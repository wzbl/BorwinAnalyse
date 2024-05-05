using System.Windows.Forms;
using System;
using PdfSharp.Drawing.Layout;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp;
using System.Drawing;
using System.Diagnostics;
using PdfSharp.Pdf.Content.Objects;
using System.Security.Cryptography;
using System.IO;
using System.ComponentModel;
using BorwinAnalyse.UCControls;
using ComponentFactory.Krypton.Toolkit;
using BorwinAnalyse.BaseClass;
using BorwinAnalyse.Forms;
using LibSDK.Motion;
using LibSDK;
using Alarm;
using System.Threading;
using ComponentFactory.Krypton.Ribbon;

namespace BorwinSplicMachine
{
    public partial class Form1 : KryptonForm
    {
        public static MainControl MainControl;
        public Form1()
        {
            InitializeComponent();
            MainControl = new MainControl(this);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (this.components == null)
            {
                this.components = new System.ComponentModel.Container();
            }
            UpdataLanguage();

            kryptonPanel1.Controls.Add(MainControl.UCMain);
        }

        public void UpdataLanguage()
        {
            this.Text = this.Text.tr();

            for (int i = 0; i < kryptonRibbon1.RibbonTabs.Count; i++)
            {
                kryptonRibbon1.RibbonTabs[i].Text = kryptonRibbon1.RibbonTabs[i].Text.tr();
                for (int j = 0; j < kryptonRibbon1.RibbonTabs[i].Groups.Count; j++)
                {
                    for (int k = 0; k < kryptonRibbon1.RibbonTabs[i].Groups[j].Items.Count; k++)
                    {
                        KryptonRibbonGroupTriple triple = kryptonRibbon1.RibbonTabs[i].Groups[j].Items[k] as KryptonRibbonGroupTriple;
                        if (triple != null)
                        {
                            for (int l = 0; l < triple.Items.Count; l++)
                            {
                                KryptonRibbonGroupButton button = triple.Items[l] as KryptonRibbonGroupButton;
                                button.TextLine1 = button.TextLine1.tr();
                            }
                        }

                    }

                }
            }
        }

        private void ShowLanguageSearch_Click(object sender, EventArgs e)
        {
            kryptonPanel1.Controls.Clear();
            kryptonPanel1.Controls.Add(MainControl.UCSearchLanguage);
        }

        private void ShowUCParam_Click(object sender, EventArgs e)
        {
            kryptonPanel1.Controls.Clear();
            kryptonPanel1.Controls.Add(MainControl.UCParam);
        }

        private void ShowUCMain_Click(object sender, EventArgs e)
        {
            kryptonPanel1.Controls.Clear();
            kryptonPanel1.Controls.Add(MainControl.UCMain);
        }

        private void ShowUCBaseSet_Click(object sender, EventArgs e)
        {
            kryptonPanel1.Controls.Clear();
            kryptonPanel1.Controls.Add(MainControl.UCBaseSet);
        }

        private void kryptonRibbonGroupButton2_Click(object sender, EventArgs e)
        {
            kryptonPanel1.Controls.Clear();
            kryptonPanel1.Controls.Add(MainControl.UCLog);
        }

        /// <summary>
        /// 相机标定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kryptonRibbonGroupButton12_Click(object sender, EventArgs e)
        {
            kryptonPanel1.Controls.Clear();
            kryptonPanel1.Controls.Add(MainControl.UCVision);
        }

        private void kryptonRibbonGroupButton10_Click(object sender, EventArgs e)
        {
            kryptonPanel1.Controls.Clear();
            kryptonPanel1.Controls.Add(MainControl.UCLCRSearch);
        }

        /// <summary>
        /// mes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kryptonRibbonGroupButton4_Click(object sender, EventArgs e)
        {
            kryptonPanel1.Controls.Clear();
            kryptonPanel1.Controls.Add(MainControl.UCMes);
        }

        /// <summary>
        /// 运动控制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>   
        private void kryptonRibbonGroupButton11_Click(object sender, EventArgs e)
        {
            kryptonPanel1.Controls.Clear();
            kryptonPanel1.Controls.Add(MainControl.UCAxis);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainControl.Log("程序关闭");
            MainControl.Close();
            Thread.Sleep(50);
            System.Environment.Exit(System.Environment.ExitCode);
            this.Dispose();
            this.Close();
        }

        private void kryptonRibbonGroupButton5_Click(object sender, EventArgs e)
        {
            FormIO FormIO = new FormIO();
            FormIO.Show();
        }

        private void kryptonRibbonGroupButton6_Click(object sender, EventArgs e)
        {
            kryptonPanel1.Controls.Clear();
            kryptonPanel1.Controls.Add(MainControl.UCPrint);
        }

        private void kryptonRibbonGroupButton3_Click(object sender, EventArgs e)
        {
            MainControl.motControl.Reset();
        }

        private void kryptonRibbonGroupButton7_Click(object sender, EventArgs e)
        {
            MainControl.Stop();
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            if (MotionControl.IsAuto)
            {
                MotionControl.IsAuto = false;
                btnAuto.TextLine1 = "手动".tr();
                btnAuto.ImageLarge = Properties.Resources.icons8_手动_96;
            }
            else
            {
                MotionControl.IsAuto = true;
                btnAuto.TextLine1 = "自动".tr();
                btnAuto.ImageLarge = Properties.Resources.icons8_自动_96;
            }
        }
        public static Process kbpr;
        private void btnOSK_Click(object sender, EventArgs e)
        {
            OSKPro();
        }

        /// <summary>
        /// 系统键盘
        /// </summary>
        public static void OSKPro()
        {
            if (kbpr != null && !kbpr.HasExited)
            {
                kbpr.Kill();
            }
            else
            {
                kbpr = System.Diagnostics.Process.Start("osk.exe");
            }
        }
    }
}
