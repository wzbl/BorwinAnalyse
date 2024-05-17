using BorwinAnalyse.BaseClass;
using Mes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mes
{
    public partial class UCCode1Check : UCBase
    {
        public UCCode1Check()
        {
            InitializeComponent();
            this.Load += UCCode1Check_Load;
            btnRun.Click += BtnRun_Click;
            btnSave.Click += BtnSave_Click;
            MesIn = MesControl.Instance.checkInCode1;
            MesOut = MesControl.Instance.checkOutCode1;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        public void Save()
        {
            SaveDataMesIn();
            SaveDataMesOut();
        }

        private void BtnRun_Click(object sender, EventArgs e)
        {
            MesControl.Instance.Updata(InterType.条码1检验);
        }

        public void Init()
        {
            GetDataMesIn();
            GetDataMesOut();
        }

        public override void GetDataMesIn()
        {
            base.GetDataMesIn();
            DataGridViewInAdd(MesControl.Instance.checkInCode1.Code);
        }

        public override void GetDataMesOut()
        {
            base.GetDataMesOut();
            DataGridViewOutAdd(MesControl.Instance.checkOutCode1.IsLCR);
            DataGridViewOutAdd(MesControl.Instance.checkOutCode1.MaterialDes);
            DataGridViewOutAdd(MesControl.Instance.checkOutCode1.Type);
            DataGridViewOutAdd(MesControl.Instance.checkOutCode1.Size);
            DataGridViewOutAdd(MesControl.Instance.checkOutCode1.Value);
            DataGridViewOutAdd(MesControl.Instance.checkOutCode1.MaxValue);
            DataGridViewOutAdd(MesControl.Instance.checkOutCode1.MinValue);
            DataGridViewOutAdd(MesControl.Instance.checkOutCode1.Unit);
            DataGridViewOutAdd(MesControl.Instance.checkOutCode1.Grade);
            DataGridViewOutAdd(MesControl.Instance.checkOutCode1.IsMatch);
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

            if (!MesControl.Instance.checkOutCode1.Type.Enable)
            {
                MessageBox.Show("类型必须选");
            }

            if (!MesControl.Instance.checkOutCode1.Unit.Enable)
            {
                MessageBox.Show("单位必须选");
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

        private void UCCode1Check_Load(object sender, EventArgs e)
        {

        }
    }
}
