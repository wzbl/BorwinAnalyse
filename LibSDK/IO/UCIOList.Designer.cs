namespace LibSDK.IO
{
    partial class UCIOList
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
            this.components = new System.ComponentModel.Container();
            this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.ucioList_IN1 = new LibSDK.IO.UCIOList_IN();
            this.ucioList_OUT1 = new LibSDK.IO.UCIOList_OUT();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
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
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.ucioList_IN1);
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.ucioList_OUT1);
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(815, 586);
            this.kryptonSplitContainer1.SplitterDistance = 402;
            this.kryptonSplitContainer1.TabIndex = 0;
            // 
            // ucioList_IN1
            // 
            this.ucioList_IN1.BackColor = System.Drawing.Color.Transparent;
            this.ucioList_IN1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucioList_IN1.Location = new System.Drawing.Point(0, 0);
            this.ucioList_IN1.Name = "ucioList_IN1";
            this.ucioList_IN1.Size = new System.Drawing.Size(402, 586);
            this.ucioList_IN1.TabIndex = 0;
            // 
            // ucioList_OUT1
            // 
            this.ucioList_OUT1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucioList_OUT1.Location = new System.Drawing.Point(0, 0);
            this.ucioList_OUT1.Name = "ucioList_OUT1";
            this.ucioList_OUT1.Size = new System.Drawing.Size(408, 586);
            this.ucioList_OUT1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // UCIOList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonSplitContainer1);
            this.Name = "UCIOList";
            this.Size = new System.Drawing.Size(815, 586);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private UCIOList_IN ucioList_IN1;
        private System.Windows.Forms.Timer timer1;
        private UCIOList_OUT ucioList_OUT1;
    }
}
