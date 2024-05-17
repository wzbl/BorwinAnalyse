using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alarm
{
    /// <summary>
    /// 报警类
    /// </summary>
    public class AlarmControl
    {
        public static AlarmList Alarm = AlarmList.None;
        public static Action ReSet;
    }

    /// <summary>
    /// 报警枚举
    /// </summary>
    public enum AlarmList
    {
        None,
        控制卡打开异常,
        左侧_测值异常,
        右侧_测值异常,
        找空料超时,
        测值超时,
        丝印超时,
        接料超时异常,
        推拉门打开异常,
        进料带超时,
        请取走料带,
        吸膜超时,
        电池电量低,
        试用次数满,
        急停,
        两侧料带间距不一致
    }

    //流道调宽回零异常,
    //    凸轮回零异常,
    //    左进入回零异常,
    //    右进入回零异常,
    //    吸头平移回零异常,
    //    吸头上下回零异常,
    //    热熔上下回零异常,
    //    拨刀回零异常,
    //    探针A回零异常,
    //    探针B回零异常,
    //    测值整体上下回零异常,
    //    下针回零异常,
}
