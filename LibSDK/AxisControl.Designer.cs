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
            this.btnPositive = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnNagetive = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnStop = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnStartGoHome = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnOpenSero = new System.Windows.Forms.Button();
            this.lbName = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.errorPanel = new System.Windows.Forms.Panel();
            this.btnAlarmReset = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lbErrorMsg = new System.Windows.Forms.Label();
            this.txtPos = new System.Windows.Forms.TextBox();
            this.kryptonWrapLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonWrapLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.comMotionType = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonWrapLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.txtAcc = new System.Windows.Forms.TextBox();
            this.kryptonWrapLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.txtVel = new System.Windows.Forms.TextBox();
            this.kryptonWrapLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.c = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewButtonColumn();
            this.Column4 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewButtonColumn();
            this.Column5 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewButtonColumn();
            this.dSignalLamp1 = new LibSDK.IO.DSignalLamp();
            this.kryptonTrackBar1 = new ComponentFactory.Krypton.Toolkit.KryptonTrackBar();
            this.kryptonTrackBar2 = new ComponentFactory.Krypton.Toolkit.KryptonTrackBar();
            this.errorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comMotionType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRel
            // 
            this.txtRel.Font = new System.Drawing.Font("宋体", 9F);
            this.txtRel.Location = new System.Drawing.Point(5, 49);
            this.txtRel.Margin = new System.Windows.Forms.Padding(4);
            this.txtRel.Name = "txtRel";
            this.txtRel.ReadOnly = true;
            this.txtRel.Size = new System.Drawing.Size(119, 25);
            this.txtRel.TabIndex = 0;
            // 
            // btnPositive
            // 
            this.btnPositive.Location = new System.Drawing.Point(131, 108);
            this.btnPositive.Margin = new System.Windows.Forms.Padding(4);
            this.btnPositive.Name = "btnPositive";
            this.btnPositive.Size = new System.Drawing.Size(60, 56);
            this.btnPositive.TabIndex = 2;
            this.btnPositive.Tag = "1";
            this.btnPositive.Values.Text = "+";
            this.btnPositive.Click += new System.EventHandler(this.btnPositive_Click);
            this.btnPositive.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPositive_MouseDown);
            this.btnPositive.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnPositive_MouseUp);
            // 
            // btnNagetive
            // 
            this.btnNagetive.Location = new System.Drawing.Point(253, 108);
            this.btnNagetive.Margin = new System.Windows.Forms.Padding(4);
            this.btnNagetive.Name = "btnNagetive";
            this.btnNagetive.Size = new System.Drawing.Size(60, 56);
            this.btnNagetive.TabIndex = 3;
            this.btnNagetive.Tag = "0";
            this.btnNagetive.Values.Text = "-";
            this.btnNagetive.Click += new System.EventHandler(this.btnNagetive_Click);
            this.btnNagetive.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPositive_MouseDown);
            this.btnNagetive.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnPositive_MouseUp);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(192, 108);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(60, 56);
            this.btnStop.TabIndex = 4;
            this.btnStop.Values.Text = "stop";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStartGoHome
            // 
            this.btnStartGoHome.Location = new System.Drawing.Point(139, 56);
            this.btnStartGoHome.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartGoHome.Name = "btnStartGoHome";
            this.btnStartGoHome.Size = new System.Drawing.Size(81, 50);
            this.btnStartGoHome.TabIndex = 9;
            this.btnStartGoHome.Values.Text = "home";
            this.btnStartGoHome.Click += new System.EventHandler(this.btnStartGoHome_Click);
            // 
            // btnOpenSero
            // 
            this.btnOpenSero.Location = new System.Drawing.Point(207, 0);
            this.btnOpenSero.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenSero.Name = "btnOpenSero";
            this.btnOpenSero.Size = new System.Drawing.Size(109, 50);
            this.btnOpenSero.TabIndex = 14;
            this.btnOpenSero.Text = "使能";
            this.btnOpenSero.Click += new System.EventHandler(this.btnOpenSero_Click);
            // 
            // lbName
            // 
            this.lbName.Font = new System.Drawing.Font("宋体", 16F);
            this.lbName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbName.Location = new System.Drawing.Point(8, 0);
            this.lbName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(67, 27);
            this.lbName.StateNormal.Font = new System.Drawing.Font("宋体", 16F);
            this.lbName.StateNormal.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbName.Text = "A轴:";
            // 
            // errorPanel
            // 
            this.errorPanel.BackColor = System.Drawing.Color.Red;
            this.errorPanel.Controls.Add(this.btnAlarmReset);
            this.errorPanel.Controls.Add(this.lbErrorMsg);
            this.errorPanel.Location = new System.Drawing.Point(151, 25);
            this.errorPanel.Margin = new System.Windows.Forms.Padding(4);
            this.errorPanel.Name = "errorPanel";
            this.errorPanel.Size = new System.Drawing.Size(13, 12);
            this.errorPanel.TabIndex = 22;
            this.errorPanel.Visible = false;
            // 
            // btnAlarmReset
            // 
            this.btnAlarmReset.Location = new System.Drawing.Point(145, 90);
            this.btnAlarmReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnAlarmReset.Name = "btnAlarmReset";
            this.btnAlarmReset.Size = new System.Drawing.Size(123, 59);
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
            this.lbErrorMsg.Location = new System.Drawing.Point(3, 48);
            this.lbErrorMsg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbErrorMsg.Name = "lbErrorMsg";
            this.lbErrorMsg.Size = new System.Drawing.Size(69, 20);
            this.lbErrorMsg.TabIndex = 0;
            this.lbErrorMsg.Text = "label1";
            // 
            // txtPos
            // 
            this.txtPos.Location = new System.Drawing.Point(5, 95);
            this.txtPos.Margin = new System.Windows.Forms.Padding(4);
            this.txtPos.Name = "txtPos";
            this.txtPos.Size = new System.Drawing.Size(119, 25);
            this.txtPos.TabIndex = 29;
            // 
            // kryptonWrapLabel2
            // 
            this.kryptonWrapLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel2.Location = new System.Drawing.Point(27, 76);
            this.kryptonWrapLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kryptonWrapLabel2.Name = "kryptonWrapLabel2";
            this.kryptonWrapLabel2.Size = new System.Drawing.Size(73, 20);
            this.kryptonWrapLabel2.Text = "目标位置";
            // 
            // kryptonWrapLabel1
            // 
            this.kryptonWrapLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel1.Location = new System.Drawing.Point(27, 122);
            this.kryptonWrapLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kryptonWrapLabel1.Name = "kryptonWrapLabel1";
            this.kryptonWrapLabel1.Size = new System.Drawing.Size(73, 20);
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
            this.comMotionType.Location = new System.Drawing.Point(5, 141);
            this.comMotionType.Margin = new System.Windows.Forms.Padding(4);
            this.comMotionType.Name = "comMotionType";
            this.comMotionType.Size = new System.Drawing.Size(120, 25);
            this.comMotionType.TabIndex = 28;
            this.comMotionType.SelectedIndexChanged += new System.EventHandler(this.comMotionType_SelectedIndexChanged);
            // 
            // kryptonWrapLabel3
            // 
            this.kryptonWrapLabel3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel3.Location = new System.Drawing.Point(27, 29);
            this.kryptonWrapLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kryptonWrapLabel3.Name = "kryptonWrapLabel3";
            this.kryptonWrapLabel3.Size = new System.Drawing.Size(73, 20);
            this.kryptonWrapLabel3.Text = "实际位置";
            // 
            // kryptonSplitContainer1
            // 
            this.kryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.kryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.kryptonSplitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonSplitContainer1.Name = "kryptonSplitContainer1";
            // 
            // kryptonSplitContainer1.Panel1
            // 
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.kryptonTrackBar2);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.errorPanel);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.kryptonTrackBar1);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.txtAcc);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.kryptonWrapLabel4);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.lbName);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.txtVel);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.txtPos);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.kryptonWrapLabel5);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.kryptonWrapLabel2);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.btnPositive);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.kryptonWrapLabel3);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.txtRel);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.btnNagetive);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.btnStop);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.btnStartGoHome);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.kryptonWrapLabel1);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.comMotionType);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.btnOpenSero);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.dSignalLamp1);
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.c);
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(760, 216);
            this.kryptonSplitContainer1.SplitterDistance = 317;
            this.kryptonSplitContainer1.TabIndex = 34;
            // 
            // txtAcc
            // 
            this.txtAcc.Location = new System.Drawing.Point(241, 191);
            this.txtAcc.Margin = new System.Windows.Forms.Padding(4);
            this.txtAcc.Name = "txtAcc";
            this.txtAcc.ReadOnly = true;
            this.txtAcc.Size = new System.Drawing.Size(70, 25);
            this.txtAcc.TabIndex = 45;
            this.txtAcc.TextChanged += new System.EventHandler(this.txtAcc_TextChanged);
            // 
            // kryptonWrapLabel4
            // 
            this.kryptonWrapLabel4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel4.Location = new System.Drawing.Point(6, 193);
            this.kryptonWrapLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kryptonWrapLabel4.Name = "kryptonWrapLabel4";
            this.kryptonWrapLabel4.Size = new System.Drawing.Size(57, 20);
            this.kryptonWrapLabel4.Text = "加速度";
            // 
            // txtVel
            // 
            this.txtVel.Location = new System.Drawing.Point(241, 165);
            this.txtVel.Margin = new System.Windows.Forms.Padding(4);
            this.txtVel.Name = "txtVel";
            this.txtVel.ReadOnly = true;
            this.txtVel.Size = new System.Drawing.Size(70, 25);
            this.txtVel.TabIndex = 36;
            this.txtVel.TextChanged += new System.EventHandler(this.txtVel_TextChanged);
            // 
            // kryptonWrapLabel5
            // 
            this.kryptonWrapLabel5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel5.Location = new System.Drawing.Point(15, 168);
            this.kryptonWrapLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kryptonWrapLabel5.Name = "kryptonWrapLabel5";
            this.kryptonWrapLabel5.Size = new System.Drawing.Size(41, 20);
            this.kryptonWrapLabel5.Text = "速度";
            // 
            // c
            // 
            this.c.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.c.ColumnHeadersHeight = 29;
            this.c.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.c.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c.Location = new System.Drawing.Point(0, 0);
            this.c.Margin = new System.Windows.Forms.Padding(4);
            this.c.Name = "c";
            this.c.RowHeadersWidth = 4;
            this.c.RowTemplate.Height = 50;
            this.c.Size = new System.Drawing.Size(438, 216);
            this.c.TabIndex = 5;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 120F;
            this.Column1.HeaderText = "名称";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "位置";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.FillWeight = 80F;
            this.Column3.HeaderText = "获取";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Text = "";
            // 
            // Column4
            // 
            this.Column4.FillWeight = 80F;
            this.Column4.HeaderText = "保存";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Text = "";
            // 
            // Column5
            // 
            this.Column5.FillWeight = 80F;
            this.Column5.HeaderText = "移动";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Text = "";
            // 
            // dSignalLamp1
            // 
            this.dSignalLamp1.CanClick = false;
            this.dSignalLamp1.Cursor = System.Windows.Forms.Cursors.Default;
            this.dSignalLamp1.IsHighlight = true;
            this.dSignalLamp1.IsShowBorder = false;
            this.dSignalLamp1.LampColor = new System.Drawing.Color[] {
        System.Drawing.Color.Red};
            this.dSignalLamp1.Location = new System.Drawing.Point(236, 54);
            this.dSignalLamp1.Margin = new System.Windows.Forms.Padding(4);
            this.dSignalLamp1.Name = "dSignalLamp1";
            this.dSignalLamp1.Size = new System.Drawing.Size(50, 50);
            this.dSignalLamp1.TabIndex = 19;
            this.dSignalLamp1.TwinkleSpeed = 0;
            this.dSignalLamp1.Value = 0;
            // 
            // kryptonTrackBar1
            // 
            this.kryptonTrackBar1.DrawBackground = true;
            this.kryptonTrackBar1.Location = new System.Drawing.Point(63, 171);
            this.kryptonTrackBar1.Maximum = 100;
            this.kryptonTrackBar1.Name = "kryptonTrackBar1";
            this.kryptonTrackBar1.Size = new System.Drawing.Size(177, 15);
            this.kryptonTrackBar1.TabIndex = 6;
            this.kryptonTrackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.kryptonTrackBar1.TrackBarSize = ComponentFactory.Krypton.Toolkit.PaletteTrackBarSize.Small;
            this.kryptonTrackBar1.ValueChanged += new System.EventHandler(this.kryptonTrackBar1_ValueChanged);
            // 
            // kryptonTrackBar2
            // 
            this.kryptonTrackBar2.DrawBackground = true;
            this.kryptonTrackBar2.Location = new System.Drawing.Point(63, 198);
            this.kryptonTrackBar2.Name = "kryptonTrackBar2";
            this.kryptonTrackBar2.Size = new System.Drawing.Size(177, 15);
            this.kryptonTrackBar2.TabIndex = 52;
            this.kryptonTrackBar2.TickStyle = System.Windows.Forms.TickStyle.None;
            this.kryptonTrackBar2.TrackBarSize = ComponentFactory.Krypton.Toolkit.PaletteTrackBarSize.Small;
            this.kryptonTrackBar2.ValueChanged += new System.EventHandler(this.kryptonTrackBar2_ValueChanged);
            // 
            // AxisControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.kryptonSplitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AxisControl";
            this.Size = new System.Drawing.Size(760, 216);
            this.errorPanel.ResumeLayout(false);
            this.errorPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comMotionType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            this.kryptonSplitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtRel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnPositive;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnNagetive;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnStop;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnStartGoHome;
        private System.Windows.Forms.Button btnOpenSero;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel lbName;
        private IO.DSignalLamp dSignalLamp1;
        private System.Windows.Forms.Panel errorPanel;
        private System.Windows.Forms.Label lbErrorMsg;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAlarmReset;
        private System.Windows.Forms.TextBox txtPos;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox comMotionType;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private System.Windows.Forms.TextBox txtVel;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel5;
        private System.Windows.Forms.TextBox txtAcc;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView c;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewButtonColumn Column3;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewButtonColumn Column4;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewButtonColumn Column5;
        private ComponentFactory.Krypton.Toolkit.KryptonTrackBar kryptonTrackBar2;
        private ComponentFactory.Krypton.Toolkit.KryptonTrackBar kryptonTrackBar1;
    }
}
