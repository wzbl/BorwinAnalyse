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
    public partial class UCMotionParamSet : UserControl
    {
        public UCMotionParamSet()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Tag.ToString().Trim() == "Axis")
            {
                MotionControl.AxisParm.Write();
            }
            else if (this.Tag.ToString().Trim() == "INIO")
            {
                MotionControl.IOParmIn.Write();
            }
            else if (this.Tag.ToString().Trim() == "OUTIO")
            {
                MotionControl.IOParmOut.Write();
            }


        }
    }
}
