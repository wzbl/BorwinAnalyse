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
        [Category("Debugging parameters|调试参数"), Description("Debugging parameters|调试参数"), DisplayName("Debugging parameters|调试参数")]
        public List<BaseAxisParam> BaseAxisParams {  get; set; }=new List<BaseAxisParam>();

        /// <summary>
        /// 加载参数
        /// </summary>
        public void Load()
        {
            string savePath = @"Ini/DebugerAxisParam.xml";
            if (!File.Exists(savePath))
            {
                return;
            }
            Rwfile.CDataXml XML = new Rwfile.CDataXml();
            DebugerAxisParam baseConfig = XML.DeserializeFile<DebugerAxisParam>(savePath);
            if (baseConfig != null)
            {
                instance = baseConfig;
            }

         
        }

        /// <summary>
        /// 保存参数
        /// </summary>
        public void Save()
        {
            string savePath = @"Ini/DebugerAxisParam.xml";
            LibSDK.Rwfile.CDataXml XML = new Rwfile.CDataXml();
            XML.Serializer<DebugerAxisParam>(savePath, instance);
        }
    }


    [TypeConverter(typeof(NullConverter))]
    public class BaseAxisParam
    {
        [Category("基础信息"), Description("控制卡ID"), DisplayName("控制卡ID")]
        public short CardNo { get; set; } = 0;

        /// <summary>
        /// 轴编号（从1开始）
        /// </summary>
        [Category("基础信息"), Description("轴编号(从1开始)"), DisplayName("轴编号")]
        public short AxisNo { get; set; } = 1;

        /// <summary>
        /// 轴编号（从1开始）
        /// </summary>
        [Category("基础信息"), Description("轴名称"), DisplayName("轴名称")]
        public string AxisName { get; set; }

        [Category("位置信息"), DisplayName("位置列表")]
        public List<PosParam> posParams { get; set; } = new List<PosParam>();
    }

    [TypeConverter(typeof(NullConverter))]
    public class PosParam
    {
        [Category("位置信息"), DisplayName("名称")]
        public string Name { get; set; }
        [Category("位置信息"), DisplayName("位置")]
        public double Pos { get; set; } = 0;
    }
}
