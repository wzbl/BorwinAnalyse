﻿namespace BorwinAnalyse.UCControls
{
    partial class UCSearchLanguage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCSearchLanguage));
            this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.txtName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonWrapLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.btnSearch = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnUpdate = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnDelete = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnImPort = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnExport = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.DGV_Language = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.Column1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.Column2 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.Column3 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.Column4 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.Column5 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.Column6 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.Column7 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.Column8 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Language)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonSplitContainer1
            // 
            this.kryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.kryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.kryptonSplitContainer1.Name = "kryptonSplitContainer1";
            this.kryptonSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // kryptonSplitContainer1.Panel1
            // 
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.txtName);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.kryptonWrapLabel1);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.btnSearch);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.btnUpdate);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.btnDelete);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.btnImPort);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.btnExport);
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.DGV_Language);
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(1387, 614);
            this.kryptonSplitContainer1.SplitterDistance = 86;
            this.kryptonSplitContainer1.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(134, 31);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(253, 23);
            this.txtName.TabIndex = 7;
            // 
            // kryptonWrapLabel1
            // 
            this.kryptonWrapLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel1.Location = new System.Drawing.Point(67, 39);
            this.kryptonWrapLabel1.Name = "kryptonWrapLabel1";
            this.kryptonWrapLabel1.Size = new System.Drawing.Size(59, 15);
            this.kryptonWrapLabel1.Text = "默认文本";
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSearch.Location = new System.Drawing.Point(957, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnSearch.OverrideDefault.Back.Color2 = System.Drawing.Color.Cyan;
            this.btnSearch.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSearch.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSearch.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSearch.OverrideFocus.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnSearch.OverrideFocus.Back.Color2 = System.Drawing.Color.Lime;
            this.btnSearch.Size = new System.Drawing.Size(86, 86);
            this.btnSearch.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.StateCommon.Back.Image")));
            this.btnSearch.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Values.Text = "";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnUpdate.Location = new System.Drawing.Point(1043, 0);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(86, 86);
            this.btnUpdate.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.StateCommon.Back.Image")));
            this.btnUpdate.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Values.Text = "";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelete.Location = new System.Drawing.Point(1129, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(86, 86);
            this.btnDelete.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.StateCommon.Back.Image")));
            this.btnDelete.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Values.Text = "";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnImPort
            // 
            this.btnImPort.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnImPort.Location = new System.Drawing.Point(1215, 0);
            this.btnImPort.Name = "btnImPort";
            this.btnImPort.Size = new System.Drawing.Size(86, 86);
            this.btnImPort.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnImPort.StateCommon.Back.Image")));
            this.btnImPort.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnImPort.TabIndex = 1;
            this.btnImPort.Values.Text = "";
            this.btnImPort.Click += new System.EventHandler(this.btnImPort_Click);
            // 
            // btnExport
            // 
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExport.Location = new System.Drawing.Point(1301, 0);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(86, 86);
            this.btnExport.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.StateCommon.Back.Image")));
            this.btnExport.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnExport.TabIndex = 0;
            this.btnExport.Values.Text = "";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // DGV_Language
            // 
            this.DGV_Language.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_Language.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Language.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.DGV_Language.ContextMenuStrip = this.contextMenuStrip1;
            this.DGV_Language.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Language.Location = new System.Drawing.Point(0, 0);
            this.DGV_Language.Name = "DGV_Language";
            this.DGV_Language.RowTemplate.Height = 23;
            this.DGV_Language.Size = new System.Drawing.Size(1387, 523);
            this.DGV_Language.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "默认文本";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.Width = 168;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "中文";
            this.Column2.Name = "Column2";
            this.Column2.Width = 169;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "英文";
            this.Column3.Name = "Column3";
            this.Column3.Width = 168;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "exp1";
            this.Column4.Name = "Column4";
            this.Column4.Width = 168;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "exp2";
            this.Column5.Name = "Column5";
            this.Column5.Width = 168;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "exp3";
            this.Column6.Name = "Column6";
            this.Column6.Width = 169;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "exp4";
            this.Column7.Name = "Column7";
            this.Column7.Width = 168;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "exp5";
            this.Column8.Name = "Column8";
            this.Column8.Width = 168;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.导入ToolStripMenuItem,
            this.导出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 114);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.deleteToolStripMenuItem.Text = "查找";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.searchToolStripMenuItem.Text = "更新";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // 导入ToolStripMenuItem
            // 
            this.导入ToolStripMenuItem.Name = "导入ToolStripMenuItem";
            this.导入ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.导入ToolStripMenuItem.Text = "导入";
            this.导入ToolStripMenuItem.Click += new System.EventHandler(this.btnImPort_Click);
            // 
            // 导出ToolStripMenuItem
            // 
            this.导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
            this.导出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.导出ToolStripMenuItem.Text = "导出";
            this.导出ToolStripMenuItem.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // UCSearchLanguage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonSplitContainer1);
            this.Name = "UCSearchLanguage";
            this.Size = new System.Drawing.Size(1387, 614);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            this.kryptonSplitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Language)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtName;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSearch;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnUpdate;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnDelete;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnImPort;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnExport;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView DGV_Language;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn Column1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn Column2;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn Column3;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn Column4;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn Column5;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn Column6;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn Column7;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出ToolStripMenuItem;
    }
}
