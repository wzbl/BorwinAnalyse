using BorwinAnalyse.BaseClass;
using BorwinAnalyse.DataBase.Model;
using BorwinAnalyse.UCControls;
using BorwinSplicMachine.BarCode;
using BorwinSplicMachine.FlowModel;
using BorwinSplicMachine.LCR;
using BorwinSplicMachine.UCControls;
using ComponentFactory.Krypton.Toolkit;
using LibSDK;
using LibSDK.IO;
using LibSDK.Motion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisionModel.UCControls;

namespace BorwinSplicMachine
{
    public class MainControl
    {
        public static void Log(string message)
        {
            LogManager.Instance.WriteLog(new LogModel(LogType.操作日志, message));
        }
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


        public UCLCRSearch UCLCRSearch { get; set; }

        public UCMes UCMes { get; set; }

        public MotControl motControl { get; set; }

        public UCALLAxis UCAxis { get; set; }

        public UCPrint UCPrint { get; set; }

        Form1 MainForm;

        public BarCodeCheck CodeControl = new BarCodeCheck();
        public MainControl(Form1 MainForm)
        {
            //VisionModel.HIKVision.Instance.initCam();
            UCBOM = new UCBOM();
            UCParam = new UCParam();
            UCSearchLanguage = new UCSearchLanguage();
            UCSearchBom = new UCSearchBom();
            UCAnalyseSet = new UCAnalyseSet();
            UCMain = new UCMain();
            UCBaseSet = new UCControls.UCBaseSet();
            UCLog = new UCLog();

            UCRichLog = new UCRichLog();
            UCCCD = new UCCCD();
            UCFlowControl = new UCFlowControl();
            UCLCRSearch = new UCLCRSearch();
            UCMes = new UCMes();
            UCAxis = new UCALLAxis();
            motControl = new MotControl();
            UCPrint = new UCPrint();
            UCLCR = new UCLCR();
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
                UCMes.UpdataLanguage();
            });
        }

        internal void Init()
        {

        }

        public void CheckCode(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return;
            }
            CodeControl.CheckCode(ref code);
            
            if (!CodeControl.Code1.IsSuccess)
            {
                BomDataModel bomData = BomManager.Instance.SearchByBarCode(code);
                if (bomData != null)
                {
                    if (bomData.result == "True")
                    {
                        UCLCR.CheckMaterial(bomData.type, bomData.size, bomData.value, bomData.unit, bomData.grade);
                        ParamManager.Instance.System_测值.paramValue = "1";
                    }
                    else
                    {
                        ParamManager.Instance.System_测值.paramValue="0";
                    }
                    CodeControl.Code1.Code = code;
                    CodeControl.Code1.IsSuccess = true;
                }
            }
            else
            {
                if (CodeControl.Code1.Code == code)
                {
                    CodeControl.Code2.Code = code;
                    CodeControl.Code2.IsSuccess = true;
                }
            }
        }

        public void ClearCode()
        {
            CodeControl.Clear();
        }
    }
}
