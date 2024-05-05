using Alarm;
using BorwinAnalyse.BaseClass;
using BorwinSplicMachine.LCR;
using FeederSpliceVisionSys;
using LibSDK;
using LibSDK.AxisParamDebuger;
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
        private int leftMoveCount = 0;
        /// <summary>
        /// 左切料位
        /// </summary>
        public static double leftCutPos = 0;
        /// <summary>
        /// 左切料补偿位
        /// </summary>
        public static double leftDockPos = 0;
        public static double RightCutPos = 0;
        public static double RightDockPos = 0;

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

        private KTimer timer = new KTimer();

        public MotControl()
        {

        }

        public void Start()
        {
            if (MotionControl.CardAPI.IsInitCardOK)
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
            }
        }

        private int filmCount = 0;

        Thread Thread = null;
        Thread Thread2 = null;
        public void Run()
        {
            if (MotionControl.CardAPI.IsInitCardOK)
            {
                Thread = new Thread(LeftAndRight);
                Thread.IsBackground = true;
                Thread.Start();

                Thread2 = new Thread(ResetAndFilm);
                Thread2.Start();
            }
          
        }

        KTimer kTimer = new KTimer();
        private async void ResetAndFilm()
        {
            while (true)
            {
                if (resetFlow == ResetFlow.None && Alarm.AlarmControl.Alarm == Alarm.AlarmList.None && MotionControl.IsAuto)
                {
                    //贴膜
                    switch (filmFlow)
                    {
                        case FilmFlow.None:
                            if (右入料光栅.State() && 左入料光栅.State() && 右物料光栅.State() && 左物料光栅.State())
                            {
                                filmFlow = FilmFlow.轴到吸膜位;
                            }
                            break;

                        case FilmFlow.轴到吸膜位:
                            if (真空表.State())
                            {
                                filmFlow = FilmFlow.吸头上下到待机位;
                            }
                            else
                            {
                                吸头上下.MovePosByName("吸膜位置上", 1, AxisRunVel.Instance.吸头上下.Sped, AxisRunVel.Instance.吸头上下.Acc);
                                热熔上下.MovePosByName("热熔上", 1, AxisRunVel.Instance.热熔上下.Sped, AxisRunVel.Instance.热熔上下.Acc);
                                filmFlow = FilmFlow.轴到位;
                            }
                            break;

                        case FilmFlow.轴到位:
                            if (真空表.State())
                            {
                                filmFlow = FilmFlow.吸头上下到待机位;
                            }
                            else if (吸头上下.InPos("吸膜位置上") && 热熔上下.InPos("热熔上"))
                            {
                                filmFlow = FilmFlow.拨刀伸出位;
                            }
                            break;

                        case FilmFlow.拨刀伸出位:
                            吸头平移.MovePosByName(XiMoPos(), 1);
                            拨刀.MovePosByName("伸出位", 1, AxisRunVel.Instance.拨刀.Sped, AxisRunVel.Instance.拨刀.Acc);
                            filmFlow = FilmFlow.拨刀到伸出位;
                            break;

                        case FilmFlow.拨刀到伸出位:
                            if (拨刀.InPos("伸出位") && 吸头平移.InPos(XiMoPos()))
                            {
                                filmFlow = FilmFlow.卷料送一个膜;
                            }
                            else
                            {
                                filmFlow = FilmFlow.拨刀伸出位;
                            }
                            break;

                        case FilmFlow.卷料送一个膜:
                            if (胶膜1到位.IsOn())
                            {
                                卷料.AxisStop();
                                if (FlowLeft == MainFlow.完成 && FlowRight == MainFlow.完成)
                                {
                                    filmFlow = FilmFlow.吸头上下吸膜;
                                    吸头上下.MovePosByName("吸膜位置下", 1, AxisRunVel.Instance.吸头上下.Sped, AxisRunVel.Instance.吸头上下.Acc);
                                    if (FileSuccessCount == 0)
                                    {
                                        左进入.PMove(-左进入.GetPosByName("接料位"), 0, AxisRunVel.Instance.左进入.Sped, AxisRunVel.Instance.左进入.Acc);
                                        右进入.PMove(-右进入.GetPosByName("接料位"), 0, AxisRunVel.Instance.右进入.Sped, AxisRunVel.Instance.右进入.Acc);
                                    }
                                    filmCount++;
                                }
                            }
                            else
                            {
                                卷料.PMove(1, 0);
                            }
                            break;

                        case FilmFlow.吸头上下吸膜:
                            if (吸头上下.InPos("吸膜位置下"))
                            {
                                真空电磁阀1.On();
                                真空电磁阀2.On();
                                真空泵.On();
                                TuiDaoPos();
                            }

                            break;

                        case FilmFlow.大膜退刀位:
                            拨刀.MovePosByName("大膜退刀位", 1, AxisRunVel.Instance.拨刀.Sped, AxisRunVel.Instance.拨刀.Acc);
                            filmFlow = FilmFlow.判断真空表;
                            break;

                        case FilmFlow.小膜退刀位:
                            拨刀.MovePosByName("小膜退刀位", 1, AxisRunVel.Instance.拨刀.Sped, AxisRunVel.Instance.拨刀.Acc);
                            filmFlow = FilmFlow.判断真空表;
                            break;

                        case FilmFlow.判断真空表:
                            if (拨刀.InPos("大膜退刀位"))
                            {
                                Thread.Sleep(500);
                                if (真空表.State())
                                {
                                    filmFlow = FilmFlow.吸头上下到待机位;
                                }
                                else if (filmCount > 2)
                                {
                                    //报警吸膜异常
                                    AlarmControl.Alarm = AlarmList.吸膜超时;
                                }
                                else
                                {
                                    if (真空表.State())
                                    {
                                        filmFlow = FilmFlow.吸头上下到待机位;
                                    }
                                    else
                                    {
                                        真空电磁阀1.Off();
                                        真空电磁阀2.Off();
                                        真空泵.Off();
                                        filmFlow = FilmFlow.轴到吸膜位;
                                    }

                                }
                            }

                            break;

                        case FilmFlow.吸头上下到待机位:
                            吸头上下.MovePosByName("吸膜位置上", 1, AxisRunVel.Instance.吸头上下.Sped, AxisRunVel.Instance.吸头上下.Acc);

                            吸头平移.MovePosByName(FilmPos(), 1, AxisRunVel.Instance.吸头平移.Sped, AxisRunVel.Instance.吸头平移.Acc);
                            filmFlow = FilmFlow.平移到对应贴膜位;
                            break;

                        case FilmFlow.平移到对应贴膜位:
                            if (吸头平移.InPos(FilmPos()))
                            {
                                filmFlow = FilmFlow.贴膜动作;
                                吸头上下.MovePosByName("贴膜位置下", 1, AxisRunVel.Instance.吸头上下.Sped, AxisRunVel.Instance.吸头上下.Acc);
                            }
                            break;

                        case FilmFlow.贴膜动作:
                            if (吸头上下.InPos("贴膜位置下"))
                            {
                                凸轮.MovePosByName("至包胶位", 1, AxisRunVel.Instance.凸轮.Sped, AxisRunVel.Instance.凸轮.Acc);
                                filmFlow = FilmFlow.包胶动作;
                            }
                            break;

                        case FilmFlow.包胶动作:
                            if (凸轮.InPos("至包胶位"))
                            {
                                真空电磁阀1.Off();
                                真空电磁阀2.Off();
                                真空泵.Off();
                                吸头上下.MovePosByName("热熔位置", 1, AxisRunVel.Instance.吸头上下.Sped, AxisRunVel.Instance.吸头上下.Acc);
                                吸头平移.MovePosByName("热熔位置", 1, AxisRunVel.Instance.吸头平移.Sped, AxisRunVel.Instance.吸头平移.Acc);
                                filmFlow = FilmFlow.热熔动作;
                            }
                            break;

                        case FilmFlow.热熔动作:
                            if (吸头上下.InPos("热熔位置") && 吸头平移.InPos("热熔位置"))
                            {
                                热熔上下.MovePosByName("热熔下", 1, AxisRunVel.Instance.热熔上下.Sped, AxisRunVel.Instance.热熔上下.Acc);
                                filmFlow = FilmFlow.热熔;
                            }
                            break;

                        case FilmFlow.热熔:
                            if (热熔上下.InPos("热熔下"))
                            {
                                FileSuccessCount++;
                                if (!IsTwice())
                                {
                                    filmFlow = FilmFlow.完成;
                                    凸轮.MovePosByName("松料位", 1, AxisRunVel.Instance.凸轮.Sped, AxisRunVel.Instance.凸轮.Acc);
                                    热熔上下.PMove(2, 1, 120, 50);
                                    SetRunnersWidth();
                                }
                                else
                                {
                                    filmFlow = FilmFlow.轴到吸膜位;
                                }

                            }
                            break;

                        case FilmFlow.完成:
                            if (FileSuccessCount > 0 && 凸轮.InPos("松料位") && resetFlow == ResetFlow.None)
                            {
                                flowLight.贴膜.status = 2;
                                Form1.MainControl.UCLCR.LCRHelper.SaveData();
                                MotControl.测值整体上下.Home(3000);
                                Reset();
                            }
                            break;

                        default:
                            break;
                    }
                }
                //复位
                switch (resetFlow)
                {
                    case ResetFlow.None:

                        break;
                    case ResetFlow.吸嘴_测值上下回零:
                        流道调宽.Home(1000);
                        Form1.MainControl.CodeControl.Clear();
                        吸头上下.Home(1000);
                        热熔上下.Home(1000);
                        左进入.SetServon();
                        右进入.SetServon();
                        下针.Home(1000);
                        探针A.Home(1000);
                        探针B.Home(1000);
                        if (FileSuccessCount == 0)
                            MotControl.测值整体上下.Home(3000);
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
                        if (探针A.HomeState && 探针B.HomeState && 热熔上下.HomeState && 测值整体上下.HomeState)
                        {
                            if (!吸头平移.HomeState)
                                吸头平移.Home(1000);
                            if (!拨刀.HomeState)
                                拨刀.Home(1000);
                            resetFlow = ResetFlow.料带是否取走;
                        }
                        break;

                    case ResetFlow.料带是否取走:
                        if (!左入料光栅.State() && !右入料光栅.State())
                        {
                            resetFlow = ResetFlow.初始化;
                        }
                        else
                        {
                            AlarmControl.Alarm = AlarmList.请取走料带;
                        }
                        break;

                    case ResetFlow.初始化:
                        FlowLeft = MainFlow.None;
                        FlowRight = MainFlow.None;
                        filmFlow = FilmFlow.None;
                        Form1.MainControl.UCLCR.LCRHelper.LCRFlow = LCR.LCRFlow.None;
                        Form1.MainControl.UCLCR.LCRHelper.Side = LCR.WhichSide.None;
                        flowLight.Reset();
                        凸轮.Home(3000);
                        resetFlow = ResetFlow.初始化完成;
                        break;
                    case ResetFlow.初始化完成:
                        if (凸轮.HomeState && 流道调宽.HomeState && 吸头平移.HomeState)
                        {
                            resetFlow = ResetFlow.None;
                            filmCount = 0;
                            FileSuccessCount = 0;
                            左进入.SetServoff();
                            右进入.SetServoff();
                            左进入.Home(1000);
                            右进入.Home(1000);
                            SetRunnersWidth();
                        }
                        break;
                    default:
                        break;
                }
                Thread.Sleep(10);
            }
        }

        private async void LeftAndRight()
        {
            while (true)
            {
                if (resetFlow == ResetFlow.None && Alarm.AlarmControl.Alarm == Alarm.AlarmList.None && MotionControl.IsAuto)
                {
                    //左
                    switch (FlowLeft)
                    {
                        case MainFlow.None:
                            flowLight.左进入.status = 0;
                            if ((!ParamManager.Instance.System_条码.B || Form1.MainControl.CodeControl.IsSuccess()) && 左入料光栅.State())
                            {
                                FlowLeft = MainFlow.进料;
                                flowLight.左进入.status = 1;
                                左进入.SetServoff();
                            }
                            break;
                        case MainFlow.进料:
                            //左轮开始转动
                            左进入.PMove(-2, 0, AxisRunVel.Instance.左进入.Sped, AxisRunVel.Instance.左进入.Acc, true);
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
                                FlowLeft = MainFlow.开始找空料;
                                flowLight.左找空料.status = 1;
                            }
                            else if (ParamManager.Instance.System_测值.B)
                            {
                                FlowLeft = MainFlow.请求测值;
                                flowLight.左测值.status = 1;
                                凸轮.MovePosByName("进料位", 1, AxisRunVel.Instance.凸轮.Sped, AxisRunVel.Instance.凸轮.Acc);
                            }
                            else if (ParamManager.Instance.System_丝印.B)
                            {
                                flowLight.左丝印.status = 1;
                                FlowLeft = MainFlow.丝印;
                            }
                            else
                            {
                                凸轮.MovePosByName("进料位", 1, AxisRunVel.Instance.凸轮.Sped, AxisRunVel.Instance.凸轮.Acc);
                                FlowLeft = MainFlow.完成;
                            }
                            break;
                        case MainFlow.开始找空料:
                            leftMoveCount++;
                            左进入.PMove(-左进入.GetPosByName("移动距离"), 0, AxisRunVel.Instance.左进入.Sped, AxisRunVel.Instance.左进入.Acc, true);//走4格
                            VisionDetection.Detection_CutPos(Station.LiftStation);
                            Form1.MainControl.UCVision.Log("找空料发送" + "Detection_CutPos(Station.LiftStation)");
                            FlowLeft = MainFlow.找空料中;
                            kTimer.Restart();
                            break;
                        case MainFlow.找空料中:
                            if (kTimer.IsOn(2000))
                            {
                                Form1.MainControl.UCVision.Log("找空料超时");
                                FlowLeft = MainFlow.开始找空料;
                            }
                            break;
                        case MainFlow.找空料OK:
                            if (ParamManager.Instance.System_测值.B)
                            {
                                FlowLeft = MainFlow.请求测值;
                                flowLight.左测值.status = 1;
                                凸轮.MovePosByName("进料位", 1, AxisRunVel.Instance.凸轮.Sped, AxisRunVel.Instance.凸轮.Acc);
                            }
                            else
                            {
                                FlowLeft = MainFlow.开始切空料;
                            }
                            break;
                        case MainFlow.找空料NG:
                            FlowLeft = MainFlow.开始找空料;
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
                                左进入.PMove(-左进入.GetPosByName("切刀位"), 0, AxisRunVel.Instance.左进入.Sped, AxisRunVel.Instance.左进入.Acc, true);
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
                            if (左进入.Runing())
                            {
                                flowLight.左测值.status = 2;
                                FlowLeft = MainFlow.开始切空料;
                                凸轮.PMove(0, 1, AxisRunVel.Instance.凸轮.Sped, AxisRunVel.Instance.凸轮.Acc);
                                Thread.Sleep(1000);
                            }
                            break;
                        case MainFlow.开始切空料:
                            Form1.MainControl.UCVision.Log("切空料值" + leftCutPos);
                            double pod = -左进入.GetPosByName("切刀位") - leftCutPos + 左进入.GetPosByName("基准位置");
                            左进入.PMove(pod, 0, AxisRunVel.Instance.左进入.Sped, AxisRunVel.Instance.左进入.Acc);
                            FlowLeft = MainFlow.开始空料补偿;
                            break;
                        case MainFlow.开始空料补偿:
                            if (左进入.Runing())
                            {
                                VisionDetection.Detection_DockPos(Station.LiftStation);
                                Form1.MainControl.UCVision.Log("空料补偿发送" + "Detection_DockPos(Station.LiftStation)");
                                FlowLeft = MainFlow.空料补偿中;
                                kTimer.Restart();
                            }
                            break;
                        case MainFlow.空料补偿中:
                            if (kTimer.IsOn(2000))
                            {
                                Form1.MainControl.UCVision.Log("空料补偿超时");
                                FlowLeft = MainFlow.开始空料补偿;
                            }
                            break;
                        case MainFlow.空料补偿完成:
                            Form1.MainControl.UCVision.Log("空料补偿值" + leftDockPos);
                            左进入.PMove(-leftDockPos, 0);
                            FlowLeft = MainFlow.切空料;
                            break;
                        case MainFlow.切空料:
                            if (左进入.Runing())
                            {
                                凸轮.MovePosByName("切刀位", 1, AxisRunVel.Instance.凸轮.Sped, AxisRunVel.Instance.凸轮.Acc);
                                FlowLeft = MainFlow.切空料完成;
                            }
                            break;
                        case MainFlow.切空料完成:
                            if (凸轮.InPos("切刀位"))
                            {
                                凸轮.MovePosByName("进料位", 1, AxisRunVel.Instance.凸轮.Sped, AxisRunVel.Instance.凸轮.Acc);
                                FlowLeft = MainFlow.完成;
                            }
                            break;
                        case MainFlow.丝印:
                            break;
                        case MainFlow.丝印完成:
                            flowLight.左丝印.status = 2;
                            FlowLeft = MainFlow.切空料;
                            左进入.PMove(-左进入.GetPosByName("切刀位"), 0, AxisRunVel.Instance.左进入.Sped, AxisRunVel.Instance.左进入.Acc, true);
                            break;
                        case MainFlow.完成:

                            break;
                        default:
                            break;
                    }
                    //右
                    switch (FlowRight)
                    {
                        case MainFlow.None:
                            flowLight.右进入.status = 0;
                            if ((!ParamManager.Instance.System_条码.B || Form1.MainControl.CodeControl.IsSuccess()) && 右入料光栅.State())
                            {
                                FlowRight = MainFlow.进料;
                                flowLight.右进入.status = 1;
                                右进入.SetServoff();
                            }
                            break;
                        case MainFlow.进料:
                            //右轮开始转动
                            右进入.PMove(-2, 0, AxisRunVel.Instance.右进入.Sped, AxisRunVel.Instance.右进入.Acc, true);
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
                                FlowRight = MainFlow.开始找空料;
                                flowLight.右找空料.status = 1;
                            }
                            else if (ParamManager.Instance.System_测值.B)
                            {
                                FlowRight = MainFlow.请求测值;
                                flowLight.右测值.status = 1;
                                凸轮.MovePosByName("进料位", 1, AxisRunVel.Instance.凸轮.Sped, AxisRunVel.Instance.凸轮.Acc);
                            }
                            else if (ParamManager.Instance.System_丝印.B)
                            {
                                flowLight.右丝印.status = 1;
                                FlowRight = MainFlow.丝印;
                            }
                            else
                            {
                                凸轮.MovePosByName("进料位", 1, AxisRunVel.Instance.凸轮.Sped, AxisRunVel.Instance.凸轮.Acc);
                                FlowRight = MainFlow.完成;
                            }
                            break;
                        case MainFlow.开始找空料:
                            leftMoveCount++;
                            右进入.PMove(-右进入.GetPosByName("移动距离"), 0, AxisRunVel.Instance.右进入.Sped, AxisRunVel.Instance.右进入.Acc, true);//走4格
                            VisionDetection.Detection_CutPos(Station.RightStation);
                            Form1.MainControl.UCVision.Log("找空料发送" + "Detection_CutPos(Station.RightStation)");
                            FlowRight = MainFlow.找空料中;
                            kTimer.Restart();
                            break;
                        case MainFlow.找空料中:
                            if (kTimer.IsOn(2000))
                            {
                                Form1.MainControl.UCVision.Log("找空料超时");
                                FlowRight = MainFlow.开始找空料;
                            }
                            break;
                        case MainFlow.找空料OK:
                            if (ParamManager.Instance.System_测值.B)
                            {
                                FlowRight = MainFlow.请求测值;
                                flowLight.右测值.status = 1;
                                凸轮.MovePosByName("进料位", 1, AxisRunVel.Instance.凸轮.Sped, AxisRunVel.Instance.凸轮.Acc);
                            }
                            else
                            {
                                FlowRight = MainFlow.开始切空料;
                            }
                            break;
                        case MainFlow.找空料NG:
                            FlowRight = MainFlow.开始找空料;
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
                                右进入.PMove(-右进入.GetPosByName("切刀位"), 0, AxisRunVel.Instance.右进入.Sped, AxisRunVel.Instance.右进入.Acc, true);
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
                            if (右进入.Runing())
                            {
                                flowLight.右测值.status = 2;
                                FlowRight = MainFlow.开始切空料;
                                凸轮.PMove(0, 1, AxisRunVel.Instance.凸轮.Sped, AxisRunVel.Instance.凸轮.Acc);
                                Thread.Sleep(1000);
                            }
                            break;
                        case MainFlow.开始切空料:
                            Form1.MainControl.UCVision.Log("切空料值" + leftCutPos);
                            double pod = -右进入.GetPosByName("切刀位") - leftCutPos + 右进入.GetPosByName("基准位置");
                            右进入.PMove(pod, 0, AxisRunVel.Instance.右进入.Sped, AxisRunVel.Instance.右进入.Acc);
                            FlowRight = MainFlow.开始空料补偿;
                            break;
                        case MainFlow.开始空料补偿:
                            if (右进入.Runing())
                            {
                                VisionDetection.Detection_DockPos(Station.RightStation);
                                Form1.MainControl.UCVision.Log("空料补偿发送" + "Detection_DockPos(Station.RightStation)");
                                FlowRight = MainFlow.空料补偿中;
                                kTimer.Restart();
                            }
                            break;
                        case MainFlow.空料补偿中:
                            if (kTimer.IsOn(2000))
                            {
                                Form1.MainControl.UCVision.Log("空料补偿超时");
                                FlowRight = MainFlow.开始空料补偿;
                            }
                            break;
                        case MainFlow.空料补偿完成:
                            Form1.MainControl.UCVision.Log("空料补偿值" + leftDockPos);
                            右进入.PMove(-leftDockPos, 0);
                            FlowRight = MainFlow.切空料;
                            break;
                        case MainFlow.切空料:
                            if (右进入.Runing())
                            {
                                凸轮.MovePosByName("切刀位", 1, AxisRunVel.Instance.凸轮.Sped, AxisRunVel.Instance.凸轮.Acc);
                                FlowRight = MainFlow.切空料完成;
                            }
                            break;
                        case MainFlow.切空料完成:
                            if (凸轮.InPos("切刀位"))
                            {
                                凸轮.MovePosByName("进料位", 1, AxisRunVel.Instance.凸轮.Sped, AxisRunVel.Instance.凸轮.Acc);
                                FlowRight = MainFlow.完成;
                            }
                            break;
                        case MainFlow.丝印:
                            break;
                        case MainFlow.丝印完成:
                            flowLight.右丝印.status = 2;
                            FlowRight = MainFlow.切空料;
                            右进入.PMove(-右进入.GetPosByName("切刀位"), 0, AxisRunVel.Instance.右进入.Sped, AxisRunVel.Instance.右进入.Acc, true);
                            break;
                        case MainFlow.完成:

                            break;
                        default:
                            break;
                    }
                }
                Thread.Sleep(10);
            }
        }

        public void Stop()
        {
            MotionControl.CardAPI.StopEmgAxis();
        }

        public void Reset()
        {
            if (MotionControl.CardAPI.IsInitCardOK)
                resetFlow = ResetFlow.吸嘴_测值上下回零;
        }

        /// <summary>
        /// 吸膜成功次数
        /// </summary>
        private int FileSuccessCount = 0;

        /// <summary>
        /// 退刀位置
        /// </summary>
        public void TuiDaoPos()
        {
            switch (runnersWidth)
            {
                case RunnersWidth._8mm:
                    filmFlow = FilmFlow.大膜退刀位;
                    break;
                case RunnersWidth._12mm:
                    if (FileSuccessCount == 0)
                    {
                        filmFlow = FilmFlow.大膜退刀位;
                    }
                    else
                    {
                        filmFlow = FilmFlow.小膜退刀位;
                    }
                    break;
                case RunnersWidth._16mm:
                    filmFlow = FilmFlow.大膜退刀位;
                    break;
                case RunnersWidth._24mm:
                    filmFlow = FilmFlow.大膜退刀位;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 是否再次贴膜
        /// </summary>
        /// <returns></returns>
        public bool IsTwice()
        {
            switch (runnersWidth)
            {
                case RunnersWidth._8mm:
                    return false;
                    break;
                case RunnersWidth._12mm:
                case RunnersWidth._16mm:
                case RunnersWidth._24mm:
                    if (FileSuccessCount > 1)
                    {
                        return false;
                    }
                    break;
                default:
                    break;
            }
            return true;
        }

        /// <summary>
        /// 设置流道宽度
        /// </summary>
        public void SetRunnersWidth()
        {
            if (MotionControl.CardAPI.IsInitCardOK && MotionControl.IsAuto)
            {
                switch (runnersWidth)
                {
                    case RunnersWidth._8mm:
                        if (!流道调宽.InPos("流道8mm"))
                            流道调宽.MovePosByName("流道8mm", 1, AxisRunVel.Instance.流道调宽.Sped, AxisRunVel.Instance.流道调宽.Acc);
                        break;
                    case RunnersWidth._12mm:
                        if (!流道调宽.InPos("流道12mm"))
                            流道调宽.MovePosByName("流道12mm", 1, AxisRunVel.Instance.流道调宽.Sped, AxisRunVel.Instance.流道调宽.Acc);
                        break;
                    case RunnersWidth._16mm:
                        if (!流道调宽.InPos("流道16mm"))
                            流道调宽.MovePosByName("流道16mm", 1, AxisRunVel.Instance.流道调宽.Sped, AxisRunVel.Instance.流道调宽.Acc);
                        break;
                    case RunnersWidth._24mm:
                        if (!流道调宽.InPos("流道24mm"))
                            流道调宽.MovePosByName("流道24mm", 1, AxisRunVel.Instance.流道调宽.Sped, AxisRunVel.Instance.流道调宽.Acc);
                        break;
                    default:
                        流道调宽.MovePosByName("流道8mm", 1, AxisRunVel.Instance.流道调宽.Sped, AxisRunVel.Instance.流道调宽.Acc);
                        break;
                }
            }
        }

        /// <summary>
        /// 贴膜位置
        /// </summary>
        /// <returns></returns>
        public string FilmPos()
        {
            string posName = "贴8mm位";
            switch (runnersWidth)
            {
                case RunnersWidth._8mm:
                    break;
                case RunnersWidth._12mm:
                    if (FileSuccessCount > 0)
                    {
                        posName = "贴12mm位2";
                    }
                    else
                    {
                        posName = "贴12mm位1";
                    }
                    break;
                case RunnersWidth._16mm:
                    if (FileSuccessCount > 0)
                    {
                        posName = "贴16mm位2";
                    }
                    else
                    {
                        posName = "贴16mm位1";
                    }
                    break;
                case RunnersWidth._24mm:
                    if (FileSuccessCount > 0)
                    {
                        posName = "贴24mm位2";
                    }
                    else
                    {
                        posName = "贴24mm位1";
                    }
                    break;
                default:
                    break;
            }
            return posName;
        }

        /// <summary>
        /// 吸膜位置
        /// </summary>
        /// <returns></returns>
        public string XiMoPos()
        {
            string posName = "吸膜位置";
            switch (runnersWidth)
            {
                case RunnersWidth._8mm:
                    break;
                case RunnersWidth._12mm:
                    if (FileSuccessCount == 0)
                    {
                        posName = "吸小膜位置";
                    }
                    break;
                case RunnersWidth._16mm:
                    break;
                case RunnersWidth._24mm:
                    break;
                default:
                    break;
            }
            return posName;
        }

        /// <summary>
        /// 设置流道夹紧
        /// </summary>
        private void SetRunnersWidth2()
        {
            switch (runnersWidth)
            {
                case RunnersWidth._8mm:
                    流道调宽.MovePosByName("夹紧8mm", 1, AxisRunVel.Instance.流道调宽.Sped, AxisRunVel.Instance.流道调宽.Acc);
                    break;
                case RunnersWidth._12mm:
                    流道调宽.MovePosByName("夹紧12mm", 1, AxisRunVel.Instance.流道调宽.Sped, AxisRunVel.Instance.流道调宽.Acc);
                    break;
                case RunnersWidth._16mm:
                    流道调宽.MovePosByName("夹紧16mm", 1, AxisRunVel.Instance.流道调宽.Sped, AxisRunVel.Instance.流道调宽.Acc);
                    break;
                case RunnersWidth._24mm:
                    流道调宽.MovePosByName("夹紧24mm", 1, AxisRunVel.Instance.流道调宽.Sped, AxisRunVel.Instance.流道调宽.Acc);
                    break;
                default:
                    流道调宽.MovePosByName("夹紧8mm", 1, AxisRunVel.Instance.流道调宽.Sped, AxisRunVel.Instance.流道调宽.Acc);
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
        开始找空料,
        找空料中,//拍照
        找空料NG,//拍照
        找空料OK,//拍照
        找空料完成,//去切空料位
        请求测值,//测值失败走一格
        测值中,
        测值完成,
        开始切空料,
        开始空料补偿,
        空料补偿中,
        空料补偿完成,
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
        包胶动作,
        热熔动作,
        热熔,
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
        料带是否取走,
        /// <summary>
        /// 其它轴回零
        /// 初始化软件
        /// </summary>
        初始化,
        初始化完成
    }
}
