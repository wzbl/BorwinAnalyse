using LibSDK;
using LibSDK.Motion;
using Mes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BorwinSplicMachine
{
    /// <summary>
    /// 运动控制类
    /// </summary>
    public class MotControl
    {
       
        public MotControl()
        {
           
        }

        public virtual void Run()
        {

        }
    }

    /// <summary>
    /// 主流程
    /// </summary>
    public enum MainFlow
    {
        None, //判断复位OK
        扫码,
        扫码完成,
        进料,
        感应料带到光源位置,
        找空料,
        找空料完成,
        切空料,
        切空料完成,
        请求测值,
        测值完成,
        贴膜,
        贴膜完成
    }
}
