using GC.Motion;
using LibSDK.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GC.Motion.Scpt;

namespace LibSDK.Motion
{
    public abstract class MotionBase
    {
        protected static readonly object lockObj = new object();
        protected static bool IsCheck(string functionName, int rtnCode)
        {
            if (rtnCode!=0&& !MotionControl.ErrorCode.Contains(rtnCode))
            {
                string strErrorMessage = GetErrorMessage(functionName, rtnCode,false);
                if (string.IsNullOrEmpty(strErrorMessage)) return true;
                //if (SDK.Alarm.Show("System Error", "S0001", strErrorMessage, "I")) return false;
                //SDK.Log.AddLog(strErrorMessage, 2);
                return false;
            }
            return true;
        }
        protected static bool IsCheck(string functionName, int rtnCode, string CardType)
        {
            if (rtnCode!=0 &&!MotionControl.ErrorCode.Contains(rtnCode))
            {
                string strErrorMessage = GetErrorMessage(functionName, rtnCode, true);
                if (string.IsNullOrEmpty(strErrorMessage)) return true;
                //if (SDK.Alarm.Show("System Error", "S0001", strErrorMessage, "I")) return false;
                //SDK.Log.AddLog(strErrorMessage, 2);
                return false;
            }
            return true;
        }
        private static string GetErrorMessage(string functionName, int errNum,bool IsIoCard)
        {
            if (errNum == 0) return string.Empty;
            string parseResult;
            if (IsIoCard)
            { parseResult = ErrorClass.Error((short)errNum, MotionControl.EnumControl.CardType); }
            else
            {
                parseResult = ErrorClass.IoError((short)errNum, MotionControl.EnumControl.IOType);
            }
            return string.Format("API:{0},Functions return error code is:{1},error define description is:{2}",functionName, errNum, parseResult.ToString());
        }
        protected static void ShowErrorMessage(string functionName, int rtnCode,string ErrorMessage)
        {
            string strErrorMessage= string.Format("API:{0},Functions return error code is:{1},error define description is:{2}", functionName, rtnCode, ErrorMessage);
            //if (SDK.Alarm.Show("System Error", "S0001", strErrorMessage, "I")) return;
            //SDK.Log.AddLog(strErrorMessage, 2);
        }
        /// <summary>
        /// 按位获取一个Int数值Bit的状态
        /// </summary>
        /// <param name="pValue">返回结果</param>
        /// <param name="bitIndex"></param>
        /// <returns></returns>
        protected virtual bool GetBitState(int pValue, int bitIndex)
        {
            int bit = 0x01;
            bit <<= bitIndex;
            if ((pValue & bit) == bit) return false;
            return true;
        }
        /// <summary>
        /// 指令返回值
        /// </summary>
        protected bool Rtn { get; set; }
        /// <summary>
        /// API返回值short类型
        /// </summary>
        protected short rtn { get; set; }
        /// <summary>
        /// 指令返回值
        /// </summary>
        protected static bool rtn_Static { get; set; }
        /// <summary>
        /// 当前轴名称
        /// </summary>
        public string Name { get; set; } = "Default Motor";
        /// <summary>
        /// 当前轴号.
        /// </summary>
        public short Axis { get; set; }
        /// <summary>
        /// 当前卡号.
        /// </summary>
        public short CardNum { get; set; }
        /// <summary>
        /// 马达类型
        /// </summary>
        public MotorType MotorType { get; set; }

        public int Cardtype { get; set; } = 0;

        /// <summary>
        /// mm转换为脉冲数.
        /// </summary>
        /// <param name="pos">位置,单位:mm</param>
        /// <returns></returns>
        protected virtual int PosToPulse(double pos,short CardNum,short Axis)
        {
            return (int)(pos * MotionControl.AxisParm.GetMotionPix(CardNum, Axis));
        }
        /// <summary>
        /// 脉冲数装换为mm。
        /// </summary>
        /// <param name="distance">脉冲个数,单位:脉冲/毫秒</param>
        /// <returns></returns>
        protected virtual double PulseToPos(int pulse, short CardNum, short Axis)
        {
          return pulse / MotionControl.AxisParm.GetMotionPix(CardNum, Axis);
        }
        /// <summary>
        /// 速度单位转换,毫米/秒转换为脉冲/毫秒
        /// </summary>
        /// <param name="vel"></param>
        /// <returns></returns>
        protected virtual double PosToVel(double vel, short CardNum, short Axis)
        {
            double value = 0;
            switch(MotionControl.EnumControl.CardType)
            {
                default :
                    value= vel * MotionControl.AxisParm.GetMotionPix(CardNum, Axis);
                    break;
                case CardType.GCS:
                    value = vel * MotionControl.AxisParm.GetMotionPix(CardNum, Axis)/1000;
                    break;
            }
            return value;
            
        }
        /// <summary>
        /// 速度单位转换,脉冲/毫秒转换为毫米/秒
        /// </summary>
        /// <param name="vel"></param>
        /// <returns></returns>
        protected virtual double VelToPos(double vel, short CardNum, short Axis)
        {
            double value = 0;
            switch (MotionControl.EnumControl.CardType)
            {
                default:
                    value= vel / MotionControl.AxisParm.GetMotionPix(CardNum, Axis);
                    break;
                case CardType.GCS:
                    value = vel / MotionControl.AxisParm.GetMotionPix(CardNum, Axis)*1000;
                    break;
            }
            return value;
        }
        /// <summary>
        /// 加速度单位转换,mm/s^2转换为pulse/ms^2
        /// <param name="Acc"></param>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        protected virtual double PosToVcc(double Acc, short CardNum, short Axis)
        {
            return Acc * MotionControl.AxisParm.GetMotionPix(CardNum, Axis) / 1000000;
        }
        /// <summary>
        /// 加速度单位转换,pulse/ms^2转换为mm/s^2
        /// </summary>
        /// <param name="Acc"></param>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        protected virtual double VccToPos(double Acc, short CardNum, short Axis)
        {
            return Acc /MotionControl.AxisParm.GetMotionPix(CardNum, Axis) * 1000000;
        }

        /// <summary>
        ///  Scpt初始化
        /// </summary>
        /// <param name="cardNum"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public virtual bool ScptIni(int instIdx, short cardNum) { return false; }

        /// <summary>
        /// 下载bin文件
        /// </summary>
        /// <returns></returns>
        public virtual bool ScpDownLoad(int idx, string filepath, short Autorun){ return false; }
        /// <summary>
        /// 配置自动运行参数
        /// </summary>
        /// <param name="idx">实例序号【0-7】</param>
        /// <param name="AutorunEn">是否自启动，1：开机自启动，0：开机不自启动 </param>
        /// <param name="AutorunDisGpiindex">
        /// 开机自启动跳过 DI（开机时，此 di 有输入，则跳过自
        ///  启动）, 取值范围[0, 16]，0 表示不设置该选项</param>
        /// <returns></returns>
        public virtual bool ScpRunconfig(int idx, short AutorunEn, short AutorunDisGpiindex) { return false; }
        /// <summary>
        /// 运行控制
        /// </summary>
        /// <param name="idx">实例序号，取值范围[0,7]</param>
        /// <param name="flag">
        /// RUN_CTRL_RUN 1 // 启动运行
        /// RUN_CTRL_STOP 2 // 停止运行
        //  RUN_CTRL_PAUSE 3 // 暂停
        /// RUN_CTRL_HOME 4 // 回零
        /// RUN_CTRL_EMG 5 // 急停
        /// RUN_CTRL_RESET 6 // 复位控制器
        /// RUN_CTRL_CLR 7 // 清除错误状态</param>
        /// <returns></returns>
        public virtual bool ScpRun(int idx, int flag) { return false; }
        /// <summary>
        /// 获取脚本运行及控制器等状态
        /// </summary>
        /// <param name="idx">实例序号，取值范围[0,7]</param>
        /// <param name="pSts">
        /// TScptStsUser:
        /// float axisPos[RS_MAX_AXIS_NUM];// 电机位置
        /// float encPos[RS_MAX_AXIS_NUM]; // 编码器位置
        /// short axisSts[RS_MAX_AXIS_NUM];// 电机状态
        /// short motionIO[RS_MAX_AXIS_NUM];// 专用 IO 状态
        /// long di1; // 数字量输入组 1 的状态
        /// long di2; // 数字量输入组 2 的状态
        /// long do1; // 数字量输出组 1 的状态
        /// long do2; // 数字量输出组 3 的状态
        ///          // run status
        /// short runState; //脚本 runtime 的运行状态
        /// short errCode; // 错误代码
        /// short bitFlag; //标志位，是否回零、是否配置等
        /// short currentLine; //当前运行的行号
        /// short errLine; // 当前出错的行号
        /// short watchVLen; // watch 变量值的长度
        /// short outputLen; // output 的长度
        /// short reserve;
        /// char data[512];
        /// </param>
        /// <returns></returns>
        public virtual bool ScptGetStatus(int idx, ref Scpt.TScptStsUser pSts) { return false; }
        /// <summary>
        /// 用户变量读取 
        /// </summary>
        /// <param name="idx">实例序号，取值范围[0,7]</param>
        /// <param name="VarType">变量类型，0:double,1:float,2:Int32,3:Int16</param>
        /// <param name="varidx">变量序号,取值范围[1,max]</param>
        /// <returns>读回的数值 -1读取失败</returns>
        public virtual double ScpUserVarRead(int idx, short VarType, short varidx) { return 0; }
        /// <summary>
        /// 用户变量写入
        /// </summary>
        /// <param name="idx">实例序号，取值范围[0,7]</param>
        /// <param name="VarType">变量类型，0:double,1:float,2:Int32,3:Int16</param>
        /// <param name="varidx">变量序号,取值范围[1,max]</param>
        /// <param name="Val">写的数值</param>
        /// <returns></returns>
        public virtual bool ScpUserVarWrite(int idx, short VarType, short varidx, double Val) { return false; }
        /// <summary>
        /// 用户变量读取（多个）
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="VarType"></param>
        /// <param name="varidx"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public virtual double[] ScpUserVarReadEx(int idx, short VarType, short varidx, short count) { return null; }
        /// <summary>
        /// 用户变量写入（多个） 
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="VarType"></param>
        /// <param name="varidx"></param>
        /// <param name="count"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public virtual bool ScpUserVarWriteEx(int idx, short VarType, short varidx, short count, double[] values) { return false; }

        /// <summary>
        /// 设置全局变量值 
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="pVarName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual bool ScpSetGlobalVarValue(int idx, string pVarName, double value) { return false; }
        /// <summary>
        /// 读全局变量值
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="pVarName"></param>
        /// <returns></returns>
        public virtual double ScpGetGlobalVarValue(int idx, string pVarName) { return 0; }
        /// <summary>
        /// 带任务启动掩码的启动运行 
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="taskMask"></param>
        /// <returns></returns>
        public virtual bool ScpRunEx(int idx, int taskMask) { return false; }
        /// <summary>
        /// 获取任务的运行状态
        /// </summary>
        /// <param name="idx">实例序号，取值范围[0,7] </param>
        /// <param name="taskIdx">任务序号，取值范围[0,8] </param>
        /// <param name="pSts"> 
        /// 
        /// 获取的任务状态定义如下： 
        /// #define TASK_RUN_STS_DIS -1  // not active 
        /// #define TASK_RUN_STS_STOP 0  // stopped 
        /// #define TASK_RUN_STS_RUN 1  // running 
        /// define TASK_RUN_STS_ERR 2  // error 
        ///typedef struct TScptTaskSts
        ///{
        ///  short runState;       //脚本runtime的运行状态 
        ///  short errCode;        // 错误代码 
        ///  long runLine;    // 运行行数 
        ///  short reserved[4];   // 保留 
        ///}
        ///TScptTaskSts; 
        /// </param>
        /// <returns></returns>
        public virtual bool ScpGetTaskSts(int idx, short taskIdx, ref TScptTaskSts pSts) { return false; }
    }
}
