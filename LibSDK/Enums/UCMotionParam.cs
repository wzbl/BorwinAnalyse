using BorwinAnalyse.BaseClass;
using LibSDK.IO;
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
using static GC.Frame.Motion.Privt.CNMCLib20;

namespace LibSDK.Enums
{
    public partial class UCMotionParam : UserControl
    {
        public UCMotionParam()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Load += UCMotionParam_Load;

            UpDateAxis();
            UpDateOUTIO();
            UpDateINIO();
            MotionControl.UpDateAxis += UpDateAxis;
            MotionControl.UpDateINIO += UpDateINIO;
            MotionControl.UpDateOUTIO += UpDateOUTIO;
            MotionControl.UpDateCard += UpDateCard;
        }

        private void UpDateCard()
        {
            ucCardParamSet.PPTParam.SelectedObject
     = BaseConfig.Instance.cardConfigs.ToArray();
        }

        private void UpDateOUTIO()
        {
            ucOUTIOParam.PPTParam.SelectedObject
             = MotionControl.IOParmOut.IOParms.ToArray();
        }

        private void UpDateINIO()
        {

            ucINIOParam.PPTParam.SelectedObject
            = MotionControl.IOParmIn.IOParms.ToArray();
        }

        private void UpDateAxis()
        {
            ucMotionParamSet1.PPTParam.SelectedObject
              = AxisParm.AParms.ToArray();
       
        }

        private void UCMotionParam_Load(object sender, EventArgs e)
        {
            ucCardParamSet.PPTParam.SelectedObject
     = BaseConfig.Instance.cardConfigs.ToArray();
        }

        #region 轴的添加删除
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAxis();
        }

        /// <summary>
        /// 新增轴
        /// </summary>
        private void AddAxis()
        {
            FormAddAxis formAddAxis = new FormAddAxis();
            if (formAddAxis.ShowDialog() == DialogResult.OK)
            {
                short cardID = formAddAxis.CardNo;
                CardConfig cardConfig = BaseConfig.Instance.cardConfigs.Where(x => x.CardNo == cardID).ToList()[0];
                if (cardConfig.AxisNum > cardConfig.AxisCurrentNum)
                {
                    CAxisParm cAxisParm = new CAxisParm();
                    cAxisParm.AxisInfo.AxisNo = (short)(AxisParm.AParms.Count + 1);
                    cAxisParm.AxisInfo.AxisName = "Axis"+ cAxisParm.AxisInfo.AxisNo;
                    BaseConfig.Instance.cardConfigs.Where(x => x.CardNo == cAxisParm.AxisInfo.CardNo).ToList()[0].AxisCurrentNum++;
                    BaseConfig.Instance.Write();
                    MotionControl.AddAxis(cAxisParm);
                }
                else
                {
                    MessageBox.Show("当前卡已达最大轴数，不可添加".tr());
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteAxis();
        }

        private void DeleteAxis()
        {
            GridItem o = ucMotionParamSet1.PPTParam.SelectedGridItem;
            string cardNo = "";
            string axisNo = "";
            string axisName = "";
            for (int i = 0; i < o.GridItems.Count; i++)
            {
                if (o.GridItems[i].PropertyDescriptor.DisplayName == "AxisInfo")
                {
                    for (int j = 0; j < o.GridItems[i].GridItems.Count; j++)
                    {


                        if (o.GridItems[i].GridItems[j].PropertyDescriptor.Name == "CardNo")
                        {
                            cardNo = o.GridItems[i].GridItems[j].Value.ToString();
                        }
                        else if (o.GridItems[i].GridItems[j].PropertyDescriptor.Name == "AxisNo")
                        {
                            axisNo = o.GridItems[i].GridItems[j].Value.ToString();
                        }
                        else if (o.GridItems[i].GridItems[j].PropertyDescriptor.Name == "AxisName")
                        {
                            axisName = o.GridItems[i].GridItems[j].Value.ToString();
                        }
                    }
                    break;
                }
            }
            if (short.TryParse(cardNo,out short card) && short.TryParse(axisNo, out short axis) && !string.IsNullOrEmpty(axisName))
            {
                CAxisParm cAxisParm = AxisParm.AParms.Where(x => x.AxisInfo.CardNo == card && x.AxisInfo.AxisNo == axis && x.AxisInfo.AxisName == axisName).First();
                MotionControl.DeleteAxis(cAxisParm);
                BaseConfig.Instance.cardConfigs.Where(x => x.CardNo == cAxisParm.AxisInfo.CardNo).ToList()[0].AxisCurrentNum--;
                BaseConfig.Instance.Write();
            }
        }
        #endregion

        #region 卡的添加删除
        private void toolAddCard_Click(object sender, EventArgs e)
        {
            AddCard();
        }

        private void toolDeleteCard_Click(object sender, EventArgs e)
        {
            DeleteCard();
        }
        /// <summary>
        /// 添加卡
        /// </summary>
        private void AddCard()
        {
            MotionControl.AddCard();
        }
        /// <summary>
        /// 删除卡
        /// </summary>
        private void DeleteCard()
        {
            GridItem o = ucCardParamSet.PPTParam.SelectedGridItem;
            string cardNo = "";
            for (int i = 0; i < o.GridItems.Count; i++)
            {
                if (o.GridItems[i].PropertyDescriptor.Name == "CardNo")
                {
                    cardNo = o.GridItems[i].Value.ToString();
                    break;
                }
            }
            if (short.TryParse(cardNo,out short card))
            {
                CardConfig cardConfig = BaseConfig.Instance.cardConfigs.Where(x => x.CardNo == card).First();
                MotionControl.DeleteCard(cardConfig);
            }

        }
        #endregion

        #region 输出IO
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormAddAxis formAddAxis = new FormAddAxis();
            if (formAddAxis.ShowDialog() == DialogResult.OK)
            {
                CIOType cIOType = new CIOType();
                cIOType.CardNo = formAddAxis.CardNo;
                cIOType.IONum = (short)MotionControl.IOParmOut.IOParms.Count;
                cIOType.IoName = "OUT_" + cIOType.IONum;
                MotionControl.AddOutIO(cIOType);
            }

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            GridItem o = ucOUTIOParam.PPTParam.SelectedGridItem;
            string cardNo = "";
            string IONum = "";
            for (int i = 0; i < o.GridItems.Count; i++)
            {
                if (o.GridItems[i].PropertyDescriptor.Name == "CardNo")
                {
                    cardNo = o.GridItems[i].Value.ToString();
                }
                else if (o.GridItems[i].PropertyDescriptor.Name == "IONum")
                {
                    IONum = o.GridItems[i].Value.ToString();
                }

            }
            if (short.TryParse(cardNo, out short card) && short.TryParse(IONum, out short io))
            {
                CIOType cIOType = MotionControl.IOParmOut.IOParms.Where(x => x.CardNo == card && x.IONum == io).First();
                MotionControl.DeleteOutIO(cIOType);
            }
        }
        #endregion

        #region 输入IO
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FormAddAxis formAddAxis = new FormAddAxis();
            if (formAddAxis.ShowDialog() == DialogResult.OK)
            {
                CIOType cIOType = new CIOType();
                cIOType.CardNo = formAddAxis.CardNo;
                cIOType.IONum = (short)MotionControl.IOParmIn.IOParms.Count;
                cIOType.IoName = "IN_" + cIOType.IONum;
                MotionControl.AddInIO(cIOType);
            }

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            GridItem o = ucINIOParam.PPTParam.SelectedGridItem;
            string cardNo = "";
            string IONum = "";
            for (int i = 0; i < o.GridItems.Count; i++)
            {
                if (o.GridItems[i].PropertyDescriptor.Name == "CardNo")
                {
                    cardNo = o.GridItems[i].Value.ToString();
                }
                else if (o.GridItems[i].PropertyDescriptor.Name == "IONum")
                {
                    IONum = o.GridItems[i].Value.ToString();
                }
            }
            if (short.TryParse(cardNo, out short card) && short.TryParse(IONum, out short io))
            {
                CIOType cIOType = MotionControl.IOParmIn.IOParms.Where(x => x.CardNo == card && x.IONum == io).First();
                MotionControl.DeleteInIO(cIOType);
            }
        }
        #endregion


        private void ucMotionParamSet1_Load(object sender, EventArgs e)
        {

        }


    }
}
