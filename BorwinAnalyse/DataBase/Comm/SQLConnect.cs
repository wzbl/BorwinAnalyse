using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorwinAnalyse.DataBase.Comm
{
    public class SQLConnect
    {
        private SQLiteConnection _SQLiteConn = null;     //连接对象
        private SQLiteTransaction _SQLiteTrans = null;   //事务对象
        private string _SQLiteConnString = null; //连接字符串
        private bool _AutoCommit = false; //事务自动提交标识

        public string SQLiteConnString
        {
            set { this._SQLiteConnString = value; }
            get { return this._SQLiteConnString; }
        }

        public SQLConnect(string dbPath)
        {
            this._SQLiteConnString = "Data Source=" + dbPath;
        }

        /// <summary>
        /// 新建数据库文件
        /// </summary>
        /// <param name="dbPath">数据库文件路径及名称</param>
        /// <returns>新建成功，返回true，否则返回false</returns>
        public Boolean NewDbFile(string dbPath)
        {
            try
            {
                SQLiteConnection.CreateFile(dbPath);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("新建数据库文件" + dbPath + "失败：" + ex.Message);
            }
        }


        /// <summary>
        /// 创建表
        /// </summary>
        /// <param name="dbPath">指定数据库文件</param>
        /// <param name="tableName">表名称</param>
        public void NewTable(string CommandText)
        {

            SQLiteConnection sqliteConn = new SQLiteConnection(this._SQLiteConnString);
            if (sqliteConn.State != System.Data.ConnectionState.Open)
            {
                sqliteConn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = sqliteConn;
                cmd.CommandText = CommandText;
                cmd.ExecuteNonQuery();
            }
            sqliteConn.Close();
        }

        public bool Insert(string CommandText)
        {
            try
            {
                SQLiteConnection sqliteConn = new SQLiteConnection(this._SQLiteConnString);
                if (sqliteConn.State != System.Data.ConnectionState.Open)
                {
                    sqliteConn.Open();
                    SQLiteCommand cmd = new SQLiteCommand();
                    cmd.Connection = sqliteConn;
                    cmd.CommandText = CommandText;
                    cmd.ExecuteNonQuery();
                }
                sqliteConn.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataTable Search(string CommandText,string table)
        {
            try
            {
                DataTable dt = new DataTable();
                SQLiteConnection sqliteConn = new SQLiteConnection(this._SQLiteConnString);
                if (sqliteConn.State != System.Data.ConnectionState.Open)
                {
                    sqliteConn.Open();
                    SQLiteCommand cmd = new SQLiteCommand( CommandText, sqliteConn);
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, table);
                    return ds.Tables[0];
                }
                sqliteConn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
