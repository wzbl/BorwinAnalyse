using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace BorwinAnalyse.BaseClass
{
    /// <summary>
    /// BOM解析类
    /// </summary>
    public class CommonAnalyse
    {
        private static CommonAnalyse instance;
        public static CommonAnalyse Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CommonAnalyse();
                }
                return instance;
            }
        }

        public CommonAnalyse()
        {


        }

        public List<Separator> Separators = new List<Separator>();

        public List<SubstitutionRules> SubstitutionRules = new List<SubstitutionRules>();

        public void Load()
        {
            string savePath = @"SqlLiteData/CommonAnalyse.json";
            if (!File.Exists(savePath))
            {
                FileStream fs1 = new FileStream(savePath, FileMode.Create, FileAccess.ReadWrite);
                fs1.Close();
            }
            else
            {
                instance = JsonConvert.DeserializeObject<CommonAnalyse>(File.ReadAllText(savePath));
            }
        }
        public void Save()
        {
            string savePath = @"SqlLiteData/CommonAnalyse.json";
            if (!File.Exists(savePath))
            {
                FileStream fs1 = new FileStream(savePath, FileMode.Create, FileAccess.ReadWrite);
                fs1.Close();
            }
            File.WriteAllText(savePath, JsonConvert.SerializeObject(instance));
        }

        /// <summary>
        /// 解析入口
        /// </summary>
        /// <param name="description">解析字符</param>
        public void AnalyseMethod(string description)
        {
            AnalyseResult analyseResult = new AnalyseResult();
        }

    }

    /// <summary>
    /// 分隔符定义
    /// </summary>
    [Serializable]
    public class Separator
    {
        /// <summary>
        /// 是否可用
        /// </summary>
        public bool Enable = false;

        /// <summary>
        /// Asc码
        /// </summary>
        public string Acsii = "";

        /// <summary>
        /// 说明
        /// </summary>
        public string Illustrate = "";
    }

    /// <summary>
    /// 替换规则
    /// </summary>
    [Serializable]
    public class SubstitutionRules
    {
        /// <summary>
        /// 是否可用
        /// </summary>
        public bool Enable = false;

        /// <summary>
        /// 查找内容
        /// </summary>
        public string FindContent = "";

        /// <summary>
        /// 替换
        /// </summary>
        public string Replace = "";

        /// <summary>
        /// 是否区分大小写
        /// </summary>
        public bool Is_Case_sensitive = false;

        /// <summary>
        /// 是否区分全半角
        /// </summary>
        public bool Is_Full_half_width = false;

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark = "";
    }

    public class SerializeHelper
    {
        public static bool SerializeXml(string path, object obj)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    XmlSerializer serializer = new XmlSerializer(obj.GetType());
                    serializer.Serialize(fs, obj);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("序列化错误：" + ex.Message, "错误");
                return false;
            }
        }
        public static T DeserializeXml<T>(string path) where T : class
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    object obj = serializer.Deserialize(fs);
                    return obj as T;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("反序列化错误：" + ex.Message, "错误");
                return null;
            }
        }
    }


    public sealed class AnalyseResult
    {
        public bool Result = false;

        /// <summary>
        /// 宽度
        /// </summary>
        public string Width { get; set; } = string.Empty;

        /// <summary>
        /// 间距
        /// </summary>
        public string Space { get; set; } = string.Empty;

        public LCRItem LcrItem { get; set; } = new LCRItem();
    }

    /// <summary>
    /// Bom解析内容
    /// </summary>
    public sealed class LCRItem
    {
        public string Type { get; set; } = "Other";
        public string Size { get; set; } = "Error";
        public string Value { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        public string Grade { get; set; } = string.Empty;

        public string DefaultFormat()
        {
            return $"{Type}-{Size}-{Value}-{Unit}-{Grade}";
        }

        public void Clear()
        {
            Type = "Other";
            Size = "Error";
            Value = string.Empty;
            Unit = string.Empty;
            Grade = string.Empty;
        }

        public override string ToString()
        {
            return "类型".tr() + ":" + Type + "规格".tr() + ":" + Size + " 标准值".tr() + ":" + Value + "单位".tr() + ":" + Unit + " 等级".tr() + ":" + Grade;
        }
    }
}
