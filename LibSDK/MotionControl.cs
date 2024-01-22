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
        public static IOParm IOParm { get; internal set; }
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

        public static MotAPI AddAxis(string AxisName, MotorType motorType)
        {
            MotAPI motAPI = null;
            foreach (CAxisParm cAxisParm in AxisParm.AParms)
            {
                if (cAxisParm.AxisName == AxisName)
                {
                    motAPI = new MotAPI(cAxisParm, motorType);
                    motAPI = new MotAPI(cAxisParm, motorType);
                    Motions.Add(AxisName, motAPI);
                }
            }
            return motAPI;
        }


    }
}
