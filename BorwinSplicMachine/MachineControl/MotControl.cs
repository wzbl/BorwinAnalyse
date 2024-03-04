using LibSDK;
using LibSDK.Motion;
using Mes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
        public MainFlow mainFlow = MainFlow.None;
        public MotControl()
        {

        }

        public virtual void Run()
        {
            switch (mainFlow)
            {
                case MainFlow.None:
                    break;
                case MainFlow.扫码:
                    break;
                case MainFlow.扫码完成:
                    break;
                case MainFlow.进料:

                    break;
                case MainFlow.感应料带到光源位置:
                    break;
                case MainFlow.找空料:
                    break;
                case MainFlow.找空料完成:
                    break;
                case MainFlow.切空料:
                    break;
                case MainFlow.切空料完成:
                    break;
                case MainFlow.请求测值:
                    break;
                case MainFlow.测值完成:
                    break;
                case MainFlow.丝印:
                    break;
                case MainFlow.丝印完成:
                    break;
                case MainFlow.贴膜:
                    break;
                case MainFlow.贴膜完成:
                    break;
                default:
                    break;
            }
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
        进料,//齿轮转动
        感应料带到光源位置,//齿轮走一格
        找空料,//拍照
        找空料完成,//去切空料位
        切空料,
        切空料完成,//去测值位，到位信号
        请求测值,//测值失败走一格
        测值完成,
        丝印,
        丝印完成,
        贴膜,
        贴膜完成
    }

    //屏蔽扫码，屏蔽相机
}
