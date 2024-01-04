using BorwinAnalyse.BaseClass;
using BorwinAnalyse.DataBase.Model;
using MvCamCtrl.NET;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using static VisionModel.HIKVision;

namespace VisionModel
{
    public class SplicCamera : MyCamera
    {
        public string Name = "";
        public cbExceptiondelegate CallBackFunc;
        public cbOutputExdelegate ImageCallback;
        public delegate void GrabImage();
        public GrabImage CCD_GrabImage = null;
        public Bitmap Img;
        /// <summary>
        /// 找空料完成
        /// </summary>
        public static bool IsFindEmptyStrips = false;
        public static bool IsMatch = false;
        public bool MatchResult = false;
        public SplicCamera(string Name)
        {
            this.Name = Name;
        }

        /// <summary>
        /// 创建相机
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="stDevInfo"></param>
        /// <param name="index"></param>
        public void CreatCamera(ref MyCamera.MV_CC_DEVICE_INFO stDevInfo)
        {
            int nRet = this.MV_CC_CreateDevice_NET(ref stDevInfo);
            if (MyCamera.MV_OK != nRet)
            {
                Log("创建相机失败");
                return;
            }
            // ch:打开设备 | en:Open device
            nRet = this.MV_CC_OpenDevice_NET();
            if (MyCamera.MV_OK != nRet)
            {
                Log("相机打开失败");
                return;
            }

            ImageCallback = new MyCamera.cbOutputExdelegate(ImageCallbackFunc);
            nRet = this.MV_CC_RegisterImageCallBackEx_NET(ImageCallback, IntPtr.Zero);

            if (MyCamera.MV_OK != nRet)
            {
                Log("注册图象回调失败");
            }

            //连续采集
            MV_CC_SetEnumValue_NET("AcquisitionMode", (uint)MyCamera.MV_CAM_ACQUISITION_MODE.MV_ACQ_MODE_CONTINUOUS);
            //开启触发
            MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON);
            //触发方式为LINE0
            MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_LINE0);
            //输出线路选择 LINE1
            nRet = MV_CC_SetEnumValue_NET("LineSelector", 1);
            //输出模式 OUT
            nRet = MV_CC_SetEnumValue_NET("LineMode", 8);
            //软件触发
            nRet = MV_CC_SetEnumValue_NET("LineSource", 5);
            //触发使能
            nRet = MV_CC_SetBoolValue_NET("StrobeEnable", true);
            //保持时间us
            nRet = MV_CC_SetIntValue_NET("StrobeLineDuration", 100000);

            //防抖时间us
            nRet = MV_CC_SetIntValue_NET("LineDebouncerTime", 50000);

            nRet = MV_CC_SetEnumValue_NET("PixelFormat", (uint)MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8);

            nRet = MV_CC_StartGrabbing_NET();
            if (MyCamera.MV_OK != nRet)
            {
                Log("开启抓图失败");
            }
        }

        /// <summary>
        /// 单次采集图片
        /// </summary>
        public void SigleTrigger()
        {
            try
            {
                MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON);
                MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_SOFTWARE);
                // ch:触发命令 | en:Trigger command
                int nRet = MV_CC_SetCommandValue_NET("TriggerSoftware");
                if (MyCamera.MV_OK == nRet)
                {
                    Log("单次采图成功");
                }
                else
                {
                    Log("单次采图失败");
                }

                MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_LINE0);

            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 实时采集
        /// </summary>
        public void StartTrigger()
        {
            Log("相机连续采集");
            MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_OFF);
            MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_SOFTWARE);
        }
        /// <summary>
        /// 停止实时采集
        /// </summary>
        public void StopTrigger()
        {
            Log( "相机停止采集");
            MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON);
            MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_LINE0);
        }

        private void ImageCallbackFunc(IntPtr pData, ref MV_FRAME_OUT_INFO_EX pFrameInfo, IntPtr pUser)
        {
            try
            {
                if (pFrameInfo.enPixelType == MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8)
                {
                    Bitmap map = new Bitmap(pFrameInfo.nWidth, pFrameInfo.nHeight, pFrameInfo.nWidth * 1,
                        PixelFormat.Format8bppIndexed, pData);
                    ColorPalette cp = map.Palette;
                    for (int i = 0; i < 256; i++)
                    {
                        cp.Entries[i] = Color.FromArgb(i, i, i);
                    }
                    map.Palette = cp;
                    Bitmap grabmap = KiResizeImage(map, 800, 600, 0);
                    Img = grabmap;
                    try { CCD_GrabImage?.Invoke(); } catch { }
                   
                    DealImg();
                }
                else
                {
                    try
                    {
                        Bitmap bmp = new Bitmap(pFrameInfo.nWidth, pFrameInfo.nHeight, pFrameInfo.nWidth * 3,
                        PixelFormat.Format24bppRgb, pData);
                    }
                    catch (Exception ee)
                    {
                    }
                }
                MyCamera.MV_FRAME_OUT stFrameOut = new MyCamera.MV_FRAME_OUT();
                MV_CC_FreeImageBuffer_NET(ref stFrameOut);
            }
            catch (Exception ee)
            {

            }
        }

        public static Bitmap KiResizeImage(Bitmap bmp, int newW, int newH, int Mode)
        {
            try
            {
                Bitmap b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);
                // 插值算法的质量
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                g.Dispose();
                return b;
            }
            catch
            {
                return bmp;
            }
        }

        /// <summary>
        /// 关闭相机
        /// </summary>
        public void Camera_Closing()
        {
            // ch:停止抓图 | en:Stop grab image
            int nRet = MV_CC_StopGrabbing_NET();
            // ch:关闭设备 | en:Close device
            nRet = MV_CC_CloseDevice_NET();
            // ch:销毁设备 | en:Destroy device
            nRet = MV_CC_DestroyDevice_NET();
        }

        /// <summary>
        /// 图片处理=》找空料=》丝印
        /// </summary>
        /// <param name="bmap"></param>
        private void DealImg()
        {
            FindEmptyStrips();
            Match();
        }

        /// <summary>
        /// 找空料带
        /// </summary>
        private void FindEmptyStrips()
        {

        }

        /// <summary>
        /// 丝印
        /// </summary>
        private void Match()
        {

        }

        public void Log(string msg)
        {
            LogManager.Instance.WriteLog(new LogModel(LogType.相机日志, Name + ":" + msg));
        }


    }
}
