namespace LibSDK
{
    partial class AxisControl
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
            this.txtRel = new System.Windows.Forms.TextBox();
            this.txtPos = new System.Windows.Forms.TextBox();
            this.btnPositive = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnNagetive = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnStop = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnStartGoHome = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lbAxisName = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.btnOpenSero = new System.Windows.Forms.Button();
            this.lbName = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.errorPanel = new System.Windows.Forms.Panel();
            this.btnAlarmReset = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lbErrorMsg = new System.Windows.Forms.Label();
            this.btnEmgStop = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.kryptonWrapLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonWrapLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.comMotionType = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.dSignalLamp4 = new LibSDK.IO.DSignalLamp();
            this.dSignalLamp3 = new LibSDK.IO.DSignalLamp();
            this.dSignalLamp1 = new LibSDK.IO.DSignalLamp();
            this.dSignalLamp2 = new LibSDK.IO.DSignalLamp();
            this.errorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comMotionType)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRel
            // 
            this.txtRel.Font = new System.Drawing.Font("宋体", 12F);
            this.txtRel.Location = new System.Drawing.Point(161, 19);
            this.txtRel.Name = "txtRel";
            this.txtRel.ReadOnly = true;
            this.txtRel.Size = new System.Drawing.Size(140, 26);
            this.txtRel.TabIndex = 0;
            // 
            // txtPos
            // 
            this.txtPos.Font = new System.Drawing.Font("宋体", 12F);
            this.txtPos.Location = new System.Drawing.Point(161, 66);
            this.txtPos.Name = "txtPos";
            this.txtPos.ReadOnly = true;
            this.txtPos.Size = new System.Drawing.Size(140, 26);
            this.txtPos.TabIndex = 1;
            // 
            // btnPositive
            // 
            this.btnPositive.Location = new System.Drawing.Point(8, 199);
            this.btnPositive.Name = "btnPositive";
            this.btnPositive.Size = new System.Drawing.Size(70, 70);
            this.btnPositive.TabIndex = 2;
            this.btnPositive.Tag = "0";
            this.btnPositive.Values.Text = "正向";
            this.btnPositive.Click += new System.EventHandler(this.btnPositive_Click);
            this.btnPositive.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPositive_MouseDown);
            this.btnPositive.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnPositive_MouseUp);
            // 
            // btnNagetive
            // 
            this.btnNagetive.Location = new System.Drawing.Point(101, 199);
            this.btnNagetive.Name = "btnNagetive";
            this.btnNagetive.Size = new System.Drawing.Size(70, 70);
            this.btnNagetive.TabIndex = 3;
            this.btnNagetive.Tag = "1";
            this.btnNagetive.Values.Text = "反向";
            this.btnNagetive.Click += new System.EventHandler(this.btnNagetive_Click);
            this.btnNagetive.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPositive_MouseDown);
            this.btnNagetive.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnPositive_MouseUp);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(197, 199);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(70, 70);
            this.btnStop.TabIndex = 4;
            this.btnStop.Values.Text = "停止";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStartGoHome
            // 
            this.btnStartGoHome.Location = new System.Drawing.Point(103, 112);
            this.btnStartGoHome.Name = "btnStartGoHome";
            this.btnStartGoHome.Size = new System.Drawing.Size(70, 70);
            this.btnStartGoHome.TabIndex = 9;
            this.btnStartGoHome.Values.Text = "回零";
            this.btnStartGoHome.Click += new System.EventHandler(this.btnStartGoHome_Click);
            // 
            // lbAxisName
            // 
            this.lbAxisName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbAxisName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.lbAxisName.Location = new System.Drawing.Point(17, 10);
            this.lbAxisName.Name = "lbAxisName";
            this.lbAxisName.Size = new System.Drawing.Size(0, 15);
            // 
            // btnOpenSero
            // 
            this.btnOpenSero.Location = new System.Drawing.Point(11, 112);
            this.btnOpenSero.Name = "btnOpenSero";
            this.btnOpenSero.Size = new System.Drawing.Size(70, 70);
            this.btnOpenSero.TabIndex = 14;
            this.btnOpenSero.Text = "使能";
            this.btnOpenSero.Click += new System.EventHandler(this.btnOpenSero_Click);
            // 
            // lbName
            // 
            this.lbName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.lbName.Location = new System.Drawing.Point(8, 34);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(31, 15);
            this.lbName.Text = "A轴:";
            // 
            // errorPanel
            // 
            this.errorPanel.BackColor = System.Drawing.Color.Red;
            this.errorPanel.Controls.Add(this.btnAlarmReset);
            this.errorPanel.Controls.Add(this.lbErrorMsg);
            this.errorPanel.Location = new System.Drawing.Point(17, 63);
            this.errorPanel.Name = "errorPanel";
            this.errorPanel.Size = new System.Drawing.Size(35, 41);
            this.errorPanel.TabIndex = 22;
            this.errorPanel.Visible = false;
            // 
            // btnAlarmReset
            // 
            this.btnAlarmReset.Location = new System.Drawing.Point(192, 130);
            this.btnAlarmReset.Name = "btnAlarmReset";
            this.btnAlarmReset.Size = new System.Drawing.Size(86, 47);
            this.btnAlarmReset.TabIndex = 1;
            this.btnAlarmReset.Values.Text = "清除报警";
            this.btnAlarmReset.Click += new System.EventHandler(this.btnAlarmReset_Click);
            // 
            // lbErrorMsg
            // 
            this.lbErrorMsg.AutoSize = true;
            this.lbErrorMsg.BackColor = System.Drawing.Color.Red;
            this.lbErrorMsg.Font = new System.Drawing.Font("宋体", 12F);
            this.lbErrorMsg.ForeColor = System.Drawing.Color.Yellow;
            this.lbErrorMsg.Location = new System.Drawing.Point(3, 61);
            this.lbErrorMsg.Name = "lbErrorMsg";
            this.lbErrorMsg.Size = new System.Drawing.Size(55, 16);
            this.lbErrorMsg.TabIndex = 0;
            this.lbErrorMsg.Text = "label1";
            // 
            // btnEmgStop
            // 
            this.btnEmgStop.Location = new System.Drawing.Point(292, 199);
            this.btnEmgStop.Name = "btnEmgStop";
            this.btnEmgStop.Size = new System.Drawing.Size(70, 70);
            this.btnEmgStop.TabIndex = 25;
            this.btnEmgStop.Values.Text = "急停";
            this.btnEmgStop.Click += new System.EventHandler(this.btnEmgStop_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(266, 151);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(96, 21);
            this.textBox1.TabIndex = 29;
            // 
            // kryptonWrapLabel2
            // 
            this.kryptonWrapLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel2.Location = new System.Drawing.Point(198, 154);
            this.kryptonWrapLabel2.Name = "kryptonWrapLabel2";
            this.kryptonWrapLabel2.Size = new System.Drawing.Size(59, 15);
            this.kryptonWrapLabel2.Text = "目标位置";
            // 
            // kryptonWrapLabel1
            // 
            this.kryptonWrapLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel1.Location = new System.Drawing.Point(199, 122);
            this.kryptonWrapLabel1.Name = "kryptonWrapLabel1";
            this.kryptonWrapLabel1.Size = new System.Drawing.Size(59, 15);
            this.kryptonWrapLabel1.Text = "运动模式";
            // 
            // comMotionType
            // 
            this.comMotionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comMotionType.DropDownWidth = 121;
            this.comMotionType.Items.AddRange(new object[] {
            " 相对",
            " 绝对",
            " JOG"});
            this.comMotionType.Location = new System.Drawing.Point(266, 116);
            this.comMotionType.Name = "comMotionType";
            this.comMotionType.Size = new System.Drawing.Size(96, 21);
            this.comMotionType.TabIndex = 28;
            this.comMotionType.SelectedIndexChanged += new System.EventHandler(this.comMotionType_SelectedIndexChanged);
            // 
            // dSignalLamp4
            // 
            this.dSignalLamp4.CanClick = false;
            this.dSignalLamp4.Cursor = System.Windows.Forms.Cursors.Default;
            this.dSignalLamp4.IsHighlight = true;
            this.dSignalLamp4.IsShowBorder = false;
            this.dSignalLamp4.LampColor = new System.Drawing.Color[] {
        System.Drawing.Color.Red};
            this.dSignalLamp4.Location = new System.Drawing.Point(308, 54);
            this.dSignalLamp4.Name = "dSignalLamp4";
            this.dSignalLamp4.Size = new System.Drawing.Size(50, 50);
            this.dSignalLamp4.TabIndex = 21;
            this.dSignalLamp4.TwinkleSpeed = 0;
            this.dSignalLamp4.Value = 0;
            // 
            // dSignalLamp3
            // 
            this.dSignalLamp3.CanClick = false;
            this.dSignalLamp3.Cursor = System.Windows.Forms.Cursors.Default;
            this.dSignalLamp3.IsHighlight = true;
            this.dSignalLamp3.IsShowBorder = false;
            this.dSignalLamp3.LampColor = new System.Drawing.Color[] {
        System.Drawing.Color.Red};
            this.dSignalLamp3.Location = new System.Drawing.Point(104, 55);
            this.dSignalLamp3.Name = "dSignalLamp3";
            this.dSignalLamp3.Size = new System.Drawing.Size(50, 50);
            this.dSignalLamp3.TabIndex = 20;
            this.dSignalLamp3.TwinkleSpeed = 0;
            this.dSignalLamp3.Value = 0;
            // 
            // dSignalLamp1
            // 
            this.dSignalLamp1.CanClick = false;
            this.dSignalLamp1.Cursor = System.Windows.Forms.Cursors.Default;
            this.dSignalLamp1.IsHighlight = true;
            this.dSignalLamp1.IsShowBorder = false;
            this.dSignalLamp1.LampColor = new System.Drawing.Color[] {
        System.Drawing.Color.Red};
            this.dSignalLamp1.Location = new System.Drawing.Point(308, 4);
            this.dSignalLamp1.Name = "dSignalLamp1";
            this.dSignalLamp1.Size = new System.Drawing.Size(50, 50);
            this.dSignalLamp1.TabIndex = 19;
            this.dSignalLamp1.TwinkleSpeed = 0;
            this.dSignalLamp1.Value = 0;
            // 
            // dSignalLamp2
            // 
            this.dSignalLamp2.CanClick = false;
            this.dSignalLamp2.Cursor = System.Windows.Forms.Cursors.Default;
            this.dSignalLamp2.IsHighlight = true;
            this.dSignalLamp2.IsShowBorder = false;
            this.dSignalLamp2.LampColor = new System.Drawing.Color[] {
        System.Drawing.Color.Red};
            this.dSignalLamp2.Location = new System.Drawing.Point(105, 5);
            this.dSignalLamp2.Name = "dSignalLamp2";
            this.dSignalLamp2.Size = new System.Drawing.Size(50, 50);
            this.dSignalLamp2.TabIndex = 17;
            this.dSignalLamp2.TwinkleSpeed = 0;
            this.dSignalLamp2.Value = 0;
            // 
            // AxisControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.errorPanel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.kryptonWrapLabel2);
            this.Controls.Add(this.kryptonWrapLabel1);
            this.Controls.Add(this.comMotionType);
            this.Controls.Add(this.btnEmgStop);
            this.Controls.Add(this.dSignalLamp4);
            this.Controls.Add(this.dSignalLamp3);
            this.Controls.Add(this.dSignalLamp1);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.dSignalLamp2);
            this.Controls.Add(this.btnOpenSero);
            this.Controls.Add(this.lbAxisName);
            this.Controls.Add(this.btnStartGoHome);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnNagetive);
            this.Controls.Add(this.btnPositive);
            this.Controls.Add(this.txtPos);
            this.Controls.Add(this.txtRel);
            this.Name = "AxisControl";
            this.Size = new System.Drawing.Size(378, 283);
            this.errorPanel.ResumeLayout(false);
            this.errorPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comMotionType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRel;
        private System.Windows.Forms.TextBox txtPos;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnPositive;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnNagetive;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnStop;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnStartGoHome;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel lbAxisName;
        private System.Windows.Forms.Button btnOpenSero;
        private IO.DSignalLamp dSignalLamp2;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel lbName;
        private IO.DSignalLamp dSignalLamp1;
        private IO.DSignalLamp dSignalLamp3;
        private IO.DSignalLamp dSignalLamp4;
        private System.Windows.Forms.Panel errorPanel;
        private System.Windows.Forms.Label lbErrorMsg;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAlarmReset;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnEmgStop;
        private System.Windows.Forms.TextBox textBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox comMotionType;
    }
}
