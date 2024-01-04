using BorwinAnalyse.BaseClass;
using MvCamCtrl.NET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisionModel.UCControls
{
    public partial class CalibrationCCD : UserControl
    {
        SplicCamera camera;
        public CalibrationCCD()
        {
            InitializeComponent();
            this.components = new System.ComponentModel.Container();
            this.Load += CalibrationCCD_Load;
        }

        private void CalibrationCCD_Load(object sender, EventArgs e)
        {
            comSelectCamera.SelectedIndex = 0;
            UpdateLanguage();
        }

        public void UpdateLanguage()
        {
            LanguageManager.Instance.UpdateLanguage(this, this.components.Components);
        }

        private void btn采集图片_Click(object sender, EventArgs e)
        {
            camera.SigleTrigger();
        }
        private void CCD_GrabImage()
        {
            picImg.Image = camera.Img;
        }

        private void btn设置左边_Click(object sender, EventArgs e)
        {

        }

        private void btn设置右边_Click(object sender, EventArgs e)
        {

        }

        private void btn设置底边_Click(object sender, EventArgs e)
        {

        }

        private void btn显示裁剪区域_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 选择相机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comSelectCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (camera != null)
            {
                camera.CCD_GrabImage -= CCD_GrabImage;
            }
            if (comSelectCamera.SelectedIndex == 0)
            {
                camera = VisionModel.HIKVision.Instance.CameraL;
            }
            else
            {
                camera = VisionModel.HIKVision.Instance.CameraL;
            }
            camera.CCD_GrabImage += CCD_GrabImage;
        }
        public bool IsDown = false;
        public Point startPoint;//鼠标按下的点
        public Point endPoint;//鼠标抬起点
        public Rectangle currRect;//当前正在绘制的举行
        public int realStartX;
        public int minStartX;
        public int minStartY;
        public int maxEndX;
        public int maxEndY;
        public int realStartY;
        public int realEndX;
        public int realEndY;
        private void picImg_MouseDown(object sender, MouseEventArgs e)
        {
            IsDown = true;
            startPoint.X = e.X;
            startPoint.Y = e.Y;
            minStartX = e.X;
            minStartY = e.Y;
            maxEndX = e.X;
            maxEndY = e.Y;
        }

        private void picImg_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsDown)
            {
                endPoint.X = e.X;
                endPoint.Y = e.Y;
                realStartX = Math.Min(startPoint.X, endPoint.X);
                realStartY = Math.Min(startPoint.Y, endPoint.Y);
                realEndX = Math.Max(startPoint.X, endPoint.X);
                realEndY = Math.Max(startPoint.Y, endPoint.Y);
                minStartX = Math.Min(minStartX, realStartX);
                minStartY = Math.Min(minStartY, realStartY);
                maxEndX = Math.Max(maxEndX, realEndX);
                maxEndY = Math.Max(maxEndY, realEndY);

                currRect = new Rectangle(realStartX, realStartY, realEndX - realStartX, realEndY - realStartY);
                picImg.Refresh();
                Graphics gc = picImg.CreateGraphics();
                gc.DrawRectangle(new Pen(Color.Red, 1), currRect);
                string  Text = string.Format("X0:{0},Y0:{1},W:{2},H:{3},X1:{4},Y1:{5}", realStartX, realStartY, (realEndX - realStartX), (realEndY - realStartY), realEndX, realEndY);
                gc.DrawString(Text,this.Font,Brushes.Red,new Point(2,2));
            }
        }

        private void picImg_MouseUp(object sender, MouseEventArgs e)
        {
            IsDown = false;
        }
    }
}
