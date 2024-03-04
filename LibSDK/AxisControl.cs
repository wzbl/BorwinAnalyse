using BorwinAnalyse.BaseClass;
using ComponentFactory.Krypton.Toolkit;
using LibSDK.AxisParamDebuger;
using LibSDK.Enums;
using LibSDK.IO;
using LibSDK.Motion;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibSDK
{
    public partial class AxisControl : UserControl
    {
        MotAPI MotAPI = null;
        CAxisParm CAxisParm= null;
        Color Color = Color.White;
        public MoveType moveType = MoveType.绝对运动模式;
        public double pos;


        public AxisControl()
        {
            InitializeComponent();
        }

        public AxisControl(MotAPI MotAPI) : this()
        {
            this.Dock = DockStyle.Top;
            errorPanel.Dock = DockStyle.Fill;
            this.Load += AxisControl_Load;
            this.MotAPI = MotAPI;
            CAxisParm = MotionControl.AxisParm.GetAxisParm(MotAPI.CardNum, MotAPI.Axis);
            txtVel.Text = CAxisParm.AxisMotionPara.MotionSped.ToString();
            comMotionType.SelectedIndex = 1;
            RefreshDebugUI();
            MotionControl.AddPos += RefreshDebugUI;
        }


        private void RefreshDebugUI()
        {
            kryptonSplitContainer1.Panel2.Controls.Clear();
            if (DebugerAxisParam.Instance.BaseAxisParams==null)
            {
                return;
            }
            List<BaseAxisParam> baseAxisParams = DebugerAxisParam.Instance.BaseAxisParams.Where(x => x.CardNo == MotAPI.CardNum && x.AxisNo == MotAPI.Axis).ToList();

            if (baseAxisParams.Count>0)
            {
                BaseAxisParam baseAxisParam = baseAxisParams[0];
                for (int i = 0; i < baseAxisParam.posParams.Count; i++)
                {
                    KryptonButton kryptonButton = new KryptonButton();
                    kryptonButton.Text = baseAxisParam.posParams[i].Name;
                    kryptonSplitContainer1.Panel2.Controls.Add(kryptonButton);
                    kryptonButton.Left = 10 + (i % 4) * 120;
                    kryptonButton.Top = 15 + (i / 4) * 50;
                    kryptonButton.Tag = baseAxisParam.posParams[i].Pos;
                    kryptonButton.Click += KryptonButton_Click;
                }
            }
        }

        private void KryptonButton_Click(object sender, EventArgs e)
        {
            if (double.TryParse(((KryptonButton)sender).Tag.ToString(), out double pos))
            {
                MotAPI.PMove(pos, 1);
            }
        }

        private void AxisControl_Load(object sender, EventArgs e)
        {
            lbName.Text = MotAPI.Name;
            Color = btnPositive.BackColor;

        }

        private void btnOpenSero_Click(object sender, EventArgs e)
        {
            if (btnOpenSero.BackColor == Color.Green)
            {
                MotAPI.SetServoff();
            }
            else
            {
                MotAPI.SetServon();
            }
        }

        private void btnPositive_Click(object sender, EventArgs e)
        {

            if (!double.TryParse(txtPos.Text, out pos))
            {
                txtPos.BackColor = Color.Red;
                return;
            }
            txtPos.BackColor = Color.White;
            double spd = pos;
            switch (moveType)
            {
                case MoveType.相对运动模式:
                    MotAPI.PMove(spd, 0);
                    break;
                case MoveType.绝对运动模式:
                    MotAPI.PMove(spd, 1);
                    break;
                default:
                    break;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            MotAPI.AxisStop();
        }

        private void btnStopGoHome_Click(object sender, EventArgs e)
        {
            MotAPI.AxisStop();
        }

        private void btnStartGoHome_Click(object sender, EventArgs e)
        {
            MotAPI.Home(1000);
        }

        private void btnNagetive_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtPos.Text, out pos)) 
            {
                txtPos.BackColor = Color.Red;
                return;
            }
            txtPos.BackColor = Color.White;
            double spd = pos;
            switch (moveType)
            {
                case MoveType.相对运动模式:
                    MotAPI.PMove(-spd, 0, true);
                    break;
                case MoveType.绝对运动模式:
                    MotAPI.PMove(-spd, 1, true);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 刷新状态
        /// </summary>
        public void RefreshUI()
        {
            txtRel.Text = MotAPI.GetEncPos().ToString();

            btnOpenSero.BackColor = MotAPI.GetSevOn() ? Color.Green : Color;
            if (MotAPI.axisError.IsError)
            {
                errorPanel.Visible = true;
                lbErrorMsg.Text = MotAPI.axisError.ErrorMsg;
            }
            else
            {
                errorPanel.Visible = false;
            }
            dSignalLamp1.Value = MotAPI.HomeState ? 1 : 0;
        }

        public void EmgStop()
        {
            MotAPI.EmgAxisStop();
        }

        private void btnAlarmReset_Click(object sender, EventArgs e)
        {
            ClearAlarm();
        }

        /// <summary>
        /// 清除报警
        /// </summary>
        public void ClearAlarm()
        {
            MotionControl.CardAPI.ClearSts();
            MotAPI.axisError.ErrorMsg = "";
            MotAPI.axisError.IsError = false;
        }

        bool IsDown = false;
        private void btnPositive_MouseDown(object sender, MouseEventArgs e)
        {
            IsDown = true;
            if (moveType == MoveType.JOG)
                MotAPI.JOP(short.Parse(((KryptonButton)sender).Tag.ToString()));
        }

        private void btnPositive_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsDown && moveType == MoveType.JOG)
            {
                MotAPI.AxisStop();
                IsDown = false;
            }
        }

        private void btnEmgStop_Click(object sender, EventArgs e)
        {
            MotionControl.CardAPI.StopEmgAxis();
        }

        private void comMotionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            moveType = (MoveType)comMotionType.SelectedIndex;
        }

        private void btnSetVel_Click(object sender, EventArgs e)
        {
            if (float.TryParse(txtVel.Text,out float vel))
            {
                CAxisParm.AxisMotionPara.MotionSped = vel;
                MotionControl.AxisParm.Write();
                txtVel.BackColor = Color.White;
            }
            else
            {
                txtVel.BackColor = Color.Red;
            }
        }
    }
}
