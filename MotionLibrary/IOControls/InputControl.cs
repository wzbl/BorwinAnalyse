using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotionLibrary.IOControls
{
    public partial class InputControl : UserControl
    {
        private string inputText;
        private int inputIndex;

        public InputControl()
        {
            InitializeComponent();
        }

        public int Value
        {
            get => dSignalLamp1.Value;
            set
            {
                dSignalLamp1.Value = value;
            }
        }

        public string InputText
        {
            get => inputText;
            set
            {
                inputText = value;
                txtInputText.Text = inputText;
            }
        }

        public int InputIndex
        {
            get => inputIndex;
            set
            {
                inputIndex = value;
                txtInputIndex.Text = "IN" + inputIndex;
            }

        }



    }
}
