using BorwinAnalyse.BaseClass;
using BorwinAnalyse.DataBase.Comm;
using BorwinAnalyse.UCControls;
using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorwinAnalyse.Forms
{
    public partial class AnalyseMainForm : KryptonForm
    {
        public AnalyseMainForm()
        {
            InitializeComponent();
            
        }

        UCBOM uCBOM;
        UCSearch uCSearch;
        UCAnalyseSet uCAnalyseSet ;

        private void AnalyseMainForm_Load(object sender, EventArgs e)
        {
            SqlLiteManager.Instance.Init();
            CommonAnalyse.Instance.Load();
            InitUI();
            LanguageManager.Instance.UpdateLanguage(this, this.components.Components);

        }

        private void InitUI()
        {
            DataTable dataTable = LanguageManager.Instance.SearchALLLanguageType();
            if (dataTable == null) { return; }
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                comLanguage.Items.Add(dataTable.Rows[i].ItemArray[0]);
            }
            if (dataTable.Rows.Count > 0)
            {
                int lang = int.Parse(dataTable.Rows[0].ItemArray[1].ToString());
                comLanguage.SelectedIndex = lang - 1;
                LanguageManager.Instance.CurrenIndex = lang;
            }
        }

        private void InitButton(string text)
        {
            KryptonButton kryptonButton = new KryptonButton();
            kryptonButton.Text = text.tr();
            kryptonButton.Dock = DockStyle.Top;
            kryptonButton.Height = 70;
            kryptonButton.Tag = text;
            kryptonButton.Click += KryptonButton_Click;
            kryptonSplitContainer2.Panel1.Controls.Add(kryptonButton);
        }

        private void KryptonButton_Click(object sender, EventArgs e)
        {
            switch (((KryptonButton)sender).Tag)
            {
                case "BOM":
                    if (uCBOM == null)
                    {
                        uCBOM = new UCBOM();
                        kryptonSplitContainer2.Panel2.Controls.Add(uCBOM);
                    }
                    uCBOM.BringToFront();
                    break;
                case "上料表":
                    break;
                case "查询":
                    if (uCSearch==null)
                    {
                        uCSearch = new UCSearch();
                        kryptonSplitContainer2.Panel2.Controls.Add(uCSearch);
                    }
                    uCSearch.BringToFront();
                    break;
                case "设置":
                    if (uCAnalyseSet == null)
                    {
                        uCAnalyseSet = new UCAnalyseSet();
                        kryptonSplitContainer2.Panel2.Controls.Add(uCAnalyseSet);
                    }
                    uCAnalyseSet.BringToFront();
                    break;
                default:
                    break;
            }
        }

        private void kryptonContextMenu1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //ShowMenu(kryptonDataGridView1, kryptonContextMenu1);
        }

        private void ShowMenu(Control c, KryptonContextMenu kcm)
        {
            //kcm.Show(c.RectangleToScreen(c.ClientRectangle),
            //         (KryptonContextMenuPositionH)Enum.Parse(typeof(KryptonContextMenuPositionH), (string)comboBoxH.SelectedItem),
            //         (KryptonContextMenuPositionV)Enum.Parse(typeof(KryptonContextMenuPositionV), (string)comboBoxV.SelectedItem));
        }

        private void comLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            LanguageManager.Instance.UpdateCurrentLanguage(comLanguage.SelectedIndex);
        }

        private void AnalyseMainForm_Shown(object sender, EventArgs e)
        {
            comLanguage.SelectedIndexChanged += comLanguage_SelectedIndexChanged;
        }
    }
}
