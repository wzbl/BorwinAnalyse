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
    public partial class OutputControl : UserControl
    {
        private string outputText;
        private int outputIndex;
        public Output output;
        DSignalLamp dSignalLamp;

        public OutputControl()
        {
            InitializeComponent();
            dSignalLamp = new DSignalLamp();
            this.Controls.Add(dSignalLamp);
            dSignalLamp.Click += DSignalLamp_Click;
            MotionControl.IsEnable += IsEnable;
        }

        private void IsEnable(bool obj)
        {
            txtOutputIndex.ReadOnly = !obj;
            txtOutputText.ReadOnly = !obj;
        }

        private void DSignalLamp_Click(object sender, EventArgs e)
        {
            if (output.IOParm.Invert)
            {
                if (Value == 0)
                {
                    output.Off();
                }
                else
                {
                    output.On();
                }
            }
            else
            {
                if (Value == 1)
                {
                    output.Off();
                }
                else
                {
                    output.On();
                }
            }
          
        }

        public int Value
        {
            get => dSignalLamp.Value;
            set
            {
                dSignalLamp.Value = value;
            }
        }

        public void RefreshUI()
        {
            txtOutputText.Text = output.IOParm.IoName;
            txtOutputIndex.Text = output.IOParm.CardNo+"-"+output.IOParm.IONum;
        }

        private void txtOutputIndex_TextChanged(object sender, EventArgs e)
        {
            if (!txtOutputIndex.Text.Contains("-"))
            {
                return;
            }

            string[] s = txtOutputIndex.Text.Split('-');
            if (s.Length != 2)
            {
                return;
            }

            if (short.TryParse(s[0], out short cardNo) && short.TryParse(s[1], out short IoNo))
            {
                output.IOParm.CardNo = cardNo;
                output.IOParm.IONum = IoNo;
            }
        }

        private void txtOutputText_TextChanged(object sender, EventArgs e)
        {
            output.IOParm.IoName = txtOutputText.Text;
        }
    }
}
