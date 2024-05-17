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
        [NonSerialized]
        public User CurrentUser = null;

        public void Load()
        {
            string path = @"Ini/UserMessage.dt";
            if (File.Exists(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    BinaryReader read = new BinaryReader(fs);
                    while (fs.Length > fs.Position + 4)
                    {
                        User user = new User();
                        user.EmpNo = read.ReadString();
                        user.name = read.ReadString();
                        user.pass = read.ReadString();
                        user.level = (Level)read.ReadInt32();
                        users.Add(user);
                    }
                    read.Close();
                    fs.Close();
                }
            }

        }

        public void Save()
        {
            string path = @"Ini/UserMessage.dt";
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                BinaryWriter write = new BinaryWriter(fs);
                foreach (User user in users)
                {
                    write.Write((string)user.EmpNo);
                    write.Write((string)user.name);
                    write.Write((string)user.pass);
                    write.Write((int)user.level);
                    write.Flush();
                }
                write.Close();
                fs.Close();
            }

        }

        public void LoadJson()
        {
            string savePath = @"Ini/User.dt";
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

        public void SaveJson()
        {
            string savePath = @"Ini/User.dt";
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
        public string EmpNo;
        public string name;
        public string pass;
        public Level level;
    }

    public enum Level
    {
        Oprator,//操作员
        Technician,//操作员
        Engineer,//工程师
        Admin//管理员
    }
}
