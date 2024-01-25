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
    public partial class UCMotionParamSet : UserControl
    {
        public UCMotionParamSet()
        {
            InitializeComponent();
            PPTParam.PropertySort = PropertySort.Alphabetical;
            PPTParam.ToolbarVisible = false;
            txtName.Font = new Font("宋体",20);
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public  string 标题
        {
            get
            {
                return txtName.Text;
            }
            set
            {
                txtName.Text=value;
            }
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
                if (!UCIOControl.RefreshInIO)
                {
                    UCIOControl.RefreshInIO = true;
                }
            }
            else if (this.Tag.ToString().Trim() == "OUTIO")
            {
                MotionControl.IOParmOut.Write();
                if (!UCIOControl.RefreshOutIO)
                {
                    UCIOControl.RefreshOutIO = true;
                }
            }
            else
            {
                BaseConfig.Instance.Write();
            }


        }

        private void PPTParam_Resize(object sender, EventArgs e)
        {
            btnSave.Location = new Point(PPTParam.Location.X + PPTParam.Width - btnSave.Width-4, PPTParam.Height - btnSave.Height+20);
        }
    }
}
