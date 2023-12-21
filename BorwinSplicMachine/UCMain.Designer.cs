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
            this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.kryptonSplitContainer2 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.kryptonTextBox2 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtBarCode1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonWrapLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonWrapLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2.Panel1)).BeginInit();
            this.kryptonSplitContainer2.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2.Panel2)).BeginInit();
            this.kryptonSplitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonSplitContainer1
            // 
            this.kryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.kryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.kryptonSplitContainer1.Name = "kryptonSplitContainer1";
            this.kryptonSplitContainer1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver;
            // 
            // kryptonSplitContainer1.Panel1
            // 
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.kryptonSplitContainer2);
            this.kryptonSplitContainer1.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighInternalProfile;
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(1083, 614);
            this.kryptonSplitContainer1.SplitterDistance = 283;
            this.kryptonSplitContainer1.TabIndex = 0;
            // 
            // kryptonSplitContainer2
            // 
            this.kryptonSplitContainer2.Cursor = System.Windows.Forms.Cursors.Default;
            this.kryptonSplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonSplitContainer2.Location = new System.Drawing.Point(0, 0);
            this.kryptonSplitContainer2.Name = "kryptonSplitContainer2";
            this.kryptonSplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.kryptonSplitContainer2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Black;
            // 
            // kryptonSplitContainer2.Panel1
            // 
            this.kryptonSplitContainer2.Panel1.Controls.Add(this.kryptonTextBox2);
            this.kryptonSplitContainer2.Panel1.Controls.Add(this.txtBarCode1);
            this.kryptonSplitContainer2.Panel1.Controls.Add(this.kryptonWrapLabel2);
            this.kryptonSplitContainer2.Panel1.Controls.Add(this.kryptonWrapLabel1);
            this.kryptonSplitContainer2.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighInternalProfile;
            this.kryptonSplitContainer2.Size = new System.Drawing.Size(283, 614);
            this.kryptonSplitContainer2.SplitterDistance = 225;
            this.kryptonSplitContainer2.TabIndex = 0;
            // 
            // kryptonTextBox2
            // 
            this.kryptonTextBox2.Location = new System.Drawing.Point(70, 86);
            this.kryptonTextBox2.Name = "kryptonTextBox2";
            this.kryptonTextBox2.Size = new System.Drawing.Size(137, 23);
            this.kryptonTextBox2.TabIndex = 4;
            this.kryptonTextBox2.Text = "kryptonTextBox2";
            // 
            // txtBarCode1
            // 
            this.txtBarCode1.Location = new System.Drawing.Point(70, 38);
            this.txtBarCode1.Name = "txtBarCode1";
            this.txtBarCode1.Size = new System.Drawing.Size(137, 23);
            this.txtBarCode1.TabIndex = 3;
            this.txtBarCode1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // kryptonWrapLabel2
            // 
            this.kryptonWrapLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel2.ForeColor = System.Drawing.Color.Black;
            this.kryptonWrapLabel2.Location = new System.Drawing.Point(25, 94);
            this.kryptonWrapLabel2.Name = "kryptonWrapLabel2";
            this.kryptonWrapLabel2.Size = new System.Drawing.Size(39, 15);
            this.kryptonWrapLabel2.Text = "条码2";
            // 
            // kryptonWrapLabel1
            // 
            this.kryptonWrapLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel1.ForeColor = System.Drawing.Color.Black;
            this.kryptonWrapLabel1.Location = new System.Drawing.Point(25, 46);
            this.kryptonWrapLabel1.Name = "kryptonWrapLabel1";
            this.kryptonWrapLabel1.Size = new System.Drawing.Size(39, 15);
            this.kryptonWrapLabel1.Text = "条码1";
            // 
            // UCMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonSplitContainer1);
            this.Name = "UCMain";
            this.Size = new System.Drawing.Size(1083, 614);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2.Panel1)).EndInit();
            this.kryptonSplitContainer2.Panel1.ResumeLayout(false);
            this.kryptonSplitContainer2.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2.Panel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2)).EndInit();
            this.kryptonSplitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer2;
  
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtBarCode1;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox2;
    }
}
