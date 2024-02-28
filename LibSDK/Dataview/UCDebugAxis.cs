using LibSDK.AxisParamDebuger;
using LibSDK.Enums;
using LibSDK.Motion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibSDK.Dataview
{
    public partial class UCDebugAxis : UserControl
    {
        public UCDebugAxis()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Load += UCDebugAxis_Load;
            UpDataAxis();
            MotionControl.UpDateAxis += UpDataAxis;
        }
        AxisControl axisControl = null;
        private void UCDebugAxis_Load(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = DebugerAxisParam.Instance;
            timer1.Start();
        }

        private void UpDataAxis()
        {
            kryptonDataGridView1.Rows.Clear();
            foreach (CAxisParm cAxisParm in AxisParm.AParms)
            {
                kryptonDataGridView1.Rows.Add
                    (
                    kryptonDataGridView1.Rows.Count,
                    cAxisParm.AxisInfo.CardNo,
                    cAxisParm.AxisInfo.AxisNo,
                    cAxisParm.AxisInfo.AxisName
                    ); ;
            }
        }

        /// <summary>
        /// 切换轴
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kryptonDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0)
                return;
            kryptonSplitContainer2.Panel1.Controls.Clear();
            axisControl = null;
            string AxisName = kryptonDataGridView1.Rows[index].Cells["AxisName"].FormattedValue.ToString();
            if (MotionControl.Motions.TryGetValue(AxisName, out var motions))
            {
                axisControl = new AxisControl(motions);
                kryptonSplitContainer2.Panel1.Controls.Add (axisControl);
            } 

        }

        /// <summary>
        /// 调轴的参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kryptonDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0)
                return;

            string CardNo =   kryptonDataGridView1.Rows[index].Cells["CardNo"].FormattedValue.ToString();
            string AxisNo =   kryptonDataGridView1.Rows[index].Cells["AxisNo"].FormattedValue.ToString();
            string AxisName =   kryptonDataGridView1.Rows[index].Cells["AxisName"].FormattedValue.ToString();

            short.TryParse(CardNo,out short card);
            short.TryParse(AxisNo, out short axis);

            CAxisParm cAxisParm = AxisParm.AParms.Where(x => x.AxisInfo.CardNo == card && x.AxisInfo.AxisNo == axis && x.AxisInfo.AxisName == AxisName).First();
            if (cAxisParm != null)
            {
                AxisParam axisParam = new AxisParam(cAxisParm);
                axisParam.ShowDialog();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (axisControl!=null)
            {
                axisControl.RefreshUI();
            }
        }
    }
}
