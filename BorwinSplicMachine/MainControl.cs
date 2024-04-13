using BorwinAnalyse.BaseClass;
using BorwinAnalyse.DataBase.Model;
using BorwinAnalyse.UCControls;
using BorwinSplicMachine.BarCode;
using BorwinSplicMachine.FlowModel;
using BorwinSplicMachine.LCR;
using BorwinSplicMachine.UCControls;
using ComponentFactory.Krypton.Toolkit;
using FeederSpliceVisionSys;
using LibSDK;
using LibSDK.IO;
using LibSDK.Motion;
using Mes;
using System;
using System.Collections.Generic;
using System.Data;
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

        public UCParam UCParam { get; set; }

        public UCSearchLanguage UCSearchLanguage { get; set; }

        public UCControls.UCBaseSet UCBaseSet { get; set; }
        public UCLog UCLog { get; set; }

        public UCLCR UCLCR { get; set; }

        public UCRichLog UCRichLog { get; set; }

        public UCVisor UCVision { get; set; }
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
            this.MainForm = MainForm;
        }



        public void Init()
        {
            CommonAnalyse.Instance.Load();
            BomManager.Instance.Init();
            MesControl.Instance.Load();
            DataTable dataTable = LanguageManager.Instance.SearchALLLanguageType();
            ParamManager.Instance.Load();
            BartenderPrintModel.Instance.Load();
            if (dataTable == null) { return; }
            if (dataTable.Rows.Count > 0)
            {
                int lang = int.Parse(dataTable.Rows[0].ItemArray[1].ToString());
                LanguageManager.Instance.CurrenIndex = lang;
            }
            UCParam = new UCParam();
            UCSearchLanguage = new UCSearchLanguage();
            UCBaseSet = new UCControls.UCBaseSet();
            UCLog = new UCLog();
            UCVision = new UCVisor();
            UCRichLog = new UCRichLog();
            UCLCRSearch = new UCLCRSearch();
            UCMes = new UCMes();
            UCAxis = new UCALLAxis();
            motControl = new MotControl();
            UCPrint = new UCPrint();
            UCLCR = new UCLCR();
            UCMain = new UCMain();
            IsInitFinish = true;
        }

        public   bool IsInitFinish = false;
        public bool IsStartFinish = false;
        public void Start()
        {
            MotionControl.Init();
            motControl.Start();
            UCLCR.Start();
            BartenderPrintModel.Instance.Start();
            VisionDetection.InitVisionDetection();
            IsStartFinish = true;
        }

        public void Stop()
        {
            motControl.Stop();
        }

        public void Close()
        {
            motControl.Stop();
            BartenderPrintModel.Instance.Stop();
        }

        public async void UpdataLanguage()
        {
            await asyncUpdataLanguage();
        }

        public async Task asyncUpdataLanguage()
        {
            await Task.Run(() =>
            {
                UCParam.UpdataLanguage();
                UCSearchLanguage.UpdataLanguage();
                UCMain.UpdataLanguage();
                UCBaseSet.UpdataLanguage();
                MainForm.UpdataLanguage();
                UCLog.UpdataLanguage();
                UCLCR.UpdateLanguage();
                UCMes.UpdataLanguage();
                UCLCRSearch.UpdateLanguage();
                UCAxis.UpdataLanguage();
                UCPrint.UpdataLanguage();

            });
        }

        public void CheckCode(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return;
            }
            CodeControl.Log("原始条码" + code);
            CodeControl.CheckCode(ref code);
            if (!CodeControl.Code1.IsSuccess)
            {
                CodeControl.Code1.Code = code;
                switch (MotControl.runnersWidth)
                {
                    case RunnersWidth._8mm:
                        VisionDetection.SetMaterialNumber(code, MyTapeWidthType.M8);
                        break;
                    case RunnersWidth._12mm:
                        VisionDetection.SetMaterialNumber(code, MyTapeWidthType.M12);
                        break;
                    case RunnersWidth._16mm:
                        VisionDetection.SetMaterialNumber(code, MyTapeWidthType.M16);
                        break;
                    case RunnersWidth._24mm:
                        VisionDetection.SetMaterialNumber(code, MyTapeWidthType.M24);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                CodeControl.Code2.Code = code;
            }
            if (ParamManager.Instance.条码校验_是否设定条码长度.B)
            {
                if (code.Length < ParamManager.Instance.条码校验_条码长度.I)
                {
                    return;
                }
            }

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
                        ParamManager.Instance.System_测值.paramValue = "0";
                        ParamManager.Instance.System_丝印.paramValue = "1";
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
