using BorwinAnalyse.BaseClass;
using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorwinSplicMachine.UCControls
{
    public partial class UCBaseSet : UserControl
    {
        public UCBaseSet()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Load += UCBaseSet_Load;
            this.components = new System.ComponentModel.Container();
            SetStyle();
        }

        public void SetStyle()
        {
            kryptonManager1.GlobalPaletteMode = PaletteModeManager.Office2010Blue;
        }

        private void UCBaseSet_Load(object sender, EventArgs e)
        {
            UpdataLanguage();
        }
        public void UpdataLanguage()
        {
            LanguageManager.Instance.UpdateLanguage(this, this.components.Components);
        }
        private void kryptonOffice2007Black_Click(object sender, EventArgs e)
        {
            int model = int.Parse(((KryptonRadioButton)sender).Tag.ToString());
            kryptonManager1.GlobalPaletteMode = (PaletteModeManager)model;
        }

        bool isChange = false;
        int count = 0;
        private void kryptonButton1_Click_1(object sender, EventArgs e)
        {
            int index = int.Parse(((KryptonButton)sender).Tag.ToString());
            isChange = true;
            GrawStatus();
            LanguageManager.Instance.UpdateCurrentLanguage(index);
            //Graphics graphics = kryptonPanel1.CreateGraphics();
            //graphics.DrawEllipse(new Pen(Brushes.Gray), new RectangleF(kryptonPanel1.Location.X+10, kryptonPanel1.Location.Y +50, 10, 10));
            Form1.MainControl.UpdataLanguage();
            isChange = false;
            count= 0;
            kryptonPanel1.Refresh();
        }

        private void GrawStatus()
        {
            Task.Factory.StartNew(() =>
            {
                while (isChange)
                {
                    Graphics graphics = kryptonPanel1.CreateGraphics();

                    Point centPoint = new Point(kryptonPanel1.Width / 2, kryptonPanel1.Height / 2);
                    int desc = 100;
                    float pos = (float)(desc * Math.Sin(Math.PI / 4));
                    graphics.DrawEllipse(new Pen(Brushes.AliceBlue,2), new RectangleF(centPoint.X, centPoint.Y - desc, 5, 5));
                    graphics.DrawEllipse(new Pen(Brushes.AliceBlue, 2), new RectangleF(centPoint.X + pos, centPoint.Y - pos, 10, 10));
                    graphics.DrawEllipse(new Pen(Brushes.AliceBlue, 2), new RectangleF(centPoint.X + desc, centPoint.Y, 15, 15));
                    graphics.DrawEllipse(new Pen(Brushes.AliceBlue, 2), new RectangleF(centPoint.X + pos, centPoint.Y + pos, 20, 20));
                    graphics.DrawEllipse(new Pen(Brushes.AliceBlue, 2), new RectangleF(centPoint.X, centPoint.Y + desc, 25, 25));
                    graphics.DrawEllipse(new Pen(Brushes.AliceBlue, 2), new RectangleF(centPoint.X - pos, centPoint.Y + pos, 30, 30));
                    graphics.DrawEllipse(new Pen(Brushes.AliceBlue, 2), new RectangleF(centPoint.X - desc, centPoint.Y, 35, 35));
                    graphics.DrawEllipse(new Pen(Brushes.AliceBlue, 2), new RectangleF(centPoint.X - pos, centPoint.Y - pos, 40, 40));
                    switch (count)
                    {
                        case 0:
                            graphics.FillEllipse(Brushes.Blue, new RectangleF(centPoint.X, centPoint.Y - desc, 5, 5));
                            break;
                        case 1:
                            graphics.FillEllipse(Brushes.Blue, new RectangleF(centPoint.X + pos, centPoint.Y - pos, 10, 10));
                            break;
                        case 2:
                            graphics.FillEllipse(Brushes.Blue, new RectangleF(centPoint.X + desc, centPoint.Y, 15, 15));
                            break;
                        case 3:
                            graphics.FillEllipse(Brushes.Blue, new RectangleF(centPoint.X + pos, centPoint.Y + pos, 20, 20));
                            break;
                        case 4:
                            graphics.FillEllipse(Brushes.Blue, new RectangleF(centPoint.X, centPoint.Y + desc, 25, 25));
                            break;
                        case 5:
                            graphics.FillEllipse(Brushes.Blue, new RectangleF(centPoint.X - pos, centPoint.Y + pos, 30, 30));
                            break;
                        case 6:
                            graphics.FillEllipse(Brushes.Blue, new RectangleF(centPoint.X - desc, centPoint.Y, 35, 35));
                            break;
                        case 7:
                            graphics.FillEllipse(Brushes.Blue, new RectangleF(centPoint.X - pos, centPoint.Y - pos, 40, 40));
                            count=-1;
                            break;
                        default:
                            break;
                    }
                   
                    count++;
                    Thread.Sleep(700);
                }
            });
        }
    }
}
