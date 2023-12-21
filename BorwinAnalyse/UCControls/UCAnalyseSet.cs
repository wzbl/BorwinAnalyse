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
            InitUI();
            UpdataLanguage();
        }

        public void UpdataLanguage()
        {
            LanguageManager.Instance.UpdateLanguage(this, this.components.Components);
        }

        private void InitUI()
        {
            IsSubstitutionRules.Checked = CommonAnalyse.Instance.IsSubstitutionRules;
            for (int i = 0; i < CommonAnalyse.Instance.SubstitutionRules.Count; i++)
            {
                SubstitutionRules substitutionRules = CommonAnalyse.Instance.SubstitutionRules[i];
                dataGridRule1.Rows.Add(
                    substitutionRules.FindContent,
                    substitutionRules.Replace,
                    substitutionRules.Enable,
                    substitutionRules.Is_Case_sensitive,
                    substitutionRules.Is_Full_half_width,
                    substitutionRules.Remark
                    );
            }

            IsSeparator.Checked = CommonAnalyse.Instance.IsSeparator;
            for (int i = 0; i < CommonAnalyse.Instance.Separators.Count; i++)
            {
                Separator separator = CommonAnalyse.Instance.Separators[i];
                dataGridRule2.Rows.Add(
                   separator.Enable,
                   separator.Acsii,
                   separator.Illustrate
                   );
            }

            for (int i = 0; i < CommonAnalyse.Instance.GradeChanges.Count; i++)
            {
                GradeChange GradeChange = CommonAnalyse.Instance.GradeChanges[i];
                dataGridRule3.Rows.Add(
                   GradeChange.Grade,
                   GradeChange.Percent
                   );
            }

            txtRes.Text = CommonAnalyse.Instance.Resistance;
            txtCAP.Text = CommonAnalyse.Instance.Capacitance;
            txtResUnit.Text = CommonAnalyse.Instance.ResistanceUnit;
            txtCapUnit.Text = CommonAnalyse.Instance.CapacitanceUnit;
            txtSize.Text = CommonAnalyse.Instance.ComponentSpecifications;

            IsDeleteString.Checked = CommonAnalyse.Instance.IsDeleteString;
            txtPrefixNumber.Text = CommonAnalyse.Instance.PrefixNumber.ToString();
            txtSuffixNumber.Text = CommonAnalyse.Instance.SuffixNumber.ToString();

            IsIntermediateUnit.Checked = CommonAnalyse.Instance.IsIntermediateUnit;

            IsGrade_ON_NO_Find.Checked = CommonAnalyse.Instance.IsGrade_ON_NO_Find;
            txtResGrade_ON_NO_Find.Text = CommonAnalyse.Instance.ResGrade_ON_NO_Find;
            txtCapGrade_ON_NO_Find.Text = CommonAnalyse.Instance.CapGrade_ON_NO_Find;

            IsValueContainsGrade.Checked = CommonAnalyse.Instance.IsValueContainsGrade;
            IsResDefaultUnit.Checked = CommonAnalyse.Instance.IsResDefaultUnit;
            txtResDefaultUnit.Text = CommonAnalyse.Instance.ResDefaultUnit;
            IsIdentifyingDigits.Checked = CommonAnalyse.Instance.IsIdentifyingDigits;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }


        private void Save()
        {
            CommonAnalyse.Instance.SubstitutionRules.Clear();
            CommonAnalyse.Instance.IsSubstitutionRules = IsSubstitutionRules.Checked;
            for (int i = 0; i < dataGridRule1.RowCount; i++)
            {
                if (dataGridRule1.Rows[i].IsNewRow)
                {
                    continue;
                }
                SubstitutionRules substitutionRules = new SubstitutionRules();
                substitutionRules.FindContent = dataGridRule1.Rows[i].Cells[0].AccessibilityObject.Value.ToString().Contains("null") ? "" : dataGridRule1.Rows[i].Cells[0].AccessibilityObject.Value.ToString();
                substitutionRules.Replace = dataGridRule1.Rows[i].Cells[1].AccessibilityObject.Value.ToString().Contains("null") ? "" : dataGridRule1.Rows[i].Cells[1].AccessibilityObject.Value.ToString();
                substitutionRules.Enable = bool.Parse(dataGridRule1.Rows[i].Cells[2].AccessibilityObject.Value.ToString());
                substitutionRules.Is_Case_sensitive = bool.Parse(dataGridRule1.Rows[i].Cells[3].AccessibilityObject.Value);
                substitutionRules.Is_Full_half_width = bool.Parse(dataGridRule1.Rows[i].Cells[4].AccessibilityObject.Value.ToString());
                substitutionRules.Remark = dataGridRule1.Rows[i].Cells[5].AccessibilityObject.Value.ToString().Contains("null") ? "" : dataGridRule1.Rows[i].Cells[5].AccessibilityObject.Value.ToString(); ;
                CommonAnalyse.Instance.SubstitutionRules.Add(substitutionRules);
            }
            CommonAnalyse.Instance.Separators.Clear();
            CommonAnalyse.Instance.IsSeparator = IsSeparator.Checked;
            for (int i = 0; i < dataGridRule2.RowCount; i++)
            {
                if (dataGridRule2.Rows[i].IsNewRow)
                {
                    continue;
                }
                Separator separator = new Separator();
                separator.Enable = bool.Parse(dataGridRule2.Rows[i].Cells[0].AccessibilityObject.Value.ToString());
                separator.Acsii = dataGridRule2.Rows[i].Cells[1].AccessibilityObject.Value.ToString().Contains("null") ? "" : dataGridRule2.Rows[i].Cells[1].AccessibilityObject.Value.ToString(); ;
                separator.Illustrate = dataGridRule2.Rows[i].Cells[2].AccessibilityObject.Value.ToString().Contains("null") ? "" : dataGridRule2.Rows[i].Cells[2].AccessibilityObject.Value.ToString();
                CommonAnalyse.Instance.Separators.Add(separator);
            }

            for (int i = 0; i < dataGridRule3.RowCount; i++)
            {
                if (dataGridRule2.Rows[i].IsNewRow)
                {
                    continue;
                }
                GradeChange GradeChange = new GradeChange();
                GradeChange.Grade = dataGridRule3.Rows[i].Cells[0].AccessibilityObject.Value.ToString();
                GradeChange.Percent = dataGridRule3.Rows[i].Cells[1].AccessibilityObject.Value.ToString();
                CommonAnalyse.Instance.GradeChanges.Add(GradeChange);
            }

            CommonAnalyse.Instance.Resistance = txtRes.Text;
            CommonAnalyse.Instance.Capacitance = txtCAP.Text;
            CommonAnalyse.Instance.ResistanceUnit = txtResUnit.Text;
            CommonAnalyse.Instance.CapacitanceUnit = txtCapUnit.Text;
            CommonAnalyse.Instance.ComponentSpecifications = txtSize.Text;
            CommonAnalyse.Instance.IsDeleteString = IsDeleteString.Checked;
            CommonAnalyse.Instance.PrefixNumber = int.Parse(txtPrefixNumber.Text);
            CommonAnalyse.Instance.SuffixNumber = int.Parse(txtSuffixNumber.Text);
            CommonAnalyse.Instance.IsIntermediateUnit = IsIntermediateUnit.Checked;
            CommonAnalyse.Instance.IsGrade_ON_NO_Find = IsGrade_ON_NO_Find.Checked;
            CommonAnalyse.Instance.ResGrade_ON_NO_Find = txtResGrade_ON_NO_Find.Text;
            CommonAnalyse.Instance.CapGrade_ON_NO_Find = txtCapGrade_ON_NO_Find.Text;
            CommonAnalyse.Instance.IsValueContainsGrade = IsValueContainsGrade.Checked;
            CommonAnalyse.Instance.IsResDefaultUnit = IsResDefaultUnit.Checked;
            CommonAnalyse.Instance.ResDefaultUnit = txtResDefaultUnit.Text.Trim();
            CommonAnalyse.Instance.IsIdentifyingDigits = IsIdentifyingDigits.Checked;
            CommonAnalyse.Instance.Save();
            MessageBox.Show("保存成功".tr());
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
            if (e.Button == MouseButtons.Right)
            {
                //ShowMenu(dataGridRule1, kryptonContextMenu1);
            }
        }

        private void ShowMenu(Control c, KryptonContextMenu kcm)
        {
            kcm.Show(c.RectangleToScreen(c.ClientRectangle), KryptonContextMenuPositionH.Left,
                     KryptonContextMenuPositionV.Top);
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            DeleteSubstitutionRules();
        }

        /// <summary>
        /// 删除字符替换规则
        /// </summary>
        private void DeleteSubstitutionRules()
        {
            int count = dataGridRule1.SelectedRows.Count;
            for (int i = 0; i < count;)
            {
                if (!dataGridRule1.SelectedRows[i].IsNewRow)
                {
                    dataGridRule1.Rows.Remove(dataGridRule1.SelectedRows[i]);
                    count = dataGridRule1.SelectedRows.Count;
                }
                else
                {
                    dataGridRule1.SelectedRows[i].Selected = false;
                }

            }
        }

        /// <summary>
        /// 删除分隔符
        /// </summary>
        private void DeleteSeparator()
        {
            int count = dataGridRule2.SelectedRows.Count;
            for (int i = 0; i < count;)
            {
                if (!dataGridRule2.SelectedRows[i].IsNewRow)
                {
                    dataGridRule2.Rows.Remove(dataGridRule2.SelectedRows[i]);
                    count = dataGridRule2.SelectedRows.Count;
                }
                else
                {
                    dataGridRule2.SelectedRows[i].Selected = false;
                }

            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            DeleteSeparator();
        }
    }
}
