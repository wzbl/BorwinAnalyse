using BorwinAnalyse.BaseClass;
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

namespace BorwinAnalyse.UCControls
{
    public partial class UCAnalyseSet : UserControl
    {
        public UCAnalyseSet()
        {
            InitializeComponent();
            this.components = new System.ComponentModel.Container();
            Dock = DockStyle.Fill;
            this.Load += UCAnalyseSet_Load;
        }

        private void UCAnalyseSet_Load(object sender, EventArgs e)
        {
            
        }

    

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }


        private void Save()
        {
            CommonAnalyse.Instance.SubstitutionRules.Clear();
            for (int i = 0; i < dataGridRule1.RowCount; i++)
            {
                SubstitutionRules substitutionRules =new SubstitutionRules();
                substitutionRules.FindContent = dataGridRule1.Rows[i].Cells[0].AccessibilityObject.Value.ToString().Contains("null")?"": dataGridRule1.Rows[i].Cells[0].AccessibilityObject.Value.ToString();
                substitutionRules.Replace = dataGridRule1.Rows[i].Cells[1].AccessibilityObject.Value.ToString().Contains("null") ? "" : dataGridRule1.Rows[i].Cells[1].AccessibilityObject.Value.ToString();
                substitutionRules.Enable = bool.Parse( dataGridRule1.Rows[i].Cells[2].AccessibilityObject.Value.ToString());
                substitutionRules.Is_Case_sensitive= bool.Parse(dataGridRule1.Rows[i].Cells[3].AccessibilityObject.Value);
                substitutionRules.Is_Full_half_width = bool.Parse(dataGridRule1.Rows[i].Cells[4].AccessibilityObject.Value.ToString());
                substitutionRules.Remark = dataGridRule1.Rows[i].Cells[5].AccessibilityObject.Value.ToString().Contains("null") ? "" : dataGridRule1.Rows[i].Cells[5].AccessibilityObject.Value.ToString(); ;
                CommonAnalyse.Instance.SubstitutionRules.Add(substitutionRules);
            }
            CommonAnalyse.Instance.Separators.Clear();
            for (int i = 0; i < dataGridRule2.RowCount; i++)
            {
                Separator separator = new Separator();
                separator.Enable = bool.Parse(dataGridRule2.Rows[i].Cells[0].AccessibilityObject.Value.ToString());
                separator.Acsii = dataGridRule2.Rows[i].Cells[1].AccessibilityObject.Value.ToString().Contains("null") ? "" : dataGridRule2.Rows[i].Cells[1].AccessibilityObject.Value.ToString(); ;
                separator.Illustrate = dataGridRule2.Rows[i].Cells[2].AccessibilityObject.Value.ToString().Contains("null") ? "" : dataGridRule2.Rows[i].Cells[2].AccessibilityObject.Value.ToString();
                CommonAnalyse.Instance.Separators.Add(separator);
            }

            CommonAnalyse.Instance.Save();

        }


        bool isEnterDataGridView1 = false;
        private void kryptonDataGridView1_MouseEnter(object sender, EventArgs e)
        {
            isEnterDataGridView1 = true;
        }

        private void kryptonDataGridView1_MouseLeave(object sender, EventArgs e)
        {
            isEnterDataGridView1 = false;
        }

        private void kryptonDataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Right)
            {
                ShowMenu(dataGridRule1,kryptonContextMenu1);
            }
        }

        private void ShowMenu(Control c, KryptonContextMenu kcm)
        {
            kcm.Show(c.RectangleToScreen(c.ClientRectangle), KryptonContextMenuPositionH.Left,
                     KryptonContextMenuPositionV.Top);
        }
    }
}
