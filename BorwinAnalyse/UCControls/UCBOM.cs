using BorwinAnalyse.BaseClass;
using BorwinAnalyse.Forms;
using ComponentFactory.Krypton.Docking;
using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorwinAnalyse.UCControls
{
    public partial class UCBOM : UserControl
    {

        CancellationTokenSource tokenSource;
        bool isStart = false;
        public UCBOM()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.components = new System.ComponentModel.Container();
            this.Load += UCBOM_Load;
        }

        private void UCBOM_Load(object sender, EventArgs e)
        {
            InitUI();
            LanguageManager.Instance.UpdateLanguage(this, this.components.Components);
        }

        private void InitUI()
        {
            kryptonDockableNavigator1.SelectedIndex = 0;
            txtName.Text = BomManager.Instance.CurrentBomName;
        }

        /// <summary>
        /// 初始化网格
        /// (id ，barCode , description ,status ,type ,size ,value ,unit ,grade ,exp1 ,exp2 ,exp3 ,exp4 ,exp5 ,createTime)
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void InitDataGrid()
        {
            DataGridView_Result.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            new DataGridViewTextBoxColumn()
            {
                FillWeight = 45.07613F,
                HeaderText = "条码".tr(),
                MinimumWidth = 6,
                Name = "Column1",
                ReadOnly = true,
            },
            new DataGridViewTextBoxColumn()
            {
                FillWeight = 45.07613F,
                HeaderText = "物料描述".tr(),
                MinimumWidth = 6,
                Name = "Column2",
                ReadOnly = true,
            },
            new DataGridViewTextBoxColumn()
            {
                FillWeight = 45.07613F,
                HeaderText = "结果".tr(),
                MinimumWidth = 6,
                Name = "Column3",
                ReadOnly = true,
            },
            new DataGridViewTextBoxColumn()
            {
                FillWeight = 45.07613F,
                HeaderText = "类型".tr(),
                MinimumWidth = 6,
                Name = "Column4",
                ReadOnly = true,
            },
            new DataGridViewTextBoxColumn()
            {
                FillWeight = 45.07613F,
                HeaderText = "尺寸".tr(),
                MinimumWidth = 6,
                Name = "Column5",
                ReadOnly = true,
            },
            new DataGridViewTextBoxColumn()
            {
                FillWeight = 45.07613F,
                HeaderText = "值".tr(),
                MinimumWidth = 6,
                Name = "Column6",
                ReadOnly = true,
            },
                  new DataGridViewTextBoxColumn()
            {
                FillWeight = 45.07613F,
                HeaderText = "单位".tr(),
                MinimumWidth = 6,
                Name = "Column7",
                ReadOnly = true,
            },
            new DataGridViewTextBoxColumn()
            {
                FillWeight = 45.07613F,
                HeaderText = "等级".tr(),
                MinimumWidth = 6,
                Name = "Column8",
                ReadOnly = true,
            },new DataGridViewTextBoxColumn()
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

        }

        DataTable dt;
        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "xlsx|*.xlsx|xls表格|*.xls|XLS|*.XLS";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtImportPath.Text = openFileDialog.FileName;
                if (string.IsNullOrEmpty(txtImportPath.Text)) return;
            }
            else return;

            if (!File.Exists(txtImportPath.Text)) { return; }
            dt = NOPIHelper.ExcelToDataTable(txtImportPath.Text, true);
            DataGridView_BOM.DataSource = dt;
            DataGridView_BOM.Refresh();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (isStart)
            {
                btnStart.Values.Image = Properties.Resources.icons8_开始_80;
                StopAnalyse();

            }
            else
            {
                tokenSource = new CancellationTokenSource();
                kryptonDockableNavigator1.SelectedIndex = 1;
                DataGridView_Result.Rows.Clear();
                btnStart.Values.Image = Properties.Resources.icons8_暂停_80;
                StartAnalyse();
            }
        }

        public void StartAnalyse()
        {
            isStart = true;
            AllCount = 0;
            OKCount = 0;
            NGCount = 0;
            Task.Run(() =>
            {
                if (chkAnalyseSelectRow.Checked)
                {
                    AnalyseSelect();
                }
                else
                {
                    AnalyseAll();
                }

                Thread.Sleep(10);

                this.Invoke(new Action(() =>
                {
                    btnStart.Values.Image = Properties.Resources.icons8_开始_80;

                    DataGridView_Result.Rows.Add
                   (
                          "",
                         "",
                          "",
                      "总数".tr(),
                         AllCount,
                       "成功".tr(),
                       OKCount,
                         "失败",
                         NGCount

                    );
                    DataGridView_Result.FirstDisplayedScrollingRowIndex = DataGridView_Result.RowCount - 1;
                }));
                isStart = false;
                tokenSource?.Cancel();

            }, tokenSource.Token);
        }

        /// <summary>
        /// 分析选中行
        /// </summary>
        public void AnalyseSelect()
        {
            for (int i = 0; i < DataGridView_BOM.SelectedRows.Count; i++)
            {
                if (tokenSource.IsCancellationRequested) break;
                if (DataGridView_BOM.SelectedRows[i].IsNewRow || DataGridView_BOM.SelectedRows[i].Cells[0].Value == null)
                {
                    continue;
                }
                if (string.IsNullOrEmpty(DataGridView_BOM.SelectedRows[i].Cells[0].Value.ToString()))
                {
                    continue;
                }

                if (DataGridView_BOM.SelectedRows[i].Cells[1].Value == null)
                {
                    UpdataAnalyseData(DataGridView_BOM.SelectedRows[i].Cells[0].Value.ToString(), "", new AnalyseResult());
                    continue;
                }
                AnalyseResult analyseResult = CommonAnalyse.Instance.AnalyseMethod(DataGridView_BOM.SelectedRows[i].Cells[1].Value.ToString());
                UpdataAnalyseData(DataGridView_BOM.SelectedRows[i].Cells[0].Value.ToString(), DataGridView_BOM.SelectedRows[i].Cells[1].Value.ToString(), analyseResult);
            }
        }

        /// <summary>
        /// 分析所有行
        /// </summary>
        public void AnalyseAll()
        {
            for (int i = 0; i < DataGridView_BOM.RowCount; i++)
            {
                if (tokenSource.IsCancellationRequested) break;
                if (DataGridView_BOM.Rows[i].IsNewRow || DataGridView_BOM.Rows[i].Cells[0].Value == null)
                {
                    continue;
                }
                if (string.IsNullOrEmpty(DataGridView_BOM.Rows[i].Cells[0].Value.ToString()))
                {
                    continue;
                }
                if (DataGridView_BOM.Rows[i].Cells[1].Value == null)
                {
                    UpdataAnalyseData(DataGridView_BOM.Rows[i].Cells[0].Value.ToString(), "", new AnalyseResult());
                    continue;
                }
                AnalyseResult analyseResult = CommonAnalyse.Instance.AnalyseMethod(DataGridView_BOM.Rows[i].Cells[1].Value.ToString());
                CommonAnalyse.Instance.AnalyWidth(DataGridView_BOM.Rows[i].Cells[2].Value.ToString(),ref analyseResult);
                UpdataAnalyseData(DataGridView_BOM.Rows[i].Cells[0].Value.ToString(), DataGridView_BOM.Rows[i].Cells[1].Value.ToString(), analyseResult);
            }
        }

        public void StopAnalyse()
        {
            isStart = false;
            tokenSource?.Cancel();
        }

        int AllCount = 0;
        int OKCount = 0;
        int NGCount = 0;

        /// <summary>
        /// 更新解析数据
        /// </summary>
        /// <param name="analyseResult"></param>
        private void UpdataAnalyseData(string barCode, string description, AnalyseResult analyseResult)
        {
            this.Invoke(new Action(() =>
            {
                DataGridView_Result.Rows.Add
              (
                 barCode,
                 description,
                 analyseResult.Result,
                 analyseResult.LcrItem.Type,
                 analyseResult.LcrItem.Size,
                 analyseResult.LcrItem.Value,
                 analyseResult.LcrItem.Unit,
                 analyseResult.LcrItem.Grade,
                 analyseResult.LcrItem.DefaultFormat(),
                 analyseResult.Width,
                 analyseResult.Space
              );
                if (analyseResult.Result)
                {
                    OKCount++;
                    DataGridView_Result.Rows[AllCount].Cells[2].Style.BackColor = Color.Green;
                }
                else
                {
                    DataGridView_Result.Rows[AllCount].Cells[2].Style.BackColor = Color.Red;
                    NGCount++;
                }
                AllCount++;

                DataGridView_Result.FirstDisplayedScrollingRowIndex = DataGridView_Result.RowCount - 1;
            }));
        }

        /// <summary>
        /// 保存BOM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("模板名称不能为空".tr());
                return;
            }

            if (BomManager.Instance.BomNames.Contains(txtName.Text))
            {
                MessageBox.Show("模板名称已经存在".tr());
                return;
            }

            Save();
        }

        private void Save()
        {
            BomManager.Instance.SaveInAllBomData(txtName.Text, DataGridView_Result);
            if (MessageBox.Show("保存成功，是否作为当前BOM？".tr(), "提示".tr(), MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                BomManager.Instance.SaveInCurrentBomData(txtName.Text, DataGridView_Result);
                MessageBox.Show("已经设置为当前BOM".tr(), "提示".tr(), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }

        }

        /// <summary>
        /// 合并按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMerge_Click(object sender, EventArgs e)
        {
            Merge();
        }
        /// <summary>
        /// 合并
        /// </summary>
        private void Merge()
        {
            if (dt == null)
            {
                return;
            }
            if (!dt.Columns.Contains(txtColumn1.Text.Trim()) || !dt.Columns.Contains(txtColumn2.Text.Trim()))
            {
                return;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                DataRow row = dt.Rows[i];//DataTable的第i行


                row.BeginEdit();//开始编辑行


                row[txtColumn1.Text.Trim()] = row[txtColumn1.Text.Trim()].ToString() + " " + row[txtColumn2.Text.Trim()].ToString();//给行的列"columnname"赋值
                row.EndEdit();//结束编辑


                dt.AcceptChanges();//保存修改的结果。     
            }
            dt.Columns.Remove(dt.Columns[txtColumn2.Text.Trim()]);
        }

        private void btnShowModelData_Click(object sender, EventArgs e)
        {
            ShowModelData();
        }

        private void ShowModelData()
        {
            AnalyseMainForm.f.ShowModelData();
        }

        private void btnDeleteSelectRow_Click(object sender, EventArgs e)
        {
            if (dt == null)
            {
                return;
            }
            int count = DataGridView_BOM.SelectedRows.Count;
            for (int i = 0; i < count;)
            {
                dt.Rows.RemoveAt(DataGridView_BOM.SelectedRows[i].Index);
                count = DataGridView_BOM.SelectedRows.Count;
            }

        }

        private void btnDeleteSelectColumn_Click(object sender, EventArgs e)
        {
            if (dt == null)
            {
                return;
            }
            if (DataGridView_BOM.SelectedCells.Count > 0)
                dt.Columns.RemoveAt(DataGridView_BOM.SelectedCells[0].ColumnIndex);

        }


    }
}
