using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorwinSplicMachine
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            this.Load += FormLogin_Load;
            this.FormClosed += FormLogin_FormClosed;
           
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

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 10;
           
    
            if (progressBar1.Value >= 100)
            {
                this.Close();
            }
            else if (progressBar1.Value > 35 && !Form1.MainControl.IsInitFinish)
            {
                Form1.MainControl.Init();
            }
            else if (progressBar1.Value > 70 && !Form1.MainControl.IsStartFinish)
            {
                Form1.MainControl.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label1.Text = progressBar1.Value.ToString() + "%";
            int x = (progressBar1.Width * progressBar1.Value / 100);
            label1.Location = new Point(x, 8);
        }
    }
}
