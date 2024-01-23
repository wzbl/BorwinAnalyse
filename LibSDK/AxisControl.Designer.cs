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
            this.txt = new System.Windows.Forms.TextBox();
            this.txtPos = new System.Windows.Forms.TextBox();
            this.btnPositive = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnNagetive = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnStop = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonWrapLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonWrapLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.btnStopGoHome = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnStartGoHome = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonWrapLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.ComMoveType = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.lbAxisName = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.btnOpenSero = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.ComMoveType)).BeginInit();
            this.SuspendLayout();
            // 
            // txt
            // 
            this.txt.Font = new System.Drawing.Font("宋体", 12F);
            this.txt.Location = new System.Drawing.Point(82, 68);
            this.txt.Name = "txt";
            this.txt.ReadOnly = true;
            this.txt.Size = new System.Drawing.Size(140, 26);
            this.txt.TabIndex = 0;
            // 
            // txtPos
            // 
            this.txtPos.Font = new System.Drawing.Font("宋体", 12F);
            this.txtPos.Location = new System.Drawing.Point(82, 98);
            this.txtPos.Name = "txtPos";
            this.txtPos.Size = new System.Drawing.Size(140, 26);
            this.txtPos.TabIndex = 1;
            // 
            // btnPositive
            // 
            this.btnPositive.Location = new System.Drawing.Point(25, 127);
            this.btnPositive.Name = "btnPositive";
            this.btnPositive.Size = new System.Drawing.Size(51, 50);
            this.btnPositive.TabIndex = 2;
            this.btnPositive.Values.Text = "正向";
            this.btnPositive.Click += new System.EventHandler(this.btnPositive_Click);
            // 
            // btnNagetive
            // 
            this.btnNagetive.Location = new System.Drawing.Point(138, 127);
            this.btnNagetive.Name = "btnNagetive";
            this.btnNagetive.Size = new System.Drawing.Size(51, 50);
            this.btnNagetive.TabIndex = 3;
            this.btnNagetive.Values.Text = "反向";
            this.btnNagetive.Click += new System.EventHandler(this.btnNagetive_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(81, 127);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(51, 50);
            this.btnStop.TabIndex = 4;
            this.btnStop.Values.Text = "停止";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // kryptonWrapLabel1
            // 
            this.kryptonWrapLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel1.Location = new System.Drawing.Point(17, 79);
            this.kryptonWrapLabel1.Name = "kryptonWrapLabel1";
            this.kryptonWrapLabel1.Size = new System.Drawing.Size(59, 15);
            this.kryptonWrapLabel1.Text = "实际位置";
            // 
            // kryptonWrapLabel2
            // 
            this.kryptonWrapLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel2.Location = new System.Drawing.Point(17, 105);
            this.kryptonWrapLabel2.Name = "kryptonWrapLabel2";
            this.kryptonWrapLabel2.Size = new System.Drawing.Size(59, 15);
            this.kryptonWrapLabel2.Text = "目标位置";
            // 
            // btnStopGoHome
            // 
            this.btnStopGoHome.Location = new System.Drawing.Point(289, 127);
            this.btnStopGoHome.Name = "btnStopGoHome";
            this.btnStopGoHome.Size = new System.Drawing.Size(80, 50);
            this.btnStopGoHome.TabIndex = 8;
            this.btnStopGoHome.Values.Text = "停止回零";
            this.btnStopGoHome.Click += new System.EventHandler(this.btnStopGoHome_Click);
            // 
            // btnStartGoHome
            // 
            this.btnStartGoHome.Location = new System.Drawing.Point(203, 127);
            this.btnStartGoHome.Name = "btnStartGoHome";
            this.btnStartGoHome.Size = new System.Drawing.Size(77, 50);
            this.btnStartGoHome.TabIndex = 9;
            this.btnStartGoHome.Values.Text = "开始回零";
            this.btnStartGoHome.Click += new System.EventHandler(this.btnStartGoHome_Click);
            // 
            // kryptonWrapLabel3
            // 
            this.kryptonWrapLabel3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel3.Location = new System.Drawing.Point(267, 70);
            this.kryptonWrapLabel3.Name = "kryptonWrapLabel3";
            this.kryptonWrapLabel3.Size = new System.Drawing.Size(59, 15);
            this.kryptonWrapLabel3.Text = "运动方式";
            // 
            // ComMoveType
            // 
            this.ComMoveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComMoveType.DropDownWidth = 128;
            this.ComMoveType.Items.AddRange(new object[] {
            "相对运动模式",
            "绝对运动模式",
            "JOG"});
            this.ComMoveType.Location = new System.Drawing.Point(241, 95);
            this.ComMoveType.Name = "ComMoveType";
            this.ComMoveType.Size = new System.Drawing.Size(128, 21);
            this.ComMoveType.TabIndex = 11;
            this.ComMoveType.SelectedIndexChanged += new System.EventHandler(this.ComMoveType_SelectedIndexChanged);
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
            this.btnOpenSero.Location = new System.Drawing.Point(280, 10);
            this.btnOpenSero.Name = "btnOpenSero";
            this.btnOpenSero.Size = new System.Drawing.Size(91, 42);
            this.btnOpenSero.TabIndex = 14;
            this.btnOpenSero.Values.Text = "打开使能";
            this.btnOpenSero.Click += new System.EventHandler(this.btnOpenSero_Click);
            // 
            // AxisControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnOpenSero);
            this.Controls.Add(this.lbAxisName);
            this.Controls.Add(this.ComMoveType);
            this.Controls.Add(this.kryptonWrapLabel3);
            this.Controls.Add(this.btnStartGoHome);
            this.Controls.Add(this.btnStopGoHome);
            this.Controls.Add(this.kryptonWrapLabel2);
            this.Controls.Add(this.kryptonWrapLabel1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnNagetive);
            this.Controls.Add(this.btnPositive);
            this.Controls.Add(this.txtPos);
            this.Controls.Add(this.txt);
            this.Name = "AxisControl";
            this.Size = new System.Drawing.Size(380, 186);
            ((System.ComponentModel.ISupportInitialize)(this.ComMoveType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt;
        private System.Windows.Forms.TextBox txtPos;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnPositive;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnNagetive;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnStop;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnStopGoHome;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnStartGoHome;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox ComMoveType;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel lbAxisName;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOpenSero;
    }
}
