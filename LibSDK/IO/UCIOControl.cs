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
            UpDateOUTIO();
            UpDateINIO();
            MotionControl.UpDateINIO += UpDateINIO;
            MotionControl.UpDateOUTIO += UpDateOUTIO;
        }

        private void UpDateOUTIO()
        {
            int i = 0;
            foreach (KeyValuePair<string, Output> flowModel in MotionControl.Output)
            {
                OutputControl outputControl = new OutputControl();
                outputControl.BringToFront();
                outputControl.output = flowModel.Value;
                outputControl.Left = 10 + (i % 4) * 173;
                outputControl.Top = 15 + (i / 4) * 56;
                OutputControls.Add(outputControl);
                kryptonSplitContainer2.Panel1.Controls.Add(outputControl);
                outputControl.RefreshUI();
                i++;
            }
        }

        private void UpDateINIO()
        {
            int i = 0;
            foreach (KeyValuePair<string, Input> flowModel in MotionControl.InPort)
            {
                InputControl inputControl = new InputControl();
                kryptonSplitContainer2.Panel2.Controls.Add(inputControl);
                inputControl.Left = 10 + (i % 4) * 173;
                inputControl.Top = 15 + (i / 4) * 56;
                inputControl.Input = flowModel.Value;
                inputControls.Add(inputControl);
                inputControl.RefreshUI();
                i++;
            }

        }
        private List<InputControl>  inputControls = new List<InputControl>();
        private List<OutputControl> OutputControls = new List<OutputControl>();

        private void UCIOControl_Load(object sender, EventArgs e)
        {
           timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

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
                if (RefreshOutIO)
                {
                    OutputControls[i].RefreshUI();
                }
                
            }

            if (RefreshOutIO)
            {
                RefreshOutIO = false;
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
                if (RefreshInIO)
                {
                    inputControls[i].RefreshUI();
                }

            }
            if (RefreshInIO)
            {
                RefreshInIO = false;
            }
        }

        public static bool  RefreshInIO = false;
        public static bool  RefreshOutIO = false;
    }
}
