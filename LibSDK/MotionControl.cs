using BorwinAnalyse.BaseClass;
using BorwinAnalyse.DataBase.Model;
using LibSDK.Enums;
using LibSDK.IO;
using LibSDK.Motion;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GC.Frame.Motion.Privt.CNMCLib20;
using static LibSDK.IO.IOParm;

namespace LibSDK
{
    public class MotionControl
    {
        public static IOParm IOParmIn = new IOParm("In");
        public static IOParm IOParmOut = new IOParm("Out");
        public static EventHandler IoRefEventHandler { get; internal set; }
        public static int[] ErrorCode = { -1, 0, 1, 2, 3, 4, 5 };
        public static EnumControl EnumControl = new EnumControl();
        public static AxisParm AxisParm = new AxisParm();
        public static Dictionary<string, Output> Output = new Dictionary<string, Output>();
        public static Dictionary<string, Input> InPort = new Dictionary<string, Input>();
        public static Dictionary<string, MotAPI> Motions = new Dictionary<string, MotAPI>();
        public static int HomeMode;
        public static bool HomeFlag = false;
        public static CardAPI CardAPI = new CardAPI();

        /// <summary>
        /// 更新轴
        /// </summary>
        public static Action UpDateAxis;

        /// <summary>
        /// 更新输入IO
        /// </summary>
        public static Action UpDateINIO;

        /// <summary>
        /// 更新输出IO
        /// </summary>
        public static Action UpDateOUTIO;


        public static void AddCard()
        {
            CardConfig cardConfig = new CardConfig();
            cardConfig.CardNo = BaseConfig.Instance.cardConfigs.Count;
            cardConfig.AxisNum = 6;
            cardConfig.ConigPath = "";
            BaseConfig.Instance.cardConfigs.Add(cardConfig);
            BaseConfig.Instance.Write();
            Log("添加卡:" + cardConfig.CardNo);
        }

        public static void AddAxis(CAxisParm cAxisParm)
        {
            AxisParm.Write();
            InitAxis();
            Log("添加轴:" + cAxisParm.AxisInfo.AxisName);
        }

        public static void AddInIO(CIOType cIOType)
        {
            cIOType.IOType = "IN";
            IOParmIn.IOParms.Add(cIOType);
        }

        public static void AddOutIO(CIOType cIOType)
        {
            cIOType.IOType = "OUT";
            IOParmOut.IOParms.Add(cIOType);
        }

        public static void Init()
        {
            BaseConfig.Instance.Read();

            if (BaseConfig.Instance.cardConfigs.Count > 0)
            {
                int CardNum = BaseConfig.Instance.cardConfigs.Count;
                int[] axis = new int[CardNum];
                string[] ConfigFile = new string[CardNum];
                for (int i = 0; i < BaseConfig.Instance.cardConfigs.Count; i++)
                {
                    axis[i] = BaseConfig.Instance.cardConfigs[i].AxisNum;
                    ConfigFile[i] = BaseConfig.Instance.cardConfigs[i].ConigPath;
                }
                CardAPI.InitCard(CardNum, axis, BaseConfig.Instance.ModeNum, ConfigFile);
                Log("开始加载轴");
                InitAxis();
                Log("开始加载IO");
                InitINIO();
                InitOUTIO();
                for (int i = 0; i < CardNum; i++)
                {
                    int cardNo = BaseConfig.Instance.cardConfigs[i].CardNo;
                    int count = AxisParm.AParms.Where(x => x.AxisInfo.CardNo == cardNo).ToList().Count();
                    BaseConfig.Instance.cardConfigs[i].AxisCurrentNum = count;
                }
                BaseConfig.Instance.Write();
            }
            else
            {
                Log("未配置运动控制卡");
            }
        }

        public static void InitAxis()
        {
            Motions.Clear();
            foreach (CAxisParm cAxisParm in AxisParm.AParms)
            {
                if (Motions.ContainsKey(cAxisParm.AxisInfo.AxisName))
                {
                    continue;
                }
                MotAPI motAPI = new MotAPI(cAxisParm);
                Motions.Add(cAxisParm.AxisInfo.AxisName, motAPI);
            }
            UpDateAxis?.Invoke();
        }

        public static void InitINIO()
        {
            InPort.Clear();
            foreach (CIOType iOType in IOParmIn.IOParms)
            {
                if (InPort.ContainsKey(iOType.IoName))
                {
                    continue;
                }
                Input input = new Input(iOType);
                InPort.Add(iOType.IoName, input);
            }
            UpDateINIO?.Invoke();
        }

        public static void InitOUTIO()
        {
            Output.Clear();
            foreach (CIOType iOType in IOParmOut.IOParms)
            {
                if (Output.ContainsKey(iOType.IoName))
                {
                    continue;
                }
                Output ouput = new Output(iOType);
                Output.Add(iOType.IoName, ouput);
            }
            UpDateOUTIO?.Invoke();
        }

        public static void Log(string message)
        {
            LogManager.Instance.WriteLog(new LogModel(LogType.运动控制日志, message));
        }

        public static MotAPI AddAxis(string AxisName)
        {
            MotAPI motAPI = null;
            foreach (CAxisParm cAxisParm in AxisParm.AParms)
            {
                if (cAxisParm.AxisInfo.AxisName == AxisName)
                {
                    motAPI = new MotAPI(cAxisParm);
                    Motions.Add(AxisName, motAPI);
                }
            }
            if (motAPI == null)
            {
                CAxisParm AxisParms = new CAxisParm();
                AxisParms.AxisInfo.AxisName = AxisName;
                AxisParm.AParms.Add(AxisParms);
                Motions.Add(AxisName, motAPI);
                motAPI = new MotAPI(AxisParms);
            }
            return motAPI;
        }

        public static void AddInPutIO(string Name)
        {
            Input input = null;
            foreach (CIOType iOType in IOParmIn.IOParms)
            {
                if (iOType.IoName == Name)
                {
                    input = new Input(iOType);
                    InPort.Add(Name, input);
                }
            }
            if (input == null)
            {
                CIOType CIOType = new CIOType();
                CIOType.IoName = Name;
                CIOType.IONum = (short)(IOParmIn.IOParms.Count);
                input = new Input(CIOType);
                IOParmIn.IOParms.Add(CIOType);
                InPort.Add(Name, input);
            }
        }
        public static void AddOutPutIO(string Name)
        {
            Output input = null;
            foreach (CIOType iOType in IOParmOut.IOParms)
            {
                if (iOType.IoName == Name)
                {
                    input = new Output(iOType);
                    Output.Add(Name, input);
                }
            }
            if (input == null)
            {
                CIOType CIOType = new CIOType();
                CIOType.IoName = Name;
                CIOType.IONum = (short)(IOParmOut.IOParms.Count);
                IOParmOut.IOParms.Add(CIOType);
                input = new Output(CIOType);
                Output.Add(Name, input);
            }
        }
    }
}
