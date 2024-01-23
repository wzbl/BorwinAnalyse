namespace LibSDK
{
    partial class UCMotion
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.kryptonNavigator1 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.kryptonPage1 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.kryptonPage2 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.kryptonPage3 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.ucOUTIOParam = new LibSDK.UCMotionParamSet();
            this.ucMotionParamSet1 = new LibSDK.UCMotionParamSet();
            this.ucINIOParam = new LibSDK.UCMotionParamSet();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).BeginInit();
            this.kryptonNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage3)).BeginInit();
            this.kryptonPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonNavigator1
            // 
            this.kryptonNavigator1.Location = new System.Drawing.Point(31, 3);
            this.kryptonNavigator1.Name = "kryptonNavigator1";
            this.kryptonNavigator1.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.kryptonPage1,
            this.kryptonPage2,
            this.kryptonPage3});
            this.kryptonNavigator1.SelectedIndex = 2;
            this.kryptonNavigator1.Size = new System.Drawing.Size(1302, 675);
            this.kryptonNavigator1.TabIndex = 0;
            this.kryptonNavigator1.Text = "kryptonNavigator1";
            // 
            // kryptonPage1
            // 
            this.kryptonPage1.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage1.Flags = 65534;
            this.kryptonPage1.LastVisibleSet = true;
            this.kryptonPage1.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage1.Name = "kryptonPage1";
            this.kryptonPage1.Size = new System.Drawing.Size(1300, 648);
            this.kryptonPage1.Text = "运动控制";
            this.kryptonPage1.ToolTipTitle = "Page ToolTip";
            this.kryptonPage1.UniqueName = "8118691BFC504E1442893FD9D728FC05";
            // 
            // kryptonPage2
            // 
            this.kryptonPage2.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage2.Flags = 65534;
            this.kryptonPage2.LastVisibleSet = true;
            this.kryptonPage2.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage2.Name = "kryptonPage2";
            this.kryptonPage2.Size = new System.Drawing.Size(1300, 648);
            this.kryptonPage2.Text = "IO监控";
            this.kryptonPage2.ToolTipTitle = "Page ToolTip";
            this.kryptonPage2.UniqueName = "3974927B55454815ABB0851658D244ED";
            // 
            // kryptonPage3
            // 
            this.kryptonPage3.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage3.Controls.Add(this.ucINIOParam);
            this.kryptonPage3.Controls.Add(this.ucOUTIOParam);
            this.kryptonPage3.Controls.Add(this.ucMotionParamSet1);
            this.kryptonPage3.Flags = 65534;
            this.kryptonPage3.LastVisibleSet = true;
            this.kryptonPage3.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage3.Name = "kryptonPage3";
            this.kryptonPage3.Size = new System.Drawing.Size(1300, 648);
            this.kryptonPage3.Text = "参数设置";
            this.kryptonPage3.ToolTipTitle = "Page ToolTip";
            this.kryptonPage3.UniqueName = "F518F4D3553349211DB4F457B1BF534B";
            // 
            // ucOUTIOParam
            // 
            this.ucOUTIOParam.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucOUTIOParam.Location = new System.Drawing.Point(426, 0);
            this.ucOUTIOParam.Name = "ucOUTIOParam";
            this.ucOUTIOParam.Size = new System.Drawing.Size(426, 648);
            this.ucOUTIOParam.TabIndex = 1;
            this.ucOUTIOParam.Tag = "INIO";
            // 
            // ucMotionParamSet1
            // 
            this.ucMotionParamSet1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucMotionParamSet1.Location = new System.Drawing.Point(0, 0);
            this.ucMotionParamSet1.Name = "ucMotionParamSet1";
            this.ucMotionParamSet1.Size = new System.Drawing.Size(426, 648);
            this.ucMotionParamSet1.TabIndex = 0;
            this.ucMotionParamSet1.Tag = "Axis";
            // 
            // ucINIOParam
            // 
            this.ucINIOParam.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucINIOParam.Location = new System.Drawing.Point(852, 0);
            this.ucINIOParam.Name = "ucINIOParam";
            this.ucINIOParam.Size = new System.Drawing.Size(426, 648);
            this.ucINIOParam.TabIndex = 2;
            this.ucINIOParam.Tag = "OUTIO";
            // 
            // UCMotion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonNavigator1);
            this.Name = "UCMotion";
            this.Size = new System.Drawing.Size(1436, 772);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).EndInit();
            this.kryptonNavigator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage3)).EndInit();
            this.kryptonPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Navigator.KryptonNavigator kryptonNavigator1;
        private ComponentFactory.Krypton.Navigator.KryptonPage kryptonPage1;
        private ComponentFactory.Krypton.Navigator.KryptonPage kryptonPage2;
        private ComponentFactory.Krypton.Navigator.KryptonPage kryptonPage3;
        public UCMotionParamSet ucMotionParamSet1;
        public UCMotionParamSet ucOUTIOParam;
        public UCMotionParamSet ucINIOParam;
    }
}
