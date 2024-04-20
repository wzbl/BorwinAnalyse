using BorwinAnalyse.BaseClass;
using BorwinSplicMachine.UCControls.MES;
using Mes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorwinSplicMachine.UCControls
{
    public partial class UCMes : UserControl
    {
        public UCMes()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            this.Load += UCBaseSet_Load;
            this.components = new System.ComponentModel.Container();
        }

        private void UCBaseSet_Load(object sender, EventArgs e)
        {
            UpdataLanguage();
            initData();
        }

        private void initData()
        {
            chkIsEnableMes.Checked = MesControl.Instance.IsOpenMes;
            comMesType.SelectedIndex = (int)MesControl.Instance.MesType;
            comMesData.SelectedIndex = (int)MesControl.Instance.DataType;
            txtWo.Text = MesControl.Instance.Wo;
            txtLine.Text = MesControl.Instance.Line;
            txtMachinCode.Text = MesControl.Instance.MachineCode;
            ucMesLogin1.Init();
            ucCode1Check1.Init();
            ucCode2Check1.Init();
            ucUpData1.Init();
        }


        public void UpdataLanguage()
        {
            LanguageManager.Instance.UpdateLanguage(this, this.components.Components);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MesControl.Instance.IsOpenMes = chkIsEnableMes.Checked;
            MesControl.Instance.MesType = (MesType)comMesType.SelectedIndex;
            MesControl.Instance.DataType = (DataType)comMesData.SelectedIndex;
            MesControl.Instance.Wo=txtWo.Text;
            MesControl.Instance.Line = txtLine.Text;
            MesControl.Instance.MachineCode=txtMachinCode.Text;
            MesControl.Instance.Save();
           
            ucMesLogin1. GetDataMesIn();
            ucMesLogin1. GetDataMesOut();

            ucCode1Check1.GetDataMesIn();
            ucCode1Check1.GetDataMesOut();

            ucCode2Check1.GetDataMesIn();
            ucCode2Check1.GetDataMesOut();

            ucUpData1.GetDataMesIn();
            ucUpData1.GetDataMesOut();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void btnCheckCode1_Click(object sender, EventArgs e)
        {

        }

        private void btnCheckCode2_Click(object sender, EventArgs e)
        {

        }

        private void btnUpData_Click(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIP.Text)&& int.TryParse(txtPort.Text,out int port))
            {
                MesClientSocket.ConnectService(txtIP.Text,port);
            }
            if (MesClientSocket.IsConnect)
            {
                btnConnect.StateCommon.Back.Image = Properties.Resources.icons8_有线网络连接_100;
            }
            else
            {
                btnConnect.StateCommon.Back.Image = Properties.Resources.icons8_没有网络_100;
            }
        }

        private void comMesType_SelectedIndexChanged(object sender, EventArgs e)
        {
            MesType MesType = (MesType)comMesType.SelectedIndex;
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
    }
}
