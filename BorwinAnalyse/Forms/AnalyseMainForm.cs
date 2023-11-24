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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BorwinAnalyse.Forms
{
    public partial class AnalyseMainForm : KryptonForm
    {
        public AnalyseMainForm()
        {
            InitializeComponent();
        }

        private void AnalyseMainForm_Load(object sender, EventArgs e)
        {
            SqlLiteManager.Instance.Init();

            LanguageManager.Instance.UpdateLanguage(this, this.components.Components);
            
        }

        private void InitUI()
        {
            InitButton("查询");
            InitButton("设置");
            InitButton("上料表");
            InitButton("BOM");

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
                    kryptonSplitContainer2.Panel2.Controls.Clear();
                    UCBOM uCBOM = new UCBOM();
                    uCBOM.Show();
                    kryptonSplitContainer2.Panel2.Controls.Add(uCBOM);
                    break;
                case "上料表":
                    break;
                case "查询":
                    break;
                case "设置":
                    kryptonSplitContainer2.Panel2.Controls.Clear();
                    UCAnalyseSet uCAnalyseSet= new UCAnalyseSet();
                    uCAnalyseSet.Show();
                    kryptonSplitContainer2.Panel2.Controls.Add(uCAnalyseSet);
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
            ShowMenu(kryptonDataGridView1, kryptonContextMenu1);
        }

        private void ShowMenu(Control c, KryptonContextMenu kcm)
        {
            kcm.Show(c.RectangleToScreen(c.ClientRectangle),
                     (KryptonContextMenuPositionH)Enum.Parse(typeof(KryptonContextMenuPositionH), (string)comboBoxH.SelectedItem),
                     (KryptonContextMenuPositionV)Enum.Parse(typeof(KryptonContextMenuPositionV), (string)comboBoxV.SelectedItem));
        }
    }
}
