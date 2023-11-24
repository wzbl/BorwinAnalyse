using BorwinAnalyse.BaseClass;
using BorwinAnalyse.DataBase.Comm;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NPOI.HSSF.Util.HSSFColor;

namespace BorwinAnalyse.UCControls
{
    public partial class UCSearch : UserControl
    {
        public UCSearch()
        {
            InitializeComponent();
            this.components = new System.ComponentModel.Container();
            this.Load += UCSearch_Load;
        }

        private void UCSearch_Load(object sender, EventArgs e)
        {
            LanguageManager.Instance.UpdateLanguage(this, this.components.Components);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
           
            string cmd = "SELECT context,chinese, english,exp1,exp2, exp3,exp4, exp5 FROM Language";
            if (!string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                cmd = string.Format("select * from Language where context = '{0}'", txtName.Text.Trim());
            }
            DataTable LanguageTable = SqlLiteManager.Instance.DB.Search(cmd, "Language");
            DGV_Language.DataSource = LanguageTable;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (DGV_Language.SelectedRows.Count>0)
            {
                for (int i = 0; i < DGV_Language.SelectedRows.Count; i++)
                {
                    DataGridViewCellCollection row = DGV_Language.SelectedRows[i].Cells;
                    UpdateLanguage(row);
                }
            }
        }

        private void UpdateLanguage(DataGridViewCellCollection row)
        {
            string cmd = string.Format("UPDATE Language SET  chinese = '{0}',english = '{1}',exp1 = '{2}',exp2 = '{3}',exp3 = '{4}',exp4 = '{5}',exp5 = '{6}'  WHERE context = '{7}'", row[1].FormattedValue, row[2].FormattedValue, row[3].FormattedValue, row[4].FormattedValue, row[5].FormattedValue, row[6].FormattedValue, row[7].FormattedValue, row[0].FormattedValue);
            SqlLiteManager.Instance.DB.Search(cmd, "Language");
        }

    }
}
