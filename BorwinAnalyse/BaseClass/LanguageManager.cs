using BorwinAnalyse.DataBase.Comm;
using BorwinAnalyse.DataBase.Model;
using ComponentFactory.Krypton.Navigator;
using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading;
using System.Windows.Forms;

namespace BorwinAnalyse.BaseClass
{
    public class LanguageManager
    {
        private static LanguageManager instance;
        public static LanguageManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LanguageManager();
                }
                return instance;
            }
        }

        public int CurrenIndex = 0;

        private Dictionary<Control, ComponentCollection> Controls = new Dictionary<Control, ComponentCollection>();

        public List<Language> languages = new List<Language>();

        public DataTable SearchALLLanguageType()
        {
            string comms = "select name ,currentLanguage  from LanguageType";
            DataTable res = SqlLiteManager.Instance.DB.Search(comms, "LanguageType");
            return res;
        }


        public void SearchALLLanguage()
        {
            string comms = "select * from Language";
            DataTable dataTable = SqlLiteManager.Instance.DB.Search(comms, "Language");
            languages.Clear();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Language language = new Language();
                language.context= dataTable.Rows[i].ItemArray[0].ToString();
                language.chinese= dataTable.Rows[i].ItemArray[1].ToString();
                language.english= dataTable.Rows[i].ItemArray[2].ToString();
                language.exp1= dataTable.Rows[i].ItemArray[3].ToString();
                language.exp2= dataTable.Rows[i].ItemArray[4].ToString();
                language.exp3= dataTable.Rows[i].ItemArray[5].ToString();
                language.exp4= dataTable.Rows[i].ItemArray[6].ToString();
                language.exp5= dataTable.Rows[i].ItemArray[7].ToString();
                languages.Add(language);
            }
        }


        public string SearchLanguage(string context)
        {
            string res = context;
            List<Language> language =  languages.Where(x=>x.context==context || x.chinese == context || x.english == context).ToList<Language>();
            if (languages == null|| language.Count==0)
            {
                string comm = string.Format("insert into Language values('{0}','{1}','','','','','','')", context, context);
                SqlLiteManager.Instance.DB.Insert(comm);
                Language lang = new Language();
                lang.context = context;
                lang.chinese = context;
                languages.Add(lang);
                return res;
            }
          
            switch (CurrenIndex)
            {
                case 0:
                    res = language[0].context;
                    break;
                case 1:
                    res = language[0].chinese;
                    break;
                case 2:
                    res = language[0].english;
                    break;
                case 3:
                    res = language[0].exp1;
                    break;
                case 4:
                    res = language[0].exp2;
                    break;
                case 5:
                    res = language[0].exp3;
                    break;
                case 6:
                    res = language[0].exp4;
                    break;
            }
            if (string.IsNullOrEmpty(res))
            {
                return language[0].context;
            }
            return res;
        }

        public void UpdateCurrentLanguage(int index)
        {
            if (index + 1== CurrenIndex)
            {
                return;
            }
            CurrenIndex = index + 1;
            string cmd = string.Format("update LanguageType set currentLanguage = '{0}'",(index + 1).ToString());
            SqlLiteManager.Instance.DB.Insert(cmd);
            foreach (var item in Controls)
            {
                UpdateLanguage(item.Key, item.Value);
                Thread.Sleep(500);
            }
        }

        public void UpdateLanguage(Control control, ComponentCollection componentCollection)
        {
            if (!Controls.ContainsKey(control))
            {
                Controls.Add(control, componentCollection);
            }
            if (control is Form)
            {
                control.Text = control.Text.tr();
            }
            MethodA(control);
            LoopWinform(componentCollection);

        }

        /// <summary>
        /// 遍历窗体控件
        /// </summary>
        private void LoopWinform(ComponentCollection fatherComponent)
        {
            foreach (Component item in fatherComponent)
            {
                if (item is KryptonContextMenu)
                {

                    if (((KryptonContextMenu)item).Items[2] is KryptonContextMenuHeading)
                    {
                        string s = ((KryptonContextMenuHeading)((KryptonContextMenu)item).Items[2]).Text;
                    }
                }

            }

        }

        private void LoopControl(Control fatherControl)
        {
            Control.ControlCollection sonControls = fatherControl.Controls;
            foreach (Control control in sonControls)
            {
               
                if (control is Label || control is Button|| control is KryptonButton)
                {
                    control.Text = control.Text.tr();
                }
                else if (control is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)control;
                    for (int i = 0; i < comboBox.Items.Count; i++)
                    {
                        string text = comboBox.Items[i].ToString().tr();
                        comboBox.Items[i] = text;
                    }
                }
                else if (control is KryptonNavigator)
                {
                    KryptonNavigator kryptonNavigator = (KryptonNavigator)control;
                    for (int i = 0; i < kryptonNavigator.Pages.Count; i++)
                    {
                        kryptonNavigator.Pages[i].Text = kryptonNavigator.Pages[i].Text.tr();
                    }
                }
                else if (control is KryptonDataGridView)
                {
                    KryptonDataGridView kryptonDataGridView = (KryptonDataGridView)control;
                    for (int i = 0; i < kryptonDataGridView.Columns.Count; i++)
                    {
                        kryptonDataGridView.Columns[i].HeaderText = kryptonDataGridView.Columns[i].HeaderText.tr();
                    }
                }
                if (control.Controls != null)
                {
                    LoopControl(control);
                }
            }
        }

        private int iQty = 0;

        public void MethodA(Control fatherControl)
        {
            Control.ControlCollection sonControls = fatherControl.Controls;
            foreach (Control control in sonControls)
            {
                fatherControl.Invoke(new Action(() =>
                {
                    if (control is Label || control is Button || control is KryptonButton||control is KryptonCheckBox)
                    {
                        control.Text = control.Text.tr();
                    }
                    else if (control is ComboBox)
                    {
                        ComboBox comboBox = (ComboBox)control;
                        for (int i = 0; i < comboBox.Items.Count; i++)
                        {
                            string text = comboBox.Items[i].ToString().tr();
                            comboBox.Items[i] = text;
                        }
                    }
                    else if (control is KryptonNavigator)
                    {
                        KryptonNavigator kryptonNavigator = (KryptonNavigator)control;
                        for (int i = 0; i < kryptonNavigator.Pages.Count; i++)
                        {
                            kryptonNavigator.Pages[i].Text = kryptonNavigator.Pages[i].Text.tr();
                        }
                    }
                    else if (control is KryptonDataGridView)
                    {
                        KryptonDataGridView kryptonDataGridView = (KryptonDataGridView)control;
                        for (int i = 0; i < kryptonDataGridView.Columns.Count; i++)
                        {
                            kryptonDataGridView.Columns[i].HeaderText = kryptonDataGridView.Columns[i].HeaderText.tr();
                        }
                    }else if (control is KryptonGroupBox)
                    {
                        KryptonGroupBox kryptonGroupBox = (KryptonGroupBox)control;
                        kryptonGroupBox.Values.Heading= kryptonGroupBox.Values.Heading.tr();
                    }
                }));
               
                if (control.Controls != null)
                {
                    MethodB(control);
                }
            }
        }

        public void MethodB(Control fatherControl)
        {


            Control.ControlCollection sonControls = fatherControl.Controls;
            foreach (Control control in sonControls)
            {
                fatherControl.Invoke(new Action(() =>
                {
                    if (control is Label || control is Button || control is KryptonButton)
                    {
                        control.Text = control.Text.tr();
                    }
                    else if (control is ComboBox)
                    {
                        ComboBox comboBox = (ComboBox)control;
                        for (int i = 0; i < comboBox.Items.Count; i++)
                        {
                            string text = comboBox.Items[i].ToString().tr();
                            comboBox.Items[i] = text;
                        }
                    }
                    else if (control is KryptonNavigator)
                    {
                        KryptonNavigator kryptonNavigator = (KryptonNavigator)control;
                        for (int i = 0; i < kryptonNavigator.Pages.Count; i++)
                        {
                            kryptonNavigator.Pages[i].Text = kryptonNavigator.Pages[i].Text.tr();
                        }
                    }
                    else if (control is KryptonDataGridView)
                    {
                        KryptonDataGridView kryptonDataGridView = (KryptonDataGridView)control;
                        for (int i = 0; i < kryptonDataGridView.Columns.Count; i++)
                        {
                            kryptonDataGridView.Columns[i].HeaderText = kryptonDataGridView.Columns[i].HeaderText.tr();
                        }
                    }
                    else if (control is KryptonGroupBox)
                    {
                        KryptonGroupBox kryptonGroupBox = (KryptonGroupBox)control;
                        kryptonGroupBox.Values.Heading = kryptonGroupBox.Values.Heading.tr();
                    }
                }));
                if (control.Controls != null)
                {
                    iQty++;
                    //if (iQty % 20 == 0)
                    //{
                    //    //这里加多一个判断，每当循环十次后，就使用新线程的方式来调用方法，主要是为了释放之前的内存，避免内存溢出。
                    //    var t = new Thread(delegate () { MethodA(control); }, 1073741824);
                    //    t.Start();
                    //}
                    //else
                    //{
                    //    MethodA(control);
                    //}
                    MethodA(control);
                }
            }
         
        }


    }
    public static class LanHelper
    {
        public static string tr(this string str)
        {
            if (str == null||string.IsNullOrEmpty(str))
            {
                return str;
            }
            string res = LanguageManager.Instance.SearchLanguage(str);
            return res;
        }

        /// <summary>
        /// 转全角的函数(SBC case)
        /// </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>全角字符串</returns>
        ///<remarks>
        ///全角空格为12288，半角空格为32
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        ///</remarks>
        public static string ToSBC(this string input)
        {
            //半角转全角：
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new string(c);
        }

        /// <summary> 转半角的函数(DBC case) </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>半角字符串</returns>
        ///<remarks>
        ///全角空格为12288，半角空格为32
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        ///</remarks>
        public static string ToDBC(this string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }

    }
}
