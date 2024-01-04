using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisionModel.UCControls
{
    /// <summary>
    /// 视觉窗体
    /// </summary>
    public partial class UCCCD : UserControl
    {
        public UCCCD()
        {
            InitializeComponent();
            this.Load += UCCCD_Load;
        }

        private void UCCCD_Load(object sender, EventArgs e)
        {
            CCD cCDL = new CCD(VisionModel.HIKVision.Instance.CameraL);
            kryptonSplitContainer1.Panel1.Controls.Add(cCDL);
           
            CCD cCDR = new CCD(VisionModel.HIKVision.Instance.CameraR);
            kryptonSplitContainer1.Panel2.Controls.Add(cCDR);
        }
    }
}
