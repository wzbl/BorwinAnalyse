using System.Windows.Forms;

namespace MotionLibrary.IOControls
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
            this.dSignalLamp1 = new MotionLibrary.IOControls.DSignalLamp();
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
            // dSignalLamp1
            // 
            this.dSignalLamp1.CanClick = false;
            this.dSignalLamp1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dSignalLamp1.IsHighlight = true;
            this.dSignalLamp1.IsShowBorder = false;
            this.dSignalLamp1.LampColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))))};
            this.dSignalLamp1.Location = new System.Drawing.Point(0, 0);
            this.dSignalLamp1.Name = "dSignalLamp1";
            this.dSignalLamp1.Size = new System.Drawing.Size(50, 50);
            this.dSignalLamp1.TabIndex = 3;
            this.dSignalLamp1.TwinkleSpeed = 0;
            this.dSignalLamp1.Value = 0;
            // 
            // InputControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dSignalLamp1);
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
        private DSignalLamp dSignalLamp1;
    }
}
