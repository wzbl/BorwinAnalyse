using BorwinAnalyse.BaseClass;
using Mes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorwinSplicMachine.UCControls.MES
{
    public partial class UCBase : UserControl
    {
        public List<MesValue> mesInValues = new List<MesValue>();
        public List<MesValue> mesOutValues = new List<MesValue>();
        public MesIn MesIn;
        public MesOut MesOut;
        public static InterType CurrentType = InterType.登录;
        public UCBase()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }


        public virtual void GetDataMesIn()
        {
            DataGridViewIn.Rows.Clear();
            mesInValues.Clear();
            MesIn.Line.Value = MesControl.Instance.Line;
            MesIn.Wo.Value = MesControl.Instance.Wo;
            MesIn.MachineCode.Value = MesControl.Instance.MachineCode;
            MesIn.UserName.Value = "Admin";
            DataGridViewInAdd(MesIn.IsEnable);
            DataGridViewInAdd(MesIn.URL);
            DataGridViewInAdd(MesIn.Line);
            DataGridViewInAdd(MesIn.MachineCode);
            DataGridViewInAdd(MesIn.Wo);
            DataGridViewInAdd(MesIn.UserName);
            DataGridViewInAdd(MesIn.InterFaceNo);
        }

        protected void DataGridViewInAdd(MesValue mesValue)
        {
            mesInValues.Add(mesValue);
            DataGridViewIn.Rows.Add(
              mesValue.Name.tr(),
              mesValue.Key,
              mesValue.Value,
              mesValue.Enable
              );
        }
        protected void DataGridViewOutAdd(MesValue mesValue)
        {
            mesOutValues.Add(mesValue);
            DataGridViewOut.Rows.Add(
             mesValue.Name.tr(),
             mesValue.Key,
             mesValue.Value,
             mesValue.Enable
             );
        }

        public virtual void GetDataMesOut()
        {
            DataGridViewOut.Rows.Clear();
            mesOutValues.Clear();
            DataGridViewOutAdd(MesOut.Result);
            DataGridViewOutAdd(MesOut.ErrorMsg);
            DataGridViewOutAdd(MesOut.ErrorCode);
            DataGridViewOutAdd(MesOut.InterFaceNo);
        }


        public void Updata(InterType interType)
        {
            CurrentType = interType;
            Dictionary<string, string> datas = new Dictionary<string, string>();
            foreach (var item in mesInValues)
            {
                if (item.Enable && item != MesIn.IsEnable && item != MesIn.URL)
                {
                    datas.Add(item.Key, item.Value);
                }
            }
            string json = JsonConvert.SerializeObject(datas, Formatting.Indented);
            string res = MesControl.Instance.UpData(interType, MesIn.URL.Value, json);
            if (res != MesType.Socket.ToString())
            {
                AnalyData(res);
                GetDataMesOut();
            }
        }

        /// <summary>
        /// 解析mes返回数据
        /// </summary>
        /// <param name="res"></param>
        public void AnalyData(string res)
        {
            try
            {
                foreach (MesValue pv in mesOutValues)
                    pv.Value = "";
                dynamic o = JsonConvert.DeserializeObject(res);
                if (o != null)
                {
                    string s = o.ToString();
                    s = s.Replace("\\", "");
                    o = JsonConvert.DeserializeObject(s);
                }

                foreach (MesValue pv in mesOutValues)
                {
                    try
                    {
                        if (pv.Enable)
                        {
                            string key = pv.Key;

                            string val = o[key];

                            if (val != null)
                            {
                                pv.Value = val;
                            }

                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                MesOut.ErrorMsg.Value = res;
            }

            switch (CurrentType)
            {
                case InterType.登录:
                    AnalyLogin();
                    break;
                case InterType.条码1检验:
                    AnalyCheckCode1();
                    break;
                case InterType.条码2检验:
                    AnalyCheckCode2();
                    break;
                case InterType.上传信息:
                    AnalyUpData();
                    break;
                default:
                    break;
            }
        }

        private void AnalyLogin()
        {
            if (MesOut.Result.Value == "OK")
            {

            }
            else
            {

            }
        }

        private void AnalyCheckCode1()
        {
            if (MesOut.Result.Value == "OK")
            {
                Form1.MainControl.CodeControl.Code1.IsSuccess = true;
                WAVPlayer.Playerer(WAVPlayer.playName.条码1获取成功请扫条码2);
            }
            else
            {
                Form1.MainControl.CodeControl.Code1.IsSuccess = false;
                WAVPlayer.Playerer(WAVPlayer.playName.条码比对失败);
            }
        }

        private void AnalyCheckCode2()
        {
            if (MesOut.Result.Value == "OK")
            {
                Form1.MainControl.CodeControl.Code2.IsSuccess = true;
                WAVPlayer.Playerer(WAVPlayer.playName.条码比对成功);
            }
            else
            {
                Form1.MainControl.CodeControl.Code2.IsSuccess = false;
                WAVPlayer.Playerer(WAVPlayer.playName.条码比对失败);
            }
        }

        private void AnalyUpData()
        {

        }

        public virtual void SaveDataMesIn()
        {

        }

        public virtual void SaveDataMesOut()
        {

        }

        private void btnRun_Click(object sender, EventArgs e)
        {

        }
    }
}
