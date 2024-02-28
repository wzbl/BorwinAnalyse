namespace LibSDK.Dataview
{
    partial class AxisParam
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
            this.PPTParam = new System.Windows.Forms.PropertyGrid();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.SuspendLayout();
            // 
            // PPTParam
            // 
            this.PPTParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PPTParam.Location = new System.Drawing.Point(0, 0);
            this.PPTParam.Name = "PPTParam";
            this.PPTParam.Size = new System.Drawing.Size(462, 497);
            this.PPTParam.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(334, 441);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 56);
            this.btnSave.TabIndex = 2;
            this.btnSave.Values.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // AxisParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 497);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.PPTParam);
            this.Name = "AxisParam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AxisParam";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PropertyGrid PPTParam;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
    }
}