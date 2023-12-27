﻿using BorwinAnalyse.BaseClass;
using BorwinAnalyse.DataBase.Model;
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
    public partial class CCD : UserControl
    {
        MyCamera myCamera;
        public CCD()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }
        bool Run = false;
        public CCD(HIKVision hIKVision, int index) : this
            ()
        {
            switch (index)
            {
                case 0:
                    this.myCamera = hIKVision.CameraL;
                    hIKVision.CCDL_GrabImage += CCD_GrabImage;
                    break;
                case 1:
                    this.myCamera = hIKVision.CameraR;
                    hIKVision.CCDR_GrabImage += CCD_GrabImage;
                    break;
                default:
                    break;
            }
        }

        private void CCD_GrabImage(Bitmap bmap)
        {
            LogManager.Instance.WriteLog(new BorwinAnalyse.DataBase.Model.LogModel(LogType.相机日志,"图片显示"));
            mainWindow.Image = bmap;
        }

        private void 采集ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                myCamera.MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON);
                myCamera.MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_SOFTWARE);
                // ch:触发命令 | en:Trigger command
                int nRet = myCamera.MV_CC_SetCommandValue_NET("TriggerSoftware");
                if (MyCamera.MV_OK == nRet)
                {
                    LogManager.Instance.WriteLog(new BorwinAnalyse.DataBase.Model.LogModel(LogType.相机日志, "单次采图成功"));
                }
                else
                {
                    LogManager.Instance.WriteLog(new BorwinAnalyse.DataBase.Model.LogModel(LogType.相机日志, "单次采图失败"));
                }

                myCamera.MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_LINE0);

            }
            catch (Exception)
            {
            }
        }

        private void 实时ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Run = !Run;
            if (Run)
            {
                实时ToolStripMenuItem.Text = "停止实时采集";
                LogManager.Instance.WriteLog(new BorwinAnalyse.DataBase.Model.LogModel(LogType.相机日志, "相机连续采集"));
                myCamera.MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_OFF);
                myCamera.MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_SOFTWARE);
            }
            else
            {
                实时ToolStripMenuItem.Text = "实时采集";
                LogManager.Instance.WriteLog(new BorwinAnalyse.DataBase.Model.LogModel(LogType.相机日志, "相机停止采集"));
                myCamera.MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON);
                myCamera.MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_LINE0);
            }
        }


    }
}