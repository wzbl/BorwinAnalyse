using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using PdfSharp.Drawing.BarCodes;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;
using PdfSharp.Charting;
using System.Windows.Forms.DataVisualization.Charting;
using System.Security.Cryptography.X509Certificates;

namespace BorwinSplicMachine.LCR
{
    public class PdfSharpHelper
    {

        public static int[] widths = new []{30,30,30,30,30,55,22,20,20,22,20,22,20,22,30,50,30,50,30,30};

        public static void ExportPdf(string path, BoundGridView dataGridView, BoundGridView statistics)
        {
            try
            {
                //1. 定义文档对象
                PdfDocument document = new PdfDocument();
                //2. 新增一页
                PdfPage page = document.AddPage();
                // 设置纸张大小
                page.Size = PageSize.A4;
                //3. 创建一个绘图对象
                XGraphics gfx = XGraphics.FromPdfPage(page);
                XFont font = new XFont("楷体", 5, XFontStyle.Regular);
                XPen xPen = new XPen(XColor.FromArgb(50, 50, 50));
                double width = (page.Width / dataGridView.ColumnCount);
                int hight = 30;
                int ii = 0;

                int hight1 = 0;
                int headHeight = 40;
                int titleHeight = 20;
                double headWidth = 2 * width;
                List<HeaderItem> headerItems = statistics.Headers.GetHeaders();
                gfx.DrawLines(xPen, new XPoint[] { new XPoint(0, 0), new XPoint(page.Width, 0), new XPoint(page.Width, 0), new XPoint(page.Width, headHeight), new XPoint(0, headHeight) });
                gfx.DrawString(headerItems[0].Content.ToString(), new XFont("楷体", 20, XFontStyle.Bold), XBrushes.Blue, new XRect(page.Width / 2, 4, width, hight), XStringFormats.Center);

                hight1 += headHeight;

                for (int h = 1; h < 9; h++)
                {
                    int j = (h - 1);
                    XPoint xPoint1 = new XPoint(j * headWidth, hight1);
                    XPoint xPoint2 = new XPoint(j * headWidth + headWidth, hight1);
                    XPoint xPoint3 = new XPoint(j * headWidth, hight1 + hight);
                    XPoint xPoint4 = new XPoint(j * headWidth + headWidth, hight1 + hight);
                    gfx.DrawLines(xPen, new XPoint[] { xPoint1, xPoint2, xPoint4, xPoint3, xPoint1 });
                    gfx.DrawString(headerItems[h].Content.ToString(), new XFont("楷体", 10, XFontStyle.Bold), XBrushes.Blue, new XRect(1 + j * headWidth, (4 + hight1), headWidth, hight), XStringFormats.Center);
                }
                hight1 += hight;

                for (int h = 9; h < 17; h++)
                {
                    int j = (h - 9);
                    XPoint xPoint1 = new XPoint(j * headWidth, hight1);
                    XPoint xPoint2 = new XPoint(j * headWidth + headWidth, hight1);
                    XPoint xPoint3 = new XPoint(j * headWidth, hight1 + hight);
                    XPoint xPoint4 = new XPoint(j * headWidth + headWidth, hight1 + hight);
                    gfx.DrawLines(xPen, new XPoint[] { xPoint1, xPoint2, xPoint4, xPoint3, xPoint1 });
                    gfx.DrawString(headerItems[h].Content.ToString(), new XFont("楷体", 10, XFontStyle.Bold), XBrushes.Blue, new XRect(1 + j * headWidth, (4 + hight1), headWidth, hight), XStringFormats.Center);
                }
                hight1 += hight;

                for (int i = 0; i < statistics.ColumnCount; i++)
                {
                    XPoint xPoint1 = new XPoint(i * headWidth, hight1);
                    XPoint xPoint2 = new XPoint(i * headWidth + headWidth, hight1);
                    XPoint xPoint3 = new XPoint(i * headWidth, hight1 + titleHeight);
                    XPoint xPoint4 = new XPoint(i * headWidth + headWidth, hight1 + titleHeight);
                    gfx.DrawLines(xPen, new XPoint[] { xPoint1, xPoint2, xPoint4, xPoint3, xPoint1 });
                    gfx.DrawString(statistics.Columns[i].HeaderText, new XFont("楷体", 10, XFontStyle.Bold), XBrushes.Blue, new XRect(1 + i * headWidth, (4 + hight1), headWidth, titleHeight), XStringFormats.Center);
                }
                hight1 += titleHeight;

                for (int i = 0; i < statistics.RowCount; i++)
                {
                    for (int j = 0; j < statistics.ColumnCount; j++)
                    {
                        XPoint xPoint1 = new XPoint(j * headWidth, (ii * hight)+ hight1);
                        XPoint xPoint2 = new XPoint(j * headWidth + headWidth, (ii * hight) + hight1);
                        XPoint xPoint3 = new XPoint(j * headWidth, (ii * hight) + hight + hight1);
                        XPoint xPoint4 = new XPoint(j * headWidth + headWidth, (ii * hight) + hight + hight1);
                        gfx.DrawLines(xPen, new XPoint[] { xPoint1, xPoint2, xPoint4, xPoint3, xPoint1 });
                        gfx.DrawString(statistics.Rows[i].Cells[j].FormattedValue.ToString(), font, XBrushes.Blue, new XRect(1 + j * headWidth, (4 + ii * hight + hight1), headWidth, hight), XStringFormats.Center);
                    }
                    ii++;
                }
                hight1 += ii * hight;

                int Width = 0;
                for (int i = 0; i < dataGridView.ColumnCount; i++)
                {
                    XPoint xPoint1 = new XPoint(Width, hight1);
                    XPoint xPoint2 = new XPoint(Width + widths[i], hight1);
                    XPoint xPoint3 = new XPoint(Width, hight1 + titleHeight);
                    XPoint xPoint4 = new XPoint(Width + widths[i], hight1 + titleHeight);
                    gfx.DrawLines(xPen, new XPoint[] { xPoint1, xPoint2, xPoint4, xPoint3, xPoint1 });
                    gfx.DrawString(dataGridView.Columns[i].HeaderText, new XFont("楷体", 5, XFontStyle.Bold), XBrushes.Blue, new XRect(1 + Width, (4 + hight1), widths[i], titleHeight), XStringFormats.Center);
                    Width += widths[i];
                }
                hight1 += titleHeight;

               

                ii= 0;

                for (int i = 0; i < dataGridView.RowCount; i++)
                {
                    if (string.IsNullOrEmpty(dataGridView.Rows[i].Cells[0].FormattedValue.ToString()))
                    {
                        continue;
                    }
                    Width = 0;
                    if (ii * hight + hight1 > page.Height)
                    {
                        ii = 0;
                        hight1 = 0;
                        page = document.AddPage();
                        page.Size = PageSize.A4;
                        gfx = XGraphics.FromPdfPage(page);
                    }
                    for (int j = 0; j < dataGridView.ColumnCount; j++)
                    {

                        if (dataGridView.Rows[i].Cells[j].FormattedValue is System.Drawing.Bitmap)
                        {
                            Bitmap bit = (dataGridView.Rows[i].Cells[j].FormattedValue as Bitmap);
                            MemoryStream strm = new MemoryStream();
                            bit.Save(strm, System.Drawing.Imaging.ImageFormat.Png);
                            XImage xfoto = XImage.FromStream(strm);
                            XPoint xPoint1 = new XPoint(Width, (ii * hight) + hight1);
                            XPoint xPoint2 = new XPoint(Width + widths[j] + hight, (ii * hight) + hight1);
                            XPoint xPoint3 = new XPoint(Width, (ii * hight) + hight + hight1);
                            XPoint xPoint4 = new XPoint(Width + widths[j] + hight, (ii * hight) + hight + hight1);
                            gfx.DrawLines(xPen, new XPoint[] { xPoint1, xPoint2, xPoint4, xPoint3, xPoint1 });
                            gfx.DrawImage(xfoto, Width + 1, ii * hight + hight1, widths[j], hight);
                        }
                        else
                        {
                            XPoint xPoint1 = new XPoint(Width, (ii * hight) + hight1);
                            XPoint xPoint2 = new XPoint(Width + widths[j], (ii * hight) + hight1);
                            XPoint xPoint3 = new XPoint(Width, (ii * hight) + hight + hight1);
                            XPoint xPoint4 = new XPoint(Width + widths[j], (ii * hight) + hight + hight1);
                            gfx.DrawLines(xPen, new XPoint[] { xPoint1, xPoint2, xPoint4, xPoint3, xPoint1 });
                            gfx.DrawString(dataGridView.Rows[i].Cells[j].FormattedValue.ToString(), font, XBrushes.Blue, new XRect(1 + Width, (4 + ii * hight + hight1), widths[j], hight), XStringFormats.Center);
                        }
                        Width += widths[j];
                    }
                    ii++;
                }
                document.Save(path);
                MessageBox.Show("success");
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// 将二进制转为图片
        /// </summary>
        /// <param name="byteArrayImage"></param>
        public static Image FromBinaryToImage(string str)
        {
            byte[] byteArrayImage = Encoding.Unicode.GetBytes(str);
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(byteArrayImage))
            {
                System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
                ms.Flush();
                return returnImage;
            }
        }

        /// <summary>
        /// 将图片转为二进制
        /// </summary>
        /// <returns></returns>
        public static string FromImageToBinary(string path)
        {
            System.Drawing.Image img = System.Drawing.Image.FromFile(path);

            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                ms.Flush();
                byte[] byteArrayImage = ms.ToArray();
                string str = Encoding.Unicode.GetString(byteArrayImage);
                return str;
            }
        }
    }
}
