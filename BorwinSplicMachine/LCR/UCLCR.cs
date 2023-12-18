using BorwinAnalyse.BaseClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
        }

        private void Init()
        {
            LCRHelper = new LCRHelper();
            initDataGrid();
        }

        private void UCLCR_Load(object sender, EventArgs e)
        {

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
                HeaderText = "条码",
                MinimumWidth = 6,
                Name = "Column2",
                ReadOnly = true,
            },
            new DataGridViewTextBoxColumn()
            {
                FillWeight = 45.07613F,
                HeaderText = "最大值",
                MinimumWidth = 6,
                Name = "Column3",
                ReadOnly = true,
            },
            new DataGridViewTextBoxColumn()
            {
                FillWeight = 45.07613F,
                HeaderText = "最小值",
                MinimumWidth = 6,
                Name = "Column4",
                ReadOnly = true,
            },
            new DataGridViewTextBoxColumn()
            {
                FillWeight = 45.07613F,
                HeaderText = "标准值",
                MinimumWidth = 6,
                Name = "Column5",
                ReadOnly = true,
            },
             new DataGridViewTextBoxColumn()
            {
                FillWeight = 45.07613F,
                HeaderText = "实测值",
                MinimumWidth = 6,
                Name = "Column5",
                ReadOnly = true,
            },
            new DataGridViewTextBoxColumn()
            {
                FillWeight = 45.07613F,
                HeaderText = "类型",
                MinimumWidth = 6,
                Name = "Column6",
                ReadOnly = true,
            },
               new DataGridViewTextBoxColumn()
            {
                FillWeight = 45.07613F,
                HeaderText = "尺寸",
                MinimumWidth = 6,
                Name = "Column6",
                ReadOnly = true,
            },
            new DataGridViewTextBoxColumn()
            {
                FillWeight = 45.07613F,
                HeaderText = "单位",
                MinimumWidth = 6,
                Name = "Column6",
                ReadOnly = true,
            },
               new DataGridViewTextBoxColumn()
            {
                FillWeight = 45.07613F,
                HeaderText = "等级",
                MinimumWidth = 6,
                Name = "Column6",
                ReadOnly = true,
            },
            new DataGridViewTextBoxColumn()
            {
                FillWeight = 45.07613F,
                HeaderText = "线号",
                MinimumWidth = 6,
                Name = "Column7",
                ReadOnly = true,
            },
            new DataGridViewTextBoxColumn()
            {
                FillWeight = 45.07613F,
                HeaderText = "结果",
                MinimumWidth = 6,
                Name = "Column8",
                ReadOnly = true,
            }
            });

        }

        private void btnStart_Click(object sender, EventArgs e)
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

            if (string.IsNullOrEmpty(txtValue.Text)|| !double.TryParse(txtValue.Text, out double value))
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
        public void StartLCR()
        {
            LCR_Type lCR_Type = LCR_Type.Error;
            LCR_Size lCR_Size = LCR_Size.Error;
            Unit unit = Unit.Error;
            if (comType.Text=="RES")
            {
                lCR_Type= LCR_Type.电阻;
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
            else if (comType.Text == "CAP")
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
            lCR_Size = (LCR_Size)comSize.SelectedIndex+1;
            string grade = txtGrade.Text;
            if (grade.Contains("%"))
            {
                grade = grade.Replace("%", "");
            }

            LCRHelper.StartLCR(lCR_Type, lCR_Size, double.Parse(txtValue.Text), unit, double.Parse(grade));

            txtMax.Text = LCRHelper.Max_Value.ToString();
            txtMin.Text = LCRHelper.Min_Value.ToString();
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
    }
}
