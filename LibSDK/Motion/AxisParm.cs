using LibSDK.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSDK.Motion
{
    [TypeConverter(typeof(NullConverter))]
    public class AxisParm
    {

        [Category("轴")]
        public static List<CAxisParm> AParms = new List<CAxisParm>();


        [Browsable(false)]
        private string MyAxisParmPath = @"Ini/AxisCfg.xml";

        public AxisParm()
        {
            AxisConfigIni();
        }

        [Browsable(false)]
        /// <summary>
        /// 默认加载路径
        /// </summary>
        public string AxisParmPath
        {
            get
            {
                return MyAxisParmPath;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    MyAxisParmPath = value;
                }
                else
                {
                    MyAxisParmPath = @"./AxisCfg.xml";
                }
            }
        }

        /// <summary>
        /// 加载轴参数
        /// </summary>
        public void AxisConfigIni()
        {
            string path = MyAxisParmPath;
            if (!File.Exists(path))
            {
                return;
            }
            Read(path);
        }

        #region 读写轴参数、及对应配置 Xml

        public void Write()
        {
            LibSDK.Rwfile.CDataXml XML = new Rwfile.CDataXml();
            XML.Serializer<List<CAxisParm>>(AxisParmPath, AParms);
        }
        public void Read(string Path)
        {
            Rwfile.CDataXml XML = new Rwfile.CDataXml();
            AParms = XML.DeserializeFile<List<CAxisParm>>(Path);
        }
        #endregion

        #region 计算脉冲比 (脉冲/mm)
        /// <summary>
        /// 获取轴脉冲比（脉冲/mm）
        /// </summary>
        /// <param name="Axis">轴编号</param>
        /// <returns></returns>
        public double GetMotionPix(short CardNum, short Axis)
        {
            double motionpix = 0;
            CAxisParm axisParm = GetAxisParm(CardNum, Axis);//根据卡号轴号获取参数
            if (axisParm.AxisInfo.ScaleFactor == 0)
            {
                axisParm.AxisInfo.ScaleFactor = 1;
            }
            if (axisParm.AxisInfo.ELGearRatio == 0)
            {
                axisParm.AxisInfo.ELGearRatio = 1;
            }
            if (axisParm.AxisInfo.ELGearRatio > 1)
            {
                motionpix = Convert.ToDouble(axisParm.AxisInfo.GearRatio) / Convert.ToDouble(axisParm.AxisInfo.ELGearRatio) / Convert.ToDouble(axisParm.AxisInfo.Lead);
            }
            else
            {
                motionpix = Convert.ToDouble(axisParm.AxisInfo.GearRatio) * Convert.ToDouble(axisParm.AxisInfo.ScaleFactor) / Convert.ToDouble(axisParm.AxisInfo.Lead);
            }
            return motionpix;
        }
        #endregion

        #region 按轴号获取当前轴参数
        public CAxisParm GetAxisParm(short CardNum, short Axis)
        {
            CAxisParm ReturnParm = new CAxisParm();
            foreach (CAxisParm axisParm in AParms)
            {
                if (axisParm.AxisInfo.AxisNo == Axis && axisParm.AxisInfo.CardNo == CardNum)
                {
                    ReturnParm = axisParm;
                    break;
                }
            }
            return ReturnParm;
        }

        #endregion
    }
    [Category("轴"),DisplayName("轴")]
    [TypeConverter(typeof(NullConverter))]
    public class CAxisParm
    {

        public CAxisParm()
        {
            AxisInfo = new AxisInfo();
            AxisHomeParam = new AxisHomeParam();
            AxisMotionPara = new AxisMotionPara();
           
        }

        [Category("基础参数"),DisplayName("基础参数")]
        public AxisInfo AxisInfo { get; set; }

        [Category("回零参数"), DisplayName("回零参数")]
        public AxisHomeParam AxisHomeParam { get; set; }

        [Category("运动参数"), DisplayName("运动参数")]
        public AxisMotionPara AxisMotionPara { get; set; }

    }

    [TypeConverter(typeof(NullConverter))]
    public class AxisInfo
    {
        [Category("基础信息"), ReadOnly(true), Description("控制卡ID"), DisplayName("控制卡ID")]
        public short CardNo { get; set; } = 0;

        /// <summary>
        /// 轴编号（从1开始）
        /// </summary>
        [Category("基础信息"), ReadOnly(true), Description("轴编号（从1开始）"), DisplayName("轴编号")]
        public short AxisNo { get; set; } = 1;

        /// <summary>
        /// 轴名称
        /// </summary>
        [Category("基础信息"), ReadOnly(false), Description("轴名称"), DisplayName("轴名称")]
        public string AxisName { get; set; }
     
        /// <summary>
        /// 伺服细分
        /// </summary>
        [Category("基础信息"), ReadOnly(false), Description("伺服细分"), DisplayName("伺服细分")]
        public int GearRatio { get; set; } = 1;

        /// <summary>
        /// 导程
        /// </summary>
        [Category("基础信息"), ReadOnly(false), Description("导程"), DisplayName("导程")]
        public float Lead { get; set; } = 5;

        /// <summary>
        /// 减速比
        /// </summary>
        [Category("基础信息"), ReadOnly(false), Description("减速比"), DisplayName("减速比")]
        public float ScaleFactor { get; set; } = 1;

        /// <summary>
        /// 电子齿轮比
        /// </summary>
        [Category("基础信息"), ReadOnly(false), Description("电子齿轮比"), DisplayName("电子齿轮比")]
        public float ELGearRatio { get; set; } = 1;

        /// <summary>
        /// 软件模块号
        /// </summary>
        [Category("基础信息"), ReadOnly(false), Description("软件模块号"), DisplayName("软件模块号")]
        public int Sofmodule { get; set; } = 0;

        /// <summary>
        /// 电机类型 0，伺服电机 1，步进电机 ，2直线电机
        /// </summary>
        [Category("基础信息"), ReadOnly(false), Description("电机类型 0，伺服电机 1，步进电机 ，2直线电机"), DisplayName("电机类型")]
        public MotorType MotType { get; set; } = MotorType.Step;
    }
    [TypeConverter(typeof(NullConverter))]
    public class AxisHomeParam
    {
        [Category("回零"), ReadOnly(false), Description("回零模式"), DisplayName("回零模式")]
        public ReturnMode HomeMode { get; set; }
      
        [Category("回零"), ReadOnly(false), Description("回零方向（0为负方向，1为正方向）"), DisplayName("回零方向")]
        public short HomeDirection { get; set; } = 0;

        [Category("回零"), ReadOnly(false), Description("安全距离,回零时最远搜寻距离"), DisplayName("安全距离,回零时最远搜寻距离")]
        public int HomesafeLen { get; set; } = 0;

        /// <summary>
        /// 回零速度
        /// </summary>
        [Category("回零"), ReadOnly(false), Description("回零速度"), DisplayName("回零速度")]
        public float HomeSpd { get; set; } = 10;

        /// <summary>
        /// 回零速度
        /// </summary>
        [Category("回零"), ReadOnly(false), Description("回零加速度"), DisplayName("回零速加度")]
        public float HomeAccSpd { get; set; } = 5;

        /// <summary>
        /// 寻找原点速度
        /// </summary>
        [Category("回零"), ReadOnly(false), Description("寻找原点速度"), DisplayName("寻找原点速度")]
        public float SearchHomeSpd { get; set; } = 2;

        /// <summary>
        /// 回零偏移量
        /// </summary>
        [Category("回零"), ReadOnly(false), Description("回零偏移量"), DisplayName("回零偏移量")]
        public float Homeoffset { get; set; } = 50;

        [Category("回零"), ReadOnly(false), Description("可选是否二次回零"), DisplayName("二次回零")]
        public bool HomeretSwOffset { get; set; } = false;

        /// <summary>
        /// 起始反向距离(不用时设为0)
        /// </summary>
        [Category("回零"), ReadOnly(false), Description("二次反向离开的距离"), DisplayName("二次反向离开的距离")]
        public int HomeretSwOffsetPos { get; set; } = 0;

        [Category("回零"), ReadOnly(false), Description("是否清除位置"), DisplayName("清除位置")]
        public bool HomeClearPos { get; set; } = false;

       
        [Category("回零"), Description("原点上升沿触发"), DisplayName("原点上升沿触发")]
        public bool OriginTriggering { get; set; } = false;

        [Category("回零"), Description("限位上升沿触发"), DisplayName("限位上升沿触发")]
        public bool LimitTriggering { get; set; } = false;

        [Category("回零"), Description("Z上升沿触发"), DisplayName("Z上升沿触发")]
        public bool ZTriggering { get; set; } = false;
    }
    [TypeConverter(typeof(NullConverter))]
    public class AxisMotionPara
    {

        [Category("运动"), ReadOnly(false), Description("最大加速度"), DisplayName("最大加速度")]
        public float MaxAcc { get; set; } = 100;

        [Category("运动"), Description("最大手动速度"), DisplayName("最大手动速度")]
        public float MaxManualMoveSpd { get; set; } = 100;

        [Category("运动"), Description("最大自动速度"), DisplayName("最大自动速度")]
        public float MaxWorkSpd { get; set; } = 50;

        [Category("运动"), Description("运行速度"), DisplayName("运行速度")]
        public float MotionSped { get; set; }

        [Category("运动"), Description("运行加速度"), DisplayName("运行加速度")]
        public float MotionAcc { get; set; }

        [Category("运动"), Description("运行减速度"), DisplayName("运行减速度")]
        public float MotionDecAcc { get; set; }

        [Category("运动"), Description("起跳速度"), DisplayName("起跳速度")]
        public float TakeOffSped { get; set; }

        [Category("运动"), Description("结束速度"), DisplayName("结束速度")]
        public float EndSped { get; set; }

        [Category("运动"), Description("平滑系数"), DisplayName("平滑系数")]
        public short Smooth { get; set; }
       [Category("运动"), Description("是否启用软限位"), DisplayName("是否启用软限位")]
        public bool IsEnableSoftLimit { get; set; }
        [Category("运动"), Description("正向限位"), DisplayName("正向限位")]
        public float PosLimit { get; set; }
      
        [Category("运动"), Description("负向限位"), DisplayName("负向限位")]
        public float NegLimit { get; set; }
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
