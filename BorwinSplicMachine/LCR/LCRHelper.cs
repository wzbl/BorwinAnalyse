using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
                BaudRate=115200,
                DataBits=8,
                Parity=Parity.None,
                StopBits=StopBits.One
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
        /// 单位
        /// </summary>
        public Unit Unit =Unit.Error;

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
        #endregion

        #region 公开方法
        public void OpenSerialPort()
        {
            try
            {
                if (SerialPort.IsOpen) SerialPort.Close();
                Thread.Sleep(1000);
                SerialPort.Open();
                if (SerialPort.IsOpen)
                {
                    //打开串口成功
                    SerialPort.DataReceived += SerialPort_DataReceived;
                }
                else
                {
                    //打开串口失败
                }
            }
            catch (Exception)
            {
                //打开串口失败
            }
        }

        /// <summary>
        /// 开始LCR测值
        /// </summary>
        public void StartLCR(LCR_Type Type, LCR_Size Size, double Value, Unit Unit, double Grade)
        {
            this.Type = Type;
            this.Size = Size;
            this.Value = Value;
            this.Unit = Unit;
            this.Grade = Grade;
            SetMaxValue();
            SetMinValue();
            if (IsOpenSerialPort)
            {
                SendTypeCommand();
            }
            SendPLCCommand();
        }


        /// <summary>
        /// 给电表写读值指令
        /// </summary>
        public void SendReadCommand()
        {
            SerialPort.DiscardInBuffer();
            SerialPort.Write("FETC?" + "\r\n");
        }

        /// <summary>
        /// 清除数据
        /// </summary>
        public void Clear()
        {

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
           
        }

        /// <summary>
        /// 测值信息发送给PLC
        /// </summary>
        private void SendPLCCommand()
        {

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
            //根据电压值发
            bool WriteVOLT = true;
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
                    if (Value >= (basic * Math.Pow(10, -5)))
                    {

                    }
                    else if (Value >= (basic * Math.Pow(10, -6)))
                    {

                    }
                    else if (Value >= (basic * Math.Pow(10, -7)))
                    {

                    }
                    else if (Value >= (basic * Math.Pow(10, -8)))
                    {

                    }
                    else if (Value >= (basic * Math.Pow(10, -9)))
                    {

                    }
                    else if (Value >= (basic * Math.Pow(10, -10)))
                    {

                    }
                    else if (Value >= (basic * Math.Pow(10, -11)))
                    {

                    }
                    else if (Value >= (basic * Math.Pow(10, -12)))
                    {

                    }
                    else if (Value >= (basic * Math.Pow(10, -13)))
                    {

                    }

                    break;
                case LCR_Type.电阻:
                    if (Value > (1 * Math.Pow(10, 6)))
                    {

                    }
                    else if (Value > (1 * Math.Pow(10, 5)))
                    {

                    }
                    else if (Value > (1 * Math.Pow(10, 4)))
                    {

                    }
                    else
                    {

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
            Max_Value = Value+ Value*Grade/100;
        }
        /// <summary>
        /// 获取最小值
        /// </summary>
        private void SetMinValue()
        {
            Min_Value = Value - Value * Grade / 100;
        }
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

}
