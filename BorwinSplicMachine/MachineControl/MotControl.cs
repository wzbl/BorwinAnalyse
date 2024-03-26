using Alarm;
using BorwinAnalyse.BaseClass;
using BorwinSplicMachine.LCR;
using LibSDK;
using LibSDK.IO;
using LibSDK.Motion;
using Mes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BorwinSplicMachine
{
    /// <summary>
    /// 运动控制类
    /// </summary>
    public class MotControl
    {
        #region 轴
        public static MotAPI 流道调宽 = null;
        public static MotAPI 凸轮 = null;
        public static MotAPI 左进入 = null;
        public static MotAPI 右进入 = null;
        public static MotAPI 吸头平移 = null;
        public static MotAPI 吸头上下 = null;
        public static MotAPI 热熔上下 = null;
        public static MotAPI 拨刀 = null;
        public static MotAPI 卷料 = null;

        public static MotAPI 探针A = null;
        public static MotAPI 测值整体上下 = null;
        public static MotAPI 探针B = null;
        public static MotAPI 下针 = null;
        #endregion

        #region 输入IO
        public static Input 探针A原点 = null;
        public static Input 测值整体上下原点 = null;
        public static Input 探针B原点 = null;
        public static Input 下针原点 = null;
        public static Input 屏蔽按钮 = null;
        public static Input 安全门开关 = null;
        public static Input 真空表 = null;
        public static Input 左收料按钮 = null;
        public static Input 右收料按钮 = null;
        public static Input 左料盘感应 = null;
        public static Input 右料盘感应 = null;
        public static Input 左轮光栅 = null;
        public static Input 右轮光栅 = null;
        public static Input 左物料光栅 = null;
        public static Input 右物料光栅 = null;
        public static Input 左入料光栅 = null;
        public static Input 右入料光栅 = null;
        public static Input 卷料原点 = null;
        public static Input 切料光纤感应 = null;
        public static Input 切料电机接近感应 = null;
        public static Input 贴膜定位针上位 = null;
        public static Input 贴膜定位针下位 = null;
        public static Input 料尾感应光电 = null;
        public static Input 胶膜1到位 = null;
        #endregion

        #region 输出IO
        public static Output 真空电磁阀1 = null;
        public static Output 真空电磁阀2 = null;
        public static Output 真空泵 = null;
        public static Output 贴膜定位针上下 = null;
        public static Output 蜂鸣器 = null;
        public static Output 卷料压膜电池铁 = null;
        public static Output 测值支撑电磁铁 = null;
        public static Output 测值压料带电磁铁 = null;
        public static Output 测值垫高电磁铁 = null;
        public static Output 测值下针电磁铁 = null;
        public static Output 探针旋转 = null;
        public static Output 左收料 = null;
        public static Output 右收料 = null;
        #endregion

        private Task[] tasks = new Task[5];

        /// <summary>
        /// 左流程
        /// </summary>
        public MainFlow FlowLeft = MainFlow.None;

        /// <summary>
        /// 右流程
        /// </summary>
        public MainFlow FlowRight = MainFlow.None;

        /// <summary>
        /// 贴膜流程
        /// </summary>
        public FilmFlow filmFlow = FilmFlow.None;

        /// <summary>
        /// 复位流程
        /// </summary>
        public ResetFlow resetFlow = ResetFlow.None;

        /// <summary>
        /// 流程灯
        /// </summary>
        public static FlowLight flowLight = new FlowLight();

        public static RunnersWidth runnersWidth = RunnersWidth._8mm;

        public MotControl()
        {
            流道调宽 = MotionControl.GetAxis("流道调宽");
            凸轮 = MotionControl.GetAxis("凸轮");
            左进入 = MotionControl.GetAxis("左进入");
            右进入 = MotionControl.GetAxis("右进入");
            吸头平移 = MotionControl.GetAxis("吸头平移");
            吸头上下 = MotionControl.GetAxis("吸头上下");
            热熔上下 = MotionControl.GetAxis("热熔上下");
            拨刀 = MotionControl.GetAxis("拨刀");
            卷料 = MotionControl.GetAxis("卷料");
            探针A = MotionControl.GetAxis("探针A");
            测值整体上下 = MotionControl.GetAxis("测值整体上下");
            探针B = MotionControl.GetAxis("探针B");
            下针 = MotionControl.GetAxis("下针");

            探针A原点 = MotionControl.GetInPutIO("探针A原点");
            测值整体上下原点 = MotionControl.GetInPutIO("测值整体上下原点");
            探针B原点 = MotionControl.GetInPutIO("探针B原点");
            下针原点 = MotionControl.GetInPutIO("下针原点");
            屏蔽按钮 = MotionControl.GetInPutIO("屏蔽按钮");
            安全门开关 = MotionControl.GetInPutIO("安全门开关");
            真空表 = MotionControl.GetInPutIO("真空表");
            左收料按钮 = MotionControl.GetInPutIO("左收料按钮");
            右收料按钮 = MotionControl.GetInPutIO("右收料按钮");
            左料盘感应 = MotionControl.GetInPutIO("左料盘感应");
            右料盘感应 = MotionControl.GetInPutIO("右料盘感应");
            左轮光栅 = MotionControl.GetInPutIO("左轮光栅");
            右轮光栅 = MotionControl.GetInPutIO("右轮光栅");
            左物料光栅 = MotionControl.GetInPutIO("左物料光栅");
            右物料光栅 = MotionControl.GetInPutIO("右物料光栅");
            左入料光栅 = MotionControl.GetInPutIO("左入料光栅");
            右入料光栅 = MotionControl.GetInPutIO("右入料光栅");
            卷料原点 = MotionControl.GetInPutIO("卷料原点");
            切料光纤感应 = MotionControl.GetInPutIO("切料光纤感应");
            切料电机接近感应 = MotionControl.GetInPutIO("切料电机接近感应");
            贴膜定位针上位 = MotionControl.GetInPutIO("贴膜定位针上位");
            贴膜定位针下位 = MotionControl.GetInPutIO("贴膜定位针下位");
            料尾感应光电 = MotionControl.GetInPutIO("料尾感应光电");
            胶膜1到位 = MotionControl.GetInPutIO("胶膜1到位");

            真空电磁阀1 = MotionControl.GetOutPutIO("真空电磁阀1");
            真空电磁阀2 = MotionControl.GetOutPutIO("真空电磁阀2");
            真空泵 = MotionControl.GetOutPutIO("真空泵");
            贴膜定位针上下 = MotionControl.GetOutPutIO("贴膜定位针上下");
            蜂鸣器 = MotionControl.GetOutPutIO("蜂鸣器");
            卷料压膜电池铁 = MotionControl.GetOutPutIO("卷料压膜电池铁");
            测值支撑电磁铁 = MotionControl.GetOutPutIO("测值支撑电磁铁");
            测值压料带电磁铁 = MotionControl.GetOutPutIO("测值压料带电磁铁");
            测值垫高电磁铁 = MotionControl.GetOutPutIO("测值垫高电磁铁");
            测值下针电磁铁 = MotionControl.GetOutPutIO("测值下针电磁铁");
            探针旋转 = MotionControl.GetOutPutIO("探针旋转");
            左收料 = MotionControl.GetOutPutIO("左收料");
            右收料 = MotionControl.GetOutPutIO("右收料");
            AlarmControl.ReSet += Reset;
            Reset();
            Run();
        }

        private int filmCount = 0;

        public void Run()
        {

            if (tasks[0] == null || tasks[0].IsCompleted)
            {
                tasks[0] = new Task(new Action(() =>
                {
                    while (true)
                    {
                        //左
                        if (resetFlow == ResetFlow.None)
                        {
                            switch (FlowLeft)
                            {
                                case MainFlow.None:
                                    flowLight.左进入.status = 0;
                                    SetRunnersWidth();
                                    if (!ParamManager.Instance.System_条码.B && 左入料光栅.State())
                                    {
                                        FlowLeft = MainFlow.进料;
                                        flowLight.左进入.status = 1;
                                        左进入.SetServoff();
                                    }
                                    break;
                                case MainFlow.进料:
                                    //左轮开始转动
                                    左进入.PMove(-1, 0, true);
                                    if (左物料光栅.State() && 左入料光栅.State())
                                    {
                                        左进入.AxisStop();
                                        //清除坐标==》左进入
                                        flowLight.左进入.status = 2;
                                        FlowLeft = MainFlow.感应料带到光源位置;
                                        SetRunnersWidth2();
                                    }
                                    else if (!左入料光栅.State())
                                    {
                                        FlowLeft = MainFlow.None;
                                        左进入.SetServon();
                                    }
                                    break;
                                case MainFlow.感应料带到光源位置:
                                    if (ParamManager.Instance.System_找空料.B)
                                    {
                                        FlowLeft = MainFlow.找空料;
                                        flowLight.左找空料.status = 1;
                                    }
                                    else if (true) //(ParamManager.Instance.System_测值.B)
                                    {
                                        FlowLeft = MainFlow.请求测值;
                                        flowLight.左测值.status = 1;
                                    }
                                    else if (ParamManager.Instance.System_丝印.B)
                                    {
                                        flowLight.左丝印.status = 1;
                                        FlowLeft = MainFlow.丝印;
                                    }
                                    else
                                    {
                                        FlowLeft = MainFlow.完成;
                                    }
                                    break;
                                case MainFlow.找空料:
                                    if (false)//视觉确定是否找到空料
                                    {
                                        //没找到空料的情况
                                        左进入.PMove(-4, 0, true);//走4格
                                    }
                                    else
                                    {
                                        FlowLeft = MainFlow.找空料完成;
                                    }
                                    break;
                                case MainFlow.找空料完成:
                                    flowLight.左找空料.status = 2;
                                    if (ParamManager.Instance.System_测值.B)
                                    {
                                        FlowLeft = MainFlow.请求测值;
                                    }
                                    else if (ParamManager.Instance.System_丝印.B)
                                    {
                                        flowLight.左丝印.status = 1;
                                        FlowLeft = MainFlow.丝印;
                                    }
                                    else
                                    {
                                        FlowLeft = MainFlow.切空料;
                                        左进入.PMove(左进入.GetPosByName("切刀位"), 0, true);
                                    }
                                    break;
                                case MainFlow.请求测值:
                                    if (Form1.MainControl.UCLCR.LCRHelper.Side == LCR.WhichSide.Left)
                                    {
                                        FlowLeft = MainFlow.测值中;
                                    }
                                    break;
                                case MainFlow.测值中:
                                    flowLight.左测值.status = 1;
                                    if (Form1.MainControl.UCLCR.LCRHelper.LCRFlow == LCRFlow.Finish)
                                    {
                                        Form1.MainControl.UCLCR.LCRHelper.LCRFlow = LCRFlow.None;
                                        FlowLeft = MainFlow.测值完成;
                                    }
                                    break;
                                case MainFlow.测值完成:
                                    Thread.Sleep(2000);
                                    flowLight.左测值.status = 2;
                                    FlowLeft = MainFlow.完成;
                                    break;
                                case MainFlow.切空料:
                                    凸轮.MovePosByName("切刀位", 1);
                                    FlowLeft = MainFlow.切空料完成;
                                    break;
                                case MainFlow.切空料完成:
                                    if (凸轮.InPos("切刀位"))
                                    {
                                        凸轮.MovePosByName("进料位", 1);
                                        FlowLeft = MainFlow.完成;
                                    }
                                    break;
                                case MainFlow.丝印:
                                    break;
                                case MainFlow.丝印完成:
                                    flowLight.左丝印.status = 2;
                                    break;
                                case MainFlow.完成:
                                    if (filmFlow == FilmFlow.完成)
                                    {
                                        FlowLeft = MainFlow.None;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }

                        //右
                        if (resetFlow == ResetFlow.None)
                        {
                            switch (FlowRight)
                            {
                                case MainFlow.None:
                                    flowLight.右进入.status = 0;
                                    SetRunnersWidth();
                                    if (!ParamManager.Instance.System_条码.B && 右入料光栅.State())
                                    {
                                        FlowRight = MainFlow.进料;
                                        flowLight.右进入.status = 1;
                                        右进入.SetServoff();
                                    }
                                    break;
                                case MainFlow.进料:
                                    //右轮开始转动
                                    右进入.PMove(-1, 0, true);
                                    if (右物料光栅.State() && 右入料光栅.State())
                                    {
                                        右进入.AxisStop();
                                        //清除坐标==》右进入
                                        flowLight.右进入.status = 2;
                                        FlowRight = MainFlow.感应料带到光源位置;
                                        SetRunnersWidth2();
                                    }
                                    else if (!右入料光栅.State())
                                    {
                                        FlowRight = MainFlow.None;
                                        右进入.SetServon();
                                    }
                                    break;
                                case MainFlow.感应料带到光源位置:
                                    if (ParamManager.Instance.System_找空料.B)
                                    {
                                        FlowRight = MainFlow.找空料;
                                        flowLight.右找空料.status = 1;
                                    }
                                    else if (true) //(ParamManager.Instance.System_测值.B)
                                    {
                                        FlowRight = MainFlow.请求测值;
                                        flowLight.右测值.status = 1;
                                    }
                                    else if (ParamManager.Instance.System_丝印.B)
                                    {
                                        flowLight.右丝印.status = 1;
                                        FlowRight = MainFlow.丝印;
                                    }
                                    else
                                    {
                                        FlowRight = MainFlow.完成;
                                    }
                                    break;
                                case MainFlow.找空料:
                                    if (false)//视觉确定是否找到空料
                                    {
                                        //没找到空料的情况
                                        右进入.PMove(-4, 0, true);//走4格

                                    }
                                    else
                                    {
                                        FlowRight = MainFlow.找空料完成;
                                    }
                                    break;
                                case MainFlow.找空料完成:
                                    flowLight.右找空料.status = 2;
                                    if (ParamManager.Instance.System_测值.B)
                                    {
                                        FlowRight = MainFlow.请求测值;
                                    }
                                    else if (ParamManager.Instance.System_丝印.B)
                                    {
                                        flowLight.右丝印.status = 1;
                                        FlowRight = MainFlow.丝印;
                                    }
                                    else
                                    {
                                        FlowRight = MainFlow.切空料;
                                        右进入.PMove(右进入.GetPosByName("切刀位"), 0, true);
                                    }
                                    break;
                                case MainFlow.请求测值:
                                    if (Form1.MainControl.UCLCR.LCRHelper.Side == LCR.WhichSide.Right)
                                    {
                                        FlowRight = MainFlow.测值中;
                                    }
                                    break;
                                case MainFlow.测值中:
                                    flowLight.右测值.status = 1;
                                    if (Form1.MainControl.UCLCR.LCRHelper.LCRFlow == LCRFlow.Finish)
                                    {
                                        Form1.MainControl.UCLCR.LCRHelper.LCRFlow = LCRFlow.None;
                                        FlowRight = MainFlow.测值完成;
                                    }
                                    break;
                                case MainFlow.测值完成:
                                    Thread.Sleep(3000);
                                    flowLight.右测值.status = 2;
                                    FlowRight = MainFlow.完成;
                                    break;
                                case MainFlow.切空料:
                                    凸轮.MovePosByName("切刀位", 1);
                                    FlowRight = MainFlow.切空料完成;
                                    break;
                                case MainFlow.切空料完成:
                                    if (凸轮.InPos("切刀位"))
                                    {
                                        凸轮.MovePosByName("进料位", 1);
                                        FlowRight = MainFlow.完成;
                                    }
                                    break;
                                case MainFlow.丝印:
                                    break;
                                case MainFlow.丝印完成:
                                    flowLight.右丝印.status = 2;
                                    break;
                                case MainFlow.完成:
                                    if (filmFlow == FilmFlow.完成)
                                    {
                                        FlowRight = MainFlow.None;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        Thread.Sleep(50);
                    }
                }));
                tasks[0].Start();
            }

            if (tasks[1] == null || tasks[1].IsCompleted)
            {
                tasks[1] = new Task(new Action(() =>
                {
                    while (true)
                    {
                        //贴膜
                        switch (filmFlow)
                        {
                            case FilmFlow.None:
                                if (右物料光栅.State() || 左物料光栅.State())
                                {
                                    filmFlow = FilmFlow.轴到吸膜位;
                                    filmCount = 0;
                                }
                                break;
                            case FilmFlow.轴到吸膜位:
                                吸头上下.MovePosByName("吸膜位置上", 1);
                                热熔上下.MovePosByName("热熔上", 1);
                                吸头平移.MovePosByName("吸膜位置", 1);
                                filmFlow = FilmFlow.轴到位;
                                break;

                            case FilmFlow.轴到位:

                                if (吸头上下.InPos("吸膜位置上") && 热熔上下.InPos("热熔上") && 吸头平移.InPos("吸膜位置"))
                                {
                                    filmFlow = FilmFlow.拨刀伸出位;
                                }
                                break;


                            case FilmFlow.拨刀伸出位:
                                拨刀.MovePosByName("伸出位", 1);
                                filmFlow = FilmFlow.拨刀到伸出位;
                                break;

                            case FilmFlow.拨刀到伸出位:
                                if (拨刀.InPos("伸出位") && FlowLeft == MainFlow.完成 && FlowRight == MainFlow.完成)
                                {
                                    filmFlow = FilmFlow.卷料送一个膜;
                                    左进入.PMove(-左进入.GetPosByName("接料位"), 0);
                                    右进入.PMove(-右进入.GetPosByName("接料位"), 0);
                                }
                                break;

                            case FilmFlow.卷料送一个膜:
                                if (胶膜1到位.IsOn())
                                {
                                    filmFlow = FilmFlow.吸头上下吸膜;
                                    吸头上下.MovePosByName("吸膜位置下", 1);
                                    filmCount++;
                                }
                                else
                                {
                                    卷料.PMove(0.5, 0);
                                }
                                break;



                            case FilmFlow.吸头上下吸膜:
                                if (吸头上下.InPos("吸膜位置下"))
                                {
                                    真空电磁阀1.On();
                                    真空电磁阀2.On();
                                    真空泵.On();
                                    filmFlow = FilmFlow.大膜退刀位;
                                }

                                break;
                            case FilmFlow.大膜退刀位:
                                拨刀.MovePosByName("大膜退刀位", 1);
                                break;
                            case FilmFlow.小膜退刀位:
                                拨刀.MovePosByName("小膜退刀位", 1);
                                break;
                            case FilmFlow.判断真空表:
                                if (拨刀.InPos("大膜退刀位"))
                                {
                                    Thread.Sleep(1000);//吸膜延时
                                    if (真空表.State())
                                    {
                                        filmFlow = FilmFlow.吸头上下到待机位;
                                    }
                                    else if (filmCount > 2)
                                    {
                                        //报警吸膜异常
                                    }
                                    else
                                    {
                                        真空电磁阀1.Off();
                                        真空电磁阀2.Off();
                                        真空泵.Off();
                                        filmFlow = FilmFlow.轴到吸膜位;
                                    }
                                }

                                break;
                            case FilmFlow.吸头上下到待机位:
                                吸头上下.MovePosByName("吸膜位置上", 1);
                                吸头平移.MovePosByName("贴膜位置1", 1);
                                filmFlow = FilmFlow.平移到对应贴膜位;
                                break;
                            case FilmFlow.平移到对应贴膜位:
                                if (吸头平移.InPos("贴膜位置1"))
                                {
                                    filmFlow = FilmFlow.贴膜动作;
                                    吸头上下.MovePosByName("贴膜位置下", 1);
                                }
                                break;
                            case FilmFlow.贴膜动作:
                                if (吸头上下.InPos("贴膜位置下"))
                                {
                                    真空电磁阀1.Off();
                                    真空电磁阀2.Off();
                                    真空泵.Off();
                                    凸轮.MovePosByName("至包胶位", 1);
                                    Thread.Sleep(100);//贴膜延时
                                    吸头上下.MovePosByName("热熔位置", 1);
                                    热熔上下.MovePosByName("热熔下", 1);
                                    filmFlow = FilmFlow.热熔动作;
                                }
                                break;
                            case FilmFlow.热熔动作:
                                if (热熔上下.InPos("热熔下"))
                                {
                                    热熔上下.MovePosByName("热熔上", 1);
                                    filmFlow = FilmFlow.完成;
                                }
                                break;
                            case FilmFlow.完成:
                                flowLight.贴膜.status = 2;
                                Form1.MainControl.UCLCR.LCRHelper.SaveData();
                                break;
                            default:
                                break;
                        }

                        //复位
                        switch (resetFlow)
                        {
                            case ResetFlow.None:
                                break;
                            case ResetFlow.吸嘴_测值上下回零:
                                吸头上下.Home(1000);
                                热熔上下.Home(1000);
                                左进入.SetServon();
                                右进入.SetServon();
                                测值整体上下.Home(1000);
                                下针.Home(1000);
                                探针A.Home(1000);
                                探针B.Home(1000);
                                resetFlow = ResetFlow.吸嘴_测值上下回零完成;
                                break;
                            case ResetFlow.吸嘴_测值上下回零完成:
                                if (吸头上下.HomeState)
                                {
                                    resetFlow = ResetFlow.探针回零;
                                }
                                break;
                            case ResetFlow.探针回零:
                                探针A.Home(1000);
                                探针B.Home(1000);
                                resetFlow = ResetFlow.探针回零完成;
                                break;
                            case ResetFlow.探针回零完成:
                                if (探针A.HomeState && 探针B.HomeState && 热熔上下.HomeState)
                                {
                                    resetFlow = ResetFlow.初始化;
                                }
                                break;
                            case ResetFlow.初始化:
                                FlowLeft = MainFlow.None;
                                FlowRight = MainFlow.None;
                                Form1.MainControl.UCLCR.LCRHelper.LCRFlow = LCR.LCRFlow.None;
                                flowLight.Reset();
                                凸轮.Home(1000);
                                流道调宽.Home(1000);
                                吸头平移.Home(1000);
                                拨刀.Home(1000);
                                resetFlow = ResetFlow.初始化完成;
                                break;
                            case ResetFlow.初始化完成:
                                if (凸轮.HomeState && 流道调宽.HomeState && 吸头平移.HomeState)
                                {
                                    resetFlow = ResetFlow.None;
                                  
                                    左进入.SetServoff();
                                    右进入.SetServoff();
                                    左进入.Home(1000);
                                    右进入.Home(1000);
                                }
                                break;
                            default:
                                break;
                        }
                    
                        Thread.Sleep(50);
                    }
                }));
                tasks[1].Start();
            }

        }

        public void Stop()
        {
            MotionControl.CardAPI.StopEmgAxis();
        }

        public void Reset()
        {
            resetFlow = ResetFlow.吸嘴_测值上下回零;
        }

        /// <summary>
        /// 设置流道宽度
        /// </summary>
        private void SetRunnersWidth()
        {
            switch (runnersWidth)
            {
                case RunnersWidth._8mm:
                    流道调宽.MovePosByName("流道8mm", 1);
                    break;
                case RunnersWidth._12mm:
                    流道调宽.MovePosByName("流道12mm", 1);
                    break;
                case RunnersWidth._16mm:
                    流道调宽.MovePosByName("流道16mm", 1);
                    break;
                case RunnersWidth._24mm:
                    流道调宽.MovePosByName("流道24mm", 1);
                    break;
                default:
                    流道调宽.MovePosByName("流道8mm", 1);
                    break;
            }
        }

        /// <summary>
        /// 设置流道夹紧
        /// </summary>
        private void SetRunnersWidth2()
        {
            switch (runnersWidth)
            {
                case RunnersWidth._8mm:
                    流道调宽.MovePosByName("夹紧8mm", 1);
                    break;
                case RunnersWidth._12mm:
                    流道调宽.MovePosByName("夹紧12mm", 1);
                    break;
                case RunnersWidth._16mm:
                    流道调宽.MovePosByName("夹紧16mm", 1);
                    break;
                case RunnersWidth._24mm:
                    流道调宽.MovePosByName("夹紧24mm", 1);
                    break;
                default:
                    流道调宽.MovePosByName("夹紧8mm", 1);
                    break;
            }

        }

    }




    /// <summary>
    /// 流道宽
    /// </summary>
    public enum RunnersWidth
    {
        _8mm,
        _12mm,
        _16mm,
        _24mm
    }

    public class FlowLight
    {
        public Light 左进入 = new Light(1);
        public Light 左找空料 = new Light(1);
        public Light 左测值 = new Light(1);
        public Light 左丝印 = new Light(1);
        public Light 右进入 = new Light(1);
        public Light 右找空料 = new Light(1);
        public Light 右测值 = new Light(1);
        public Light 右丝印 = new Light(1);
        public Light 贴膜 = new Light(1);
        public Light 接料完成 = new Light(1);
        /// <summary>
        /// 信号复位
        /// </summary>
        public void Reset()
        {
            左进入.status = 0;
            左找空料.status = 0;
            左测值.status = 0;
            左丝印.status = 0;
            右进入.status = 0;
            右找空料.status = 0;
            右测值.status = 0;
            右丝印.status = 0;
            贴膜.status = 0;
            接料完成.status = 0;
        }

    }

    public struct Light
    {

        public Light(int status)
        {
            this.status = status;
        }
        /// <summary>
        /// 0:未执行:灰色
        /// 1:执行中:黄色
        /// 2:成功  :绿色
        /// 3:失败  :红色
        /// </summary>
        public int status;
    }

    /// <summary>
    /// 主流程
    /// </summary>
    public enum MainFlow
    {
        None, //判断复位OK
        进料,//齿轮转动
        感应料带到光源位置,//齿轮走一格
        找空料,//拍照
        找空料完成,//去切空料位
        请求测值,//测值失败走一格
        测值中,
        测值完成,
        切空料,
        切空料完成,//去测值位，到位信号
        丝印,
        丝印完成,
        完成
    }

    /// <summary>
    /// 贴膜流程
    /// </summary>
    public enum FilmFlow
    {
        None,
        拨刀伸出位,
        拨刀到伸出位,
        卷料送一个膜,
        轴到吸膜位,
        /// <summary>
        /// 吸头上下，热熔上下到待机位
        /// 吸头平移到吸膜位，拨刀去伸出位
        /// </summary>
        轴到位,
        /// <summary>
        /// 打开真空电磁阀
        /// </summary>
        吸头上下吸膜,
        判断真空表,
        大膜退刀位,
        小膜退刀位,
        吸头上下到待机位,
        平移到对应贴膜位,
        贴膜动作,
        热熔动作,
        完成
    }


    /// <summary>
    /// 复位流程
    /// </summary>
    public enum ResetFlow
    {
        None,
        吸嘴_测值上下回零,
        吸嘴_测值上下回零完成,
        探针回零,
        探针回零完成,
        /// <summary>
        /// 其它轴回零
        /// 初始化软件
        /// </summary>
        初始化,
        初始化完成
    }
}
