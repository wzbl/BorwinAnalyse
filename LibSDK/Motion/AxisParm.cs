using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSDK.Motion
{
    public class AxisParm
    {

        [Browsable(false)]
        public static  List<CAxisParm> AParms =new List<CAxisParm>();

        [Category("运动轴")]
        public CAxisParm A { get { return AParms[0]; } }
        [Category("运动轴")]
        public CAxisParm B { get { return AParms[1]; } }
        [Category("运动轴")]
        public CAxisParm C { get { return AParms[2]; } }
        [Category("运动轴")]
        public CAxisParm D { get { return AParms[3]; } }

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
        public void Write(string Path)
        {
            LibSDK.Rwfile.CDataXml XML = new Rwfile.CDataXml();
            XML.Serializer<List<CAxisParm>>(Path, AParms);
        }
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
            if (axisParm.ScaleFactor == 0)
            {
                axisParm.ScaleFactor = 1;
            }
            if (axisParm.ELGearRatio == 0)
            {
                axisParm.ELGearRatio = 1;
            }
            if (axisParm.ELGearRatio > 1)
            {
                motionpix = Convert.ToDouble(axisParm.GearRatio) / Convert.ToDouble(axisParm.ELGearRatio) / Convert.ToDouble(axisParm.Lead);
            }
            else
            {
                motionpix = Convert.ToDouble(axisParm.GearRatio) * Convert.ToDouble(axisParm.ScaleFactor) / Convert.ToDouble(axisParm.Lead);
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
                if (axisParm.AxisID == Axis && axisParm.CardID == CardNum)
                {
                    ReturnParm = axisParm;
                    break;
                }
            }
            return ReturnParm;
        }

        #endregion
    }


    public class CAxisParm
    {
        /// <summary>
        /// 轴名称
        /// </summary>
        [Category("基础信息"), Description("轴名称"), DisplayName("轴名称")]
        public string AxisName { get; set; }
        /// <summary>
        /// 轴编号（从1开始）
        /// </summary>
        [Category("基础信息"), Description("轴编号（从1开始）"), DisplayName("轴编号（从1开始）")]
        public short AxisID { get; set; }
        [Category("基础信息"), Description("控制卡ID"), DisplayName("控制卡ID")]
        public short CardID { get; set; }
        /// <summary>
        /// 伺服细分
        /// </summary>
        [Category("基础信息"), Description("伺服细分"), DisplayName("伺服细分")]
        public int GearRatio { get; set; }
        /// <summary>
        /// 导程
        /// </summary>
        [Category("基础信息"), Description("导程"), DisplayName("导程")]
        public float Lead { get; set; }
        /// <summary>
        /// 减速比
        /// </summary>
        [Category("基础信息"), Description("减速比"), DisplayName("减速比")]
        public float ScaleFactor { get; set; }
        /// <summary>
        /// 电子齿轮比
        /// </summary>
        [Category("基础信息"), Description("电子齿轮比"), DisplayName("电子齿轮比")]
        public float ELGearRatio { get; set; }

        /// <summary>
        /// 软件模块号
        /// </summary>
        [Category("基础信息"), Description("软件模块号"), DisplayName("软件模块号")]
        public int Sofmodule { get; set; }
        /// <summary>
        /// 电机类型 0，伺服电机 1，步进电机 ，2直线电机
        /// </summary>
        [Category("基础信息"), Description("电机类型 0，伺服电机 1，步进电机 ，2直线电机"), DisplayName("电机类型 0，伺服电机 1，步进电机 ，2直线电机")]
        public int MotType { get; set; }

        /// <summary>
        /// 回零方向（0为负方向，1为正方向）
        /// </summary>
        [Category("回零"), Description("回零方向（0为负方向，1为正方向）"), DisplayName("回零方向（0为负方向，1为正方向）")]
        public short HomeDirection { get; set; }
        /// <summary>
        /// 回零模式
        /// </summary>
        [Category("回零"), Description("回零模式"), DisplayName("回零模式")]
        public int HomeMode { get; set; }
        /// <summary>
        /// 回零速度
        /// </summary>
        [Category("回零"), Description("回零速度"), DisplayName("回零速度")]
        public float HomeSpd { get; set; }
        /// <summary>
        /// 寻找原点速度
        /// </summary>
        [Category("回零"), Description("寻找原点速度"), DisplayName("寻找原点速度")]
        public float SearchHomeSpd { get; set; }
        /// <summary>
        /// 回零偏移量
        /// </summary>
        [Category("回零"), Description("回零偏移量"), DisplayName("回零偏移量")]
        public float Homeoffset { get; set; }
        /// <summary>
        /// 起始反向距离(不用时设为0)
        /// </summary>
        [Category("回零"), Description("起始反向距离(不用时设为0)"), DisplayName("起始反向距离(不用时设为0)")]
        public int HomeRetPos { get; set; } = 0;
        /// <summary>
        ///  // 反向运动时离开开关距离(可选,不用时设为0)
        /// </summary>
        [Category("回零"), Description("反向运动时离开开关距离(可选,不用时设为0)"), DisplayName("反向运动时离开开关距离(可选,不用时设为0)")]
        public int HomeretSwOffset { get; set; } = 0;
        /// <summary>
        /// 安全距离,回零时最远搜寻距离(可选,不用时设为0,不限制距离)
        /// </summary>
        [Category("回零"), Description("安全距离,回零时最远搜寻距离"), DisplayName("安全距离,回零时最远搜寻距离(可选,不用时设为0,不限制距离)")]
        public int HomesafeLen { get; set; } = 0;
        /// <summary>
        /// 最大加速度
        /// </summary>
        [Category("运动"), Description("最大加速度"), DisplayName("最大加速度")]
        public float MaxAcc { get; set; }
        /// <summary>
        /// 最大手动速度
        /// </summary>
        [Category("运动"), Description("最大手动速度"), DisplayName("最大手动速度")]
        public float MaxManualMoveSpd { get; set; }
        /// <summary>
        /// 最大自动速度
        /// </summary>
        [Category("运动"), Description("最大自动速度"), DisplayName("最大自动速度")]
        public float MaxWorkSpd { get; set; }
        /// <summary>
        /// 平滑系数
        /// </summary
        [Category("运动"), Description("平滑系数"), DisplayName("平滑系数")]
        public short Smooth { get; set; }
        /// <summary>
        /// 正向限位
        /// </summary>
        [Category("运动"), Description("正向限位"), DisplayName("正向限位")]
        public float PosLimit { get; set; }
        /// <summary>
        /// 负向限位
        /// </summary>
        [Category("运动"), Description("负向限位"), DisplayName("负向限位")]
        public float NegLimit { get; set; }

        /// <summary>
        ///回零捕获电平
        /// </summary>
        [Category("回零"), Description("回零捕获电平"), DisplayName("回零捕获电平")]
        public short Level { get; set; }

    }
}
