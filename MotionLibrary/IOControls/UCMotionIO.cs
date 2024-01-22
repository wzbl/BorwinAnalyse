using MotionLibrary.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotionLibrary.IOControls
{
    public partial class UCMotionIO : UserControl
    {
        public UCMotionIO()
        {
            InitializeComponent();
            this.Load += UCMotionIO_Load;
        }
        private List<InputControl> motionInList = new List<InputControl>();
        private List<OutputControl> motionOutList = new List<OutputControl>();

        private void UCMotionIO_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < MotionManager.Instance.InBitControl.IOParameters.Length; i++)
            {
                InputControl inputControl = new InputControl();
                inputControl.Left = 24 + (i % 4) * 173;
                inputControl.Top = 24 + (i / 4) * 56;
                motionInList.Add(inputControl);
                tabPage1.Controls.Add(inputControl);
            }

            for (int i = 0; i < MotionManager.Instance.OutBitControl.IOParameters.Length; i++)
            {
                OutputControl outputControl = new OutputControl();
                outputControl.Left = 24 + (i % 4) * 173;
                outputControl.Top = 24 + (i / 4) * 56;
                motionOutList.Add(outputControl);
                tabPage2.Controls.Add(outputControl);
                outputControl.OutputIndex = i;
            }
            comboBox1.SelectedIndex = 0;
            timer1.Start();
        }



        private void btnConnect_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < motionInList.Count; i++)
            {
                motionInList[i].Value = MotionManager.Instance.Motion_GC.Read_INIO(i);
            }
            for (int i = 0; i < motionOutList.Count; i++)
            {
                motionOutList[i].Value = MotionManager.Instance.Motion_GC.Read_OutIO(i);
            }
            MotionManager.Instance.Motion_GC.RobotStatusRead(comboBox1.SelectedIndex);

            btnAlarm.BackColor = MotionManager.Instance.Motion_GC.AxisSt[comboBox1.SelectedIndex].DriveAlarm ? Color.Green : Color.Gray;
            btnSero.BackColor = MotionManager.Instance.Motion_GC.AxisSt[comboBox1.SelectedIndex].Enabled ? Color.Green : Color.Gray;
            btnMotion.BackColor = MotionManager.Instance.Motion_GC.AxisSt[comboBox1.SelectedIndex].IsRunning ? Color.Green : Color.Gray;
            button7.BackColor = MotionManager.Instance.Motion_GC.AxisSt[comboBox1.SelectedIndex].DriveAlarm ? Color.Green : Color.Gray;
            btnLimitDown.BackColor = MotionManager.Instance.Motion_GC.AxisSt[comboBox1.SelectedIndex].NegativeLimit ? Color.Green : Color.Gray;
            btnLimitUp.BackColor = MotionManager.Instance.Motion_GC.AxisSt[comboBox1.SelectedIndex].PositiveLimit ? Color.Green : Color.Gray;
            btnInPos.BackColor = MotionManager.Instance.Motion_GC.AxisSt[comboBox1.SelectedIndex].IsArrival ? Color.Green : Color.Gray;
            btnError.BackColor = MotionManager.Instance.Motion_GC.AxisSt[comboBox1.SelectedIndex].DriveAlarm ? Color.Green : Color.Gray;
            button15.BackColor = MotionManager.Instance.Motion_GC.AxisSt[comboBox1.SelectedIndex].NegativeSoftLimit ? Color.Green : Color.Gray;
            button14.BackColor = MotionManager.Instance.Motion_GC.AxisSt[comboBox1.SelectedIndex].PositiveSoftLimit ? Color.Green : Color.Gray;
            btnGet.BackColor = MotionManager.Instance.Motion_GC.AxisSt[comboBox1.SelectedIndex].DriveAlarm ? Color.Green : Color.Gray;
            btnQuackStop.BackColor = MotionManager.Instance.Motion_GC.AxisSt[comboBox1.SelectedIndex].DriveAlarm ? Color.Green : Color.Gray;

            lbCommPos.Text = MotionManager.Instance.Motion_GC.AxisSt[comboBox1.SelectedIndex].Position.ToString();
            lbRealPos.Text = MotionManager.Instance.Motion_GC.AxisSt[comboBox1.SelectedIndex].RealPosition.ToString();
            lbVal.Text = MotionManager.Instance.Motion_GC.AxisSt[comboBox1.SelectedIndex].AxisVel.ToString();

            if (MotionManager.Instance.Motion_GC.AxisSt[comboBox1.SelectedIndex].Enabled)
            {

                button1.BackColor = Color.Green;
                button1.Text = "关闭使能";

            }
            else
            {

                button1.BackColor = Color.Gray;
                button1.Text = "打开使能";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MotionManager.Instance.Motion_GC.AxisSt[comboBox1.SelectedIndex].Enabled)
            {
                bool res = MotionManager.Instance.Motion_GC.RobotServoOff(comboBox1.SelectedIndex);
            }
            else
            {
                bool res = MotionManager.Instance.Motion_GC.RobotServoOn(comboBox1.SelectedIndex);

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            double acc = MotionManager.Instance.Motion_GC.OptionMotion.AXIS[comboBox1.SelectedIndex].MotionParam.Acceleration;                          //加速度
            double dec = MotionManager.Instance.Motion_GC.OptionMotion.AXIS[comboBox1.SelectedIndex].MotionParam.DecAcceleration;                          //减加速度
            double endVel = MotionManager.Instance.Motion_GC.OptionMotion.AXIS[comboBox1.SelectedIndex].MotionParam.EndVelocity;                           //结束速度
            double startVel = MotionManager.Instance.Motion_GC.OptionMotion.AXIS[comboBox1.SelectedIndex].MotionParam.JumpVelocity;         //起跳速度
            double Vel = MotionManager.Instance.Motion_GC.OptionMotion.AXIS[comboBox1.SelectedIndex].MotionParam.Velocity;
            short smoothCoef = MotionManager.Instance.Motion_GC.OptionMotion.AXIS[comboBox1.SelectedIndex].MotionParam.SmoothCoef;                          //平滑系数
            int.TryParse(txtTargetPos.Text, out int tgtPos);                             //目标位置
            MotionManager.Instance.Motion_GC.MovePtpAbs(acc, dec, startVel, endVel, Vel, smoothCoef, tgtPos);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double acc = MotionManager.Instance.Motion_GC.OptionMotion.AXIS[comboBox1.SelectedIndex].MotionParam.Acceleration;                          //加速度
            double dec = MotionManager.Instance.Motion_GC.OptionMotion.AXIS[comboBox1.SelectedIndex].MotionParam.DecAcceleration;                          //减加速度
            double endVel = MotionManager.Instance.Motion_GC.OptionMotion.AXIS[comboBox1.SelectedIndex].MotionParam.EndVelocity;                           //结束速度
            double startVel = MotionManager.Instance.Motion_GC.OptionMotion.AXIS[comboBox1.SelectedIndex].MotionParam.JumpVelocity;         //起跳速度
            double Vel = MotionManager.Instance.Motion_GC.OptionMotion.AXIS[comboBox1.SelectedIndex].MotionParam.Velocity;
            short smoothCoef = MotionManager.Instance.Motion_GC.OptionMotion.AXIS[comboBox1.SelectedIndex].MotionParam.SmoothCoef;                          //平滑系数
            int.TryParse(txtTargetPos.Text, out int tgtPos);                             //目标位置
            MotionManager.Instance.Motion_GC.MovePtpAbs(acc, dec, startVel, endVel, Vel, smoothCoef, -tgtPos);
        }

        /// <summary>
        /// 停止运动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            MotionManager.Instance.Motion_GC.MoveStop(0);
        }

        /// <summary>
        /// 开始回零
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGoHome_Click(object sender, EventArgs e)
        {
            
            MotionManager.Instance.Motion_GC.Set_HomeSearch(0,0,1,1);
        }
        
        /// <summary>
        /// 停止回零
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStopGoHome_Click(object sender, EventArgs e)
        {
            MotionManager.Instance.Motion_GC.Set_HomeSearchStop(0);
        }
    }
}
