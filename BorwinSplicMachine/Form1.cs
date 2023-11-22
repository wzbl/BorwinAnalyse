using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorwinSplicMachine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            BorwinAnalyse.Forms.AnalyseMainForm analyseMainForm =new BorwinAnalyse.Forms.AnalyseMainForm();
            analyseMainForm.Show();
        }
    }
}
