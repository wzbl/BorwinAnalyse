using BorwinAnalyse.BaseClass;
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
            MesControl.Instance.Save();
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
    }
}
