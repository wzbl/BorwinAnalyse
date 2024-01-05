using System.Windows.Forms;
using System;
using PdfSharp.Drawing.Layout;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp;
using System.Drawing;
using System.Diagnostics;
using PdfSharp.Pdf.Content.Objects;
using System.Security.Cryptography;
using System.IO;
using System.ComponentModel;
using BorwinAnalyse.UCControls;
using ComponentFactory.Krypton.Toolkit;
using BorwinAnalyse.BaseClass;
using BorwinAnalyse.Forms;

namespace BorwinSplicMachine
{
    public partial class Form1 : KryptonForm
    {
        public static MainControl MainControl;
        public Form1()
        {
            InitializeComponent();
            MainControl=new MainControl(this);
        }
        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            BorwinAnalyse.Forms.AnalyseMainForm analyseMainForm = new BorwinAnalyse.Forms.AnalyseMainForm();
            analyseMainForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (this.components==null)
            {
                this.components= new System.ComponentModel.Container();
            }
            UpdataLanguage();
      
        }
        public void UpdataLanguage()
        {
            LanguageManager.Instance.UpdateLanguage(this, this.components.Components);
        }

        private void ExportPDF()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "(*.pdf)|*.pdf";
            saveFileDialog.RestoreDirectory = true;
            string path = "";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog.FileName;
                if (string.IsNullOrEmpty(path)) return;
            }
            else return;
            //1. 定义文档对象
            PdfDocument document = new PdfDocument();
            //2. 新增一页
            PdfPage page = document.AddPage();
            // 设置纸张大小
            page.Size = PageSize.A4;
            //3. 创建一个绘图对象
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("华文宋体", 10, XFontStyle.Bold);
            XPen xPen = new XPen(XColor.FromArgb(50, 50, 50));
            //double width = (page.Width / kryptonDataGridView1.ColumnCount) - 10;
            //int ii = 0;
            //for (int i = 0; i < kryptonDataGridView1.RowCount; i++)
            //{
            //    if (ii * 50 > page.Height)
            //    {
            //        ii = 0;
            //        page = document.AddPage();
            //        page.Size = PageSize.A4;
            //        gfx = XGraphics.FromPdfPage(page);
            //    }
            //    for (int j = 0; j < kryptonDataGridView1.ColumnCount; j++)
            //    {
            //        if (kryptonDataGridView1.Rows[i].Cells[j].FormattedValue is Bitmap)
            //        {
            //            XPoint xPoint1 = new XPoint(j * width, (ii * 50));
            //            XPoint xPoint2 = new XPoint(j * width + width+50, (ii * 50));
            //            XPoint xPoint3 = new XPoint(j * width, (ii * 50) + 50);
            //            XPoint xPoint4 = new XPoint(j * width + width+50, (ii * 50) + 50);
            //            gfx.DrawLines(xPen, new XPoint[] { xPoint1, xPoint2, xPoint4, xPoint3, xPoint1 });
            //            gfx.DrawImage(XImage.FromFile("D:\\IMG\\IF670-0411-001\\L-2023-11-10 08-39-13-IF670-0411-001.jpg"), j * width+1, ii * 50+1, width + 48, 48);
            //        }
            //        else
            //        {
            //            XPoint xPoint1 = new XPoint(j * width, (ii * 50));
            //            XPoint xPoint2 = new XPoint(j * width + width, (ii * 50));
            //            XPoint xPoint3 = new XPoint(j * width, (ii * 50) + 50);
            //            XPoint xPoint4 = new XPoint(j * width + width, (ii * 50) + 50);
            //            gfx.DrawLines(xPen, new XPoint[] { xPoint1, xPoint2, xPoint4, xPoint3 , xPoint1});
            //            gfx.DrawString(kryptonDataGridView1.Rows[i].Cells[j].FormattedValue.ToString(), font, XBrushes.Blue, new XRect(1 + j * width, (4 + ii * 50), width, 50), XStringFormats.Center);
            //        }
            //    }
            //    ii++;
            //}

            //6. 保存文档
            document.Save(path);
            MessageBox.Show("success");
        }


        /// <summary>
        /// 生成Pdf
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="bo"></param>
        /// <returns></returns>
        public bool GeneratePdf(string filePath)
        {
            int margin_left_right = 30;//左右边距
            int margin_top_bottom = 30;//上下边距
            //1. 定义文档对象
            PdfDocument document = new PdfDocument();
            //2. 新增一页
            PdfPage page = document.AddPage();
            // 设置纸张大小
            page.Size = PageSize.A4;
            //3. 创建一个绘图对象
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("华文宋体", 40, XFontStyle.Bold);
            //定制化内容开始
            int cur_x = 0 + margin_left_right;
            int cur_y = 0 + margin_top_bottom;
            //标题1
            gfx.DrawString("11111111", font, XBrushes.Red, new XRect(cur_x, cur_y, page.Width - 2 * cur_x, 80), XStringFormats.Center);
            //序号
            font = new XFont("华文宋体", 12, XFontStyle.Regular);
            cur_y = cur_y + 80;
            gfx.DrawString("22222222", font, XBrushes.Black, new XRect(cur_x, cur_y, 100, 20), XStringFormats.CenterLeft);
            //密级
            cur_x = cur_x + 200;
            gfx.DrawString(string.Format("密级[{0}]", "33333"), font, XBrushes.Black, new XRect(cur_x, cur_y, 100, 20), XStringFormats.CenterLeft);
            //缓级
            cur_x = cur_x + 100;
            gfx.DrawString(string.Format("缓级[{0}]", "444444"), font, XBrushes.Black, new XRect(cur_x, cur_y, 100, 20), XStringFormats.CenterLeft);
            //签发人
            cur_x = cur_x + 100;
            gfx.DrawString(string.Format("签发人：{0}", "55555"), font, XBrushes.Black, new XRect(cur_x, cur_y, 100, 20), XStringFormats.CenterLeft);
            //一条横线
            cur_x = 0 + margin_left_right;
            cur_y = cur_y + 20;
            XPen pen = new XPen(XColor.FromKnownColor(XKnownColor.Black), 1);
            gfx.DrawLine(pen, cur_x, cur_y, page.Width - cur_x, cur_y + 2);
            //标题2
            font = new XFont("华文宋体", 20, XFontStyle.Regular);
            cur_y = cur_y + 10;
            gfx.DrawString("asdfghj", font, XBrushes.Black, new XRect(cur_x, cur_y, page.Width - 2 * cur_x, 40), XStringFormats.Center);
            //抬头
            font = new XFont("华文宋体", 15, XFontStyle.Bold);
            cur_y = cur_y + 40;
            gfx.DrawString("6666666", font, XBrushes.Black, new XRect(cur_x, cur_y, page.Width, 40), XStringFormats.CenterLeft);
            //正文 ，自动换行
            cur_y = cur_y + 40;
            XTextFormatter tf = new XTextFormatter(gfx);
            font = new XFont("华文宋体", 12, XFontStyle.Regular);

            //测量当前内容下，一行可以多少个汉字
            int cnt = 0;
            int height = 0;
            for (int i = 0; i < 3; i++)
            {
                XSize xsize = gfx.MeasureString("i=" + i.ToString(), font, XStringFormats.TopLeft);
                double width = xsize.Width;
                if (width >= page.Width - 2 * cur_x)
                {
                    cnt = i; //表示一行可以放多少个汉字。
                    height = (int)xsize.Height;
                    break;
                }
            }
            cnt = cnt > 0 ? cnt : 6;//每一行多少汉字
            string[] arrContent = "xczxsa".Split('\n');
            string new_content = "";
            int total_lines = 0;
            foreach (string content in arrContent)
            {
                if (content.Length <= cnt)
                {
                    new_content += string.Format("{0}\n", content);
                    total_lines++;
                }
                else
                {
                    string tmpContent = content;
                    int lines = content.Length / cnt + 1;
                    for (int j = 0; j < lines; j++)
                    {
                        tmpContent = tmpContent.Insert(j * cnt, "\n");
                        total_lines++;
                    }
                    new_content += string.Format("{0}\n", tmpContent);
                }
            }
            int num = new_content.Length - new_content.Replace("\r", "").Length;
            //计算矩形
            XRect rect = new XRect(cur_x, cur_y, page.Width - 2 * cur_x, (total_lines + num) * (height + 2));
            tf.DrawString(new_content, font, XBrushes.Black, rect, XStringFormats.TopLeft);
            //主题词
            cur_y = cur_y + (total_lines + num) * (height + 2) + 20;
            font = new XFont("华文宋体", 12, XFontStyle.Bold);
            gfx.DrawString(string.Format("主题词：{0}", "6l6"), font, XBrushes.Black, new XRect(cur_x, cur_y, page.Width, 40), XStringFormats.CenterLeft);
            //再加一条横线
            cur_y = cur_y + 40;
            gfx.DrawLine(pen, cur_x, cur_y, page.Width - cur_x, cur_y + 2);
            cur_y = cur_y + 2;
            font = new XFont("华文宋体", 10, XFontStyle.Regular);
            gfx.DrawString(string.Format("{0}{1}", "china", "江西"), font, XBrushes.Black, new XRect(cur_x, cur_y, page.Width - 2 * cur_x, 40), XStringFormats.CenterLeft);
            gfx.DrawString(DateTime.Now.ToString("yyyy 年 MM 月 dd 日 印发"), font, XBrushes.Black, new XRect(cur_x, cur_y, page.Width - 2 * cur_x, 40), XStringFormats.CenterRight);
            gfx.DrawImage(XImage.FromFile("D:\\IMG\\IF670-0411-001\\L-2023-11-10 08-39-13-IF670-0411-001.jpg"), cur_x, cur_y + 100, 100, 50);
            //水印开始
            font = new XFont("华文宋体", 20, XFontStyle.BoldItalic);
            // 计算长度
            var size = gfx.MeasureString("zz", font);

            // 定义旋转中心
            gfx.TranslateTransform(page.Width / 2, page.Height / 2);
            gfx.RotateTransform(-Math.Atan(page.Height / page.Width) * 180 / Math.PI);
            gfx.TranslateTransform(-page.Width / 2, -page.Height / 2);

            // 字符样式
            var format = new XStringFormat();
            format.Alignment = XStringAlignment.Near;
            format.LineAlignment = XLineAlignment.Near;

            //画刷
            XBrush brush = new XSolidBrush(XColor.FromArgb(128, 255, 0, 0));
            for (int i = 0; i < 3; i++)
            {
                gfx.DrawString("12345", font, brush,
                new XPoint((page.Width - size.Width) / (1.5 + i * 0.5), (page.Height - size.Height) / (1.5 + i * 0.5)),
                format);
            }

            //水印结束
            //6. 保存文档
            document.Save(filePath);
            return true;
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            ExportPDF();
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            Stopwatch sp = new Stopwatch();
            sp.Start();
            //for (int i = 0; i < 300; i++)
            //{
            //    Bitmap bitmap = new Bitmap(Image.FromFile("D:\\IMG\\IF670-0411-001\\L-2023-11-10 08-39-13-IF670-0411-001.jpg"), 100, 50);
            //    Bitmap bitmap2 = new Bitmap(Image.FromFile("D:\\我的资料库\\Documents\\Downloads\\icons8-刷新-120.png"), 100, 50);
            //    kryptonDataGridView1.Rows.Add(
            //       i + 1,
            //       sp.ElapsedMilliseconds,
            //       i + 1,
            //       i + 1,
            //       i + 1,
            //       i + 1,
            //       i + 1,
            //       bitmap2,
            //       i + 1,
            //       i + 1,
            //       i + 1,
            //       i + 1,
            //       i + 1,
            //       bitmap
            //    );
            //    kryptonDataGridView1.Refresh();
            //}
            MessageBox.Show("完成");
            sp.Stop();
        }

        private void ShowUCBom_Click(object sender, EventArgs e)
        {
            kryptonPanel1.Controls.Clear();
            kryptonPanel1.Controls.Add(MainControl.UCBOM);
        }

        private void ShowUCBomSearch_Click(object sender, EventArgs e)
        {
            kryptonPanel1.Controls.Clear();
            kryptonPanel1.Controls.Add(MainControl.UCSearchBom);
        }

        private void ShowUCBomSet_Click(object sender, EventArgs e)
        {
            kryptonPanel1.Controls.Clear();
            kryptonPanel1.Controls.Add(MainControl.UCAnalyseSet);
        }

        private void ShowLanguageSearch_Click(object sender, EventArgs e)
        {
            kryptonPanel1.Controls.Clear();
            kryptonPanel1.Controls.Add(MainControl.UCSearchLanguage);
        }

        private void ShowUCParam_Click(object sender, EventArgs e)
        {
            kryptonPanel1.Controls.Clear();
            kryptonPanel1.Controls.Add(MainControl.UCParam);
        }

        private void ShowUCMain_Click(object sender, EventArgs e)
        {
            kryptonPanel1.Controls.Clear();
            kryptonPanel1.Controls.Add(MainControl.UCMain);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            this.WindowState = this.WindowState==FormWindowState.Maximized? FormWindowState.Normal : FormWindowState.Maximized;
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void kryptonRibbonGroup7_DialogBoxLauncherClick(object sender, EventArgs e)
        {

        }

        private void ShowUCBaseSet_Click(object sender, EventArgs e)
        {
            kryptonPanel1.Controls.Clear();
            kryptonPanel1.Controls.Add(MainControl.UCBaseSet);
        }

        private void kryptonRibbonGroupButton2_Click(object sender, EventArgs e)
        {
            kryptonPanel1.Controls.Clear();
            kryptonPanel1.Controls.Add(MainControl.UCLog);
        }

        /// <summary>
        /// 相机标定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kryptonRibbonGroupButton12_Click(object sender, EventArgs e)
        {
            kryptonPanel1.Controls.Clear();
            kryptonPanel1.Controls.Add(MainControl.CalibrationCCD);
        }

        private void kryptonRibbonGroupButton10_Click(object sender, EventArgs e)
        {
            kryptonPanel1.Controls.Clear();
            kryptonPanel1.Controls.Add(MainControl.UCLCRSearch);
        }

        private void kryptonRibbonGroup1_DialogBoxLauncherClick(object sender, EventArgs e)
        {

        }
    }


}
