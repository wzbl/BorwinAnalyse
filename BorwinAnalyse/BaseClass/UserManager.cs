using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorwinAnalyse.BaseClass
{
    public class UserManager
    {
        private static UserManager instance;
        public static UserManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserManager();
                }
                return instance;
            }
        }

        public List<User> users = new List<User>();

        public User CurrentUser;

        public void Load()
        {
            string savePath = @"Ini/User.json";
            if (!File.Exists(savePath))
            {
                FileStream fs1 = new FileStream(savePath, FileMode.Create, FileAccess.ReadWrite);
                fs1.Close();
            }
            else
            {
                instance = Newtonsoft.Json.JsonConvert.DeserializeObject<UserManager>(File.ReadAllText(savePath));
            }
        }

        public void Save()
        {
            string savePath = @"Ini/User.json";
            if (!File.Exists(savePath))
            {
                FileStream fs1 = new FileStream(savePath, FileMode.Create, FileAccess.ReadWrite);
                fs1.Close();
            }
            File.WriteAllText(savePath, Newtonsoft.Json.JsonConvert.SerializeObject(instance));
        }
    }

    public class User
    {
        public Level level;
        public string name;
        public string pass;
    }

    public enum Level
    {
        Normal,//无
        oprator,//操作员
        admin, //管理员
        engineer//工程师
    }
}
