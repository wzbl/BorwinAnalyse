using BorwinAnalyse.DataBase.Comm;
using ComponentFactory.Krypton.Navigator;
using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        public DataTable SearchALLLanguageType()
        {
            string comms = "select name ,currentLanguage  from LanguageType";
            DataTable res = SqlLiteManager.Instance.DB.Search(comms, "LanguageType");
            return res;
        }

        public void UpdateCurrentLanguage(int index)
        {
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
            LoopControl(control);
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
    }
    public static class LanHelper
    {
        public static string tr(this string str)
        {
            if (str == null)
            {
                return str;
            }
            string comms = string.Format("select * from Language where context = '{0}' or chinese = '{1}' or english = '{2}' ", str,str,str);
            DataTable res = SqlLiteManager.Instance.DB.Search(comms, "Language");
            if (res == null || res.Rows.Count == 0)
            {
                string comm = string.Format("insert into Language values('{0}','{1}','','','','','','')", str, str);
                SqlLiteManager.Instance.DB.Insert(comm);
            }
            else
            {
                return res.Rows[0].ItemArray[LanguageManager.Instance.CurrenIndex].ToString() != "" ? res.Rows[0].ItemArray[LanguageManager.Instance.CurrenIndex].ToString() : str;
            }
            return str;
        }
    }
}
