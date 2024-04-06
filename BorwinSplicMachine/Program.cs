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

            //强制关闭进程    
            //string exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            //string[] exeArray = exeName.Split('\\');
            //RunCmd("taskkill /im " + exeArray[exeArray.Length - 1] + " /f ");
        }

        /// <summary>
        /// 运行DOS命令
        /// DOS关闭进程命令(ntsd -c q -p PID )PID为进程的ID
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static string RunCmd(string command)
        {
            //實例一個Process類，啟動一個獨立進程
            System.Diagnostics.Process p = new System.Diagnostics.Process();

            //Process類有一個StartInfo屬性，這個是ProcessStartInfo類，包括了一些屬性和方法，下面我們用到了他的幾個屬性：

            p.StartInfo.FileName = "cmd.exe";           //設定程序名
            p.StartInfo.Arguments = "/c " + command;    //設定程式執行參數
            p.StartInfo.UseShellExecute = false;        //關閉Shell的使用
            p.StartInfo.RedirectStandardInput = true;   //重定向標準輸入
            p.StartInfo.RedirectStandardOutput = true;  //重定向標準輸出
            p.StartInfo.RedirectStandardError = true;   //重定向錯誤輸出
            p.StartInfo.CreateNoWindow = true;          //設置不顯示窗口

            p.Start();   //啟動

            //p.StandardInput.WriteLine(command);       //也可以用這種方式輸入要執行的命令
            //p.StandardInput.WriteLine("exit");        //不過要記得加上Exit要不然下一行程式執行的時候會當機

            return p.StandardOutput.ReadToEnd();        //從輸出流取得命令執行結果

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
