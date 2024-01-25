using LibSDK.Enums;
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
        Color Color = Color.White;
        public AxisControl(MotAPI MotAPI)
        {
            InitializeComponent();
            this.Load += AxisControl_Load;
            this.MotAPI = MotAPI;
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
            double spd = UCAxisControl.pos;
            switch (UCAxisControl.moveType)
            {
                case MoveType.相对运动模式:
                    MotAPI.PMove(spd, 0);
                    break;
                case MoveType.绝对运动模式:
                    MotAPI.PMove(spd, 1);
                    break;
                case MoveType.JOG:

                    MotAPI.JOP(0);
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
            double spd = UCAxisControl.pos;
            switch (UCAxisControl.moveType)
            {
                case MoveType.相对运动模式:
                    MotAPI.PMove(-spd, 0, true);
                    break;
                case MoveType.绝对运动模式:
                    MotAPI.PMove(-spd, 1, true);
                    break;
                case MoveType.JOG:

                    MotAPI.JOP(1);
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
            txtPos.Text = MotAPI.GetPrfPos().ToString();
            txtRel.Text = MotAPI.GetEncPos().ToString();

            btnOpenSero.BackColor = MotAPI.GetSevOn() ? Color.Green : Color;
            if (MotAPI.axisError.IsError)
            {
                errorPanel.Visible = true;
                lbErrorMsg.Text = MotAPI.Name + ":" + MotAPI.axisError.ErrorMsg;
            }
            else
            {
                errorPanel.Visible = false;
            }
            if (MotAPI.GetHomeDirection() == 0)
            {
                dSignalLamp1.Value = MotAPI.HomeState ? 1 : 0;
            }
            else
            {
                dSignalLamp2.Value = MotAPI.HomeState ? 1 : 0;
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
    }
}
