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
    public partial class FlowMatchModel : FlowBaseModel
    {
        public FlowMatchModel()
        {
            InitializeComponent();
            FlowControl = new FlowMatchControl();
            FlowControl.FlowModeControl.FlowModel = this;
            FlowControl.FlowModeControl.ModelName = ModelType.丝印;
        }
    }
}
