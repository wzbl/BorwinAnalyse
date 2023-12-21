using BorwinAnalyse.BaseClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorwinAnalyse.UCControls
{
    public partial class UCRichLog : UserControl
    {
        public UCRichLog()
        {
            InitializeComponent();
            this.Dock= DockStyle.Fill;
            LogManager.Instance.LogMsg += WriteLog;
        }

        private void WriteLog(string msg)
        {
            richLog.Text += msg + "\r\n";
        }

        private void buttonSpecAny1_Click(object sender, EventArgs e)
        {
            richLog.Clear();
        }
    }
}
