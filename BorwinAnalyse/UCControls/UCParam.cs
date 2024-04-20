using BorwinAnalyse.BaseClass;
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

namespace BorwinAnalyse.UCControls
{
    public partial class UCParam : UserControl
    {
        public UCParam()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Load += UCParam_Load;
            this.components = new System.ComponentModel.Container();
        }

        private void UCParam_Load(object sender, EventArgs e)
        {
            InitType();
            UpdataLanguage();
        }
        public void UpdataLanguage()
        {
            lbDescription.Text = lbDescription.Text.tr();
            //LanguageManager.Instance.UpdateLanguage(this, this.components.Components);
        }
        /// <summary>
        /// 初始化类别
        /// </summary>
        private void InitType()
        {
            for (int i = (int)ParamType.Barcode_Scanner; i >= 0; i--)
            {
                KryptonButton btn = new KryptonButton();
                btn.Text = ((ParamType)i).ToString();
                btn.Tag = i;
                btn.Dock = DockStyle.Top;
                btn.Height = 50;
                btn.Click += Btn_Click;
                kryptonSplitContainer1.Panel2.Controls.Add(btn);
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            int type = int.Parse(((KryptonButton)sender).Tag.ToString());
            List<ParamData> paramDatas = ParamManager.Instance.SearchData((ParamType)type);
            kryptonDataGridView1.Rows.Clear();
            DataGridViewUpdata(paramDatas);
        }


        private void DataGridViewUpdata(List<ParamData> paramDatas)
        {
            for (int i = 0; i < paramDatas.Count; i++)
            {
                kryptonDataGridView1.Rows.Add(
                    paramDatas[i].paramName.tr(),
                    paramDatas[i].paramValue,
                    paramDatas[i].paramDescription.tr(),
                    paramDatas[i].paramLevel
                    );
            }
        }

        
        private void btnSave_Click(object sender, EventArgs e)
        {
            for (int i = 0;i< kryptonDataGridView1.Rows.Count;i++)
            {
                if (kryptonDataGridView1.Rows[i].Cells[0].Value!=null)
                {
                    string paramName = kryptonDataGridView1.Rows[i].Cells[0].FormattedValue.ToString();
                    string paramValue = kryptonDataGridView1.Rows[i].Cells[1].FormattedValue.ToString();
                    string level = kryptonDataGridView1.Rows[i].Cells[3].FormattedValue.ToString();
                    ParamManager.Instance.UpData(paramName, paramValue, level);
                }
            }
            ParamManager.Instance.Save();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
