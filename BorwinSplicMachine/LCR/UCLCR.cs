using BorwinAnalyse.BaseClass;
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

        private void Init()
        {
            LCRHelper = new LCRHelper();
            LCRFlow();
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
            }, new DataGridViewTextBoxColumn()
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
                HeaderText = "条码",
                MinimumWidth = 6,
                Name = "Column4",
                ReadOnly = true,
            },
            new DataGridViewTextBoxColumn()
            {
                FillWeight = 45.07613F,
                HeaderText = "最大值",
                MinimumWidth = 6,
                Name = "Column5",
                ReadOnly = true,
            },
            new DataGridViewTextBoxColumn()
            {
                FillWeight = 45.07613F,
                HeaderText = "最小值",
                MinimumWidth = 6,
                Name = "Column6",
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
                HeaderText = "类型",
                MinimumWidth = 6,
                Name = "Column8",
                ReadOnly = true,
            },
               new DataGridViewTextBoxColumn()
            {
                FillWeight = 45.07613F,
                HeaderText = "尺寸",
                MinimumWidth = 6,
                Name = "Column9",
                ReadOnly = true,
            },

            new DataGridViewTextBoxColumn()
            {
                FillWeight = 45.07613F,
                HeaderText = "标准值",
                MinimumWidth = 6,
                Name = "Column10",
                ReadOnly = true,
            },
            new DataGridViewTextBoxColumn()
            {
                FillWeight = 45.07613F,
                HeaderText = "单位",
                MinimumWidth = 6,
                Name = "Column11",
                ReadOnly = true,
            },
               new DataGridViewTextBoxColumn()
            {
                FillWeight = 45.07613F,
                HeaderText = "等级",
                MinimumWidth = 6,
                Name = "Column12",
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
            if (type == "电阻")
            {
                comType.SelectedIndex = 0;
            }
            else if (type == "电容")
            {
                comType.SelectedIndex = 1;
            }
            comSize.Text = size;
            comUnit.Text = unit;
            txtValue.Text = value;
            txtGrade.Text = grade;
            CheckMaterialMsg();
        }

        private void CheckMaterialMsg()
        {
            if (string.IsNullOrEmpty(comType.Text))
            {
                MessageBox.Show("请选择类型".tr());
                return;
            }

            if (string.IsNullOrEmpty(comSize.Text))
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
        public void LCRFlow()
        {
            Task.Run(() =>
            {
                while (Form1.MainControl.motControl != null)
                {
                    switch (LCRHelper.LCRFlow)
                    {
                        case LCR.LCRFlow.None:
                            if (Form1.MainControl.motControl.FlowLeft == MainFlow.请求测值)
                            {
                                LCRHelper.LCRFlow = LCR.LCRFlow.Start;
                                LCRHelper.Side = LCR.WhichSide.Left;
                                MotControl.凸轮.MovePosByName("进料位", 1);
                            }
                            else if (Form1.MainControl.motControl.FlowRight == MainFlow.请求测值)
                            {
                                LCRHelper.LCRFlow = LCR.LCRFlow.Start;
                                LCRHelper.Side = LCR.WhichSide.Right;
                                MotControl.凸轮.MovePosByName("进料位", 1);
                            }
                            break;
                        case LCR.LCRFlow.Start:
                            if (MotControl.凸轮.InPos("进料位"))
                            {
                                if (LCRHelper.Side == LCR.WhichSide.Left)
                                {
                                    MotControl.左进入.PMove(-MotControl.左进入.GetPosByName("测值位"), 0);
                                }
                                else if (LCRHelper.Side == LCR.WhichSide.Right)
                                {
                                    MotControl.右进入.PMove(-MotControl.右进入.GetPosByName("测值位"), 0);
                                }
                                Thread.Sleep(3000);
                                LCRHelper.LCRFlow = LCR.LCRFlow.测值整体平移;
                            }
                            break;
                        case LCR.LCRFlow.走一格:
                            if (MotControl.测值整体上下.HomeState)
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
                            Thread.Sleep(1000);
                            LCRHelper.LCRFlow = LCR.LCRFlow.测值定位;
                            break;
                        case LCR.LCRFlow.测值定位:
                            LCRHelper.LCRFlow = LCR.LCRFlow.AB探针到位;
                            MotControl.测值整体上下.PMove(MotControl.测值整体上下.GetPosByName("探测位"), 1);
                            break;
                        case LCR.LCRFlow.AB探针到位:
                            if (MotControl.测值整体上下.InPos("探测位"))
                            {
                                MotControl.测值支撑电磁铁.On();
                                LCRHelper.LCRFlow = LCR.LCRFlow.下针;
                                MotControl.下针.PMove(MotControl.下针.GetPosByName("探测位"), 1);
                            }
                            Thread.Sleep(1000);
                            break;
                        case LCR.LCRFlow.下针:
                            if (MotControl.下针.InPos("探测位"))
                            {
                                LCRHelper.SendReadCommand();
                                LCRHelper.LCRFlow = LCR.LCRFlow.发送电表指令;
                            }
                            break;
                        case LCR.LCRFlow.发送电表指令:
                            Thread.Sleep(1000);
                            LCRHelper.LCRFlow = LCR.LCRFlow.增加补偿值;
                            break;
                        case LCR.LCRFlow.增加补偿值:
                            LCRHelper.LCRFlow = LCR.LCRFlow.判断值是否在范围;
                            break;
                        case LCR.LCRFlow.判断值是否在范围:
                            MotControl.测值整体上下.Home(1000);
                            MotControl.下针.Home(1000);

                            MotControl.测值支撑电磁铁.Off();
                            if (testCount > 3)
                            {
                                Thread.Sleep(2000);
                                if (LCRHelper.Side == LCR.WhichSide.Left)
                                {
                                    double pos = testCount * 1 + MotControl.左进入.GetPosByName("测值位");
                                    MotControl.左进入.PMove(pos, 0);
                                }
                                else if (LCRHelper.Side == LCR.WhichSide.Right)
                                {
                                    double pos = testCount * 1 + MotControl.右进入.GetPosByName("测值位");
                                    MotControl.右进入.PMove(pos, 0);
                                }

                                LCRHelper.LCRFlow = LCR.LCRFlow.Finish;
                            }
                            else
                            {
                                LCRHelper.LCRFlow = LCR.LCRFlow.走一格;
                            }
                            break;
                        case LCR.LCRFlow.Finish:
                            testCount = 0;
                            break;
                        default:
                            break;
                    }
                    Thread.Sleep(100);
                }
            });
        }

        /// <summary>
        /// 增加一条测值记录
        /// </summary>
        public void GridAddData()
        {
            kryptonDataGridView1.Rows.Add(
                kryptonDataGridView1.RowCount,
                LCRHelper.Side.ToString(),
                LCRHelper.LineNo.ToString(),
                "Code",
                LCRHelper.Max_Value,
                LCRHelper.Min_Value,
                LCRHelper.RealValue,
                LCRHelper.Type,
                LCRHelper.Size.ToString(),
                LCRHelper.Value,
                LCRHelper.Unit,
                LCRHelper.Grade,
                LCRHelper.Result
            );
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            LCRHelper.SendReadCommand();
        }
    }
}
