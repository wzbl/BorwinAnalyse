using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorwinSplicMachine.FlowModel
{
    [Serializable]
    public class FlowBarCode : FlowBaseControl
    {
        public FlowBarCode() {
            ModelName = "条码";
        }
        public override void Run()
        {
            
        }
    }
}
