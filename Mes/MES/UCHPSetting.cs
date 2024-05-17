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

namespace Mes.MES
{
    public partial class UCHPSetting : UCBase
    {
        public UCHPSetting()
        {
            InitializeComponent();
            btnRun.Click += BtnRun_Click;
            btnSave.Click += BtnSave_Click;
            MesIn = MesControl.Instance.HPDataIn;
            MesOut = MesControl.Instance.HPDataOut;
            this.Load += UCHPSetting_Load;
        }

        private void UCHPSetting_Load(object sender, EventArgs e)
        {

        }

        public void Init()
        {
            GetDataMesIn();
            GetDataMesOut();
        }

        public override void GetDataMesIn()
        {
            base.GetDataMesIn();
            DataGridViewInAdd(MesControl.Instance.HPDataIn.BarCode);
            DataGridViewInAdd(MesControl.Instance.HPDataIn.IsLCR);
            DataGridViewInAdd(MesControl.Instance.HPDataIn.Type);
            DataGridViewInAdd(MesControl.Instance.HPDataIn.Size);
            DataGridViewInAdd(MesControl.Instance.HPDataIn.StandValue);
            DataGridViewInAdd(MesControl.Instance.HPDataIn.MaxValue);
            DataGridViewInAdd(MesControl.Instance.HPDataIn.MinValue);
            DataGridViewInAdd(MesControl.Instance.HPDataIn.LCRValue);
        }

        public override void GetDataMesOut()
        {
            base.GetDataMesOut();
            DataGridViewOutAdd(MesControl.Instance.HPDataOut.PN);
            DataGridViewOutAdd(MesControl.Instance.HPDataOut.Qty);
            DataGridViewOutAdd(MesControl.Instance.HPDataOut.DateCode);
            DataGridViewOutAdd(MesControl.Instance.HPDataOut.LotCode);
            DataGridViewOutAdd(MesControl.Instance.HPDataOut.VENDOR);
        }

        public override void SaveDataMesIn()
        {
            for (int i = 0; i < DataGridViewIn.Rows.Count; i++)
            {
                string name = DataGridViewIn.Rows[i].Cells[0].FormattedValue.ToString();
                string key = DataGridViewIn.Rows[i].Cells[1].FormattedValue.ToString();
                string value = DataGridViewIn.Rows[i].Cells[2].FormattedValue.ToString();
                bool.TryParse(DataGridViewIn.Rows[i].Cells[3].FormattedValue.ToString(), out bool enable);
                List<MesValue> mesValues = MesIn.mesInValues.Where(x => x.Name.tr() == name).ToList();
                if (mesValues.Count > 0)
                {
                    mesValues[0].Key = key;
                    mesValues[0].Value = value;
                    mesValues[0].Enable = enable;
                }
            }
        }

        public override void SaveDataMesOut()
        {
            for (int i = 0; i < DataGridViewOut.Rows.Count; i++)
            {
                string name = DataGridViewOut.Rows[i].Cells[0].FormattedValue.ToString();
                string key = DataGridViewOut.Rows[i].Cells[1].FormattedValue.ToString();
                string value = DataGridViewOut.Rows[i].Cells[2].FormattedValue.ToString();
                bool.TryParse(DataGridViewOut.Rows[i].Cells[3].FormattedValue.ToString(), out bool enable);
                List<MesValue> mesValues = MesOut.mesOutValues.Where(x => x.Name.tr() == name).ToList();
                if (mesValues.Count > 0)
                {
                    mesValues[0].Key = key;
                    mesValues[0].Value = value;
                    mesValues[0].Enable = enable;
                }
            }
        }


        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveDataMesIn();
            SaveDataMesOut();
        }

        private void BtnRun_Click(object sender, EventArgs e)
        {

        }
    }
}
