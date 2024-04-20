namespace BorwinSplicMachine
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnLogOut = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnLogin = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnRegi = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtPass = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lbPass = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.txtUserName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.comLevel = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.lbUserName = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.lbLevel = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.btnOSK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.comLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.White;
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 239);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(412, 29);
            this.progressBar1.TabIndex = 0;
            this.progressBar1.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(333, 3);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(76, 73);
            this.btnLogOut.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnLogOut.StateCommon.Back.Image")));
            this.btnLogOut.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnLogOut.TabIndex = 21;
            this.btnLogOut.Values.Text = "";
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(259, 160);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(76, 73);
            this.btnLogin.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnLogin.StateCommon.Back.Image")));
            this.btnLogin.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnLogin.TabIndex = 20;
            this.btnLogin.Values.Text = "";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnRegi
            // 
            this.btnRegi.Location = new System.Drawing.Point(64, 164);
            this.btnRegi.Name = "btnRegi";
            this.btnRegi.Size = new System.Drawing.Size(76, 69);
            this.btnRegi.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnRegi.StateCommon.Back.Image")));
            this.btnRegi.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnRegi.TabIndex = 19;
            this.btnRegi.Values.Text = "";
            this.btnRegi.Click += new System.EventHandler(this.btnRegi_Click);
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(151, 119);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '●';
            this.txtPass.Size = new System.Drawing.Size(121, 23);
            this.txtPass.TabIndex = 18;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // lbPass
            // 
            this.lbPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.lbPass.Location = new System.Drawing.Point(81, 123);
            this.lbPass.Name = "lbPass";
            this.lbPass.Size = new System.Drawing.Size(59, 15);
            this.lbPass.Text = "PassWord";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(151, 76);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(121, 23);
            this.txtUserName.TabIndex = 17;
            // 
            // comLevel
            // 
            this.comLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comLevel.DropDownWidth = 121;
            this.comLevel.Items.AddRange(new object[] {
            "Operator",
            "Administrator",
            "Engineer"});
            this.comLevel.Location = new System.Drawing.Point(151, 35);
            this.comLevel.Name = "comLevel";
            this.comLevel.Size = new System.Drawing.Size(121, 21);
            this.comLevel.TabIndex = 16;
            // 
            // lbUserName
            // 
            this.lbUserName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.lbUserName.Location = new System.Drawing.Point(93, 79);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(30, 15);
            this.lbUserName.Text = "User";
            // 
            // lbLevel
            // 
            this.lbLevel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.lbLevel.Location = new System.Drawing.Point(95, 38);
            this.lbLevel.Name = "lbLevel";
            this.lbLevel.Size = new System.Drawing.Size(34, 15);
            this.lbLevel.Text = "Level";
            // 
            // btnOSK
            // 
            this.btnOSK.Location = new System.Drawing.Point(278, 89);
            this.btnOSK.Name = "btnOSK";
            this.btnOSK.Size = new System.Drawing.Size(51, 39);
            this.btnOSK.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("kryptonButton1.StateCommon.Back.Image")));
            this.btnOSK.StateCommon.Back.ImageAlign = ComponentFactory.Krypton.Toolkit.PaletteRectangleAlign.Control;
            this.btnOSK.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.CenterMiddle;
            this.btnOSK.TabIndex = 25;
            this.btnOSK.Values.Text = "";
            this.btnOSK.Click += new System.EventHandler(this.btnOSK_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(412, 268);
            this.Controls.Add(this.btnOSK);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnRegi);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.lbPass);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.comLevel);
            this.Controls.Add(this.lbUserName);
            this.Controls.Add(this.lbLevel);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormLogin";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Frm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Frm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Frm_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.comLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnLogOut;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnLogin;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnRegi;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPass;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel lbPass;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtUserName;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox comLevel;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel lbUserName;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel lbLevel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOSK;
    }
}