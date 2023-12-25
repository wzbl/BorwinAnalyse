using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BorwinAnalyse.BaseClass;
using BorwinAnalyse.DataBase.Model;
using MvCamCtrl.NET;
using System.Drawing.Drawing2D;

namespace VisionModel
{
    public class HIKVision
    {
        public MyCamera CameraL = new MyCamera();
        public MyCamera CameraR = new MyCamera();

        public static MyCamera.cbExceptiondelegate L_CallBackFunc;
        public static MyCamera.cbExceptiondelegate R_CallBackFunc;

        public static MyCamera.cbOutputExdelegate L_ImageCallback;
        public static MyCamera.cbOutputExdelegate R_ImageCallback;

        public static int L_status = 0;
        public static int R_status = 0;

        public void initCam()
        {
            try
            {
                AppDomain.CurrentDomain.ProcessExit += new EventHandler(AppExit);
                // ch:枚举设备 | en:Enum device
                MyCamera.MV_CC_DEVICE_INFO_LIST stDevList = new MyCamera.MV_CC_DEVICE_INFO_LIST();
                int nRet = MyCamera.MV_CC_EnumDevices_NET(MyCamera.MV_GIGE_DEVICE | MyCamera.MV_USB_DEVICE, ref stDevList);
                if (stDevList.nDeviceNum == 0)
                {
                    LogManager.Instance.WriteLog(new LogModel(LogType.相机日志, "没有找到设备"));
                    return;
                }
                MyCamera.MV_CC_DEVICE_INFO stDevInfo; // 通用设备信息
                for (int i = 0; i < stDevList.nDeviceNum; i++)
                {
                    stDevInfo = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(stDevList.pDeviceInfo[i], typeof(MyCamera.MV_CC_DEVICE_INFO));
                    if (stDevInfo.nTLayerType == MyCamera.MV_GIGE_DEVICE)
                    {
                        MyCamera.MV_GIGE_DEVICE_INFO gigeInfo = (MyCamera.MV_GIGE_DEVICE_INFO)MyCamera.ByteToStruct(stDevInfo.SpecialInfo.stGigEInfo, typeof(MyCamera.MV_GIGE_DEVICE_INFO));

                        if ((gigeInfo.chUserDefinedName.ToUpper() == "L") & (gigeInfo.chManufacturerName.ToLower() == "hikrobot"))
                        {
                            CreatCamera(CameraL, ref stDevInfo, 0);
                        }
                        else if ((gigeInfo.chUserDefinedName.ToUpper() == "R") & (gigeInfo.chManufacturerName.ToLower() == "hikrobot"))
                        {
                            CreatCamera(CameraR, ref stDevInfo, 1);
                        }
                    }
                }
                LogManager.Instance.WriteLog(new LogModel(LogType.相机日志, "初始化相机完成"));
            }
            catch (Exception)
            {
                AppExit(this, new EventArgs());
            }

            //注册回调
            try
            {
                Thread Status = new Thread(Cmd_Status);
                Status.IsBackground = true;
                Status.Name = "刷新相机状态";
                Status.Start();
            }
            catch (Exception ee)
            {
            }
        }

        /// <summary>
        /// 创建相机
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="stDevInfo"></param>
        /// <param name="index"></param>
        private void CreatCamera(MyCamera camera, ref MyCamera.MV_CC_DEVICE_INFO stDevInfo, int index)
        {
            int nRet = camera.MV_CC_CreateDevice_NET(ref stDevInfo);
            if (MyCamera.MV_OK != nRet)
            {
                LogManager.Instance.WriteLog(new LogModel(LogType.相机日志, "创建相机失败"));
                return;
            }
            // ch:打开设备 | en:Open device
            nRet = camera.MV_CC_OpenDevice_NET();
            if (MyCamera.MV_OK != nRet)
            {
                LogManager.Instance.WriteLog(new LogModel(LogType.相机日志, "相机打开失败"));
                return;
            }
            switch (index)
            {
                case 0:
                    L_ImageCallback = new MyCamera.cbOutputExdelegate(L_ImageCallbackFunc);
                    nRet = camera.MV_CC_RegisterImageCallBackEx_NET(L_ImageCallback, IntPtr.Zero);
                    break;
                case 1:
                    R_ImageCallback = new MyCamera.cbOutputExdelegate(R_ImageCallbackFunc);
                    nRet = camera.MV_CC_RegisterImageCallBackEx_NET(R_ImageCallback, IntPtr.Zero);
                    break;
            }

            if (MyCamera.MV_OK != nRet)
            {
                LogManager.Instance.WriteLog(new LogModel(LogType.相机日志, "注册图象回调失败"));
            }

            //连续采集
            camera.MV_CC_SetEnumValue_NET("AcquisitionMode", (uint)MyCamera.MV_CAM_ACQUISITION_MODE.MV_ACQ_MODE_CONTINUOUS);
            //开启触发
            camera.MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON);
            //触发方式为LINE0
            camera.MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_LINE0);
            //输出线路选择 LINE1
            nRet = camera.MV_CC_SetEnumValue_NET("LineSelector", 1);
            //输出模式 OUT
            nRet = camera.MV_CC_SetEnumValue_NET("LineMode", 8);
            //软件触发
            nRet = camera.MV_CC_SetEnumValue_NET("LineSource", 5);
            //触发使能
            nRet = camera.MV_CC_SetBoolValue_NET("StrobeEnable", true);
            //保持时间us
            nRet = camera.MV_CC_SetIntValue_NET("StrobeLineDuration", 100000);

            //防抖时间us
            nRet = camera.MV_CC_SetIntValue_NET("LineDebouncerTime", 50000);

            nRet = camera.MV_CC_SetEnumValue_NET("PixelFormat", (uint)MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8);

            nRet = camera.MV_CC_StartGrabbing_NET();
            if (MyCamera.MV_OK != nRet)
            {
                LogManager.Instance.WriteLog(new LogModel(LogType.相机日志, "开启抓图失败"));
            }
        }

        /// <summary>
        /// 相机软件采图
        /// </summary>
        public static void SowftGrab(MyCamera camera)
        {
            try
            {
                camera.MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON);
                camera.MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_SOFTWARE);
                // ch:触发命令 | en:Trigger command
                int nRet = camera.MV_CC_SetCommandValue_NET("TriggerSoftware");
                if (MyCamera.MV_OK == nRet)
                {
                    //JYE.log("左相机单次采图成功！");
                }
                else
                {
                    //JYE.log("左相单次采图失败！：" + nRet.ToString());
                }

                camera.MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_LINE0);

            }
            catch (Exception)
            {
            }
        }

        private void Cmd_Status()
        {
            while (true)
            {
                try
                {
                    if (CameraL.MV_CC_IsDeviceConnected_NET() & CameraL.GetCameraHandle() != IntPtr.Zero)
                    {
                        L_status = 1;
                    }
                    else
                    {
                        if (L_status >= 1)
                        {
                            L_status = 2;
                        }
                        else
                        {
                            L_status = 0;
                        }
                    }

                    if (CameraR.MV_CC_IsDeviceConnected_NET() & CameraR.GetCameraHandle() != IntPtr.Zero)
                    {
                        R_status = 1;
                    }
                    else
                    {
                        if (R_status >= 1)
                        {
                            R_status = 2;
                        }
                        else
                        {
                            R_status = 0;
                        }
                    }

                }
                catch (Exception)
                {

                }
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// 采图回调函数
        /// 1.绘制到界面==》2.图片处理(找空料/丝印等)
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="pFrameInfo"></param>
        /// <param name="pUser"></param>
        private void R_ImageCallbackFunc(IntPtr pData, ref MyCamera.MV_FRAME_OUT_INFO_EX pFrameInfo, IntPtr pUser)
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
                    //try { CCDR_GrabImage?.Invoke(grabmap); } catch { }
                    //bmpR = new Bitmap(grabmap);
                    //try { CCDR_GrabImage?.Invoke(map); } catch { }
                    //bmpR = map;
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
                CameraR.MV_CC_FreeImageBuffer_NET(ref stFrameOut);
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


        private void L_ImageCallbackFunc(IntPtr pData, ref MyCamera.MV_FRAME_OUT_INFO_EX pFrameInfo, IntPtr pUser)
        {

        }

        /// <summary>
        /// 关闭相机
        /// </summary>
        private void Camera_Closing(MyCamera camera)
        {
            // ch:停止抓图 | en:Stop grab image
            int nRet = camera.MV_CC_StopGrabbing_NET();
            if (MyCamera.MV_OK != nRet)
            {
                //JYE.log("device failed: " + nRet.ToString());
            }

            // ch:关闭设备 | en:Close device
            nRet = camera.MV_CC_CloseDevice_NET();
            if (MyCamera.MV_OK != nRet)
            {
                //JYE.log("device failed: " + nRet.ToString());
            }

            // ch:销毁设备 | en:Destroy device
            nRet = camera.MV_CC_DestroyDevice_NET();
            if (MyCamera.MV_OK != nRet)
            {
                //JYE.log("device failed: " + nRet.ToString());
            }
        }

        /// <summary>
        /// 软件退出触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppExit(object sender, EventArgs e)
        {
            Camera_Closing(CameraL);
            Camera_Closing(CameraR);
        }
    }
}
