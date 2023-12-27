using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorwinSplicMachine.FlowModel
{
    [Serializable]
    public abstract class FlowBaseControl
    {

        public Dictionary<FlowBaseControl, BaseModelPos> InFlow = new Dictionary<FlowBaseControl, BaseModelPos>();

        public  Dictionary<FlowBaseControl,BaseModelPos> outFlows = new Dictionary<FlowBaseControl, BaseModelPos>();

        public FlowBaseModel FlowModel { get; set; }

        public bool RunResult = false;
        /// <summary>
        /// 运行
        /// </summary>
        public  abstract void Run();

    }
}
