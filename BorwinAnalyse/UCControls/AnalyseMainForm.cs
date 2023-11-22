using BorwinAnalyse.BaseClass;
using BorwinAnalyse.DataBase.Comm;
using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorwinAnalyse.Forms
{
    public partial class AnalyseMainForm : KryptonForm
    {
        public AnalyseMainForm()
        {
            InitializeComponent();
            this.Load += AnalyseMainForm_Load;
        }

        private void AnalyseMainForm_Load(object sender, EventArgs e)
        {
            SqlLiteManager.Instance.Init();
            InitUI();
        }

        private void InitUI()
        {
            InitButton("解析".tr());
            InitButton("规则".tr());
            InitButton("查询".tr());
        }

        private void InitButton(string text)
        {
            KryptonButton button = new KryptonButton();
            button.Dock = DockStyle.Top;
            button.Height = 80;
            button.Text = text;
            button.Font = new Font("宋体",15);
            kryptonSplitContainer1.Panel1.Controls.Add(button);
        }
    }
}
