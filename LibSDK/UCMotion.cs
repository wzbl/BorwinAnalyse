using LibSDK.IO;
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
    public partial class UCMotion : UserControl
    {
        public UCMotion()
        {
            InitializeComponent();
            this.Load += UCMotion_Load;
            this.Dock = DockStyle.Fill;
            kryptonNavigator1.Dock = DockStyle.Fill;
        }
        private void UCMotion_Load(object sender, EventArgs e)
        {
            kryptonPage1.Controls.Add(new AxisControl());
            kryptonPage2.Controls.Add(new UCIOControl());
        }

    }
}
