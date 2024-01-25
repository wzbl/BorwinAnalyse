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

namespace LibSDK.Enums
{
    public partial class UCMotionParam : UserControl
    {
        public UCMotionParam()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Load += UCMotionParam_Load;

            UpDateAxis();
            UpDateOUTIO();
            UpDateINIO();
            MotionControl.UpDateAxis += UpDateAxis;
            MotionControl.UpDateINIO += UpDateINIO;
            MotionControl.UpDateOUTIO += UpDateOUTIO;
        }

        private void UpDateOUTIO()
        {
            ucOUTIOParam.PPTParam.SelectedObject
             = MotionControl.IOParmOut.IOParms.ToArray();
        }

        private void UpDateINIO()
        {

            ucINIOParam.PPTParam.SelectedObject
            = MotionControl.IOParmIn.IOParms.ToArray();
        }

        private void UpDateAxis()
        {
            ucMotionParamSet1.PPTParam.SelectedObject
              = AxisParm.AParms.ToArray();
            ucCardParamSet.PPTParam.SelectedObject
          = BaseConfig.Instance.cardConfigs.ToArray();
        }

        private void UCMotionParam_Load(object sender, EventArgs e)
        {

        }

    }
}
