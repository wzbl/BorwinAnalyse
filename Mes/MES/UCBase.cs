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

namespace Mes
{
    public partial class UCBase : UserControl
    {
        public MesIn MesIn;
        public MesOut MesOut;
        public bool IsLoad = false;
        public UCBase()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Load += UCBase_Load;
        }

        private void UCBase_Load(object sender, EventArgs e)
        {
            IsLoad = true;
        }

        public virtual void GetDataMesIn()
        {
            DataGridViewIn.Rows.Clear();
            MesIn.mesInValues.Clear();
            MesIn.Line.Value = MesControl.Instance.Line;
            MesIn.Wo.Value = MesControl.Instance.Wo;
            MesIn.MachineCode.Value = MesControl.Instance.MachineCode;
            MesIn.StandNo.Value = MesControl.Instance.StandNo;
            MesIn.UserName.Value = "Admin";
            DataGridViewInAdd(MesIn.IsEnable);
            DataGridViewInAdd(MesIn.URL);
            DataGridViewInAdd(MesIn.WebFunName);
            DataGridViewInAdd(MesIn.WebFunName_Xmlns);
            DataGridViewInAdd(MesIn.WebParamName_Xmlns);
            DataGridViewInAdd(MesIn.Line);
            DataGridViewInAdd(MesIn.MachineCode);
            DataGridViewInAdd(MesIn.Wo);
            DataGridViewInAdd(MesIn.StandNo);
            DataGridViewInAdd(MesIn.UserName);
            DataGridViewInAdd(MesIn.InterFaceNo);
        }

        protected void DataGridViewInAdd(MesValue mesValue)
        {
            MesIn.mesInValues.Add(mesValue);
            DataGridViewIn.Rows.Add(
              mesValue.Name.tr(),
              mesValue.Key,
              mesValue.Value,
              mesValue.Enable
              );
        }
        protected void DataGridViewOutAdd(MesValue mesValue)
        {
            MesOut.mesOutValues.Add(mesValue);
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
            MesOut.mesOutValues.Clear();
            DataGridViewOutAdd(MesOut.Result);
            DataGridViewOutAdd(MesOut.ErrorMsg);
            DataGridViewOutAdd(MesOut.ErrorCode);
            DataGridViewOutAdd(MesOut.InterFaceNo);
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
