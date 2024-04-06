using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorwinSplicMachine.LCR
{
    public partial class UCLCRSearch : UserControl
    {
        private int OKCount;
        private int allCount;
        private List<Statistics> statistics;

        public UCLCRSearch()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Load += UCLCRSearch_Load;
        }

        private void UCLCRSearch_Load(object sender, EventArgs e)
        {
            statistics = new List<Statistics>();
            dt = new System.Data.DataTable();
            initGrid2();
            initGrid1();
        }

        public void UpdateLanguage()
        {

        }

        private void initGrid1()
        {
            boundGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
             new DataGridViewTextBoxColumn()
            {
                Width = 120,
                HeaderText = "接料时间",
                MinimumWidth = 6,
                Name = "Column1",
                ReadOnly = true,
            },
            new DataGridViewTextBoxColumn()
            {
                  Width = 100,
                HeaderText = "条码1",
                MinimumWidth = 6,
                Name = "Column2",
                ReadOnly = true,
            },
            new DataGridViewTextBoxColumn()
            {
                 Width = 100,
                HeaderText = "扫码1时间",
                MinimumWidth = 6,
                Name = "Column3",
                ReadOnly = true,
            },
            new DataGridViewTextBoxColumn()
            {
                Width = 100,
                HeaderText = "条码2",
                MinimumWidth = 6,
                Name = "Column4",
                ReadOnly = true,
            },
            new DataGridViewTextBoxColumn()
            {
                  Width = 100,
                HeaderText = "扫码2时间",
                MinimumWidth = 6,
                Name = "Column5",
                ReadOnly = true,
            },
            new DataGridViewTextBoxColumn()
            {
                 Width = 100,
                HeaderText = "物料信息",
                MinimumWidth = 6,
                Name = "Column6",
                ReadOnly = true,
            },
            new DataGridViewTextBoxColumn()
            {
                 Width = 100,
                HeaderText = "是否测值",
                MinimumWidth = 6,
                Name = "Column7",
                ReadOnly = true,
            },
                  new DataGridViewTextBoxColumn()
            {
                 Width = 100,
                HeaderText = "最大值",
                MinimumWidth = 6,
                Name = "Column8",
                ReadOnly = true,
            },
            new DataGridViewTextBoxColumn()
            {
                 Width = 100,
                HeaderText = "最小值",
                MinimumWidth = 6,
                Name = "Column9",
                ReadOnly = true,
            },new DataGridViewTextBoxColumn()
            {
                 Width = 100,
                HeaderText = "右实测值",
                MinimumWidth = 6,
                Name = "Column10",
                ReadOnly = true,
            },
            new DataGridViewTextBoxColumn()
            {
                 Width = 100,
                HeaderText = "右结果",
                MinimumWidth = 6,
                Name = "Column11",
                ReadOnly = true,
            },
            new DataGridViewTextBoxColumn()
            {
                Width = 100,
                HeaderText = "左实测值",
                MinimumWidth = 6,
                Name = "Column12",
                ReadOnly = true,
            },
            new DataGridViewTextBoxColumn()
            {
                Width = 100,
                HeaderText = "左结果",
                MinimumWidth = 6,
                Name = "Column13",
                ReadOnly = true,
            },
            new DataGridViewTextBoxColumn()
            {
                Width = 100,
                HeaderText = "是否丝印",
                MinimumWidth = 6,
                Name = "Column14",
                ReadOnly = true,
            }
            ,
            new DataGridViewTextBoxColumn()
            {
                 Width = 100,
                HeaderText = "左丝印结果",
                MinimumWidth = 6,
                Name = "Column15",
                ReadOnly = true,
            }
            ,
            new DataGridViewImageColumn()
            {
                 Width = 150,
                HeaderText = "左丝印图片",
                MinimumWidth = 6,
                ImageLayout= DataGridViewImageCellLayout.Zoom,
                Name = "Column16",
                ReadOnly = true,
            }
            ,
            new DataGridViewTextBoxColumn()
            {
                 Width = 100,
                HeaderText = "右丝印结果",
                MinimumWidth = 6,
                Name = "Column17",
                ReadOnly = true,
            }
            ,
            new DataGridViewImageColumn()
            {
                 Width = 150,
                HeaderText = "右丝印图片",
                MinimumWidth = 6,
                ImageLayout= DataGridViewImageCellLayout.Zoom,
                Name = "Column18",
                ReadOnly = true,
            }  ,
            new DataGridViewTextBoxColumn()
            {
                 Width = 100,
                HeaderText = "操作员",
                MinimumWidth = 6,
                Name = "Column19",
                ReadOnly = true,
            }
              ,
            new DataGridViewTextBoxColumn()
            {
                Width = 100,
                HeaderText = "备注",
                MinimumWidth = 6,
                Name = "Column20",
                ReadOnly = true,
            }
            });
            boundGridView1.RowTemplate.Height = 100;
        }

        System.Data.DataTable dt;
        private void initGrid2()
        {
            if (boundGridView2.DataSource == null)
            {
                dt.Columns.Add("元件规格");
                dt.Columns.Add("总数");
                dt.Columns.Add("测值数");
                dt.Columns.Add("不测值数");
                dt.Columns.Add("测值OK数");
                dt.Columns.Add("测值NG数");
                dt.Columns.Add("测值通过率");
                dt.Columns.Add("不测值通过率");
                boundGridView2.DataSource = dt;
            }

            for (int i = 0; i < statistics.Count; i++)
            {
                DataRow dataRow = dt.NewRow();
                dataRow[0] = statistics[i].Size;
                dataRow[1] = statistics[i].AllCount;
                dataRow[2] = statistics[i].测值数;
                dataRow[3] = statistics[i].不测值数;
                dataRow[4] = statistics[i].测值OK数;
                dataRow[5] = statistics[i].测值NG数;
                dataRow[6] = statistics[i].测值数 > 0 ? ((float)statistics[i].测值OK数 * 100) / statistics[i].测值数 : 0;
                dataRow[7] = statistics[i].不测值数 > 0 ? 100 : 0;
                dt.Rows.Add(dataRow);
            }


            for (int i = 0; i < boundGridView2.ColumnCount; i++)
            {
                boundGridView2.Columns[i].Width = boundGridView2.Width / 9;
            }

            float pass = 0;
            if (OKCount == 0 || allCount == 0)
            {
                pass = 0;
            }
            else
            {
                pass = ((float)(OKCount * 100)) / allCount;
            }

            List<HeaderItem> headerItems = boundGridView2.Headers.GetHeaders();
            if (headerItems.Count > 0)
            {
                for (int i = 0; i < headerItems.Count; i++)
                    boundGridView2.Headers.RemoveHeader(headerItems[i]);
            }

            this.boundGridView2.Headers.AddHeader(0, 7, 4, 4, "AFS智能上料检测报告");
            this.boundGridView2.Headers.AddHeader(0, 0, 3, 3, "设备编号:");
            this.boundGridView2.Headers.AddHeader(1, 1, 3, 3, "值");
            this.boundGridView2.Headers.AddHeader(2, 2, 3, 3, "设备类型:");
            this.boundGridView2.Headers.AddHeader(3, 3, 3, 3, "值");
            this.boundGridView2.Headers.AddHeader(4, 4, 3, 3, "操作员:");
            this.boundGridView2.Headers.AddHeader(5, 5, 3, 3, "值");
            this.boundGridView2.Headers.AddHeader(6, 6, 3, 3, "机种线别:");
            this.boundGridView2.Headers.AddHeader(7, 7, 3, 3, "值");

            this.boundGridView2.Headers.AddHeader(0, 0, 2, 2, "总数:");
            this.boundGridView2.Headers.AddHeader(1, 1, 2, 2, allCount.ToString());
            this.boundGridView2.Headers.AddHeader(2, 2, 2, 2, "通过数:");
            this.boundGridView2.Headers.AddHeader(3, 3, 2, 2, OKCount.ToString());
            this.boundGridView2.Headers.AddHeader(4, 4, 2, 2, "失败数:");
            this.boundGridView2.Headers.AddHeader(5, 5, 2, 2, (allCount - OKCount).ToString());
            this.boundGridView2.Headers.AddHeader(6, 6, 2, 2, "通过率:");
            this.boundGridView2.Headers.AddHeader(7, 7, 2, 2, pass.ToString());
            this.boundGridView2.Headers.AddHeader(0, 7, 1, 1, "统计信息");

            boundGridView2.Refresh();
            //SetGrid2BackColor();
        }

        /// <summary>
        /// 设置查询结果背景色
        /// </summary>
        private void SetGrid2BackColor()
        {

            boundGridView2.EnableHeadersVisualStyles = false;
            boundGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;
            boundGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(220, 232, 244);
            for (int i = 0; i < boundGridView2.Rows.Count - 1; i++)
            {
                if (i % 2 == 0)
                {
                    boundGridView2.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(154, 142, 152);
                }
                else
                {
                    boundGridView2.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(170, 190, 220);
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            PdfSharpHelper.ExportPdf("D:\\dd.pdf", boundGridView1, boundGridView2);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            statistics.Clear();
            boundGridView1.Rows.Clear();
            dt.Rows.Clear();
            allCount = 0;
            OKCount = 0;
            try
            {
                if (startDateTime.Value.DayOfYear > endDateTime.Value.DayOfYear)
                {
                    MessageBox.Show("开始时间不可大于结束时间");
                    return;
                }

                if (startDateTime.Text.Substring(0, 7) != endDateTime.Text.Substring(0, 7))
                {
                    MessageBox.Show("只可查询同月份数据");
                    return;
                }

                int startDay = int.Parse(startDateTime.Text.Substring(8, 2));//2022-22-08
                int endDay = int.Parse(endDateTime.Text.Substring(8, 2));//2022-22-08
                for (int i = startDay; i <= endDay; i++)
                {
                    string date = i < 10 ? "0" + i : i.ToString();
                    string path = "D:\\HistoryData" + "\\" + startDateTime.Text.Substring(0, 7) + "\\" + startDateTime.Text.Substring(0, 7) + "-" + date + ".csv";
                    if (!File.Exists(path))
                    {
                        continue;
                    }

                    using (FileStream fs = new FileStream(path, FileMode.Open))
                    {
                        StreamReader sr = new StreamReader(fs);
                        string nextLine = sr.ReadLine();
                        while ((nextLine = sr.ReadLine()) != null)
                        {
                            string[] strings = nextLine.Split(',');
                            if (strings.Length >= 20)
                            {
                                G1Add(strings);
                                G2Add(strings);
                                allCount++;
                            }

                        }
                        sr.Close();
                        sr.Dispose();
                        fs.Dispose();
                        fs.Close();
                    }

                    initGrid2();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void G1Add(string[] strings)
        {
            boundGridView1.Rows.Add(
                                       strings[0],
                                       strings[1],
                                       strings[2],
                                       strings[3],
                                       strings[4],
                                       strings[5],                   //物料信息
                                       strings[6],
                                       strings[7],
                                       strings[8],
                                       strings[9],
                                       strings[10],
                                       strings[11],
                                       strings[12],
                                       strings[13],
                                       strings[14],
                                      new Bitmap(strings[15]),     //
                                       strings[16],
                                      new Bitmap(strings[15]),   //
                                       strings[18],
                                       strings[19]
                                   );
        }

        private void G2Add(string[] strings)
        {
            string material = strings[5];
            string size = material.Split('-')[1];

            if (statistics.Where(x => x.Size == size).ToList().Count > 0)
            {
                statistics.Where(x => x.Size == size).ToList()[0].AllCount++;

                if (!bool.Parse(strings[6]))
                {
                    statistics.Where(x => x.Size == size).ToList()[0].不测值数++;
                    OKCount++;
                }
                else
                {
                    statistics.Where(x => x.Size == size).ToList()[0].测值数++;

                    if (strings[10].Contains("NG") || strings[12].Contains("NG"))
                    {
                        statistics.Where(x => x.Size == size).ToList()[0].测值NG数++;
                    }
                    else
                    {
                        if (strings[10].Contains("OK") || strings[12].Contains("OK"))
                        {
                            statistics.Where(x => x.Size == size).ToList()[0].测值OK数++;
                            OKCount++;
                        }

                    }
                }
            }
            else
            {
                Statistics gridData1 = new Statistics();
                gridData1.Size = size;
                gridData1.AllCount++;
                if (!bool.Parse(strings[6]))
                {
                    gridData1.不测值数++;
                    OKCount++;
                }
                else
                {
                    gridData1.测值数++;

                    if (strings[10].Contains("NG") || strings[12].Contains("NG"))
                    {
                        gridData1.测值NG数++;
                    }
                    else
                    {
                        if (strings[10].Contains("OK") || strings[12].Contains("OK"))
                        {
                            gridData1.测值OK数++;
                            OKCount++;
                        }

                    }

                }
                statistics.Add(gridData1);
            }
        }

    }

    /// <summary>
    /// 统计信息
    /// </summary>
    public class Statistics
    {
        /// <summary>
        /// 元件规格
        /// </summary>
        public string Size;
        /// <summary>
        /// 总数
        /// </summary>
        public int AllCount;

        /// <summary>
        /// 纸带数
        /// </summary>
        public int 测值数;

        /// <summary>
        /// 胶带数
        /// </summary>
        public int 不测值数;

        /// <summary>
        /// 测值OK数
        /// </summary>
        public int 测值OK数;

        /// <summary>
        /// 测值NG数
        /// </summary>
        public int 测值NG数;
    }
}
