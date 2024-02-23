namespace LibSDK.Enums
{
    partial class UCMotionParam
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
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolAddCard = new System.Windows.Forms.ToolStripMenuItem();
            this.toolDeleteCard = new System.Windows.Forms.ToolStripMenuItem();
            this.ucMotionParamSet1 = new LibSDK.UCMotionParamSet();
            this.ucCardParamSet = new LibSDK.UCMotionParamSet();
            this.ucOUTIOParam = new LibSDK.UCMotionParamSet();
            this.ucINIOParam = new LibSDK.UCMotionParamSet();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip4 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.contextMenuStrip3.SuspendLayout();
            this.contextMenuStrip4.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.ucMotionParamSet1);
            this.kryptonPanel1.Controls.Add(this.ucCardParamSet);
            this.kryptonPanel1.Controls.Add(this.ucOUTIOParam);
            this.kryptonPanel1.Controls.Add(this.ucINIOParam);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1285, 675);
            this.kryptonPanel1.TabIndex = 7;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存ToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 48);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.保存ToolStripMenuItem.Text = "Add";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAddCard,
            this.toolDeleteCard});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(108, 48);
            // 
            // toolAddCard
            // 
            this.toolAddCard.Name = "toolAddCard";
            this.toolAddCard.Size = new System.Drawing.Size(107, 22);
            this.toolAddCard.Text = "Add";
            this.toolAddCard.Click += new System.EventHandler(this.toolAddCard_Click);
            // 
            // toolDeleteCard
            // 
            this.toolDeleteCard.Name = "toolDeleteCard";
            this.toolDeleteCard.Size = new System.Drawing.Size(107, 22);
            this.toolDeleteCard.Text = "Delete";
            this.toolDeleteCard.Click += new System.EventHandler(this.toolDeleteCard_Click);
            // 
            // ucMotionParamSet1
            // 
            this.ucMotionParamSet1.ContextMenuStrip = this.contextMenuStrip1;
            this.ucMotionParamSet1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMotionParamSet1.Location = new System.Drawing.Point(0, 0);
            this.ucMotionParamSet1.Name = "ucMotionParamSet1";
            this.ucMotionParamSet1.Size = new System.Drawing.Size(307, 675);
            this.ucMotionParamSet1.TabIndex = 3;
            this.ucMotionParamSet1.Tag = "Axis";
            this.ucMotionParamSet1.标题 = "轴配置";
            this.ucMotionParamSet1.Load += new System.EventHandler(this.ucMotionParamSet1_Load);
            // 
            // ucCardParamSet
            // 
            this.ucCardParamSet.ContextMenuStrip = this.contextMenuStrip2;
            this.ucCardParamSet.Dock = System.Windows.Forms.DockStyle.Right;
            this.ucCardParamSet.Location = new System.Drawing.Point(307, 0);
            this.ucCardParamSet.Name = "ucCardParamSet";
            this.ucCardParamSet.Size = new System.Drawing.Size(295, 675);
            this.ucCardParamSet.TabIndex = 4;
            this.ucCardParamSet.Tag = "BaseConfig";
            this.ucCardParamSet.标题 = "基础配置";
            // 
            // ucOUTIOParam
            // 
            this.ucOUTIOParam.ContextMenuStrip = this.contextMenuStrip3;
            this.ucOUTIOParam.Dock = System.Windows.Forms.DockStyle.Right;
            this.ucOUTIOParam.Location = new System.Drawing.Point(602, 0);
            this.ucOUTIOParam.Name = "ucOUTIOParam";
            this.ucOUTIOParam.Size = new System.Drawing.Size(352, 675);
            this.ucOUTIOParam.TabIndex = 6;
            this.ucOUTIOParam.Tag = "OUTIO";
            this.ucOUTIOParam.标题 = "输出IO配置";
            // 
            // ucINIOParam
            // 
            this.ucINIOParam.ContextMenuStrip = this.contextMenuStrip4;
            this.ucINIOParam.Dock = System.Windows.Forms.DockStyle.Right;
            this.ucINIOParam.Location = new System.Drawing.Point(954, 0);
            this.ucINIOParam.Name = "ucINIOParam";
            this.ucINIOParam.Size = new System.Drawing.Size(331, 675);
            this.ucINIOParam.TabIndex = 5;
            this.ucINIOParam.Tag = "INIO";
            this.ucINIOParam.标题 = "输入IO配置";
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.contextMenuStrip3.Name = "contextMenuStrip1";
            this.contextMenuStrip3.Size = new System.Drawing.Size(108, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "Add";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem2.Text = "Delete";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // contextMenuStrip4
            // 
            this.contextMenuStrip4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.contextMenuStrip4.Name = "contextMenuStrip1";
            this.contextMenuStrip4.Size = new System.Drawing.Size(181, 70);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem3.Text = "Add";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem4.Text = "Delete";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // UCMotionParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "UCMotionParam";
            this.Size = new System.Drawing.Size(1285, 675);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip3.ResumeLayout(false);
            this.contextMenuStrip4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public UCMotionParamSet ucINIOParam;
        public UCMotionParamSet ucOUTIOParam;
        public UCMotionParamSet ucMotionParamSet1;
        public UCMotionParamSet ucCardParamSet;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolAddCard;
        private System.Windows.Forms.ToolStripMenuItem toolDeleteCard;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
    }
}
