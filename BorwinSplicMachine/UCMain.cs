using BorwinAnalyse.BaseClass;
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

namespace BorwinSplicMachine
{
    public partial class UCMain : UserControl
    {
        public UCMain()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Load += UCMain_Load;
            this.components = new System.ComponentModel.Container();
        }

        private void UCMain_Load(object sender, EventArgs e)
        {
            LanguageManager.Instance.UpdateLanguage(this, this.components.Components);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
            List<BomDataModel> bomDataModels = BomManager.Instance.AllBomData.Where(x => x.barCode == txtBarCode1.Text).ToList<BomDataModel>();
            if (bomDataModels.Count > 0)
            {
                uclcr1.LoadSplic(bomDataModels[0].type, bomDataModels[0].size, bomDataModels[0].value, bomDataModels[0].unit, bomDataModels[0].grade);
            }
            else
            {
                MessageBox.Show("Bom中不存在条码:"+ txtBarCode1.Text);
            }
        }
    }
}
