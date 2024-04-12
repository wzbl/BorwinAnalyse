using FeederSpliceVisionSys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisionModel.UCControls;

namespace BorwinSplicMachine
{
    public partial class VisiTest : Form
    {
        public VisiTest()
        {
            InitializeComponent();
            this.Controls.Add(new UCVisor());
            this.FormClosed += VisiTest_FormClosed;
        }

        private void VisiTest_FormClosed(object sender, FormClosedEventArgs e)
        {
            VisionDetection.CameraClose();
        }
    }
}
