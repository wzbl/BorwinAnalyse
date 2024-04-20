using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alarm
{
    public partial class FormAlarm : Form
    {
        public FormAlarm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="time"></param>
        /// <param name="alarm"></param>
        /// <param name="emp"></param>
        /// <param name="type">0默认系统报警,1测值失败人工判定</param>
        public FormAlarm(string time, string alarm, string emp,int type=0) : this()
        {
            lbTime.Text = time;
            lbAlarm.Text = alarm;
            lbemp.Text = emp;
            BtnOK.Visible=false;
            if (type == 1 )
            {
                BtnOK.Visible = true;
                BtnClose.Visible = true;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            AlarmControl.Alarm = AlarmList.None;
            AlarmControl.ReSet?.Invoke();
            DialogResult = DialogResult.Yes;
        }

        /// <summary>
        /// 人工OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
