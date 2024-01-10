using BorwinAnalyse.BaseClass;
using BorwinAnalyse.DataBase.Comm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            CommonAnalyse.Instance.Load();
            BomManager.Instance.Init();
            DataTable dataTable = LanguageManager.Instance.SearchALLLanguageType();
            if (dataTable == null) { return; }
            
            if (dataTable.Rows.Count > 0)
            {
                int lang = int.Parse(dataTable.Rows[0].ItemArray[1].ToString());
                LanguageManager.Instance.CurrenIndex = lang;
            }
            Application.Run(new Form1());
        }

    }
}
