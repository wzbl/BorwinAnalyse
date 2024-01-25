using LibSDK.Enums;
using LibSDK.IO;
using LibSDK.Motion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibSDK
{
    public partial class UCBaseConfig : UserControl
    {
        public UCBaseConfig()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Load += UCBaseConfig_Load;
        }

        private void UCBaseConfig_Load(object sender, EventArgs e)
        {
            rIn.Checked = true;
            comHomeMode.SelectedIndex = 0;
            RefreshIONum();
            RefreshAxisNum();
        
            Init();
        }

        private void RefreshAxisNum()
        {
            txtAxisNo.Text = (AxisParm.AParms.Count + 1).ToString();
        }

        public void Init()
        {
            comCardNo.Items.Clear();
            for (int i = 0; i < BaseConfig.Instance.cardConfigs.Count; i++)
            {
                comCardNo.Items.Add(BaseConfig.Instance.cardConfigs[i].CardNo);
            }
            if (comCardNo.Items.Count > 0)
                comCardNo.SelectedIndex = 0;
        }

        private void btnAddSingleAxis_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comCardNo.Text))
            {
                MessageBox.Show("先选择卡号");
                return;
            }
            if (string.IsNullOrEmpty(txtAxisName.Text))
            {
                MessageBox.Show("轴名称不能空");
                return;
            }
            if (MotionControl.Motions.ContainsKey(txtAxisName.Text.Trim()))
            {
                MessageBox.Show("轴名称已经存在");
                return;
            }
            short cardID = short.Parse(comCardNo.Text);
            CardConfig cardConfig = BaseConfig.Instance.cardConfigs.Where(x => x.CardNo == cardID).ToList()[0];
            if (cardConfig.AxisNum > cardConfig.AxisCurrentNum)
            {
                CAxisParm cAxisParm = new CAxisParm();
                cAxisParm.AxisInfo.CardNo = cardID;
                short.TryParse(txtAxisNo.Text, out short AxisNo);
                cAxisParm.AxisInfo.AxisNo = AxisNo;
                cAxisParm.AxisInfo.AxisName = txtAxisName.Text.Trim();
                int.TryParse(txtGearRatio.Text, out int AxisRatio);
                cAxisParm.AxisInfo.GearRatio = AxisRatio;
                float.TryParse(txtLead.Text, out float Lead);
                cAxisParm.AxisInfo.Lead = Lead;
                float.TryParse(txtScaleFactor.Text, out float ScaleFactor);
                cAxisParm.AxisInfo.ScaleFactor = ScaleFactor;
                float.TryParse(txtELGearRatio.Text, out float ELGearRatio);
                cAxisParm.AxisInfo.ELGearRatio = ELGearRatio;

                cAxisParm.AxisHomeParam.HomeMode = (ReturnMode)comHomeMode.SelectedIndex;
                short.TryParse(txtHomeDirection.Text, out short HomeDirection);
                cAxisParm.AxisHomeParam.HomeDirection = HomeDirection;
                int.TryParse(txtHomesafeLen.Text, out int HomesafeLen);
                cAxisParm.AxisHomeParam.HomesafeLen = HomesafeLen;
                float.TryParse(txtHomeSped.Text, out float HomeSpd);
                cAxisParm.AxisHomeParam.HomeSpd = HomeSpd;
                float.TryParse(txtHomeAccSpd.Text, out float HomeAccSpd);
                cAxisParm.AxisHomeParam.HomeAccSpd = HomeAccSpd;
                float.TryParse(txtSearchHomeSpd.Text, out float SearchHomeSpd);
                cAxisParm.AxisHomeParam.SearchHomeSpd = SearchHomeSpd;
                float.TryParse(txtHomeoffset.Text, out float Homeoffset);
                cAxisParm.AxisHomeParam.Homeoffset = Homeoffset;
                cAxisParm.AxisHomeParam.HomeretSwOffset = chkHomeretSwOffset.Checked;
                int.TryParse(txtHomeretSwOffsetPos.Text, out int HomeretSwOffsetPos);
                cAxisParm.AxisHomeParam.HomeretSwOffsetPos = HomeretSwOffsetPos;
                cAxisParm.AxisHomeParam.HomeClearPos = chkHomeClearPos.Checked;

                float.TryParse(txtMotionSped.Text, out float MotionSped);
                cAxisParm.AxisMotionPara.MotionSped = MotionSped;
                float.TryParse(txtMotionAcc.Text, out float MotionAcc);
                cAxisParm.AxisMotionPara.MotionAcc = MotionAcc;
                float.TryParse(txtMotionDecAcc.Text, out float MotionDecAcc);
                cAxisParm.AxisMotionPara.MotionDecAcc = MotionDecAcc;
                float.TryParse(txtTakeOffSped.Text, out float TakeOffSped);
                cAxisParm.AxisMotionPara.TakeOffSped = TakeOffSped;
                float.TryParse(txtEndSped.Text, out float EndSped);
                cAxisParm.AxisMotionPara.EndSped = EndSped; 
                short.TryParse(txtSmooth.Text, out short Smooth);
                cAxisParm.AxisMotionPara.Smooth = Smooth;
                cAxisParm.AxisMotionPara.IsEnableSoftLimit=IsEnableSoftLimit.Checked;
                float.TryParse(txtPosLimit.Text, out float PosLimit);
                cAxisParm.AxisMotionPara.PosLimit = PosLimit;   
                float.TryParse(txtNegLimit.Text, out float NegLimit);
                cAxisParm.AxisMotionPara.NegLimit = NegLimit;
                AddAxis(cAxisParm);
                BaseConfig.Instance.cardConfigs.Where(x => x.CardNo == cAxisParm.AxisInfo.CardNo).ToList()[0].AxisCurrentNum++;
                BaseConfig.Instance.Write();
                MessageBox.Show("添加成功");
            }
            else
            {

                MessageBox.Show("当前卡已达最大轴数，不可添加");
            }
        }

        /// <summary>
        /// 添加轴
        /// </summary>
        private void AddAxis(CAxisParm cAxisParm)
        {
            MotionControl.AddAxis(cAxisParm);
            RefreshAxisNum();
        }

        private void btnAddSingleIO_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comCardNo.Text))
            {
                MessageBox.Show("先选择卡号");
                return;
            }

            if (string.IsNullOrEmpty(txtIOName.Text))
            {
                MessageBox.Show("IO名称不能空");
                return;
            }
            short cardID = short.Parse(comCardNo.Text);
            CIOType cIOType = new CIOType();
            cIOType.IoName = txtIOName.Text.Trim();
            cIOType.CardNum = cardID;
            int.TryParse(txtSMode.Text,out int SMode);
            cIOType.SMode = SMode;
            int.TryParse(txtDelay.Text, out int Delay);
            cIOType.Delay = Delay;
            short.TryParse(txtIONum.Text, out short IONum);
            cIOType.IONum = IONum;
            if (rIn.Checked)
            {
                if (MotionControl.InPort.ContainsKey(txtIOName.Text))
                {
                    MessageBox.Show("IO名称已经存在");
                    return;
                }
                cIOType.IONum = (short)MotionControl.IOParmIn.IOParms.Count;
                AddINIO(cIOType);
                MotionControl.IOParmIn.Write();
                MotionControl.InitINIO();
            }
            else
            {
                if (MotionControl.Output.ContainsKey(txtIOName.Text))
                {
                    MessageBox.Show("IO名称已经存在");
                    return;
                }
                cIOType.IONum = (short)MotionControl.IOParmOut.IOParms.Count;
                AddOUTIO(cIOType);
                MotionControl.IOParmOut.Write();
                MotionControl.InitOUTIO();
            }
            RefreshIONum();
        }

        /// <summary>
        /// 添加输入IO
        /// </summary>
        private void AddINIO(CIOType cIOType)
        {
            MotionControl.AddInIO(cIOType);
        }

        /// <summary>
        /// 添加输出IO
        /// </summary>
        private void AddOUTIO(CIOType cIOType)
        {
            MotionControl.AddOutIO(cIOType);
        }

        private void btnAddCard_Click(object sender, EventArgs e)
        {
            MotionControl.AddCard();
            MessageBox.Show("添加卡成功");
            Init();
        }

        private void kryptonGroupBox1_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rOut_CheckedChanged(object sender, EventArgs e)
        {
            RefreshIONum();
        }

        private void RefreshIONum()
        {
            if (rIn.Checked)
            {
                txtIONum.Text = MotionControl.IOParmIn.IOParms.Count.ToString();
            }
            else
            {
                txtIONum.Text = MotionControl.IOParmOut.IOParms.Count.ToString();
            }
        }
    }
}
