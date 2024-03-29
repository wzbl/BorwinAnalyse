﻿using ComponentFactory.Krypton.Toolkit;
using LibSDK.Motion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibSDK
{
    public partial class UCALLAxis : UserControl
    {
        public UCALLAxis()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            MotionControl.UpDateAxis += UpDateAxis;
            UpDateAxis();
            this.Load += UCALLAxis_Load;
        }

        private void UCALLAxis_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private List<AxisControl> axisControls = new List<AxisControl>();

        private void UpDateAxis()
        {
            timer1.Stop();
            Thread.Sleep(10);
            axisControls.Clear();
            this.kryptonPanel1.Controls.Clear();
            int i = 0;
            foreach (KeyValuePair<string, MotAPI> flowModel in MotionControl.Motions)
            {
                AxisControl axisControl = new AxisControl(flowModel.Value);
                this.kryptonPanel1.Controls.Add(axisControl);
                axisControl.Left = 2 + (i % 2) * 600;
                axisControl.Top = 5 + (i / 2) * 180;
                axisControls.Add(axisControl);
                i++;
            }
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < axisControls.Count; i++)
            {
                axisControls[i].RefreshUI();
            }
        }
    }
}
