namespace BorwinSplicMachine.LCR
{
    partial class UCLCRSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCLCRSearch));
            this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.endDateTime = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.startDateTime = new System.Windows.Forms.DateTimePicker();
            this.btnExport = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnImport = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.boundGridView1 = new BorwinSplicMachine.LCR.BoundGridView();
            this.boundGridView2 = new BorwinSplicMachine.LCR.BoundGridView();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boundGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boundGridView2)).BeginInit();
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
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.label1);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.endDateTime);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.label4);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.startDateTime);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.btnExport);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.btnImport);
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.boundGridView1);
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.boundGridView2);
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(1320, 723);
            this.kryptonSplitContainer1.SplitterDistance = 87;
            this.kryptonSplitContainer1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 18F);
            this.label1.Location = new System.Drawing.Point(311, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 24);
            this.label1.TabIndex = 14;
            this.label1.Text = "-";
            // 
            // endDateTime
            // 
            this.endDateTime.CalendarMonthBackground = System.Drawing.Color.Transparent;
            this.endDateTime.CustomFormat = "yyyy-MM-dd";
            this.endDateTime.Font = new System.Drawing.Font("宋体", 20F);
            this.endDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endDateTime.Location = new System.Drawing.Point(334, 16);
            this.endDateTime.Name = "endDateTime";
            this.endDateTime.Size = new System.Drawing.Size(178, 38);
            this.endDateTime.TabIndex = 13;
            this.endDateTime.Value = new System.DateTime(2024, 1, 4, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("宋体", 18F);
            this.label4.Location = new System.Drawing.Point(45, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 24);
            this.label4.TabIndex = 12;
            this.label4.Text = "日期:";
            // 
            // startDateTime
            // 
            this.startDateTime.CalendarMonthBackground = System.Drawing.Color.Transparent;
            this.startDateTime.CustomFormat = "yyyy-MM-dd";
            this.startDateTime.Font = new System.Drawing.Font("宋体", 20F);
            this.startDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDateTime.Location = new System.Drawing.Point(133, 16);
            this.startDateTime.Name = "startDateTime";
            this.startDateTime.Size = new System.Drawing.Size(178, 38);
            this.startDateTime.TabIndex = 11;
            this.startDateTime.Value = new System.DateTime(2024, 1, 4, 0, 0, 0, 0);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(711, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(92, 71);
            this.btnExport.StateNormal.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.StateNormal.Back.Image")));
            this.btnExport.StateNormal.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnExport.StatePressed.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.StatePressed.Back.Image")));
            this.btnExport.StatePressed.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnExport.StateTracking.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.StateTracking.Back.Image")));
            this.btnExport.StateTracking.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnExport.TabIndex = 1;
            this.btnExport.Values.Text = "";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(593, 3);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(91, 71);
            this.btnImport.StateNormal.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.StateNormal.Back.Image")));
            this.btnImport.StateNormal.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnImport.StatePressed.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.StatePressed.Back.Image")));
            this.btnImport.StatePressed.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnImport.StateTracking.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.StateTracking.Back.Image")));
            this.btnImport.StateTracking.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnImport.TabIndex = 0;
            this.btnImport.Values.Text = "";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // boundGridView1
            // 
            this.boundGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.boundGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boundGridView1.Location = new System.Drawing.Point(0, 253);
            this.boundGridView1.Name = "boundGridView1";
            this.boundGridView1.RowTemplate.Height = 23;
            this.boundGridView1.Size = new System.Drawing.Size(1320, 378);
            this.boundGridView1.TabIndex = 2;
            // 
            // boundGridView2
            // 
            this.boundGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.boundGridView2.Dock = System.Windows.Forms.DockStyle.Top;
            this.boundGridView2.Location = new System.Drawing.Point(0, 0);
            this.boundGridView2.Name = "boundGridView2";
            this.boundGridView2.RowTemplate.Height = 23;
            this.boundGridView2.Size = new System.Drawing.Size(1320, 253);
            this.boundGridView2.TabIndex = 1;
            // 
            // UCLCRSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonSplitContainer1);
            this.Name = "UCLCRSearch";
            this.Size = new System.Drawing.Size(1320, 723);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            this.kryptonSplitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.boundGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boundGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private BoundGridView boundGridView2;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnExport;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnImport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker endDateTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker startDateTime;
        private BoundGridView boundGridView1;
    }
}
