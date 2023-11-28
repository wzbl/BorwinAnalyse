using BorwinAnalyse.BaseClass;
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
        }

        private void UCSearchBom_Load(object sender, EventArgs e)
        {
            ComModelUpdata();
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
            Search();
        }

        public void Search()
        {
            List<BomDataModel> bomDataModels;
            if (comModelName.Text == "ALL")
            {
                bomDataModels = BomManager.Instance.AllBomData;
            }
            else
            {
                bomDataModels = BomManager.Instance.AllBomData.Where(x => x.modelName == comModelName.Text ).ToList<BomDataModel>();
            }
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

        private void btnUpdataBom_Click(object sender, EventArgs e)
        {

        }
        private void btnDeleteBom_Click(object sender, EventArgs e)
        {

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
    }
}
