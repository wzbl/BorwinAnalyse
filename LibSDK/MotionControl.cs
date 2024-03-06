using BorwinAnalyse.BaseClass;
using BorwinAnalyse.DataBase.Model;
using ComponentFactory.Krypton.Toolkit;
using LibSDK.AxisParamDebuger;
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


        #region 卡控制

        /// <summary>
        /// 更新卡
        /// </summary>
        public static Action UpDateCard;
        public static void AddCard()
        {
            CardConfig cardConfig = new CardConfig();
            cardConfig.CardNo = BaseConfig.Instance.cardConfigs.Count;
            cardConfig.AxisNum = 6;
            cardConfig.ConigPath = "";
            BaseConfig.Instance.cardConfigs.Add(cardConfig);
            BaseConfig.Instance.Write();
            Log("添加卡:" + cardConfig.CardNo);
            UpDateCard?.Invoke();
        }

        public static void DeleteCard(CardConfig cardConfig)
        {
            List<CAxisParm> cAxisParms = AxisParm.AParms.Where(x => x.AxisInfo.CardNo == cardConfig.CardNo).ToList();
            foreach (var cAxisParm in cAxisParms)
                DeleteAxis(cAxisParm);

            List<CIOType> ins = IOParmIn.IOParms.Where(x => x.CardNo == cardConfig.CardNo).ToList();
            foreach (var inIO in ins)
                DeleteInIO(inIO);

            List<CIOType> outs = IOParmOut.IOParms.Where(x => x.CardNo == cardConfig.CardNo).ToList();
            foreach (var outIO in outs)
                DeleteOutIO(outIO);

            BaseConfig.Instance.cardConfigs.Remove(cardConfig);
            BaseConfig.Instance.Write();
            UpDateCard?.Invoke();
        }
        #endregion

        #region 轴控制

        /// <summary>
        /// 添加点位
        /// </summary>
        public static Action AddPos;

        /// <summary>
        /// 更新轴
        /// </summary>
        public static Action UpDateAxis;
        public static void AddAxis(CAxisParm cAxisParm)
        {
            AxisParm.AParms.Add(cAxisParm);
            AxisParm.Write();
            InitAxis();
            Log("添加轴:" + cAxisParm.AxisInfo.AxisName);
        }

        public static void DeleteAxis(CAxisParm cAxisParm)
        {
            AxisParm.AParms.Remove(cAxisParm);
            AxisParm.Write();
            InitAxis();
            Log("删除轴:" + cAxisParm.AxisInfo.AxisName);
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
        #endregion

        #region 输入IO
        /// <summary>
        /// 是否可以修改
        /// </summary>
        public static Action<bool> IsEnable;
        /// <summary>
        /// 更新输入IO
        /// </summary>
        public static Action UpDateINIO;
        public static void AddInIO(CIOType cIOType)
        {
            cIOType.IOType = "IN";
            IOParmIn.IOParms.Add(cIOType);
            IOParmIn.Write();
            InitINIO();
        }

        public static void DeleteInIO(CIOType cIOType)
        {
            IOParmIn.IOParms.Remove(cIOType);
            IOParmIn.Write();
            InitINIO();
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
        #endregion

        #region 输出IO

        /// <summary>
        /// 更新输出IO
        /// </summary>
        public static Action UpDateOUTIO;
        public static void AddOutIO(CIOType cIOType)
        {
            cIOType.IOType = "OUT";
            IOParmOut.IOParms.Add(cIOType);
            IOParmOut.Write();
            InitOUTIO();
        }

        public static void DeleteOutIO(CIOType cIOType)
        {
            IOParmOut.IOParms.Remove(cIOType);
            IOParmOut.Write();
            InitOUTIO();
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
        #endregion

        public static void Init()
        {
            BaseConfig.Instance.Read();
            DebugerAxisParam.Instance.Load();
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
                Log("开始加载轴".tr());
                InitAxis();
                Log("开始加载IO".tr());
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
                Log("未配置运动控制卡".tr());
            }
        }


        /// <summary>
        /// 运动控制打印日志
        /// </summary>
        /// <param name="message"></param>
        public static void Log(string message)
        {
            LogManager.Instance.WriteLog(new LogModel(LogType.运动控制日志, message));
        }

        #region 外部获取轴/IO
        /// <summary>
        /// 外部逻辑，获取轴控制权
        /// </summary>
        /// <param name="AxisName"></param>
        /// <returns></returns>
        public static MotAPI GetAxis(string AxisName)
        {
            MotAPI motAPI = null;
            foreach (KeyValuePair<string, MotAPI> flowModel in Motions)
            {
                if (flowModel.Value.Name == AxisName)
                {
                    motAPI = flowModel.Value;
                    break;
                }
            }
            if (motAPI == null)
            {
                Log("初始化轴"+ AxisName + "失败");
            }
            else
            {
                Log("初始化轴" + AxisName + "成功");
            }
            return motAPI;
        }

        /// <summary>
        /// 外部逻辑,获取输入IO控制权
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>

        public static Input GetInPutIO(string Name)
        {
            Input input = null;
            foreach (KeyValuePair<string, Input> flowModel in InPort)
            {
                if (flowModel.Value.IOParm.IoName == Name)
                {
                    input = flowModel.Value;
                    break;
                }
            }

            return input;
        }

        /// <summary>
        /// 外部逻辑,获取输出IO控制权
        /// </summary>

        public static Output GetOutPutIO(string Name)
        {
            Output output = null;
            foreach (KeyValuePair<string, Output> flowModel in Output)
            {
                if (flowModel.Value.IOParm.IoName == Name)
                {
                    output = flowModel.Value;
                    break;
                }
            }
            return output;
        }

        #endregion


    }
}
