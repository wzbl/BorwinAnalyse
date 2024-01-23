using LibSDK.Enums;
using LibSDK.IO;
using LibSDK.Motion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public static MotAPI AddAxis(string AxisName)
        {
            MotAPI motAPI = null;
            foreach (CAxisParm cAxisParm in AxisParm.AParms)
            {
                if (cAxisParm.AxisName == AxisName)
                {
                    motAPI = new MotAPI(cAxisParm);
                    Motions.Add(AxisName, motAPI);
                }
            }
            if (motAPI == null)
            {
                CAxisParm AxisParms = new CAxisParm();
                AxisParms.AxisName = AxisName;
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
