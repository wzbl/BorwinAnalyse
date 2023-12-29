namespace BorwinSplicMachine.FlowModel
{
    partial class UCFlowControl
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
            this.保存模板ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开模板ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.运行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存模板ToolStripMenuItem,
            this.打开模板ToolStripMenuItem,
            this.运行ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 92);
            // 
            // 保存模板ToolStripMenuItem
            // 
            this.保存模板ToolStripMenuItem.Name = "保存模板ToolStripMenuItem";
            this.保存模板ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.保存模板ToolStripMenuItem.Text = "保存模板";
            this.保存模板ToolStripMenuItem.Click += new System.EventHandler(this.保存模板ToolStripMenuItem_Click);
            // 
            // 打开模板ToolStripMenuItem
            // 
            this.打开模板ToolStripMenuItem.Name = "打开模板ToolStripMenuItem";
            this.打开模板ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.打开模板ToolStripMenuItem.Text = "打开模板";
            this.打开模板ToolStripMenuItem.Click += new System.EventHandler(this.打开模板ToolStripMenuItem_Click);
            // 
            // 运行ToolStripMenuItem
            // 
            this.运行ToolStripMenuItem.Name = "运行ToolStripMenuItem";
            this.运行ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.运行ToolStripMenuItem.Text = "运行";
            this.运行ToolStripMenuItem.Click += new System.EventHandler(this.运行ToolStripMenuItem_Click);
            // 
            // UCFlowControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(71)))), ((int)(((byte)(74)))));
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Name = "UCFlowControl";
            this.Size = new System.Drawing.Size(793, 592);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UCFlowControl_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UCFlowControl_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.UCFlowControl_MouseUp);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 保存模板ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开模板ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 运行ToolStripMenuItem;
    }
}
