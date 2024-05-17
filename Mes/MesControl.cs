using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;
using System.Xml;
using System.Web.UI.WebControls;
using System.Data;
using Newtonsoft.Json.Linq;
using BorwinAnalyse;
using BorwinAnalyse.BaseClass;
using BorwinAnalyse.DataBase.Model;

namespace Mes
{
    public class MesControl
    {
        private static MesControl instance;

        public static MesControl Instance
        {
            get
            {
                if (instance == null)
                    instance = new MesControl();
                return instance;
            }
            set => instance = value;
        }

        /// <summary>
        /// 1.是否对接mes
        /// </summary>
        public bool IsOpenMes { get; set; }
        //2.mes类型（webAPI）
        public MesType MesType { get; set; }
        //3.数据类型（json）
        public DataType DataType { get; set; }

        public string Line = "";
        public string MachineCode = "";
        public string Wo = "";
        public string StandNo = "";//站位号
        public string UserName = "";

        public string Ip = "127.0.0.1";
        public int Port = 6666;
        public InterType CurrentType = InterType.登录;
        public LoginIn loginIn = new LoginIn();
        public LoginOut loginOut = new LoginOut();
        public CheckInCode1 checkInCode1 = new CheckInCode1();
        public CheckOutCode1 checkOutCode1 = new CheckOutCode1();
        public CheckInCode2 checkInCode2 = new CheckInCode2();
        public CheckOutCode2 checkOutCode2 = new CheckOutCode2();
        public UpDataIn upDataIn = new UpDataIn();
        public UpDataOut upDataOut = new UpDataOut();
        public HPDataIn HPDataIn = new HPDataIn();
        public HPDataOut HPDataOut = new HPDataOut();
        public HPIn HPDataList = new HPIn();

        public XMLSoap XML = new XMLSoap();
        [NonSerialized]
        public Action ActionCheckCode1;
        [NonSerialized]
        public Action ActionCheckCode2;
        [NonSerialized]
        public Action ActionHPResult;
        [NonSerialized]
        public Action<HPDataIn> ActionHPAdd;
      

        [NonSerialized]
        public Action ActionHPDelete;

        public void Load()
        {
            string savePath = @"Ini/MesControl.json";
            if (!File.Exists(savePath))
            {
                FileStream fs1 = new FileStream(savePath, FileMode.Create, FileAccess.ReadWrite);
                fs1.Close();
            }
            else
            {
                instance = JsonConvert.DeserializeObject<MesControl>(File.ReadAllText(savePath));
            }
        }

        /// <summary>
        /// 保存参数
        /// </summary>
        public void Save()
        {
            string savePath = @"Ini/MesControl.json";
            if (!File.Exists(savePath))
            {
                FileStream fs1 = new FileStream(savePath, FileMode.Create, FileAccess.ReadWrite);
                fs1.Close();
            }
            File.WriteAllText(savePath, JsonConvert.SerializeObject(instance));
        }

        /// <summary>
        /// Mes返回JSON转字典
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public Dictionary<string, string> JsonToDiC(string json)
        {
            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            return values;
        }

        public void Log(string message)
        {
            LogManager.Instance.WriteLog(new LogModel(LogType.Mes日志, message));
        }
        public void Updata(InterType interType)
        {
            CurrentType = interType;
            GetMesModel(interType, out MesIn MesIn, out MesOut MesOut);
            if (MesType != MesType.WebService)
            {
                Dictionary<string, string> datas = new Dictionary<string, string>();
                foreach (var item in MesIn.mesInValues)
                {
                    if (item.Enable && item != MesIn.IsEnable && item != MesIn.URL && item != MesIn.WebFunName && item != MesIn.WebFunName_Xmlns && item != MesIn.WebParamName_Xmlns)
                    {
                        datas.Add(item.Key, item.Value);
                    }
                }
                string json = JsonConvert.SerializeObject(datas, Newtonsoft.Json.Formatting.Indented);
                string res = MesControl.Instance.UpData(interType, MesIn.URL.Value, json);
                if (res != MesType.Socket.ToString())
                {
                    AnalyData(res);
                }
            }
            else
            {
                List<MesValue> mesValues = new List<MesValue>();
                foreach (var item in MesIn.mesInValues)
                {
                    if (item.Enable && item != MesIn.IsEnable && item != MesIn.URL && item != MesIn.WebFunName && item != MesIn.WebFunName_Xmlns && item != MesIn.WebParamName_Xmlns)
                    {
                        mesValues.Add(item);
                    }
                }
                string data = MesControl.Instance.CreateXmlData1(interType, mesValues);
                string xmlData = MesControl.Instance.UpData(interType, MesIn.URL.Value, data);
                AnalyData(xmlData);
            }
        }

        public void GetMesModel(InterType interType, out MesIn MesIn, out MesOut MesOut)
        {
            MesIn = new MesIn();
            MesOut = new MesOut();
            switch (interType)
            {
                case InterType.登录:
                    MesIn = loginIn;
                    MesOut = loginOut;
                    break;
                case InterType.条码1检验:
                    MesIn = checkInCode1;
                    MesOut = checkOutCode1;
                    break;
                case InterType.条码2检验:
                    MesIn = checkInCode2;
                    MesOut = checkOutCode2;
                    break;
                case InterType.上传信息:
                    MesIn = upDataIn;
                    MesOut = upDataOut;
                    break;
                case InterType.合盘:
                    MesIn = HPDataIn;
                    MesOut = HPDataOut;
                    break;
            }
        }
        public string UpData(InterType name, string url, string json)
        {
            string res = "";
            Log(name.ToString().tr() + ":" + json);
            switch (MesControl.Instance.MesType)
            {
                case MesType.WebApi:
                    WebApiHelper webApiHelper = new WebApiHelper();
                    res = webApiHelper.HttpPost(url, json);
                    Log(res);
                    break;
                case MesType.Socket:
                    MesClientSocket.ConnectService(Ip, Port);
                    MesClientSocket.ClientSendMsg(json);
                    res = MesType.Socket.ToString();
                    break;
                case MesType.WebService:
                    res = GetService1(url, json);
                    if (string.IsNullOrEmpty(res))
                    {
                        Log(res);
                    }
                    break;
            }
            return res;
        }

        public string CreateXmlData1(InterType type, List<MesValue> mesValues)
        {
            XNamespace xsi = "http://www.w3.org/2001/XMLSchema-instance";//XML.XSI.Value;
            XNamespace xsd = "http://www.w3.org/2001/XMLSchema";//XML.XSD.Value; 
            XNamespace soap = "http://schemas.xmlsoap.org/soap/envelope/";//XML.SOAP.Value; 

            XmlDocument pXmlDocument = new XmlDocument();
            XmlDeclaration pXmlDeclaration = pXmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
            pXmlDocument.AppendChild(pXmlDeclaration);
            XmlElement root = pXmlDocument.CreateElement("soap", "Envelope", "urn:soap");//加入根节点 
            root.SetAttribute("xmlns:xsi", xsi.ToString());//xml的名称空间
            root.SetAttribute("xmlns:xsd", xsd.ToString());//xml的名称空间
            root.SetAttribute("xmlns:soap", soap.ToString());//xml的名称空间
            pXmlDocument.AppendChild(root);

            XmlElement body = pXmlDocument.CreateElement("soap", "Body", "urn:soap");//
            root.AppendChild(body);
            XmlCDataSection cd = null; XmlDocument Document = null;
            string FuncName = "";
            string xmlns = "";
            string inPutParamName = "";
            switch (type)
            {
                case InterType.登录:
                    FuncName = loginIn.WebFunName.Value;
                    xmlns = loginIn.WebFunName_Xmlns.Value;
                    inPutParamName = loginIn.WebParamName_Xmlns.Value;
                    break;
                case InterType.条码1检验:
                    FuncName = checkInCode1.WebFunName.Value;
                    xmlns = checkInCode1.WebFunName_Xmlns.Value;
                    inPutParamName = checkInCode1.WebParamName_Xmlns.Value;
                    break;
                case InterType.条码2检验:
                    FuncName = checkInCode2.WebFunName.Value;
                    xmlns = checkInCode2.WebFunName_Xmlns.Value;
                    inPutParamName = checkInCode2.WebParamName_Xmlns.Value;
                    break;
                case InterType.上传信息:
                    FuncName = upDataIn.WebFunName.Value;
                    xmlns = upDataIn.WebFunName_Xmlns.Value;
                    inPutParamName = upDataIn.WebParamName_Xmlns.Value;
                    break;
                case InterType.合盘:

                    break;
                default:
                    break;
            }

            XmlElement LOT_COLECTDATA = pXmlDocument.CreateElement(FuncName);//接口名
            LOT_COLECTDATA.SetAttribute("xmlns", xmlns.ToString());
            body.AppendChild(LOT_COLECTDATA);
            XmlElement InputStr = pXmlDocument.CreateElement(inPutParamName);
            LOT_COLECTDATA.AppendChild(InputStr);

            foreach (var item in mesValues)
            {
                XmlElement WO = pXmlDocument.CreateElement(item.Key);
                WO.InnerText = item.Value;
                InputStr.AppendChild(WO);
            }
            //if (XML.IsCDATA.Enable)
            //    cd = pXmlDocument.CreateCDataSection(CreateNode(mesValues).InnerText);
            //else
            //{
            //    Document = CreateNode(mesValues);
            //}



            return pXmlDocument.InnerXml;
        }

        private XmlDocument CreateNode(List<MesValue> mesValues)
        {
            XmlDocument document = new XmlDocument();
            foreach (var item in mesValues)
            {
                XmlElement WO = document.CreateElement(item.Key);
                WO.InnerText = item.Value;
                document.AppendChild(WO);
            }
            return document;
        }

        public string GetService1(string url, string par)
        {
            string res = "";
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse webResponse = null;
            Stream writer = null;
            Stream reader = null;
            byte[] data = Encoding.UTF8.GetBytes(par);
            webRequest.Method = "Get";
            webRequest.ContentType = "text/html, application/xhtml+xml, */*"; //"text/xml; charset=utf-8";
            webRequest.ContentLength = data.Length;

            //webRequest.ContentType = "application/json";
            //webRequest.ContentType = "application/x-www-form-urlencoded";

            //写入参数
            try
            {
                writer = webRequest.GetRequestStream();
                writer.Write(data, 0, data.Length);
                writer.Close();
            }
            catch (Exception ex)
            {

                Log(ex.Message);
                return "";
            }
            //获取响应
            try
            {
                webResponse = (HttpWebResponse)webRequest.GetResponse();
                reader = webResponse.GetResponseStream();
                StreamReader streamReader = new StreamReader(reader, Encoding.UTF8);
                res = streamReader.ReadToEnd();
                reader.Close();
                streamReader.Close();
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                return "";
            }

            return HttpUtility.HtmlDecode(res);
        }

        /// <summary>
        /// 解析mes返回数据
        /// </summary>
        /// <param name="res"></param>
        public void AnalyData(string res)
        {
            GetMesModel(CurrentType, out MesIn mesIn, out MesOut MesOut);
            try
            {
                Log("系统返回:" + res);
                foreach (MesValue pv in MesOut.mesOutValues)
                    pv.Value = "";
                dynamic o = JsonConvert.DeserializeObject(res);
                if (o != null)
                {
                    string s = o.ToString();
                    s = s.Replace("\\", "");
                    o = JsonConvert.DeserializeObject(s);
                }

                foreach (MesValue pv in MesOut.mesOutValues)
                {
                    try
                    {
                        if (pv.Enable)
                        {
                            string key = pv.Key;

                            string val = o[key];

                            if (val != null)
                            {
                                pv.Value = val;
                            }

                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                MesOut.ErrorMsg.Value = "Exception:" + ex.Message;
            }

            switch (CurrentType)
            {
                case InterType.登录:
                    AnalyLogin();
                    break;
                case InterType.条码1检验:
                    AnalyCheckCode1();
                    break;
                case InterType.条码2检验:
                    AnalyCheckCode2();
                    break;
                case InterType.上传信息:
                    AnalyUpData();
                    break; 
                case InterType.合盘:
                    AnalyHP();
                    break;
                default:
                    break;
            }
            UCMes.timer1.Start();
        }

        

        private void AnalyLogin()
        {

        }

        private void AnalyCheckCode1()
        {
            ActionCheckCode1?.Invoke();
        }

        private void AnalyCheckCode2()
        {
            ActionCheckCode2?.Invoke();
        }

        private void AnalyUpData()
        {

        }

        private void AnalyHP()
        {
            ActionHPResult?.Invoke();
        }
        public HPDataIn GetHPObject()
        {
            HPDataIn hPData = new HPDataIn();
            hPData.Line = HPDataIn.Line;
            hPData.MachineCode = HPDataIn.MachineCode;
            hPData.Wo = HPDataIn.Wo;
            hPData.StandNo = HPDataIn.StandNo;
            hPData.UserName = HPDataIn.UserName;
            hPData.InterFaceNo = HPDataIn.InterFaceNo;
            hPData.BarCode.SetValue(HPDataIn.BarCode);
            hPData.IsLCR.SetValue(HPDataIn.IsLCR);
            hPData.Type.SetValue(HPDataIn.Type);
            hPData.Size.SetValue(HPDataIn.Size);
            hPData.StandValue.SetValue(HPDataIn.StandValue);
            hPData.MaxValue.SetValue(HPDataIn.MaxValue);
            hPData.MinValue.SetValue(HPDataIn.MinValue);
            hPData.LCRValue.SetValue(HPDataIn.LCRValue);
            return hPData;
        }

    }

    /// <summary>
    /// mes类型
    /// </summary>
    public enum MesType
    {
        WebApi,
        Socket,
        WebService
    }

    /// <summary>
    /// 数据类型
    /// </summary>
    public enum DataType
    {
        Json,
        Xml
    }

    public enum InterType
    {
        登录,
        条码1检验,
        条码2检验,
        上传信息,
        合盘
    }

    public class MesIn
    {
        //上传
        public MesValue IsEnable = new MesValue("是否启用", "", true);
        public MesValue URL = new MesValue("URL", "", true);
        public MesValue WebFunName = new MesValue("WebServices 方法名", "", true);
        public MesValue WebFunName_Xmlns = new MesValue("WebServices方法名_Xmlns", "http://SONIC_Service.org/", true);
        public MesValue WebParamName_Xmlns = new MesValue("WebServices参数名_Xmlns", "http://SONIC_Service.org/", true);
        public MesValue Line = new MesValue("线体", "", true);
        public MesValue MachineCode = new MesValue("设备代码", "", true);
        public MesValue Wo = new MesValue("工单单号", "", true);
        public MesValue StandNo = new MesValue("站位号", "", true);
        public MesValue UserName = new MesValue("用户名", "", true);
        public MesValue InterFaceNo = new MesValue("接口序号", "1", true);
        [NonSerialized]
        public List<MesValue> mesInValues = new List<MesValue>();

    }

    public class MesOut
    {
        //返回
        public MesValue Result = new MesValue("结果", "");
        public MesValue ErrorMsg = new MesValue("失败信息", "");
        public MesValue ErrorCode = new MesValue("失败代码", "");
        public MesValue InterFaceNo = new MesValue("接口序号", "1", true);
        [NonSerialized]
        public List<MesValue> mesOutValues = new List<MesValue>();
    }

    public class LoginIn : MesIn
    {
        //上传
        public MesValue Pwd = new MesValue("密码", "", true);
    }

    public class LoginOut : MesOut
    {
        //返回
        public MesValue StrToken = new MesValue("AccToken", "", true);
    }

    public class CheckInCode1 : MesIn
    {
        //上传
        public MesValue Code = new MesValue("条码", "", true);
    }

    public class CheckOutCode1 : MesOut
    {
        //返回
        public MesValue IsLCR = new MesValue("是否测值", "");
        public MesValue MaterialDes = new MesValue("物料描述", "");
        public MesValue Type = new MesValue("类型", "");
        public MesValue Size = new MesValue("规格", "");
        public MesValue Value = new MesValue("标准值", "");
        public MesValue MaxValue = new MesValue("最大值", "");
        public MesValue MinValue = new MesValue("最小值", "");
        public MesValue Unit = new MesValue("单位", "");
        public MesValue Grade = new MesValue("偏差等级", "");
        public MesValue IsMatch = new MesValue("是否丝印", "");
    }

    public class CheckInCode2 : MesIn
    {
        //上传
        public MesValue Code1 = new MesValue("条码1", "", true);
        public MesValue Code2 = new MesValue("条码2", "", true);
    }

    public class CheckOutCode2 : MesOut
    {

    }


    public class UpDataIn : MesIn
    {
        //上传
        public MesValue SplicTime = new MesValue("接料时间", "", true);
        public MesValue Barcode1 = new MesValue("条码1", "", true);
        public MesValue Barcode2 = new MesValue("条码2", "", true);
        public MesValue MaterialDes = new MesValue("物料描述", "", true);
        public MesValue LCRValueLeft = new MesValue("左测值", "", true);
        public MesValue LCRValueRight = new MesValue("右测值", "", true);
        public MesValue LCRResultLeft = new MesValue("左测值结果", "", true);
        public MesValue LCRResultRight = new MesValue("右测值结果", "", true);
        public MesValue MatchResult = new MesValue("丝印结果", "", true);
    }

    public class UpDataOut : MesOut
    {

    }

    public class HPIn
    {
        public List<HPDataIn> HPDatas { get; set; } = new List<HPDataIn>();

        /// <summary>
        /// 接料完成
        /// </summary>
        public bool IsSplicFinish = true;
        public void Clear()
        {
            HPDatas.Clear();
        }
        public void Add(HPDataIn hPData)
        {
            HPDatas.Add(hPData);
            if (HPDatas.Count > 1)
            {
                IsSplicFinish = false;
            }
            MesControl.Instance.ActionHPAdd?.Invoke(hPData);
            MesControl.Instance.Save();
        }

        public bool IsFinishHP()
        {
            return HPDatas.Count == 0;
        }

        public List<HPDataIn> GetDatas()
        {
            if (HPDatas.Count == 0)
            {
                IsSplicFinish = true;
            }
            return HPDatas;
        }

        public void Delete()
        {
            IsSplicFinish = true;
            if (HPDatas.Count == 0)
            {
                return;
            }
            HPDatas.RemoveAt(HPDatas.Count - 1);
            MesControl.Instance.ActionHPDelete?.Invoke();
        }

    }

    public class HPDataIn : MesIn
    {
        public MesValue BarCode = new MesValue("条码", "", true);
        public MesValue IsLCR = new MesValue("是否测值", "", true);
        public MesValue Type = new MesValue("类型", "", true);
        public MesValue Size = new MesValue("规格", "", true);
        public MesValue StandValue = new MesValue("标准值", "", true);
        public MesValue MaxValue = new MesValue("上限", "", true);
        public MesValue MinValue = new MesValue("下限", "", true);
        public MesValue Unit = new MesValue("单位", "", true);
        public MesValue LCRValue = new MesValue("测量值", "", true);
        public void GetValue(string key, out string value)
        {
            value = "";
            if (BarCode.Key == key)
            {
                value = BarCode.Value;
            }
            else if (IsLCR.Key == key)
            {
                value = IsLCR.Value;
            }
            else if (Type.Key == key)
            {
                value = Type.Value;
            }
            else if (Size.Key == key)
            {
                value = Size.Value;
            }
            else if (StandValue.Key == key)
            {
                value = StandValue.Value;
            }
            else if (MaxValue.Key == key)
            {
                value = MaxValue.Value;
            }
            else if (MinValue.Key == key)
            {
                value = MinValue.Value;
            }
            else if (Unit.Key == key)
            {
                value = Unit.Value;
            }
            else if (LCRValue.Key == key)
            {
                value = LCRValue.Value;
            }
            else if (InterFaceNo.Key == key)
            {
                value = InterFaceNo.Value;
            }
        }
    }

    public class HPDataOut : MesOut
    {
        public MesValue PN = new MesValue("PN", "", true);
        public MesValue Qty = new MesValue("QTY", "", true);
        public MesValue DateCode = new MesValue("DateCode", "", true);
        public MesValue LotCode = new MesValue("LotCode", "", true);
        public MesValue VENDOR = new MesValue("VENDOR", "", true);
    }

    public class MesValue
    {
        public MesValue(string name, string key, bool enable = false, string value = "")
        {
            Name = name;
            Key = key;
            Enable = enable;
            Value = value;
        }

        public void SetValue(MesValue mesValue)
        {
            if (Name == mesValue.Name)
            {
                Key = mesValue.Key;
                Enable = mesValue.Enable;
            }
        }

        public string Name { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public bool Enable;
    }

    /// <summary>
    /// XML协议
    /// </summary>
    public class XMLSoap
    {
        public MesValue XSI = new MesValue("XSI", "http://www.w3.org/2001/XMLSchema-instance", true);
        public MesValue XSD = new MesValue("XSD", "http://www.w3.org/2001/XMLSchema", true);
        public MesValue SOAP = new MesValue("SOAP", "http://schemas.xmlsoap.org/soap/envelope/", true);
        public MesValue IsCDATA = new MesValue("IsCDATA", "", false, "0");
    }

    #region mes对接
    /// <summary>
    /// WebApi
    /// </summary>
    public class WebApiHelper
    {
        public WebApiHelper()
        {

        }

        /// <summary>
        /// mes,Post
        /// </summary>
        /// <param name="url">接口地址</param>
        /// <param name="data">json字符串</param>
        /// <returns></returns>
        public string HttpPost(string url, string data)
        {
            try
            {
                Encoding encoding = Encoding.UTF8;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.Accept = "text/html, application/xhtml+xml, */*";
                request.ContentType = "application/json";

                byte[] buffer = encoding.GetBytes(data);
                request.ContentLength = buffer.Length;
                request.GetRequestStream().Write(buffer, 0, buffer.Length);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        /// <summary>
        /// Mes,Get
        /// </summary>
        /// <param name="url">接口地址</param>
        /// <param name="data">json字符串</param>
        /// <returns></returns>
        public string HttpGet(string url, string data)
        {
            try
            {
                Encoding encoding = Encoding.UTF8;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.Accept = "text/html, application/xhtml+xml, */*";
                request.ContentType = "application/json";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (Exception)
            {
                return "";
            }

        }

        /// <summary>
        /// Mes,Put
        /// </summary>
        /// <param name="url">接口地址</param>
        /// <param name="data">json字符串</param>
        /// <returns></returns>
        public string HttpPut(string url, string data)
        {
            try
            {
                Encoding encoding = Encoding.UTF8;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "PUT";
                request.Accept = "text/html, application/xhtml+xml, */*";
                request.ContentType = "application/json";

                byte[] buffer = encoding.GetBytes(data);
                request.ContentLength = buffer.Length;
                request.GetRequestStream().Write(buffer, 0, buffer.Length);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (Exception)
            {

                return "";
            }

        }

    }

    public class MesClientSocket
    {
        public MesClientSocket()
        {

        }

        /// <summary>
        /// 接收消息委托
        /// </summary>
        public static Action<string> OnReceive;
        static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        /// <summary>
        /// 连接服务端
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public static void ConnectService(string ip, int port)
        {
            //if (socket.Connected)
            //{
            //    return;
            //}
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket.Connect(ip, port);
                MesControl.Instance.Log("Connect Success" + ":IP=" + ip + ",port=" + port);
                //独立线程来接受来自服务端的数据
                Thread receive = new Thread(ClientReceive);
                receive.Start(socket);
            }
            catch (Exception ex)
            {
                MesControl.Instance.Log("Connect Fail" + ex.Message + ":IP=" + ip + ",port=" + port);
            }
        }
        /// <summary>
        /// 断开连接
        /// </summary>
        public static void DisConnect()
        {
            socket.Close();
        }

        static void ClientReceive(object so)
        {
            Socket MesClientSocket = so as Socket;
            while (true)
            {
                //Console.ForegroundColor = ConsoleColor.Green;  // 修改文字颜色为绿色
                try
                {
                    byte[] buffer = new byte[1024];
                    int len = MesClientSocket.Receive(buffer);
                    if (len > 0)
                    {
                        string msg = Encoding.UTF8.GetString(buffer);
                        //OnReceive?.Invoke(msg);
                        MesControl.Instance.AnalyData(msg);
                        MesClientSocket.Close();
                        break;
                    }
                }
                catch (Exception ex)
                {
                    MesControl.Instance.Log("Exception:" + ex.Message);
                    break;
                }
                Thread.Sleep(10);
            }
        }

        public static void ClientSendMsg(string msg)
        {
            try
            {
                if (socket.Connected)
                {
                    socket.Send(Encoding.UTF8.GetBytes(msg));
                }
            }
            catch (Exception ex)
            {
                MesControl.Instance.Log("Exception:" + ex.Message);
            }
        }

        public static bool IsConnect { get { return socket.Connected; } }
    }
    #endregion

}
