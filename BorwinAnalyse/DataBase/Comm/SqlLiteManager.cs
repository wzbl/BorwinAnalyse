using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorwinAnalyse.DataBase.Comm
{

    public class SqlLiteManager
    {
        private static SqlLiteManager instance;

        public static SqlLiteManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new SqlLiteManager();
                return instance;
            }
            set => instance = value;
        }

        /// <summary>
        /// 初始化数据库
        /// </summary>
        public void Init()
        {
            InitData();
            InitTable();
        }

        /// <summary>
        /// 数据库对象
        /// </summary>
        public SQLConnect DB;

        private void InitData()
        {
            string DicPath = @"SqlLiteData";
            if (!Directory.Exists(DicPath))
            {
                Directory.CreateDirectory(DicPath);
            }
            if (!File.Exists(DicPath + "\\AnalyseData.db"))
            {
                DB = new SQLConnect(DicPath + "\\AnalyseData.db");
                DB.NewDbFile(DicPath + "\\AnalyseData.db");
            }
            if (DB == null)
            {
                DB = new SQLConnect(DicPath + "\\AnalyseData.db");
            }
        }

        private void InitTable()
        {
            string tableName = "BOM";
            string commandText = "CREATE TABLE IF NOT EXISTS " + tableName + "(id varchar PRIMARY KEY,barCode varchar, description varchar,status int,type varchar,size varchar,value varchar,unit varchar,grade varchar,exp1 varchar,exp2 varchar,exp3 varchar,exp4 varchar,exp5 varchar,createTime datetime)";
            DB.NewTable(commandText);


            string tableName2 = "Language";
            string commandText2 = "CREATE TABLE IF NOT EXISTS " + tableName2 + "(context varchar PRIMARY KEY,chinese varchar, english varchar,exp1 varchar,exp2 varchar,exp3 varchar,exp4 varchar,exp5 varchar,createTime datetime)";
            DB.NewTable(commandText2);
        }
    }
}
