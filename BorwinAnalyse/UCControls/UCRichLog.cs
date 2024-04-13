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
            this.Load += UCRichLog_Load;
        
        }

        private void UCRichLog_Load(object sender, EventArgs e)
        {
            LogManager.Instance.LogMsg += WriteLog;
           
        }

        private void WriteLog(string msg)
        {
            this.Invoke(new Action(() => 
            { 
                richLog.Text += msg + "\r\n";
                richLog.SelectionStart = richLog.Text.Length;
                richLog.ScrollToCaret();
            }));

          
        }

        private void buttonSpecAny1_Click(object sender, EventArgs e)
        {
            richLog.Clear();
        }
    }
}
