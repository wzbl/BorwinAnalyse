using BorwinAnalyse.BaseClass;
using BorwinAnalyse.DataBase.Model;
using PdfSharp.Drawing;
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

namespace BorwinSplicMachine.FlowModel
{
    public partial class FlowBaseModel : UserControl
    {
        public string ModelName = "条码";
        Graphics graphics;
        public FlowBaseModel()
        {
            InitializeComponent();
            this.Load += FlowBaseModel_Load;
        }
        bool IsEnter = false;
        bool IsDown = false;
        bool IsCanMove = true;
        private BaseModel TopRec;
        private BaseModel LeftRec;
        private BaseModel RightRec;
        private BaseModel BottomRec;

        private Brush recBrush = Brushes.Blue;

        /// <summary>
        /// 双缓冲，解决界面加载、放大、缩小的卡顿问题
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        private void FlowBaseModel_Load(object sender, EventArgs e)
        {
            TopRec = new BaseModel(Width / 2, 0);
            LeftRec = new BaseModel(0, Height / 2);
            RightRec = new BaseModel(Width- 8, Height / 2);
            BottomRec = new BaseModel(Width / 2, Height- 8);
            //this.DoubleBuffered = true;//设置本窗体
            //SetStyle(ControlStyles.UserPaint, true);
            //SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            //SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
        }

        private void FlowBaseModel_MouseEnter(object sender, EventArgs e)
        {
            IsEnter = true;
            MouseEnterMove();
        }

         private void MouseEnterMove()
        {
            Point point1 = PointToClient(MousePosition);
            MouseEnterRec(point1,ref TopRec);
            MouseEnterRec(point1, ref LeftRec);
            MouseEnterRec(point1, ref RightRec);
            MouseEnterRec(point1, ref BottomRec);
            RightRec.point=new Point(Width - RightRec.recSize, Height / 2);
            BottomRec.point = new Point(Width / 2, Height - BottomRec.recSize);
            Refresh();
        }

        private void MouseEnterRec(Point point,ref BaseModel baseModel)
        {
            //判断鼠标是否进入到小正方形范围
            int px = point.X;
            int py = point.Y;
            if (px <= baseModel.point.X + baseModel.recSize && px >= baseModel.point.X && py <= baseModel.point.Y + baseModel.recSize && py >= baseModel.point.Y)
            {
                baseModel.recSize = 12;
                baseModel.IsEnter = true;
            }
            else
            {
                baseModel.IsEnter=false;
                baseModel.recSize = 8;
            }

        }

        private void FlowBaseModel_MouseLeave(object sender, EventArgs e)
        {
            IsEnter = false;
            Refresh();
        }

        Point controlPos;
        Point mousePos;
        private void FlowBaseModel_MouseDown(object sender, MouseEventArgs e)
        {
            IsDown = true;
            controlPos = Location;
            mousePos = MousePosition;
            if (LeftRec.IsEnter || RightRec.IsEnter || BottomRec.IsEnter || TopRec.IsEnter)
            {
                IsCanMove = false;
            }
        }

        private void FlowBaseModel_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsEnter&& IsCanMove)
            {
                MouseEnterMove();
            }
            if (e.Button == MouseButtons.Left)
            {
                if (IsDown)
                {
                    if (IsCanMove)
                    {
                        Location = new Point(controlPos.X - (mousePos.X - MousePosition.X), controlPos.Y - (mousePos.Y - MousePosition.Y));
                    }
                }
            }
        }

        private void FlowBaseModel_MouseUp(object sender, MouseEventArgs e)
        {
            IsDown = false;
            IsCanMove = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            graphics = e.Graphics;
            graphics.DrawString(ModelName, this.Font, recBrush, Width / 3, Height / 2);
            graphics.DrawString(ModelName, this.Font, recBrush, Width, Height );
            if (IsEnter)
            {
                graphics.FillRectangle(recBrush, LeftRec.point.X, LeftRec.point.Y, LeftRec.recSize, LeftRec.recSize);
                graphics.FillRectangle(recBrush, RightRec.point.X, RightRec.point.Y, RightRec.recSize, RightRec.recSize);
                graphics.FillRectangle(recBrush, TopRec.point.X, TopRec.point.Y, TopRec.recSize, TopRec.recSize);
                graphics.FillRectangle(recBrush, BottomRec.point.X, BottomRec.point.Y, BottomRec.recSize, BottomRec.recSize);
            }
        }


    }

    /// <summary>
    /// 小正方形
    /// </summary>
    public class BaseModel
    {
        public BaseModel(int x, int y)
        {
            this.point = new Point(x, y);
        }

        public Point point { get; set; }

        public int recSize = 8;

        /// <summary>
        /// 鼠标进入
        /// </summary>
        public bool IsEnter = false;
    }



}
