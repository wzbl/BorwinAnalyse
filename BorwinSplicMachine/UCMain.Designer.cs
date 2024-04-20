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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCMain));
            this.txtbarCode2 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lbCode2 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.txtBarcode1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lbCode1 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonWrapLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.kryptonWrapLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonWrapLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rad24mm = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.rad16mm = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.rad12mm = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.rad8mm = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnVision = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.MenuLeft = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.拍照ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.视频ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.裁切位置检测ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.拍照ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.视频ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRight = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.拍照ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.视频ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClearCode = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnScann = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.pL = new System.Windows.Forms.Panel();
            this.pM = new System.Windows.Forms.Panel();
            this.pR = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.MenuLeft.SuspendLayout();
            this.MenuMid.SuspendLayout();
            this.MenuRight.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtbarCode2
            // 
            this.txtbarCode2.Location = new System.Drawing.Point(70, 34);
            this.txtbarCode2.Name = "txtbarCode2";
            this.txtbarCode2.Size = new System.Drawing.Size(239, 23);
            this.txtbarCode2.TabIndex = 5;
            this.txtbarCode2.TextChanged += new System.EventHandler(this.txtbarCode2_TextChanged);
            // 
            // lbCode2
            // 
            this.lbCode2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbCode2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.lbCode2.Location = new System.Drawing.Point(22, 36);
            this.lbCode2.Name = "lbCode2";
            this.lbCode2.Size = new System.Drawing.Size(39, 15);
            this.lbCode2.Text = "条码2";
            // 
            // txtBarcode1
            // 
            this.txtBarcode1.Location = new System.Drawing.Point(70, 4);
            this.txtBarcode1.Name = "txtBarcode1";
            this.txtBarcode1.Size = new System.Drawing.Size(239, 23);
            this.txtBarcode1.TabIndex = 1;
            this.txtBarcode1.TextChanged += new System.EventHandler(this.txtBarcode1_TextChanged);
            // 
            // lbCode1
            // 
            this.lbCode1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbCode1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.lbCode1.Location = new System.Drawing.Point(22, 9);
            this.lbCode1.Name = "lbCode1";
            this.lbCode1.Size = new System.Drawing.Size(39, 15);
            this.lbCode1.Text = "条码1";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.67327F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.66337F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.66337F));
            this.tableLayoutPanel2.Controls.Add(this.kryptonWrapLabel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.kryptonWrapLabel5, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.kryptonWrapLabel4, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(887, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.30189F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.69811F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(235, 64);
            this.tableLayoutPanel2.TabIndex = 16;
            // 
            // kryptonWrapLabel3
            // 
            this.kryptonWrapLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonWrapLabel3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel3.Location = new System.Drawing.Point(3, 0);
            this.kryptonWrapLabel3.Name = "kryptonWrapLabel3";
            this.kryptonWrapLabel3.Size = new System.Drawing.Size(70, 18);
            this.kryptonWrapLabel3.Text = "cameraL";
            this.kryptonWrapLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(158, 21);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(74, 40);
            this.panel3.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(79, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(73, 40);
            this.panel2.TabIndex = 5;
            // 
            // kryptonWrapLabel5
            // 
            this.kryptonWrapLabel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonWrapLabel5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel5.Location = new System.Drawing.Point(158, 0);
            this.kryptonWrapLabel5.Name = "kryptonWrapLabel5";
            this.kryptonWrapLabel5.Size = new System.Drawing.Size(74, 18);
            this.kryptonWrapLabel5.Text = "cameraR";
            this.kryptonWrapLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kryptonWrapLabel4
            // 
            this.kryptonWrapLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonWrapLabel4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel4.Location = new System.Drawing.Point(79, 0);
            this.kryptonWrapLabel4.Name = "kryptonWrapLabel4";
            this.kryptonWrapLabel4.Size = new System.Drawing.Size(73, 18);
            this.kryptonWrapLabel4.Text = "cameraM";
            this.kryptonWrapLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(70, 40);
            this.panel1.TabIndex = 4;
            // 
            // rad24mm
            // 
            this.rad24mm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rad24mm.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.rad24mm.Location = new System.Drawing.Point(2, 122);
            this.rad24mm.Margin = new System.Windows.Forms.Padding(2);
            this.rad24mm.Name = "rad24mm";
            this.rad24mm.Size = new System.Drawing.Size(70, 36);
            this.rad24mm.TabIndex = 13;
            this.rad24mm.Values.Text = "24mm";
            // 
            // rad16mm
            // 
            this.rad16mm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rad16mm.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.rad16mm.Location = new System.Drawing.Point(2, 82);
            this.rad16mm.Margin = new System.Windows.Forms.Padding(2);
            this.rad16mm.Name = "rad16mm";
            this.rad16mm.Size = new System.Drawing.Size(70, 36);
            this.rad16mm.TabIndex = 12;
            this.rad16mm.Values.Text = "16mm";
            // 
            // rad12mm
            // 
            this.rad12mm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rad12mm.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.rad12mm.Location = new System.Drawing.Point(2, 42);
            this.rad12mm.Margin = new System.Windows.Forms.Padding(2);
            this.rad12mm.Name = "rad12mm";
            this.rad12mm.Size = new System.Drawing.Size(70, 36);
            this.rad12mm.TabIndex = 11;
            this.rad12mm.Values.Text = "12mm";
            // 
            // rad8mm
            // 
            this.rad8mm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rad8mm.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.rad8mm.Location = new System.Drawing.Point(2, 2);
            this.rad8mm.Margin = new System.Windows.Forms.Padding(2);
            this.rad8mm.Name = "rad8mm";
            this.rad8mm.Size = new System.Drawing.Size(70, 36);
            this.rad8mm.StateCommon.LongText.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.rad8mm.StateNormal.LongText.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.rad8mm.TabIndex = 10;
            this.rad8mm.Values.Text = "8mm";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.rad24mm, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.rad12mm, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.rad16mm, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.rad8mm, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnVision, 0, 4);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(1045, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(74, 238);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // btnVision
            // 
            this.btnVision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnVision.Location = new System.Drawing.Point(3, 163);
            this.btnVision.Name = "btnVision";
            this.btnVision.Size = new System.Drawing.Size(68, 72);
            this.btnVision.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnVision.StateCommon.Back.Image")));
            this.btnVision.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnVision.TabIndex = 14;
            this.btnVision.Values.Text = "";
            this.btnVision.Click += new System.EventHandler(this.btnVision_Click);
            // 
            // MenuLeft
            // 
            this.MenuLeft.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MenuLeft.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.拍照ToolStripMenuItem,
            this.视频ToolStripMenuItem,
            this.裁切位置检测ToolStripMenuItem});
            this.MenuLeft.Name = "MenuLeft";
            this.MenuLeft.Size = new System.Drawing.Size(153, 70);
            // 
            // 拍照ToolStripMenuItem
            // 
            this.拍照ToolStripMenuItem.Name = "拍照ToolStripMenuItem";
            this.拍照ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.拍照ToolStripMenuItem.Tag = "L";
            this.拍照ToolStripMenuItem.Text = "拍照";
            this.拍照ToolStripMenuItem.Click += new System.EventHandler(this.拍照ToolStripMenuItem_Click);
            // 
            // 视频ToolStripMenuItem
            // 
            this.视频ToolStripMenuItem.Name = "视频ToolStripMenuItem";
            this.视频ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.视频ToolStripMenuItem.Tag = "L";
            this.视频ToolStripMenuItem.Text = "视频";
            this.视频ToolStripMenuItem.Click += new System.EventHandler(this.视频ToolStripMenuItem_Click);
            // 
            // 裁切位置检测ToolStripMenuItem
            // 
            this.裁切位置检测ToolStripMenuItem.Name = "裁切位置检测ToolStripMenuItem";
            this.裁切位置检测ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.裁切位置检测ToolStripMenuItem.Tag = "L";
            this.裁切位置检测ToolStripMenuItem.Text = "裁切位置检测";
            this.裁切位置检测ToolStripMenuItem.Click += new System.EventHandler(this.裁切位置检测ToolStripMenuItem_Click);
            // 
            // MenuMid
            // 
            this.MenuMid.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MenuMid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.拍照ToolStripMenuItem1,
            this.视频ToolStripMenuItem1});
            this.MenuMid.Name = "MenuMid";
            this.MenuMid.Size = new System.Drawing.Size(101, 48);
            // 
            // 拍照ToolStripMenuItem1
            // 
            this.拍照ToolStripMenuItem1.Name = "拍照ToolStripMenuItem1";
            this.拍照ToolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.拍照ToolStripMenuItem1.Tag = "M";
            this.拍照ToolStripMenuItem1.Text = "拍照";
            this.拍照ToolStripMenuItem1.Click += new System.EventHandler(this.拍照ToolStripMenuItem_Click);
            // 
            // 视频ToolStripMenuItem1
            // 
            this.视频ToolStripMenuItem1.Name = "视频ToolStripMenuItem1";
            this.视频ToolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.视频ToolStripMenuItem1.Tag = "M";
            this.视频ToolStripMenuItem1.Text = "视频";
            this.视频ToolStripMenuItem1.Click += new System.EventHandler(this.视频ToolStripMenuItem_Click);
            // 
            // MenuRight
            // 
            this.MenuRight.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MenuRight.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.拍照ToolStripMenuItem2,
            this.视频ToolStripMenuItem2});
            this.MenuRight.Name = "MenuMid";
            this.MenuRight.Size = new System.Drawing.Size(101, 48);
            // 
            // 拍照ToolStripMenuItem2
            // 
            this.拍照ToolStripMenuItem2.Name = "拍照ToolStripMenuItem2";
            this.拍照ToolStripMenuItem2.Size = new System.Drawing.Size(100, 22);
            this.拍照ToolStripMenuItem2.Tag = "R";
            this.拍照ToolStripMenuItem2.Text = "拍照";
            this.拍照ToolStripMenuItem2.Click += new System.EventHandler(this.拍照ToolStripMenuItem_Click);
            // 
            // 视频ToolStripMenuItem2
            // 
            this.视频ToolStripMenuItem2.Name = "视频ToolStripMenuItem2";
            this.视频ToolStripMenuItem2.Size = new System.Drawing.Size(100, 22);
            this.视频ToolStripMenuItem2.Tag = "R";
            this.视频ToolStripMenuItem2.Text = "视频";
            this.视频ToolStripMenuItem2.Click += new System.EventHandler(this.视频ToolStripMenuItem_Click);
            // 
            // btnClearCode
            // 
            this.btnClearCode.Location = new System.Drawing.Point(319, 2);
            this.btnClearCode.Name = "btnClearCode";
            this.btnClearCode.Size = new System.Drawing.Size(60, 61);
            this.btnClearCode.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnClearCode.StateCommon.Back.Image")));
            this.btnClearCode.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnClearCode.TabIndex = 19;
            this.btnClearCode.Values.Text = "";
            this.btnClearCode.Click += new System.EventHandler(this.btnClearCode_Click);
            // 
            // btnScann
            // 
            this.btnScann.Location = new System.Drawing.Point(384, 3);
            this.btnScann.Name = "btnScann";
            this.btnScann.Size = new System.Drawing.Size(64, 59);
            this.btnScann.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnScann.StateCommon.Back.Image")));
            this.btnScann.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnScann.TabIndex = 20;
            this.btnScann.Values.Text = "";
            this.btnScann.Click += new System.EventHandler(this.btnScann_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.kryptonPanel1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 4;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.39793F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.60208F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1128, 609);
            this.tableLayoutPanel4.TabIndex = 11;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.tableLayoutPanel2);
            this.kryptonPanel1.Controls.Add(this.btnScann);
            this.kryptonPanel1.Controls.Add(this.btnClearCode);
            this.kryptonPanel1.Controls.Add(this.lbCode2);
            this.kryptonPanel1.Controls.Add(this.txtbarCode2);
            this.kryptonPanel1.Controls.Add(this.txtBarcode1);
            this.kryptonPanel1.Controls.Add(this.lbCode1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(3, 3);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1122, 64);
            this.kryptonPanel1.TabIndex = 11;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 73);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1122, 244);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel5.Controls.Add(this.pR, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.pM, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.pL, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1036, 238);
            this.tableLayoutPanel5.TabIndex = 5;
            // 
            // pL
            // 
            this.pL.BackColor = System.Drawing.Color.Black;
            this.pL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pL.Location = new System.Drawing.Point(3, 3);
            this.pL.Name = "pL";
            this.pL.Size = new System.Drawing.Size(335, 232);
            this.pL.TabIndex = 0;
            // 
            // pM
            // 
            this.pM.BackColor = System.Drawing.Color.Black;
            this.pM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pM.Location = new System.Drawing.Point(344, 3);
            this.pM.Name = "pM";
            this.pM.Size = new System.Drawing.Size(346, 232);
            this.pM.TabIndex = 1;
            // 
            // pR
            // 
            this.pR.BackColor = System.Drawing.Color.Black;
            this.pR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pR.Location = new System.Drawing.Point(696, 3);
            this.pR.Name = "pR";
            this.pR.Size = new System.Drawing.Size(337, 232);
            this.pR.TabIndex = 2;
            // 
            // UCMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel4);
            this.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.Name = "UCMain";
            this.Size = new System.Drawing.Size(1128, 609);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.MenuLeft.ResumeLayout(false);
            this.MenuMid.ResumeLayout(false);
            this.MenuRight.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtBarcode1;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel lbCode1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtbarCode2;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel lbCode2;
        private System.Windows.Forms.Timer timer1;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rad24mm;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rad16mm;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rad12mm;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rad8mm;
        private System.Windows.Forms.ContextMenuStrip MenuLeft;
        private System.Windows.Forms.ContextMenuStrip MenuMid;
        private System.Windows.Forms.ContextMenuStrip MenuRight;
        private System.Windows.Forms.ToolStripMenuItem 拍照ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 视频ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 拍照ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 视频ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 拍照ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 视频ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 裁切位置检测ToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnVision;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnScann;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnClearCode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Panel pR;
        private System.Windows.Forms.Panel pM;
        private System.Windows.Forms.Panel pL;
    }
}
