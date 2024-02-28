using LibSDK.Dataview;
using LibSDK.IO;
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
    public partial class UCDebugging : UserControl
    {
        public UCDebugging()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            this.Load += UCDebugging_Load;
        }

        private void UCDebugging_Load(object sender, EventArgs e)
        {
          kryptonSplitContainer1.Panel1.Controls.Add(new UCDebugAxis());
          kryptonSplitContainer1.Panel2.Controls.Add(new UCIOControl());
        }
    }
}
