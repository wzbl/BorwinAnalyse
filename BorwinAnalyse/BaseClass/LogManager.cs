using BorwinAnalyse.DataBase.Comm;
using BorwinAnalyse.DataBase.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorwinAnalyse.BaseClass
{
    public class LogManager
    {
        private static LogManager instance;
        public static LogManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LogManager();
                }
                return instance;
            }
        }

        public List<LogModel> SearchByTime(DateTime startTime, DateTime endTime)
        {
            string startT = startTime.ToString("yyyy-MM-dd HH:mm:ss");
            string endT = endTime.ToString("yyyy-MM-dd HH:mm:ss");
            List<LogModel> logModels = new List<LogModel>();
            string comm = string.Format("select time,type,content,operator from Log where time between '{0}' and '{1}' ", startT, endT);
            DataTable dataTable = SqlLiteManager.Instance.DB.Search(comm, "Log");
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    LogModel logModel = new LogModel();
                    logModel.Time = ((DateTime)dataTable.Rows[i].ItemArray[0]).ToString("yyyy-MM-dd HH:mm:ss");
                    logModel.Type = dataTable.Rows[i].ItemArray[1].ToString();
                    logModel.Content = dataTable.Rows[i].ItemArray[2].ToString();
                    logModel.Operator = dataTable.Rows[i].ItemArray[3].ToString();
                    logModels.Add(logModel);
                }
            }
            return logModels;
        }


        public List<LogModel> SearchByType(DateTime startTime, DateTime endTime, string type)
        {
            string startT = startTime.ToString("yyyy-MM-dd HH:mm:ss");
            string endT = endTime.ToString("yyyy-MM-dd HH:mm:ss");
            List<LogModel> logModels = new List<LogModel>();
            string comm = string.Format("select time,type,content,operator from Log where time between '{0}' and '{1}' and type='{2}' ", startT, endT, type);
            DataTable dataTable = SqlLiteManager.Instance.DB.Search(comm, "Log");
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    LogModel logModel = new LogModel();
                    logModel.Time = ((DateTime)dataTable.Rows[i].ItemArray[0]).ToString("yyyy-MM-dd HH:mm:ss");
                    logModel.Type = dataTable.Rows[i].ItemArray[1].ToString();
                    logModel.Content = dataTable.Rows[i].ItemArray[2].ToString();
                    logModel.Operator = dataTable.Rows[i].ItemArray[3].ToString();
                    logModels.Add(logModel);
                }
            }
            return logModels;
        }

        public void WriteLog(LogModel logModel)
        {
            string log = string.Format("[{0}][{1}]:{2}", logModel.Time, logModel.Type, logModel.Content);
            LogMsg?.Invoke(log);
            Log(log);
            string comm = string.Format("insert into Log values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", logModel.Time, logModel.Type, logModel.Content, logModel.Operator, logModel.exp1, logModel.exp2, logModel.exp3, logModel.exp4, logModel.exp5);
            SqlLiteManager.Instance.DB.Insert(comm);
        }

        /// <summary>
        /// 日志
        /// </summary>
        /// <param name="message"></param>
        public void Log(string message)
        {
            if (!message.Contains("\r\n"))
            {
                message = message + "\r\n";
            }
            string dic = Application.StartupPath + "\\Log\\" + DateTime.Now.ToString("yyyy-MM");
            if (!Directory.Exists(dic))
            {
                Directory.CreateDirectory(dic);
            }

            string file = dic + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            if (!File.Exists(file))
            {
                FileStream fs = new FileStream(file, FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(fs);
                sw.Close();
            }

            using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.BaseStream.Seek(0, SeekOrigin.End);
                    sw.Write(message);
                    sw.Flush();
                }
            }

        }

        public Action<string> LogMsg;
    }
}
