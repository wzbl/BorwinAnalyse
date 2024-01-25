using BorwinAnalyse.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorwinAnalyse.DataBase.Model
{
    public class LogModel
    {
        public string Time {  get; set; }  
        public string Type { get; set; }
        public string Content { get; set; }
        public string Operator { get; set; }
        public string exp1 { get; set; }
        public string exp2 { get; set; }
        public string exp3 { get; set; }
        public string exp4 { get; set; }
        public string exp5 { get; set; }
        public LogModel() { }

        public LogModel(LogType type, string content, string Oper ="default", string exp1="", string exp2 = "", string exp3 = "", string exp4 = "", string exp5="")
        {
            Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Type = type.ToString();
            Content = content;
            Operator = Oper;
            this.exp1 = exp1;
            this.exp2 = exp2;
            this.exp3 = exp3;
            this.exp4 = exp4;
            this.exp5 = exp5;
        }
    }

    public enum LogType
    {
        操作日志,
        扫码日志,
        测值日志,
        相机日志,
        运动控制日志
    }
}
