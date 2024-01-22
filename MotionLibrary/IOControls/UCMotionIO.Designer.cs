namespace MotionLibrary.IOControls
{
    partial class UCMotionIO
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ucAxisParams1 = new MotionLibrary.AxisParam.UCAxisParams();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbStatus = new System.Windows.Forms.Label();
            this.lbVal = new System.Windows.Forms.Label();
            this.lbRealPos = new System.Windows.Forms.Label();
            this.lbCommPos = new System.Windows.Forms.Label();
            this.btnQuackStop = new System.Windows.Forms.Button();
            this.btnGet = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.btnError = new System.Windows.Forms.Button();
            this.btnInPos = new System.Windows.Forms.Button();
            this.btnLimitUp = new System.Windows.Forms.Button();
            this.btnLimitDown = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.btnMotion = new System.Windows.Forms.Button();
            this.btnSero = new System.Windows.Forms.Button();
            this.btnAlarm = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtTargetPos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnGoHome = new System.Windows.Forms.Button();
            this.btnStopGoHome = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(857, 707);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(806, 681);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "InIO";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(806, 681);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "OutIO";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ucAxisParams1);
            this.tabPage3.Controls.Add(this.panel1);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.comboBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(849, 681);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ucAxisParams1
            // 
            this.ucAxisParams1.Location = new System.Drawing.Point(9, 56);
            this.ucAxisParams1.Name = "ucAxisParams1";
            this.ucAxisParams1.Size = new System.Drawing.Size(421, 571);
            this.ucAxisParams1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.lbStatus);
            this.panel1.Controls.Add(this.lbVal);
            this.panel1.Controls.Add(this.lbRealPos);
            this.panel1.Controls.Add(this.lbCommPos);
            this.panel1.Controls.Add(this.btnQuackStop);
            this.panel1.Controls.Add(this.btnGet);
            this.panel1.Controls.Add(this.button14);
            this.panel1.Controls.Add(this.button15);
            this.panel1.Controls.Add(this.btnError);
            this.panel1.Controls.Add(this.btnInPos);
            this.panel1.Controls.Add(this.btnLimitUp);
            this.panel1.Controls.Add(this.btnLimitDown);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.btnMotion);
            this.panel1.Controls.Add(this.btnSero);
            this.panel1.Controls.Add(this.btnAlarm);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Location = new System.Drawing.Point(436, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(365, 145);
            this.panel1.TabIndex = 5;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("宋体", 12F);
            this.lbStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbStatus.Location = new System.Drawing.Point(95, 108);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(15, 16);
            this.lbStatus.TabIndex = 20;
            this.lbStatus.Text = "0";
            // 
            // lbVal
            // 
            this.lbVal.AutoSize = true;
            this.lbVal.Font = new System.Drawing.Font("宋体", 12F);
            this.lbVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbVal.Location = new System.Drawing.Point(95, 79);
            this.lbVal.Name = "lbVal";
            this.lbVal.Size = new System.Drawing.Size(15, 16);
            this.lbVal.TabIndex = 19;
            this.lbVal.Text = "0";
            // 
            // lbRealPos
            // 
            this.lbRealPos.AutoSize = true;
            this.lbRealPos.Font = new System.Drawing.Font("宋体", 12F);
            this.lbRealPos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbRealPos.Location = new System.Drawing.Point(95, 47);
            this.lbRealPos.Name = "lbRealPos";
            this.lbRealPos.Size = new System.Drawing.Size(15, 16);
            this.lbRealPos.TabIndex = 18;
            this.lbRealPos.Text = "0";
            // 
            // lbCommPos
            // 
            this.lbCommPos.AutoSize = true;
            this.lbCommPos.Font = new System.Drawing.Font("宋体", 12F);
            this.lbCommPos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbCommPos.Location = new System.Drawing.Point(95, 18);
            this.lbCommPos.Name = "lbCommPos";
            this.lbCommPos.Size = new System.Drawing.Size(15, 16);
            this.lbCommPos.TabIndex = 17;
            this.lbCommPos.Text = "0";
            // 
            // btnQuackStop
            // 
            this.btnQuackStop.Location = new System.Drawing.Point(324, 103);
            this.btnQuackStop.Name = "btnQuackStop";
            this.btnQuackStop.Size = new System.Drawing.Size(43, 24);
            this.btnQuackStop.TabIndex = 16;
            this.btnQuackStop.Text = "急停";
            this.btnQuackStop.UseVisualStyleBackColor = true;
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(273, 103);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(43, 24);
            this.btnGet.TabIndex = 15;
            this.btnGet.Text = "捕获";
            this.btnGet.UseVisualStyleBackColor = true;
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(174, 114);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(94, 24);
            this.button14.TabIndex = 14;
            this.button14.Text = "软限+";
            this.button14.UseVisualStyleBackColor = true;
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(174, 87);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(94, 24);
            this.button15.TabIndex = 13;
            this.button15.Text = "软限-";
            this.button15.UseVisualStyleBackColor = true;
            // 
            // btnError
            // 
            this.btnError.Location = new System.Drawing.Point(324, 53);
            this.btnError.Name = "btnError";
            this.btnError.Size = new System.Drawing.Size(43, 24);
            this.btnError.TabIndex = 12;
            this.btnError.Text = "错误";
            this.btnError.UseVisualStyleBackColor = true;
            // 
            // btnInPos
            // 
            this.btnInPos.Location = new System.Drawing.Point(274, 53);
            this.btnInPos.Name = "btnInPos";
            this.btnInPos.Size = new System.Drawing.Size(43, 24);
            this.btnInPos.TabIndex = 11;
            this.btnInPos.Text = "到位";
            this.btnInPos.UseVisualStyleBackColor = true;
            // 
            // btnLimitUp
            // 
            this.btnLimitUp.Location = new System.Drawing.Point(225, 53);
            this.btnLimitUp.Name = "btnLimitUp";
            this.btnLimitUp.Size = new System.Drawing.Size(43, 24);
            this.btnLimitUp.TabIndex = 10;
            this.btnLimitUp.Text = "正限";
            this.btnLimitUp.UseVisualStyleBackColor = true;
            // 
            // btnLimitDown
            // 
            this.btnLimitDown.Location = new System.Drawing.Point(174, 53);
            this.btnLimitDown.Name = "btnLimitDown";
            this.btnLimitDown.Size = new System.Drawing.Size(43, 24);
            this.btnLimitDown.TabIndex = 9;
            this.btnLimitDown.Text = "负限";
            this.btnLimitDown.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(324, 10);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(43, 24);
            this.button7.TabIndex = 8;
            this.button7.Text = "越限";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // btnMotion
            // 
            this.btnMotion.Location = new System.Drawing.Point(274, 10);
            this.btnMotion.Name = "btnMotion";
            this.btnMotion.Size = new System.Drawing.Size(43, 24);
            this.btnMotion.TabIndex = 7;
            this.btnMotion.Text = "运动";
            this.btnMotion.UseVisualStyleBackColor = true;
            // 
            // btnSero
            // 
            this.btnSero.Location = new System.Drawing.Point(225, 10);
            this.btnSero.Name = "btnSero";
            this.btnSero.Size = new System.Drawing.Size(43, 24);
            this.btnSero.TabIndex = 6;
            this.btnSero.Text = "使能";
            this.btnSero.UseVisualStyleBackColor = true;
            // 
            // btnAlarm
            // 
            this.btnAlarm.Location = new System.Drawing.Point(174, 10);
            this.btnAlarm.Name = "btnAlarm";
            this.btnAlarm.Size = new System.Drawing.Size(43, 24);
            this.btnAlarm.TabIndex = 5;
            this.btnAlarm.Text = "报警";
            this.btnAlarm.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 12F);
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label18.Location = new System.Drawing.Point(13, 108);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(79, 16);
            this.label18.TabIndex = 4;
            this.label18.Text = "点击状态:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 12F);
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label17.Location = new System.Drawing.Point(13, 79);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(79, 16);
            this.label17.TabIndex = 3;
            this.label17.Text = "电机速度:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 12F);
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label16.Location = new System.Drawing.Point(13, 47);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(79, 16);
            this.label16.TabIndex = 2;
            this.label16.Text = "实际位置:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 12F);
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label15.Location = new System.Drawing.Point(13, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(79, 16);
            this.label15.TabIndex = 1;
            this.label15.Text = "命令位置:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStopGoHome);
            this.groupBox1.Controls.Add(this.btnGoHome);
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.txtTargetPos);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(436, 154);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(365, 309);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(19, 224);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(98, 36);
            this.btnStop.TabIndex = 21;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(19, 154);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(98, 36);
            this.button3.TabIndex = 3;
            this.button3.Text = "反向";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(19, 85);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 36);
            this.button2.TabIndex = 2;
            this.button2.Text = "正向";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtTargetPos
            // 
            this.txtTargetPos.Location = new System.Drawing.Point(82, 17);
            this.txtTargetPos.Name = "txtTargetPos";
            this.txtTargetPos.Size = new System.Drawing.Size(119, 21);
            this.txtTargetPos.TabIndex = 2;
            this.txtTargetPos.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "p";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "运动位置:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(230, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 36);
            this.button1.TabIndex = 1;
            this.button1.Text = "打开使能";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBox1.Location = new System.Drawing.Point(55, 22);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnGoHome
            // 
            this.btnGoHome.Location = new System.Drawing.Point(225, 124);
            this.btnGoHome.Name = "btnGoHome";
            this.btnGoHome.Size = new System.Drawing.Size(98, 36);
            this.btnGoHome.TabIndex = 22;
            this.btnGoHome.Text = "回零";
            this.btnGoHome.UseVisualStyleBackColor = true;
            this.btnGoHome.Click += new System.EventHandler(this.btnGoHome_Click);
            // 
            // btnStopGoHome
            // 
            this.btnStopGoHome.Location = new System.Drawing.Point(225, 200);
            this.btnStopGoHome.Name = "btnStopGoHome";
            this.btnStopGoHome.Size = new System.Drawing.Size(98, 36);
            this.btnStopGoHome.TabIndex = 23;
            this.btnStopGoHome.Text = "停止回零";
            this.btnStopGoHome.UseVisualStyleBackColor = true;
            this.btnStopGoHome.Click += new System.EventHandler(this.btnStopGoHome_Click);
            // 
            // UCMotionIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "UCMotionIO";
            this.Size = new System.Drawing.Size(857, 707);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTargetPos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnQuackStop;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button btnError;
        private System.Windows.Forms.Button btnInPos;
        private System.Windows.Forms.Button btnLimitUp;
        private System.Windows.Forms.Button btnLimitDown;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btnMotion;
        private System.Windows.Forms.Button btnSero;
        private System.Windows.Forms.Button btnAlarm;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label lbVal;
        private System.Windows.Forms.Label lbRealPos;
        private System.Windows.Forms.Label lbCommPos;
        private AxisParam.UCAxisParams ucAxisParams1;
        private System.Windows.Forms.Button btnStopGoHome;
        private System.Windows.Forms.Button btnGoHome;
    }
}
