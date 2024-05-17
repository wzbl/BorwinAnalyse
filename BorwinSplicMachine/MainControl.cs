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
using Mes.MES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
        public UCHP UCHP { get; set; }

        public UCRichLog UCRichLog { get; set; }

        public UCVisor UCVision { get; set; }
        public UCFlowControl UCFlowControl { get; set; }


        public UCLCRSearch UCLCRSearch { get; set; }

        public UCMes UCMes { get; set; }

        public MotControl motControl { get; set; }

        public UCALLAxis UCAxis { get; set; }

        public UCPrint UCPrint { get; set; }
        public UCUser UCUser { get; set; }

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
            if (dataTable != null)
            {
                if (dataTable.Rows.Count > 0)
                {
                    int lang = int.Parse(dataTable.Rows[0].ItemArray[1].ToString());
                    LanguageManager.Instance.CurrenIndex = lang;
                }
            }
            MotionControl.Init();
            IsInitFinish = true;
            MesControl.Instance.ActionCheckCode1 += ActionCheckCode1;
            MesControl.Instance.ActionCheckCode2 += ActionCheckCode2;
            MesControl.Instance.ActionHPDelete += ActionHPDelete;
        }

        public bool IsInitFinish = false;
        public bool IsStartFinish = false;
        public void Start()
        {
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
            UCHP = new UCHP();
            UCUser = new UCUser();
            motControl.Start();
            UCLCR.Start();
            BartenderPrintModel.Instance.Start();
            VisionDetection.InitVisionDetection();
            IsStartFinish = true;
            motControl.Run();
            UCMes.InitData();
        }

        public void Stop()
        {
            motControl.Stop();
        }

        public void Close()
        {
            MesControl.Instance.Save();
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
            if (ParamManager.Instance.System_机型.I == 2)
            {
                if (!MesControl.Instance.HPDataList.IsSplicFinish)
                {
                    MessageBox.Show("未完成接料,禁止扫码");
                    return;
                }
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
                if (MesControl.Instance.IsOpenMes && MesControl.Instance.checkInCode2.IsEnable.Enable)
                {
                    MesControl.Instance.checkInCode1.Code.Value = code;
                    MesControl.Instance.Updata(InterType.条码1检验);
                }
                else if (ParamManager.Instance.System_BOM.B)
                {
                    BomDataModel bomData = BomManager.Instance.SearchByBarCode(code);
                    if (bomData != null)
                    {
                        if (bomData.result == "True")
                        {
                            UCLCR.StartLCR(bomData.type, bomData.size, bomData.value, bomData.unit, bomData.grade);
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
                    else
                    {
                        CodeControl.Log("Bom中不存在条码:" + code);
                    }
                }
            }
            else if (!CodeControl.Code2.IsSuccess)
            {
                if (MesControl.Instance.IsOpenMes && MesControl.Instance.checkInCode2.IsEnable.Enable)
                {
                    MesControl.Instance.checkInCode2.Code1.Value = CodeControl.Code1.Code;
                    MesControl.Instance.checkInCode2.Code2.Value = code;
                    MesControl.Instance.Updata(InterType.条码2检验);
                }
                else if (CodeControl.Code1.Code == code)
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

        /// <summary>
        /// 合盘删除
        /// </summary>
        private void ActionHPDelete()
        {
            if (MesControl.Instance.HPDataList.HPDatas.Count == 0)
            {
                CodeControl.Code1.Clear();
                CodeControl.Code2.Clear();
            }
            else
            {
                CodeControl.Code2.Clear();
            }
        }

        /// <summary>
        /// Mes解析条码2后处理
        /// </summary>
        private void ActionCheckCode2()
        {
            if (MesControl.Instance.checkOutCode2.Result.Value == "OK")
            {
                WAVPlayer.Playerer(WAVPlayer.playName.条码比对成功);
                CodeControl.Code2.IsSuccess = true;

                if (ParamManager.Instance.System_机型.I == 2)
                {
                    HPAdd();
                }
                //可以开始接料
            }
            else
            {
                WAVPlayer.Playerer(WAVPlayer.playName.条码比对失败);
            }
        }

        /// <summary>
        /// Mes解析条码1后处理
        /// </summary>
        private void ActionCheckCode1()
        {
            if (MesControl.Instance.checkOutCode1.Result.Value == "OK" && IsLCR())
            {
                WAVPlayer.Playerer(WAVPlayer.playName.条码1获取成功请扫条码2);
                CodeControl.Code1.IsSuccess = true;
                if (ParamManager.Instance.System_机型.I == 2)
                {
                    MesControl.Instance.HPDataList.Clear();
                    HPAdd();
                }
            }
            else
            {
                WAVPlayer.Playerer(WAVPlayer.playName.条码比对失败);
                CodeControl.Code1.IsSuccess = false;
            }
        }

        /// <summary>
        /// 解析是否测值
        /// </summary>
        public bool IsLCR()
        {
            if (MesControl.Instance.checkOutCode1.IsLCR.Enable)
            {
                //如果系统要求测值
                if (MesControl.Instance.checkOutCode1.IsLCR.Value.ToUpper() == "TRUE")
                {
                    if (!AnalyLCR(out string msg))
                    {
                        Log(msg);
                        MessageBox.Show(msg);
                        return false;
                    }
                    else
                    {
                        ParamManager.Instance.System_测值.paramValue = "1";
                    }
           
                }
                else
                {
                    ParamManager.Instance.System_测值.paramValue = "0";
                    ParamManager.Instance.System_丝印.paramValue = "1";
                }
            }
            else
            {
                //如果系统未要求测值
                if (!AnalyLCR(out string msg))
                {
                    ParamManager.Instance.System_测值.paramValue = "0";
                    Log(msg);
                }
                else
                {
                    ParamManager.Instance.System_测值.paramValue = "1";
                }
            }
            return true;
        }

        public bool AnalyLCR(out string msg)
        {
            msg = "解析正常";
            if (ParamManager.Instance.System_BOM.B)
            {
                //1.采用本地Bom的方式
                BomDataModel bomData = BomManager.Instance.SearchByBarCode(CodeControl.Code1.Code);
                if (bomData != null)
                {
                    if (bomData.result == "True")
                    {
                        UCLCR.StartLCR(bomData.type, bomData.size, bomData.value, bomData.unit, bomData.grade);
                        ParamManager.Instance.System_测值.paramValue = "1";
                    }
                    else
                    {
                        msg = "Bom信息不全:".tr() + CodeControl.Code1.Code;
                        return false;
                    }
                }
                else
                {
                    msg = "Bom中不存在条码:".tr() + CodeControl.Code1.Code;
                    return false;
                }
            }
            else
            {
                //2.系统返回信息
                if (MesControl.Instance.checkOutCode1.MaterialDes.Enable)
                {
                    //A.解析物料描述
                    AnalyseResult analyseResult = CommonAnalyse.Instance.AnalyseMethod_copy(MesControl.Instance.checkOutCode1.MaterialDes.Value);
                    if (analyseResult != null)
                    {
                        if (analyseResult.Result)
                        {
                            UCLCR.StartLCR(analyseResult.Type, analyseResult.Size, analyseResult.Value, analyseResult.Unit, analyseResult.Grade);
                        }
                        else
                        {
                            msg = "解析物料异常:".tr() + MesControl.Instance.checkOutCode1.MaterialDes.Value;
                            return false;
                        }
                    }
                    else
                    {
                        msg = "解析物料异常:".tr() + MesControl.Instance.checkOutCode1.MaterialDes.Value;
                        return false;
                    }
                }
                else if (MesControl.Instance.checkOutCode1.Size.Enable && MesControl.Instance.checkOutCode1.Value.Enable && MesControl.Instance.checkOutCode1.Grade.Enable)
                {
                    //B.类型,尺寸,值,单位,偏差等级
                    string type = MesControl.Instance.checkOutCode1.Type.Value;
                    string size = MesControl.Instance.checkOutCode1.Size.Value;
                    string value = MesControl.Instance.checkOutCode1.Value.Value;
                    string unit = MesControl.Instance.checkOutCode1.Unit.Value;
                    string grade = MesControl.Instance.checkOutCode1.Grade.Value;
                    if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(size) || string.IsNullOrEmpty(value) || string.IsNullOrEmpty(unit) || string.IsNullOrEmpty(grade))
                    {
                        msg = "信息不全:".tr() + type + "-" + size + "-" + value + "-" + unit + "-" + grade;
                        return false;
                    }
                    UCLCR.StartLCR(type, size, value, unit, grade);
                }
                else if (MesControl.Instance.checkOutCode1.Size.Enable && MesControl.Instance.checkOutCode1.MaxValue.Enable && MesControl.Instance.checkOutCode1.MinValue.Enable)
                {
                    //C.类型,尺寸,最大值,最小值,单位
                    string type = MesControl.Instance.checkOutCode1.Type.Value;
                    string size = MesControl.Instance.checkOutCode1.Size.Value;
                    double value = 0;
                    if (double.TryParse(MesControl.Instance.checkOutCode1.MaxValue.Value, out double max) && double.TryParse(MesControl.Instance.checkOutCode1.MaxValue.Value, out double min))
                    {
                        value = (max + min) / 2;
                    }
                    else
                    {
                        msg = "错误" + "最大值".tr() + "=" + MesControl.Instance.checkOutCode1.MaxValue.Value + "最小值".tr() + "=" + MesControl.Instance.checkOutCode1.MinValue.Value;
                        return false;
                    }
                    string unit = MesControl.Instance.checkOutCode1.Unit.Value;
                    string grade = "";
                    grade = ((max / value) - 1) + "%";
                    if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(size)|| string.IsNullOrEmpty(unit))
                    {
                        msg = "信息不全:".tr() + type + "-" + size + "-" + value + "-" + unit + "-" + grade;
                        return false;
                    }
                    UCLCR.StartLCR(type, size, value.ToString(), unit, grade);
                }
                else if (MesControl.Instance.checkOutCode1.Value.Enable && MesControl.Instance.checkOutCode1.Grade.Enable)
                {
                    //D.类型,值,单位,偏差等级
                    string type = MesControl.Instance.checkOutCode1.Type.Value;
                    string value = MesControl.Instance.checkOutCode1.Value.Value;
                    string unit = MesControl.Instance.checkOutCode1.Unit.Value;
                    string grade = MesControl.Instance.checkOutCode1.Grade.Value;
                    if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(value) || string.IsNullOrEmpty(unit) || string.IsNullOrEmpty(grade))
                    {
                        msg = "信息不全:" + type + "-" + value + "-" + unit + "-" + grade;
                        return false;
                    }
                    UCLCR.StartLCR(type, "", value, unit, grade);
                }
                else if (MesControl.Instance.checkOutCode1.MaxValue.Enable && MesControl.Instance.checkOutCode1.MinValue.Enable)
                {
                    //E.类型,最大值,最小值,单位
                    string type = MesControl.Instance.checkOutCode1.Type.Value;
                    double value = 0;
                    if (double.TryParse(MesControl.Instance.checkOutCode1.MaxValue.Value, out double max) && double.TryParse(MesControl.Instance.checkOutCode1.MaxValue.Value, out double min))
                    {
                        value = (max + min) / 2;
                    }
                    else
                    {
                        msg = "错误" + "最大值".tr() + "=" + MesControl.Instance.checkOutCode1.MaxValue.Value + "最小值".tr() + "=" + MesControl.Instance.checkOutCode1.MinValue.Value;
                        return false;
                    }
                    string unit = MesControl.Instance.checkOutCode1.Unit.Value;
                    string grade = "";
                    grade = ((max / value) - 1) + "%";
                    if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(unit))
                    {
                        msg = "信息不全:".tr() + type + "-" + value + "-" + unit + "-" + grade;
                        return false;
                    }
                    UCLCR.StartLCR(type, "", value.ToString(), unit, grade);
                }
                else
                {
                    msg = "条码1检查输出不符合要求";
                    return false;
                }

            }
            return true;
        }

        private void HPAdd()
        {
            HPDataIn hPData = MesControl.Instance.GetHPObject();
            hPData.BarCode.Value = CodeControl.Code1.Code;
            hPData.IsLCR.Value = MesControl.Instance.checkOutCode1.IsLCR.Value;
            hPData.Type.Value = MesControl.Instance.checkOutCode1.Type.Value;
            hPData.Size.Value = MesControl.Instance.checkOutCode1.Size.Value;
            hPData.MaxValue.Value = MesControl.Instance.checkOutCode1.MaxValue.Value;
            hPData.MinValue.Value = MesControl.Instance.checkOutCode1.MinValue.Value;
            MesControl.Instance.HPDataList.Add(hPData);
        }

    }
}
