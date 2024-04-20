using BorwinAnalyse.BaseClass;
using ComponentFactory.Krypton.Toolkit;
using LibSDK.AxisParamDebuger;
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
            this.components = new System.ComponentModel.Container();
            MotionControl.UpDateAxis += UpDateAxis;
            this.Load += UCALLAxis_Load;
            UpDateAxis();
        }

        private void UCALLAxis_Load(object sender, EventArgs e)
        {
            timer1.Start();
            UpdataLanguage();
            if (!MotionControl.CardAPI.IsInitCardOK)
            {
                btnShowParam.Visible = false;
                kryptonPanel2.Visible = false;
            }
            else
            {
                txt流道Vel.Text = AxisRunVel.Instance.流道调宽.Sped.ToString();
                txt流道Acc.Text = AxisRunVel.Instance.流道调宽.Sped.ToString();
                txt凸轮Vel.Text = AxisRunVel.Instance.凸轮.Sped.ToString();
                txt凸轮Acc.Text = AxisRunVel.Instance.凸轮.Acc.ToString();
                txt左进入Vel.Text = AxisRunVel.Instance.左进入.Sped.ToString();
                txt左进入Acc.Text = AxisRunVel.Instance.左进入.Acc.ToString();
                txt右进入Vel.Text = AxisRunVel.Instance.右进入.Sped.ToString();
                txt右进入Acc.Text = AxisRunVel.Instance.右进入.Acc.ToString();
                txt吸头平移Vel.Text = AxisRunVel.Instance.吸头平移.Sped.ToString();
                txt吸头上下Vel.Text = AxisRunVel.Instance.吸头上下.Sped.ToString();
                txt热熔上下Vel.Text = AxisRunVel.Instance.热熔上下.Sped.ToString();
                txt拨刀Vel.Text = AxisRunVel.Instance.拨刀.Sped.ToString();
                txt卷料Vel.Text = AxisRunVel.Instance.卷料.Sped.ToString();
                txt探针AVel.Text = AxisRunVel.Instance.探针A.Sped.ToString();
                txt测值上下Vel.Text = AxisRunVel.Instance.测值整体上下.Sped.ToString();
                txt探针BVel.Text = AxisRunVel.Instance.探针B.Sped.ToString();
                txt下针Vel.Text = AxisRunVel.Instance.下针.Sped.ToString();
                txt吸头平移Acc.Text = AxisRunVel.Instance.吸头平移.Acc.ToString();
                txt吸头上下Acc.Text = AxisRunVel.Instance.吸头上下.Acc.ToString();
                txt热熔上下Acc.Text = AxisRunVel.Instance.热熔上下.Acc.ToString();
                txt拨刀Acc.Text = AxisRunVel.Instance.拨刀.Acc.ToString();
                txt卷料Acc.Text = AxisRunVel.Instance.卷料.Acc.ToString();
                txt探针AAcc.Text = AxisRunVel.Instance.探针A.Acc.ToString();
                txt测值上下Acc.Text = AxisRunVel.Instance.测值整体上下.Acc.ToString();
                txt探针BAcc.Text = AxisRunVel.Instance.探针B.Acc.ToString();
                txt下针Acc.Text = AxisRunVel.Instance.下针.Acc.ToString();
            }
        }

        public void UpdataLanguage()
        {
            LanguageManager.Instance.UpdateLanguage(this, this.components.Components);
            for (int i = 0; i < axisControls.Count; i++)
            {
                axisControls[i].UpdataLanguage();
            }
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
                axisControl.Top = 5 + (i / 2) * 195;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            AxisRunVel.Instance.流道调宽.Sped = int.Parse(txt流道Vel.Text);
            AxisRunVel.Instance.流道调宽.Acc = int.Parse(txt流道Acc.Text);
            AxisRunVel.Instance.凸轮.Sped = int.Parse(txt凸轮Vel.Text);
            AxisRunVel.Instance.凸轮.Acc = int.Parse(txt凸轮Acc.Text);
            AxisRunVel.Instance.左进入.Sped = int.Parse(txt左进入Vel.Text);
            AxisRunVel.Instance.左进入.Acc = int.Parse(txt左进入Acc.Text);
            AxisRunVel.Instance.右进入.Sped = int.Parse(txt右进入Vel.Text);
            AxisRunVel.Instance.右进入.Acc = int.Parse(txt右进入Acc.Text);
            AxisRunVel.Instance.吸头平移.Sped = int.Parse(txt吸头平移Vel.Text);
            AxisRunVel.Instance.吸头上下.Sped = int.Parse(txt吸头上下Vel.Text);
            AxisRunVel.Instance.热熔上下.Sped = int.Parse(txt热熔上下Vel.Text);
            AxisRunVel.Instance.拨刀.Sped = int.Parse(txt拨刀Vel.Text);
            AxisRunVel.Instance.卷料.Sped = int.Parse(txt卷料Vel.Text);
            AxisRunVel.Instance.探针A.Sped = int.Parse(txt探针AVel.Text);
            AxisRunVel.Instance.测值整体上下.Sped = int.Parse(txt测值上下Vel.Text);
            AxisRunVel.Instance.探针B.Sped = int.Parse(txt探针BVel.Text);
            AxisRunVel.Instance.下针.Sped = int.Parse(txt下针Vel.Text);
            AxisRunVel.Instance.吸头平移.Acc = int.Parse(txt吸头平移Acc.Text);
            AxisRunVel.Instance.吸头上下.Acc = int.Parse(txt吸头上下Acc.Text);
            AxisRunVel.Instance.热熔上下.Acc = int.Parse(txt热熔上下Acc.Text);
            AxisRunVel.Instance.拨刀.Acc = int.Parse(txt拨刀Acc.Text);
            AxisRunVel.Instance.卷料.Acc = int.Parse(txt卷料Acc.Text);
            AxisRunVel.Instance.探针A.Acc = int.Parse(txt探针AAcc.Text);
            AxisRunVel.Instance.测值整体上下.Acc = int.Parse(txt测值上下Acc.Text);
            AxisRunVel.Instance.探针B.Acc = int.Parse(txt探针BAcc.Text);
            AxisRunVel.Instance.下针.Acc = int.Parse(txt下针Acc.Text);

            AxisRunVel.Instance.Save();
        }
    }
}
