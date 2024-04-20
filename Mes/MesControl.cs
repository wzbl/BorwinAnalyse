using BorwinAnalyse.BaseClass;
using BorwinAnalyse.DataBase.Model;
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

        public string Line ="";
        public string MachineCode = "";
        public string Wo = "";
        public string UserName = "";

        public LoginIn loginIn = new LoginIn();
        public LoginOut loginOut = new LoginOut();
        public CheckInCode1 checkInCode1 = new CheckInCode1();
        public CheckOutCode1 checkOutCode1 = new CheckOutCode1();
        public CheckInCode2 checkInCode2 = new CheckInCode2();
        public CheckOutCode2 checkOutCode2 = new CheckOutCode2();
        public UpDataIn upDataIn = new UpDataIn();
        public UpDataOut upDataOut = new UpDataOut();

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
                    MesClientSocket.ClientSendMsg(json);
                    res = MesType.Socket.ToString();
                    break;
                case MesType.WebService:
                    break;
            }
            return res;
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
        public MesValue Line = new MesValue("线体", "", true);
        public MesValue MachineCode = new MesValue("设备代码", "", true);
        public MesValue Wo = new MesValue("工单单号", "", true);
        public MesValue UserName = new MesValue("用户名", "", true);
    }

    public class MesOut
    {
        //返回
        public MesValue Result = new MesValue("结果", "");
        public MesValue ErrorMsg = new MesValue("失败信息", "");
        public MesValue ErrorCode = new MesValue("失败代码", "");
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
        public MesValue MaxValue = new MesValue("最大值", "");
        public MesValue MinValue = new MesValue("最小值", "");
        public MesValue Unit = new MesValue("单位", "");
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


    public class MesValue
    {
        public MesValue(string name, string key, bool enable = false, string value = "")
        {
            Name = name;
            Key = key;
            Enable = enable;
            Value = value;
        }
        public string Name { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public bool Enable;
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
            if (socket.Connected)
            {
                return;
            }
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
                Console.ForegroundColor = ConsoleColor.Green;  // 修改文字颜色为绿色
                try
                {
                    byte[] buffer = new byte[1024];
                    int len = MesClientSocket.Receive(buffer);
                    if (len > 0)
                    {
                        string msg = Encoding.UTF8.GetString(buffer);
                        OnReceive?.Invoke(msg);
                    }
                }
                catch (Exception ex)
                {
                    MesControl.Instance.Log("Exception:" + ex.Message);
                    break;
                }
                Thread.Sleep(10);
            }
            MesClientSocket.Close();
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
                MesControl.Instance.Log("Exception:"+ex.Message);
            }
        }

        public static bool IsConnect { get { return socket.Connected; } }
    }
    #endregion

}
