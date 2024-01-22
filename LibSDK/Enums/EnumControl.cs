using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace LibSDK.Enums
{
    public class EnumControl
    {
        public CardType CardType= CardType.GCS;
        public IOType IOType;
    }

    public enum CardType
    {
        Unknown = 0,
        GTS,
        LTDMC,
        GCS
    }

    public enum IOType
    {
        Unknown = 0,
        DMC640
    }

    public enum MotorType
    {
        Servo,//
        Step//
    }

    public enum OUTtype
    {
        On,
        Off
    }
}
