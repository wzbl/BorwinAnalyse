﻿using Alarm;
using BorwinAnalyse.BaseClass;
using LibSDK;
using LibSDK.AxisParamDebuger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorwinSplicMachine.LCR
{
    /// <summary>
    /// LCR界面
    /// </summary>
    public partial class UCLCR : UserControl
    {
        public LCRHelper LCRHelper;
        public UCLCR()
        {
            InitializeComponent();
            this.Load += UCLCR_Load;
            Init();
            this.components = new System.ComponentModel.Container();
            Dock = DockStyle.Fill;
        }
        public KTimer KTimer = new KTimer();
        private void Init()
        {
            LCRHelper = new LCRHelper();
        }

        public void Start()
        {
            if (MotionControl.CardAPI.IsInitCardOK)
            {
                ThreadStart threadStart = new ThreadStart(LCRFlow);
                Thread Thread = new Thread(threadStart);
                Thread.Start();
            }
        }

        private void UCLCR_Load(object sender, EventArgs e)
        {
            initDataGrid();
            UpdateLanguage();
        }

        public void UpdateLanguage()
        {
            LanguageManager.Instance.UpdateLanguage(this, this.components.Components);
        }

        private void initDataGrid()
        {
            this.kryptonDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            new DataGridViewTextBoxColumn()
            {
                FillWeight = 45.07613F,
                HeaderText = "序号",
                MinimumWidth = 6,
                Name = "Column1",
                ReadOnly = true,
            },
            new DataGridViewTextBoxColumn()
            {
                FillWeight = 45.07613F,
                HeaderText = "左/右",
                MinimumWidth = 6,
                Name = "Column2",
                ReadOnly = true,
            },
            new DataGridViewTextBoxColumn()
            {
                FillWeight = 45.07613F,
                HeaderText = "两线/四线",
                MinimumWidth = 6,
                Name = "Column3",
                ReadOnly = true,
            },
            new DataGridViewTextBoxColumn()
            {
                FillWeight = 45.07613F,
                HeaderText = "实测值",
                MinimumWidth = 6,
                Name = "Column7",
                ReadOnly = true,
            },
            new DataGridViewTextBoxColumn()
            {
                FillWeight = 45.07613F,
                HeaderText = "结果",
                MinimumWidth = 6,
                Name = "Column13",
                ReadOnly = true,
            }
            });
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            CheckMaterialMsg();
        }

        public void CheckMaterial(string type, string size, string value, string unit, string grade)
        {
          
            this.Invoke(new Action(() =>
            {
                if (type == "电阻" || type.ToUpper() == "RES")
                {
                    comType.SelectedIndex = 0;
                }
                else if (type == "电容" || type.ToUpper() == "CAP")
                {
                    comType.SelectedIndex = 1;
                }
                comSize.Text = size;
                comUnit.Text = unit;
                txtValue.Text = value;
                txtGrade.Text = grade;
                CheckMaterialMsg();
            }));
           
        }

        private void CheckMaterialMsg()
        {
            if (string.IsNullOrEmpty(comType.Text))
            {
                MessageBox.Show("请选择类型".tr());
                return;
            }

            if (ParamManager.Instance.LCRSize.B && string.IsNullOrEmpty(comSize.Text))
            {
                MessageBox.Show("请选择尺寸".tr());
                return;
            }

            if (string.IsNullOrEmpty(comUnit.Text))
            {
                MessageBox.Show("请选择单位".tr());
                return;
            }

            if (string.IsNullOrEmpty(txtValue.Text) || !double.TryParse(txtValue.Text, out double value))
            {
                MessageBox.Show("值不正确".tr());
                return;
            }

            string grade = txtGrade.Text;
            if (grade.Contains("%"))
            {
                grade = grade.Replace("%", "");
            }
            if (double.TryParse(grade, out double gradeValue))
            {
                if (gradeValue <= 0 || gradeValue > 100)
                {
                    MessageBox.Show("等级超出范围".tr() + ":>0;<=100");
                    return;
                }
            }
            else
            {
                MessageBox.Show("等级不正确".tr());
                return;
            }
            StartLCR();
        }

        /// <summary>
        /// 开始测值
        /// </summary>
        private void StartLCR()
        {
            LCR_Type lCR_Type = LCR_Type.Error;
            LCR_Size lCR_Size = LCR_Size.Error;
            Unit unit = Unit.Error;
            if (comType.Text == "RES" || comType.Text == "电阻")
            {
                lCR_Type = LCR_Type.电阻;
                switch (comUnit.Text.Trim())
                {
                    case "mΩ":
                        unit = Unit.mΩ;
                        break;
                    case "Ω":
                        unit = Unit.Ω;
                        break;
                    case "KΩ":
                        unit = Unit.KΩ;
                        break;
                    case "MΩ":
                        unit = Unit.MΩ;
                        break;
                }
            }
            else if (comType.Text == "CAP" || comType.Text == "电容")
            {
                lCR_Type = LCR_Type.电容;
                switch (comUnit.Text.Trim())
                {
                    case "PF":
                        unit = Unit.PF;
                        break;
                    case "NF":
                        unit = Unit.NF;
                        break;
                    case "UF":
                        unit = Unit.UF;
                        break;
                    case "MF":
                        unit = Unit.MF;
                        break;
                    case "F":
                        unit = Unit.F;
                        break;
                }
            }
            lCR_Size = (LCR_Size)comSize.SelectedIndex + 1;
            string grade = txtGrade.Text;
            if (grade.Contains("%"))
            {
                grade = grade.Replace("%", "");
            }

            LCRHelper.StartLCR(lCR_Type, lCR_Size, double.Parse(txtValue.Text), unit, double.Parse(grade));

            txtMax.Text = LCRHelper.Max_Value.ToString();
            txtMin.Text = LCRHelper.Min_Value.ToString();
        }

        public void StartLCR(string type, string size, string value, string UNIT, string grade)
        {
            LCR_Type lCR_Type = LCR_Type.Error;
            LCR_Size lCR_Size = LCR_Size.Error;
            Unit unit = Unit.Error;
            if (type.ToUpper() == "RES" || type == "电阻")
            {
                lCR_Type = LCR_Type.电阻;
                switch (UNIT.Trim())
                {
                    case "mΩ":
                        unit = Unit.mΩ;
                        break;
                    case "Ω":
                        unit = Unit.Ω;
                        break;
                    case "KΩ":
                        unit = Unit.KΩ;
                        break;
                    case "MΩ":
                        unit = Unit.MΩ;
                        break;
                }
            }
            else if (type.ToUpper() == "CAP" || comType.Text == "电容")
            {
                lCR_Type = LCR_Type.电容;
                switch (UNIT.Trim())
                {
                    case "PF":
                        unit = Unit.PF;
                        break;
                    case "NF":
                        unit = Unit.NF;
                        break;
                    case "UF":
                        unit = Unit.UF;
                        break;
                    case "MF":
                        unit = Unit.MF;
                        break;
                    case "F":
                        unit = Unit.F;
                        break;
                }
            }
            if (LCR_Size._01005.ToString().Contains(size))
            {
                lCR_Size = LCR_Size._01005;
            }
            else if (LCR_Size._0201.ToString().Contains(size))
            {
                lCR_Size = LCR_Size._0201;
            }
            else if (LCR_Size._0402.ToString().Contains(size))
            {
                lCR_Size = LCR_Size._0402;
            }
            else if (LCR_Size._0603.ToString().Contains(size))
            {
                lCR_Size = LCR_Size._0603;
            }
            else if (LCR_Size._0805.ToString().Contains(size))
            {
                lCR_Size = LCR_Size._0805;
            }
            else if (LCR_Size._1206.ToString().Contains(size))
            {
                lCR_Size = LCR_Size._1206;
            }
            else if (LCR_Size._1210.ToString().Contains(size))
            {
                lCR_Size = LCR_Size._1210;
            }
            if (grade.Contains("%"))
            {
                grade = grade.Replace("%", "");
            }
            LCRHelper.StartLCR(lCR_Type, lCR_Size, double.Parse(value), unit, double.Parse(grade));
        }

        public void LoadSplic(string type, string size, string value, string unit, string grade)
        {
            comType.Text = type;
            comSize.Text = size;
            txtValue.Text = value;
            comUnit.Text = unit;
            txtGrade.Text = grade;
            CheckMaterialMsg();
        }

        private void comType_SelectedIndexChanged(object sender, EventArgs e)
        {
            comUnit.Items.Clear();
            if (comType.Text == "RES")
            {
                comUnit.Items.Add("mΩ");
                comUnit.Items.Add("Ω");
                comUnit.Items.Add("KΩ");
                comUnit.Items.Add("MΩ");
            }
            else if (comType.Text == "CAP")
            {
                comUnit.Items.Add("PF");
                comUnit.Items.Add("NF");
                comUnit.Items.Add("UF");
                comUnit.Items.Add("MF");
                comUnit.Items.Add("F");
            }

        }

        int testCount = 0;

        /// <summary>
        /// LCR测值线程
        /// </summary>
        private async void LCRFlow()
        {
            while (Form1.MainControl.motControl != null)
            {
                if (MotionControl.IsAuto && ParamManager.Instance.System_测值.B)
                {
                    switch (LCRHelper.LCRFlow)
                    {
                        case LCR.LCRFlow.None:
                            if (Form1.MainControl.motControl.FlowLeft == MainFlow.请求测值)
                            {
                                LCRHelper.LCRFlow = LCR.LCRFlow.Start;
                                LCRHelper.Side = LCR.WhichSide.Left;
                                MotControl.凸轮.MovePosByName("进料位", 1, AxisRunVel.Instance.凸轮.Sped, AxisRunVel.Instance.凸轮.Acc);
                            }
                            else if (Form1.MainControl.motControl.FlowRight == MainFlow.请求测值)
                            {
                                LCRHelper.LCRFlow = LCR.LCRFlow.Start;
                                LCRHelper.Side = LCR.WhichSide.Right;
                                MotControl.凸轮.MovePosByName("进料位", 1, AxisRunVel.Instance.凸轮.Sped, AxisRunVel.Instance.凸轮.Acc);
                            }
                            else if (Form1.MainControl.CodeControl.IsSuccess() && Form1.MainControl.motControl.FlowLeft == MainFlow.None && Form1.MainControl.motControl.FlowRight == MainFlow.None && MotControl.测值整体上下.HomeState)
                            {
                                if (!MotControl.测值整体上下.InPos("待探测位"))
                                {
                                    MotControl.测值整体上下.MovePosByName("待探测位", 1, AxisRunVel.Instance.测值整体上下.Sped, AxisRunVel.Instance.测值整体上下.Acc);
                                }
                            }
                            break;
                        case LCR.LCRFlow.Start:
                            if (MotControl.凸轮.InPos("进料位"))
                            {
                                if (LCRHelper.Side == LCR.WhichSide.Left)
                                {
                                    MotControl.左进入.PMove(-MotControl.左进入.GetPosByName("测值位"), 0, AxisRunVel.Instance.左进入.Sped, AxisRunVel.Instance.左进入.Acc);
                                }
                                else if (LCRHelper.Side == LCR.WhichSide.Right)
                                {
                                    MotControl.右进入.PMove(-MotControl.右进入.GetPosByName("测值位"), 0, AxisRunVel.Instance.左进入.Sped, AxisRunVel.Instance.左进入.Acc);
                                }
                                LCRHelper.LCRFlow = LCR.LCRFlow.测值整体平移;
                            }
                            Thread.Sleep(1000);
                            break;
                        case LCR.LCRFlow.走一格:
                            if (MotControl.测值整体上下.InPos("待探测位"))
                            {
                                testCount++;
                                if (LCRHelper.Side == LCR.WhichSide.Left)
                                {
                                    MotControl.左进入.PMove(-1, 0);
                                }
                                else if (LCRHelper.Side == LCR.WhichSide.Right)
                                {
                                    MotControl.右进入.PMove(-1, 0);
                                }
                                LCRHelper.LCRFlow = LCR.LCRFlow.测值整体平移;
                            }
                            break;
                        case LCR.LCRFlow.测值整体平移:
                            LCRHelper.LCRFlow = LCR.LCRFlow.测值定位;
                            break;
                        case LCR.LCRFlow.测值定位:
                            LCRHelper.LCRFlow = LCR.LCRFlow.AB探针到位;
                            MotControl.测值整体上下.MovePosByName("探测位", 1, AxisRunVel.Instance.测值整体上下.Sped, AxisRunVel.Instance.测值整体上下.Acc);
                            break;
                        case LCR.LCRFlow.AB探针到位:
                            if (MotControl.测值整体上下.InPos("探测位"))
                            {
                                MotControl.测值支撑电磁铁.On();
                                LCRHelper.LCRFlow = LCR.LCRFlow.下针;
                                MotControl.下针.MovePosByName("探测位", 1, AxisRunVel.Instance.下针.Sped, AxisRunVel.Instance.下针.Acc);
                            }
                            Thread.Sleep(1000);
                            break;
                        case LCR.LCRFlow.下针:
                            if (MotControl.下针.InPos("探测位"))
                            {
                                LCRHelper.LCRFlow = LCR.LCRFlow.发送电表指令;
                                KTimer.Restart();
                                LCRHelper.SendReadCommand();
                            }
                            else
                            {
                                LCRHelper.LCRFlow = LCR.LCRFlow.AB探针到位;
                            }
                            break;
                        case LCR.LCRFlow.发送电表指令:
                            LCRHelper.LCRFlow = LCR.LCRFlow.增加补偿值;
                            LCRHelper.RealValue = (LCRHelper.Min_Value + LCRHelper.Max_Value) / 2;
                            if (KTimer.IsOn(ParamManager.Instance.TimerOut.I))
                            {
                                AlarmControl.Alarm = AlarmList.测值超时;
                                LCRHelper.LCRFlow = LCR.LCRFlow.None;
                            }
                            break;
                        case LCR.LCRFlow.增加补偿值:
                            LCRHelper.SetUnitReadData(ref LCRHelper.ReadData);
                            LCRHelper.RealValue = LCRHelper.ReadData;
                            LCRHelper.LCRFlow = LCR.LCRFlow.判断值是否在范围;
                            break;
                        case LCR.LCRFlow.判断值是否在范围:
                            MotControl.测值整体上下.MovePosByName("待探测位", 1, AxisRunVel.Instance.测值整体上下.Sped, AxisRunVel.Instance.测值整体上下.Acc);
                            MotControl.测值支撑电磁铁.Off();
                            if (LCRHelper.RealValue >= LCRHelper.Min_Value && LCRHelper.RealValue <= LCRHelper.Max_Value)
                            {
                                if (LCRHelper.Side == LCR.WhichSide.Left)
                                {
                                    double pos = testCount * 1 + MotControl.左进入.GetPosByName("测值位");
                                    MotControl.左进入.PMove(pos, 0, 1000, 100);
                                    LCRHelper.LRealValue = LCRHelper.RealValue;
                                    LCRHelper.LResult = "Pass";
                                }
                                else if (LCRHelper.Side == LCR.WhichSide.Right)
                                {
                                    double pos = testCount * 1 + MotControl.右进入.GetPosByName("测值位");
                                    MotControl.右进入.PMove(pos, 0, 1000, 100);
                                    LCRHelper.RRealValue = LCRHelper.RealValue;
                                    LCRHelper.RResult = "Pass";
                                }
                                LCRHelper.Result = LCRResult.Pass;
                                if (ParamManager.Instance.ContinuousTest.B)
                                {

                                    LCRHelper.LCRFlow = LCR.LCRFlow.走一格;
                                }
                                else
                                {
                                    testCount = 0;
                                    LCRHelper.LCRFlow = LCR.LCRFlow.Finish;
                                }
                            }
                            else if (ParamManager.Instance.ContinuousTest.B || testCount < ParamManager.Instance.testint_Count.I - 1)
                            {
                                LCRHelper.Result = LCRResult.Fail;
                                LCRHelper.LCRFlow = LCR.LCRFlow.走一格;
                            }
                            else
                            {
                                //MotControl.蜂鸣器.On();
                                FormAlarm formAlarm = new FormAlarm(DateTime.Now.ToString(), "测值失败", "admin", 1);
                                DialogResult dialogResult = formAlarm.ShowDialog();
                                if (dialogResult == DialogResult.OK)
                                {
                                    if (LCRHelper.Side == LCR.WhichSide.Left)
                                    {
                                        LCRHelper.LResult = "人工Pass".tr();
                                    }
                                    else if (LCRHelper.Side == LCR.WhichSide.Right)
                                    {
                                        LCRHelper.RResult = "人工Pass".tr();
                                    }
                                    LCRHelper.LCRFlow = LCR.LCRFlow.Finish;
                                }
                                else
                                {
                                    if (LCRHelper.Side == LCR.WhichSide.Left)
                                    {
                                        LCRHelper.LResult = "Fail";
                                    }
                                    else if (LCRHelper.Side == LCR.WhichSide.Right)
                                    {
                                        LCRHelper.RResult = "Fail";
                                    }
                                    LCRHelper.LCRFlow = LCR.LCRFlow.None;
                                }
                                if (LCRHelper.Side == LCR.WhichSide.Left)
                                {
                                    LCRHelper.LRealValue = LCRHelper.RealValue;
                                    double pos = testCount * 1 + MotControl.左进入.GetPosByName("测值位");
                                    MotControl.左进入.PMove(pos, 0);
                                }
                                else
                                {
                                    double pos = testCount * 1 + MotControl.右进入.GetPosByName("测值位");
                                    MotControl.右进入.PMove(pos, 0);
                                    LCRHelper.RRealValue = LCRHelper.RealValue;
                                }
                                testCount = 0;
                                //MotControl.蜂鸣器.Off();
                            }
                            GridAddData();
                            break;
                        case LCR.LCRFlow.Finish:
                            LCRHelper.Side = LCR.WhichSide.None;
                            break;
                        default:
                            break;
                    }
                }
                Thread.Sleep(50);
            }
        }

        /// <summary>
        /// 增加一条测值记录
        /// </summary>
        public void GridAddData()
        {
            if (ParamManager.Instance.System_机型.I == 2)
            {
                return;
            }
            this.Invoke(new Action(() =>
            {
                kryptonDataGridView1.Rows.Add(
                    kryptonDataGridView1.RowCount,
                    LCRHelper.Side.ToString(),
                    LCRHelper.LineNo.ToString(),
                    LCRHelper.RealValue,
                    LCRHelper.Result
                );
                kryptonDataGridView1.FirstDisplayedScrollingRowIndex = kryptonDataGridView1.RowCount - 1;
            }));
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            LCRHelper.SendReadCommand();
        }
    }
}
