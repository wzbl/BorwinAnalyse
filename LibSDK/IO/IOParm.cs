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
        public  List<CIOType> IOParms = new List<CIOType>();

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
            foreach(CIOType cIOType in IOParms)
            {
                if(cIOType.IoName== IOName)
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
        /// <summary>
        /// IO名称
        /// </summary>
        public string IoName { get; set; }
        /// <summary>
        /// IO类型
        /// </summary>u
        public string IOType { get; set; }
        /// <summary>
        /// 卡号
        /// </summary>
        public short CardNum { get; set; }
        /// <summary>
        /// 模块号从0开始
        /// </summary>
        public short Extmdl { get; set; }
        /// <summary>
        /// IO端口号
        /// </summary>
        public short IONum { get; set; }
        /// <summary>
        /// 是/否(取反)
        /// </summary>
        public bool Invert { get; set; }
        /// <summary>
        ///  所属软件模块
        /// </summary>
        public int SMode { get; set; }
        /// <summary>
        /// 检测延时
        /// </summary>
        public double Delay { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int Index { get; set; }
    }
}