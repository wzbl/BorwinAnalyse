using BorwinAnalyse.BaseClass;
using BorwinAnalyse.DataBase.Comm;
using BorwinAnalyse.DataBase.Model;
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
    public partial class UCSearchLanguage : UserControl
    {
        public UCSearchLanguage()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            this.Load += UCSearch_Load;
        }
        private void UCSearch_Load(object sender, EventArgs e)
        {
            //LanguageManager.Instance.UpdateLanguage(this, this.components.Components);
        }

        private void initUI()
        {
            DGV_Language.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            new DataGridViewTextBoxColumn()
            {
                FillWeight = 45.07613F,
                HeaderText = "默认文本",
                MinimumWidth = 6,
                Name = "Column1",
                ReadOnly = true,
            },
            new DataGridViewTextBoxColumn()
            {
                FillWeight = 45.07613F,
                HeaderText = "中文",
                MinimumWidth = 6,
                Name = "Column2",
                ReadOnly = true,
            },
            new DataGridViewTextBoxColumn()
            {
                FillWeight = 45.07613F,
                HeaderText = "英文",
                MinimumWidth = 6,
                Name = "Column3",
                ReadOnly = true,
            },
             new DataGridViewTextBoxColumn()
            {
                FillWeight = 45.07613F,
                HeaderText = "exp1",
                MinimumWidth = 6,
                Name = "Column7",
                ReadOnly = true,
            },
            new DataGridViewTextBoxColumn()
            {
                FillWeight = 45.07613F,
                HeaderText = "exp2",
                MinimumWidth = 6,
                Name = "Column7",
                ReadOnly = true,
            },
            new DataGridViewTextBoxColumn()
            {
                FillWeight = 45.07613F,
                HeaderText = "exp3",
                MinimumWidth = 6,
                Name = "Column7",
                ReadOnly = true,
            },
            new DataGridViewTextBoxColumn()
            {
                FillWeight = 45.07613F,
                HeaderText = "exp4",
                MinimumWidth = 6,
                Name = "Column7",
                ReadOnly = true,
            },
            new DataGridViewTextBoxColumn()
            {
                FillWeight = 45.07613F,
                HeaderText = "exp5",
                MinimumWidth = 6,
                Name = "Column7",
                ReadOnly = true,
            }
            });
            for (int i = 0; i < DGV_Language.ColumnCount; i++)
            {
                if (i == 0)
                {
                    DGV_Language.Columns[i].ReadOnly = true;
                }
                else
                {
                    DGV_Language.Columns[i].ReadOnly = false;
                }

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            List<Language> languages;
            if (!string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                string context = txtName.Text.Trim();
                languages = LanguageManager.Instance.languages.Where(x => x.context == context || x.chinese == context || x.english == context).ToList<Language>();
            }
            else
            {
                languages = LanguageManager.Instance.languages;
            }
            DGV_Language.Rows.Clear();
            if (languages != null)
            {
                foreach (var item in languages)
                {
                    DGV_Language.Rows.Add(
                        item.context,
                        item.chinese,
                        item.english,
                        item.exp1,
                        item.exp2,
                        item.exp3,
                        item.exp4,
                        item.exp5
                  );
                }
                DGV_Language.Refresh();
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (DGV_Language.SelectedRows.Count > 0)
            {
                for (int i = 0; i < DGV_Language.SelectedRows.Count; i++)
                {
                    DataGridViewCellCollection row = DGV_Language.SelectedRows[i].Cells;
                    UpdateLanguage(row);
                }
            }
            Search();
        }

        private void UpdateLanguage(DataGridViewCellCollection row)
        {
            if (string.IsNullOrEmpty(row[0].FormattedValue.ToString()))
            {
                return;
            }
            List<Language> languages = LanguageManager.Instance.languages.Where(x => x.context == row[0].FormattedValue.ToString()).ToList();
            if (languages.Count() > 0)
                LanguageManager.Instance.languages.Remove(languages[0]);
            Language language1 = new Language();
            language1.context = row[0].FormattedValue.ToString();
            language1.chinese = row[1].FormattedValue.ToString();
            language1.english = row[2].FormattedValue.ToString();
            language1.exp1 = row[3].FormattedValue.ToString();
            language1.exp2 = row[4].FormattedValue.ToString();
            language1.exp3 = row[5].FormattedValue.ToString();
            language1.exp4 = row[6].FormattedValue.ToString();
            language1.exp5 = row[7].FormattedValue.ToString();
            string cmd = string.Format("UPDATE Language SET  chinese = '{0}',english = '{1}',exp1 = '{2}',exp2 = '{3}',exp3 = '{4}',exp4 = '{5}',exp5 = '{6}'  WHERE context = '{7}'", language1.context, language1.english, language1.exp1, language1.exp2, language1.exp3, language1.exp4, language1.exp5, language1.context);
            SqlLiteManager.Instance.DB.Search(cmd, "Language");
            LanguageManager.Instance.languages.Add(language1);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (DGV_Language.SelectedRows.Count > 0)
            {
                for (int i = 0; i < DGV_Language.SelectedRows.Count; i++)
                {
                    DataGridViewCellCollection row = DGV_Language.SelectedRows[i].Cells;
                    DeleteLanguage(row);
                }
            }
            Search();
        }

        private void DeleteLanguage(DataGridViewCellCollection row)
        {
            if (string.IsNullOrEmpty(row[0].FormattedValue.ToString()))
            {
                return;
            }
            List<Language> languages = LanguageManager.Instance.languages.Where(x => x.context == row[0].FormattedValue.ToString()).ToList();
            if (languages.Count() > 0)
                LanguageManager.Instance.languages.Remove(languages[0]);
            string context = row[0].FormattedValue.ToString();
            string cmd = string.Format("Delete from Language  WHERE context = '{0}'", context);
            SqlLiteManager.Instance.DB.Search(cmd, "Language");


        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dt = NOPIHelper.ToDataTable(DGV_Language);
            NOPIHelper.ExportDataToExcel(dt);
        }

        private void btnImPort_Click(object sender, EventArgs e)
        {
            DataTable dt = NOPIHelper.ImportExcel();
            if (dt==null) { return; }
            DGV_Language.Rows.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DGV_Language.Rows.Add(
                      dt.Rows[i].ItemArray[0],
                      dt.Rows[i].ItemArray[1],
                      dt.Rows[i].ItemArray[2],
                      dt.Rows[i].ItemArray[3],
                      dt.Rows[i].ItemArray[4],
                      dt.Rows[i].ItemArray[5],
                      dt.Rows[i].ItemArray[6],
                      dt.Rows[i].ItemArray[7]
                );
            }

            if (MessageBox.Show("导入成功，是否保存？".tr(), "提示".tr(), MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                SaveImport();
                LanguageManager.Instance.SearchALLLanguage();
                Search();
            }
        }

        private void SaveImport()
        {
            string comms = "DELETE FROM Language";
            SqlLiteManager.Instance.DB.Insert(comms);
            for (int i = 0; i < DGV_Language.Rows.Count; i++)
            {
                Language language1 = new Language();
                language1.context = DGV_Language.Rows[i].Cells[0].FormattedValue.ToString();
                language1.chinese = DGV_Language.Rows[i].Cells[1].FormattedValue.ToString();
                language1.english = DGV_Language.Rows[i].Cells[2].FormattedValue.ToString();
                language1.exp1 = DGV_Language.Rows[i].Cells[3].FormattedValue.ToString();
                language1.exp2 = DGV_Language.Rows[i].Cells[4].FormattedValue.ToString();
                language1.exp3 = DGV_Language.Rows[i].Cells[5].FormattedValue.ToString();
                language1.exp4 = DGV_Language.Rows[i].Cells[6].FormattedValue.ToString();
                language1.exp5 = DGV_Language.Rows[i].Cells[7].FormattedValue.ToString();
                string cmd = string.Format("insert into Language values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", language1.context, language1.chinese, language1.english, language1.exp1, language1.exp2, language1.exp3, language1.exp4, language1.exp5);
                SqlLiteManager.Instance.DB.Insert(cmd);
            }

            for (int i = 0; i < DGV_Language.Columns.Count; i++)
            {
                DGV_Language.Columns[i].HeaderText = DGV_Language.Columns[i].HeaderText.tr();
            }
        }
    }
}
