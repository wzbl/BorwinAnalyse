using BorwinAnalyse.BaseClass;
using ComponentFactory.Krypton.Toolkit;
using LibSDK.Dataview;
using NPOI.SS.Formula.Functions;
using NPOI.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LibSDK.IO
{
    public partial class UCIOList_OUT : UserControl
    {
        public UCIOList_OUT()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            UpDateOUTIO();
            MotionControl.UpDateOUTIO += UpDateOUTIO;
            this.Load += UCIOList_OUT_Load;
        }

        private void UCIOList_OUT_Load(object sender, EventArgs e)
        {
            dgvIO.ColumnHeadersHeight = 30;
            dgvIO.CellContentClick += DgvIO_CellContentClick;
        }

        private void DgvIO_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row < 0||row>= outputs.Count) return;
            int column = e.ColumnIndex;
            if (column==4)
            {
                if (outputs[row].State())
                {
                    outputs[row].Off();
                }
                else
                {
                    outputs[row].On();
                }
              
            }
        }

        public List<Output> outputs = new List<Output>();
        public List<OutIO> OutIOs = new List<OutIO>();

        private void UpDateOUTIO()
        {
            outputs.Clear();
            OutIOs.Clear();
            dgvIO.DataSource = null;
            foreach (KeyValuePair<string, Output> flowModel in MotionControl.Output)
            {
                Output output = flowModel.Value;
                outputs.Add(output);
                OutIO outIO = new OutIO();
                outIO.CardNo = output.IOParm.CardNo.ToString();
                outIO.IONo = output.IOParm.IONum.ToString();
                outIO.Name = output.IOParm.IoName.tr();
                OutIOs.Add(outIO);
            }
            dgvIO.DataSource = new BindingList<OutIO>(OutIOs);
        }

        public void RefreshUI()
        {
            for (int i = 0; i < outputs.Count; i++)
            {
                if (outputs[i].State())
                {
                    OutIOs[i].Status = Properties.Resources.G_45;
                    OutIOs[i].Switch = Properties.Resources.switch4_b;
                }
                else
                {
                    OutIOs[i].Status = Properties.Resources.R_45;
                    OutIOs[i].Switch = Properties.Resources.switch4_a;
                }

            }
            dgvIO.Refresh();
        }

    }

    public class OutIO
    {
        public string CardNo { get; set; }
        public string IONo { get; set; }
        public string Name { get; set; }
        public Image Status { get; set; } = Properties.Resources.G_45;
        public Image Switch { get; set; } = Properties.Resources.switch4_a;

    }
}
