namespace BorwinSplicMachine
{
    partial class UCMain
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
            this.txtbarCode2 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonWrapLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.txtBarcode1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonWrapLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.rad24mm = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.rad16mm = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.rad12mm = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.rad8mm = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.btnClearCode = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonSplitContainer2 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2.Panel1)).BeginInit();
            this.kryptonSplitContainer2.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2.Panel2)).BeginInit();
            this.kryptonSplitContainer2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtbarCode2
            // 
            this.txtbarCode2.Location = new System.Drawing.Point(348, 13);
            this.txtbarCode2.Name = "txtbarCode2";
            this.txtbarCode2.Size = new System.Drawing.Size(239, 23);
            this.txtbarCode2.TabIndex = 5;
            this.txtbarCode2.TextChanged += new System.EventHandler(this.txtbarCode2_TextChanged);
            // 
            // kryptonWrapLabel2
            // 
            this.kryptonWrapLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel2.Location = new System.Drawing.Point(309, 21);
            this.kryptonWrapLabel2.Name = "kryptonWrapLabel2";
            this.kryptonWrapLabel2.Size = new System.Drawing.Size(39, 15);
            this.kryptonWrapLabel2.Text = "条码2";
            // 
            // txtBarcode1
            // 
            this.txtBarcode1.Location = new System.Drawing.Point(57, 13);
            this.txtBarcode1.Name = "txtBarcode1";
            this.txtBarcode1.Size = new System.Drawing.Size(239, 23);
            this.txtBarcode1.TabIndex = 1;
            this.txtBarcode1.TextChanged += new System.EventHandler(this.txtBarcode1_TextChanged);
            // 
            // kryptonWrapLabel1
            // 
            this.kryptonWrapLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel1.Location = new System.Drawing.Point(18, 21);
            this.kryptonWrapLabel1.Name = "kryptonWrapLabel1";
            this.kryptonWrapLabel1.Size = new System.Drawing.Size(39, 15);
            this.kryptonWrapLabel1.Text = "条码1";
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.rad24mm);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.rad16mm);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.rad12mm);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.rad8mm);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.btnClearCode);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.txtBarcode1);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.kryptonWrapLabel1);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.txtbarCode2);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.kryptonWrapLabel2);
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.kryptonSplitContainer2);
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(980, 609);
            this.kryptonSplitContainer1.SplitterDistance = 53;
            this.kryptonSplitContainer1.TabIndex = 10;
            // 
            // rad24mm
            // 
            this.rad24mm.Location = new System.Drawing.Point(850, 21);
            this.rad24mm.Margin = new System.Windows.Forms.Padding(2);
            this.rad24mm.Name = "rad24mm";
            this.rad24mm.Size = new System.Drawing.Size(57, 20);
            this.rad24mm.TabIndex = 13;
            this.rad24mm.Values.Text = "24mm";
            // 
            // rad16mm
            // 
            this.rad16mm.Location = new System.Drawing.Point(802, 21);
            this.rad16mm.Margin = new System.Windows.Forms.Padding(2);
            this.rad16mm.Name = "rad16mm";
            this.rad16mm.Size = new System.Drawing.Size(57, 20);
            this.rad16mm.TabIndex = 12;
            this.rad16mm.Values.Text = "16mm";
            // 
            // rad12mm
            // 
            this.rad12mm.Location = new System.Drawing.Point(748, 21);
            this.rad12mm.Margin = new System.Windows.Forms.Padding(2);
            this.rad12mm.Name = "rad12mm";
            this.rad12mm.Size = new System.Drawing.Size(57, 20);
            this.rad12mm.TabIndex = 11;
            this.rad12mm.Values.Text = "12mm";
            // 
            // rad8mm
            // 
            this.rad8mm.Location = new System.Drawing.Point(700, 21);
            this.rad8mm.Margin = new System.Windows.Forms.Padding(2);
            this.rad8mm.Name = "rad8mm";
            this.rad8mm.Size = new System.Drawing.Size(50, 20);
            this.rad8mm.TabIndex = 10;
            this.rad8mm.Values.Text = "8mm";
            // 
            // btnClearCode
            // 
            this.btnClearCode.Location = new System.Drawing.Point(593, 4);
            this.btnClearCode.Name = "btnClearCode";
            this.btnClearCode.Size = new System.Drawing.Size(90, 40);
            this.btnClearCode.TabIndex = 7;
            this.btnClearCode.Values.Text = "清除条码";
            this.btnClearCode.Click += new System.EventHandler(this.btnClearCode_Click);
            // 
            // kryptonSplitContainer2
            // 
            this.kryptonSplitContainer2.Cursor = System.Windows.Forms.Cursors.Default;
            this.kryptonSplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonSplitContainer2.Location = new System.Drawing.Point(0, 0);
            this.kryptonSplitContainer2.Name = "kryptonSplitContainer2";
            this.kryptonSplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // kryptonSplitContainer2.Panel1
            // 
            this.kryptonSplitContainer2.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.kryptonSplitContainer2.Size = new System.Drawing.Size(980, 551);
            this.kryptonSplitContainer2.SplitterDistance = 183;
            this.kryptonSplitContainer2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(980, 183);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox3.Location = new System.Drawing.Point(655, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(322, 177);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 177);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(329, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(320, 177);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // UCMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonSplitContainer1);
            this.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.Name = "UCMain";
            this.Size = new System.Drawing.Size(980, 609);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            this.kryptonSplitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2.Panel1)).EndInit();
            this.kryptonSplitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2.Panel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2)).EndInit();
            this.kryptonSplitContainer2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtBarcode1;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtbarCode2;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel2;
        private System.Windows.Forms.Timer timer1;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnClearCode;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rad24mm;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rad16mm;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rad12mm;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rad8mm;
    }
}
