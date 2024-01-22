using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionLibrary
{
    public abstract class MotionControl
    {
        public abstract AxisStatus[] AxisSt { get; set; }
        public abstract bool BInitializeFlag { get; }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        public abstract bool Initialize();

        /// <summary>
        /// 反初始化
        /// </summary>
        /// <returns></returns>
        public abstract bool Deinitialize();

        /// <summary>
        /// 关闭驱动器使能
        /// </summary>
        /// <param name="i_iAxisNum"></param>
        /// <returns></returns>
        public abstract bool RobotServoOff(int i_iAxisNum);

        /// <summary>
        /// 打开驱动器使能
        /// </summary>
        /// <param name="i_iAxisNum"></param>
        /// <returns></returns>
        public abstract bool RobotServoOn(int i_iAxisNum);

        /// <summary>
        /// 点位运动
        /// </summary>
        /// <param name="i_iAxisNum"></param>
        /// <param name="i_dPosition"></param>
        /// <returns></returns>
        public abstract bool RobotAbsMove(int i_iAxisNum, double i_dPosition);

        /// <summary>
        /// Step运动
        /// </summary>
        /// <param name="i_iAxisNum"></param>
        /// <param name="i_dOffset"></param>
        /// <returns></returns>
        public abstract bool MoveStep(int i_iAxisNum, double i_dOffset);

        /// <summary>
        /// JOG运动
        /// </summary>
        /// <param name="i_iAxisNum"></param>
        /// <returns></returns>
        public abstract bool MoveJog(int i_iAxisNum, int direction, int speedLevel = 1);

        /// <summary>
        /// 停止运动
        /// </summary>
        /// <param name="i_iAxisNum"></param>
        /// <returns></returns>
        public abstract bool MoveStop(int i_iAxisNum);

        /// <summary>
        /// 读取轴状态
        /// </summary>
        /// <param name="i_iAxisNum"></param>
        /// <returns></returns>
        public abstract bool RobotStatusRead(int i_iAxisNum);

        /// <summary>
        /// 读取轴位置
        /// </summary>
        /// <param name="i_iAxisNum"></param>
        /// <returns></returns>
        public abstract bool RobotPositionRead(int i_iAxisNum);

        /// <summary>
        /// 电子齿轮运动
        /// </summary>
        /// <param name="i_iAxisNum"></param>
        /// <param name="SlopVal"></param>
        /// <returns></returns>
        public abstract bool RobotGearMove(int i_iAxisNum, int SlopVal);

        /// <summary>
        /// 软件限位
        /// </summary>
        /// <param name="i_iAxisNum"></param>
        /// <param name="i_nPos"></param>
        public abstract bool Set_SoftLimit_P(int i_iAxisNum, int i_nPos);

        /// <summary>
        /// 坐标清零
        /// </summary>
        /// <param name="i_iAxisNum"></param>
        /// <returns></returns>
        public abstract bool Set_ZeroSet(int i_iAxisNum);

        public abstract void SetHomeFlag(int i_iAxisNum, int i_nNum);

        /// <summary>
        /// 设置Home偏移量
        /// </summary>
        /// <param name="i_iAxisNum"></param>
        /// <param name="i_nPos"></param>
        public abstract void Set_HomeOffset(int i_iAxisNum, int i_nPos);

        //public abstract bool GoHome(int i_iAxisNum);

        public abstract bool Set_HomeSearch(int i_iAxisNum, int i_nBackGap, int i_nMoveVel, int i_nHomeVel);

        //public abstract bool GoOrigin(int i_iAxisNum, int i_nMoveVel);

        public abstract bool Set_HomeSearchStop(int i_iAxisNum);

        public abstract void Read_OutExIO();

        public abstract int GetExIOBit(bool i_bInputFlag, string i_strIONum, int i_nNormalSignal);

        public abstract bool SetExIOBit(string i_strIONum, int i_nIOVal);

        public abstract int Read_OutIO(int i_strIONum);

        public abstract int Read_INIO(int i_strIONum);

        public abstract bool SetIOBit(int i_strIONum, short Val);

        /// <summary>
        /// 设置加速度
        /// </summary>
        /// <param name="i_iAxisNum"></param>
        /// <param name="i_nAccel"></param>
        public abstract void SetAccel(int i_iAxisNum, double i_nAccel);

        /// <summary>
        /// 设置目标速度
        /// </summary>
        /// <param name="i_iAxisNum"></param>
        /// <param name="i_dVelocity"></param>
        /// <param name="fastVelocity"></param>
        public abstract void SetSpeed(int i_iAxisNum, double i_dVelocity);

        public abstract bool WaitInpos(int i_iAxisNum, double dCheckPos);

        public abstract bool WaitInpos(int i_iAxisNum1, int i_iAxisNum2, double dCheckPos1, double dCheckPos2);

        public abstract bool WaitInpos(int i_iAxisNum1, int i_iAxisNum2, int i_iAxisNum3, double dCheckPos1, double dCheckPos2, double dCheckPos3);

        public abstract bool Set_SoftLimit_P(int i_iAxisNum, int positive, int negative);

        public abstract bool SetLeadScrewComp(int axis, int n, int startPos, int lenPos, int[] pCompPos, int[] pCompNeg);

        public abstract bool EnableLeadScrewComp(int axis, int mode);

        /// <summary>
        /// 设置回原点方式
        /// </summary>
        /// <param name="i_iAxisNum"></param>
        /// <param name="returnMode"></param>
        public abstract void SetReturnMode(int i_iAxisNum, ReturnMode returnMode);

        /// <summary>
        /// 设置坐标清零前延时
        /// </summary>
        /// <param name="i_iAxisNum"></param>
        /// <param name="delay"></param>
        public abstract void SetClearDelay(int i_iAxisNum, int delay);


    }
}
