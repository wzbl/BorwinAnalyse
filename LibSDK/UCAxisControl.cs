using ComponentFactory.Krypton.Toolkit;
using LibSDK.AxisParamDebuger;
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
using static GC.Frame.Motion.Privt.CNMCLib20;

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
            propertyGrid1.SelectedObject = DebugerAxisParam.Instance;
        }


        private void UpDateAxis()
        {
            timer1.Stop();
            Thread.Sleep(100);
            axisControls.Clear();
            kryptonSplitContainer1.Panel1.Controls.Clear();
            foreach (KeyValuePair<string, MotAPI> flowModel in MotionControl.Motions)
            {
                AxisControl axisControl = new AxisControl(flowModel.Value);
                kryptonSplitContainer1.Panel1.Controls.Add(axisControl);
                axisControls.Add(axisControl);
            }
            timer1.Start();
        }

        private List<AxisControl> axisControls = new List<AxisControl>();
        public static   MoveType moveType = MoveType.绝对运动模式;
        public static double pos;
        private void UCAxisControl_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
   
        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < axisControls.Count; i++)
            {
                axisControls[i].RefreshUI();
            }
        }

        private void propertyGrid1_Resize(object sender, EventArgs e)
        {
            btnSave.Location = new Point(propertyGrid1.Location.X + propertyGrid1.Width - btnSave.Width - 4, propertyGrid1.Height - btnSave.Height-4);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DebugerAxisParam.Instance.Save();
            MotionControl.AddPos?.Invoke();
        }
    }
}
