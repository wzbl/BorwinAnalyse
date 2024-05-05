namespace BorwinSplicMachine.UCControls
{
    partial class UCLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCLog));
            this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.btnSearch = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnDelete = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.comType = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.endTime = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.startTime = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonWrapLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonWrapLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonDataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.序号 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.时间 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.类型 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.内容 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.操作员 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).BeginInit();
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
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.btnSearch);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.btnDelete);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.comType);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.endTime);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.startTime);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.kryptonWrapLabel2);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.kryptonWrapLabel1);
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.kryptonDataGridView1);
            this.kryptonSplitContainer1.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighProfile;
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(1149, 596);
            this.kryptonSplitContainer1.SplitterDistance = 74;
            this.kryptonSplitContainer1.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(437, 0);
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
            this.btnSearch.Size = new System.Drawing.Size(72, 67);
            this.btnSearch.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.StateCommon.Back.Image")));
            this.btnSearch.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnSearch.StateNormal.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnSearch.StatePressed.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnSearch.StateTracking.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Values.Text = "";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(786, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(70, 68);
            this.btnDelete.StateNormal.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.StateNormal.Back.Image")));
            this.btnDelete.StateNormal.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnDelete.StatePressed.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.StatePressed.Back.Image")));
            this.btnDelete.StatePressed.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnDelete.StateTracking.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.StateTracking.Back.Image")));
            this.btnDelete.StateTracking.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Values.Text = "";
            this.btnDelete.Visible = false;
            // 
            // comType
            // 
            this.comType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comType.DropDownWidth = 164;
            this.comType.Items.AddRange(new object[] {
            "ALL",
            "操作日志",
            "扫码日志",
            "测值日志",
            "相机日志",
            "运动日志",
            "Mes日志"});
            this.comType.Location = new System.Drawing.Point(71, 35);
            this.comType.Name = "comType";
            this.comType.Size = new System.Drawing.Size(164, 21);
            this.comType.TabIndex = 4;
            // 
            // endTime
            // 
            this.endTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.endTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endTime.Location = new System.Drawing.Point(241, 8);
            this.endTime.MaxDate = new System.DateTime(2070, 12, 31, 0, 0, 0, 0);
            this.endTime.MinDate = new System.DateTime(2023, 12, 20, 0, 0, 0, 0);
            this.endTime.Name = "endTime";
            this.endTime.Size = new System.Drawing.Size(143, 21);
            this.endTime.TabIndex = 3;
            // 
            // startTime
            // 
            this.startTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.startTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startTime.Location = new System.Drawing.Point(71, 8);
            this.startTime.MaxDate = new System.DateTime(2070, 12, 31, 0, 0, 0, 0);
            this.startTime.MinDate = new System.DateTime(2023, 12, 20, 0, 0, 0, 0);
            this.startTime.Name = "startTime";
            this.startTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.startTime.Size = new System.Drawing.Size(164, 21);
            this.startTime.TabIndex = 2;
            // 
            // kryptonWrapLabel2
            // 
            this.kryptonWrapLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel2.Location = new System.Drawing.Point(17, 41);
            this.kryptonWrapLabel2.Name = "kryptonWrapLabel2";
            this.kryptonWrapLabel2.Size = new System.Drawing.Size(33, 15);
            this.kryptonWrapLabel2.Text = "类型";
            // 
            // kryptonWrapLabel1
            // 
            this.kryptonWrapLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel1.Location = new System.Drawing.Point(15, 14);
            this.kryptonWrapLabel1.Name = "kryptonWrapLabel1";
            this.kryptonWrapLabel1.Size = new System.Drawing.Size(33, 15);
            this.kryptonWrapLabel1.Text = "时间";
            // 
            // kryptonDataGridView1
            // 
            this.kryptonDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kryptonDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.序号,
            this.时间,
            this.类型,
            this.内容,
            this.操作员});
            this.kryptonDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.kryptonDataGridView1.Name = "kryptonDataGridView1";
            this.kryptonDataGridView1.RowTemplate.Height = 23;
            this.kryptonDataGridView1.Size = new System.Drawing.Size(1149, 517);
            this.kryptonDataGridView1.TabIndex = 0;
            // 
            // 序号
            // 
            this.序号.HeaderText = "序号";
            this.序号.Name = "序号";
            this.序号.Width = 100;
            // 
            // 时间
            // 
            this.时间.FillWeight = 200F;
            this.时间.HeaderText = "时间";
            this.时间.Name = "时间";
            this.时间.Width = 200;
            // 
            // 类型
            // 
            this.类型.HeaderText = "类型";
            this.类型.Name = "类型";
            this.类型.Width = 100;
            // 
            // 内容
            // 
            this.内容.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.内容.FillWeight = 500F;
            this.内容.HeaderText = "内容";
            this.内容.Name = "内容";
            this.内容.Width = 608;
            // 
            // 操作员
            // 
            this.操作员.HeaderText = "操作员";
            this.操作员.Name = "操作员";
            // 
            // UCLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonSplitContainer1);
            this.Name = "UCLog";
            this.Size = new System.Drawing.Size(1149, 596);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            this.kryptonSplitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kryptonDataGridView1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn 序号;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn 时间;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn 类型;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn 内容;
        private System.Windows.Forms.DataGridViewTextBoxColumn 操作员;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox comType;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker endTime;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker startTime;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSearch;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnDelete;
    }
}
