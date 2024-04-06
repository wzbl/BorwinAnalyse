using Alarm;
using BorwinAnalyse.BaseClass;
using BorwinAnalyse.DataBase.Model;
using BorwinAnalyse.UCControls;
using BorwinSplicMachine.BarCode;
using BorwinSplicMachine.FlowModel;
using BorwinSplicMachine.LCR;
using ComponentFactory.Krypton.Toolkit;
using LibSDK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorwinSplicMachine
{
    public partial class UCMain : UserControl
    {
        public UCMain()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Load += UCMain_Load;
            this.components = new System.ComponentModel.Container();

            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
        }

        private void UCMain_Load(object sender, EventArgs e)
        {
            UpdataLanguage();
       
            kryptonSplitContainer2.Panel2.Controls.Add(Form1.MainControl.UCLCR);
            timer1.Start();
        }
        public void UpdataLanguage()
        {
            LanguageManager.Instance.UpdateLanguage(this, this.components.Components);
        }
     

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }


        BarCodeCheck barCode = new BarCodeCheck();

        /// <summary>
        /// 测试检验条码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            Form1.MainControl.CheckCode(txtBarcode1.Text);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!ParamManager.Instance.System_条码.B)
            {
                txtBarcode1.Enabled = false;
                txtbarCode2.Enabled = false;
            }
            else
            {
                if (Form1.MainControl.CodeControl.Code1.IsSuccess)
                {
                    txtBarcode1.Enabled = false;
                    txtBarcode1.Text = Form1.MainControl.CodeControl.Code1.Code;
                    if (!Form1.MainControl.CodeControl.Code2.IsSuccess)
                    {
                        txtbarCode2.Focus();
                        txtbarCode2.Enabled = true;
                        txtbarCode2.Text = "";
                    }
                    else
                    {
                        txtbarCode2.Enabled = false;
                        txtbarCode2.Text = Form1.MainControl.CodeControl.Code2.Code;
                    }
                }
                else
                {
                    txtBarcode1.Enabled = true;
                    txtbarCode2.Enabled = false;
                    txtBarcode1.Text = "";
                    txtbarCode2.Text = "";

                    txtBarcode1.Focus();
                }
            }
      

            if (rad8mm.Checked)
            {
                MotControl.runnersWidth = RunnersWidth._8mm;
            }
            else if (rad12mm.Checked)
            {
                MotControl.runnersWidth = RunnersWidth._12mm;
            }
            else if (rad16mm.Checked)
            {
                MotControl.runnersWidth = RunnersWidth._16mm;
            }
            else if (rad24mm.Checked)
            {
                MotControl.runnersWidth = RunnersWidth._24mm;
            }
            else
            {
                MotControl.runnersWidth = RunnersWidth._8mm;
            }
            if (Form1.MainControl.motControl.resetFlow==ResetFlow.None&& Form1.MainControl.motControl.FlowLeft == MainFlow.None && Form1.MainControl.motControl.FlowRight == MainFlow.None)
                Form1.MainControl.motControl.SetRunnersWidth();
            if (Alarm.AlarmControl.Alarm != Alarm.AlarmList.None)
            {
                timer1.Stop();
                FormAlarm formAlarm = new FormAlarm(DateTime.Now.ToString(), Alarm.AlarmControl.Alarm.ToString(), "admin");
                //if (MotionControl.CardAPI.IsInitCardOK)
                //    MotControl.蜂鸣器.On();
                Form1.MainControl.motControl.Stop();
                if (formAlarm.ShowDialog() == DialogResult.Yes)
                {
                    //if (MotionControl.CardAPI.IsInitCardOK)
                    //    MotControl.蜂鸣器.Off();
                    timer1.Start();
                }

            }

            bool IsStart = Form1.MainControl.CodeControl.Code1.IsSuccess;
            if (!ParamManager.Instance.System_条码.B)
            {
                IsStart = (Form1.MainControl.motControl.FlowLeft != MainFlow.None || Form1.MainControl.motControl.FlowRight != MainFlow.None);
            }
            rad8mm.Enabled = IsStart ? false : true;
            rad12mm.Enabled = IsStart ? false : true;
            rad16mm.Enabled = IsStart ? false : true;
            rad24mm.Enabled = IsStart ? false : true;
        }

        private void txtBarcode1_TextChanged(object sender, EventArgs e)
        {
            Form1.MainControl.CheckCode(txtBarcode1.Text);
        }

        private void txtbarCode2_TextChanged(object sender, EventArgs e)
        {
            Form1.MainControl.CheckCode(txtbarCode2.Text);
        }

        private void btnClearCode_Click(object sender, EventArgs e)
        {
            Form1.MainControl.ClearCode();
            txtBarcode1.Text = "";
            txtbarCode2.Text = "";
        }

        private void rad8mm_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
