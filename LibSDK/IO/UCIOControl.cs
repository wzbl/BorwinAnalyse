using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LibSDK.IO
{
    public partial class UCIOControl : UserControl
    {
        public UCIOControl()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Load += UCIOControl_Load;
        }

        private List<InputControl>  inputControls = new List<InputControl>();
        private List<OutputControl> OutputControls = new List<OutputControl>();

        private void UCIOControl_Load(object sender, EventArgs e)
        {
          timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (inputControls.Count==0&& MotionControl.InPort.Count>0)
            {
                int i = 0;
                foreach (KeyValuePair<string, Input> flowModel in MotionControl.InPort)
                {
                    InputControl inputControl = new InputControl();
                    kryptonSplitContainer2.Panel2.Controls.Add(inputControl);
                    inputControl.Left = 24 + (i % 4) * 173;
                    inputControl.Top = 24 + (i / 4) * 56;
                    inputControl.Input = flowModel.Value;
                    inputControl.InputIndex = i;
                    inputControls.Add(inputControl);
                    i++;
                }
                i = 0;
                foreach (KeyValuePair<string, Output> flowModel in MotionControl.Output)
                {
                    OutputControl outputControl = new OutputControl();
                    outputControl.BringToFront();
                    outputControl.output = flowModel.Value;
                    outputControl.Left = 24 + (i % 4) * 173;
                    outputControl.Top = 24 + (i / 4) * 56;
                    outputControl.OutputIndex = i;
                    OutputControls.Add(outputControl);
                    kryptonSplitContainer2.Panel1.Controls.Add(outputControl);
                    i++;
                }
            }
            for (int i = 0; i < OutputControls.Count; i++)
            {
                if (OutputControls[i].output.State())
                {
                    OutputControls[i].Value = 1;
                }
                else
                {
                    OutputControls[i].Value = 0;
                }
            }

            for (int i = 0; i < inputControls.Count;i++)
            {
                if (inputControls[i].Input.State())
                {
                    inputControls[i].Value = 1;
                }
                else
                {
                    inputControls[i].Value = 0;
                }
            }
        }
    }
}
