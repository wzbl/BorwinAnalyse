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
        public string ModelName = "";

        public FlowBaseControl FlowControl;
        Graphics graphics;

        public FlowBaseModel()
        {
            InitializeComponent();
            this.Load += FlowBaseModel_Load;
        }

        public void CommFun()
        {
            if (Form1.MainControl.UCFlowControl.StartFlow == null)
                Form1.MainControl.UCFlowControl.StartFlow = FlowControl;
        }

        bool IsEnter = false;
        bool IsDown = false;
        public bool IsCanMove = true;
        public BaseModel TopRec;
        public BaseModel LeftRec;
        public BaseModel RightRec;
        public BaseModel BottomRec;
        public Brush recBrush = Brushes.Yellow;

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
            TopRec = new BaseModel(Width / 2, 0, BaseModelPos.Top);
            LeftRec = new BaseModel(0, Height / 2, BaseModelPos.Left);
            RightRec = new BaseModel(Width - 8, Height / 2, BaseModelPos.Right);
            BottomRec = new BaseModel(Width / 2, Height - 8, BaseModelPos.Bottom);
        }

        private void FlowBaseModel_MouseEnter(object sender, EventArgs e)
        {
            if (Form1.MainControl.UCFlowControl.ConnectModel && FlowControl.InFlow.Count == 0)
            {
                if (Form1.MainControl.UCFlowControl.CurrentModel.FlowControl.InFlow.Count == 0)
                {
                    Form1.MainControl.UCFlowControl.StartFlow = Form1.MainControl.UCFlowControl.CurrentModel.FlowControl;
                }
                if (Form1.MainControl.UCFlowControl.CurrentModel.RightRec.IsEnter)
                {
                    FlowControl.InFlow.Add(Form1.MainControl.UCFlowControl.CurrentModel.FlowControl, Form1.MainControl.UCFlowControl.CurrentModel.RightRec.pos);
                }
                else if (Form1.MainControl.UCFlowControl.CurrentModel.LeftRec.IsEnter)
                {
                    FlowControl.InFlow.Add(Form1.MainControl.UCFlowControl.CurrentModel.FlowControl, Form1.MainControl.UCFlowControl.CurrentModel.LeftRec.pos);

                }
                else if (Form1.MainControl.UCFlowControl.CurrentModel.BottomRec.IsEnter)
                {
                    FlowControl.InFlow.Add(Form1.MainControl.UCFlowControl.CurrentModel.FlowControl, Form1.MainControl.UCFlowControl.CurrentModel.BottomRec.pos);
                }

                if (Form1.MainControl.UCFlowControl.CurrentModel.FlowControl.InFlow.Count == 0) Form1.MainControl.UCFlowControl.StartFlow = Form1.MainControl.UCFlowControl.CurrentModel.FlowControl;


                Form1.MainControl.UCFlowControl.CurrentModel.FlowControl.outFlows.Add(FlowControl, TopRec.pos);

                Form1.MainControl.UCFlowControl.ConnectModel = false;
            }
            IsEnter = true;
            MouseEnterMove();
        }

        private void MouseEnterMove()
        {
            Point point1 = PointToClient(MousePosition);
            MouseEnterRec(point1, ref TopRec);
            MouseEnterRec(point1, ref LeftRec);
            MouseEnterRec(point1, ref RightRec);
            MouseEnterRec(point1, ref BottomRec);
            RightRec.point = new Point(Width - RightRec.recSize, Height / 2);
            BottomRec.point = new Point(Width / 2, Height - BottomRec.recSize);
            Refresh();
        }

        private void MouseEnterRec(Point point, ref BaseModel baseModel)
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
                baseModel.IsEnter = false;
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

            Form1.MainControl.UCFlowControl.CurrentModel = this;
        }

        private void FlowBaseModel_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsEnter && IsCanMove)
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
                    else
                    {
                        //画画
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
            graphics.DrawString(ModelName, this.Font, Brushes.Black, Width / 3, Height / 2);
            if (IsEnter)
            {
                graphics.FillRectangle(recBrush, LeftRec.point.X, LeftRec.point.Y, LeftRec.recSize, LeftRec.recSize);
                graphics.FillRectangle(recBrush, RightRec.point.X, RightRec.point.Y, RightRec.recSize, RightRec.recSize);
                graphics.FillRectangle(recBrush, TopRec.point.X, TopRec.point.Y, TopRec.recSize, TopRec.recSize);
                graphics.FillRectangle(recBrush, BottomRec.point.X, BottomRec.point.Y, BottomRec.recSize, BottomRec.recSize);
            }
        }

        #region 菜单操作
        private void 删除控件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            删除左节点ToolStripMenuItem_Click(sender, e);
            删除右节点ToolStripMenuItem_Click(sender, e);
            删除下节点ToolStripMenuItem_Click(sender, e);
            删除父节点ToolStripMenuItem_Click(sender, e);

            Form1.MainControl.UCFlowControl.DeleteFlowControl(this);
        }

        private void 删除父节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (FlowControl.InFlow.Count > 0)
            {
                FlowBaseControl InFlow = null;
                foreach (KeyValuePair<FlowBaseControl, BaseModelPos> kv in FlowControl.InFlow)
                {
                    InFlow = kv.Key;
                }

                FlowControl.InFlow.Remove(InFlow);
                InFlow.outFlows.Remove(FlowControl);

                if (FlowControl.outFlows.Count > 0)
                {
                    Form1.MainControl.UCFlowControl.StartFlow = FlowControl;
                }
            }
        }


        private void 删除左节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FlowControl.outFlows.Count > 0)
            {
                FlowBaseControl outFlow = null;
                foreach (KeyValuePair<FlowBaseControl, BaseModelPos> kv in FlowControl.outFlows)
                {
                    outFlow = kv.Key;
                    outFlow.InFlow.TryGetValue(FlowControl, out BaseModelPos baseModelPos);
                    if (baseModelPos == BaseModelPos.Left)
                    {
                        outFlow = kv.Key;
                        break;
                    }
                    else
                    {
                        outFlow = null;
                    }
                }

                if (outFlow != null)
                {
                    FlowControl.outFlows.Remove(outFlow);
                    outFlow.InFlow.Remove(FlowControl);
                }
            }
        }

        private void 删除右节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FlowControl.outFlows.Count > 0)
            {
                FlowBaseControl outFlow = null;
                foreach (KeyValuePair<FlowBaseControl, BaseModelPos> kv in FlowControl.outFlows)
                {
                    outFlow = kv.Key;
                    outFlow.InFlow.TryGetValue(FlowControl, out BaseModelPos baseModelPos);
                    if (baseModelPos == BaseModelPos.Right)
                    {
                        outFlow = kv.Key;
                        break;
                    }
                    else
                    {
                        outFlow = null;
                    }
                }

                if (outFlow != null)
                {
                    FlowControl.outFlows.Remove(outFlow);
                    outFlow.InFlow.Remove(FlowControl);
                }
            }
        }

        private void 删除下节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FlowControl.outFlows.Count > 0)
            {
                FlowBaseControl outFlow = null;
                foreach (KeyValuePair<FlowBaseControl, BaseModelPos> kv in FlowControl.outFlows)
                {
                    outFlow = kv.Key;
                    outFlow.InFlow.TryGetValue(FlowControl, out BaseModelPos baseModelPos);
                    if (baseModelPos == BaseModelPos.Bottom)
                    {
                        outFlow = kv.Key;
                        break;
                    }
                    else
                    {
                        outFlow = null;
                    }
                }

                if (outFlow != null)
                {
                    FlowControl.outFlows.Remove(outFlow);
                    outFlow.InFlow.Remove(FlowControl);
                }
            }
        }
        #endregion

    }

    /// <summary>
    /// 小正方形
    /// </summary>
    public class BaseModel
    {
        public BaseModel(int x, int y, BaseModelPos pos)
        {
            this.point = new Point(x, y);
            this.pos = pos;
        }

        public Point point { get; set; }

        public int recSize = 8;
        public BaseModelPos pos { get; set; }
        /// <summary>
        /// 鼠标进入
        /// </summary>
        public bool IsEnter = false;
    }

    public enum BaseModelPos
    {
        Top,
        Right,
        Left,
        Bottom
    }

}
