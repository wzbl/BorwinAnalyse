namespace BorwinAnalyse.UCControls
{
    partial class UCPrint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCPrint));
            this.kryptonDataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.Column1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.Column2 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.Column3 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtPath = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lbPath = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.lbPrintName = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.btnPrint = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnDelete = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.comPrintName = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonDataGridView1
            // 
            this.kryptonDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kryptonDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.kryptonDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.kryptonDataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonDataGridView1.Name = "kryptonDataGridView1";
            this.kryptonDataGridView1.RowHeadersWidth = 51;
            this.kryptonDataGridView1.RowTemplate.Height = 27;
            this.kryptonDataGridView1.Size = new System.Drawing.Size(901, 518);
            this.kryptonDataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "System Fields";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 213;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Template Fields";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 212;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Value";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 213;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "Enable";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(124, 21);
            this.txtPath.Margin = new System.Windows.Forms.Padding(2);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(294, 23);
            this.txtPath.TabIndex = 1;
            // 
            // lbPath
            // 
            this.lbPath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.lbPath.Location = new System.Drawing.Point(50, 27);
            this.lbPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbPath.Name = "lbPath";
            this.lbPath.Size = new System.Drawing.Size(59, 15);
            this.lbPath.Text = "模板路径";
            // 
            // lbPrintName
            // 
            this.lbPrintName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbPrintName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.lbPrintName.Location = new System.Drawing.Point(47, 69);
            this.lbPrintName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbPrintName.Name = "lbPrintName";
            this.lbPrintName.Size = new System.Drawing.Size(72, 15);
            this.lbPrintName.Text = "打印机名称";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(648, 5);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(81, 81);
            this.btnPrint.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.StateCommon.Back.Image")));
            this.btnPrint.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Values.Text = "";
            this.btnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(770, 3);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(77, 82);
            this.btnDelete.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.StateCommon.Back.Image")));
            this.btnDelete.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Values.Text = "";
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(532, 5);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 81);
            this.btnSave.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.StateCommon.Back.Image")));
            this.btnSave.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnSave.TabIndex = 9;
            this.btnSave.Values.Text = "";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
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
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.comPrintName);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.btnSave);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.txtPath);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.btnDelete);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.lbPath);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.btnPrint);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.lbPrintName);
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.kryptonDataGridView1);
            this.kryptonSplitContainer1.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighInternalProfile;
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(901, 632);
            this.kryptonSplitContainer1.SplitterDistance = 109;
            this.kryptonSplitContainer1.TabIndex = 12;
            // 
            // comPrintName
            // 
            this.comPrintName.FormattingEnabled = true;
            this.comPrintName.Location = new System.Drawing.Point(124, 65);
            this.comPrintName.Name = "comPrintName";
            this.comPrintName.Size = new System.Drawing.Size(204, 20);
            this.comPrintName.TabIndex = 12;
            // 
            // UCPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonSplitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UCPrint";
            this.Size = new System.Drawing.Size(901, 632);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            this.kryptonSplitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kryptonDataGridView1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPath;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel lbPath;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel lbPrintName;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnPrint;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnDelete;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private System.Windows.Forms.ComboBox comPrintName;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn Column1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn Column2;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column4;
    }
}
