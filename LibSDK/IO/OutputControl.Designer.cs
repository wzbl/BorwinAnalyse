﻿namespace LibSDK.IO
{
    partial class OutputControl
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
            this.txtOutputText = new System.Windows.Forms.TextBox();
            this.txtOutputIndex = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtOutputText
            // 
            this.txtOutputText.Location = new System.Drawing.Point(59, 27);
            this.txtOutputText.Name = "txtOutputText";
            this.txtOutputText.Size = new System.Drawing.Size(100, 21);
            this.txtOutputText.TabIndex = 1;
            this.txtOutputText.TextChanged += new System.EventHandler(this.txtOutputText_TextChanged);
            // 
            // txtOutputIndex
            // 
            this.txtOutputIndex.Location = new System.Drawing.Point(59, 3);
            this.txtOutputIndex.Name = "txtOutputIndex";
            this.txtOutputIndex.Size = new System.Drawing.Size(100, 21);
            this.txtOutputIndex.TabIndex = 2;
            this.txtOutputIndex.TextChanged += new System.EventHandler(this.txtOutputIndex_TextChanged);
            // 
            // OutputControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtOutputIndex);
            this.Controls.Add(this.txtOutputText);
            this.Name = "OutputControl";
            this.Size = new System.Drawing.Size(167, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtOutputText;
        private System.Windows.Forms.TextBox txtOutputIndex;
    }
}
