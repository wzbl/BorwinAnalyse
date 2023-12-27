using BorwinAnalyse.BaseClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        public FlowBaseControl StartFlow;

        private FlowBaseModel currentModel;

        public bool ConnectModel = false;

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
            if (currentModel== flowModel)
            {
                currentModel = null;
            }
            FlowModels.Remove(flowModel);
            Controls.Remove(flowModel);
        }

        private void UCFlowControl_MouseDown(object sender, MouseEventArgs e)
        {
            currentModel = null;
        }

        private void UCFlowControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (currentModel==null|| !currentModel.IsDown)
            {
                ConnectModel = false;
            }
            Refresh();
        }

        private void UCFlowControl_MouseUp(object sender, MouseEventArgs e)
        {
            Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            graphics = e.Graphics;

            if (currentModel!=null)
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
                    //new Point(StartFlow.FlowModel.Location.X-2, StartFlow.FlowModel.Location.Y-2),
                    //new Point(StartFlow.FlowModel.Location.X+2+StartFlow.FlowModel.Width, StartFlow.FlowModel.Location.Y-2),
                    //new Point(StartFlow.FlowModel.Location.X+2+StartFlow.FlowModel.Width, StartFlow.FlowModel.Location.Y+2+StartFlow.FlowModel.Height),
                    //new Point(StartFlow.FlowModel.Location.X-2, StartFlow.FlowModel.Location.Y+2+StartFlow.FlowModel.Height),
                    //new Point(StartFlow.FlowModel.Location.X-2, StartFlow.FlowModel.Location.Y-2)
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
                graphics.DrawLine(new Pen(Brushes.Red,2), point, StartPoin);
                DrawLines(point, moucePoint);

            }
           
            if (StartFlow != null&& StartFlow.outFlows.Count>0)
            {
                DrawModel(StartFlow);
            }
        }

        private void DrawModel(FlowBaseControl currentFlow)
        {
            Point startPoint = new Point(0, 0);
            Point endPoint = new Point(0, 0);
            FlowBaseControl flowBaseControl =null;
            if (currentFlow.InFlow.Count > 0)
            {
                foreach (KeyValuePair<FlowBaseControl, BaseModelPos> kv in currentFlow.InFlow)
                {
                    BaseModelPos pos = kv.Value;
                    switch (pos)
                    {
                        case BaseModelPos.Top:
                            startPoint = new Point(kv.Key.FlowModel.TopRec.point.X + kv.Key.FlowModel.Location.X, kv.Key.FlowModel.TopRec.point.Y + kv.Key.FlowModel.Location.Y);
                            break;
                        case BaseModelPos.Right:
                          Point  midP1 = new Point(kv.Key.FlowModel.RightRec.point.X + kv.Key.FlowModel.Location.X, kv.Key.FlowModel.RightRec.point.Y + kv.Key.FlowModel.Location.Y);
                            startPoint=new Point(midP1.X+12, midP1.Y);
                            graphics.DrawLine(new Pen(Brushes.Red,2), midP1, startPoint);
                            break;
                        case BaseModelPos.Left:
                            Point midP2 = new Point(kv.Key.FlowModel.LeftRec.point.X + kv.Key.FlowModel.Location.X, kv.Key.FlowModel.LeftRec.point.Y + kv.Key.FlowModel.Location.Y);
                            startPoint = new Point(midP2.X - 5, midP2.Y);
                            graphics.DrawLine(new Pen(Brushes.Red,2), midP2, startPoint);
                            break;
                        case BaseModelPos.Bottom:
                            startPoint = new Point(kv.Key.FlowModel.BottomRec.point.X + kv.Key.FlowModel.Location.X, kv.Key.FlowModel.BottomRec.point.Y + kv.Key.FlowModel.Location.Y);
                            break;
                        default:
                            break;
                    }
                }

                endPoint = new Point(currentFlow.FlowModel.TopRec.point.X + currentFlow.FlowModel.Location.X, currentFlow.FlowModel.TopRec.point.Y + currentFlow.FlowModel.Location.Y);
                DrawLines(startPoint, endPoint);
            }
            if (currentFlow.outFlows.Count>0)
            {
                foreach (KeyValuePair<FlowBaseControl, BaseModelPos> kv in currentFlow.outFlows)
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
            FlowModel.Instance.StartFlow = StartFlow;
            FlowModel.Instance.Save();
        }

        private void 打开模板ToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
