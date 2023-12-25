namespace VisionModel.UCControls
{
    partial class CCD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CCD));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolZoom = new System.Windows.Forms.ToolStripSplitButton();
            this.放大ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.缩小ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.填充窗口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.适应图像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清除图像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.相机参数设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolButtonOption = new System.Windows.Forms.ToolStripSplitButton();
            this.d3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemdps01 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemdps11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolFileButton = new System.Windows.Forms.ToolStripSplitButton();
            this.toolItem_OpenImage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolItem_save = new System.Windows.Forms.ToolStripMenuItem();
            this.toolItem_saveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolGrapButton = new System.Windows.Forms.ToolStripSplitButton();
            this.采集ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.实时ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolRun = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tbSet = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSplitButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.填加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.采集ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mainWindow = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainWindow)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolZoom,
            this.toolStripSeparator1,
            this.toolButtonOption,
            this.toolFileButton,
            this.toolGrapButton,
            this.toolRun,
            this.toolStripLabel1,
            this.tbSet,
            this.toolStripSplitButton1,
            this.toolStripSplitButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(623, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "工具条";
            // 
            // toolZoom
            // 
            this.toolZoom.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.放大ToolStripMenuItem,
            this.缩小ToolStripMenuItem,
            this.填充窗口ToolStripMenuItem,
            this.适应图像ToolStripMenuItem,
            this.清除图像ToolStripMenuItem,
            this.相机参数设置ToolStripMenuItem});
            this.toolZoom.Image = ((System.Drawing.Image)(resources.GetObject("toolZoom.Image")));
            this.toolZoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolZoom.Name = "toolZoom";
            this.toolZoom.Size = new System.Drawing.Size(65, 22);
            this.toolZoom.Text = "缩放";
            // 
            // 放大ToolStripMenuItem
            // 
            this.放大ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("放大ToolStripMenuItem.Image")));
            this.放大ToolStripMenuItem.Name = "放大ToolStripMenuItem";
            this.放大ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.放大ToolStripMenuItem.Text = "放大";
            // 
            // 缩小ToolStripMenuItem
            // 
            this.缩小ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("缩小ToolStripMenuItem.Image")));
            this.缩小ToolStripMenuItem.Name = "缩小ToolStripMenuItem";
            this.缩小ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.缩小ToolStripMenuItem.Text = "缩小";
            // 
            // 填充窗口ToolStripMenuItem
            // 
            this.填充窗口ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("填充窗口ToolStripMenuItem.Image")));
            this.填充窗口ToolStripMenuItem.Name = "填充窗口ToolStripMenuItem";
            this.填充窗口ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.填充窗口ToolStripMenuItem.Text = "适应窗口";
            // 
            // 适应图像ToolStripMenuItem
            // 
            this.适应图像ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("适应图像ToolStripMenuItem.Image")));
            this.适应图像ToolStripMenuItem.Name = "适应图像ToolStripMenuItem";
            this.适应图像ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.适应图像ToolStripMenuItem.Text = "适应图像";
            // 
            // 清除图像ToolStripMenuItem
            // 
            this.清除图像ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("清除图像ToolStripMenuItem.Image")));
            this.清除图像ToolStripMenuItem.Name = "清除图像ToolStripMenuItem";
            this.清除图像ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.清除图像ToolStripMenuItem.Text = "清除图像";
            // 
            // 相机参数设置ToolStripMenuItem
            // 
            this.相机参数设置ToolStripMenuItem.Name = "相机参数设置ToolStripMenuItem";
            this.相机参数设置ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.相机参数设置ToolStripMenuItem.Text = "相机参数设置";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolButtonOption
            // 
            this.toolButtonOption.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolButtonOption.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.d3ToolStripMenuItem,
            this.ToolStripMenuItemdps01,
            this.ToolStripMenuItemdps11});
            this.toolButtonOption.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonOption.Image")));
            this.toolButtonOption.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonOption.Name = "toolButtonOption";
            this.toolButtonOption.Size = new System.Drawing.Size(65, 22);
            this.toolButtonOption.Text = "选项";
            // 
            // d3ToolStripMenuItem
            // 
            this.d3ToolStripMenuItem.Name = "d3ToolStripMenuItem";
            this.d3ToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.d3ToolStripMenuItem.Text = "显示图标";
            // 
            // ToolStripMenuItemdps01
            // 
            this.ToolStripMenuItemdps01.Name = "ToolStripMenuItemdps01";
            this.ToolStripMenuItemdps01.Size = new System.Drawing.Size(165, 22);
            this.ToolStripMenuItemdps01.Text = "显示文字";
            // 
            // ToolStripMenuItemdps11
            // 
            this.ToolStripMenuItemdps11.Name = "ToolStripMenuItemdps11";
            this.ToolStripMenuItemdps11.Size = new System.Drawing.Size(165, 22);
            this.ToolStripMenuItemdps11.Text = "显示图标和文字";
            // 
            // toolFileButton
            // 
            this.toolFileButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolItem_OpenImage,
            this.toolItem_save,
            this.toolItem_saveAs});
            this.toolFileButton.Image = ((System.Drawing.Image)(resources.GetObject("toolFileButton.Image")));
            this.toolFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolFileButton.Name = "toolFileButton";
            this.toolFileButton.Size = new System.Drawing.Size(65, 22);
            this.toolFileButton.Text = "打开";
            // 
            // toolItem_OpenImage
            // 
            this.toolItem_OpenImage.Image = ((System.Drawing.Image)(resources.GetObject("toolItem_OpenImage.Image")));
            this.toolItem_OpenImage.Name = "toolItem_OpenImage";
            this.toolItem_OpenImage.Size = new System.Drawing.Size(113, 22);
            this.toolItem_OpenImage.Text = "打开";
            this.toolItem_OpenImage.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // toolItem_save
            // 
            this.toolItem_save.Image = ((System.Drawing.Image)(resources.GetObject("toolItem_save.Image")));
            this.toolItem_save.Name = "toolItem_save";
            this.toolItem_save.Size = new System.Drawing.Size(113, 22);
            this.toolItem_save.Text = "保存";
            // 
            // toolItem_saveAs
            // 
            this.toolItem_saveAs.Image = ((System.Drawing.Image)(resources.GetObject("toolItem_saveAs.Image")));
            this.toolItem_saveAs.Name = "toolItem_saveAs";
            this.toolItem_saveAs.Size = new System.Drawing.Size(113, 22);
            this.toolItem_saveAs.Text = "另存为";
            // 
            // toolGrapButton
            // 
            this.toolGrapButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.采集ToolStripMenuItem,
            this.实时ToolStripMenuItem});
            this.toolGrapButton.Image = ((System.Drawing.Image)(resources.GetObject("toolGrapButton.Image")));
            this.toolGrapButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolGrapButton.Name = "toolGrapButton";
            this.toolGrapButton.Size = new System.Drawing.Size(65, 22);
            this.toolGrapButton.Text = "采集";
            // 
            // 采集ToolStripMenuItem
            // 
            this.采集ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("采集ToolStripMenuItem.Image")));
            this.采集ToolStripMenuItem.Name = "采集ToolStripMenuItem";
            this.采集ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.采集ToolStripMenuItem.Text = "采集";
            this.采集ToolStripMenuItem.Click += new System.EventHandler(this.采集ToolStripMenuItem_Click);
            // 
            // 实时ToolStripMenuItem
            // 
            this.实时ToolStripMenuItem.Name = "实时ToolStripMenuItem";
            this.实时ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.实时ToolStripMenuItem.Text = "实时采集";
            this.实时ToolStripMenuItem.Click += new System.EventHandler(this.实时ToolStripMenuItem_Click);
            // 
            // toolRun
            // 
            this.toolRun.Image = ((System.Drawing.Image)(resources.GetObject("toolRun.Image")));
            this.toolRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolRun.Name = "toolRun";
            this.toolRun.Size = new System.Drawing.Size(65, 22);
            this.toolRun.Text = "处理";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(45, 22);
            this.toolStripLabel1.Text = "-           ";
            // 
            // tbSet
            // 
            this.tbSet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbSet.Image = ((System.Drawing.Image)(resources.GetObject("tbSet.Image")));
            this.tbSet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSet.Name = "tbSet";
            this.tbSet.Size = new System.Drawing.Size(23, 22);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 22);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // toolStripSplitButton2
            // 
            this.toolStripSplitButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.填加ToolStripMenuItem,
            this.采集ToolStripMenuItem1});
            this.toolStripSplitButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton2.Image")));
            this.toolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton2.Name = "toolStripSplitButton2";
            this.toolStripSplitButton2.Size = new System.Drawing.Size(65, 22);
            this.toolStripSplitButton2.Text = "添加";
            // 
            // 填加ToolStripMenuItem
            // 
            this.填加ToolStripMenuItem.Name = "填加ToolStripMenuItem";
            this.填加ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.填加ToolStripMenuItem.Text = "填加";
            // 
            // 采集ToolStripMenuItem1
            // 
            this.采集ToolStripMenuItem1.Name = "采集ToolStripMenuItem1";
            this.采集ToolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.采集ToolStripMenuItem1.Text = "采集";
            // 
            // mainWindow
            // 
            this.mainWindow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mainWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainWindow.Location = new System.Drawing.Point(0, 25);
            this.mainWindow.Margin = new System.Windows.Forms.Padding(0);
            this.mainWindow.Name = "mainWindow";
            this.mainWindow.Size = new System.Drawing.Size(623, 538);
            this.mainWindow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mainWindow.TabIndex = 8;
            this.mainWindow.TabStop = false;
            // 
            // CCD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainWindow);
            this.Controls.Add(this.toolStrip1);
            this.Name = "CCD";
            this.Size = new System.Drawing.Size(623, 563);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainWindow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.ToolStripSplitButton toolZoom;
        public System.Windows.Forms.ToolStripMenuItem 放大ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem 缩小ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem 填充窗口ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem 适应图像ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem 清除图像ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem 相机参数设置ToolStripMenuItem;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripSplitButton toolButtonOption;
        public System.Windows.Forms.ToolStripMenuItem d3ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemdps01;
        public System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemdps11;
        public System.Windows.Forms.ToolStripSplitButton toolFileButton;
        public System.Windows.Forms.ToolStripMenuItem toolItem_OpenImage;
        public System.Windows.Forms.ToolStripMenuItem toolItem_save;
        public System.Windows.Forms.ToolStripMenuItem toolItem_saveAs;
        public System.Windows.Forms.ToolStripSplitButton toolGrapButton;
        public System.Windows.Forms.ToolStripMenuItem 采集ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem 实时ToolStripMenuItem;
        public System.Windows.Forms.ToolStripSplitButton toolRun;
        public System.Windows.Forms.ToolStripLabel toolStripLabel1;
        public System.Windows.Forms.ToolStripButton tbSet;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton2;
        private System.Windows.Forms.ToolStripMenuItem 填加ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 采集ToolStripMenuItem1;
        public System.Windows.Forms.PictureBox mainWindow;
    }
}
