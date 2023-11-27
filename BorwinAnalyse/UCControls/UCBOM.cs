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
                btnStart.Text = "开始".tr();
                StopAnalyse();
            }
            else
            {
                tokenSource = new CancellationTokenSource();
                kryptonDockableNavigator1.SelectedIndex = 1;
                btnStart.Text = "停止".tr();
                StartAnalyse();
            }
        }

        public void StartAnalyse()
        {
            isStart = true;
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    if (tokenSource.IsCancellationRequested) break;
                    for (int i = 0; i < DataGridView_BOM.RowCount; i++)
                    {

                    }
                    Thread.Sleep(10);
                }

            });
        }

        public void StopAnalyse()
        {
            isStart = false;
            tokenSource?.Cancel();
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
                return;
            }

            Save();
        }

        private void Save()
        {

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
            if (!dt.Columns.Contains(txtColumn1.Text.Trim())|| !dt.Columns.Contains(txtColumn2.Text.Trim()))
            {
                return;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                DataRow row = dt.Rows[i];//DataTable的第i行


                row.BeginEdit();//开始编辑行


                row[txtColumn1.Text.Trim()] = row[txtColumn1.Text.Trim()].ToString()+ " " + row[txtColumn2.Text.Trim()].ToString();//给行的列"columnname"赋值
                row.EndEdit();//结束编辑


                dt.AcceptChanges();//保存修改的结果。     
            }
            dt.Columns.Remove(dt.Columns[txtColumn2.Text.Trim()]);
        }

    }
}
