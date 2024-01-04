namespace VisionModel.UCControls
{
    partial class CalibrationCCD
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
            this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.kryptonSplitContainer2 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.comSelectCamera = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.btn采集图片 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btn设置左边 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btn设置右边 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btn设置底边 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btn显示裁剪区域 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.picImg = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2.Panel1)).BeginInit();
            this.kryptonSplitContainer2.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2.Panel2)).BeginInit();
            this.kryptonSplitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comSelectCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImg)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonSplitContainer1
            // 
            this.kryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.kryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.kryptonSplitContainer1.Name = "kryptonSplitContainer1";
            // 
            // kryptonSplitContainer1.Panel1
            // 
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.btn显示裁剪区域);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.btn设置底边);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.btn设置右边);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.btn设置左边);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.btn采集图片);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.comSelectCamera);
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.kryptonSplitContainer2);
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(669, 511);
            this.kryptonSplitContainer1.SplitterDistance = 176;
            this.kryptonSplitContainer1.TabIndex = 0;
            // 
            // kryptonSplitContainer2
            // 
            this.kryptonSplitContainer2.Cursor = System.Windows.Forms.Cursors.Default;
            this.kryptonSplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonSplitContainer2.Location = new System.Drawing.Point(0, 0);
            this.kryptonSplitContainer2.Name = "kryptonSplitContainer2";
            this.kryptonSplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // kryptonSplitContainer2.Panel1
            // 
            this.kryptonSplitContainer2.Panel1.Controls.Add(this.picImg);
            this.kryptonSplitContainer2.Size = new System.Drawing.Size(488, 511);
            this.kryptonSplitContainer2.SplitterDistance = 355;
            this.kryptonSplitContainer2.TabIndex = 0;
            // 
            // comSelectCamera
            // 
            this.comSelectCamera.Dock = System.Windows.Forms.DockStyle.Top;
            this.comSelectCamera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comSelectCamera.DropDownWidth = 176;
            this.comSelectCamera.Items.AddRange(new object[] {
            "左相机",
            "右相机"});
            this.comSelectCamera.Location = new System.Drawing.Point(0, 0);
            this.comSelectCamera.Name = "comSelectCamera";
            this.comSelectCamera.Size = new System.Drawing.Size(176, 21);
            this.comSelectCamera.TabIndex = 0;
            this.comSelectCamera.SelectedIndexChanged += new System.EventHandler(this.comSelectCamera_SelectedIndexChanged);
            // 
            // btn采集图片
            // 
            this.btn采集图片.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn采集图片.Location = new System.Drawing.Point(0, 21);
            this.btn采集图片.Name = "btn采集图片";
            this.btn采集图片.Size = new System.Drawing.Size(176, 50);
            this.btn采集图片.TabIndex = 0;
            this.btn采集图片.Values.Text = "采集图片";
            this.btn采集图片.Click += new System.EventHandler(this.btn采集图片_Click);
            // 
            // btn设置左边
            // 
            this.btn设置左边.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn设置左边.Location = new System.Drawing.Point(0, 71);
            this.btn设置左边.Name = "btn设置左边";
            this.btn设置左边.Size = new System.Drawing.Size(176, 50);
            this.btn设置左边.TabIndex = 1;
            this.btn设置左边.Values.Text = "设置左边";
            this.btn设置左边.Click += new System.EventHandler(this.btn设置左边_Click);
            // 
            // btn设置右边
            // 
            this.btn设置右边.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn设置右边.Location = new System.Drawing.Point(0, 121);
            this.btn设置右边.Name = "btn设置右边";
            this.btn设置右边.Size = new System.Drawing.Size(176, 50);
            this.btn设置右边.TabIndex = 2;
            this.btn设置右边.Values.Text = "设置右边";
            this.btn设置右边.Click += new System.EventHandler(this.btn设置右边_Click);
            // 
            // btn设置底边
            // 
            this.btn设置底边.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn设置底边.Location = new System.Drawing.Point(0, 171);
            this.btn设置底边.Name = "btn设置底边";
            this.btn设置底边.Size = new System.Drawing.Size(176, 50);
            this.btn设置底边.TabIndex = 3;
            this.btn设置底边.Values.Text = "设置底边";
            this.btn设置底边.Click += new System.EventHandler(this.btn设置底边_Click);
            // 
            // btn显示裁剪区域
            // 
            this.btn显示裁剪区域.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn显示裁剪区域.Location = new System.Drawing.Point(0, 221);
            this.btn显示裁剪区域.Name = "btn显示裁剪区域";
            this.btn显示裁剪区域.Size = new System.Drawing.Size(176, 50);
            this.btn显示裁剪区域.TabIndex = 4;
            this.btn显示裁剪区域.Values.Text = "显示裁剪区域";
            this.btn显示裁剪区域.Click += new System.EventHandler(this.btn显示裁剪区域_Click);
            // 
            // picImg
            // 
            this.picImg.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.picImg.Location = new System.Drawing.Point(3, 3);
            this.picImg.Name = "picImg";
            this.picImg.Size = new System.Drawing.Size(482, 349);
            this.picImg.TabIndex = 0;
            this.picImg.TabStop = false;
            this.picImg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picImg_MouseDown);
            this.picImg.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picImg_MouseMove);
            this.picImg.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picImg_MouseUp);
            // 
            // CalibrationCCD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonSplitContainer1);
            this.Name = "CalibrationCCD";
            this.Size = new System.Drawing.Size(669, 511);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2.Panel1)).EndInit();
            this.kryptonSplitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2.Panel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2)).EndInit();
            this.kryptonSplitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comSelectCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer2;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox comSelectCamera;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn显示裁剪区域;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn设置底边;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn设置右边;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn设置左边;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn采集图片;
        private System.Windows.Forms.PictureBox picImg;
    }
}
