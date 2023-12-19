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
using System.Text.RegularExpressions;
using NPOI.Util;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;
using NPOI.SS.Formula.Functions;

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

        /// <summary>
        /// 是否启用字符分割
        /// </summary>
        public bool IsSeparator = false;
        public List<Separator> Separators = new List<Separator>();

        /// <summary>
        /// 是否启用字符替换
        /// </summary>
        public bool IsSubstitutionRules = false;
        public List<SubstitutionRules> SubstitutionRules = new List<SubstitutionRules>();

        public List<GradeChange> GradeChanges = new List<GradeChange>();

        /// <summary>
        /// 电阻
        /// </summary>
        public string Resistance = "resistance,RES";
        /// <summary>
        /// 电容
        /// </summary>
        public string Capacitance = "capacitance,CAP";

        /// <summary>
        /// 电阻单位
        /// </summary>
        public string ResistanceUnit = "MΩ,KΩ,Ω,M,K,R,HΩ";

        /// <summary>
        /// 电容单位
        /// </summary>
        public string CapacitanceUnit = "PF,NF,UF,P,N,U";

        /// <summary>
        /// 元件规格
        /// </summary>
        public string ComponentSpecifications = "01005,0201,0402,0603,0805,1010,1206,1210,2010";



        /// <summary>
        /// 是否删除字符
        /// </summary>
        public bool IsDeleteString = false;

        /// <summary>
        /// 删除前缀数
        /// </summary>
        public int PrefixNumber = 0;

        /// <summary>
        /// 删除后缀数
        /// </summary>
        public int SuffixNumber = 0;

        /// <summary>
        /// 是否启用在中间的单位((如4R7=4.7Ω 4K7=4.7KΩ) 电容中间R代表.(如0R5=0.5PF))
        /// </summary>
        public bool IsIntermediateUnit = false;

        /// <summary>
        /// 启用偏差等级(未找到时使用)
        /// </summary>
        public bool IsGrade_ON_NO_Find = false;
        public string ResGrade_ON_NO_Find = "0%";
        public string CapGrade_ON_NO_Find = "0%";

        //string s_Grade = "CDFGJKMN";

        /// <summary>
        /// 是否启用值包含偏差等级
        /// </summary>
        public bool IsValueContainsGrade = false;

        /// <summary>
        /// 识别数码法
        /// </summary>
        public bool IsIdentifyingDigits = false;

        /// <summary>
        /// 启用默认电阻单位
        /// </summary>
        public bool IsResDefaultUnit = false;

        /// <summary>
        /// 默认电阻单位
        /// </summary>
        public string ResDefaultUnit = "Ω";




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
        public AnalyseResult AnalyseMethod(string description)
        {
            AnalyseResult analyseResult = new AnalyseResult();
            List<string> specList = new List<string>(); //分隔符处理后
            string LCR_Type = "";
            if (IsDeleteString)
            {
                description = RemoveLeft(description, PrefixNumber);
                description = RemoveRight(description, SuffixNumber);
            }

            if (IsSubstitutionRules)
            {
                SubstitutionRule(ref description);
            }

            if (IsSeparator)
            {
                specList = Separator(description);
            }

            GetType(description, ref analyseResult, ref LCR_Type);
            if (analyseResult.Type == "Other") return analyseResult;

            GetSize(description, ref analyseResult);
            if (analyseResult.Size == "Error") return analyseResult;

            var gradeResult = specList.Where("CDFGJKMN".Contains).ToList();
            if (gradeResult?.Count > 0)
                analyseResult.Grade = gradeResult[0];

            if (string.IsNullOrEmpty(analyseResult.Grade))
            {
                string textValue = string.Empty;
                for (int i = 0; i < specList?.Count; i++)
                {
                    textValue = specList[i];
                    if (textValue.StartsWith("%"))
                    {
                        if (textValue.EndsWith("%"))
                        {
                            analyseResult.Grade = Regex.Replace(textValue, @"[^\d.\d]", "") + "%";
                        }
                        else
                        {
                            string tempGrade = Regex.Replace(textValue, @"[^0-9.]", "");
                            if (IsNumeric(tempGrade))
                            {
                                analyseResult.Grade = tempGrade + "%";
                            }
                            else
                            {
                                analyseResult.Grade = tempGrade;
                            }
                        }
                        break;
                    }
                    else if (textValue.Contains("%"))
                    {
                        analyseResult.Grade = TheGrade(textValue);
                        break;
                    }
                    if (string.IsNullOrEmpty(analyseResult.Grade) && IsValueGrade(textValue))
                    {
                        if (IsValueContainsGrade)
                        {
                            Regex r = new Regex(@"[a-zA-Z]+");
                            System.Text.RegularExpressions.Match m = r.Match(textValue);
                            string grade = m.Value;
                            if (!string.IsNullOrEmpty(grade))
                            {
                                analyseResult.Grade = grade;
                                textValue = textValue.Replace(grade, "");
                                if (textValue.Length == 3 && IsNumeric(textValue))
                                {
                                    int v1 = int.Parse(textValue.Substring(0, 2));
                                    int v2 = int.Parse(textValue.Substring(2, 1));
                                    double val = v1 * Math.Pow(10, v2);
                                    textValue = val.ToString();
                                }
                                analyseResult.Value = textValue;
                                //analyseResult.Unit = "P";
                                analyseResult.Check();
                                //如果值不为空
                                if (analyseResult.Result)
                                {
                                    return analyseResult;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                string textValue = string.Empty;
                for (int i = 0; i < specList?.Count; i++)
                {
                    textValue = specList[i];
                    if (textValue.StartsWith("%"))
                    {
                        if (textValue.EndsWith("%"))
                        {
                            analyseResult.Grade = Regex.Replace(textValue, @"[^\d.\d]", "") + "%";
                        }
                        else
                        {
                            string tempGrade = Regex.Replace(textValue, @"[^0-9.]", "");
                            //string tempGrade = textValue.TrimStart('%');
                            if (IsNumeric(tempGrade))
                            {
                                analyseResult.Grade = tempGrade + "%";
                            }
                            else
                            {
                                analyseResult.Grade = tempGrade;
                            }
                        }
                        break;
                    }
                    else if (textValue.Contains("%"))
                    {
                        analyseResult.Grade = TheGrade(textValue);
                        break;
                    }
                }
            }

            //未找到偏差等级是否启用自定义
            if (string.IsNullOrEmpty(analyseResult.Grade) && IsGrade_ON_NO_Find)
            {
                if (analyseResult.Type == "电阻".tr())
                {
                    analyseResult.Grade = ResGrade_ON_NO_Find;
                }
                else if (analyseResult.Type == "电容".tr())
                {
                    analyseResult.Grade = CapGrade_ON_NO_Find;
                }
            }

            //去掉物料类型
            var typeList = specList.Where(u => u.Contains(LCR_Type)).ToList();
            foreach (var item in typeList)
            {
                specList.Remove(item);
            }
            //去掉包含规格项
            var sizeIndexList = specList.Where(u => u.Contains(analyseResult.Size)).ToList();
            foreach (var item in sizeIndexList)
            {
                specList.Remove(item);
            }
            //去掉包含偏差等级项
            if (!string.IsNullOrEmpty(analyseResult.Grade))
            {
                specList.Remove(analyseResult.Grade);
            }

            //找到可能包含值得项
            List<string> listValue = new List<string>();
            foreach (var item in specList)
            {
                if (Regex.IsMatch(item.Trim(), "^[0-9].*[A-Za-z0-9.]*$"))//修改正则表达式，当为0的时候匹配失败
                {

                    listValue.Add(item);
                }
            }

            if (listValue.Count > 0)//找到多个待处理
            {
                if (analyseResult.Type == "电阻".tr())
                {
                    //通过单位分割
                    analyseResult.Unit = "";
                    for (int i = 0; i < listValue.Count; i++)
                    {
                        string textValue = listValue[i];
                        var unitList = ResistanceUnit.Split(',').Where(textValue.Contains).ToList();
                        if (unitList?.Count > 0)
                        {
                            analyseResult.Unit = TheLongestName(unitList.ToArray());
                            //提取值
                            string[] valueArray = textValue.Split(analyseResult.Unit.ToCharArray()[0]);

                            if (valueArray.Length == 2 && string.IsNullOrEmpty(valueArray[1]))
                            {
                                analyseResult.Value = valueArray[0];
                            }
                            else if (valueArray.Length == 2 && !string.IsNullOrEmpty(valueArray[1]))
                            {
                                if (IsInt(valueArray[1]))
                                {
                                    analyseResult.Value = textValue.Replace(analyseResult.Unit.ToCharArray()[0], '.');
                                }
                                else
                                {
                                    analyseResult.Value = valueArray[0];
                                }
                            }
                            break;
                        }
                    }
                }
                else if (analyseResult.Type == "电容".tr())
                {
                    //通过单位分割
                    analyseResult.Unit = "";
                    for (int i = 0; i < listValue.Count; i++)
                    {
                        string textValue = listValue[i];
                        var unitList = CapacitanceUnit.ToUpper().Split(',').Where(textValue.ToUpper().Contains).ToList();
                        if (unitList?.Count > 0)
                        {
                            //找出最长
                            analyseResult.Unit = TheLongestName(unitList.ToArray());
                            //提取值
                            string[] valueArray = textValue.ToUpper().Split(analyseResult.Unit.ToCharArray()[0]);
                            if (valueArray.Length == 2 && string.IsNullOrEmpty(valueArray[1]))
                            {
                                analyseResult.Value = valueArray[0];
                            }
                            else if (valueArray.Length == 2 && !string.IsNullOrEmpty(valueArray[1]))
                            {
                                if (IsInt(valueArray[1]))
                                {
                                    analyseResult.Value = textValue.ToUpper().Replace(analyseResult.Unit.ToCharArray()[0], '.');
                                }
                                else
                                {
                                    analyseResult.Value = valueArray[0];
                                }
                            }
                            break;
                        }
                    }
                }

                //找出数字字符串
                if (string.IsNullOrEmpty(analyseResult.Value))
                {
                    if (analyseResult.Type == "电阻".tr())
                    {
                        for (int i = 0; i < listValue.Count; i++)
                        {
                            string textValue = listValue[i];
                            if (IsNumeric(textValue))
                            {
                                if (textValue?.Length > 0)
                                {
                                    if (IsIdentifyingDigits)
                                    {
                                        int factor = (int)Math.Pow(10, Convert.ToInt32(textValue.Substring(textValue.Length - 1)));
                                        analyseResult.Value = (Convert.ToDouble(textValue.Remove(textValue.Length - 1, 1)) * factor).ToString();
                                    }
                                    else
                                    {
                                        analyseResult.Value = textValue;
                                    }

                                }
                                break;
                            }
                            else
                            {   //电阻分析加入特殊处理 如0R5 5R00...
                                string pattern = @"(?<=\d)\D+(?=\d)";
                                Regex regex = new Regex(pattern);
                                string result = regex.Replace(textValue, ".");
                                if (IsIntermediateUnit)
                                    analyseResult.Value = Regex.Replace(result, @"[^0-9.]", "");
                                break;
                            }
                        }
                    }
                    else if (analyseResult.Type == "电容".tr())
                    {
                        for (int i = 0; i < listValue.Count; i++)
                        {
                            string textValue = listValue[i];
                            if (IsNumeric(textValue))
                            {
                                if (IsIdentifyingDigits)
                                {
                                    int factor = (int)Math.Pow(10, Convert.ToInt32(textValue.Substring(textValue.Length - 1)));
                                    analyseResult.Value = (Convert.ToDouble(textValue.Remove(textValue.Length - 1, 1)) * factor).ToString();
                                }
                                else
                                {
                                    analyseResult.Value = textValue;
                                }
                                break;
                            }
                            else
                            {
                                //电阻分析加入特殊处理 如0R5 5R00...
                                string pattern = @"(?<=\d)\D+(?=\d)";
                                Regex regex = new Regex(pattern);
                                string result = regex.Replace(textValue, ".");
                                if (IsIntermediateUnit)
                                    analyseResult.Value = Regex.Replace(result, @"[^0-9.]", "");
                                break;
                            }
                        }
                    }
                }
            }

            analyseResult.Check();

            return analyseResult;
        }

        /// <summary>
        /// 解析物料宽度
        /// </summary>
        /// <param name="spec"></param>
        /// <param name="fromTable"></param>
        /// <param name="partNumber"></param>
        /// <returns></returns>
        public void AnalyWidth(string spec, ref AnalyseResult analyseResult)
        {
            try
            {
                if (!string.IsNullOrEmpty(spec))
                {
                    string Rstr = Regex.Replace(spec, @"[^\d.\d]", "");
                    string er = Rstr.Substring(2, 2);
                    analyseResult.Width = Convert.ToDouble(Rstr.Substring(0, 2)).ToString();
                    analyseResult.Space = Convert.ToDouble(Rstr.Substring(2, 2)).ToString();
                }
            }
            catch
            {
                analyseResult.Width = "8";
                analyseResult.Space = "4";
            }
        }
        /// <summary>
        /// 解析入口
        /// </summary>
        /// <param name="description">解析字符</param>
        public AnalyseResult AnalyseMethod_copy(string description)
        {
            AnalyseResult analyseResult = new AnalyseResult();
            List<string> specList = new List<string>(); //物料描述分隔符处理后
            List<string> unitResList = ResistanceUnit.Split(',').ToList(); //电阻单位
            List<string> unitCapList = CapacitanceUnit.Split(',').ToList();//电容单位

            string LCR_Type = "";

            #region 删除首位
            if (IsDeleteString)
            {
                description = RemoveLeft(description, PrefixNumber);
                description = RemoveRight(description, SuffixNumber);
            }
            #endregion

            #region 替换
            if (IsSubstitutionRules)
            {
                SubstitutionRule(ref description);
            }
            #endregion

            #region 分割符
            if (IsSeparator)
            {
                specList = Separator(description);
            }

            if (specList.Count <= 1)
            {
                analyseResult.Type = "分割不成功";
                return analyseResult;
            }
            #endregion

            #region 获取类型
            GetType(description, ref analyseResult, ref LCR_Type);
            if (analyseResult.Type == "Other") return analyseResult;
            //去掉物料类型
            var typeList = specList.Where(u => u.Contains(LCR_Type)).ToList();
            foreach (var item in typeList)
            {
                specList.Remove(item);
            }
            #endregion

            #region 获取尺寸
            GetSize(description, ref analyseResult);
            if (analyseResult.Size == "Error") return analyseResult;
            //去掉尺寸
            var sizeIndexList = specList.Where(u => u.Contains(analyseResult.Size)).ToList();
            foreach (var item in sizeIndexList)
            {
                specList.Remove(item);
            }
            #endregion

            #region 获取值，单位，等级
            for (int i = 0; i < specList.Count; i++)
            {
                #region 获取单位
                if (string.IsNullOrEmpty(analyseResult.Unit))
                {
                    List<string> units = new List<string>();
                    if (analyseResult.Type == "电阻")
                    {
                        units = unitResList.Where(x => specList[i].Contains(x)).ToList();
                    }
                    else if (analyseResult.Type == "电容")
                    {
                        units = unitCapList.Where(x => specList[i].Contains(x)).ToList();
                    }
                    if (units.Count > 0)
                    {
                        analyseResult.Unit = units[0];
                        if (string.IsNullOrEmpty(analyseResult.Value))
                        {
                            //提取值
                            string[] valueArray = specList[i].Split(analyseResult.Unit.ToCharArray()[0]);
                            if (valueArray.Length == 2 && string.IsNullOrEmpty(valueArray[1]))
                            {
                                analyseResult.Value = valueArray[0];
                            }
                            else if (valueArray.Length == 2 && !string.IsNullOrEmpty(valueArray[1]))
                            {
                                if (IsInt(valueArray[1]))
                                {
                                    analyseResult.Value = specList[i].Replace(analyseResult.Unit.ToCharArray()[0], '.');
                                }
                                else
                                {
                                    analyseResult.Value = valueArray[0];
                                }
                            }
                        }
                        continue;
                    }

                }
                #endregion

                #region 获取等级
                string textValue = specList[i];
                if (string.IsNullOrEmpty(analyseResult.Grade))
                {
                    //值含偏差等级
                    if (IsValueContainsGrade && IsValueGrade(textValue)&&string.IsNullOrEmpty(analyseResult.Value))
                    {
                        Regex r = new Regex(@"[a-zA-Z]+");
                        System.Text.RegularExpressions.Match m = r.Match(textValue);
                        string grade = m.Value;
                        if (!string.IsNullOrEmpty(grade))
                        {
                            analyseResult.Grade = grade;
                            textValue = textValue.Replace(grade, "");
                            if (textValue.Length == 3 && IsNumeric(textValue))
                            {
                                int v1 = int.Parse(textValue.Substring(0, 2));
                                int v2 = int.Parse(textValue.Substring(2, 1));
                                double val = v1 * Math.Pow(10, v2);
                                textValue = val.ToString();
                            }
                            analyseResult.Value = textValue;
                            continue;
                        }
                    }
                    else if (textValue.Contains("%"))
                    {
                        if (textValue.StartsWith("%"))
                        {
                            if (textValue.EndsWith("%"))
                            {
                                analyseResult.Grade = Regex.Replace(textValue, @"[^\d.\d]", "") + "%";
                            }
                            else
                            {
                                string tempGrade = Regex.Replace(textValue, @"[^0-9.]", "");
                                if (IsNumeric(tempGrade))
                                {
                                    analyseResult.Grade = tempGrade + "%";
                                }
                                else
                                {
                                    analyseResult.Grade = tempGrade;
                                }
                            }
                        }
                        else
                        {
                            analyseResult.Grade = TheGrade(textValue);
                        }
                    }
                }
                #endregion

                #region 获取值
                if (string.IsNullOrEmpty(analyseResult.Value))
                {
                    string value = textValue.Substring(textValue.Length - 1);
                    if (IsIdentifyingDigits && textValue.Length > 2 &&int.TryParse(textValue,out int res0) && int.TryParse(value,out int res))
                    {
                        int factor = (int)Math.Pow(10, Convert.ToInt32(res));
                        analyseResult.Value = (Convert.ToDouble(textValue.Remove(textValue.Length - 1, 1)) * factor).ToString();
                    }

                    if (string.IsNullOrEmpty(analyseResult.Value))
                    {
                        textValue = specList[i];
                        if (IsNumeric(textValue))
                        {
                            analyseResult.Value = textValue;
                        }
                        else
                        {
                            //电阻分析加入特殊处理 如0R5 5R00...
                            string pattern = @"(?<=\d)\D+(?=\d)";
                            Regex regex = new Regex(pattern);
                            string result = regex.Replace(textValue, ".");
                            if (IsIntermediateUnit)
                                analyseResult.Value = Regex.Replace(result, @"[^0-9.]", "");
                        }
                    }
                }
                #endregion
            }

            #region 删除单位
            if (!string.IsNullOrEmpty(analyseResult.Unit))
            {
                var unitList = specList.Where(u => u.Contains(analyseResult.Unit)).ToList();
                foreach (var item in unitList)
                {
                    specList.Remove(item);
                }
            }
            #endregion

            #endregion

            #region 最后未找到的项处理
            if (IsResDefaultUnit&&string.IsNullOrEmpty(analyseResult.Unit)&& analyseResult.Type == "电阻".tr())
            {
                //如果电阻没找到，默认单位为Ω
                analyseResult.Unit = ResDefaultUnit;
            }

            if (string.IsNullOrEmpty(analyseResult.Grade))
            {
                var gradeResult = specList.Where("CDFGJKMN".Contains).ToList();
                if (gradeResult?.Count > 0)
                {
                    string Grade = gradeResult[0];
                    if (GradeChanges.Where(x => x.Grade == Grade).ToList().Count>0)
                    {
                        Grade = GradeChanges.Where(x => x.Grade == Grade).ToList()[0].Percent;
                    }
                    analyseResult.Grade = Grade;   
                }
                    
                else if (IsGrade_ON_NO_Find)
                {
                    //自定义等级偏差
                    if (analyseResult.Type == "电阻".tr())
                    {
                        analyseResult.Grade = ResGrade_ON_NO_Find;
                    }
                    else if (analyseResult.Type == "电容".tr())
                    {
                        analyseResult.Grade = CapGrade_ON_NO_Find;
                    }
                }
            }
            #endregion

            analyseResult.Check();
            return analyseResult;
        }

        private void GetValueAndUnit(ref AnalyseResult analyseResult, string value, List<string> unitList)
        {
            List<string> units = unitList.Where(x => value.Contains(x)).ToList();
            if (units.Count > 0)
            {

            }
        }

        /// <summary>
        /// 获取类型
        /// </summary>
        /// <param name="description"></param>
        /// <param name="analyseResult"></param>
        /// <param name="LCR_Type"></param>
        private void GetType(string description, ref AnalyseResult analyseResult, ref string LCR_Type)
        {
            var resResult = Resistance.ToUpper().Split(',').Where(description.ToUpper().Contains).ToList();
            var capResult = Capacitance.ToUpper().Split(',').Where(description.ToUpper().Contains).ToList();

            if (resResult?.Count > 0)
            {
                analyseResult.Type = "电阻".tr();
                LCR_Type = resResult[0];

            }
            else if (capResult?.Count > 0)
            {
                analyseResult.Type = "电容".tr();
                LCR_Type = capResult[0];
            }
        }

        /// <summary>
        /// 获取尺寸
        /// </summary>
        private void GetSize(string description, ref AnalyseResult analyseResult)
        {
            var sizeResult = ComponentSpecifications.ToUpper().Split(',').Where(description.ToUpper().Contains).ToList();
            if (sizeResult?.Count > 0)
                analyseResult.Size = sizeResult[0];
        }

        /// <summary>
        /// 分割字符方法
        /// </summary>
        /// <param name="description"></param>
        private List<string> Separator(string description)
        {
            var splitCharList = Separators.Where(u => u.Enable == true);
            List<char> listSplitChar = new List<char>();
            foreach (var item in splitCharList)
            {
                //char singleSplitChar = MidStrEx(item.Acsii, "(", ")").ToCharArray()[0];
                if (!listSplitChar.Contains(item.Acsii.ToArray()[0]))
                    listSplitChar.Add(item.Acsii.ToArray()[0]);
            }
            List<string> specList = description.Split(listSplitChar.ToArray(), StringSplitOptions.RemoveEmptyEntries).Where(a => a.Length >= 1).Select(b => b).ToList();

            return specList;
        }

        private string MidStrEx(string sourse, string startstr, string endstr)
        {
            string result = string.Empty;
            int startindex, endindex;
            try
            {
                startindex = sourse.IndexOf(startstr);
                if (startindex == -1)
                    return result;
                string tmpstr = sourse.Substring(startindex + startstr.Length);
                endindex = tmpstr.IndexOf(endstr);
                if (endindex == -1)
                    return result;
                result = tmpstr.Remove(endindex);
            }
            catch (Exception)
            {
                return sourse;
            }
            return result;
        }

        /// <summary>
        /// 替换字符方法
        /// </summary>
        /// <returns></returns>
        private void SubstitutionRule(ref string description)
        {
            var replaceList = SubstitutionRules.Where(u => u.Enable == true);
            foreach (var item in replaceList.ToList())
            {
                if (description.Contains(item.FindContent))
                {
                    if (item.Is_Case_sensitive)//区分大小写
                    {
                        if (item.Is_Full_half_width)//区分全半角
                        {
                            description = description.Replace(item.FindContent, item.Replace);
                        }
                        else//不区分全半角
                        {
                            description = description.Replace(item.FindContent.ToSBC(), item.Replace);
                            description = description.Replace(item.FindContent.ToDBC(), item.Replace);
                        }
                    }
                    else//不区分大小写
                    {
                        if (item.Is_Full_half_width)//区分全半角
                        {
                            description = Regex.Replace(description, Regex.Escape(item.FindContent), item.Replace, RegexOptions.IgnoreCase);
                        }
                        else //不区分全半角
                        {
                            description = Regex.Replace(description, Regex.Escape(item.FindContent.ToSBC()), item.Replace, RegexOptions.IgnoreCase);
                            description = Regex.Replace(description, Regex.Escape(item.FindContent.ToDBC()), item.Replace, RegexOptions.IgnoreCase);
                        }
                    }
                }
            }
        }

        //从字符串前面删除指定字符个数
        private string RemoveLeft(string s, int len)
        {
            return s.PadLeft(len).Remove(0, len);
        }

        //从字符串后面删除指定字符个数
        private string RemoveRight(string s, int len)
        {
            s = s.PadRight(len);
            return s.Remove(s.Length - len, len);
        }

        private bool IsNumeric(string s)
        {
            double v;
            if (double.TryParse(s, out v))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string TheGrade(string str)
        {
            string r = @"[0-9.]+%";
            List<string> list = new List<string>();
            Regex reg = new Regex(r, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            MatchCollection mc = reg.Matches(str);
            foreach (System.Text.RegularExpressions.Match m in mc)
            {
                return m.Groups[0].Value;
            }
            return str;
        }

        //数字开头字母结尾
        private bool IsValueGrade(string mobile)
        {
            return Regex.IsMatch(mobile, @"^\d[\d\w]+\w$");
        }

        private bool IsInt(string value)
        {
            return Regex.IsMatch(value, @"^[0-9]*[1-9][0-9]*$");
        }

        private string TheLongestName(string[] array)
        {
            string longest = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Length > longest.Length)
                {
                    longest = array[i];
                }
            }
            return longest;
        }

    }

    [Serializable]
    public class GradeChange
    {
        /// <summary>
        /// 字符等级
        /// </summary>
        public string Grade;
        /// <summary>
        /// 百分比
        /// </summary>
        public string Percent;
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
        /// <summary>
        /// 条码
        /// </summary>
        public string BarCode = "";
        /// <summary>
        /// 物料描述
        /// </summary>
        public string Description;
        public bool Result = false;

        /// <summary>
        /// 宽度
        /// </summary>
        public string Width { get; set; } = "8";

        /// <summary>
        /// 间距
        /// </summary>
        public string Space { get; set; } = "4";

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

        public void Check()
        {
            if (Type != "Other" && Size != "Error" && !string.IsNullOrEmpty(Value) && !string.IsNullOrEmpty(Unit) && !string.IsNullOrEmpty(Grade))
            {
                Result = true;
            }
        }
    }


}
