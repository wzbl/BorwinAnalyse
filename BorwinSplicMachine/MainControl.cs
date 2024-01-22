using BorwinAnalyse.UCControls;
using BorwinSplicMachine.FlowModel;
using BorwinSplicMachine.LCR;
using BorwinSplicMachine.UCControls;
using ComponentFactory.Krypton.Toolkit;
using LibSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VisionModel.UCControls;

namespace BorwinSplicMachine
{
    public class MainControl
    {
        public UCMain UCMain
        {
            get;
            set;
        }
        public UCBOM UCBOM { get; set; }
        public UCParam UCParam { get; set; }

        public UCSearchBom UCSearchBom { get; set; }

        public UCSearchLanguage UCSearchLanguage { get; set; }

        public UCAnalyseSet UCAnalyseSet { get; set; }
        public UCControls.UCBaseSet UCBaseSet { get; set; }
        public UCLog UCLog { get; set; }

        public UCLCR UCLCR { get; set; }

        public UCRichLog UCRichLog { get; set; }

        public UCCCD UCCCD { get; set; }

        public UCFlowControl UCFlowControl { get; set; }

        public CalibrationCCD CalibrationCCD { get; set;}

        public UCLCRSearch UCLCRSearch { get; set; }

        public UCMes UCMes { get; set; }
        public UCMotion UCMotion { get; set; }

        Form1 MainForm;
        public MainControl(Form1 MainForm)
        {
            VisionModel.HIKVision.Instance.initCam();
            UCBOM = new UCBOM();
            UCParam = new UCParam();
            UCSearchLanguage = new UCSearchLanguage();
            UCSearchBom = new UCSearchBom();
            UCAnalyseSet = new UCAnalyseSet();
            UCMain = new UCMain();
            UCBaseSet = new UCControls.UCBaseSet();
            UCLog = new UCLog();
            UCLCR = new UCLCR();
            UCRichLog = new UCRichLog();
            UCCCD = new UCCCD();
            UCFlowControl = new UCFlowControl();
            CalibrationCCD =new CalibrationCCD();
            UCLCRSearch = new UCLCRSearch();
            UCMes= new UCMes();
            UCMotion = new UCMotion();
            this.MainForm = MainForm;
        }

        public async void UpdataLanguage()
        {
            await asyncUpdataLanguage();
        }

        public async Task asyncUpdataLanguage()
        {
            await Task.Run(() =>
            {
                UCBOM.UpdataLanguage();
                UCParam.UpdataLanguage();
                UCSearchLanguage.UpdataLanguage();
                UCSearchBom.UpdataLanguage();
                UCAnalyseSet.UpdataLanguage();
                UCMain.UpdataLanguage();
                UCBaseSet.UpdataLanguage();
                MainForm.UpdataLanguage();
                UCLog.UpdataLanguage();
                UCLCR.UpdateLanguage();
                CalibrationCCD.UpdateLanguage();
                UCMes.UpdataLanguage();
            });
        }

    }
}
