namespace LibSDK.Enums
{
    partial class UCMotionParam
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
            this.ucCardParamSet = new LibSDK.UCMotionParamSet();
            this.ucINIOParam = new LibSDK.UCMotionParamSet();
            this.ucOUTIOParam = new LibSDK.UCMotionParamSet();
            this.ucMotionParamSet1 = new LibSDK.UCMotionParamSet();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucCardParamSet
            // 
            this.ucCardParamSet.Dock = System.Windows.Forms.DockStyle.Right;
            this.ucCardParamSet.Location = new System.Drawing.Point(307, 0);
            this.ucCardParamSet.Name = "ucCardParamSet";
            this.ucCardParamSet.Size = new System.Drawing.Size(295, 675);
            this.ucCardParamSet.TabIndex = 4;
            this.ucCardParamSet.Tag = "BaseConfig";
            this.ucCardParamSet.标题 = "基础配置";
            // 
            // ucINIOParam
            // 
            this.ucINIOParam.Dock = System.Windows.Forms.DockStyle.Right;
            this.ucINIOParam.Location = new System.Drawing.Point(954, 0);
            this.ucINIOParam.Name = "ucINIOParam";
            this.ucINIOParam.Size = new System.Drawing.Size(331, 675);
            this.ucINIOParam.TabIndex = 5;
            this.ucINIOParam.Tag = "INIO";
            this.ucINIOParam.标题 = "输入IO配置";
            // 
            // ucOUTIOParam
            // 
            this.ucOUTIOParam.Dock = System.Windows.Forms.DockStyle.Right;
            this.ucOUTIOParam.Location = new System.Drawing.Point(602, 0);
            this.ucOUTIOParam.Name = "ucOUTIOParam";
            this.ucOUTIOParam.Size = new System.Drawing.Size(352, 675);
            this.ucOUTIOParam.TabIndex = 6;
            this.ucOUTIOParam.Tag = "OUTIO";
            this.ucOUTIOParam.标题 = "输出IO配置";
            // 
            // ucMotionParamSet1
            // 
            this.ucMotionParamSet1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMotionParamSet1.Location = new System.Drawing.Point(0, 0);
            this.ucMotionParamSet1.Name = "ucMotionParamSet1";
            this.ucMotionParamSet1.Size = new System.Drawing.Size(307, 675);
            this.ucMotionParamSet1.TabIndex = 3;
            this.ucMotionParamSet1.Tag = "Axis";
            this.ucMotionParamSet1.标题 = "轴配置";
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.ucMotionParamSet1);
            this.kryptonPanel1.Controls.Add(this.ucCardParamSet);
            this.kryptonPanel1.Controls.Add(this.ucOUTIOParam);
            this.kryptonPanel1.Controls.Add(this.ucINIOParam);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1285, 675);
            this.kryptonPanel1.TabIndex = 7;
            // 
            // UCMotionParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "UCMotionParam";
            this.Size = new System.Drawing.Size(1285, 675);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public UCMotionParamSet ucINIOParam;
        public UCMotionParamSet ucOUTIOParam;
        public UCMotionParamSet ucMotionParamSet1;
        public UCMotionParamSet ucCardParamSet;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
    }
}
