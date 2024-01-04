using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorwinSplicMachine.FlowModel
{
    [Serializable]
    public partial class FlowFindEmptyStrips : FlowBaseModel
    {
        public FlowFindEmptyStrips()
        {
            InitializeComponent();
            FlowControl = new FlowFindEmptyStripsControl();
            FlowControl.FlowModeControl.FlowModel = this;
            FlowControl.FlowModeControl.ModelName = ModelType.找空料;
        }
    }
}
