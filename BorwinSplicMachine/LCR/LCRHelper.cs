﻿using BorwinAnalyse.BaseClass;
using BorwinAnalyse.DataBase.Model;
using LibSDK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using VisionModel;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BorwinSplicMachine.LCR
{
    /// <summary>
    /// LCR实体类
    /// 包括电表控制，测值流程控制，测试数据保存
    /// </summary>
    public class LCRHelper
    {
        public LCRHelper()
        {
            SerialPort = new SerialPort
            {
                PortName = "COM1",
                BaudRate = 115200,
                DataBits = 8,
                Parity = Parity.None,
                StopBits = StopBits.One
            };
            Init();
        }
        private SerialPort SerialPort { get; set; }

        #region 公开属性

        /// <summary>
        /// 类型
        /// </summary>
        public LCR_Type Type = LCR_Type.Error;

        /// <summary>
        /// 尺寸
        /// </summary>
        public LCR_Size Size = LCR_Size.Error;

        /// <summary>
        /// 值
        /// </summary>
        public double Value = 0;

        /// <summary>
        /// 转换单位后的值
        /// </summary>
        public double UnitValue = 0;

        /// <summary>
        /// 实测值
        /// </summary>
        public double RealValue = 0;

        /// <summary>
        /// 是否需要测值
        /// </summary>
        public bool IsLCR = false;

        /// <summary>
        /// 左实测值
        /// </summary>
        public double LRealValue = 0;

        /// <summary>
        /// 右实测值
        /// </summary>
        public double RRealValue = 0;

        /// <summary>
        /// 左实测值
        /// </summary>
        public string LResult = "";

        /// <summary>
        /// 右实测值
        /// </summary>
        public string RResult = "";

        /// <summary>
        /// 单位
        /// </summary>
        public Unit Unit = Unit.Error;

        /// <summary>
        /// 等级
        /// </summary>
        public double Grade = 0;

        /// <summary>
        /// 最大值
        /// </summary>
        public double Max_Value = 0;

        /// <summary>
        /// 最小值
        /// </summary>
        public double Min_Value = 0;

        /// <summary>
        /// 串口是否打来
        /// </summary>
        public bool IsOpenSerialPort
        {
            get { return SerialPort.IsOpen; }
        }

        public LCRFlow LCRFlow = LCRFlow.None;
        public double ReadData = -1;

        public WhichSide Side = WhichSide.None;

        public WhichLine LineNo = WhichLine.None;
        public LCRResult Result = LCRResult.None;
        #endregion

        #region 公开方法
        public void OpenSerialPort()
        {
            try
            {
                if (SerialPort.IsOpen) SerialPort.Close();
                Thread.Sleep(100);
                SerialPort.Open();
                if (SerialPort.IsOpen)
                {
                    //打开串口成功
                    SerialPort.DataReceived += SerialPort_DataReceived;
                    Log("电表连接成功");
                }
                else
                {
                    //打开串口失败
                    Log("电表连接失败");
                }
            }
            catch (Exception ex)
            {
                //打开串口失败
                Log("电表连接异常" + ":" + ex.Message);
            }
        }


        /// <summary>
        /// 开始LCR测值
        /// </summary>
        public void StartLCR(LCR_Type Type, LCR_Size Size, double Value, Unit Unit, double Grade)
        {
            SetPinWidth();
            this.Type = Type;
            this.Size = Size;
            this.Value = Value;
            this.Unit = Unit;
            this.Grade = Grade;
            SetABWidth();
            SetMaxValue();
            SetMinValue();
            SetUnitValue();
            if (IsOpenSerialPort)
            {
                SendTypeCommand();
            }

        }

        /// <summary>
        /// 设置AB探针宽度
        /// </summary>
        public void SetABWidth()
        {
            if (!MotionControl.CardAPI.IsInitCardOK)
            {
                return;
            }
            double a = 0;
            double b = 0;
            switch (Size)
            {
                case LCR_Size.Error:
                case LCR_Size._01005:
                    a = MotControl.探针A.GetPosByName("01005");
                    b = MotControl.探针B.GetPosByName("01005");
                    break;
                case LCR_Size._0201:
                    a = MotControl.探针A.GetPosByName("0201");
                    b = MotControl.探针B.GetPosByName("0201");
                    break;
                case LCR_Size._0402:
                    a = MotControl.探针A.GetPosByName("0402");
                    b = MotControl.探针B.GetPosByName("0402");
                    break;
                case LCR_Size._0603:
                    a = MotControl.探针A.GetPosByName("0603");
                    b = MotControl.探针B.GetPosByName("0603");
                    break;
                case LCR_Size._0805:
                    a = MotControl.探针A.GetPosByName("0805");
                    b = MotControl.探针B.GetPosByName("0805");
                    break;
                case LCR_Size._1206:
                    a = MotControl.探针A.GetPosByName("1206");
                    b = MotControl.探针B.GetPosByName("1206");
                    break;
                case LCR_Size._1210:
                    a = MotControl.探针A.GetPosByName("1210");
                    b = MotControl.探针B.GetPosByName("1210");
                    break;
                default:
                    a = MotControl.探针A.GetPosByName("01005");
                    b = MotControl.探针B.GetPosByName("01005");
                    break;
            }
        }

        /// <summary>
        /// 调节AB针的间距
        /// </summary>
        public void SetPinWidth()
        {
            if (!MotionControl.CardAPI.IsInitCardOK)
            {
                return;
            }
            switch (Size)
            {
                case LCR_Size._01005:
                    MotControl.探针A.MovePosByName("01005", 1);
                    MotControl.探针B.MovePosByName("01005", 1);
                    break;
                case LCR_Size._0201:
                    MotControl.探针A.MovePosByName("0201", 1);
                    MotControl.探针B.MovePosByName("0201", 1);
                    break;
                case LCR_Size._0402:
                    MotControl.探针A.MovePosByName("0402", 1);
                    MotControl.探针B.MovePosByName("0402", 1);
                    break;
                case LCR_Size._0603:
                    MotControl.探针A.MovePosByName("0603", 1);
                    MotControl.探针B.MovePosByName("0603", 1);
                    break;
                case LCR_Size._0805:
                    MotControl.探针A.MovePosByName("0805", 1);
                    MotControl.探针B.MovePosByName("0805", 1);
                    break;
                case LCR_Size._1206:
                    MotControl.探针A.MovePosByName("1206", 1);
                    MotControl.探针B.MovePosByName("1206", 1);
                    break;
                case LCR_Size._1210:
                    MotControl.探针A.MovePosByName("1210", 1);
                    MotControl.探针B.MovePosByName("1210", 1);
                    break;
                default:
                    break;
            }
        }


        /// <summary>
        /// 给电表写读值指令
        /// </summary>
        public void SendReadCommand()
        {
            if (SerialPort.IsOpen)
            {
                SerialPort.DiscardInBuffer();
                SerialPort.Write("FETC?" + "\r\n");
            }
        }

        /// <summary>
        /// 清除数据
        /// </summary>
        public void Clear()
        {
            Side = WhichSide.None;
            LineNo = WhichLine.None;
            Result = LCRResult.None;
            Max_Value = 0;
            Min_Value = 0;
            RealValue = 0;
            Type = LCR_Type.Error;
            Size = LCR_Size.Error;
            Value = 0;
            Unit = Unit.Error;
            Grade = 0;
            LResult = "";
            RResult = "";
        }

        /// <summary>
        /// 清除结果
        /// </summary>
        public void ClearResult()
        {
            Side = WhichSide.None;
            LineNo = WhichLine.None;
            Result = LCRResult.None;
            RealValue = 0;
        }

        /// <summary>
        /// 保存测值明细
        /// </summary>
        public void SaveLCRData()
        {
            string dic = "D:\\HistoryData" + "\\LCR" + "\\" + DateTime.Now.ToString("yyyy-MM");
            if (!Directory.Exists(dic))
            {
                Directory.CreateDirectory(dic);
            }
            string tmp = dic + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".csv";
            if (!File.Exists(tmp))
            {
                File.AppendAllText(tmp, "测值时间,条码1,物料信息,最大值,最小值,实测值,结果,左/右,线体,操作员,备注" + "\r\n", Encoding.UTF8);
            }
            File.AppendAllText(tmp,
                             DateTime.Now.ToString("dd HH:mm:ss") + "," +      //测值时间  
                             "12345678" + "," +                                        //条码1
                             GetMaterial() + "," +      //物料信息
                             Max_Value + "," +                                         //最大值
                             Min_Value + "," +                                         //最小值
                             RealValue + "," +                                        //实测值
                             Result + "," +                                           //结果
                             Side + "," +                                             //左/右
                             LResult + "," +                                           //线体
                             "李小龙" + "," +                                          //操作员
                             "" + "," + "\r\n",                                        //备注
                             Encoding.UTF8);
        }

        /// <summary>
        /// 保存接料完成数据
        /// </summary>
        public void SaveData()
        {
            string dic = "D:\\HistoryData" + "\\" + DateTime.Now.ToString("yyyy-MM");
            if (!Directory.Exists(dic))
            {
                Directory.CreateDirectory(dic);
            }
            string tmp = dic + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".csv";

            if (!File.Exists(tmp))
            {
                File.AppendAllText(tmp, "接料时间,条码1,扫码1时间,条码2,扫码2时间,物料信息,是否测值,最大值,最小值,右实测值,右结果,左实测值,左结果,是否丝印,左丝印结果,左丝印图片,右丝印结果,右丝印图片,操作员,备注" + "\r\n", Encoding.UTF8);
            }
            File.AppendAllText(tmp,
                               DateTime.Now.ToString("dd HH:mm:ss") + "," +    //接料时间  
                               "12345678" + "," +                              //条码1
                               DateTime.Now.ToString("dd HH:mm:ss") + "," +    //扫码1时间
                               "12345678" + "," +                              //条码2
                               DateTime.Now.ToString("dd HH:mm:ss") + "," +    //扫码2时间
                               GetMaterial() + "," +      //物料信息
                               IsLCR + "," +                                   //是否测值
                               Max_Value + "," +                               //最大值
                               Min_Value + "," +                                //最小值
                               RRealValue + "," +                               //右实测值
                               RResult + "," +                                  //右结果
                               LRealValue + "," +                               //左实测值
                               LResult + "," +                                  //左结果
                               "" + "," +                      //是否丝印
                               "HIKVision.Instance.CameraR.MatchResult" + "," +                                                 //右丝印结果
                                "D:\\壁纸\\高圆圆1.jpg" + "," +                                                 //右丝印图片
                               "HIKVision.Instance.CameraL.MatchResult" + "," +                                               //左丝印结果
                               "D:\\壁纸\\高圆圆1.jpg" + "," +                                              //左丝印图片
                               "李小龙" + "," +                                          //操作员
                               "" + "," + "\r\n",                                        //备注
                               Encoding.UTF8);
            Clear();
        }
        #endregion

        private void Init()
        {
            OpenSerialPort();
        }

        /// <summary>
        /// 解析串口返回数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (LCRFlow != LCRFlow.发送电表指令)
            {
                return;
            }
            Thread.Sleep(100);
            try
            {
                byte[] recvData = new byte[SerialPort.BytesToRead];
                SerialPort.Read(recvData, 0, recvData.Length);
                string Recv = Encoding.Default.GetString(recvData);
                Log("接收到电表数据".tr() + ":" + Recv);
                string[] datels = Recv.Trim().Split(',');
                double.TryParse(datels[0], out ReadData);
                LCRFlow = LCRFlow.增加补偿值;
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }


        /// <summary>
        /// 给电表写指令类型，电压、电流
        /// </summary>
        private void SendTypeCommand()
        {
            switch (Type)
            {
                case LCR_Type.Error:
                    break;
                case LCR_Type.电感:
                    break;
                case LCR_Type.电容:
                    CAPTypeCommand();
                    break;
                case LCR_Type.电阻:
                    RESTypeCommand();
                    break;
                case LCR_Type.其他:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 电容类型指令
        /// </summary>
        private void CAPTypeCommand()
        {
            bool WriteVOLT = true;
            //根据电压值发
            if (UnitValue >= ParamManager.Instance.ReWriteV_Min.D / 1000000 && UnitValue <= ParamManager.Instance.ReWriteV_Max.D / 1000000)
                WriteVOLT = true;
            else WriteVOLT = false;

            string sendstrV = WriteVOLT ? "VOLT 1" : "VOLT 2";
            SerialPort.Write(sendstrV + "\r\n");

            ///发频率
            string freq = GetFrequency();
            string sendstr = "FREQ " + freq + "HZ";
            // "B_发送频率至LRC测试仪".log(sendstr);
            SerialPort.Write(sendstr + "\r\n");

            string type = "FUNC:IMP CPQ";
            SerialPort.Write(type + "\r\n");
        }

        /// <summary>
        /// 电阻类型指令
        /// </summary>
        private void RESTypeCommand()
        {
            string sendstrV = "VOLT 2";
            SerialPort.Write(sendstrV + "\r\n");

            ///发频率
            string freq = GetFrequency();
            string sendstr = "FREQ " + freq + "HZ";
            // "B_发送频率至LRC测试仪".log(sendstr);
            SerialPort.Write(sendstr + "\r\n");

            string type = "FUNC:IMP RX";
            SerialPort.Write(type + "\r\n");
        }

        /// <summary>
        /// 获取频率
        /// </summary>
        /// <param name="Vilue"></param>
        /// <param name="TestType"></param>
        /// <returns></returns>
        private string GetFrequency()
        {
            string LCR = "10K";

            int basic = 47;
            switch (Type)
            {
                case LCR_Type.Error:
                    break;

                case LCR_Type.电感:
                    break;
                case LCR_Type.电容:
                    if (UnitValue >= (basic * Math.Pow(10, -5)))
                    {
                        LCR = ParamManager.Instance.Clock_477.S;
                    }
                    else if (UnitValue >= (basic * Math.Pow(10, -6)))
                    {
                        LCR = ParamManager.Instance.Clock_476.S;
                    }
                    else if (UnitValue >= (basic * Math.Pow(10, -7)))
                    {
                        LCR = ParamManager.Instance.Clock_475.S;
                    }
                    else if (UnitValue >= (basic * Math.Pow(10, -8)))
                    {
                        LCR = ParamManager.Instance.Clock_474.S;
                    }
                    else if (UnitValue >= (basic * Math.Pow(10, -9)))
                    {
                        LCR = ParamManager.Instance.Clock_473.S;
                    }
                    else if (UnitValue >= (basic * Math.Pow(10, -10)))
                    {
                        LCR = ParamManager.Instance.Clock_472.S;
                    }
                    else if (UnitValue >= (basic * Math.Pow(10, -11)))
                    {
                        LCR = ParamManager.Instance.Clock_471.S;
                    }
                    else if (UnitValue >= (basic * Math.Pow(10, -12)))
                    {
                        LCR = ParamManager.Instance.Clock_470.S;
                    }
                    else if (UnitValue >= (basic * Math.Pow(10, -13)))
                    {
                        LCR = ParamManager.Instance.Clock_47.S;
                    }
                    else if (UnitValue >= (Math.Pow(10, -12)))
                    {
                        LCR = ParamManager.Instance.Clock_10.S;
                    }
                    else
                    {
                        LCR = ParamManager.Instance.Clock_1.S;
                    }
                    break;

                case LCR_Type.电阻:
                    if (UnitValue > (basic * Math.Pow(10, 5)))
                    {
                        LCR = ParamManager.Instance.Rlock_47D.S;
                    }
                    else if (UnitValue > (Math.Pow(10, 6)))
                    {
                        LCR = ParamManager.Instance.Rlock_47.S;
                    }
                    else if (UnitValue > (basic * Math.Pow(10, 4)))
                    {
                        LCR = ParamManager.Instance.Rlock_1.S;
                    }
                    else
                    {
                        LCR = ParamManager.Instance.Rlock_470.S;
                    }
                    break;

                case LCR_Type.其他:
                    break;

                default:
                    break;
            }
            return LCR;

        }

        /// <summary>
        /// 获取最大值
        /// </summary>
        private void SetMaxValue()
        {
            Max_Value = Value + Value * Grade / 100;
        }

        /// <summary>
        /// 获取最小值
        /// </summary>
        private void SetMinValue()
        {
            Min_Value = Value - Value * Grade / 100;
        }

        /// <summary>
        /// 转化单位Ω、F
        /// </summary>
        private void SetUnitValue()
        {
            double sta = Value;
            switch (Unit)
            {
                case Unit.mΩ:
                    sta = sta / 1000;
                    break;

                case Unit.Ω:
                    break;

                case Unit.KΩ:
                    sta = sta * 1000;
                    break;

                case Unit.MΩ:
                    sta = sta * 1000 * 1000;
                    break;

                case Unit.PF:
                    sta = sta / (1000000000000);
                    break;

                case Unit.NF:
                    sta = sta / (1000 * 1000 * 1000);
                    break;

                case Unit.UF:
                    sta = sta / (1000 * 1000);
                    break;

                case Unit.MF:
                    sta = sta / (1000);
                    break;

                case Unit.F:
                    break;

                default:
                    break;
            }
            UnitValue = sta;
        }

        /// <summary>
        /// 电表读值单位化
        /// </summary>
        public void SetUnitReadData(ref double data)
        {
            switch (Unit)
            {
                case Unit.mΩ:
                    data = data * 1000;
                    break;

                case Unit.Ω:
                    break;

                case Unit.KΩ:
                    data = data / 1000;
                    break;

                case Unit.MΩ:
                    data = data / 1000 / 1000;
                    break;

                case Unit.PF:
                    data = data * 1000000000000;
                    break;

                case Unit.NF:
                    data = data * 1000000000;
                    break;

                case Unit.UF:
                    data = data * 1000000;
                    break;

                case Unit.MF:
                    data = data * 1000;
                    break;

                case Unit.F:
                    break;

                default:
                    break;
            }
        }

        public string GetMaterial()
        {
            string size = Size.ToString();
            size = size.Replace("_", "").Trim();
            string grade = Grade + "%";
            return string.Format("{0}-{1}-{2}{3}-{4}", Type.ToString(), size, RealValue, Unit.ToString(), grade);
        }

        public void Log(string message)
        {
            LogManager.Instance.WriteLog(new LogModel(LogType.测值日志, message));
        }
    }


    /// <summary>
    /// LCR测值流程
    /// </summary>
    public enum LCRFlow
    {
        None,
        Start,//开始
        走一格,//到测值位置
        测值整体平移,
        测值定位,//相机拍照定位
        AB探针到位,
        下针,
        发送电表指令,
        增加补偿值,
        判断值是否在范围,//判断值是否在范围
        Finish//完成
    }

    public enum LCR_Type
    {
        Error,
        电感,
        电容,
        电阻,
        其他
    }

    public enum LCR_Size
    {
        Error,
        _01005,
        _0201,
        _0402,
        _0603,
        _0805,
        _1206,
        _1210
    }

    public enum Unit
    {
        Error,
        mΩ,
        Ω,
        KΩ,
        MΩ,
        PF,
        NF,
        UF,
        MF,
        F
    }

    /// <summary>
    /// 左边/右边
    /// </summary>
    public enum WhichSide
    {
        None,
        Left,
        Right
    }

    /// <summary>
    /// 两线/四线
    /// </summary>
    public enum WhichLine
    {
        None,
        L2,
        L4
    }

    /// <summary>
    /// 测值结果
    /// </summary>
    public enum LCRResult
    {
        None,
        Pass,
        Fail
    }
}
