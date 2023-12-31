﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorwinSplicMachine.FlowModel
{
    [Serializable]
    public partial class FlowLCRModel : FlowBaseModel
    {
        public FlowLCRModel()
        {
            InitializeComponent();
            FlowControl = new FlowLCR();
            FlowControl.FlowModeControl.FlowModel = this;
            FlowControl.FlowModeControl.ModelName = ModelType.LCR;
        }
    }
}
