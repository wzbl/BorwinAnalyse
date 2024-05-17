using BorwinAnalyse;
using Mes.MES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mes
{
    public partial class UCMes : UserControl
    {
        public UCMes()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            this.Load += UCBaseSet_Load;
            this.components = new System.ComponentModel.Container();
            kryptonPage5.Controls.Add(cHPSetting);
        }
        UCHPSetting cHPSetting = new UCHPSetting();
        private void UCBaseSet_Load(object sender, EventArgs e)
        {
            UpdataLanguage();
        }

        public void InitData()
        {
            chkIsEnableMes.Checked = MesControl.Instance.IsOpenMes;
            comMesType.SelectedIndex = (int)MesControl.Instance.MesType;
            comMesData.SelectedIndex = (int)MesControl.Instance.DataType;
            txtWo.Text = MesControl.Instance.Wo;
            txtLine.Text = MesControl.Instance.Line;
            txtMachinCode.Text = MesControl.Instance.MachineCode;
            txtStandNo.Text = MesControl.Instance.StandNo;
            txtIP.Text = MesControl.Instance.Ip;
            txtPort.Text = MesControl.Instance.Port.ToString();
            ucMesLogin1.Init();
            ucCode1Check1.Init();
            ucCode2Check1.Init();
            ucUpData1.Init();
            cHPSetting.Init();
        }


        public void UpdataLanguage()
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MesControl.Instance.IsOpenMes = chkIsEnableMes.Checked;
            MesControl.Instance.MesType = (MesType)comMesType.SelectedIndex;
            MesControl.Instance.DataType = (DataType)comMesData.SelectedIndex;
            MesControl.Instance.Wo = txtWo.Text;
            MesControl.Instance.Line = txtLine.Text;
            MesControl.Instance.MachineCode = txtMachinCode.Text;
            MesControl.Instance.StandNo = txtStandNo.Text;
            MesControl.Instance.Ip = txtIP.Text;
            MesControl.Instance.Port = int.Parse(txtPort.Text);
            MesControl.Instance.Save();

            ucMesLogin1.GetDataMesIn();
            ucMesLogin1.GetDataMesOut();

            ucCode1Check1.GetDataMesIn();
            ucCode1Check1.GetDataMesOut();

            ucCode2Check1.GetDataMesIn();
            ucCode2Check1.GetDataMesOut();

            ucUpData1.GetDataMesIn();
            ucUpData1.GetDataMesOut();
        }



        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIP.Text) && int.TryParse(txtPort.Text, out int port))
            {
                MesClientSocket.ConnectService(txtIP.Text, port);
            }
            if (MesClientSocket.IsConnect)
            {
                btnConnect.StateCommon.Back.Image = Properties.Resources.icons8_有线网络连接_100;
            }
            else
            {
                btnConnect.StateCommon.Back.Image = Properties.Resources.icons8_没有网络_100;
                MessageBox.Show("Connect Fail");
            }
        }

        private void comMesType_SelectedIndexChanged(object sender, EventArgs e)
        {
            MesType MesType = (MesType)comMesType.SelectedIndex;
            MesControl.Instance.MesType = MesType;
            switch (MesType)
            {
                case Mes.MesType.WebApi:
                    kryptonGroupBox1.Visible = false;
                    break;
                case Mes.MesType.Socket:
                    kryptonGroupBox1.Visible = true;
                    break;
                case Mes.MesType.WebService:
                    kryptonGroupBox1.Visible = false;
                    break;
                default:
                    break;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (MesControl.Instance.loginIn.IsEnable.Enable && MesControl.Instance.CurrentType == InterType.登录)
                ucMesLogin1.GetDataMesOut();
            if (MesControl.Instance.checkInCode1.IsEnable.Enable && MesControl.Instance.CurrentType == InterType.条码1检验)
                ucCode1Check1.GetDataMesOut();
            if (MesControl.Instance.checkInCode2.IsEnable.Enable && MesControl.Instance.CurrentType == InterType.条码2检验)
                ucCode2Check1.GetDataMesOut();
            if (MesControl.Instance.upDataIn.IsEnable.Enable && MesControl.Instance.CurrentType == InterType.上传信息)
                ucUpData1.GetDataMesOut();
            if (MesControl.Instance.HPDataIn.IsEnable.Enable && MesControl.Instance.CurrentType == InterType.合盘)
                cHPSetting.GetDataMesOut();
            timer1.Stop();
        }
    }
}
