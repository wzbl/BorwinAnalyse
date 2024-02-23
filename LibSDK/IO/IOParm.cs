using LibSDK.Motion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace LibSDK.IO
{
    public class IOParm
    {
        public List<CIOType> IOParms = new List<CIOType>();

        private string MyIOParmPath = @"Ini/OutIOCfg.xml";

        //private string MyIOParmPath =SDK.GlobPath+"\\IOCfg.xml";
        public IOParm(string type)
        {
            if (type == "In")
            {
                MyIOParmPath = @"Ini/InIOCfg.xml";
            }
            IOConfigIni();
        }


        public string IOParmPath
        {
            get
            {
                return MyIOParmPath;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    MyIOParmPath = value;
                }
                else
                {
                    MyIOParmPath = @"Ini/IOCfg.xml";
                }
            }
        }

        /// <summary>
        /// 加载IO参数
        /// </summary>
        public void IOConfigIni()
        {
            string path = MyIOParmPath;
            if (!File.Exists(path))
            {
                //new Alarm.Alarm().MesShow(0, "File Error", "Path:" + path + "<--未找到IO参数配置文件！！！", "OK");
                return;
            }
            Read();
        }
        public void Write()
        {
            LibSDK.Rwfile.CDataXml XML = new Rwfile.CDataXml();
            XML.Serializer<List<CIOType>>(MyIOParmPath, IOParms);
        }
        public void Read()
        {
            Rwfile.CDataXml XML = new Rwfile.CDataXml();

            IOParms = XML.DeserializeFile<List<CIOType>>(MyIOParmPath);
        }
        public CIOType GetIOprame(string IOName)
        {
            CIOType cIO = new CIOType();
            foreach (CIOType cIOType in IOParms)
            {
                if (cIOType.IoName == IOName)
                {
                    cIO = cIOType;
                }
            }
            return cIO;
        }

        public CIOType GetIOprame(int Index)
        {
            return IOParms[Index];
        }
    }

    [TypeConverter(typeof(NullConverter))]
    public class CIOType
    {
        [DisplayName("IO名称"), Description("IO名称")]
        public string IoName { get; set; }
        [DisplayName("IO类型"), Description("IO类型")]
        [ReadOnly(true)]
        public string IOType { get; set; } = "IN";
        [DisplayName("控制卡号"), Description("控制卡号")]
        public short CardNo { get; set; }
        [DisplayName("模块号从0开始"), Description("模块号从0开始")]
        public short Extmdl { get; set; }
  
        [DisplayName("IO端口号"), Description("IO端口号")]
        public short IONum { get; set; }
 
        [DisplayName("是/否(取反)"), Description("是/否(取反)")]
        public bool Invert { get; set; }
 
        [DisplayName("所属软件模块"), Description("所属软件模块")]
        public int SMode { get; set; }
   
        [DisplayName("检测延时"), Description("检测延时")]
        public double Delay { get; set; }
  
        [DisplayName("序号"), Description("序号")]
        public int Index { get; set; }
    }
}