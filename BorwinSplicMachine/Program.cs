using BorwinAnalyse.BaseClass;
using BorwinAnalyse.DataBase.Comm;
using BorwinAnalyse.Forms;
using LibSDK;
using LibSDK.Motion;
using Mes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml;

namespace BorwinSplicMachine
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SqlLiteManager.Instance.Init();
            //http();
            MainControl.Log("打开程序");
            CommonAnalyse.Instance.Load();
            BomManager.Instance.Init();
            MesControl.Instance.Load();
            MotionControl.Init();
            DataTable dataTable = LanguageManager.Instance.SearchALLLanguageType();
            ParamManager.Instance.Load();
            if (dataTable == null) { return; }
            if (dataTable.Rows.Count > 0)
            {
                int lang = int.Parse(dataTable.Rows[0].ItemArray[1].ToString());
                LanguageManager.Instance.CurrenIndex = lang;
            }
            //Application.Run(new MotionConfig());
            Application.Run(new Form1());
            //Application.Run(new AnalyseMainForm());
        }

        public static void http()
        {
           
            Encoding encoding = Encoding.ASCII;
           
            string data = JsonConvert.SerializeObject(new Teee());
     
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://183.62.165.125:9812/MESService.asmx/VendorDeliveryHandle?HandleParameter=" + "{\"HandleType\":\"HandleType_MaterialQuery\",\"LotSN\":\"WMLOT24012400260\"}"); 
            request.Method = "GET";
            request.Accept = "text/html, application/xhtml+xml, */*";
            //request.ContentType = "application/json";
            request.ContentType = "application/x-www-form-urlencoded";
            //byte[] buffer = encoding.GetBytes("HandleParameter="+data);
            //request.ContentLength = buffer.Length;
            //request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
               string s = reader.ReadToEnd();
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(s);
                string v = xmlDocument.InnerText;
            }
        }

        public class Teee
        {
            public string HandleType = "HandleType_MaterialQuery";
             public string LotSN = "WMLOT24012400260";
        }

    }
}
