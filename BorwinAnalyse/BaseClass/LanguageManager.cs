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
                    foreach (KryptonContextMenuItemBase MenuItemBas in ((KryptonContextMenu)item).Items)
                    {
                        if (MenuItemBas is KryptonContextMenuHeading)
                        {
                            ((KryptonContextMenuHeading)(MenuItemBas)).Text = ((KryptonContextMenuHeading)(MenuItemBas)).Text.tr();
                        }
                        else if (MenuItemBas is KryptonContextMenuCheckBox)
                        {
                            ((KryptonContextMenuCheckBox)(MenuItemBas)).Text = ((KryptonContextMenuCheckBox)(MenuItemBas)).Text.tr();
                        }
                        else if (MenuItemBas is KryptonContextMenuCheckButton)
                        {
                            ((KryptonContextMenuCheckButton)(MenuItemBas)).Text = ((KryptonContextMenuCheckButton)(MenuItemBas)).Text.tr();
                        }
                        else if (MenuItemBas is KryptonContextMenuRadioButton)
                        {
                            ((KryptonContextMenuRadioButton)(MenuItemBas)).Text = ((KryptonContextMenuRadioButton)(MenuItemBas)).Text.tr();
                        }
                        else if (MenuItemBas is KryptonContextMenuLinkLabel)
                        {
                            ((KryptonContextMenuLinkLabel)(MenuItemBas)).Text = ((KryptonContextMenuLinkLabel)(MenuItemBas)).Text.tr();
                        }
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
                    control.Text = control.Text.tr();
                }
                else if (control is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)control;
                    for (int i = 0; i < comboBox.Items.Count; i++)
                    {
                        comboBox.Items[i]= comboBox.Items[i].ToString().tr();
                    }
                }else if (control is KryptonDataGridView)
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
            if (str == null || str == "")
            {
                return str;
            }
            string comms = string.Format("select * from Language where context = '{0}' or english = '{1}'", str, str);
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
