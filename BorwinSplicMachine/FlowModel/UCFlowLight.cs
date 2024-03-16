using BorwinAnalyse.BaseClass;
using PdfSharp.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorwinSplicMachine.FlowModel
{
    public partial class UCFlowLight : UserControl
    {
        /// <summary>
        /// 流程灯
        /// </summary>
        public UCFlowLight()
        {
            InitializeComponent();
            this.Load += UCFlowLight_Load;
            this.Dock = DockStyle.Fill;
        }
        private void UCFlowLight_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }
        Pen Pen = new Pen(Color.Green);
        protected override void OnPaint(PaintEventArgs e)
        {
            int distence = 100;
            int radiu = 30;
            int height = 50;
            int startPos = 100;
            int des = 2;

            GraphicCricle(MotControl.flowLight.左进入, new Point(startPos, height), e.Graphics, radiu, "左进入", new Point(startPos + radiu, height + radiu / 2), new Point(distence + startPos, height + radiu / 2));

            GraphicCricle(MotControl.flowLight.左找空料, new Point(distence + startPos, height), e.Graphics, radiu, "左找空料", new Point(distence + startPos + radiu, height + radiu / 2), new Point(distence * 2 + startPos, height + radiu / 2));

            GraphicCricle(MotControl.flowLight.左测值, new Point(distence * 2 + startPos, height), e.Graphics, radiu, "左测值", new Point(2 * distence + startPos + radiu, height + radiu / 2), new Point(distence * 3 + startPos, height + radiu / 2));
            GraphicCricle(MotControl.flowLight.左丝印, new Point(distence * 3 + startPos, height), e.Graphics, radiu, "左丝印", new Point(3 * distence + startPos + radiu, height + radiu / 2), new Point(distence * 4 + startPos, height + radiu / 2));
            GraphicCricle(MotControl.flowLight.贴膜, new Point(distence * 4 + startPos, height), e.Graphics, radiu, "贴膜", new Point(distence * 4 + startPos + radiu / 2, height), new Point(distence * 4 + startPos + radiu / 2, height - 40 + radiu));
            GraphicCricle(MotControl.flowLight.接料完成, new Point(distence * 4 + startPos, height - 40), e.Graphics, radiu, "接料完成");

            GraphicCricle(MotControl.flowLight.右丝印, new Point(distence * 5 + startPos, height), e.Graphics, radiu, "右丝印", new Point(distence * 5 + startPos, height + radiu / 2), new Point(distence * 4 + startPos + radiu, height + radiu / 2));
            GraphicCricle(MotControl.flowLight.右测值, new Point(distence * 6 + startPos, height), e.Graphics, radiu, "右测值", new Point(distence * 6 + startPos, height + radiu / 2), new Point(distence * 5 + startPos + radiu, height + radiu / 2));
            GraphicCricle(MotControl.flowLight.右找空料, new Point(distence * 7 + startPos, height), e.Graphics, radiu, "右找空料", new Point(distence * 7 + startPos, height + radiu / 2), new Point(distence * 6 + startPos + radiu, height + radiu / 2));
            GraphicCricle(MotControl.flowLight.右进入, new Point(distence * 8 + startPos, height), e.Graphics, radiu, "右进入", new Point(distence * 8 + startPos, height + radiu / 2), new Point(distence * 7 + startPos + radiu, height + radiu / 2));
        }

        private void GraphicCricle(Light light, Point point, Graphics graphics, int radiu, string name, Point start = new Point(), Point end = new Point())
        {
            graphics.DrawString(name.tr(), Font, Brushes.Black, new Point(point.X - 60, point.Y));
            if (end.X > start.X)
            {
                graphics.DrawLine(Pen, start, end);
                graphics.DrawLine(Pen, new Point(end.X - 3, end.Y - 3), end);
                graphics.DrawLine(Pen, new Point(end.X - 3, end.Y + 3), end);
            }
            else if (end.X < start.X)
            {
                graphics.DrawLine(Pen, start, end);
                graphics.DrawLine(Pen, new Point(end.X + 3, end.Y - 3), end);
                graphics.DrawLine(Pen, new Point(end.X + 3, end.Y + 3), end);
            }
            else if (end.X == start.X)
            {
                graphics.DrawLine(Pen, start, end);
                graphics.DrawLine(Pen, new Point(end.X - 3, end.Y + 3), end);
                graphics.DrawLine(Pen, new Point(end.X + 3, end.Y + 3), end);
            }
            switch (light.status)
            {
                case 0:
                    graphics.FillEllipse(Brushes.Gray, new Rectangle(point.X, point.Y, radiu, radiu));
                    break;
                case 1:
                    graphics.FillEllipse(Brushes.Yellow, new Rectangle(point.X, point.Y, radiu, radiu));
                    break;
                case 2:
                    graphics.FillEllipse(Brushes.Green, new Rectangle(point.X, point.Y, radiu, radiu));
                    break;
                case 3:
                    graphics.FillEllipse(Brushes.Red, new Rectangle(point.X, point.Y, radiu, radiu));
                    break;
                default:
                    break;
            }
        }
    }
}
