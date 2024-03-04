using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibSDK.IO
{
    public partial class UCIOList : UserControl
    {
        public UCIOList()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Load += UCIOList_Load;
        }

        private void UCIOList_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ucioList_IN1.RefreshUI();
            ucioList_OUT1.RefreshUI();
        }
    }
}
