namespace BorwinAnalyse.UCControls
{
    partial class UCUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCUser));
            this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.kryptonDataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.EmpNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLogin = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnDeleteModel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnUpdataBom = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lbLevel = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.btnRegi = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lbUserName = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.comLevel = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.lbPass = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.txtPass = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtUserName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comLevel)).BeginInit();
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
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.kryptonDataGridView1);
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.btnLogin);
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.btnDeleteModel);
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.btnUpdataBom);
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.lbLevel);
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.btnRegi);
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.lbUserName);
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.comLevel);
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.lbPass);
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.txtPass);
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.txtUserName);
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(870, 480);
            this.kryptonSplitContainer1.SplitterDistance = 580;
            this.kryptonSplitContainer1.TabIndex = 0;
            // 
            // kryptonDataGridView1
            // 
            this.kryptonDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kryptonDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmpNo,
            this.colName,
            this.Pass,
            this.Level});
            this.kryptonDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.kryptonDataGridView1.Name = "kryptonDataGridView1";
            this.kryptonDataGridView1.RowTemplate.Height = 23;
            this.kryptonDataGridView1.Size = new System.Drawing.Size(580, 480);
            this.kryptonDataGridView1.TabIndex = 0;
            // 
            // EmpNo
            // 
            this.EmpNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EmpNo.HeaderText = "工号";
            this.EmpNo.Name = "EmpNo";
            // 
            // Name
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.HeaderText = "名称";
            this.colName.Name = "Name";
            // 
            // Pass
            // 
            this.Pass.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Pass.HeaderText = "密码";
            this.Pass.Name = "Pass";
            // 
            // Level
            // 
            this.Level.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Level.HeaderText = "等级";
            this.Level.Name = "Level";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(166, 144);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(76, 73);
            this.btnLogin.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnLogin.StateCommon.Back.Image")));
            this.btnLogin.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnLogin.TabIndex = 42;
            this.btnLogin.Values.Text = "";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnDeleteModel
            // 
            this.btnDeleteModel.Location = new System.Drawing.Point(51, 252);
            this.btnDeleteModel.Name = "btnDeleteModel";
            this.btnDeleteModel.Size = new System.Drawing.Size(74, 70);
            this.btnDeleteModel.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteModel.StateCommon.Back.Image")));
            this.btnDeleteModel.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnDeleteModel.TabIndex = 41;
            this.btnDeleteModel.Values.Text = "";
            this.btnDeleteModel.Click += new System.EventHandler(this.btnDeleteModel_Click);
            // 
            // btnUpdataBom
            // 
            this.btnUpdataBom.Location = new System.Drawing.Point(51, 147);
            this.btnUpdataBom.Name = "btnUpdataBom";
            this.btnUpdataBom.Size = new System.Drawing.Size(74, 70);
            this.btnUpdataBom.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdataBom.StateCommon.Back.Image")));
            this.btnUpdataBom.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnUpdataBom.TabIndex = 40;
            this.btnUpdataBom.Values.Text = "";
            this.btnUpdataBom.Click += new System.EventHandler(this.btnUpdataBom_Click);
            // 
            // lbLevel
            // 
            this.lbLevel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.lbLevel.Location = new System.Drawing.Point(65, 23);
            this.lbLevel.Name = "lbLevel";
            this.lbLevel.Size = new System.Drawing.Size(34, 15);
            this.lbLevel.Text = "Level";
            // 
            // btnRegi
            // 
            this.btnRegi.Location = new System.Drawing.Point(166, 253);
            this.btnRegi.Name = "btnRegi";
            this.btnRegi.Size = new System.Drawing.Size(76, 69);
            this.btnRegi.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnRegi.StateCommon.Back.Image")));
            this.btnRegi.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnRegi.TabIndex = 32;
            this.btnRegi.Values.Text = "";
            this.btnRegi.Click += new System.EventHandler(this.btnRegi_Click);
            // 
            // lbUserName
            // 
            this.lbUserName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.lbUserName.Location = new System.Drawing.Point(63, 64);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(30, 15);
            this.lbUserName.Text = "User";
            // 
            // comLevel
            // 
            this.comLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comLevel.DropDownWidth = 121;
            this.comLevel.Items.AddRange(new object[] {
            "Oprator",
            "Technician",
            "Engineer",
            "Admin"});
            this.comLevel.Location = new System.Drawing.Point(121, 20);
            this.comLevel.Name = "comLevel";
            this.comLevel.Size = new System.Drawing.Size(121, 21);
            this.comLevel.TabIndex = 29;
            // 
            // lbPass
            // 
            this.lbPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.lbPass.Location = new System.Drawing.Point(51, 108);
            this.lbPass.Name = "lbPass";
            this.lbPass.Size = new System.Drawing.Size(59, 15);
            this.lbPass.Text = "PassWord";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(121, 104);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '●';
            this.txtPass.Size = new System.Drawing.Size(121, 23);
            this.txtPass.TabIndex = 31;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(121, 61);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(121, 23);
            this.txtUserName.TabIndex = 30;
            // 
            // UCUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonSplitContainer1);
            this.Name = "UCUser";
            this.Size = new System.Drawing.Size(870, 480);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            this.kryptonSplitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comLevel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel lbLevel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnRegi;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel lbUserName;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox comLevel;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel lbPass;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPass;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtUserName;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kryptonDataGridView1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnUpdataBom;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnDeleteModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pass;
        private System.Windows.Forms.DataGridViewTextBoxColumn Level;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnLogin;
    }
}
