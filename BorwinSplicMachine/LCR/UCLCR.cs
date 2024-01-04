using BorwinAnalyse.BaseClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
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
        }

        private void Init()
        {
            LCRHelper = new LCRHelper();
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
        
        /// <summary>
        /// LCR测值线程
        /// </summary>
        public void LCRFlow()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    switch (LCRHelper.LCRFlow)
                    {
                        case LCR.LCRFlow.None:
                            //判断有无开始测值信号

                            break;
                        case LCR.LCRFlow.Start:
                            //开启超时定时器，给电表发指令
                            break;
                        case LCR.LCRFlow.ValueIsSuccess:
                            switch (LCRHelper.ReadStatus)
                            {
                                case ReadStatus.None:
                                    //判断是否超时
                                    break;
                                case ReadStatus.Success:

                                    break;
                                case ReadStatus.Fail:

                                    break;
                            }
                            break;
                        case LCR.LCRFlow.Judgement:
                            //判断值是否在范围

                            break;
                        case LCR.LCRFlow.Finish:
                            //测值完成
                            break;
                    }
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
