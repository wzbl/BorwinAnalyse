using BorwinAnalyse.BaseClass;
using Mes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorwinSplicMachine.UCControls.MES
{
    public partial class UCMesLogin : UCBase
    {
        public UCMesLogin()
        {
            InitializeComponent();
            this.Load += UCMesLogin_Load;
            btnRun.Click += BtnRun_Click;
            btnSave.Click += BtnSave_Click;
            MesIn = MesControl.Instance.loginIn;
            MesOut = MesControl.Instance.loginOut;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Save();
            MesControl.Instance.Save();
        }

        public void Save()
        {
            SaveDataMesIn();
            SaveDataMesOut();
        }

        private void BtnRun_Click(object sender, EventArgs e)
        {
            Updata(InterType.登录);
            GetDataMesOut();
        }

        public void Init()
        {
            GetDataMesIn();
            GetDataMesOut();
        }


        private void UCMesLogin_Load(object sender, EventArgs e)
        {
           
        }

        public override void GetDataMesIn()
        {
            base.GetDataMesIn();
            DataGridViewInAdd(MesControl.Instance.loginIn.Pwd);
        }

        public override void GetDataMesOut()
        {
            base.GetDataMesOut();
            DataGridViewOutAdd(MesControl.Instance.loginOut.StrToken);
        }

        public override void SaveDataMesIn()
        {
            for (int i = 0; i < DataGridViewIn.Rows.Count; i++)
            {
                string name = DataGridViewIn.Rows[i].Cells[0].FormattedValue.ToString();
                string key = DataGridViewIn.Rows[i].Cells[1].FormattedValue.ToString();
                string value = DataGridViewIn.Rows[i].Cells[2].FormattedValue.ToString();
                bool.TryParse(DataGridViewIn.Rows[i].Cells[3].FormattedValue.ToString(), out bool enable);
                List<MesValue> mesValues = mesInValues.Where(x => x.Name.tr() == name).ToList();
                if (mesValues.Count > 0)
                {
                    mesValues[0].Key = key;
                    mesValues[0].Value = value;
                    mesValues[0].Enable = enable;
                }
            }
            GetDataMesIn();
        }

        public override void SaveDataMesOut()
        {
            for (int i = 0; i < DataGridViewOut.Rows.Count; i++)
            {
                string name = DataGridViewOut.Rows[i].Cells[0].FormattedValue.ToString();
                string key = DataGridViewOut.Rows[i].Cells[1].FormattedValue.ToString();
                string value = DataGridViewOut.Rows[i].Cells[2].FormattedValue.ToString();
                bool.TryParse(DataGridViewOut.Rows[i].Cells[3].FormattedValue.ToString(), out bool enable);
                List<MesValue> mesValues = mesOutValues.Where(x => x.Name.tr() == name).ToList();
                if (mesValues.Count > 0)
                {
                    mesValues[0].Key = key;
                    mesValues[0].Value = value;
                    mesValues[0].Enable = enable;
                }
            }
            GetDataMesOut();
        }
    }
}
