using BorwinAnalyse.DataBase.Comm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorwinAnalyse.BaseClass
{
    public class LanguageManager
    {
        private static LanguageManager instance;
        public static LanguageManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LanguageManager();
                }
                return instance;
            }
        }
    }
    public static class LanHelper
    {
        public static string tr(this string str)
        {
            if (str == null)
            {
                return str;
            }
            string comms = string.Format("select * from Language where context = '{0}' ", str);
            var res =  SqlLiteManager.Instance.DB.Search(comms, "Language");
            if (res == null|| res.Rows.Count==0)
            {
                string comm = string.Format("insert into Language values('{0}','{1}','','','','','','','{2}')",str,str,DateTime.Now.ToString("yyyy-MM-dd H:m:s"));
                SqlLiteManager.Instance.DB.Insert(comm);
            }
            else
            {

            }
           return str;
        }
    }
}
