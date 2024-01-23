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
        public CardType CardType = CardType.GCS;
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

    public enum MoveType
    {
        相对运动模式,
        绝对运动模式,
        JOG
    }

    public enum ReturnMode
    {
        单原点,
        单限位,
        单Z相,
        原点正Z相,
        原点正负Z相,
        限位正负Z相
    }

    public enum OUTtype
    {
        On,
        Off
    }

    /// <summary>
    /// 轴数量
    /// </summary>
    public enum Axis
    {
        A,
        B,
        C,
        D,
        E,
        F,
        G,
        H,
        I,
        J,
        K,
        L,
        M,
        N,
        O,
        P,
        Q,
        R,
        S,
        T,
        U,
        V,
        W,
        X,
        Y,
        Z,
        Length
    }
}
