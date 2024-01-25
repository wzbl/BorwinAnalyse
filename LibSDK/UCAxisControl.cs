using ComponentFactory.Krypton.Toolkit;
using LibSDK.Enums;
using LibSDK.IO;
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
    public partial class UCAxisControl : UserControl
    {
        public UCAxisControl()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Load += UCAxisControl_Load;
            MotionControl.UpDateAxis += UpDateAxis;
            UpDateAxis();
        }

        private void UpDateAxis()
        {
            timer1.Stop();
            Thread.Sleep(100);
            axisControls.Clear();
            int i = 0;
            foreach (KeyValuePair<string, MotAPI> flowModel in MotionControl.Motions)
            {
                AxisControl axisControl = new AxisControl(flowModel.Value);
                kryptonSplitContainer1.Panel1.Controls.Add(axisControl);
                axisControl.Left = 10 + (i % 3) * 320;
                axisControl.Top = 15 + (i / 3) * 130;
                axisControls.Add(axisControl);
                i++;
            }
            timer1.Start();
        }

        private List<AxisControl> axisControls = new List<AxisControl>();
        public static   MoveType moveType = MoveType.绝对运动模式;
        public static double pos;
        private void UCAxisControl_Load(object sender, EventArgs e)
        {
            comMotionType.SelectedIndex = 0;
            txtPos.Text = "10";  
            timer1.Start();
        }
   
        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < axisControls.Count; i++)
            {
                axisControls[i].RefreshUI();
            }
        }

        private void kryptonComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            moveType =(MoveType) comMotionType.SelectedIndex;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            double.TryParse(txtPos.Text, out  pos);
        }

        private void btnEmgStop_Click(object sender, EventArgs e)
        {
            MotionControl.CardAPI.StopEmgAxis();
        }
    }
}
