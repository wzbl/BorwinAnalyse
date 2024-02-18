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

namespace BorwinSplicMachine.UCControls.MES
{
    public partial class UCBase : UserControl
    {
        protected List<MesValue> mesInValues = new List<MesValue>();
        protected List<MesValue> mesOutValues = new List<MesValue>();
        protected MesIn MesIn;
        protected MesOut MesOut;
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
        }

        protected void DataGridViewInAdd(MesValue mesValue)
        {
            mesInValues.Add(mesValue);
            DataGridViewIn.Rows.Add(
              mesValue.Name,
              mesValue.Key,
              mesValue.Value,
              mesValue.Enable
              );
        }
        protected void DataGridViewOutAdd(MesValue mesValue)
        {
            mesOutValues.Add(mesValue);
            DataGridViewOut.Rows.Add(
             mesValue.Name,
             mesValue.Key,
             mesValue.Value,
             mesValue.Enable
             );
        }

        public virtual void GetDataMesOut()
        {
            DataGridViewOut.Rows.Clear();
            mesOutValues.Clear();
            DataGridViewOutAdd(MesOut.Success);
            DataGridViewOutAdd(MesOut.ErrorMsg);
            DataGridViewOutAdd(MesOut.ErrorCode);
        }

        public virtual void SaveDataMesIn()
        {

        }

        public virtual void SaveDataMesOut()
        {

        }

    }
}
