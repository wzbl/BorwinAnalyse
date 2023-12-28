using BorwinAnalyse.BaseClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Windows.Forms;
using System.Xml.Serialization;

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
            this.Load += UCFlowControl_Load;
        }

        private void UCFlowControl_Load(object sender, EventArgs e)
        {
            FlowModel.Instance.Load();
            for (int i = 0;i < FlowModel.Instance.FlowModels.Count; i++)
            {

            }
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
        Point controlPos = new Point();
        private void UCFlowControl_MouseDown(object sender, MouseEventArgs e)
        {
            currentModel = null;
            isDown = true;
            mouseStart = MousePosition;
            if (selectFlowModes.IsSelectFlowModes)
            {
                if (selectFlowModes.CheckMousePos(PointToClient(MousePosition)))
                {
                    selectFlowModes.Clear();
                }
                else
                {
                    selectFlowModes.IsLock = true;
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

            if (isDown && selectFlowModes.IsSelectFlowModes && !selectFlowModes.CheckMousePos(PointToClient(MousePosition)))
            {
                if (selectFlowModes.Point.X + selectFlowModes.Width < Location.X + Width && selectFlowModes.Point.Y + selectFlowModes.Height < Location.Y + Height&& selectFlowModes.Point.X> Location.X&& selectFlowModes.Point.Y> Location.Y)
                {
                    selectFlowModes.Point = new Point(controlPos.X - (mouseStart.X - MousePosition.X), controlPos.Y - (mouseStart.Y - MousePosition.Y));
                    foreach (KeyValuePair<FlowBaseModel, Point> flowModel in selectFlowModes.FlowBaseModels)
                    {
                        flowModel.Key.Location = new Point(flowModel.Value.X - (mouseStart.X - MousePosition.X), flowModel.Value.Y - (mouseStart.Y - MousePosition.Y));
                        flowModel.Key.FlowModeControl.Point = flowModel.Key.Location;
                    }
                }
                else
                {
                    mouseStart= MousePosition;
                    int decX = 0;
                    int decY = 0;
                    if (selectFlowModes.Point.X + selectFlowModes.Width >= Location.X + Width)
                    {
                        decX = selectFlowModes.Point.X + selectFlowModes.Width-(Location.X + Width)+4;
                    }else if (selectFlowModes.Point.X <= Location.X)
                    {
                        decX = selectFlowModes.Point.X - Location.X-4;
                    }
                    if (selectFlowModes.Point.Y + selectFlowModes.Height >= Location.Y + Height)
                    {
                        decY = selectFlowModes.Point.Y + selectFlowModes.Height - (Location.Y + Height) + 4;
                    }
                    else if (selectFlowModes.Point.Y <= Location.Y)
                    {
                        decY = selectFlowModes.Point.Y - Location.Y - 4;
                    }
                    selectFlowModes.Point = new Point(selectFlowModes.Point.X-decX, selectFlowModes.Point.Y-decY);
                    foreach (KeyValuePair<FlowBaseModel, Point> flowModel in selectFlowModes.FlowBaseModels)
                    {
                        flowModel.Key.Location = new Point(flowModel.Key.Location.X-decX, flowModel.Key.Location.Y-decY);
                        flowModel.Key.FlowModeControl.Point = flowModel.Key.Location;
                    }
                }
            }

            Refresh();
        }

        private void UCFlowControl_MouseUp(object sender, MouseEventArgs e)
        {
            Refresh();
            if (selectFlowModes.FlowBaseModels.Count > 0)
            {
                selectFlowModes.IsLock = false;
                selectFlowModes.IsSelectFlowModes = true;
            }
            if (isDown && selectFlowModes.IsSelectFlowModes)
            {
                List<FlowBaseModel> flowModels = new List<FlowBaseModel>();
                foreach (var item in selectFlowModes.FlowBaseModels)
                {
                    flowModels.Add(item.Key);
                }

                foreach (FlowBaseModel flowModel in flowModels)
                {
                    selectFlowModes.FlowBaseModels[flowModel] = flowModel.Location;
                }
            }
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
                if (currentModel.FlowModeControl.RightRec.IsEnter)
                {
                    StartPoin = new Point(currentModel.FlowModeControl.RightRec.point.X + currentModel.Location.X + currentModel.FlowModeControl.RightRec.recSize, currentModel.FlowModeControl.RightRec.point.Y + currentModel.Location.Y + currentModel.FlowModeControl.RightRec.recSize / 2);
                    point = new Point(StartPoin.X + 6, StartPoin.Y);
                }
                else if (currentModel.FlowModeControl.LeftRec.IsEnter)
                {
                    StartPoin = new Point(currentModel.FlowModeControl.LeftRec.point.X + currentModel.Location.X, currentModel.FlowModeControl.LeftRec.point.Y + currentModel.Location.Y + currentModel.FlowModeControl.LeftRec.recSize / 2);
                    point = new Point(StartPoin.X - 6, StartPoin.Y);

                }
                else if (currentModel.FlowModeControl.BottomRec.IsEnter)
                {
                    StartPoin = new Point(currentModel.FlowModeControl.BottomRec.point.X + currentModel.Location.X + currentModel.FlowModeControl.BottomRec.recSize / 2, currentModel.FlowModeControl.BottomRec.point.Y + currentModel.Location.Y + currentModel.FlowModeControl.BottomRec.recSize);
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

            //if (StartFlow != null && StartFlow.FlowControl.outFlows.Count > 0)
            //{
            //    DrawModel(StartFlow);
            //}

            for (int i = 0; i < FlowModels.Count; i++)
            {
                if (FlowModels[i].FlowModeControl.FlowControl.outFlows.Count > 0 && FlowModels[i].FlowModeControl.FlowControl.InFlow.Count == 0)
                {
                    if (StartFlow == null)
                        StartFlow = FlowModels[i];
                    DrawModel(FlowModels[i].FlowModeControl);
                }
            }

            if (!selectFlowModes.IsLock&&isDown)
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

        private void DrawModel(FlowModeControl currentFlow)
        {
            Point startPoint = new Point(0, 0);
            Point endPoint = new Point(0, 0);
            FlowModeControl flowBaseControl = null;
            if (currentFlow.FlowControl.InFlow.Count > 0)
            {
                foreach (KeyValuePair< FlowModeControl, BaseModelPos > kv in currentFlow.FlowControl.InFlow)
                {
                    BaseModelPos pos = kv.Value;
                    switch (pos)
                    {
                        case BaseModelPos.Top:
                            startPoint = new Point(kv.Key.TopRec.point.X + kv.Key.Point.X, kv.Key.TopRec.point.Y + kv.Key.Point.Y);
                            break;
                        case BaseModelPos.Right:
                            Point midP1 = new Point(kv.Key.RightRec.point.X + kv.Key.Point.X, kv.Key.RightRec.point.Y + kv.Key.Point.Y);
                            startPoint = new Point(midP1.X + 12, midP1.Y);
                            graphics.DrawLine(new Pen(Brushes.Red, 2), midP1, startPoint);
                            break;
                        case BaseModelPos.Left:
                            Point midP2 = new Point(kv.Key.LeftRec.point.X + kv.Key.Point.X, kv.Key.LeftRec.point.Y + kv.Key.Point.Y);
                            startPoint = new Point(midP2.X - 5, midP2.Y);
                            graphics.DrawLine(new Pen(Brushes.Red, 2), midP2, startPoint);
                            break;
                        case BaseModelPos.Bottom:
                            startPoint = new Point(kv.Key.BottomRec.point.X + kv.Key.Point.X, kv.Key.BottomRec.point.Y + kv.Key.Point.Y);
                            break;
                        default:
                            break;
                    }
                }

                endPoint = new Point(currentFlow.TopRec.point.X + currentFlow.Point.X, currentFlow.TopRec.point.Y + currentFlow.Point.Y);
                DrawLines(startPoint, endPoint);
            }
            if (currentFlow.FlowControl.outFlows.Count > 0)
            {
                foreach (KeyValuePair< FlowModeControl, BaseModelPos > kv in currentFlow.FlowControl.outFlows)
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
            FlowModel.Instance.FlowModels.Clear();
            for (int i = 0;i< FlowModels.Count; i++)
            {
                FlowModel.Instance.FlowModels.Add(FlowModels[i].FlowModeControl.FlowControl);
            }
            FlowModel.Instance.Save();
        }

        private void 打开模板ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FlowModel.Instance.Load();
            for (int i = 0; i < FlowModel.Instance.FlowModels.Count; i++)
            {

            }
        }

    }

    public class SelectFlowModes
    {
        public bool IsLock = false;
        public bool IsSelectFlowModes = false;
        public int Width = 0;
        public int Height = 0;
        public Point Point = new Point(0, 0);

        public Dictionary<FlowBaseModel, Point> FlowBaseModels = new Dictionary<FlowBaseModel, Point>();

        public bool CheckMousePos(Point p)
        {
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
                    if (!FlowBaseModels.ContainsKey(Form1.MainControl.UCFlowControl.FlowModels[i]))
                    {
                        Point point = Form1.MainControl.UCFlowControl.FlowModels[i].Location;
                        FlowBaseModels.Add(Form1.MainControl.UCFlowControl.FlowModels[i], point);
                        //Form1.MainControl.UCFlowControl.FlowModels[i].MouseDown -= Form1.MainControl.UCFlowControl.FlowModels[i].FlowBaseModel_MouseDown;
                        Form1.MainControl.UCFlowControl.FlowModels[i].MouseMove -= Form1.MainControl.UCFlowControl.FlowModels[i].FlowBaseModel_MouseMove;
                    }
                }
                else
                {
                    if (FlowBaseModels.ContainsKey(Form1.MainControl.UCFlowControl.FlowModels[i]))
                    {
                        //Form1.MainControl.UCFlowControl.FlowModels[i].MouseDown += Form1.MainControl.UCFlowControl.FlowModels[i].FlowBaseModel_MouseDown;
                        Form1.MainControl.UCFlowControl.FlowModels[i].MouseMove += Form1.MainControl.UCFlowControl.FlowModels[i].FlowBaseModel_MouseMove;
                        FlowBaseModels.Remove(Form1.MainControl.UCFlowControl.FlowModels[i]);
                    }

                }
            }
        }

        public void Clear()
        {
            foreach (var item in FlowBaseModels)
            {
                //item.Key.MouseDown += item.Key.FlowBaseModel_MouseDown;
                item.Key.MouseMove += item.Key.FlowBaseModel_MouseMove;
            }
            FlowBaseModels.Clear();
            IsSelectFlowModes = false;
            IsLock = false;
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
        public List<FlowBaseControl> FlowModels = new List<FlowBaseControl>();

        public void Load()
        {
            string savePath = @"SqlLiteData/FlowModel.xml";
            instance= SerializeHelper.DeserializeXml<FlowModel>(savePath);
        }
        public void Save()
        {
            string savePath = @"SqlLiteData/FlowModel.xml";
            SerializeHelper.SerializeXml(savePath,this);
        }
    }

    public class SerializeHelper
    {
        public static bool SerializeXml(string path, object obj)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    XmlSerializer serializer = new XmlSerializer(obj.GetType());
                    serializer.Serialize(fs, obj);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("序列化错误：" + ex.Message, "错误");
                return false;
            }
        }
        public static T DeserializeXml<T>(string path) where T : class
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    object obj = serializer.Deserialize(fs);
                    return obj as T;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("反序列化错误：" + ex.Message, "错误");
                return null;
            }
        }
    }
}
