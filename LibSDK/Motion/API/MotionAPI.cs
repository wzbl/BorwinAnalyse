
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSDK.Motion
{
    public class MotionAPI : MotionBase
    {
        private readonly BoardSwitchCs Card = new BoardSwitchCs();
        public MotionAPI() { }

        #region 高速位置比较
        public bool CmpMode(short CardNum, short Axis, short group, short Hcmp, int time, short cmp_logic, int Mode)
        {
            return Card.API.CmpMode(CardNum, Axis, group, Hcmp, time, cmp_logic, Mode);
        }
        public bool AddCmpPoint(short CardNum, short Axis, short Hcmp, double Pos)
        {
            int _Pos = PosToPulse(Pos, CardNum, Axis);//位置换算

            return Card.API.addHcmpPoint(CardNum, Hcmp, _Pos);
        }
        public bool ClearHcmpPoint(short CardNum, short Hcmp)
        {
            return Card.API.ClearHcmpPoint(CardNum, Hcmp);
        }
        #endregion
        private CAxisParm GetAxisParm(short CardNum, short Axis)
        {
            CAxisParm ReturnParm = new CAxisParm();
            foreach (CAxisParm axisParm in AxisParm.AParms)
            {
                if (axisParm.AxisID == Axis && axisParm.CardID == CardNum)
                {
                    ReturnParm = axisParm;
                    break;
                }
            }
            return ReturnParm;
        }

        /// <summary>
        /// XY插补平移运动
        /// </summary>
        /// <param name="Vel">速度</param>
        /// <param name="Acc">加速度</param>
        /// <param name="Xpos">X轴位置</param>
        /// <param name="Ypos">Y轴位置</param>
        /// <param name="mode">运动模式</param>
        /// <returns></returns>
        public bool LinXyMoveA(double Vel, double Acc, double Xpos, double Ypos, short mode, bool IsLimt = true)
        {
            double _Spd = PosToVel(Vel, CardNum, 1);//速度换算
            double _Acc = PosToVcc(Acc, CardNum, 1);//加速度换算
            double Xpuse = Xpos * MotionControl.AxisParm.GetMotionPix(0, 1);
            double Ypuse = Ypos * MotionControl.AxisParm.GetMotionPix(0, 2);
            CAxisParm XaxisParm = GetAxisParm(0, 1);
            CAxisParm YaxisParm = GetAxisParm(0, 2);
            if (IsLimt)
            {
                if (Xpos > XaxisParm.PosLimit || Xpos <= 0)
                {
                    //SDK.Log.AddLog("X轴" + "目标位置超过软极限", 2);
                    //SDK.Alarm.Show("System Error", "S0002", "X轴" + "目标位置超过软极限", "I");
                    return false;
                }
                if (Ypos > YaxisParm.PosLimit || Ypos <= 0)
                {
                    //SDK.Log.AddLog("Y轴" + "目标位置超过软极限", 2);
                    //SDK.Alarm.Show("System Error", "S0002", "Y轴" + "目标位置超过软极限", "I");
                    return false;
                }
                else
                {
                    return Card.API.LinearInterMove(0, 0, 2, _Spd, _Acc, new ushort[] { 0, 1 }, new int[] { (int)Xpuse, (int)Ypuse }, (ushort)mode);
                }
            }
            else
            {
                return Card.API.LinearInterMove(0, 0, 2, _Spd, _Acc, new ushort[] { 0, 1 }, new int[] { (int)Xpuse, (int)Ypuse }, (ushort)mode);
            }
        }
        /// <summary>
        /// XY插补平移运动
        /// </summary>
        /// <param name="Vel">速度</param>
        /// <param name="Acc">加速度</param>
        /// <param name="Xpos">X轴位置</param>
        /// <param name="Ypos">Y轴位置</param>
        /// <param name="mode">运动模式</param>
        /// <param name="Spdpix">速度换算当量轴序号</param>
        /// <returns></returns>
        public bool LinXyMoveA(double Vel, double Acc, double Xpos, double Ypos, short mode, short Spdpix, bool IsLimt = true)
        {
            double _Spd = PosToVel(Vel, CardNum, Spdpix);//速度换算
            double _Acc = PosToVcc(Acc, CardNum, Spdpix);//加速度换算
            double Xpuse = Xpos * MotionControl.AxisParm.GetMotionPix(0, 1);
            double Ypuse = Ypos * MotionControl.AxisParm.GetMotionPix(0, 2);
            CAxisParm XaxisParm = GetAxisParm(0, 1);
            CAxisParm YaxisParm = GetAxisParm(0, 2);
            if (IsLimt)
            {
                if (Xpos > XaxisParm.PosLimit || Xpos <= 0)
                {
                    //SDK.Log.AddLog("X轴" + "目标位置超过软极限", 2);
                    //SDK.Alarm.Show("System Error", "S0002", "X轴" + "目标位置超过软极限", "I");
                    return false;
                }
                if (Ypos > YaxisParm.PosLimit || Ypos <= 0)
                {
                    //SDK.Log.AddLog("Y轴" + "目标位置超过软极限", 2);
                    //SDK.Alarm.Show("System Error", "S0002", "Y轴" + "目标位置超过软极限", "I");
                    return false;
                }
                else
                {
                    return Card.API.LinearInterMove(0, 0, 2, _Spd, _Acc, new ushort[] { 0, 1 }, new int[] { (int)Xpuse, (int)Ypuse }, (ushort)mode);
                }
            }
            else
            {
                return Card.API.LinearInterMove(0, 0, 2, _Spd, _Acc, new ushort[] { 0, 1 }, new int[] { (int)Xpuse, (int)Ypuse }, (ushort)mode);
            }

        }
        public bool LinZyMoveA(double Vel, double Acc, double Zpos, double Ypos, short mode)
        {
            double _Spd = PosToVel(Vel, CardNum, 3);//速度换算
            double _Acc = PosToVcc(Acc, CardNum, 3);//加速度换算
            double Zpuse = Zpos * MotionControl.AxisParm.GetMotionPix(0, 3);
            double Ypuse = Ypos * MotionControl.AxisParm.GetMotionPix(0, 2);
            return Card.API.LinearInterMove(0, 0, 2, _Spd, _Acc, new ushort[] { 1, 2 }, new int[] { (int)Ypuse, (int)Zpuse }, (ushort)mode);
        }

        public bool LinXyMoveB(double Vel, double Acc, double Xpos, double Ypos, short mode)
        {
            double _Spd = PosToVel(Vel, CardNum, 5);//速度换算
            double _Acc = PosToVcc(Acc, CardNum, 5);//加速度换算
            double Xpuse = Xpos * MotionControl.AxisParm.GetMotionPix(0, 5);
            double Ypuse = Ypos * MotionControl.AxisParm.GetMotionPix(0, 6);
            return Card.API.LinearInterMove(0, 1, 2, _Spd, _Acc, new ushort[] { 4, 5 }, new int[] { (int)Xpuse, (int)Ypuse }, (ushort)mode);
        }

        public bool LinZyMoveB(double Vel, double Acc, double Zpos, double Ypos, short mode)
        {
            double _Spd = PosToVel(Vel, CardNum, 7);//速度换算
            double _Acc = PosToVcc(Acc, CardNum, 7);//加速度换算
            double Zpuse = Zpos * MotionControl.AxisParm.GetMotionPix(0, 7);
            double Ypuse = Ypos * MotionControl.AxisParm.GetMotionPix(0, 6);
            return Card.API.LinearInterMove(0, 1, 2, _Spd, _Acc, new ushort[] { 5, 6 }, new int[] { (int)Ypuse, (int)Zpuse }, (ushort)mode);
        }
        /// <summary>
        /// 检查坐标系停止
        /// </summary>
        /// <returns></returns>
        public bool LinXYRuningA()
        {
            return Card.API.CrdRunning(0, 0);
        }
        public bool LinXYRuningB()
        {
            return Card.API.CrdRunning(0, 1);
        }

    }
}
