namespace Alarm
{
    partial class FormAlarm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAlarm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonWrapLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.kryptonWrapLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.lbTime = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.lbAlarm = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonWrapLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.BtnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lbemp = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonWrapLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.btnReset = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Controls.Add(this.kryptonWrapLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(801, 82);
            this.panel1.TabIndex = 0;
            // 
            // kryptonWrapLabel1
            // 
            this.kryptonWrapLabel1.AutoSize = false;
            this.kryptonWrapLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonWrapLabel1.Font = new System.Drawing.Font("宋体", 20F);
            this.kryptonWrapLabel1.ForeColor = System.Drawing.Color.White;
            this.kryptonWrapLabel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonWrapLabel1.Name = "kryptonWrapLabel1";
            this.kryptonWrapLabel1.Size = new System.Drawing.Size(801, 82);
            this.kryptonWrapLabel1.StateNormal.Font = new System.Drawing.Font("宋体", 20F);
            this.kryptonWrapLabel1.StateNormal.TextColor = System.Drawing.Color.White;
            this.kryptonWrapLabel1.Text = "警报";
            this.kryptonWrapLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(96)))), ((int)(((byte)(138)))));
            this.panel2.Location = new System.Drawing.Point(0, 303);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 10);
            this.panel2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(59, 88);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(207, 208);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // kryptonWrapLabel2
            // 
            this.kryptonWrapLabel2.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kryptonWrapLabel2.ForeColor = System.Drawing.Color.White;
            this.kryptonWrapLabel2.Location = new System.Drawing.Point(332, 132);
            this.kryptonWrapLabel2.Name = "kryptonWrapLabel2";
            this.kryptonWrapLabel2.Size = new System.Drawing.Size(114, 23);
            this.kryptonWrapLabel2.StateNormal.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kryptonWrapLabel2.StateNormal.TextColor = System.Drawing.Color.White;
            this.kryptonWrapLabel2.Text = "报警时间:";
            // 
            // lbTime
            // 
            this.lbTime.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTime.ForeColor = System.Drawing.Color.White;
            this.lbTime.Location = new System.Drawing.Point(472, 132);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(118, 23);
            this.lbTime.StateNormal.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTime.StateNormal.TextColor = System.Drawing.Color.White;
            this.lbTime.Text = "2024-3-26";
            // 
            // lbAlarm
            // 
            this.lbAlarm.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbAlarm.ForeColor = System.Drawing.Color.White;
            this.lbAlarm.Location = new System.Drawing.Point(480, 178);
            this.lbAlarm.Name = "lbAlarm";
            this.lbAlarm.Size = new System.Drawing.Size(102, 23);
            this.lbAlarm.StateNormal.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbAlarm.StateNormal.TextColor = System.Drawing.Color.White;
            this.lbAlarm.Text = "测值超时";
            // 
            // kryptonWrapLabel5
            // 
            this.kryptonWrapLabel5.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kryptonWrapLabel5.ForeColor = System.Drawing.Color.White;
            this.kryptonWrapLabel5.Location = new System.Drawing.Point(332, 178);
            this.kryptonWrapLabel5.Name = "kryptonWrapLabel5";
            this.kryptonWrapLabel5.Size = new System.Drawing.Size(114, 23);
            this.kryptonWrapLabel5.StateNormal.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kryptonWrapLabel5.StateNormal.TextColor = System.Drawing.Color.White;
            this.kryptonWrapLabel5.Text = "报警类型:";
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(511, 322);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(134, 59);
            this.BtnClose.TabIndex = 10;
            this.BtnClose.Values.Text = "关闭";
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // lbemp
            // 
            this.lbemp.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbemp.ForeColor = System.Drawing.Color.White;
            this.lbemp.Location = new System.Drawing.Point(480, 225);
            this.lbemp.Name = "lbemp";
            this.lbemp.Size = new System.Drawing.Size(70, 23);
            this.lbemp.StateNormal.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbemp.StateNormal.TextColor = System.Drawing.Color.White;
            this.lbemp.Text = "admin";
            // 
            // kryptonWrapLabel7
            // 
            this.kryptonWrapLabel7.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kryptonWrapLabel7.ForeColor = System.Drawing.Color.White;
            this.kryptonWrapLabel7.Location = new System.Drawing.Point(344, 225);
            this.kryptonWrapLabel7.Name = "kryptonWrapLabel7";
            this.kryptonWrapLabel7.Size = new System.Drawing.Size(91, 23);
            this.kryptonWrapLabel7.StateNormal.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kryptonWrapLabel7.StateNormal.TextColor = System.Drawing.Color.White;
            this.kryptonWrapLabel7.Text = "操作员:";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(151, 322);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(134, 59);
            this.btnReset.TabIndex = 15;
            this.btnReset.Values.Text = "复位";
            this.btnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // FormAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(49)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(801, 386);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lbemp);
            this.Controls.Add(this.kryptonWrapLabel7);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.lbAlarm);
            this.Controls.Add(this.kryptonWrapLabel5);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.kryptonWrapLabel2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAlarm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAlarm";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel lbTime;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel lbAlarm;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnClose;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel lbemp;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel7;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnReset;
    }
}