using BorwinAnalyse.BaseClass;
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
    public partial class UCPrint : UserControl
    {
        public UCPrint()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Load += UCPrint_Load;
            BartenderPrintModel.Instance.Load();
            this.components = new System.ComponentModel.Container();
        }

        private void UCPrint_Load(object sender, EventArgs e)
        {
            comPrintName.Text = BartenderPrintModel.Instance.Name;
            txtPath.Text = BartenderPrintModel.Instance.Path;
            RefreshData();
            GetPrinter();
            UpdataLanguage();
        }

        /// <summary>
        /// 获取本地已安装的打印机
        /// </summary>
        /// <returns></returns>
        public void GetPrinter()
        {
            System.Drawing.Printing.PrinterSettings.StringCollection PrinterList = System.Drawing.Printing.PrinterSettings.InstalledPrinters;
            foreach (var item in PrinterList)
            {
                comPrintName.Items.Add(item);
            }
        }

        private void RefreshData()
        {
            kryptonDataGridView1.Rows.Clear();
            for (int i = 0; i < BartenderPrintModel.Instance.PrintValues.Count; i++)
            {
                kryptonDataGridView1.Rows.Add(
                    BartenderPrintModel.Instance.PrintValues[i].Name,
                    BartenderPrintModel.Instance.PrintValues[i].Key,
                    BartenderPrintModel.Instance.PrintValues[i].Value,
                    BartenderPrintModel.Instance.PrintValues[i].Enable
                );
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (kryptonDataGridView1.SelectedRows.Count > 0)
                kryptonDataGridView1.Rows.RemoveAt(kryptonDataGridView1.SelectedRows[0].Index);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            BartenderPrintModel.Instance.Name = comPrintName.Text;
            BartenderPrintModel.Instance.Path = txtPath.Text;
            RefreshRow();
            BartenderPrintModel.Instance.Save();
        }

        public void RefreshRow()
        {
            BartenderPrintModel.Instance.PrintValues.Clear();
            for (int i = 0; i < kryptonDataGridView1.Rows.Count; i++)
            {
                if (kryptonDataGridView1.Rows[i].Cells[0].Value != null)
                {
                    string name = kryptonDataGridView1.Rows[i].Cells[0].Value == null ? "" : kryptonDataGridView1.Rows[i].Cells[0].Value.ToString();
                    string key = kryptonDataGridView1.Rows[i].Cells[1].Value == null ? "" : kryptonDataGridView1.Rows[i].Cells[1].Value.ToString();
                    string value = kryptonDataGridView1.Rows[i].Cells[2].Value == null ? "" : kryptonDataGridView1.Rows[i].Cells[2].Value.ToString();
                    PrintValue printValue = new PrintValue
                        (
                        name,
                        key,
                        value,
                        (bool)kryptonDataGridView1.Rows[i].Cells[3].Value
                        );
                    BartenderPrintModel.Instance.PrintValues.Add(printValue);
                }
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            BartenderPrintModel.Instance.Print();
        }

        public void UpdataLanguage()
        {
            LanguageManager.Instance.UpdateLanguage(this, this.components.Components);
        }
    }
}
