using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Emit;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace BorwinSplicMachine.FlowModel
{
    public partial class FlowBaseModel : UserControl
    {
        public  FlowBaseControl FlowControl;

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
            FlowControl.FlowModeControl.TopRec = new BaseModel(Width / 2, 0, BaseModelPos.Top);
            FlowControl.FlowModeControl.LeftRec = new BaseModel(0, Height / 2, BaseModelPos.Left);
            FlowControl.FlowModeControl.RightRec = new BaseModel(Width - 8, Height / 2, BaseModelPos.Right);
            FlowControl.FlowModeControl.BottomRec = new BaseModel(Width / 2, Height - 8, BaseModelPos.Bottom);
        }

        private void FlowBaseModel_MouseEnter(object sender, EventArgs e)
        {
            IsEnter = true;
            MouseEnterMove();
            if (Form1.MainControl.UCFlowControl.CurrentModel != this && Form1.MainControl.UCFlowControl.ConnectModel && FlowControl.InFlow.Count == 0)
            {
                if (Form1.MainControl.UCFlowControl.StartFlow==this)
                {
                    if (Form1.MainControl.UCFlowControl.CurrentModel.FlowControl.InFlow.Count!=0)
                    {
                        return;
                    }
                }
                if (Form1.MainControl.UCFlowControl.CurrentModel.FlowControl.InFlow.Count == 0)
                {
                    Form1.MainControl.UCFlowControl.StartFlow = Form1.MainControl.UCFlowControl.CurrentModel;
                }
                if (Form1.MainControl.UCFlowControl.CurrentModel.FlowControl.FlowModeControl.RightRec.IsEnter)
                {
                    FlowControl.InFlow.Add(new OutOrInFlow( Form1.MainControl.UCFlowControl.CurrentModel.FlowControl.FlowModeControl, Form1.MainControl.UCFlowControl.CurrentModel.FlowControl.FlowModeControl.RightRec.pos));
                }
                else if (Form1.MainControl.UCFlowControl.CurrentModel.FlowControl.FlowModeControl.LeftRec.IsEnter)
                {
                    FlowControl.InFlow.Add(new OutOrInFlow(Form1.MainControl.UCFlowControl.CurrentModel.FlowControl.FlowModeControl, Form1.MainControl.UCFlowControl.CurrentModel.FlowControl.FlowModeControl.LeftRec.pos));

                }
                else if (Form1.MainControl.UCFlowControl.CurrentModel.FlowControl.FlowModeControl.BottomRec.IsEnter)
                {
                    FlowControl.InFlow.Add(new OutOrInFlow(Form1.MainControl.UCFlowControl.CurrentModel.FlowControl.FlowModeControl, Form1.MainControl.UCFlowControl.CurrentModel.FlowControl.FlowModeControl.BottomRec.pos));
                }

                if (Form1.MainControl.UCFlowControl.CurrentModel.FlowControl.InFlow.Count == 0) Form1.MainControl.UCFlowControl.StartFlow = Form1.MainControl.UCFlowControl.CurrentModel;
                Form1.MainControl.UCFlowControl.CurrentModel.FlowControl.outFlows.Add(new OutOrInFlow(FlowControl.FlowModeControl, FlowControl.FlowModeControl.TopRec.pos));

                Form1.MainControl.UCFlowControl.ConnectModel = false;
            }

        }

        private void MouseEnterMove()
        {
            Point point1 = PointToClient(MousePosition);
            MouseEnterRec(point1, ref FlowControl.FlowModeControl.TopRec);
            MouseEnterRec(point1, ref FlowControl.FlowModeControl.LeftRec);
            MouseEnterRec(point1, ref FlowControl.FlowModeControl.RightRec);
            MouseEnterRec(point1, ref FlowControl.FlowModeControl.BottomRec);
            FlowControl.FlowModeControl.RightRec.point = new Point(Width - FlowControl.FlowModeControl.RightRec.recSize, Height / 2);
            FlowControl.FlowModeControl.BottomRec.point = new Point(Width / 2, Height - FlowControl.FlowModeControl.BottomRec.recSize);
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
            if (FlowControl.FlowModeControl.LeftRec.IsEnter || FlowControl.FlowModeControl.RightRec.IsEnter || FlowControl.FlowModeControl.BottomRec.IsEnter || FlowControl.FlowModeControl.TopRec.IsEnter)
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
                        FlowControl.FlowModeControl.Point = p;
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
            graphics.DrawString(FlowControl.FlowModeControl.ModelName.ToString(), this.Font, Brushes.Black, Width / 3, Height / 2);
            if (IsEnter)
            {
                graphics.FillRectangle(recBrush, FlowControl.FlowModeControl.LeftRec.point.X, FlowControl.FlowModeControl.LeftRec.point.Y, FlowControl.FlowModeControl.LeftRec.recSize, FlowControl.FlowModeControl.LeftRec.recSize);
                graphics.FillRectangle(recBrush, FlowControl.FlowModeControl.RightRec.point.X, FlowControl.FlowModeControl.RightRec.point.Y, FlowControl.FlowModeControl.RightRec.recSize, FlowControl.FlowModeControl.RightRec.recSize);
                graphics.FillRectangle(recBrush, FlowControl.FlowModeControl.TopRec.point.X, FlowControl.FlowModeControl.TopRec.point.Y, FlowControl.FlowModeControl.TopRec.recSize, FlowControl.FlowModeControl.TopRec.recSize);
                graphics.FillRectangle(recBrush, FlowControl.FlowModeControl.BottomRec.point.X, FlowControl.FlowModeControl.BottomRec.point.Y, FlowControl.FlowModeControl.BottomRec.recSize, FlowControl.FlowModeControl.BottomRec.recSize);
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
            if (FlowControl.InFlow.Count > 0)
            {
                 OutOrInFlow InFlow = null;
                foreach (var kv in FlowControl.InFlow)
                {
                    InFlow = kv;
                }

                FlowControl.InFlow.Remove(InFlow);

                OutOrInFlow outOrInFlow = null;
                foreach (var item in InFlow.FlowModeControl.FlowModel.FlowControl.outFlows)
                {
                    if (item.FlowModeControl.FlowModel== FlowControl.FlowModeControl.FlowModel)
                    {
                        outOrInFlow = item;
                    }
                }
                InFlow.FlowModeControl.FlowModel.FlowControl.outFlows.Remove(outOrInFlow);

                if (FlowControl.outFlows.Count > 0)
                {
                    Form1.MainControl.UCFlowControl.StartFlow = this;
                }
            }
        }

        private void 删除左节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FlowControl.outFlows.Count > 0)
            {
                OutOrInFlow outFlow = null;
                OutOrInFlow InFlow = null;
                foreach (var kv in FlowControl.outFlows)
                {
                    InFlow = kv.FlowModeControl.FlowModel.FlowControl.InFlow[0];
                    if (InFlow.baseModelPos == BaseModelPos.Left)
                    {
                        outFlow = kv;
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
                    outFlow.FlowModeControl.FlowModel.FlowControl.InFlow.Remove(InFlow);
                }
            }
        }

        private void 删除右节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FlowControl.outFlows.Count > 0)
            {
                OutOrInFlow outFlow = null;
                OutOrInFlow InFlow = null;
                foreach (var kv in FlowControl.outFlows)
                {
                    InFlow = kv.FlowModeControl.FlowModel.FlowControl.InFlow[0];
                    if (InFlow.baseModelPos == BaseModelPos.Right)
                    {
                        outFlow = kv;
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
                    outFlow.FlowModeControl.FlowModel.FlowControl.InFlow.Remove(InFlow);
                }
            }
        }

        private void 删除下节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FlowControl.outFlows.Count > 0)
            {
                OutOrInFlow outFlow = null;
                OutOrInFlow InFlow = null;
                foreach (var kv in FlowControl.outFlows)
                {
                    InFlow = kv.FlowModeControl.FlowModel.FlowControl.InFlow[0];
                    if (InFlow.baseModelPos == BaseModelPos.Bottom)
                    {
                        outFlow = kv;
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
                    outFlow.FlowModeControl.FlowModel.FlowControl.InFlow.Remove(InFlow);
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
        public ModelType ModelName = ModelType.None;

        public Point Point;

        [Newtonsoft.Json.JsonIgnore]
        [XmlIgnore]
        [NonSerialized]
        public FlowBaseModel FlowModel;

        public BaseModel TopRec;
      
        public BaseModel LeftRec;
       
        public BaseModel RightRec;
     
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

    [Serializable]
    public enum ModelType
    {
        None,
        条码,
        LCR
    }
}
