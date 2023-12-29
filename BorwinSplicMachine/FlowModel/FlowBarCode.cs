using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BorwinSplicMachine.FlowModel
{
    [Serializable]
    public class FlowBarCode : FlowBaseControl
    {
        public FlowBarCode() {
           

        }
        public override void Run()
        {
            this.FlowModeControl.FlowModel.BackColor = System.Drawing.Color.Green;
            this.FlowModeControl.FlowModel.Refresh();
            for (int i = 0; i < 1009999999; i++) { }
            this.FlowModeControl.FlowModel.BackColor = System.Drawing.Color.Red;
            foreach (var item in outFlows)
            {
                item.FlowModeControl.FlowModel.FlowControl.Run();
            }
        }
    }
}
