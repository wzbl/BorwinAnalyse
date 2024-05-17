namespace Mes
{
    partial class UCCode2Check
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCCode2Check));
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.StateCommon.Back.Image")));
            this.btnSave.StatePressed.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnSave.StateTracking.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnSave.Values.Text = "";
            // 
            // btnRun
            // 
            this.btnRun.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnRun.StateCommon.Back.Image")));
            this.btnRun.StateCommon.Back.ImageAlign = ComponentFactory.Krypton.Toolkit.PaletteRectangleAlign.Control;
            this.btnRun.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnRun.Values.Text = "";
            // 
            // UCCode2Check
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "UCCode2Check";
            this.Size = new System.Drawing.Size(1471, 551);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
