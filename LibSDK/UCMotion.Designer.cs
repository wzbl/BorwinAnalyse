namespace LibSDK
{
    partial class UCMotion
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
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.PPTAxisParam = new LibSDK.UCMotionParamSet();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1181, 237);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(142, 71);
            this.button2.TabIndex = 1;
            this.button2.Text = "JOG";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1192, 144);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(142, 71);
            this.button3.TabIndex = 2;
            this.button3.Text = "停止";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // PPTAxisParam
            // 
            this.PPTAxisParam.Location = new System.Drawing.Point(43, 25);
            this.PPTAxisParam.Name = "PPTAxisParam";
            this.PPTAxisParam.Size = new System.Drawing.Size(520, 602);
            this.PPTAxisParam.TabIndex = 3;
            // 
            // UCMotion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PPTAxisParam);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Name = "UCMotion";
            this.Size = new System.Drawing.Size(1431, 709);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private UCMotionParamSet PPTAxisParam;
    }
}
