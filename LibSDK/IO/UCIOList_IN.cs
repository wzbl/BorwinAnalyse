using BorwinAnalyse.BaseClass;
using ComponentFactory.Krypton.Toolkit;
using NPOI.Util.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibSDK.IO
{
    public partial class UCIOList_IN : UserControl
    {
        public UCIOList_IN()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            UpDateINIO();
            this.Load += UCIOList_IN_Load;
            MotionControl.UpDateINIO += UpDateINIO;
        }

        List<Input> inputs = new List<Input>();
        List<INIO> INIOs = new List<INIO>();

        private void UCIOList_IN_Load(object sender, EventArgs e)
        {
            dgvIO.ColumnHeadersHeight = 30;
            
        }

        private void UpDateINIO()
        {
            inputs.Clear();
            INIOs.Clear();
            dgvIO.DataSource = null;
            foreach (KeyValuePair<string, Input> flowModel in MotionControl.InPort)
            {
                Input input = flowModel.Value;
                inputs.Add(input);
                INIO iNIO = new INIO();
                iNIO.CardNo=input.IOParm.CardNo.ToString();
                iNIO.IONo=input.IOParm.IONum.ToString();
                iNIO.Name=input.IOParm.IoName.tr();
                INIOs.Add(iNIO);
            }
            dgvIO.DataSource = new BindingList<INIO>(INIOs);
        }

        public void RefreshUI()
        {
            for (int i = 0; i < inputs.Count; i++)
            {
                if (inputs[i].State())
                {
                    INIOs[i].Status = Properties.Resources.G_45;
                }
                else
                {
                    INIOs[i].Status = Properties.Resources.R_45;
                }
                
            }
            dgvIO.Refresh();
        }
    }

    public class INIO
    {
        public string CardNo {  get; set; }
        public string IONo { get; set; }
        public string Name { get; set; }
        public Image Status { get; set; } = Properties.Resources.G_45;
    }

}
