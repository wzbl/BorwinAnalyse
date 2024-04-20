using Newtonsoft.Json;
using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorwinAnalyse.BaseClass
{
    /// <summary>
    /// Bartender打印
    /// </summary>
    public class BartenderPrintModel
    {
        //模板路径
        //打印名称
        //参数绑定
        //打印份数

        private static BartenderPrintModel instance;

        public static BartenderPrintModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BartenderPrintModel();
                }
                return instance;
            }
        }

        /// <summary>
        /// 模版路径
        /// </summary>
        public string Path;

        /// <summary>
        /// 打印机名称
        /// </summary>
        public string Name;
        //private BarTender.Application btApp = null;
        //BarTender.Format btFormat = null;
        public List<PrintValue> PrintValues = new List<PrintValue>();

        public void Start()
        {
            //if (btApp != null)
            //    btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges);
            //btApp = new BarTender.Application();
            //btFormat = btApp.Formats.Open(Path, false, "");
            //btFormat.PrintSetup.IdenticalCopiesOfLabel = 1;  //设置同序列打印的份数
            //btFormat.PrintSetup.NumberSerializedLabels = 1;  //设置需要打印的序列数
        }

        public void Stop()
        {
            //if (btApp != null)
            //{
               
            //    Process[] processes = Process.GetProcessesByName("bartend");
            //    foreach (Process process in processes)
            //    {
            //        process.Kill();
            //    }
            //}
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="objects"></param>
        private void BindData()
        {
            //名称绑定值
            for (int i = 0; i < PrintValues.Count; i++)
            {
                //if (PrintValues[i].Enable)
                //{
                //    btFormat.SetNamedSubStringValue(PrintValues[i].Key, PrintValues[i].Value);
                //}
            }
        }

        /// <summary>
        /// 设置打印信息
        /// </summary>
        /// <param name="o">对象属性可访问</param>
        public void SetPrintMsg(object o)
        {
            foreach (PrintValue pv in PrintValues)
            {
                try
                {
                    if (pv.Enable)
                    {
                        Type type = o.GetType();
                        //属性
                        PropertyInfo info = type.GetProperty(pv.Name);
                        //字段
                        FieldInfo fieldInfo = type.GetField(pv.Name);
                        if (fieldInfo != null)
                        {
                            if (fieldInfo.GetValue(o) != null)
                            {
                                pv.Value = fieldInfo.GetValue(o).ToString();
                            }
                        }
                        else if (info != null)
                        {
                            if (info.GetValue(o, null) != null)
                            {
                                pv.Value = info.GetValue(o, null).ToString();
                            }
                        }
                        //else
                        //{
                        //    MessageBox.Show("未找到字段或者属性:".tr() + pv.Name);
                        //}
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        /// <summary>
        /// 执行打印
        /// </summary>
        public void Print()
        {
            BindData();
            //打印机名称
            //btFormat.PrintSetup.Printer = Name;
            ////第二个false设置打印时是否跳出打印属性
            //btFormat.PrintOut(false, false);
            //btFormat.Print(Path, true, 1000, out BarTender.Messages Messages);
            ////退出时是否保存标签
            //btFormat.Close(BarTender.BtSaveOptions.btSaveChanges);
        }

        public void Save()
        {
            string savePath = @"Ini/BartenderPrint.json";
            if (!File.Exists(savePath))
            {
                FileStream fs1 = new FileStream(savePath, FileMode.Create, FileAccess.ReadWrite);
                fs1.Close();
            }
            File.WriteAllText(savePath, JsonConvert.SerializeObject(instance));
            Start();
        }

        public void Load()
        {
            string savePath = @"Ini/BartenderPrint.json";
            if (!File.Exists(savePath))
            {
                FileStream fs1 = new FileStream(savePath, FileMode.Create, FileAccess.ReadWrite);
                fs1.Close();
            }
            else
            {
                instance = JsonConvert.DeserializeObject<BartenderPrintModel>(File.ReadAllText(savePath));
            }
        }
    }


    public class PrintValue
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">绑定客户返回字段名</param>
        /// <param name="key">绑定模板字段名</param>
        /// <param name="enable">是否启用</param>
        /// <param name="value">模板值</param>
        public PrintValue(string name, string key, string value = "", bool enable = false)
        {
            Name = name;
            Key = key;
            Enable = enable;
            Value = value;
        }
        public string Name { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public bool Enable;
    }
}
