using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BorwinSplicMachine.FlowModel
{
    [Serializable]
    public class FlowLCR : FlowBaseControl
    {
        public FlowLCR()
        {
            ModelName = "LCR";
        }

        public override void Run()
        {
           
        }
    }
}
