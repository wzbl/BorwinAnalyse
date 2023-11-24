using BorwinAnalyse.DataBase.Comm;
using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void UpdateLanguage(Control control, ComponentCollection componentCollection)
        {
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
                if (control is Label || control is Button)
                {
                    control.Text = ((Label)control).Text.tr();
                }
                else if (control is ComboBox)
                {
                    if (((ComboBox)control).Items.Count > 0)
                    {

                    }

                }
                string text = control.Text;
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
            string comms = string.Format("select * from Language where context = '{0}' ", str);
            DataTable res = SqlLiteManager.Instance.DB.Search(comms, "Language");
            if (res == null || res.Rows.Count == 0)
            {
                string comm = string.Format("insert into Language values('{0}','{1}','','','','','','','{2}')", str, str, DateTime.Now.ToString("yyyy-MM-dd H:m:s"));
                SqlLiteManager.Instance.DB.Insert(comm);
            }
            else
            {
                return res.Rows[0].ItemArray[1].ToString() != "" ? res.Rows[0].ItemArray[1].ToString() : str;
            }
            return str;
        }
    }
}
