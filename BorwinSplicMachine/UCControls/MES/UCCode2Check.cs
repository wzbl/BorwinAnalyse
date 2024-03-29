﻿using Mes;
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
    public partial class UCCode2Check : UCBase
    {
        public UCCode2Check()
        {
            InitializeComponent();
            this.Load += UCCode1Check_Load;
            btnRun.Click += BtnRun_Click;
            btnSave.Click += BtnSave_Click;
            MesIn = MesControl.Instance.checkInCode2;
            MesOut = MesControl.Instance.checkOutCode2;
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
            Dictionary<string, string> datas = new Dictionary<string, string>();
            foreach (var item in mesInValues)
            {
                if (item.Enable && item != MesControl.Instance.checkInCode1.IsEnable && item != MesControl.Instance.checkInCode1.URL)
                {
                    datas.Add(item.Key, item.Value);
                }
            }
            string json = JsonConvert.SerializeObject(datas, Formatting.Indented);
            Form1.MainControl.UCMes.richLog.Text += "登入上传mes" + json;
            string res = UpData(json);
        }

        public string UpData(string json)
        {
            WebApiHelper webApiHelper = new WebApiHelper();
            return webApiHelper.HttpPost(MesIn.URL.Value, json);
        }

        private void UCMesLogin_Load(object sender, EventArgs e)
        {
            GetDataMesIn();
            GetDataMesOut();
        }

        public override void GetDataMesIn()
        {
            base.GetDataMesIn();
            DataGridViewInAdd(MesControl.Instance.checkInCode2.Code1);
            DataGridViewInAdd(MesControl.Instance.checkInCode2.Code2);

        }

        public override void GetDataMesOut()
        {
            base.GetDataMesOut();
        }

        public override void SaveDataMesIn()
        {
            for (int i = 0; i < DataGridViewIn.Rows.Count; i++)
            {
                string name = DataGridViewIn.Rows[i].Cells[0].FormattedValue.ToString();
                string key = DataGridViewIn.Rows[i].Cells[1].FormattedValue.ToString();
                string value = DataGridViewIn.Rows[i].Cells[2].FormattedValue.ToString();
                bool.TryParse(DataGridViewIn.Rows[i].Cells[3].FormattedValue.ToString(), out bool enable);
                List<MesValue> mesValues = mesInValues.Where(x => x.Name == name).ToList();
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
                List<MesValue> mesValues = mesOutValues.Where(x => x.Name == name).ToList();
                if (mesValues.Count > 0)
                {
                    mesValues[0].Key = key;
                    mesValues[0].Value = value;
                    mesValues[0].Enable = enable;
                }
            }
            GetDataMesOut();
        }

        private void UCCode1Check_Load(object sender, EventArgs e)
        {
            GetDataMesIn();
            GetDataMesOut();
        }
    }
}
