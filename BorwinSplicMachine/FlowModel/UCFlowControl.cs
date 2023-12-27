using BorwinAnalyse.BaseClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Security.Permissions;
using System.Windows.Forms;

namespace BorwinSplicMachine.FlowModel
{
    public partial class UCFlowControl : UserControl
    {
        Graphics graphics;

        /// <summary>
        /// 添加控件
        /// </summary>
        public List<FlowBaseModel> FlowModels = new List<FlowBaseModel>();

        /// <summary>
        /// 开始流程
        /// </summary>
        public FlowBaseModel StartFlow;

        private FlowBaseModel currentModel;

        public bool ConnectModel = false;

        private SelectFlowModes selectFlowModes = new SelectFlowModes();

        /// <summary>
        /// 当前选中流程控件
        /// </summary>
        public FlowBaseModel CurrentModel
        {
            get
            {
                return currentModel;
            }
            set
            {
                currentModel = value;
                currentModel.MouseMove += UCFlowControl_MouseMove;
                currentModel.MouseUp += UCFlowControl_MouseUp;
            }
        }
        public UCFlowControl()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        public void AddFlowControl(FlowBaseModel flowModel)
        {
            FlowModels.Add(flowModel);
            Controls.Add(flowModel);
        }

        public void DeleteFlowControl(FlowBaseModel flowModel)
        {
            if (currentModel == flowModel)
            {
                currentModel = null;
            }
            FlowModels.Remove(flowModel);
            Controls.Remove(flowModel);
        }

        bool isDown = false;
        Point  controlPos = new Point();
        private void UCFlowControl_MouseDown(object sender, MouseEventArgs e)
        {
            currentModel = null;
            isDown = true;
            mouseStart = MousePosition;
            if (selectFlowModes.IsSelectFlowModes)
            {
                if (selectFlowModes.CheckMousePos(PointToClient(mouseStart)))
                {
                    selectFlowModes.Clear();
                }
                else
                {
                    controlPos = selectFlowModes.Point;
                }
            }
        }
        Point mouseStart = new Point(0, 0);
        private void UCFlowControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (currentModel == null || !currentModel.IsDown)
            {
                ConnectModel = false;
            }

            if (isDown && !selectFlowModes.CheckMousePos(PointToClient(mouseStart)))
            {
                selectFlowModes.Point = new Point(controlPos.X - (mouseStart.X - MousePosition.X), controlPos.Y - (mouseStart.Y - MousePosition.Y));
                for (int i = 0; i < selectFlowModes.FlowBaseModels.Count; i++)
                {
                    Point p = selectFlowModes.FlowBaseModels[i].Location;
                    selectFlowModes.FlowBaseModels[i].Location= new Point(p.X - (mouseStart.X - MousePosition.X), p.Y - (mouseStart.Y - MousePosition.Y));
                }
            }

            Refresh();
        }

        private void UCFlowControl_MouseUp(object sender, MouseEventArgs e)
        {
            Refresh();
            isDown = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            graphics = e.Graphics;

            if (currentModel != null)
            {
                Point[] points =
                {
                    new Point(currentModel.Location.X-2, currentModel.Location.Y-2),
                    new Point(currentModel.Location.X+2+currentModel.Width, currentModel.Location.Y-2),
                    new Point(currentModel.Location.X+2+currentModel.Width, currentModel.Location.Y+2+currentModel.Height),
                    new Point(currentModel.Location.X-2, currentModel.Location.Y+2+currentModel.Height),
                    new Point(currentModel.Location.X-2, currentModel.Location.Y-2)
                };
                graphics.DrawLines(Pens.DarkOrange, points);
            }

            if (StartFlow != null)
            {
                Point[] points =
                {
                    new Point(StartFlow.Location.X-2, StartFlow.Location.Y-2),
                    new Point(StartFlow.Location.X+2+StartFlow.Width, StartFlow.Location.Y-2),
                    new Point(StartFlow.Location.X+2+StartFlow.Width, StartFlow.Location.Y+2+StartFlow.Height),
                    new Point(StartFlow.Location.X-2, StartFlow.Location.Y+2+StartFlow.Height),
                    new Point(StartFlow.Location.X-2, StartFlow.Location.Y-2)
                };
                graphics.DrawLines(Pens.GreenYellow, points);
            }

            if (currentModel != null && !currentModel.IsCanMove)
            {
                Point moucePoint = PointToClient(MousePosition);
                Point StartPoin = new Point(0, 0);
                Point point = new Point(0, 0);
                if (currentModel.RightRec.IsEnter)
                {
                    StartPoin = new Point(currentModel.RightRec.point.X + currentModel.Location.X + currentModel.RightRec.recSize, currentModel.RightRec.point.Y + currentModel.Location.Y + currentModel.RightRec.recSize / 2);
                    point = new Point(StartPoin.X + 6, StartPoin.Y);
                }
                else if (currentModel.LeftRec.IsEnter)
                {
                    StartPoin = new Point(currentModel.LeftRec.point.X + currentModel.Location.X, currentModel.LeftRec.point.Y + currentModel.Location.Y + currentModel.LeftRec.recSize / 2);
                    point = new Point(StartPoin.X - 6, StartPoin.Y);

                }
                else if (currentModel.BottomRec.IsEnter)
                {
                    StartPoin = new Point(currentModel.BottomRec.point.X + currentModel.Location.X + currentModel.BottomRec.recSize / 2, currentModel.BottomRec.point.Y + currentModel.Location.Y + currentModel.BottomRec.recSize);
                    point = new Point(StartPoin.X, StartPoin.Y + 6);
                }
                else
                {
                    ConnectModel = false;
                    return;
                }
                ConnectModel = true;
                graphics.DrawLine(new Pen(Brushes.Red, 2), point, StartPoin);
                DrawLines(point, moucePoint);

            }

            if (StartFlow != null && StartFlow.FlowControl.outFlows.Count > 0)
            {
                DrawModel(StartFlow);
            }

            if (isDown && selectFlowModes.CheckMousePos(PointToClient(MousePosition)))
            {
                Point p1 = PointToClient(mouseStart);
                Point p2 = PointToClient(MousePosition);
                Point p = new Point(0, 0);
                if (p1.X > p2.X && p1.Y > p2.Y)
                {
                    p = p2;
                }
                if (p1.X < p2.X && p1.Y < p2.Y)
                {
                    p = p1;
                }
                if (p1.X < p2.X && p1.Y > p2.Y)
                {
                    p = new Point(p1.X, p2.Y);
                }
                if (p1.X > p2.X && p1.Y < p2.Y)
                {
                    p = new Point(p2.X, p1.Y);
                }
                int width = Math.Abs(mouseStart.X - MousePosition.X);
                int height = Math.Abs(mouseStart.Y - MousePosition.Y);
                graphics.DrawRectangle(new Pen(Brushes.Yellow), p.X, p.Y, width, height);
                selectFlowModes.Width = width; selectFlowModes.Height = height;
                selectFlowModes.Point = p;
                selectFlowModes.IsSelectFlowModes = true;
                selectFlowModes.CheckFlowModel();
            }
            else
            {
                if (selectFlowModes.IsSelectFlowModes)
                {
                    graphics.DrawRectangle(new Pen(Brushes.Yellow), selectFlowModes.Point.X, selectFlowModes.Point.Y, selectFlowModes.Width, selectFlowModes.Height);
                }
            }
        }

        private void DrawModel(FlowBaseModel currentFlow)
        {
            Point startPoint = new Point(0, 0);
            Point endPoint = new Point(0, 0);
            FlowBaseModel flowBaseControl = null;
            if (currentFlow.FlowControl.InFlow.Count > 0)
            {
                foreach (KeyValuePair<FlowBaseModel, BaseModelPos> kv in currentFlow.FlowControl.InFlow)
                {
                    BaseModelPos pos = kv.Value;
                    switch (pos)
                    {
                        case BaseModelPos.Top:
                            startPoint = new Point(kv.Key.TopRec.point.X + kv.Key.Location.X, kv.Key.TopRec.point.Y + kv.Key.Location.Y);
                            break;
                        case BaseModelPos.Right:
                            Point midP1 = new Point(kv.Key.RightRec.point.X + kv.Key.Location.X, kv.Key.RightRec.point.Y + kv.Key.Location.Y);
                            startPoint = new Point(midP1.X + 12, midP1.Y);
                            graphics.DrawLine(new Pen(Brushes.Red, 2), midP1, startPoint);
                            break;
                        case BaseModelPos.Left:
                            Point midP2 = new Point(kv.Key.LeftRec.point.X + kv.Key.Location.X, kv.Key.LeftRec.point.Y + kv.Key.Location.Y);
                            startPoint = new Point(midP2.X - 5, midP2.Y);
                            graphics.DrawLine(new Pen(Brushes.Red, 2), midP2, startPoint);
                            break;
                        case BaseModelPos.Bottom:
                            startPoint = new Point(kv.Key.BottomRec.point.X + kv.Key.Location.X, kv.Key.BottomRec.point.Y + kv.Key.Location.Y);
                            break;
                        default:
                            break;
                    }
                }

                endPoint = new Point(currentFlow.TopRec.point.X + currentFlow.Location.X, currentFlow.TopRec.point.Y + currentFlow.Location.Y);
                DrawLines(startPoint, endPoint);
            }
            if (currentFlow.FlowControl.outFlows.Count > 0)
            {
                foreach (KeyValuePair<FlowBaseModel, BaseModelPos> kv in currentFlow.FlowControl.outFlows)
                {
                    flowBaseControl = kv.Key;
                    DrawModel(flowBaseControl);
                }
            }
        }

        private void DrawLines(Point startPoint, Point moucePoint)
        {
            if (startPoint.X == moucePoint.X || startPoint.Y == moucePoint.Y)
            {
                graphics.DrawLine(new Pen(Brushes.Red, 2), moucePoint, startPoint);
            }
            else
            {
                Point midPoint1 = new Point(startPoint.X, moucePoint.Y - 10);

                if (startPoint.Y > moucePoint.Y)
                {
                    midPoint1 = new Point(startPoint.X, moucePoint.Y + 10);
                }
                else
                {
                    midPoint1 = new Point(startPoint.X, moucePoint.Y - 10);
                }
                Point midPoint2 = new Point(moucePoint.X, midPoint1.Y);
                graphics.DrawLine(new Pen(Brushes.Red, 2), startPoint, midPoint1);
                graphics.DrawLine(new Pen(Brushes.Red, 2), midPoint1, midPoint2);
                graphics.DrawLine(new Pen(Brushes.Red, 2), moucePoint, midPoint2);


            }
            if (startPoint.Y == moucePoint.Y)
            {
                graphics.DrawLine(new Pen(Brushes.Red, 2), moucePoint, new Point(moucePoint.X + 5, moucePoint.Y - 8));
                graphics.DrawLine(new Pen(Brushes.Red, 2), moucePoint, new Point(moucePoint.X - 5, moucePoint.Y - 8));
            }
            else
            {
                graphics.DrawLine(new Pen(Brushes.Red, 2), moucePoint, new Point(moucePoint.X + 5, moucePoint.Y - 8));
                graphics.DrawLine(new Pen(Brushes.Red, 2), moucePoint, new Point(moucePoint.X - 5, moucePoint.Y - 8));
            }
        }


        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void 保存模板ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FlowModel.Instance.FlowModels = FlowModels;
            FlowModel.Instance.StartFlow = StartFlow.FlowControl;
            FlowModel.Instance.Save();
        }

        private void 打开模板ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }

    public class SelectFlowModes
    {
        public bool IsSelectFlowModes = false;
        public int Width = 0;
        public int Height = 0;
        public Point Point = new Point(0, 0);

        public List<FlowBaseModel> FlowBaseModels = new List<FlowBaseModel>();

        public bool CheckMousePos(Point p)
        {
            if (!IsSelectFlowModes)
            {
                return true;
            }

            if (p.X > Point.X && p.X < Point.X + Width && p.Y > Point.Y && p.Y < Point.Y + Height)
            {
                return false;
            }

            return true;
        }

        public void CheckFlowModel()
        {
            for (int i = 0; i < Form1.MainControl.UCFlowControl.FlowModels.Count; i++)
            {
                int width = Form1.MainControl.UCFlowControl.FlowModels[i].Width;
                int height = Form1.MainControl.UCFlowControl.FlowModels[i].Height;
                Point p1 = Form1.MainControl.UCFlowControl.FlowModels[i].Location;
                Point p2 = new Point(p1.X + width, p1.Y);
                Point p3 = new Point(p1.X + width, p1.Y + height);
                Point p4 = new Point(p1.X, p1.Y + height);
                if (!CheckMousePos(p1) && !CheckMousePos(p2) && !CheckMousePos(p3) && !CheckMousePos(p4))
                {
                    if (!FlowBaseModels.Contains(Form1.MainControl.UCFlowControl.FlowModels[i]))
                        FlowBaseModels.Add(Form1.MainControl.UCFlowControl.FlowModels[i]);
                }
                else
                {
                    if (FlowBaseModels.Contains(Form1.MainControl.UCFlowControl.FlowModels[i]))
                        FlowBaseModels.Remove(Form1.MainControl.UCFlowControl.FlowModels[i]);
                }
            }
        }

        public void Clear()
        {
            FlowBaseModels.Clear();
            IsSelectFlowModes = false;
        }
    }

    public class FlowModel
    {
        private static FlowModel instance;
        public static FlowModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FlowModel();
                }
                return instance;
            }
        }

        /// <summary>
        /// 添加控件
        /// </summary>
        public List<FlowBaseModel> FlowModels = new List<FlowBaseModel>();

        /// <summary>
        /// 开始流程
        /// </summary>
        public FlowBaseControl StartFlow;

        public void Load()
        {
            string savePath = @"SqlLiteData/FlowModel.json";
            if (!File.Exists(savePath))
            {
                FileStream fs1 = new FileStream(savePath, FileMode.Create, FileAccess.ReadWrite);
                fs1.Close();
            }
            else
            {
                instance = JsonConvert.DeserializeObject<FlowModel>(File.ReadAllText(savePath));
            }
        }
        public void Save()
        {
            string savePath = @"SqlLiteData/FlowModel.json";
            if (!File.Exists(savePath))
            {
                FileStream fs1 = new FileStream(savePath, FileMode.Create, FileAccess.ReadWrite);
                fs1.Close();
            }
            File.WriteAllText(savePath, JsonConvert.SerializeObject(instance));
        }
    }
}
