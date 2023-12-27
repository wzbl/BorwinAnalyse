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

        public Dictionary<FlowBaseModel, BaseModelPos> InFlow = new Dictionary<FlowBaseModel, BaseModelPos>();

        public  Dictionary<FlowBaseModel, BaseModelPos> outFlows = new Dictionary<FlowBaseModel, BaseModelPos>();

        //public FlowBaseModel FlowModel { get; set; }

        public bool RunResult = false;
        /// <summary>
        /// 运行
        /// </summary>
        public  abstract void Run();

    }
}
