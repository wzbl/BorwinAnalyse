using BorwinAnalyse.DataBase.Model;
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
            propertyGrid1.SelectedObject = DebugerAxisParam.Instance;
            kryptonPanel1.Controls.Add(new UCALLAxis());
            kryptonPanel2.Visible = false;
            btnShowParam.Text = "<";
        }

        private void propertyGrid1_Resize(object sender, EventArgs e)
        {
            btnSave.Location = new Point(propertyGrid1.Location.X + propertyGrid1.Width - btnSave.Width - 4, propertyGrid1.Height - btnSave.Height - 4);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DebugerAxisParam.Instance.Save();
            MotionControl.AddPos?.Invoke();
        }

        private void btnShowParam_Click(object sender, EventArgs e)
        {
            if (kryptonPanel2.Visible)
            {
                kryptonPanel2.Visible = false;
                btnShowParam.Text = "<";
            }
            else
            {
                kryptonPanel2.Visible = true;
                btnShowParam.Text = ">";
            }
        }

        private void kryptonPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
