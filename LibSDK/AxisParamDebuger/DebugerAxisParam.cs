using BorwinAnalyse.BaseClass;
using BorwinAnalyse.UCControls;
using ComponentFactory.Krypton.Toolkit;
using LibSDK.Motion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSDK.AxisParamDebuger
{
    /// <summary>
    /// 调试参数
    /// </summary>
    public class DebugerAxisParam
    {
        private static DebugerAxisParam instance;
        public static DebugerAxisParam Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DebugerAxisParam();
                }
                return instance;
            }
        }

        private Runners runners = new Runners();
        //流道宽8-24mm
        //夹紧宽8-24mm
        [Browsable(true),Category("流道参数"),DisplayName("流道")]
        public Runners Runners{ get => runners; set => runners = value; }
        [Browsable(true), Category("凸轮参数"), DisplayName("凸轮")]
        public Cam cam { get; set; }=new Cam();
        [Browsable(true), Category("拨刀参数"), DisplayName("拨刀")]
        public DialKnives dialKnives  { get; set; }=new DialKnives();
        [Browsable(true), Category("吸头参数"), DisplayName("吸头")]
        public Tips tips  { get; set; }=new Tips();
        [Browsable(true), Category("热熔头参数"), DisplayName("热熔头")]
        public HotMeltHead hotMeltHead  { get; set; }=new HotMeltHead(); 
        [Browsable(true), Category("吸嘴平移参数"), DisplayName("吸嘴平移")]
        public Nozzle Nozzle { get; set; }=new Nozzle();

        /// <summary>
        /// 加载参数
        /// </summary>
        public void Load()
        {
            string savePath = @"Ini/DebugerAxisParam.json";
            if (!File.Exists(savePath))
            {
                FileStream fs1 = new FileStream(savePath, FileMode.Create, FileAccess.ReadWrite);
                fs1.Close();
            }
            else
            {
                instance = JsonConvert.DeserializeObject<DebugerAxisParam>(File.ReadAllText(savePath));
            }
        }

        /// <summary>
        /// 保存参数
        /// </summary>
        public void Save()
        {
            string savePath = @"Ini/DebugerAxisParam.json";
            if (!File.Exists(savePath))
            {
                FileStream fs1 = new FileStream(savePath, FileMode.Create, FileAccess.ReadWrite);
                fs1.Close();
            }
            File.WriteAllText(savePath, JsonConvert.SerializeObject(instance));
        }
    }

    #region 流道
    /// <summary>
    /// 流道
    /// </summary>
    [TypeConverter(typeof(NullConverter))]
    public class Runners
    {

        //流道宽8-24mm
        //夹紧宽8-24mm
        [Browsable(true), Category("流道"), Description("流道参数"), DisplayName("流道")]
        public RunnersParam runners { get; set; } = new RunnersParam();

        [Browsable(true), Category("夹紧"), Description("夹紧参数"), DisplayName("夹紧")]
        public RunnersParam clamping { get; set; } = new RunnersParam();

    }

    [TypeConverter(typeof(NullConverter))]
    public class RunnersParam
    {
        [Browsable(true), Category("8"), Description("8mm参数"), DisplayName("8mm")]
        public double _8 { get; set; }
        [Browsable(true), Category("12"), Description("12mm参数"), DisplayName("12mm")]
        public double _12 { get; set; }
        [Browsable(true), Category("16"), Description("16mm参数"), DisplayName("16mm")]
        public double _16 { get; set; }
        [Browsable(true), Category("24"), Description("24mm参数"), DisplayName("24mm")]
        public double _24 { get; set; }
    }
    #endregion

    #region 凸轮
    [TypeConverter(typeof(NullConverter))]
    public class Cam
    {
        [Browsable(true), Category("取料位"), Description("至取料位"), DisplayName("取料位")]
        public double Reclaiming_Pos { get; set; }

        [Browsable(true), Category("切刀位"), Description("至切刀位"), DisplayName("切刀位")]
        public double Cutter_Pos { get; set; }  

        [Browsable(true), Category("热容位"), Description("至热容位"), DisplayName("热容位")]
        public double Hot_Melt_Pos { get; set; } 
        
        [Browsable(true), Category("包胶位"), Description("至包胶位"), DisplayName("包胶位")]
        public double Lagging_Pos { get; set; }
    }
    #endregion

    #region 拨刀
    [TypeConverter(typeof(NullConverter))]
    public class DialKnives
    {
        [Browsable(true), Category("拨出位"), Description("至拨出位"), DisplayName("拨出位")]
        public double DialOut_Pos { get; set; }

        [Browsable(true), Category("大膜退刀位"), Description("至大膜退刀位"), DisplayName("大膜退刀位")]
        public double LargeMembrane_Pos { get; set; }

        [Browsable(true), Category("小膜退刀位"), Description("至小膜退刀位"), DisplayName("小膜退刀位")]
        public double Membrane_Pos { get; set; }

        [Browsable(true), Category("速度"), Description("送膜1速度"), DisplayName("送膜1速度")]
        public double Velocity { get; set; }
    }
    #endregion

    #region 吸头
    [TypeConverter(typeof(NullConverter))]
    public class Tips
    {
        [Browsable(true), Category("待吸位"), Description("至待吸位"), DisplayName("待吸位")]
        public double Sucked_Pos { get; set; }

        [Browsable(true), Category("吸取位"), Description("至吸取位"), DisplayName("吸取位")]
        public double Suction_Pos { get; set; }

        [Browsable(true), Category("待贴位"), Description("至待贴位"), DisplayName("待贴位")]
        public double Pasted_Pos { get; set; }

        [Browsable(true), Category("贴料位置"), Description("至贴料位置"), DisplayName("贴料位置")]
        public double Patch_Pos { get; set; }
    }
    #endregion

    #region 吸嘴平移
    [TypeConverter(typeof(NullConverter))]
    public class Nozzle
    {
        [Browsable(true), Category("贴膜位"), Description("8mm贴膜位置"), DisplayName("8mm")]
        public double _8Pos { get; set; }

        [Browsable(true), Category("贴膜位"), Description("12mm贴膜位置"), DisplayName("12mm")]
        public double _12Pos { get; set; }

        [Browsable(true), Category("贴膜位"), Description("16mm贴膜位置"), DisplayName("16mm")]
        public double _16Pos { get; set; }

        [Browsable(true), Category("贴膜位"), Description("24mm贴膜位置"), DisplayName("24mm")]
        public double _24Pos { get; set; }

        [Browsable(true), Category("吸膜位"), Description("吸膜位"), DisplayName("吸膜位")]
        public double SuctionFilm_Pos { get; set; }

        [Browsable(true), Category("热熔位"), Description("热熔位"), DisplayName("热熔位")]
        public double HotMelt_Pos { get; set; }
    }
    #endregion

    #region 热熔头
    [TypeConverter(typeof(NullConverter))]
    public class HotMeltHead
    {
        [Browsable(true), Category("热熔头热熔位"), Description("热熔头热熔位"), DisplayName("热熔头热熔位")]
        public double Sucked_Pos { get; set; }

        [Browsable(true), Category("第二次贴位"), Description("第二次贴位"), DisplayName("第二次贴位")]
        public double Suction_Pos { get; set; }

        [Browsable(true), Category("吸头热熔位"), Description("吸头热熔位"), DisplayName("吸头热熔位")]
        public double Pasted_Pos { get; set; }
    }
    #endregion

    #region 左探针

    #endregion

    #region 右探针

    #endregion

    #region 下针电机

    #endregion

    #region 测值上下

    #endregion

}
