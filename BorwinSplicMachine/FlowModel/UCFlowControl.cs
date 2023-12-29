using BorwinAnalyse.BaseClass;
using BorwinAnalyse.DataBase.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
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
        ToolStripMenuItem Delete;
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
            LoadModel();
            Delete = new ToolStripMenuItem();
            Delete.Name = "删除流程";
            Delete.Size = new System.Drawing.Size(180, 22);
            Delete.Text = "删除流程";
            Delete.Click += Delete_Click;
        }

        /// <summary>
        /// 删除框选流程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_Click(object sender, EventArgs e)
        {
            List<FlowBaseModel> models = new List<FlowBaseModel>();
            int count = 0;
            foreach (KeyValuePair<FlowBaseModel, Point> flowModel in selectFlowModes.FlowBaseModels)
            {
                models.Add(flowModel.Key);
            }
            selectFlowModes.Clear();
            count = models.Count();
            for (int i = 0; i < count;)
            {
                models[i].DeleteUC();
                models.Remove(models[i]);
                count = models.Count();
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
                if (e.Button == MouseButtons.Left)
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
                else if (e.Button == MouseButtons.Right)
                {
                    selectFlowModes.IsLock = true;
                    controlPos = selectFlowModes.Point;
                    contextMenuStrip1.Items.Add(Delete);
                }
            }
            else
            {
                contextMenuStrip1.Items.Remove(Delete);
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
                if (selectFlowModes.Point.X + selectFlowModes.Width < Location.X + Width && selectFlowModes.Point.Y + selectFlowModes.Height < Location.Y + Height && selectFlowModes.Point.X > Location.X && selectFlowModes.Point.Y > Location.Y)
                {
                    selectFlowModes.Point = new Point(controlPos.X - (mouseStart.X - MousePosition.X), controlPos.Y - (mouseStart.Y - MousePosition.Y));
                    foreach (KeyValuePair<FlowBaseModel, Point> flowModel in selectFlowModes.FlowBaseModels)
                    {
                        flowModel.Key.Location = new Point(flowModel.Value.X - (mouseStart.X - MousePosition.X), flowModel.Value.Y - (mouseStart.Y - MousePosition.Y));
                        flowModel.Key.FlowControl.FlowModeControl.Point = flowModel.Key.Location;
                    }
                }
                else
                {
                    mouseStart = MousePosition;
                    int decX = 0;
                    int decY = 0;
                    if (selectFlowModes.Point.X + selectFlowModes.Width >= Location.X + Width)
                    {
                        decX = selectFlowModes.Point.X + selectFlowModes.Width - (Location.X + Width) + 4;
                    }
                    else if (selectFlowModes.Point.X <= Location.X)
                    {
                        decX = selectFlowModes.Point.X - Location.X - 4;
                    }
                    if (selectFlowModes.Point.Y + selectFlowModes.Height >= Location.Y + Height)
                    {
                        decY = selectFlowModes.Point.Y + selectFlowModes.Height - (Location.Y + Height) + 4;
                    }
                    else if (selectFlowModes.Point.Y <= Location.Y)
                    {
                        decY = selectFlowModes.Point.Y - Location.Y - 4;
                    }
                    selectFlowModes.Point = new Point(selectFlowModes.Point.X - decX, selectFlowModes.Point.Y - decY);
                    foreach (KeyValuePair<FlowBaseModel, Point> flowModel in selectFlowModes.FlowBaseModels)
                    {
                        flowModel.Key.Location = new Point(flowModel.Key.Location.X - decX, flowModel.Key.Location.Y - decY);
                        flowModel.Key.FlowControl.FlowModeControl.Point = flowModel.Key.Location;
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
                if (currentModel.FlowControl.FlowModeControl.RightRec.IsEnter)
                {
                    StartPoin = new Point(currentModel.FlowControl.FlowModeControl.RightRec.point.X + currentModel.Location.X + currentModel.FlowControl.FlowModeControl.RightRec.recSize, currentModel.FlowControl.FlowModeControl.RightRec.point.Y + currentModel.Location.Y + currentModel.FlowControl.FlowModeControl.RightRec.recSize / 2);
                    point = new Point(StartPoin.X + 6, StartPoin.Y);
                }
                else if (currentModel.FlowControl.FlowModeControl.LeftRec.IsEnter)
                {
                    StartPoin = new Point(currentModel.FlowControl.FlowModeControl.LeftRec.point.X + currentModel.Location.X, currentModel.FlowControl.FlowModeControl.LeftRec.point.Y + currentModel.Location.Y + currentModel.FlowControl.FlowModeControl.LeftRec.recSize / 2);
                    point = new Point(StartPoin.X - 6, StartPoin.Y);

                }
                else if (currentModel.FlowControl.FlowModeControl.BottomRec.IsEnter)
                {
                    StartPoin = new Point(currentModel.FlowControl.FlowModeControl.BottomRec.point.X + currentModel.Location.X + currentModel.FlowControl.FlowModeControl.BottomRec.recSize / 2, currentModel.FlowControl.FlowModeControl.BottomRec.point.Y + currentModel.Location.Y + currentModel.FlowControl.FlowModeControl.BottomRec.recSize);
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
                if (FlowModels[i].FlowControl.outFlows.Count > 0 && FlowModels[i].FlowControl.InFlow.Count == 0)
                {
                    if (StartFlow == null)
                        StartFlow = FlowModels[i];
                    DrawModel(FlowModels[i].FlowControl.FlowModeControl);
                }
            }

            if (!selectFlowModes.IsLock && isDown)
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
            if (currentFlow.FlowModel.FlowControl.InFlow.Count > 0)
            {
                foreach (var kv in currentFlow.FlowModel.FlowControl.InFlow)
                {
                    BaseModelPos pos = kv.baseModelPos;
                    flowBaseControl = kv.FlowModeControl;
                    switch (pos)
                    {
                        case BaseModelPos.Top:
                            startPoint = new Point(flowBaseControl.TopRec.point.X + flowBaseControl.FlowModel.Location.X, flowBaseControl.TopRec.point.Y + flowBaseControl.FlowModel.Location.Y);
                            break;
                        case BaseModelPos.Right:
                            Point midP1 = new Point(flowBaseControl.RightRec.point.X + flowBaseControl.FlowModel.Location.X, flowBaseControl.RightRec.point.Y + flowBaseControl.FlowModel.Location.Y);
                            startPoint = new Point(midP1.X + 12, midP1.Y);
                            graphics.DrawLine(new Pen(Brushes.Red, 2), midP1, startPoint);
                            break;
                        case BaseModelPos.Left:
                            Point midP2 = new Point(flowBaseControl.LeftRec.point.X + flowBaseControl.FlowModel.Location.X, flowBaseControl.LeftRec.point.Y + flowBaseControl.FlowModel.Location.Y);
                            startPoint = new Point(midP2.X - 5, midP2.Y);
                            graphics.DrawLine(new Pen(Brushes.Red, 2), midP2, startPoint);
                            break;
                        case BaseModelPos.Bottom:
                            startPoint = new Point(flowBaseControl.BottomRec.point.X + flowBaseControl.FlowModel.Location.X, flowBaseControl.BottomRec.point.Y + flowBaseControl.FlowModel.Location.Y);
                            break;
                        default:
                            break;
                    }
                }

                endPoint = new Point(currentFlow.TopRec.point.X + currentFlow.FlowModel.Location.X, currentFlow.TopRec.point.Y + currentFlow.FlowModel.Location.Y);
                DrawLines(startPoint, endPoint);
            }
            if (currentFlow.FlowModel.FlowControl.outFlows.Count > 0)
            {
                foreach (var kv in currentFlow.FlowModel.FlowControl.outFlows)
                {
                    flowBaseControl = kv.FlowModeControl;
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
            for (int i = 0; i < FlowModels.Count; i++)
            {
                FlowModel.Instance.FlowModels.Add(FlowModels[i].FlowControl);
            }
            FlowModel.Instance.Save();
        }

        private void 打开模板ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadModel();
        }

        public void LoadModel()
        {
            FlowModel.Instance.Load();
            FlowModels.Clear();
            Controls.Clear();

            //添加Model
            for (int i = 0; i < FlowModel.Instance.FlowModels.Count; i++)
            {
                switch (FlowModel.Instance.FlowModels[i].FlowModeControl.ModelName)
                {
                    case ModelType.条码:
                        FlowBarCodeModel flowBarCodeModel = new FlowBarCodeModel();
                        flowBarCodeModel.Location = FlowModel.Instance.FlowModels[i].FlowModeControl.Point;
                        FlowModel.Instance.FlowModels[i].FlowModeControl.FlowModel = flowBarCodeModel;
                        break;
                    case ModelType.LCR:
                        FlowLCRModel flowLCRModel = new FlowLCRModel();
                        flowLCRModel.Location = FlowModel.Instance.FlowModels[i].FlowModeControl.Point;
                        FlowModel.Instance.FlowModels[i].FlowModeControl.FlowModel = flowLCRModel;
                        break;
                    default:
                        break;
                }
            }

            //添加InOrOutFlow
            for (int i = 0; i < FlowModel.Instance.FlowModels.Count; i++)
            {
                if (FlowModel.Instance.FlowModels[i].InFlow.Count > 0)
                {
                    foreach (var item in FlowModel.Instance.FlowModels[i].InFlow)
                    {
                        List<FlowBaseControl> flowBaseControls = FlowModel.Instance.FlowModels.Where(x => x.FlowModeControl.Point == item.FlowModeControl.Point).ToList();
                        item.FlowModeControl.FlowModel = flowBaseControls[0].FlowModeControl.FlowModel;
                    }
                }

                if (FlowModel.Instance.FlowModels[i].outFlows.Count > 0)
                {
                    foreach (var item in FlowModel.Instance.FlowModels[i].outFlows)
                    {
                        List<FlowBaseControl> flowBaseControls = FlowModel.Instance.FlowModels.Where(x => x.FlowModeControl.Point == item.FlowModeControl.Point).ToList();
                        item.FlowModeControl.FlowModel = flowBaseControls[0].FlowModeControl.FlowModel;
                    }
                }
                FlowModel.Instance.FlowModels[i].FlowModeControl.FlowModel.FlowControl = FlowModel.Instance.FlowModels[i];
            }

            for (int i = 0; i < FlowModel.Instance.FlowModels.Count; i++)
            {
                AddFlowControl(FlowModel.Instance.FlowModels[i].FlowModeControl.FlowModel);
                if (FlowModel.Instance.FlowModels[i].InFlow.Count == 0 && FlowModel.Instance.FlowModels[i].outFlows.Count > 0)
                {
                    StartFlow = FlowModel.Instance.FlowModels[i].FlowModeControl.FlowModel;
                }
            }

        }

        private void 运行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Run();
        }

        public void Run()
        {
            if (StartFlow != null)
            {
                StartFlow.FlowControl.Run();
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
            if (File.Exists(savePath))
            {
                instance = SerializeHelper.DeserializeXml<FlowModel>(savePath);
            }
        }
        public void Save()
        {
            string savePath = @"SqlLiteData/FlowModel.xml";
            SerializeHelper.SerializeXml(savePath, this);
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
                    MessageBox.Show("保存成功");
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
