using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Emit;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace BorwinSplicMachine.FlowModel
{
    [Serializable]
    [XmlInclude(typeof(FlowBarCodeModel))]
    [XmlInclude(typeof(FlowLCRModel))]
    public partial class FlowBaseModel : UserControl
    {

        public FlowModeControl FlowModeControl;

        Graphics graphics;

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {

        }

        public FlowBaseModel()
        {
            InitializeComponent();

            this.Load += FlowBaseModel_Load;
        }

        bool IsEnter = false;
        public bool IsDown = false;
        public bool IsCanMove = true;

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
            FlowModeControl.TopRec = new BaseModel(Width / 2, 0, BaseModelPos.Top);
            FlowModeControl.LeftRec = new BaseModel(0, Height / 2, BaseModelPos.Left);
            FlowModeControl.RightRec = new BaseModel(Width - 8, Height / 2, BaseModelPos.Right);
            FlowModeControl.BottomRec = new BaseModel(Width / 2, Height - 8, BaseModelPos.Bottom);
        }

        private void FlowBaseModel_MouseEnter(object sender, EventArgs e)
        {
            IsEnter = true;
            MouseEnterMove();
            if (Form1.MainControl.UCFlowControl.StartFlow != this && Form1.MainControl.UCFlowControl.ConnectModel && FlowModeControl.FlowControl.InFlow.Count == 0)
            {
                if (Form1.MainControl.UCFlowControl.CurrentModel.FlowModeControl.FlowControl.InFlow.Count == 0)
                {
                    Form1.MainControl.UCFlowControl.StartFlow = Form1.MainControl.UCFlowControl.CurrentModel;
                }
                if (Form1.MainControl.UCFlowControl.CurrentModel.FlowModeControl.RightRec.IsEnter)
                {
                    FlowModeControl.FlowControl.InFlow.Add(Form1.MainControl.UCFlowControl.CurrentModel.FlowModeControl, Form1.MainControl.UCFlowControl.CurrentModel.FlowModeControl.RightRec.pos);
                }
                else if (Form1.MainControl.UCFlowControl.CurrentModel.FlowModeControl.LeftRec.IsEnter)
                {
                    FlowModeControl.FlowControl.InFlow.Add(Form1.MainControl.UCFlowControl.CurrentModel.FlowModeControl, Form1.MainControl.UCFlowControl.CurrentModel.FlowModeControl.LeftRec.pos);

                }
                else if (Form1.MainControl.UCFlowControl.CurrentModel.FlowModeControl.BottomRec.IsEnter)
                {
                    FlowModeControl.FlowControl.InFlow.Add(Form1.MainControl.UCFlowControl.CurrentModel.FlowModeControl, Form1.MainControl.UCFlowControl.CurrentModel.FlowModeControl.BottomRec.pos);
                }

                if (Form1.MainControl.UCFlowControl.CurrentModel.FlowModeControl.FlowControl.InFlow.Count == 0) Form1.MainControl.UCFlowControl.StartFlow = Form1.MainControl.UCFlowControl.CurrentModel;
                Form1.MainControl.UCFlowControl.CurrentModel.FlowModeControl.FlowControl.outFlows.Add(FlowModeControl, FlowModeControl.TopRec.pos);

                Form1.MainControl.UCFlowControl.ConnectModel = false;
            }

        }

        private void MouseEnterMove()
        {
            Point point1 = PointToClient(MousePosition);
            MouseEnterRec(point1, ref FlowModeControl.TopRec);
            MouseEnterRec(point1, ref FlowModeControl.LeftRec);
            MouseEnterRec(point1, ref FlowModeControl.RightRec);
            MouseEnterRec(point1, ref FlowModeControl.BottomRec);
            FlowModeControl.RightRec.point = new Point(Width - FlowModeControl.RightRec.recSize, Height / 2);
            FlowModeControl.BottomRec.point = new Point(Width / 2, Height - FlowModeControl.BottomRec.recSize);
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
        public void FlowBaseModel_MouseDown(object sender, MouseEventArgs e)
        {
            IsDown = true;
            controlPos = Location;
            mousePos = MousePosition;
            if (FlowModeControl.LeftRec.IsEnter || FlowModeControl.RightRec.IsEnter || FlowModeControl.BottomRec.IsEnter || FlowModeControl.TopRec.IsEnter)
            {
                IsCanMove = false;
            }

            Form1.MainControl.UCFlowControl.CurrentModel = this;
        }

        public void FlowBaseModel_MouseMove(object sender, MouseEventArgs e)
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
                        Point p = new Point(controlPos.X - (mousePos.X - MousePosition.X), controlPos.Y - (mousePos.Y - MousePosition.Y));
                        Point pointToClient = PointToScreen(p);
                        Point point = PointToScreen(Form1.MainControl.UCFlowControl.Location);
                        int width = Form1.MainControl.UCFlowControl.Width;
                        int height = Form1.MainControl.UCFlowControl.Height;

                        if (pointToClient.X + Width < point.X + width && pointToClient.X > point.X && pointToClient.Y + Height < point.Y + height && pointToClient.Y > point.Y)
                        {
                            Location = p;
                        }
                        FlowModeControl.Point = p;
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
            graphics.DrawString(FlowModeControl.FlowControl.ModelName, this.Font, Brushes.Black, Width / 3, Height / 2);
            if (IsEnter)
            {
                graphics.FillRectangle(recBrush, FlowModeControl.LeftRec.point.X, FlowModeControl.LeftRec.point.Y, FlowModeControl.LeftRec.recSize, FlowModeControl.LeftRec.recSize);
                graphics.FillRectangle(recBrush, FlowModeControl.RightRec.point.X, FlowModeControl.RightRec.point.Y, FlowModeControl.RightRec.recSize, FlowModeControl.RightRec.recSize);
                graphics.FillRectangle(recBrush, FlowModeControl.TopRec.point.X, FlowModeControl.TopRec.point.Y, FlowModeControl.TopRec.recSize, FlowModeControl.TopRec.recSize);
                graphics.FillRectangle(recBrush, FlowModeControl.BottomRec.point.X, FlowModeControl.BottomRec.point.Y, FlowModeControl.BottomRec.recSize, FlowModeControl.BottomRec.recSize);
            }
        }

        #region 菜单操作
        private void 删除控件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Form1.MainControl.UCFlowControl.StartFlow == this)
            {
                Form1.MainControl.UCFlowControl.StartFlow = null;
            }
            删除左节点ToolStripMenuItem_Click(sender, e);
            删除右节点ToolStripMenuItem_Click(sender, e);
            删除下节点ToolStripMenuItem_Click(sender, e);
            删除父节点ToolStripMenuItem_Click(sender, e);

            Form1.MainControl.UCFlowControl.DeleteFlowControl(this);
        }

        private void 删除父节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (FlowModeControl.FlowControl.InFlow.Count > 0)
            {
                FlowModeControl InFlow = null;
                foreach (KeyValuePair<FlowModeControl, BaseModelPos> kv in FlowModeControl.FlowControl.InFlow)
                {
                    InFlow = kv.Key;
                }

                FlowModeControl.FlowControl.InFlow.Remove(InFlow);
                InFlow.FlowControl.outFlows.Remove(FlowModeControl);

                if (FlowModeControl.FlowControl.outFlows.Count > 0)
                {
                    Form1.MainControl.UCFlowControl.StartFlow = this;
                }
            }
        }

        private void 删除左节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FlowModeControl.FlowControl.outFlows.Count > 0)
            {
                FlowModeControl outFlow = null;
                foreach (KeyValuePair<FlowModeControl, BaseModelPos> kv in FlowModeControl.FlowControl.outFlows)
                {
                    outFlow = kv.Key;
                    outFlow.FlowControl.InFlow.TryGetValue(FlowModeControl, out BaseModelPos baseModelPos);
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
                    FlowModeControl.FlowControl.outFlows.Remove(outFlow);
                    outFlow.FlowControl.InFlow.Remove(FlowModeControl);
                }
            }
        }

        private void 删除右节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FlowModeControl.FlowControl.outFlows.Count > 0)
            {
                FlowModeControl outFlow = null;
                foreach (KeyValuePair<FlowModeControl, BaseModelPos> kv in FlowModeControl.FlowControl.outFlows)
                {
                    outFlow = kv.Key;
                    outFlow.FlowControl.InFlow.TryGetValue(FlowModeControl, out BaseModelPos baseModelPos);
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
                    FlowModeControl.FlowControl.outFlows.Remove(outFlow);
                    outFlow.FlowControl.InFlow.Remove(FlowModeControl);
                }
            }
        }

        private void 删除下节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FlowModeControl.FlowControl.outFlows.Count > 0)
            {
                FlowModeControl outFlow = null;
                foreach (KeyValuePair<FlowModeControl, BaseModelPos> kv in FlowModeControl.FlowControl.outFlows)
                {
                    outFlow = kv.Key;
                    outFlow.FlowControl.InFlow.TryGetValue(FlowModeControl, out BaseModelPos baseModelPos);
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
                    FlowModeControl.FlowControl.outFlows.Remove(outFlow);
                    outFlow.FlowControl.InFlow.Remove(FlowModeControl);
                }
            }
        }



        #endregion

    }
    [Serializable]
    public class FlowModeControl
    {
        public FlowModeControl()
        {

        }
        public FlowModeControl(FlowBaseControl FlowControl) { 
        this.FlowControl = FlowControl;
        }
        public Point Point;

        public FlowBaseControl FlowControl;
        [NonSerialized]
        public BaseModel TopRec;
        [NonSerialized]
        public BaseModel LeftRec;
        [NonSerialized]
        public BaseModel RightRec;
        [NonSerialized]
        public BaseModel BottomRec;
    }
    [Serializable]
    /// <summary>
    /// 小正方形
    /// </summary>
    public class BaseModel
    {
        public BaseModel()
        {

        }
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
    [Serializable]
    public enum BaseModelPos
    {
        Top,
        Right,
        Left,
        Bottom
    }

}
