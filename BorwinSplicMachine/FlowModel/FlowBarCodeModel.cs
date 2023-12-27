using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorwinSplicMachine.FlowModel
{
    public partial class FlowBarCodeModel : FlowBaseModel
    {
        public FlowBarCodeModel()
        {
            InitializeComponent();
            ModelName = "条码";
            FlowControl = new FlowBarCode();
            FlowControl.FlowModel = this;
            CommFun();
        }
    }
}
