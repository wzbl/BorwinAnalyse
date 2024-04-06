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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibSDK
{
    public partial class AxisControl : UserControl
    {
        MotAPI MotAPI = null;
        CAxisParm CAxisParm = null;
        Color Color = Color.White;
        public MoveType moveType = MoveType.绝对运动模式;
        public double pos;
        Input 胶膜1到位 = null;
        double sped = 0;
        double Acc = 0;

        /// <summary>
        /// 卷料按钮
        /// </summary>
        KryptonButton kryptonButton = null;
        /// <summary>
        /// 位置列表
        /// </summary>
        BaseAxisParam baseAxisParam;

        public AxisControl()
        {
            InitializeComponent();
        }

        public AxisControl(MotAPI MotAPI) : this()
        {
            errorPanel.Dock = DockStyle.Fill;
            this.Load += AxisControl_Load;
            this.MotAPI = MotAPI;
            CAxisParm = MotionControl.AxisParm.GetAxisParm(MotAPI.CardNum, MotAPI.Axis);
            kryptonTrackBar1.Maximum = (int)CAxisParm.AxisMotionPara.MaxManualMoveSpd;
            kryptonTrackBar2.Maximum = (int)CAxisParm.AxisMotionPara.MaxAcc;
            if (CAxisParm.AxisMotionPara.MotionSped <= CAxisParm.AxisMotionPara.MaxManualMoveSpd)
            {
                kryptonTrackBar1.Value = (int)CAxisParm.AxisMotionPara.MotionSped;
                txtVel.Text = kryptonTrackBar1.Value.ToString();
            }
            if (CAxisParm.AxisMotionPara.MotionAcc <= CAxisParm.AxisMotionPara.MaxAcc)
            {
                kryptonTrackBar2.Value = (int)CAxisParm.AxisMotionPara.MotionAcc;
                txtAcc.Text = kryptonTrackBar2.Value.ToString();
            }
            comMotionType.SelectedIndex = 1;
            txtPos.Text = "10";

            if (MotAPI.Name == "卷料")
            {
                c.Visible = false;
                kryptonButton = new KryptonButton();
                kryptonButton.Text = "卷一个料";
                kryptonButton.Click += KryptonButton_Click;
                kryptonButton.Dock = DockStyle.Fill;
                kryptonSplitContainer1.Panel2.Controls.Add(kryptonButton);
                胶膜1到位 = MotionControl.GetInPutIO("胶膜1到位");
                btnStartGoHome.Visible = false;
                dSignalLamp1.Visible = false;
            }
            else
            {
                c.Columns[2].DefaultCellStyle.NullValue = c.Columns[2].HeaderText.tr();
                c.Columns[3].DefaultCellStyle.NullValue = c.Columns[3].HeaderText.tr();
                c.Columns[4].DefaultCellStyle.NullValue = c.Columns[4].HeaderText.tr();
                RefreshDebugUI();
                MotionControl.AddPos += RefreshDebugUI;
                c.CellContentClick += DgvAxis_CellContentClick;
            }
            MotAPI.SetLimit(false);
            MotAPI.SetServoff();
            btnOpenSero.Enabled = false;

            this.components = new System.ComponentModel.Container();
        }

        private void KryptonButton_Click(object sender, EventArgs e)
        {
            if (!MotionControl.IsAuto)
            {
                if (胶膜1到位.IsOn())
                {
                    MotAPI.PMove(6, 0, sped, Acc);
                }
                Thread.Sleep(1000);
                kryptonButton.Enabled = false;
            }
           
        }

        private void DgvAxis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row < 0 || c.Rows[row].Cells[1].Value == null) return;
            int column = e.ColumnIndex;
            switch (column)
            {
                case 2:
                    c.Rows[row].Cells[1].Value = txtRel.Text;
                    break;
                case 3:
                    if (baseAxisParam != null && double.TryParse(c.Rows[row].Cells[1].Value.ToString(), out double pv))
                    {
                        baseAxisParam.posParams[row].Pos = pv;
                        DebugerAxisParam.Instance.Save();
                    }
                    break;
                case 4:
                    if (double.TryParse(c.Rows[row].Cells[1].Value.ToString(), out double p))
                    {
                        if (MotAPI.Name == "左进入" || MotAPI.Name == "右进入")
                        {
                            MotAPI.PMove(-p, 0, sped, Acc);
                        }
                        MotAPI.PMove(p, 1, sped, Acc);
                    }

                    break;
                default:
                    break;
            }
        }

        private void RefreshDebugUI()
        {
            c.Rows.Clear();
            if (DebugerAxisParam.Instance.BaseAxisParams == null)
            {
                return;
            }
            List<BaseAxisParam> baseAxisParams = DebugerAxisParam.Instance.BaseAxisParams.Where(x => x.CardNo == MotAPI.CardNum && x.AxisNo == MotAPI.Axis).ToList();

            if (baseAxisParams.Count > 0)
            {
                baseAxisParam = baseAxisParams[0];
                for (int i = 0; i < baseAxisParam.posParams.Count; i++)
                {
                    MotAPI.posParams.Add(baseAxisParam.posParams[i]);
                    c.Rows.Add(
                        baseAxisParam.posParams[i].Name.tr(),
                        baseAxisParam.posParams[i].Pos
                        );
                }
            }
        }


        private void AxisControl_Load(object sender, EventArgs e)
        {
            lbName.Text = MotAPI.Name;
            Color = btnPositive.BackColor;
            UpdataLanguage();
        }
        public void UpdataLanguage()
        {
            LanguageManager.Instance.UpdateLanguage(this, this.components.Components);
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
            switch (moveType)
            {
                case MoveType.相对运动模式:
                    MotAPI.PMove(pos, 0, sped, Acc);
                    break;
                case MoveType.绝对运动模式:
                    MotAPI.PMove(pos, 1, sped, Acc);
                    break;
                default:
                    break;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            MotAPI.AxisStop();
            btnStartGoHome.Enabled = true;
        }



        private void btnStartGoHome_Click(object sender, EventArgs e)
        {
            MotAPI.Home(1000);
            btnStartGoHome.Enabled = false;
        }

        private void btnNagetive_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtPos.Text, out pos))
            {
                txtPos.BackColor = Color.Red;
                return;
            }
            txtPos.BackColor = Color.White;
            switch (moveType)
            {
                case MoveType.相对运动模式:
                    MotAPI.PMove(-pos, 0, sped, Acc, true);
                    break;
                case MoveType.绝对运动模式:
                    MotAPI.PMove(-pos, 1, sped, Acc, true);
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
            if (MotionControl.IsAuto)
            {
                btnNagetive.Enabled = false;
                btnStartGoHome.Enabled = false;
                btnPositive.Enabled = false;
                btnStartGoHome.Enabled = false;
                btnStop.Enabled = false;
                c.Enabled = false;
            }
            else
            {
                btnNagetive.Enabled = true;
                btnStartGoHome.Enabled = true;
                btnPositive.Enabled = true;
                btnStartGoHome.Enabled = true;
                btnStop.Enabled = true;
                c.Enabled = true;
            }

            txtRel.Text = MotAPI.GetEncPos().ToString();

            btnOpenSero.BackColor = MotAPI.GetSevOn() ? Color : Color.Green;
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


            if (kryptonButton != null && !kryptonButton.Enabled)
            {
                if (胶膜1到位.IsOn())
                {
                    kryptonButton.Enabled = true;
                    MotAPI.AxisStop();
                }
                else
                {
                    MotAPI.PMove(1, 0, sped, Acc);
                }
            }

            if (!MotionControl.IsAuto&&MotAPI.HomeState)
            {
                btnStartGoHome.Enabled = true;
            }

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

        /// <summary>
        /// 设置速度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtVel_TextChanged(object sender, EventArgs e)
        {
            double.TryParse(txtVel.Text, out sped);
        }

        /// <summary>
        /// 设置加速度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAcc_TextChanged(object sender, EventArgs e)
        {
            double.TryParse(txtAcc.Text, out Acc);
        }

        private void kryptonTrackBar1_ValueChanged(object sender, EventArgs e)
        {
            txtVel.Text = kryptonTrackBar1.Value.ToString();
        }

        private void kryptonTrackBar2_ValueChanged(object sender, EventArgs e)
        {
            txtAcc.Text = kryptonTrackBar2.Value.ToString();
        }
    }
}
