using BorwinAnalyse.BaseClass;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Mes.MES
{
    public partial class UCHP : UserControl
    {
        public UCHP()
        {
            InitializeComponent();
            this.Load += UCHP_Load;
            Dock = DockStyle.Fill;
            MesControl.Instance.ActionHPResult += ActionHPResult;
        }

        /// <summary>
        /// 合盘,打印信息
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void ActionHPResult()
        {
            for (int i = 0; i < BartenderPrintModel.Instance.PrintValues.Count; i++)
            {
                if (BartenderPrintModel.Instance.PrintValues[i].Enable&& BartenderPrintModel.Instance.PrintValues[i].Name!="QR")
                {
                    string name = BartenderPrintModel.Instance.PrintValues[i].Name;
                    List<MesValue> mesValues = MesControl.Instance.HPDataOut.mesOutValues.Where(x => x.Key == name).ToList();
                    if (mesValues.Count > 0)
                    {
                        BartenderPrintModel.Instance.PrintValues[i].Value = mesValues[0].Value;
                    }
                    else
                    {
                        MessageBox.Show("系统返回缺少字段".tr() + ":" + name + "," + "请确认打印信息与系统返回是否无误".tr());
                        return;
                    }
                }
            }
            BartenderPrintModel.Instance.Print();
        }

        private void UCHP_Load(object sender, EventArgs e)
        {
            DataGridViewOut.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridViewInAdd();
            MesControl.Instance.ActionHPAdd += ActionHPAdd;
        }

        private void ActionHPAdd(HPDataIn data)
        {
            DataRow dr = dt.NewRow();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string key = dt.Columns[i].ColumnName;
                data.GetValue(key, out string val);
                dr[i] = val;
            }
            dt.Rows.Add(dr);
            this.Invoke(new Action(() =>
            {
                DataGridViewOut.Refresh();
            }));

        }


        public void DataGridViewInAdd()
        {
            DataGridViewOut.DataSource = null;
            dt = new DataTable();
            foreach (var item in MesControl.Instance.HPDataIn.mesInValues)
            {
                if (item.Enable && item != MesControl.Instance.HPDataIn.IsEnable && item != MesControl.Instance.HPDataIn.URL && item != MesControl.Instance.HPDataIn.WebFunName && item != MesControl.Instance.HPDataIn.WebFunName_Xmlns && item != MesControl.Instance.HPDataIn.WebParamName_Xmlns)
                {
                    DataGridViewHead(item.Key);
                }
            }
            List<HPDataIn> hPDatas = MesControl.Instance.HPDataList.GetDatas();
            for (int i = 0; i < hPDatas.Count; i++)
            {
                ActionHPAdd(hPDatas[i]);
            }
            DataGridViewOut.DataSource = dt;
            DataGridViewOut.Refresh();
        }
        System.Data.DataTable dt = new DataTable();
        public void DataGridViewHead(string Key)
        {
            dt.Columns.Add(Key);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("删除最后一行?".tr(), "警告".tr(), MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (dt.Rows.Count > 0)
                {
                    //int index = DataGridViewOut.RowCount-1;
                    //string CodeKey = MesControl.Instance.HPDataIn.BarCode.Key;
                    //string barcode = DataGridViewOut.SelectedRows[index].Cells[CodeKey].Value.ToString().Trim();
                    MesControl.Instance.HPDataList.Delete();
                    dt.Rows.RemoveAt(dt.Rows.Count - 1);
                    DataGridViewOut.Refresh();
                }
            }

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count < 2)
            {
                MessageBox.Show("当前合盘数量小于2,无法执行合盘".tr());
                return;
            }
            MesControl.Instance.CurrentType = InterType.合盘;
            List<string> keys = new List<string>();
            List<object> list = new List<object>();

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                keys.Add(dt.Columns[i].ColumnName.ToString());
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SortedList sl = new SortedList();
                for (int j = 0; j < keys.Count; j++)
                {
                    string key = keys[j].ToString();
                    string val = dt.Rows[i].ItemArray[j].ToString();
                    sl.Add(key, val);
                }
                list.Add(sl);

            }
           
            SortedList s2 = new SortedList();
            s2.Add(MesControl.Instance.HPDataIn.InterFaceNo.Key, MesControl.Instance.HPDataIn.InterFaceNo.Value);
            s2.Add("list", list);
            string json = JsonConvert.SerializeObject(s2);
            MesControl.Instance.UpData(InterType.合盘, MesControl.Instance.HPDataIn.URL.Value, json);

        }


    }

  

}
