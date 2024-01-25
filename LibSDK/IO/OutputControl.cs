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
                txtOutputText.Text = value.ToString();
            }
        }

        public string OutputText
        {
            get => outputText;
            set
            {
                outputText = value;
                txtOutputText.Text = outputText;
            }
        }

        public int OutputIndex
        {
            get => outputIndex;
            set
            {
                outputIndex = value;
                txtOutputIndex.Text = "OUT" + outputIndex;
            }
        }

        public void RefreshUI()
        {
            txtOutputIndex.Text = output.IOParm.IoName;
            txtOutputText.Text = output.IOParm.IONum.ToString();
        }

    }
}
