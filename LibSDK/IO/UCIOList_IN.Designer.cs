namespace LibSDK.IO
{
    partial class UCIOList_IN
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
            this.txtName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.dgvIO = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIO)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtName.Location = new System.Drawing.Point(0, 0);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(607, 29);
            this.txtName.StateActive.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(204)))), ((int)(((byte)(230)))));
            this.txtName.StateActive.Content.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.StateNormal.Content.Font = new System.Drawing.Font("宋体", 12F);
            this.txtName.TabIndex = 3;
            this.txtName.Text = "IN_IO";
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvIO
            // 
            this.dgvIO.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIO.Location = new System.Drawing.Point(0, 29);
            this.dgvIO.Name = "dgvIO";
            this.dgvIO.RowHeadersWidth = 4;
            this.dgvIO.RowTemplate.Height = 50;
            this.dgvIO.Size = new System.Drawing.Size(607, 555);
            this.dgvIO.TabIndex = 4;
            // 
            // UCIOList_IN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvIO);
            this.Controls.Add(this.txtName);
            this.Name = "UCIOList_IN";
            this.Size = new System.Drawing.Size(607, 584);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIO)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtName;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvIO;
    }
}
