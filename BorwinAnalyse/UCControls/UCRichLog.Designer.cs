namespace BorwinAnalyse.UCControls
{
    partial class UCRichLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCRichLog));
            this.richLog = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.buttonSpecAny1 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.SuspendLayout();
            // 
            // richLog
            // 
            this.richLog.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.buttonSpecAny1});
            this.richLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richLog.HideSelection = false;
            this.richLog.Location = new System.Drawing.Point(0, 0);
            this.richLog.Name = "richLog";
            this.richLog.ReadOnly = true;
            this.richLog.Size = new System.Drawing.Size(347, 363);
            this.richLog.TabIndex = 0;
            this.richLog.Text = "";
            // 
            // buttonSpecAny1
            // 
            this.buttonSpecAny1.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Near;
            this.buttonSpecAny1.Image = ((System.Drawing.Image)(resources.GetObject("buttonSpecAny1.Image")));
            this.buttonSpecAny1.Orientation = ComponentFactory.Krypton.Toolkit.PaletteButtonOrientation.FixedLeft;
            this.buttonSpecAny1.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Alternate;
            this.buttonSpecAny1.Type = ComponentFactory.Krypton.Toolkit.PaletteButtonSpecStyle.FormMin;
            this.buttonSpecAny1.UniqueName = "6E4B46122B0E4367A494F0DA9EEE8D4F";
            this.buttonSpecAny1.Click += new System.EventHandler(this.buttonSpecAny1_Click);
            // 
            // UCRichLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.richLog);
            this.Name = "UCRichLog";
            this.Size = new System.Drawing.Size(347, 363);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox richLog;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny1;
    }
}
