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
        public SplicCamera CameraL = new SplicCamera("左相机");
        public SplicCamera CameraR = new SplicCamera("右相机");

        public  int L_status = 0;
        public  int R_status = 0;

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
                MyCamera.MV_CC_DEVICE_INFO stDevInfo; //通用设备信息
                for (int i = 0; i < stDevList.nDeviceNum; i++)
                {
                    stDevInfo = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(stDevList.pDeviceInfo[i], typeof(MyCamera.MV_CC_DEVICE_INFO));
                    if (stDevInfo.nTLayerType == MyCamera.MV_GIGE_DEVICE)
                    {
                        MyCamera.MV_GIGE_DEVICE_INFO gigeInfo = (MyCamera.MV_GIGE_DEVICE_INFO)MyCamera.ByteToStruct(stDevInfo.SpecialInfo.stGigEInfo, typeof(MyCamera.MV_GIGE_DEVICE_INFO));

                        if ((gigeInfo.chUserDefinedName.ToUpper() == "L") & (gigeInfo.chManufacturerName.ToLower() == "hikrobot"))
                        {
                            CameraL.CreatCamera( ref stDevInfo);
                        }
                        else if ((gigeInfo.chUserDefinedName.ToUpper() == "R") & (gigeInfo.chManufacturerName.ToLower() == "hikrobot"))
                        {
                            CameraR.CreatCamera(ref stDevInfo);
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
        /// 软件退出触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppExit(object sender, EventArgs e)
        {
            CameraL.Camera_Closing();
            CameraR.Camera_Closing();
        }
    }
}
