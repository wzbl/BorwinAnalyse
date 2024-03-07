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

namespace BorwinSplicMachine
{
    public partial class Form1 : KryptonForm
    {
        public static MainControl MainControl;
        public Form1()
        {
            InitializeComponent();
            MainControl=new MainControl(this);
            MainControl.Init();
        }
     
        private void Form1_Load(object sender, EventArgs e)
        {
            if (this.components==null)
            {
                this.components= new System.ComponentModel.Container();
            }
            UpdataLanguage();
        }
        public void UpdataLanguage()
        {
            LanguageManager.Instance.UpdateLanguage(this, this.components.Components);
        }
     
        private void ShowUCBom_Click(object sender, EventArgs e)
        {
            kryptonPanel1.Controls.Clear();
            kryptonPanel1.Controls.Add(MainControl.UCBOM);
        }

        private void ShowUCBomSearch_Click(object sender, EventArgs e)
        {
            kryptonPanel1.Controls.Clear();
            kryptonPanel1.Controls.Add(MainControl.UCSearchBom);
        }

        private void ShowUCBomSet_Click(object sender, EventArgs e)
        {
            kryptonPanel1.Controls.Clear();
            kryptonPanel1.Controls.Add(MainControl.UCAnalyseSet);
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
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainControl.Log("程序关闭");
        }
    }


}
