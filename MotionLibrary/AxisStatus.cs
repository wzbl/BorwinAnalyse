using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionLibrary
{
    /// <summary>
    /// 轴状态参数
    /// </summary>
    public class AxisStatus
    {
        /// <summary>
        /// 轴速度
        /// </summary>
        public double AxisVel;

        /// <summary>
        /// 轴规划位置
        /// </summary>
        public double Position;

        /// <summary>
        /// 轴实际位置
        /// </summary>
        public double RealPosition;

        /// <summary>
        /// 轴实际位置
        /// </summary>
        public bool IsArrival;

        /// <summary>
        /// 正限位状态
        /// </summary>
        public bool PositiveLimit;

        /// <summary>
        /// 负限位状态
        /// </summary>
        public bool NegativeLimit;

        /// <summary>
        /// 正向软限位状态
        /// </summary>
        public bool PositiveSoftLimit;

        /// <summary>
        /// 负向软限位状态
        /// </summary>
        public bool NegativeSoftLimit;

        /// <summary>
        /// 使能状态
        /// </summary>
        public bool Enabled;

        /// <summary>
        /// 运动状态
        /// </summary>
        public bool IsRunning;

        /// <summary>
        /// 驱动器报警标志
        /// </summary>
        public bool DriveAlarm;

        /// <summary>
        /// 回原点状态
        /// </summary>
        public int GoHomeStatus;

        /// <summary>
        /// 生成副本
        /// </summary>
        /// <param name="pTemp"></param>
        /// <param name="dRes"></param>
        public void Copy(AxisStatus pTemp, double dRes)
        {
            this.Position = Math.Round(pTemp.Position / dRes, 4);
            this.RealPosition = Math.Round(pTemp.RealPosition / dRes, 4);
            this.PositiveLimit = pTemp.PositiveLimit;
            this.NegativeLimit = pTemp.NegativeLimit;
            this.Enabled = pTemp.Enabled;
            this.IsRunning = pTemp.IsRunning;
            this.DriveAlarm = pTemp.DriveAlarm;
            this.GoHomeStatus = pTemp.GoHomeStatus;
        }

    }
}
