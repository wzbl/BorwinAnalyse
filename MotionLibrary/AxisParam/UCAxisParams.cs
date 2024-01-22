using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotionLibrary.AxisParam
{
    public partial class UCAxisParams : UserControl
    {
        public UCAxisParams()
        {
            InitializeComponent();
            this.Load += UCAxisParams_Load;
        }

        private void UCAxisParams_Load(object sender, EventArgs e)
        {
            pptMotion.SelectedObject = Managers.MotionManager.Instance.Motion_GC.OptionMotion;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Managers.MotionManager.Instance.Motion_GC.OptionMotion.Save();
        }
    }
}
