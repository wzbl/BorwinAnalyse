namespace BorwinSplicMachine.FlowModel
{
    partial class FlowBaseModel
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除控件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除父节点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除左节点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除右节点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除下节点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除控件ToolStripMenuItem,
            this.删除父节点ToolStripMenuItem,
            this.删除左节点ToolStripMenuItem,
            this.删除右节点ToolStripMenuItem,
            this.删除下节点ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 136);
            // 
            // 删除控件ToolStripMenuItem
            // 
            this.删除控件ToolStripMenuItem.Name = "删除控件ToolStripMenuItem";
            this.删除控件ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.删除控件ToolStripMenuItem.Text = "删除控件";
            this.删除控件ToolStripMenuItem.Click += new System.EventHandler(this.删除控件ToolStripMenuItem_Click);
            // 
            // 删除父节点ToolStripMenuItem
            // 
            this.删除父节点ToolStripMenuItem.Name = "删除父节点ToolStripMenuItem";
            this.删除父节点ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.删除父节点ToolStripMenuItem.Text = "删除上节点";
            this.删除父节点ToolStripMenuItem.Click += new System.EventHandler(this.删除父节点ToolStripMenuItem_Click);
            // 
            // 删除左节点ToolStripMenuItem
            // 
            this.删除左节点ToolStripMenuItem.Name = "删除左节点ToolStripMenuItem";
            this.删除左节点ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.删除左节点ToolStripMenuItem.Text = "删除左节点";
            this.删除左节点ToolStripMenuItem.Click += new System.EventHandler(this.删除左节点ToolStripMenuItem_Click);
            // 
            // 删除右节点ToolStripMenuItem
            // 
            this.删除右节点ToolStripMenuItem.Name = "删除右节点ToolStripMenuItem";
            this.删除右节点ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.删除右节点ToolStripMenuItem.Text = "删除右节点";
            this.删除右节点ToolStripMenuItem.Click += new System.EventHandler(this.删除右节点ToolStripMenuItem_Click);
            // 
            // 删除下节点ToolStripMenuItem
            // 
            this.删除下节点ToolStripMenuItem.Name = "删除下节点ToolStripMenuItem";
            this.删除下节点ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.删除下节点ToolStripMenuItem.Text = "删除下节点";
            this.删除下节点ToolStripMenuItem.Click += new System.EventHandler(this.删除下节点ToolStripMenuItem_Click);
            // 
            // FlowBaseModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(225)))), ((int)(((byte)(222)))));
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Name = "FlowBaseModel";
            this.Size = new System.Drawing.Size(126, 39);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FlowBaseModel_MouseDown);
            this.MouseEnter += new System.EventHandler(this.FlowBaseModel_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.FlowBaseModel_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FlowBaseModel_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FlowBaseModel_MouseUp);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除控件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除父节点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除左节点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除右节点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除下节点ToolStripMenuItem;
    }
}
