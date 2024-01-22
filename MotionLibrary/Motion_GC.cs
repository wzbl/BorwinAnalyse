using GC.Frame.Motion.Privt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace MotionLibrary
{
    /// <summary>
    /// 高川运动控制卡
    /// </summary>
    public class Motion_GC : MotionControl
    {
        //定义控制器句柄
        private UInt16 Devhandle = 0;
        UInt16[] axisHandle = new UInt16[14];            // 轴句柄

        /// <summary>
        /// 控制器信息
        /// </summary>
        CNMCLib20.TCardInfo devInforMation = new CNMCLib20.TCardInfo();

        public override bool BInitializeFlag => throw new NotImplementedException();

        public override AxisStatus[] AxisSt { get ; set; }= new AxisStatus[4];

        public OptionMotion OptionMotion { get; set; } = new OptionMotion();

        public override bool Deinitialize()
        {
            CNMCLib20.NMC_DevClose(ref Devhandle);
            return true;
        }

        public override bool EnableLeadScrewComp(int axis, int mode)
        {
            throw new NotImplementedException();
        }

        public override int GetExIOBit(bool i_bInputFlag, string i_strIONum, int i_nNormalSignal)
        {
            throw new NotImplementedException();
        }

        public override bool Initialize()
        {

            for (int i = 0; i < AxisSt.Length; i++)
            {
                if (AxisSt[i]==null)
                {
                    AxisStatus axisStatus = new AxisStatus();
                    AxisSt[i] = axisStatus;
                }
            }
            OptionMotion.Load();

            short rtn = 0;
            short devnum = 0;
            byte[] devinfo = new byte[4 * 84];
            rtn = CNMCLib20.NMC_DevSearch(CNMCLib20.TSearchMode.Ethernet, ref devnum, devinfo);
            if (rtn == 0 && devnum > 0)
            {
                //仅打开第一个控制器
                rtn = CNMCLib20.NMC_DevOpen(0, ref Devhandle);
                if (rtn != 0)
                {
                    MessageBox.Show("提示:未连接上控制器");
                    return false;
                }
                // "提示:控制器已连接";s
                //获取控制器信息
                rtn = CNMCLib20.NMC_GetCardInfo(Devhandle, ref devInforMation);
                for (short i = 0; i < axisHandle.Length; i++)
                {
                    rtn = CNMCLib20.NMC_MtOpen(Devhandle, i, ref axisHandle[i]); // 打开轴
                }
            }
            else
            {
                MessageBox.Show("提示:未连接上控制器");
                ////"提示:未连接上控制器";
            }

            return false;
        }

        public override bool MoveJog(int i_iAxisNum, int direction, int speedLevel = 1)
        {
            CNMCLib20.NMC_MtMovePtpAbs((ushort)i_iAxisNum, 1, 1, 1, 1, 10, 1, 10);
            return true;
        }

        public void MovePtpAbs(double acc, double dec, double startVel, double endVel, double maxVel, Int16 smoothCoef, Int32 tgtPos)
        {
            CNMCLib20.NMC_MtMovePtpAbs(axisHandle[0], acc, dec, startVel, endVel, maxVel, smoothCoef, tgtPos);
        }

        public override bool MoveStep(int i_iAxisNum, double i_dOffset)
        {
            //CNMCLib20.NMC_MtMovePtpAbs(axisHandle[0], acc, dec, startVel, endVel, maxVel, smoothCoef, tgtPos);
            return true;
        }

        public override bool MoveStop(int i_iAxisNum)
        {
            CNMCLib20.NMC_MtStop(axisHandle[0]);
            return true;
        }

        public override int Read_INIO(int i_strIONum)
        {
            short Index = (short)i_strIONum;
            //short value = 0;
            //CNMCLib20.NMC_GetDOBit(Devhandle, Index, ref  value);
            CNMCLib20.NMC_GetDIGroup(Devhandle, out Int32 value, 0);

            int val = (int)Math.Pow(2, i_strIONum);

            int va = val & (Math.Abs(value) - 1);
            if (val == va)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public override void Read_OutExIO()
        {
            throw new NotImplementedException();
        }

        public override int Read_OutIO(int i_strIONum)
        {
            short Index = (short)i_strIONum;
            //short value = 0;
            //CNMCLib20.NMC_GetDOBit(Devhandle, Index, ref  value);
            CNMCLib20.NMC_GetDOGroup(Devhandle, out Int32 value, 0);

            int val = (int)Math.Pow(2, i_strIONum);

            int va = val & (Math.Abs(value) - 1);
            if (val == va)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public override bool RobotAbsMove(int i_iAxisNum, double i_dPosition)
        {
            throw new NotImplementedException();
        }

        public override bool RobotGearMove(int i_iAxisNum, int SlopVal)
        {
            throw new NotImplementedException();
        }

        public override bool RobotPositionRead(int i_iAxisNum)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 使能关闭
        /// </summary>
        /// <param name="i_iAxisNum"></param>
        /// <returns></returns>
        public override bool RobotServoOff(int i_iAxisNum)
        {
            short res = CNMCLib20.NMC_MtSetSvOff(axisHandle[i_iAxisNum]);
            if (res == 0)
            {
                return false;
            }
            else
            {
                return true;

            }
        }

        /// <summary>
        /// 使能打开
        /// </summary>
        /// <param name="i_iAxisNum"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override bool RobotServoOn(int i_iAxisNum)
        {
            short res = CNMCLib20.NMC_MtSetSvOn((axisHandle[i_iAxisNum]));
            if (res == 0)
            {
                return false;
            }
            else
            {
                return true;

            }
        }

        public override bool RobotStatusRead(int i_iAxisNum)
        {
            Int16 axsiSts = 0;
            CNMCLib20.NMC_MtGetSts(axisHandle[0], ref axsiSts);
            AxisSt[i_iAxisNum].IsRunning = (axsiSts & (1 << 0)) == 0 ? false : true; //取bit0,0静止,1运动
            AxisSt[i_iAxisNum].IsArrival = (axsiSts & (1 << 1)) == 0 ? false : true; //取bit1,位置到达,0,未到达,1到达
            bool IsError = (axsiSts & (1 << 2)) == 0 ? false : true; //取bit2,上次运动出错，或当前无法启动运动，需要软件复位,0,未出错,1,出错
            AxisSt[i_iAxisNum].Enabled = (axsiSts & (1 << 3)) == 0 ? false : true; //取bit3,是否使能中
            AxisSt[i_iAxisNum].PositiveLimit = (axsiSts & (1 << 6)) == 0 ? false : true;//取bit6,正向限位是否触发
            AxisSt[i_iAxisNum].NegativeLimit = (axsiSts & (1 << 7)) == 0 ? false : true;//取bit7,负向限位是否触发
            AxisSt[i_iAxisNum].PositiveSoftLimit = (axsiSts & (1 << 8)) == 0 ? false : true;//取bit8,正向软限位是否触发
            AxisSt[i_iAxisNum].NegativeSoftLimit = (axsiSts & (1 << 9)) == 0 ? false : true;//取bit9,负向软限位是否触发
            AxisSt[i_iAxisNum].DriveAlarm = (axsiSts & (1 << 10)) == 0 ? false : true;//取bit10,驱动器是否报警
            bool IsPosErr = (axsiSts & (1 << 11)) == 0 ? false : true;//取bit11,位置超限，需要软件复位
            bool IsESTP = (axsiSts & (1 << 12)) == 0 ? false : true;//取bit12,急停触发
            bool IsHWERR = (axsiSts & (1 << 13)) == 0 ? false : true;//取bit13,硬件错误
            bool IsCAPTSET = (axsiSts & (1 << 14)) == 0 ? false : true;//取bit14,捕获触发

            int axisPos = 0;
            CNMCLib20.NMC_MtGetAxisPos(axisHandle[0], ref  axisPos);   // 读取电机当前的理论位置
            AxisSt[i_iAxisNum].Position = axisPos;
            int encPos = 0;
            CNMCLib20.NMC_MtGetEncPos(axisHandle[0], ref encPos);     // 读取电机当前的实际位置
            AxisSt[i_iAxisNum].RealPosition = encPos;
            double axisVel = 0;
            CNMCLib20.NMC_MtGetPrfVel(axisHandle[0], ref axisVel);    // 读取当前规划的速度
            AxisSt[i_iAxisNum].AxisVel = axisVel;
            return true;
        }

        public override void SetAccel(int i_iAxisNum, double i_nAccel)
        {
            throw new NotImplementedException();
        }

        public override void SetClearDelay(int i_iAxisNum, int delay)
        {
            throw new NotImplementedException();
        }

        public override bool SetExIOBit(string i_strIONum, int i_nIOVal)
        {
            throw new NotImplementedException();
        }

        public override void SetHomeFlag(int i_iAxisNum, int i_nNum)
        {
            throw new NotImplementedException();
        }

        public override bool SetIOBit(int i_strIONum, short Val)
        {
            short res = CNMCLib20.NMC_SetDOBit(Devhandle, (short)i_strIONum, Val);
            return res == 0;
        }

        public override bool SetLeadScrewComp(int axis, int n, int startPos, int lenPos, int[] pCompPos, int[] pCompNeg)
        {
            throw new NotImplementedException();
        }

        public override void SetReturnMode(int i_iAxisNum, ReturnMode returnMode)
        {
            throw new NotImplementedException();
        }

        public override void SetSpeed(int i_iAxisNum, double i_dVelocity)
        {
            throw new NotImplementedException();
        }

        public override void Set_HomeOffset(int i_iAxisNum, int i_nPos)
        {
            throw new NotImplementedException();
        }

        public override bool Set_HomeSearch(int i_iAxisNum, int i_nBackGap, int i_nMoveVel, int i_nHomeVel)
        {

            CNMCLib20.THomeSetting homeSetup = new CNMCLib20.THomeSetting(true);         // 回零参数设置(根据自身机构特点配置)
            homeSetup.mode = (short)CNMCLib20.THomeMode.HM_MODE1;    // 回零模式(HM_MODE1单原点回零)
            homeSetup.dir = OptionMotion.AXIS[i_iAxisNum].HomeParam.HomeDir;              // 搜寻零点方向（必须）, 0:负向,1：正向,其它值无意义
            homeSetup.offset = OptionMotion.AXIS[i_iAxisNum].HomeParam.HomeOffset;           // 原点偏移
            homeSetup.scan1stVel = OptionMotion.AXIS[i_iAxisNum].HomeParam.HomeMoveVel;       // 基本搜寻速度
            homeSetup.scan2ndVel = OptionMotion.AXIS[i_iAxisNum].HomeParam.HomeSearchVel;       // 二次回零时使用，低速(建议小于10p/ms)，与参数reScanEn一起使用
            homeSetup.acc = OptionMotion.AXIS[i_iAxisNum].HomeParam.HomeMoveAcc;            // 加速度
            homeSetup.reScanEn = (byte)(OptionMotion.AXIS[i_iAxisNum].HomeParam.HomereScanEn ?1:0);         // 二次搜寻零点，与参数scan2ndVel一起使用
            homeSetup.homeEdge = (byte)(OptionMotion.AXIS[i_iAxisNum].HomeParam.HomeEdge ? 1 : 0);         // 原点，触发沿,下降沿
            homeSetup.lmtEdge = (byte)(OptionMotion.AXIS[i_iAxisNum].HomeParam.LmtEdge ? 1 : 0); ;          // 限位,触发沿(默认下降沿)
            homeSetup.zEdge = (byte)(OptionMotion.AXIS[i_iAxisNum].HomeParam.ZEdge ? 1 : 0); ;            // Z相位,触发沿(默认下降沿)
            homeSetup.iniRetPos = OptionMotion.AXIS[i_iAxisNum].HomeParam.HomeIniRetPos;        // 起始反向运动距离（可选,不用时设为0）
            homeSetup.retSwOffset = OptionMotion.AXIS[i_iAxisNum].HomeParam.HomeRetSwOffset;      // 反向运动时离开开关距离（可选,不用时设为0）
            homeSetup.safeLen = OptionMotion.AXIS[i_iAxisNum].HomeParam.HomeSafeDistance;          // 安全距离,回零时最远搜寻距离（可选,不用时设为0,不限制距离）
            homeSetup.usePreSetPtpPara = 0; //当usePreSetPtpPara=0时，回零运动的
                                            //减加速度默认等于acc,起跳速度、终点速度、平滑系数默认为0
             CNMCLib20.NMC_MtSetHomePara(axisHandle[i_iAxisNum], ref homeSetup);    // 设置回零参数
           
             CNMCLib20.NMC_MtHome(axisHandle[0]);   // 启动回零

            return true;
        }

        public override bool Set_HomeSearchStop(int i_iAxisNum)
        {
            CNMCLib20.NMC_MtHomeStop(axisHandle[0]);
            return true;
        }

        public override bool Set_SoftLimit_P(int i_iAxisNum, int i_nPos)
        {
            throw new NotImplementedException();
        }

        public override bool Set_SoftLimit_P(int i_iAxisNum, int positive, int negative)
        {
            throw new NotImplementedException();
        }

        public override bool Set_ZeroSet(int i_iAxisNum)
        {
            throw new NotImplementedException();
        }

        public override bool WaitInpos(int i_iAxisNum, double dCheckPos)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 等待一个轴到达指定位置
        /// </summary>
        /// <returns></returns>
        public override bool WaitInpos(int i_iAxisNum1, int i_iAxisNum2, double dCheckPos1, double dCheckPos2)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 等待一个轴到达指定位置
        /// </summary>
        public override bool WaitInpos(int i_iAxisNum1, int i_iAxisNum2, int i_iAxisNum3, double dCheckPos1, double dCheckPos2, double dCheckPos3)
        {
            throw new NotImplementedException();
        }
    }
}
