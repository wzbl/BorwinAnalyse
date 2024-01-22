using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionLibrary
{
    [TypeConverter(typeof(NullConverter))]
    public class OptionAxis
    {
        [Category("Home")]
        public HomeAxis HomeParam {  get; set; }

        [Category("Motion")]
        public MotionAxis MotionParam { get; set; }

    }

    [TypeConverter(typeof(NullConverter))]
    public class MotionAxis
    {
        [Category("运动"), ReadOnly(true), Description("轴"), DisplayName("轴")]
        public string Name
        {
            get;
            set;
        }

        [Category("运动"), ReadOnly(true), Description("轴号"), DisplayName("轴号")]
        public int Number
        {
            get;
            set;
        }


        [Category("运动"), ReadOnly(false), Description("速度"), DisplayName("速度")]
        public double Velocity
        {
            get;
            set;
        } = 50;

        [Category("运动"), ReadOnly(false), Description("加速度"), DisplayName("加速度")]
        public double Acceleration
        {
            get;
            set;
        } = 50;

        [Category("运动"), ReadOnly(false), Description("减速度"), DisplayName("减速度")]
        public double DecAcceleration
        {
            get;
            set;
        } = 50;

        [Category("运动"), ReadOnly(false), Description("脉冲/毫米"), DisplayName("每毫米脉冲数")]
        public int Resolution
        {
            get;
            set;
        } = 10000;
        [Category("运动"), Browsable(true), ReadOnly(false), Description("起跳运动速度"), DisplayName("起跳运动速度")]
        public double JumpVelocity
        {
            get;
            set;
        } = 1;

        [Category("运动"), Browsable(true), ReadOnly(false), Description("结束运动速度"), DisplayName("结束运动速度")]
        public double EndVelocity
        {
            get;
            set;
        } = 0;
        [Category("运动"), Browsable(true), ReadOnly(false), Description("平滑系数"), DisplayName("平滑系数")]
        public short SmoothCoef
        {
            get;
            set;
        } = 0;


        [Category("运动"), ReadOnly(true), Description("启用状态"), DisplayName("启用状态")]
        public bool Enabled
        {
            get;
            set;
        }

        [Category("运动"), ReadOnly(true), Description("软件正限位"), DisplayName("软件正限位")]
        public double PositivePosition
        {
            get;
            set;
        }

        [Category("运动"), ReadOnly(true), Description("软件负限位"), DisplayName("软件负限位")]
        public double NegativePosition
        {
            get;
            set;
        }

    }

    [TypeConverter(typeof(NullConverter))]
    public class HomeAxis
    {
        [Category("回零"), ReadOnly(false), Description("回零点方式"), DisplayName("回零点方式")]
        public ReturnMode ReturnMode { get; set; }

        [Category("回零"), ReadOnly(false), Description("回零点方向"), DisplayName("回零点方向")]
        public short HomeDir { get; set; }
        [Category("回零"), ReadOnly(false), Description("原点上升沿触发"), DisplayName("原点上升沿触发0|1")]
        public bool HomeEdge
        {
            get;
            set;
        }
        [Category("回零"), ReadOnly(false), Description("限位上升沿触发"), DisplayName("限位上升沿触发")]
        public bool LmtEdge
        {
            get;
            set;
        }
        [Category("回零"), ReadOnly(false), Description("Z上升沿触发"), DisplayName("Z上升沿触发")]
        public bool ZEdge
        {
            get;
            set;
        }
        [Category("回零"), ReadOnly(false), Description("二次搜索原点"), DisplayName("二次搜索原点,0|1")]
        public bool HomereScanEn         // 二次搜寻零点，与参数scan2ndVel一起使用
        {
            get;
            set;
        }

        [Category("回零"), ReadOnly(false), Description("原点搜索安全距离"), DisplayName("原点搜索安全距离")]
        public int HomeSafeDistance
        {
            get;
            set;
        } = 50;

        [Category("回零"), ReadOnly(false), Description("回零初始固定回退距离"), DisplayName("回零初始固定回退距离")]
        public int HomeIniRetPos
        {
            get;
            set;
        } = 50;

        [Category("回零"), ReadOnly(false), Description("二次零点回退距离"), DisplayName("二次零点回退距离")]
        public int HomeRetSwOffset
        {
            get;
            set;
        } = 50;
        [Category("回零"), ReadOnly(false), Description("原点偏移量"), DisplayName("原点偏移量")]
        public int HomeOffset
        {
            get;
            set;
        }

        [Category("回零"), ReadOnly(false), Description("回零速度"), DisplayName("回零速度")]
        public double HomeMoveVel
        {
            get;
            set;
        } = 50;
        [Category("回零"), ReadOnly(false), Description("回零加速度"), DisplayName("回零加速度")]
        public double HomeMoveAcc
        {
            get;
            set;
        } = 50;

        [Category("回零"), ReadOnly(false), Description("原点搜索速度"), DisplayName("原点搜索速度")]
        public int HomeSearchVel
        {
            get;
            set;
        } = 8;

        [Category("回零"), ReadOnly(false), Description("回完原点后，延时此时间后将坐标清零，单位：ms"), DisplayName("坐标清零延时")]
        public int ClearDelay { get; set; } = 3000;
    }

    public enum ReturnMode
    {
        单原点,
        单限位,
        单Z相,
        原点正Z相,
        原点正负Z相,
        限位正负Z相,
        //Home,
        //Index,
        //Home_Index,
    }

    public class NullConverter : ExpandableObjectConverter
    {
        #region ExpandableObjectConverter

        public override bool CanConvertTo(ITypeDescriptorContext context, System.Type destinationType)
        {
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return string.Format("");
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        #endregion
    }
}
