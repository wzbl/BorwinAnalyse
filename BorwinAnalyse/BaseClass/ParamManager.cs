﻿using Newtonsoft.Json;
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
        public ParamData System_机型 = new ParamData(ParamType.System, "机型", "1", "1:接料机,2:合盘机,3:CR机", "1");
        public ParamData System_条码 = new ParamData(ParamType.System, "条码", "0", "0不启用,1启用", "1");
        public ParamData System_测值 = new ParamData(ParamType.System, "测值", "0", "0不启用,1启用", "1");
        public ParamData System_找空料 = new ParamData(ParamType.System, "找空料", "0", "0不启用,1启用", "1");
        public ParamData System_丝印 = new ParamData(ParamType.System, "丝印", "0", "0不启用,1启用", "1");
        public ParamData System_BOM = new ParamData(ParamType.System, "BOM", "0", "0不启用,1启用", "1");
        public ParamData System_语音 = new ParamData(ParamType.System, "语音", "0", "0不启用,1启用", "1");
        #endregion

        #region 条码校验
        public ParamData 条码校验_是否二维码分割 = new ParamData(ParamType.CheckCode, "是否二维码分割", "0", "0不启用,1启用", "1");
        public ParamData 条码校验_分割符 = new ParamData(ParamType.CheckCode, "分割符", "-", "分割字符符号", "1");
        public ParamData 条码校验_索引位置 = new ParamData(ParamType.CheckCode, "索引位置", "0", "从0开始", "1");
        public ParamData 条码校验_是否删除前缀 = new ParamData(ParamType.CheckCode, "是否删除前缀", "0", "0不启用,1启用", "1");
        public ParamData 条码校验_删除前缀长度 = new ParamData(ParamType.CheckCode, "删除前缀长度", "0", "从1开始", "1");
        public ParamData 条码校验_是否删除后缀 = new ParamData(ParamType.CheckCode, "是否删除后缀", "0", "0不启用,1启用", "1");
        public ParamData 条码校验_删除后缀长度 = new ParamData(ParamType.CheckCode, "删除后缀长度", "0", "从1开始", "1");
        public ParamData 条码校验_是否字符替换 = new ParamData(ParamType.CheckCode, "是否字符替换", "0", "0不启用,1启用", "1");
        public ParamData 条码校验_原始字符 = new ParamData(ParamType.CheckCode, "原始字符", "A", "", "1");
        public ParamData 条码校验_替换为 = new ParamData(ParamType.CheckCode, "替换为", "B", "", "1");
        public ParamData 条码校验_是否字符大写 = new ParamData(ParamType.CheckCode, "是否字符大写", "0", "0不启用,1启用", "1");
        public ParamData 条码校验_是否设定条码长度 = new ParamData(ParamType.CheckCode, "是否设定条码长度", "0", "0不启用,1启用", "1");
        public ParamData 条码校验_条码长度 = new ParamData(ParamType.CheckCode, "设定条码长度", "10", "从1开始", "1");
        #endregion

        #region LCR
        public ParamData LCRSize = new ParamData(ParamType.LCR, "测值是否需要知道尺寸", "0", "0不启用,1启用");
        public ParamData LCR自动校准 = new ParamData(ParamType.LCR, "LCR自动校准", "0", "0不启用,1启用", "1");
        public ParamData LCR校准_只启动两线 = new ParamData(ParamType.LCR, "LCR自动校准只启用两线", "0", "0不启用,1启用", "1");

        public ParamData LCR偏差 = new ParamData(ParamType.LCR, "LCR差值", "2", "%");
        public ParamData 小电阻先测4线 = new ParamData(ParamType.LCR, "判断是否为小电阻", "10", "低于此值判断为小电阻,单位Ω");
        public ParamData Reel = new ParamData(ParamType.LCR, "料盘感应", "0", "1或者0");
        public ParamData TimerOut = new ParamData(ParamType.LCR, "测值超时", "2000", "电表反馈超时");
        public ParamData testing_delay = new ParamData(ParamType.LCR, "测试延时", "500", "ms");
        public ParamData testint_Count = new ParamData(ParamType.LCR, "测试次数", "6", "次数");
        public ParamData ContinuousTest = new ParamData(ParamType.LCR, "连续测试", "0", "0不启用,1启用");
        public ParamData R_Set_value = new ParamData(ParamType.LCR, "电阻标准设置", "200", "电阻单位Ω,K,M");
        public ParamData R_Set_Grade = new ParamData(ParamType.LCR, "电阻偏差设置", "F", "C%0.25,D%0.5,F%1,G%2,J%5,K%10,M%20,N%30");
        public ParamData C_Set_value = new ParamData(ParamType.LCR, "电容标准设置", "3", "电容单位pF,nF,uF,mF");
        public ParamData C_Set_Grade = new ParamData(ParamType.LCR, "电容偏差设置", "k", "C%0.25,D%0.5,F%1,G%2,J%5,K%10,M%20,N%30");

        public ParamData Type_now = new ParamData(ParamType.LCR, "当前补偿值", "0.06", "pF");
        public ParamData Rst_Test_mode = new ParamData(ParamType.LCR, "电阻测试模式", "RX", "RX   或者  DCR ");
        public ParamData Mim0_Value = new ParamData(ParamType.LCR, "0Ω参考值最小值", "2", "mΩ");
        public ParamData Max0_Value = new ParamData(ParamType.LCR, "0Ω参考值最大值", "8", "mΩ");

        public ParamData C_Deviation = new ParamData(ParamType.LCR, "电容误差放宽倍率(1.0至3.0)", "1.0", "电容误差放宽倍率(1.0至3.0)，1等于无任何补偿");
        public ParamData C_beginValue = new ParamData(ParamType.LCR, "电容误差放宽最小值（uf）", "1.0uf", "电容误差放宽最小值（uf）小于1uf的启用电容误差放宽倍率");
        public ParamData TestType = new ParamData(ParamType.LCR, "测试物料封装", "不检测", "测试物料封装");
        public ParamData Sliced_time = new ParamData(ParamType.LCR, "数据记录分割时间点", "18", "17-20之间的转班时间");

        public ParamData C_Scale1uF = new ParamData(ParamType.LCR, "针对1uF电容测值偏小启用是否放宽标准值下限", "0", "0 = 不启用，1 = 启用");
        public ParamData C_Deviation1uF = new ParamData(ParamType.LCR, "针对1uF电容测值偏小标准值下限误差放宽倍率(1.0至3.0)", "1.0", "1uF电容误差放宽倍率(1.0至3.0)，1.0等于无任何补偿【放大偏差等级  *请输入数值*】");
        public ParamData Clock_Now = new ParamData(ParamType.LCR, "当前测试频率", "10K", "");
        public ParamData Rlock_470 = new ParamData(ParamType.LCR, "电阻测试频率电阻小于470K", "1K", "0-470K");
        public ParamData Rlock_1 = new ParamData(ParamType.LCR, "电阻测试频率电阻小于1M", "100", "470K-1M");
        public ParamData Rlock_47 = new ParamData(ParamType.LCR, "电阻测试频率电阻小于4.7M", "100", "1M-4.7M");
        public ParamData Rlock_47D = new ParamData(ParamType.LCR, "电阻测试频率电阻大于4.7M", "50", "大于4.7M");

        public ParamData Clock_1 = new ParamData(ParamType.LCR, "电容测试频率电容小于1", "10K", "Hz_1pF");
        public ParamData Clock_10 = new ParamData(ParamType.LCR, "电容测试频率电容大于1", "10K", "Hz_1pF");
        public ParamData Clock_47 = new ParamData(ParamType.LCR, "电容测试频率电容大于47", "10K", "Hz_4.7pF");
        public ParamData Clock_470 = new ParamData(ParamType.LCR, "电容测试频率电容大于470", "10K", "Hz_47pF");
        public ParamData Clock_471 = new ParamData(ParamType.LCR, "电容测试频率电容大于471", "1K", "Hz_470pF");
        public ParamData Clock_472 = new ParamData(ParamType.LCR, "电容测试频率电容大于472", "1K", "Hz_4.7nF");
        public ParamData Clock_473 = new ParamData(ParamType.LCR, "电容测试频率电容大于473", "100", "Hz_47nF");
        public ParamData Clock_474 = new ParamData(ParamType.LCR, "电容测试频率电容大于474", "100", "Hz_470nF");
        public ParamData Clock_475 = new ParamData(ParamType.LCR, "电容测试频率电容大于475", "50", "Hz_4.7uF");
        public ParamData Clock_476 = new ParamData(ParamType.LCR, "电容测试频率电容大于476", "50", "Hz_47uF");
        public ParamData Clock_477 = new ParamData(ParamType.LCR, "电容测试频率电容大于477", "50", "Hz_470uF");
        public ParamData ReWriteV_Min = new ParamData(ParamType.LCR, "转换测试电压电容最小值uf", "1", "1_uF");
        public ParamData ReWriteV_Max = new ParamData(ParamType.LCR, "转换测试电压电容最大值uf", "1000", "1000_uF");
        #endregion

        #region 左LCR
        public ParamData IsLCR_Left = new ParamData(ParamType.Left_LCR, "左测值", "0", "0不启用,1启用", "1");
        #endregion

        #region 右LCR
        public ParamData IsLCR_Right = new ParamData(ParamType.Right_LCR, "右测值", "0", "0不启用,1启用", "1");
        #endregion

        #region 扫码枪
        public ParamData paramData8 = new ParamData(ParamType.Barcode_Scanner, "扫码枪", "2", "test", "1");
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
                    int.TryParse(paramData.paramLevel, out int lev);
                    if (paramData.paramType == paramType && lev <= (int)UserManager.Instance.CurrentUser.level + 1)
                    {
                        paramDatas.Add(paramData);
                    }
                }
            }
            return paramDatas;
        }

        public void UpData(string paramName, string paramValue, string level)
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
                        paramData.paramLevel = level;
                    }
                }
            }
        }

        /// <summary>
        /// 加载参数
        /// </summary>
        public void Load()
        {
            string savePath = @"Ini/ParamManager.json";
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
        public void Save()
        {
            string savePath = @"Ini/ParamManager.json";
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

        public ParamData(ParamType paramType, string paramName, string paramValue, string paramDescription, string paramLevel = "1")
        {
            this.paramType = paramType;
            this.paramName = paramName;
            this.paramValue = paramValue;
            this.paramDescription = paramDescription;
            this.paramLevel = paramLevel;
        }


        public double D
        {
            get
            {
                double.TryParse(paramValue, out double d);
                return d;
            }
        }

        public string S
        {
            get
            {

                return paramValue;
            }
        }

        public int I
        {
            get
            {
                int.TryParse(paramValue, out int i);
                return i;
            }
        }

        public bool B
        {
            get
            {
                bool.TryParse(paramValue, out bool b);
                if (int.TryParse(paramValue, out int i))
                {
                    b = i == 1 ? true : false;
                }
                return b;
            }
        }

    }

    /// <summary>
    /// 参数类别
    /// </summary>
    public enum ParamType
    {
        System,
        CheckCode,
        LCR,
        Left_LCR,
        Right_LCR,
        Barcode_Scanner
    }
}
