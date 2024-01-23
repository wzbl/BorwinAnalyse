using LibSDK.Enums;
using LibSDK.Motion;
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
        MoveType moveType = MoveType.绝对运动模式;
        public AxisControl()
        {
            InitializeComponent();
            this.Load += AxisControl_Load;
        }

        private void AxisControl_Load(object sender, EventArgs e)
        {
            //MotAPI = MotionControl.AddAxis("A轴");
            //lbAxisName.Text = MotAPI.Name;
        }

        bool IsServon = false;
        private void btnOpenSero_Click(object sender, EventArgs e)
        {
            if (IsServon)
            {
                MotAPI.SetServoff();
                btnOpenSero.Text = "打开使能";
            }
            else
            {
                MotAPI.SetServon();
                btnOpenSero.Text = "关闭使能";
            }

        }

        private void btnPositive_Click(object sender, EventArgs e)
        {
            double.TryParse(txtPos.Text, out double spd);
            switch (moveType)
            {
                case MoveType.相对运动模式:
                    MotAPI.PMove(3, 5, spd, 0);
                    break;
                case MoveType.绝对运动模式:
                    MotAPI.PMove(3, 5, spd, 1);
                    break;
                case MoveType.JOG:

                    MotAPI.JOP(0, spd);
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
            MotAPI.Home(50,10,5,0,0,0,100);
        }

        private void ComMoveType_SelectedIndexChanged(object sender, EventArgs e)
        {
            moveType = (MoveType)ComMoveType.SelectedIndex;
        }

        private void btnNagetive_Click(object sender, EventArgs e)
        {
            double.TryParse(txtPos.Text, out double spd);
            switch (moveType)
            {
                case MoveType.相对运动模式:
                    MotAPI.PMove(3, 5, -spd, 0);
                    break;
                case MoveType.绝对运动模式:
                    MotAPI.PMove(3, 5, -spd, 1);
                    break;
                case MoveType.JOG:

                    MotAPI.JOP(1, 300);
                    break;
                default:
                    break;
            }
        }
    }
}
