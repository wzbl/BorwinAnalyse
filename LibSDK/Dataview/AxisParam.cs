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

namespace LibSDK.Dataview
{
    public partial class AxisParam : Form
    {
        public AxisParam()
        {
            InitializeComponent();
        }

        public AxisParam(CAxisParm cAxisParm):this()
        {
            PPTParam.SelectedObject = cAxisParm;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MotionControl.AxisParm.Write();
            MotionControl.InitAxis();
        }
    }
}
