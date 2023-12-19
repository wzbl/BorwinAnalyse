using BorwinAnalyse.BaseClass;
using BorwinAnalyse.DataBase.Comm;
using BorwinAnalyse.DataBase.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorwinAnalyse.UCControls
{
    public partial class UCSearchBom : UserControl
    {
        public UCSearchBom()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            this.Load += UCSearchBom_Load;
            this.components = new System.ComponentModel.Container();
        }

        private void UCSearchBom_Load(object sender, EventArgs e)
        {
            ComModelUpdata();
            LanguageManager.Instance.UpdateLanguage(this, this.components.Components);
        }

        /// <summary>
        /// 更新模板下拉框
        /// </summary>
        public void ComModelUpdata()
        {
            comModelName.Items.Clear();
            comModelName.Items.Add("ALL");
            for (int i = 0; i < BomManager.Instance.BomNames.Count; i++)
            {
                comModelName.Items.Add(BomManager.Instance.BomNames[i]);
                if (BomManager.Instance.CurrentBomName == BomManager.Instance.BomNames[i])
                {
                    comModelName.SelectedIndex = i;
                    comModelName.Text = BomManager.Instance.CurrentBomName;
                }
            }
        }


        private void btnSearchBom_Click(object sender, EventArgs e)
        {
            btnSearchBom.Enabled = false;
            Search();
        }


        public async void Search()
        {
            List<BomDataModel> bomDataModels;
            if (comModelName.Text == "ALL")
            {
                bomDataModels = BomManager.Instance.AllBomData;
            }
            else
            {
                bomDataModels = BomManager.Instance.AllBomData.Where(x => x.modelName == comModelName.Text).ToList<BomDataModel>();
            }
            gridBomData.Rows.Clear();
            if (bomDataModels != null)
            {
                await Task.Run(() =>
                {
                    foreach (var item in bomDataModels)
                    {
                        this.Invoke(new Action(() =>
                        {
                            gridBomData.Rows.Add(
                            gridBomData.RowCount + "_" + item.id,
                                item.modelName,
                                item.barCode,
                                item.replaceCode,
                                item.description,
                                item.result,
                                item.type,
                                item.size,
                                item.value,
                                item.unit,
                                item.grade,
                                item.exp1,
                                item.exp2,
                                item.exp3,
                                item.exp4,
                                item.exp5
                          );
                           
                            if (gridBomData.RowCount % 5000 == 0)
                            {
                                gridBomData.Refresh();
                            }
                        }));
                    }
                });
                gridBomData.Refresh();
            }
            btnSearchBom.Enabled = true;
        }

        private void btnUpdataBom_Click(object sender, EventArgs e)
        {
            if (gridBomData.SelectedRows.Count > 0)
            {
                for (int i = 0; i < gridBomData.SelectedRows.Count; i++)
                {
                    DataGridViewCellCollection row = gridBomData.SelectedRows[i].Cells;
                    UpdataBomData(row);
                }
                BomManager.Instance.Init();
                Search();
            }

        }

        private void UpdataBomData(DataGridViewCellCollection row)
        {
            if (string.IsNullOrEmpty(row[0].FormattedValue.ToString()))
            {
                return;
            }
            BomDataModel bomDataModel = new BomDataModel();
            bomDataModel.id = row[0].FormattedValue.ToString();
            bomDataModel.modelName = row[1].FormattedValue.ToString();
            bomDataModel.barCode = row[2].FormattedValue.ToString();
            bomDataModel.replaceCode = row[3].FormattedValue.ToString();
            bomDataModel.description = row[4].FormattedValue.ToString();
            bomDataModel.result = row[5].FormattedValue.ToString();
            bomDataModel.type = row[6].FormattedValue.ToString();
            bomDataModel.size = row[7].FormattedValue.ToString();
            bomDataModel.value = row[8].FormattedValue.ToString();
            bomDataModel.unit = row[9].FormattedValue.ToString();
            bomDataModel.grade = row[10].FormattedValue.ToString();
            bomDataModel.exp1 = row[11].FormattedValue.ToString();
            bomDataModel.exp2 = row[12].FormattedValue.ToString();
            bomDataModel.exp3 = row[13].FormattedValue.ToString();
            bomDataModel.exp4 = row[14].FormattedValue.ToString();
            bomDataModel.exp5 = row[15].FormattedValue.ToString();
            BomManager.Instance.UpdataBomData(bomDataModel);
        }

        private void btnDeleteModel_Click(object sender, EventArgs e)
        {
            BomManager.Instance.DeleteModel(comModelName.Text);
            ComModelUpdata();
        }

        private void btnSetModel_Click(object sender, EventArgs e)
        {
            if (BomManager.Instance.BomNames.Contains(comModelName.Text))
            {
                BomManager.Instance.SetCurrentModel(comModelName.Text);
                MessageBox.Show("设为模板成功");
            }

        }

        private void btnAddBom_Click(object sender, EventArgs e)
        {
            if (!BomManager.Instance.BomNames.Contains(comModelName.Text))
            {
                MessageBox.Show("未选择模板".tr());
                return;
            }
            if (string.IsNullOrEmpty(txtbarCode.Text))
            {
                MessageBox.Show("未输入条码".tr());
                return;
            }
            if (BomManager.Instance.AllBomData.Where(x => x.barCode == txtbarCode.Text).ToList<BomDataModel>().ToList().Count > 0)
            {
                MessageBox.Show("当前条码已存在".tr());
                return;
            }


            BomDataModel bomDataModel = new BomDataModel();
            bomDataModel.id = Guid.NewGuid().ToString();
            bomDataModel.modelName = comModelName.Text;
            bomDataModel.barCode = txtbarCode.Text;
            bomDataModel.description = txtDescription.Text;
            bomDataModel.type = txtType.Text;
            bomDataModel.result = txtResult.Text;
            bomDataModel.size = txtSize.Text;
            bomDataModel.value = txtValue.Text;
            bomDataModel.unit = txtUnit.Text;
            bomDataModel.grade = txtGrade.Text;
            bomDataModel.exp1 = string.Format("{0}-{1}-{2}-{3}-{4}", bomDataModel.type, bomDataModel.size, bomDataModel.value, bomDataModel.unit, bomDataModel.grade);
            bomDataModel.exp2 = txtWidth.Text;
            bomDataModel.exp3 = txtPitch.Text;
            BomManager.Instance.InserIntoBomData(bomDataModel);
            Search();
        }

        /// <summary>
        /// 双击时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridBomData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0) return;
            txtbarCode.Text = gridBomData.Rows[index].Cells[2].FormattedValue.ToString();
            txtDescription.Text = gridBomData.Rows[index].Cells[4].FormattedValue.ToString();
            txtResult.Text = gridBomData.Rows[index].Cells[5].FormattedValue.ToString();
            txtType.Text = gridBomData.Rows[index].Cells[6].FormattedValue.ToString();
            txtSize.Text = gridBomData.Rows[index].Cells[7].FormattedValue.ToString();
            txtValue.Text = gridBomData.Rows[index].Cells[8].FormattedValue.ToString();
            txtUnit.Text = gridBomData.Rows[index].Cells[9].FormattedValue.ToString();
            txtGrade.Text = gridBomData.Rows[index].Cells[10].FormattedValue.ToString();
            txtWidth.Text = gridBomData.Rows[index].Cells[12].FormattedValue.ToString();
            txtPitch.Text = gridBomData.Rows[index].Cells[13].FormattedValue.ToString();
        }

        private void btnSearchByCode_Click(object sender, EventArgs e)
        {
            List<BomDataModel> bomDataModels;
            bomDataModels = BomManager.Instance.AllBomData.Where(x => x.barCode == txtbarCode.Text).ToList<BomDataModel>();
            gridBomData.Rows.Clear();

            if (bomDataModels != null)
            {
                foreach (var item in bomDataModels)
                {
                    gridBomData.Rows.Add(
                        item.id,
                        item.modelName,
                        item.barCode,
                        item.replaceCode,
                        item.description,
                        item.result,
                        item.type,
                        item.size,
                        item.value,
                        item.unit,
                        item.grade,
                        item.exp1,
                        item.exp2,
                        item.exp3,
                        item.exp4,
                        item.exp5
                  );
                }
                gridBomData.Refresh();
            }
        }
    }
}
