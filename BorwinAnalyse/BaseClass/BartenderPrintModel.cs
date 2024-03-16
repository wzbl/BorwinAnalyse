using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List< Dictionary<string ,string >> keyValuePairs = new List< Dictionary<string ,string>>();
        /// <summary>
        /// 模版路径
        /// </summary>
        public string Path;
        /// <summary>
        /// 打印机名称
        /// </summary>
        public string Name;
        BarTender.Application btApp;
        BarTender.Format btFormat;

        public void Init()
        {
            btFormat = btApp.Formats.Open(Path, false, "");
            btFormat.PrintSetup.IdenticalCopiesOfLabel = 1;  //设置同序列打印的份数
            btFormat.PrintSetup.NumberSerializedLabels = 1;  //设置需要打印的序列数
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="objects"></param>
        public void BindData() 
        {
            //名称绑定值
            for (int i = 0; i < keyValuePairs.Count; i++)
            {
                btFormat.SetNamedSubStringValue(keyValuePairs[i].Keys.ToString(), keyValuePairs[i].Values.ToString());
            }
        }

        /// <summary>
        /// 执行打印
        /// </summary>
        public void Print()
        {
            //打印机名称
            btFormat.PrintSetup.Printer = Name;
            //第二个false设置打印时是否跳出打印属性
            btFormat.PrintOut(false, false);
            btFormat.Print(Path, true, 1000, out BarTender.Messages Messages);
            //退出时是否保存标签
            btFormat.Close(BarTender.BtSaveOptions.btSaveChanges);
        }
    }
}
