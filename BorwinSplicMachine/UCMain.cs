using BorwinAnalyse.BaseClass;
using BorwinAnalyse.DataBase.Model;
using BorwinAnalyse.UCControls;
using BorwinSplicMachine.BarCode;
using BorwinSplicMachine.FlowModel;
using BorwinSplicMachine.LCR;
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

namespace BorwinSplicMachine
{
    public partial class UCMain : UserControl
    {
        public UCMain()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Load += UCMain_Load;
            this.components = new System.ComponentModel.Container();

            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
        }
       
        private void UCMain_Load(object sender, EventArgs e)
        {
            UpdataLanguage();
            //Form1.MainControl.UCRichLog.Dock = DockStyle.Top;
            //kryptonSplitContainer2.Panel1.Controls.Add(Form1.MainControl.UCRichLog);
            kryptonSplitContainer2.Panel1.Controls.Add(new UCFlowLight());
            Form1.MainControl.UCCCD.Dock = DockStyle.Fill;
            kryptonSplitContainer2.Panel2.Controls.Add(Form1.MainControl.UCLCR);
            kryptonSplitContainer1.Panel1.Controls.Add(Form1.MainControl.UCFlowControl);
        }
        public void UpdataLanguage()
        {
            LanguageManager.Instance.UpdateLanguage(this, this.components.Components);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //LogManager.Instance.WriteLog(new LogModel(LogType.扫码日志, "输入条码"+":"+ txtBarCode1.Text,"周星星"));
            //List<BomDataModel> bomDataModels = BomManager.Instance.AllBomData.Where(x => x.barCode == txtBarCode1.Text).ToList<BomDataModel>();
            //if (bomDataModels.Count > 0)
            //{
            //    Form1.MainControl.UCLCR.LoadSplic(bomDataModels[0].type, bomDataModels[0].size, bomDataModels[0].value, bomDataModels[0].unit, bomDataModels[0].grade);
            //}
            //else
            //{
            //    MessageBox.Show("Bom中不存在条码:" + txtBarCode1.Text);
            //}
        }

        /// <summary>
        /// 添加测值到界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddLCR(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton1_MouseDown(object sender, MouseEventArgs e)
        {
            FlowBarCodeModel flowBarCodeModel = new FlowModel.FlowBarCodeModel();
            Form1.MainControl.UCFlowControl.AddFlowControl(flowBarCodeModel);
        }

        private void btnLCR_Click(object sender, EventArgs e)
        {
            FlowLCRModel flowLCRModel = new FlowModel.FlowLCRModel();
            Form1.MainControl.UCFlowControl.AddFlowControl(flowLCRModel);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void 找空料_Click(object sender, EventArgs e)
        {
            FlowFindEmptyStrips FindEmptyStrips = new FlowModel.FlowFindEmptyStrips();
            Form1.MainControl.UCFlowControl.AddFlowControl(FindEmptyStrips);
        }

        private void 丝印_Click(object sender, EventArgs e)
        {
            FlowMatchModel FlowMatch = new FlowModel.FlowMatchModel();
            Form1.MainControl.UCFlowControl.AddFlowControl(FlowMatch);
        }
        BarCodeCheck barCode = new BarCodeCheck();

        /// <summary>
        /// 测试检验条码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            Form1.MainControl.CheckCode(txtBarcode1.Text);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtBarcode1.Focus();
        }
    }
}
