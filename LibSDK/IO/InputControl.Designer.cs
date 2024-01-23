namespace LibSDK.IO
{
    partial class InputControl
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
            this.txtInputText = new System.Windows.Forms.TextBox();
            this.txtInputIndex = new System.Windows.Forms.TextBox();
 
            this.SuspendLayout();
            // 
            // txtInputText
            // 
            this.txtInputText.Location = new System.Drawing.Point(59, 27);
            this.txtInputText.Name = "txtInputText";
            this.txtInputText.ReadOnly = true;
            this.txtInputText.Size = new System.Drawing.Size(100, 21);
            this.txtInputText.TabIndex = 1;
            // 
            // txtInputIndex
            // 
            this.txtInputIndex.Location = new System.Drawing.Point(59, 3);
            this.txtInputIndex.Name = "txtInputIndex";
            this.txtInputIndex.ReadOnly = true;
            this.txtInputIndex.Size = new System.Drawing.Size(100, 21);
            this.txtInputIndex.TabIndex = 2;
           
            // 
            // InputControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtInputIndex);
            this.Controls.Add(this.txtInputText);
            this.Name = "InputControl";
            this.Size = new System.Drawing.Size(167, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtInputText;
        private System.Windows.Forms.TextBox txtInputIndex;
    
    }
}
