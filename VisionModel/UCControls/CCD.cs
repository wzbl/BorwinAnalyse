using BorwinAnalyse.BaseClass;
using BorwinAnalyse.DataBase.Model;
using MvCamCtrl.NET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisionModel.UCControls
{
    public partial class CCD : UserControl
    {
        SplicCamera myCamera;
        public CCD()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }
        bool Run = false;
        public CCD(SplicCamera myCamera) : this
            ()
        {
            this.myCamera = myCamera;
            myCamera.CCD_GrabImage += CCD_GrabImage;
        }

        private void CCD_GrabImage()
        {
            cameraPic.Image = myCamera.Img;
        }

        private void 采集ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myCamera.SigleTrigger();
        }

        private void 实时ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Run = !Run;
            if (Run)
            {
                实时ToolStripMenuItem.Text = "停止实时采集";
                myCamera.StartTrigger();
            }
            else
            {
                实时ToolStripMenuItem.Text = "实时采集";
                myCamera.StopTrigger();
            }
        }

    }
}
