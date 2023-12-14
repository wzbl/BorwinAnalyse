using BorwinAnalyse.BaseClass;
using BorwinAnalyse.DataBase.Model;
using BorwinAnalyse.Forms;
using ComponentFactory.Krypton.Docking;
using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        DataTable AnalyseDt;
        List<string> codes = new List<string>();
        private void InitUI()
        {
            kryptonDockableNavigator1.SelectedIndex = 0;
            txtName.Text = BomManager.Instance.CurrentBomName;
            AnalyseDt = new DataTable();
            AnalyseDt.Columns.Add("序号");
            AnalyseDt.Columns.Add("barCode");
            AnalyseDt.Columns.Add("description");
            AnalyseDt.Columns.Add("result");
            AnalyseDt.Columns.Add("type");
            AnalyseDt.Columns.Add("size");
            AnalyseDt.Columns.Add("value");
            AnalyseDt.Columns.Add("unit");
            AnalyseDt.Columns.Add("grade");
            AnalyseDt.Columns.Add("exp1");
            AnalyseDt.Columns.Add("exp2");
            AnalyseDt.Columns.Add("exp3");
            AnalyseDt.Columns.Add("exp4");
            AnalyseDt.Columns.Add("exp5");
            //InitDataGrid();
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
                HeaderText = "序号".tr(),
                MinimumWidth = 6,
                Name = "Column1",
                ReadOnly = true,
            },
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
            dt = new DataTable();
            DataGridView_BOM.DataSource = dt;
            DataGridView_BOM.Refresh();
            dt = NOPIHelper.ExcelToDataTable(txtImportPath.Text, true);
            DataGridView_BOM.DataSource = dt;
            DataGridView_BOM.Refresh();
            lbResult.Text = "总数".tr() + ":" + DataGridView_BOM.RowCount;
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
                btnStart.Values.Image = Properties.Resources.icons8_暂停_80;
                StartAnalyse();
            }
        }

        public async void StartAnalyse()
        {
            isStart = true;
            AllCount = 0;
            OKCount = 0;
            NGCount = 0;
            analyseResults.Clear();
            AnalyseDt.Rows.Clear();
            codes.Clear();
            if (chkAnalyseSelectRow.Checked)
            {
                AnalyseSelect();
            }
            else
            {
                //Stopwatch stopwatch = new Stopwatch();
                //stopwatch.Start();
                await AnalyseAll();
                //stopwatch.Stop();
                //MessageBox.Show("解析完成用时"+stopwatch.ElapsedMilliseconds);
            }
            Thread.Sleep(10);
            DataGridView_Result.DataSource = null;
            DataGridView_Result.DataSource = AnalyseDt;
            DataGridView_Result.Refresh();
            btnStart.Values.Image = Properties.Resources.icons8_开始_80;
            isStart = false;
            tokenSource?.Cancel();
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
                    UpdataAnalyseData(new AnalyseResult { BarCode = DataGridView_BOM.SelectedRows[i].Cells[0].Value.ToString() });
                    continue;
                }
                AnalyseResult analyseResult = CommonAnalyse.Instance.AnalyseMethod_copy(DataGridView_BOM.SelectedRows[i].Cells[1].Value.ToString());
                analyseResult.BarCode = DataGridView_BOM.SelectedRows[i].Cells[0].Value.ToString();
                analyseResult.Description = DataGridView_BOM.SelectedRows[i].Cells[1].Value.ToString();
                UpdataAnalyseData(analyseResult);
            }
        }

        /// <summary>
        /// 分析所有行
        /// </summary>
        public async Task AnalyseAll()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < DataGridView_BOM.RowCount; i++)
                {
                    if (tokenSource.IsCancellationRequested) break;
                    if (IsOKRow(i))
                    {
                        string barCode = DataGridView_BOM.Rows[i].Cells[0].Value.ToString();
                        string description = DataGridView_BOM.Rows[i].Cells[1].Value.ToString();
                        description = description.Replace("'", "");
                        string spec = DataGridView_BOM.Rows[i].Cells[2].Value.ToString();
                        AnalyseMethod(barCode, description, spec);
                    }
                }
            }, tokenSource.Token);
        }

        /// <summary>
        /// 判断解析行是否可以解析
        /// </summary>
        /// <returns></returns>
        private bool IsOKRow(int i)
        {
            if (DataGridView_BOM.Rows[i].IsNewRow || DataGridView_BOM.Rows[i].Cells[0].Value == null)
            {
                return false;
            }
            if (string.IsNullOrEmpty(DataGridView_BOM.Rows[i].Cells[0].Value.ToString()))
            {
                return false;
            }
            if (DataGridView_BOM.Rows[i].Cells[1].Value == null)
            {
                UpdataAnalyseData(new AnalyseResult { BarCode = DataGridView_BOM.Rows[i].Cells[0].Value.ToString() });
                return false;
            }

            string barCode = DataGridView_BOM.Rows[i].Cells[0].Value.ToString();
            if (BomManager.Instance.AllBomData.Where(x => x.barCode == barCode).ToList().Count > 0)
            {
                //如果bom中有这个条码就不解析了
                return false;
            }

            if (codes.Contains(barCode))
            {
                //如果条码已经解析了，不再解析
                return false;
            }

            return true;
        }

        public void AnalyseMethod(string barcode, string description, string spec)
        {
            AnalyseResult analyseResult = CommonAnalyse.Instance.AnalyseMethod_copy(description);
            analyseResult.BarCode = barcode;
            analyseResult.Description = description;
            CommonAnalyse.Instance.AnalyWidth(spec, ref analyseResult);
            UpdataAnalyseData(analyseResult);
        }

        public void StopAnalyse()
        {
            isStart = false;
            tokenSource?.Cancel();
        }

        int AllCount = 0;
        int OKCount = 0;
        int NGCount = 0;
        Queue<AnalyseResult> analyseResults = new Queue<AnalyseResult>();

        /// <summary>
        /// 更新解析数据
        /// </summary>
        /// <param name="analyseResult"></param>
        private void UpdataAnalyseData(AnalyseResult analyseResult)
        {
            AnalyseDt.Rows.Add
                (
                           AnalyseDt.Rows.Count,
                           analyseResult.BarCode,
                           analyseResult.Description,
                           analyseResult.Result,
                           analyseResult.Type,
                           analyseResult.Size,
                           analyseResult.Value,
                           analyseResult.Unit,
                           analyseResult.Grade,
                           analyseResult.DefaultFormat(),
                           analyseResult.Width,
                           analyseResult.Space
                );
            if (analyseResult.Result)
            {
                OKCount++;
            }
            else
            {
                NGCount++;
            }
            AllCount++;
            codes.Add(analyseResult.BarCode);
            UpdataResult();
        }

        private void UpdataResult()
        {
            this.Invoke(new Action(() =>
            {
                lbResult.Text = "总数".tr() + ":" + AllCount + "成功".tr() + ":" + OKCount + "失败".tr() + ":" + NGCount;
                if (AllCount % 5000 == 0)
                {
                    DataGridView_Result.DataSource = null;
                    DataGridView_Result.DataSource = AnalyseDt;
                    DataGridView_Result.Refresh();
                }

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
        /// 合并符
        /// </summary>
        private string MergeChar = "";
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

            if (CommonAnalyse.Instance.IsSeparator)
            {
                List<Separator> splitCharList = CommonAnalyse.Instance.Separators.Where(u => u.Enable == true).ToList();
                if (splitCharList.Count > 0)
                {
                    MergeChar = splitCharList[0].Acsii;
                }
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                row.BeginEdit();
                row[txtColumn1.Text.Trim()] = row[txtColumn1.Text.Trim()].ToString() + MergeChar + row[txtColumn2.Text.Trim()].ToString();
                row.EndEdit();
                dt.AcceptChanges();
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
