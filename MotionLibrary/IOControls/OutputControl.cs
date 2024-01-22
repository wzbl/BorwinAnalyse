using MotionLibrary.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotionLibrary.IOControls
{
    public partial class OutputControl : UserControl
    {
        private string outputText;
        private int outputIndex;
        //public Action<int,int> OnChangeValue;
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

            short value =  0;
            if (Value ==1)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            MotionManager.Instance.Motion_GC.SetIOBit(outputIndex, value);
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

    }
}
