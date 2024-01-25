﻿using System;
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
    public partial class InputControl : UserControl
    {
        private string inputText;
        private int inputIndex;
        DSignalLamp dSignalLamp;
        public Input Input { get; set; }

        public InputControl()
        {
            InitializeComponent();
            dSignalLamp = new DSignalLamp();
            this.Controls.Add(dSignalLamp);
        }

        public int Value
        {
            get => dSignalLamp.Value;
            set
            {
                dSignalLamp.Value = value;
            }
        }

        public string InputText
        {
            get => inputText;
            set
            {
                inputText = value;
            
            }
        }

        public int InputIndex
        {
            get => inputIndex;
            set
            {
                inputIndex = value;
                
            }

        }

        public void RefreshUI()
        {
            txtInputIndex.Text = Input.IOParm.IoName;
            txtInputText.Text = Input.IOParm.IONum.ToString();
        }


    }
}