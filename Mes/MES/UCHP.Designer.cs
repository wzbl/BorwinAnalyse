namespace Mes.MES
{
    partial class UCHP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCHP));
            this.kryptonSplitContainer2 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.DataGridViewOut = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.btnDelete = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnRun = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2.Panel1)).BeginInit();
            this.kryptonSplitContainer2.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2.Panel2)).BeginInit();
            this.kryptonSplitContainer2.Panel2.SuspendLayout();
            this.kryptonSplitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewOut)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonSplitContainer2
            // 
            this.kryptonSplitContainer2.Cursor = System.Windows.Forms.Cursors.Default;
            this.kryptonSplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonSplitContainer2.Location = new System.Drawing.Point(0, 0);
            this.kryptonSplitContainer2.Name = "kryptonSplitContainer2";
            // 
            // kryptonSplitContainer2.Panel1
            // 
            this.kryptonSplitContainer2.Panel1.Controls.Add(this.DataGridViewOut);
            // 
            // kryptonSplitContainer2.Panel2
            // 
            this.kryptonSplitContainer2.Panel2.Controls.Add(this.btnDelete);
            this.kryptonSplitContainer2.Panel2.Controls.Add(this.btnRun);
            this.kryptonSplitContainer2.Size = new System.Drawing.Size(950, 258);
            this.kryptonSplitContainer2.SplitterDistance = 780;
            this.kryptonSplitContainer2.TabIndex = 2;
            // 
            // DataGridViewOut
            // 
            this.DataGridViewOut.AllowUserToAddRows = false;
            this.DataGridViewOut.AllowUserToDeleteRows = false;
            this.DataGridViewOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridViewOut.Location = new System.Drawing.Point(0, 0);
            this.DataGridViewOut.Name = "DataGridViewOut";
            this.DataGridViewOut.RowTemplate.Height = 23;
            this.DataGridViewOut.Size = new System.Drawing.Size(780, 258);
            this.DataGridViewOut.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(81, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(74, 71);
            this.btnDelete.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.StateCommon.Back.Image")));
            this.btnDelete.StateCommon.Back.ImageAlign = ComponentFactory.Krypton.Toolkit.PaletteRectangleAlign.Control;
            this.btnDelete.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Values.Text = "";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(4, 0);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(74, 72);
            this.btnRun.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnRun.StateCommon.Back.Image")));
            this.btnRun.StateCommon.Back.ImageAlign = ComponentFactory.Krypton.Toolkit.PaletteRectangleAlign.Control;
            this.btnRun.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnRun.TabIndex = 8;
            this.btnRun.Values.Text = "";
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // UCHP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonSplitContainer2);
            this.Name = "UCHP";
            this.Size = new System.Drawing.Size(950, 258);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2.Panel1)).EndInit();
            this.kryptonSplitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2.Panel2)).EndInit();
            this.kryptonSplitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2)).EndInit();
            this.kryptonSplitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewOut)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer2;
        protected ComponentFactory.Krypton.Toolkit.KryptonDataGridView DataGridViewOut;
        protected ComponentFactory.Krypton.Toolkit.KryptonButton btnRun;
        protected ComponentFactory.Krypton.Toolkit.KryptonButton btnDelete;
    }
}
