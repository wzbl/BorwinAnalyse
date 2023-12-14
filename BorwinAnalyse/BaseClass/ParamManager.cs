using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BorwinAnalyse.BaseClass
{
    /// <summary>
    /// 参数管理
    /// </summary>
    public class ParamManager
    {
        private static ParamManager instance;
        public static ParamManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ParamManager();
                }
                return instance;
            }
        }

        #region System
        public ParamData paramData1 = new ParamData(ParamType.System, "系统", "2", "test", "1");
        #endregion

        #region LCR
        public ParamData paramData2 = new ParamData(ParamType.LCR, "测值", "2", "test", "1");
        #endregion

        #region 左LCR
        public ParamData paramData3 = new ParamData(ParamType.Left_LCR, "左测值", "2", "test", "1");
        #endregion

        #region 右LCR
        public ParamData paramData4 = new ParamData(ParamType.Right_LCR, "右测值", "2", "test", "1");
        #endregion

        #region 相机
        public ParamData paramData5 = new ParamData(ParamType.CCD, "CCD", "2", "视觉", "1");
        #endregion

        #region 左相机
        public ParamData paramData6 = new ParamData(ParamType.Left_CCD, "左视觉", "2", "test", "1");
        #endregion

        #region 右相机
        public ParamData paramData7 = new ParamData(ParamType.Right_CCD, "右视觉", "2", "test", "1");
        #endregion

        #region 扫码枪
        public ParamData paramData8 = new ParamData(ParamType.Barcode_Scanner, "扫码枪", "2", "test", "1");
        #endregion

        #region PLC
        public ParamData paramData9 = new ParamData(ParamType.PLC, "PLC", "2", "test", "1");
        #endregion


        public List<ParamData> SearchData(ParamType paramType)
        {
            List<ParamData> paramDatas = new List<ParamData>();
            FieldInfo[] props = typeof(ParamManager).GetFields();
            foreach (var item in props)
            {
                Type type = item.FieldType;
                if (type.Name == typeof(ParamData).Name)
                {
                    ParamData paramData = item.GetValue(this) as ParamData;

                    if (paramData.paramType== paramType)
                    {
                        paramDatas.Add(paramData);
                    }
                }
            }
            return paramDatas;
        }

        public void UpData(string paramName, string paramValue)
        {
            FieldInfo[] props = typeof(ParamManager).GetFields();
            foreach (var item in props)
            {
                Type type = item.FieldType;
                if (type.Name == typeof(ParamData).Name)
                {
                    ParamData paramData = item.GetValue(this) as ParamData;

                    if (paramData.paramName.tr() == paramName)
                    {
                        paramData.paramValue = paramValue;
                    }
                }
            }
        }

        /// <summary>
        /// 加载参数
        /// </summary>
        public void LoadParam()
        {
            string savePath = @"SqlLiteData/ParamManager.json";
            if (!File.Exists(savePath))
            {
                FileStream fs1 = new FileStream(savePath, FileMode.Create, FileAccess.ReadWrite);
                fs1.Close();
            }
            else
            {
                instance = JsonConvert.DeserializeObject<ParamManager>(File.ReadAllText(savePath));
            }
        }

        /// <summary>
        /// 保存参数
        /// </summary>
        public void SaveParam()
        {
            string savePath = @"SqlLiteData/ParamManager.json";
            if (!File.Exists(savePath))
            {
                FileStream fs1 = new FileStream(savePath, FileMode.Create, FileAccess.ReadWrite);
                fs1.Close();
            }
            File.WriteAllText(savePath, JsonConvert.SerializeObject(instance));
        }
    }

    /// <summary>
    /// 参数实体
    /// </summary>
    public class ParamData
    {
        /// <summary>
        /// 参数类型
        /// </summary>
        public ParamType paramType { get; set; }
        /// <summary>
        /// 参数名称
        /// </summary>
        public string paramName { get; set; }
        /// <summary>
        /// 参数值
        /// </summary>
        public string paramValue { get; set; }
        /// <summary>
        /// 参数描述
        /// </summary>
        public string paramDescription { get; set; }
        /// <summary>
        /// 参数等级
        /// </summary>
        public string paramLevel { get; set; }

        public ParamData() { }

        public ParamData(ParamType paramType, string paramName, string paramValue, string paramDescription, string paramLevel)
        {
            this.paramType = paramType;
            this.paramName = paramName;
            this.paramValue = paramValue;
            this.paramDescription = paramDescription;
            this.paramLevel = paramLevel;
        }

    }

    /// <summary>
    /// 参数类别
    /// </summary>
    public enum ParamType
    {
        System,
        LCR,
        Left_LCR,
        Right_LCR,
        CCD,
        Left_CCD,
        Right_CCD,
        Barcode_Scanner,
        PLC
    }
}
