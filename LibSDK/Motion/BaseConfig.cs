using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSDK.Motion
{

    public class BaseConfig
    {

        private static BaseConfig instance;

        [Browsable(false)]
        public static BaseConfig Instance 
        {
            get 
            {
                if (instance==null)
                {
                    instance=new BaseConfig();
                }
                return instance;
            }
        }

        [Category("卡配置")]
        public List<CardConfig> cardConfigs = new List<CardConfig>();
        //[Category("模块数")]
        [Browsable(false)]
        public int ModeNum { get; set; } = 1;
  

        [Browsable(false)]
        private string MyAxisParmPath = @"Ini/BaseCfg.xml";

        public BaseConfig()
        {
            
        }


        public void Write()
        {
            LibSDK.Rwfile.CDataXml XML = new Rwfile.CDataXml();
            XML.Serializer<BaseConfig>(MyAxisParmPath,instance);
        }
        public void Read()
        {
            if (!File.Exists(MyAxisParmPath))
            {
                return;
            }
            Rwfile.CDataXml XML = new Rwfile.CDataXml();
            BaseConfig baseConfig = XML.DeserializeFile<BaseConfig>(MyAxisParmPath);
            if (baseConfig != null)
            {
                instance = baseConfig;
            }
        }

    }
    [Category("卡配置")]
    [TypeConverter(typeof(NullConverter))]
    public class CardConfig
    {
        [Category("卡配置"), Description("卡号"),DisplayName("卡号")]
        public int CardNo{get; set;}
        [Category("卡配置"), Description("轴数量"), DisplayName("轴数量")]
        public int AxisNum { get; set; }
        [Category("卡配置"), Description("当前轴数量"), DisplayName("当前轴数量")]
        public int AxisCurrentNum { get; set; }
        [Category("卡配置"), Description("配置文件"), DisplayName("配置文件")]
        public string ConigPath { get; set; }
    }
}
