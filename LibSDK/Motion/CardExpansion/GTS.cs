/******************************************************************************
 * LibSDK 控件库、工具类库、扩展类库、多页面开发框架。
 * 作    者：Zhuxingang
 * * EMail：xinguangzhuemail@163.com
 * * 版权信息：版权所有 (c) 2020, , 保留所有权利
 ******************************************************************************
 * 文件名称: CMotion.cs
 * 文件说明: 运动控制类
 * 当前版本: V2.2
 * 创建日期: 2021-06-06
 *
 * 2020-06-06: V2.2.5 增加文件说明
******************************************************************************/
using GC.Frame.Motion.Privt;
using gts;
using System;
using System.Threading;
using System.Windows.Forms;

namespace LibSDK.Motion
{
    class GTS : MotionBase, CardInterface
    {
        public bool  HomeStop { get; set; }

        public bool HomeRuning { get; set; }

        public static bool[] boolReadALL = new bool[256];
        
        public static bool[] boolReadOutALL = new bool[256];

        private float MyDimensionMaxVel = 5000;//坐标系最大速度(单位 mm/s)

        private float MyDimensionMaxAcc = 40000;//坐标系最大加速度（单位 mm/s^2）
        public GTS() { }
        /// <summary>
        /// 板卡初始化
        /// </summary>
        /// <param name="CardNum">卡号</param>
        /// <param name="CardFile">配置文件名称</param>
        /// <returns>调用成功返回(True)否则(False)</returns>
        public bool CrdIni(short CardNum, string CardFile)
        {
            Rtn = IsCheck("GT_Open", mc.GT_Open(0, 0, 1));
            if (Rtn)
                Rtn = IsCheck("GT_Reset", mc.GT_Reset(0));
            if (Rtn)
                Rtn = IsCheck("GT_LoadConfig", mc.GT_LoadConfig(0, CardFile));
            return Rtn;
        }
        public  bool CloseCard(short CardNum = 0)
        {
            return IsCheck("GT_Close", mc.GT_Close(CardNum));
        }
        /// <summary>
        /// 初始化扩展
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="FileName">[0]DLL名称，[1]扩展配置文件名称</param>
        /// <returns></returns>
        public bool ExMdlIni(short CardNum, int MdlNum, params string[] FileName)
        {
            if (Rtn)
                Rtn = IsCheck("GT_OpenExtMd", mc.GT_OpenExtMdl(CardNum, "gts.dll"));
            if (Rtn)
                Rtn = IsCheck("GT_ResetExtMdl", mc.GT_ResetExtMdl(CardNum));
            if (Rtn)
                IsCheck("GT_LoadExtConfig", mc.GT_LoadExtConfig(CardNum, FileName[1]));
            return Rtn;
        }
        /// <summary>
        /// 清除轴状态
        /// </summary>
        /// <param name="CardNum">卡号</param>
        /// <param name="Axis">起始轴</param>
        /// <returns></returns>
        public bool ClearAxisState(short CardNum, short Axis)
        {
            return IsCheck("mc.GT_ClrSts", mc.GT_ClrSts(CardNum, Axis, 1));
        }

        public bool Servon(short CardNum, short Axis)
        {
            return IsCheck("GT_AxisOn", mc.GT_AxisOn(CardNum, Axis));
        }

        public bool Servoff(short CardNum, short Axis)
        {
            return IsCheck("GT_AxisOff", mc.GT_AxisOff(CardNum, Axis));
        }
        /// <summary>
        /// 清除轴状态
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        public bool ClrSts(short CardNum, short Axis)
        {
           return IsCheck("GT_ClrSts", mc.GT_ClrSts(CardNum, Axis, 1));
        }
        /// <summary>
        /// 读取轴状态
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <param name="pSts"></param>
        /// <returns></returns>
        public bool GetSts(short CardNum, short Axis, out int pSts)
        {
            uint pClock;
            return IsCheck("GT_GetSts", mc.GT_GetSts(CardNum, Axis, out pSts, 1, out pClock));
        }
        /// <summary>
        /// 先清除，后读取轴状态
        /// </summary>
        /// <param name="pSts"></param>
        /// <returns></returns>
        public bool ClrGetSts(short CardNum, short Axis,out int pSts)
        {
            pSts = 0;
            if (!this.ClrSts(CardNum, Axis)) return false;
            if (!this.GetSts(CardNum, Axis,out pSts)) return false;
            return true;

        }
        private bool GetBitStatus(short CardNum, short Axis,int bitIndex)
        {
            int pSts;
            uint bit = 0x01;
            bit <<= bitIndex;
            if (!ClrGetSts(CardNum, Axis, out pSts)) return false;
            if ((pSts & bit) == bit) return true;
            return false;
        }
        /// <summary>
        ///  伺服报警信号。
        /// </summary>
        public  bool Mot_ALM(short CardNum, short Axis)
        {
            return GetBitStatus(CardNum, Axis,1);
        }
        /// <summary>
        /// 读取正限位信号
        /// </summary>
        public  bool Mot_PEL(short CardNum, short Axis)
        {
          return GetBitStatus(CardNum, Axis,5);
        }
        /// <summary>
        /// 读取负限位信号
        /// </summary>
        public bool Mot_NEL(short CardNum, short Axis)
        {
          return GetBitStatus(CardNum, Axis, 6);
        }
        /// <summary>
        /// 读取原点信号
        /// </summary>
        public  bool Mot_ORG(short CardNum, short Axis)
        {
            int pValue;
            Rtn = IsCheck("GT_GetDi", mc.GT_GetDi(CardNum, mc.MC_HOME, out pValue));
            return this.GetBitState(pValue, Axis - 1);            
        }

        public bool  Mot_SLN(short CardNum, short Axis)
        {
            return false;
        }

        public bool Mot_SLP(short CardNum, short Axis)
        {
            return false;
        }
        /// <summary>
        /// 检测电机运行状态
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        public  bool Mot_Running(short CardNum, short Axis)
        {
           return GetBitStatus(CardNum, Axis, 10);
        }
        /// <summary>
        /// 获取电机到位标志
        /// </summary>
        public bool GetCheckDone(short CardNum, short Axis)
        {
          return this.GetBitStatus(CardNum, Axis,11);
        }

        /// <summary>
        /// 读取电机的使能信号，高电平输出。
        /// </summary>
        public  bool SevOn(short CardNum, short Axis)
        {
          return this.GetBitStatus(CardNum, Axis, 9);
        }

        public bool SetSofLimit(short CardNum, short Axis,bool Enable, double P_Limit, double N_Limit)
        {
            return false;
        }
        public bool SetELMode(short CardNum, short Axis, short El_Enable, short EL_Logic, short EL_Mode)
        {
            return false;
        }
        /// <summary>
        /// 读取规划位置
        /// </summary>
        /// <param name="pValue"></param>
        /// <returns></returns>
        public double GetPrfPluse(short CardNum, short Axis)
        {
            uint pClock;
            double pValue;
            IsCheck("GT_GetPrfPos", mc.GT_GetPrfPos(CardNum, (short)(Axis-1),out pValue,1, out  pClock));
            return pValue;
        }
        /// <summary>
        /// 读取轴的编码器位置值
        /// </summary>
        public double GetEncPluse(short CardNum, short Axis)
        {
            uint pClock;
            double pValue;
            IsCheck("GT_GetPrfPos", mc.GT_GetEncPos(CardNum, (short)(Axis - 1), out pValue, 1, out pClock));
            return pValue;
        }
        /// <summary>
        /// 读取规划速度
        /// </summary>
        public double GetPrfVel(short CardNum, short Axis)
        {
            uint pClock;
            double pValue;
            IsCheck("GT_GetPrfVel", mc.GT_GetPrfVel(CardNum, Axis, out  pValue ,1,out pClock));
            return pValue;
        }
        /// <summary>
        /// 读取编码器速度值
        /// </summary>
        public double GetEncVel(short CardNum, short Axis)
        {
            double pValue;
            uint pClock;
            IsCheck("GT_GetEncVel", mc.GT_GetEncVel(CardNum, Axis, out pValue, 1, out pClock));
            return pValue;
        }
        /// <summary>
        /// 读取轴的规划加速度值.单位mm/s2.
        /// </summary>
        public double GetPrfAcc(short CardNum, short Axis)
        {
            double pValue;
            uint pClock;
            IsCheck("GT_GetPrfAcc", mc.GT_GetPrfAcc(CardNum, Axis, out pValue, 1, out pClock));
            return pValue;
        }
        /// <summary>
        /// 读取轴的编码器加减速度值.单位mm/s2.
        /// </summary>
        public double GetEncAcc(short CardNum, short Axis)
        {
            double pValue;
            uint pClock;
            IsCheck("GT_GetAxisEncAcc", mc.GT_GetAxisEncAcc(CardNum, Axis,out pValue,1, out pClock));
            return pValue;
        }
        /// <summary>
        /// 读取轴(axis)的规划位置值和编码器位置值的差值
        /// </summary>
        public double GetAxisError(short CardNum, short Axis)
        {
            double pValue;
            uint pClock;
            IsCheck("GT_GetAxisError", mc.GT_GetAxisError(CardNum, Axis, out pValue,1,out pClock));
            return pValue;
        }
        /// <summary>
        /// 获取轴的运动模式
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        public string GetPrfMode(short CardNum, short Axis)
        {
            int pValue;
            uint pClock;
            string PrfMode=null;
            IsCheck("GT_GetPrfMode", mc.GT_GetPrfMode(CardNum, Axis, out pValue, 1, out pClock));
            switch (pValue)
            {
                case 0:
                    PrfMode = "点位运动";
                    break;
                case 1:
                    PrfMode = "Jog";
                    break;
                case 2:
                   PrfMode = "PT";
                    break;
                case 3:
                   PrfMode = "电子齿轮";
                    break;
                case 4:
                    PrfMode = "Follow";
                    break;
                case 5:
                    PrfMode = "插补";
                    break;
                case 6:
                    PrfMode = "Pvt";
                    break;
            }
            return PrfMode;
        }
        /// <summary>
        /// 设置正向软限位和负向软限位
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <param name="positive"></param>
        /// <param name="negative"></param>
        /// <returns></returns>
        public bool SetSoftLimit(short CardNum, short Axis,int positive, int negative)
        {
            return IsCheck("GT_SetSoftLimit", mc.GT_SetSoftLimit(CardNum, Axis, positive, negative));
        }

        /// <summary>
        /// 读取正向软限位和负向软限位
        /// </summary>
        /// <param name="pPositive"></param>
        /// <param name="pNegative"></param>
        /// <returns></returns>
        public bool GetSoftLimit(short CardNum, short Axis, out int pPositive, out int pNegative)
        {
            return IsCheck("GT_GetSoftLimit", mc.GT_GetSoftLimit(CardNum,Axis, out pPositive, out pNegative));
        }

        #region IO操作
        /// <summary>
        /// 设置板卡IO输出
        /// </summary>
        /// <param name="DoNum">0-15号IO数组状态为普通IO</param>
        /// <param name="value">输出电平（1为高，0为低）</param>
        public bool SetDo(short CardNum, short IoNum, short value)
        {
            lock (lockObj)
            {
                short DoValue = 0;
                if (value == 1)
                {
                    DoValue = 0;
                    IsCheck("mc.GT_SetDoBit", mc.GT_SetDoBit(CardNum, mc.MC_GPO, IoNum, DoValue));
                }
                if (value == 0)
                {
                    DoValue = 1;
                    IsCheck("mc.GT_SetDoBit", mc.GT_SetDoBit(CardNum, mc.MC_GPO, IoNum, DoValue));
                }

            }
            return true;
        }
        /// <summary>
        /// 读取板卡IO输出
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="DoNum"></param>
        /// <returns></returns>
        public bool GetDo(short CardNum, short IoNum)
        {
            lock (lockObj)
            {
                int PValue;
                if (!IsCheck("mc.GT_GetDo", mc.GT_GetDo(CardNum, mc.MC_GPO, out PValue))) return false;
                return GetBitState(PValue, IoNum - 1);
            }
        }
        /// <summary>
        /// 读取板卡IO输入
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="DoNum"></param>
        /// <param name="pvalue"></param>
        public  bool GetDi(short CardNum, short IoNum)
        {
            lock(lockObj)
            {
                int PValue;
                if (!IsCheck("mc.GT_GetDi", mc.GT_GetDi(CardNum, mc.MC_GPI, out PValue))) return false;
                return GetBitState(PValue, IoNum - 1);
            }
        }
        /// <summary>
        /// 读取正限
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="DoNum"></param>
        /// <returns></returns>
        public  bool P_EL(short CardNum, short Axis)
        {
            lock (lockObj)
            {
                int PValue;
                IsCheck("mc.GT_GetDi", mc.GT_GetDi(CardNum, mc.MC_LIMIT_POSITIVE, out PValue));
                return GetBitState(PValue, Axis - 1);
            }
        }
        /// <summary>
        /// 读取负限位
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="DoNum"></param>
        /// <returns></returns>
        public bool N_EL(short CardNum, short Axis)
        {
            lock(lockObj)
            {
                int PValue;
                IsCheck("mc.GT_GetDi", mc.GT_GetDi(CardNum, mc.MC_LIMIT_NEGATIVE, out PValue));
                return GetBitState(PValue, Axis - 1);
            }
        }

        /// <summary>
        /// 读原点
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="DoNum"></param>
        /// <returns></returns>
        public bool ORG(short CardNum, short Axis)
        {
            lock (lockObj)
            {
                IsCheck("mc.GT_GetDi", mc.GT_GetDi(CardNum, mc.MC_HOME, out int PValue));
                return GetBitState(PValue, Axis - 1);
            }
        }

        /// <summary>
        /// 读取驱动器报警
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        public bool ALM(short CardNum, short Axis)
        {
            lock (lockObj)
            {
                IsCheck("mc.GT_GetDi", mc.GT_GetDi(CardNum, mc.MC_ALARM, out int PValue));
                return GetBitState(PValue, Axis - 1);
            }
        }
        /// <summary>
        /// 设置扩展模块IO输出
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="mdl"></param>
        /// <param name="DoNum"></param>
        /// <param name="value"></param>
        public bool SetExtmdlDO(short CardNum,  short mdl ,short IoNum, ushort value)
        {
            lock (lockObj)
            {
                int Num = (int)(IoNum - 1);
                ushort ExtDoValue;
                if (value == 1)
                {
                    ExtDoValue = 0;
                    IsCheck("mc.GT_SetExtIoBit", mc.GT_SetExtIoBit(CardNum, mdl, (short)(Num), ExtDoValue));
                }
                if (value == 0)
                {
                    ExtDoValue = 1;
                    IsCheck("mc.GT_SetExtIoBit", mc.GT_SetExtIoBit(CardNum, mdl, (short)(Num), ExtDoValue));
                }
            }
            return true;
        }

        /// <summary>
        /// 读取扩展模块IO输入
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="mdl"></param>
        /// <param name="DoNum"></param>
        /// <returns></returns>
        public bool GetExtmdDi(short CardNum, short mdl, short IoNum)
        {
            lock (lockObj)
            {
                ushort pValue;
                int ExtDoNum = (int)(IoNum - 1);
                if (!IsCheck("mc.GT_GetExtIoBit", mc.GT_GetExtIoBit(CardNum, mdl, (short)(ExtDoNum), out pValue))) return false;
                return pValue == 1 ? false : true;
            }
        }

        /// <summary>
        /// 读取扩展模块IO输出
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="mdl"></param>
        /// <param name="DoNum"></param>
        /// <returns></returns>
        public  bool GetExtmdDO(short CardNum, short mdl, short IoNum)
        {
            lock (lockObj)
            {
                ushort PValue;
                if (!IsCheck("mc.GT_GetExtDoValue", mc.GT_GetExtDoValue(CardNum, mdl, out PValue))) return false;
                return GetBitState(PValue, Axis - 1);
            }
        }
        #endregion

        #region 单轴Jog运动
        /// <summary>
        /// 单轴Jog运动
        /// </summary>
        /// <param name = "Axis" > Jog轴号（从1开始计算）</param>
        /// <param name = "Direction" > 方向（-1为负，1为正）</param>
        public bool JogMove(short CardNum, short Axis, short Direction, double Vel)
        {
            Rtn= ClrSts(CardNum, Axis);//清除各轴报警和限位
            if (Rtn)
            Rtn= IsCheck("GT_PrfJog", mc.GT_PrfJog(CardNum, Axis));//设置为jog模式
            mc.TJogPrm MyTJogPrm = new mc.TJogPrm();
            MyTJogPrm.acc = 0.25; MyTJogPrm.dec = 0.25;
            if (Rtn)
            Rtn=IsCheck("GT_SetJogPrm",mc.GT_SetJogPrm(CardNum, Axis,ref MyTJogPrm));
            if (Rtn)
            Rtn=IsCheck("GT_SetVel", mc.GT_SetVel(CardNum, Axis, Direction*Vel));
            if (Rtn)
            Rtn=IsCheck("GT_Update", mc.GT_Update(CardNum, 1 << (Axis - 1)));
            return Rtn;
        }
        #endregion

        public void ChangeSpeed(short CardNum, short Axis, double Vel)
        {

        }
        #region 单轴点位运动
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <param name="Pos"></param>
        /// <param name="Vel"></param>
        /// <param name="Acc"></param>
        /// <param name="RunMode">0,相对运动模式 1,绝对运动模式</param>
        /// <returns></returns>
        public bool PMove(short CardNum, short Axis, double Pos, double Vel,double Acc,int RunMode=1)
        {
            Rtn = IsCheck("GT_PrfTrap", mc.GT_PrfTrap(CardNum, Axis));//设置点位模式
            mc.TTrapPrm myTTrapPrm = new gts.mc.TTrapPrm();
            myTTrapPrm.acc = Acc;  //加速度  脉冲/毫秒2
            myTTrapPrm.dec = 0.125;//减速度
            myTTrapPrm.velStart =30;//起始速度
            myTTrapPrm.smoothTime=5;//平滑时间
            double NowPos=GetPrfPluse(CardNum, Axis);
            double RunPos = 0; ;
            if(RunMode==0)
            {
                RunPos = NowPos + Pos;
            }
            else if(RunMode ==1)
            {
                RunPos = Pos;
            }
            if (Rtn)
                Rtn = IsCheck("GT_SetTrapPrm", mc.GT_SetTrapPrm(CardNum, Axis, ref myTTrapPrm));
            if (Rtn)
                Rtn=IsCheck("GT_SetPos", mc.GT_SetPos(CardNum, Axis, (int)RunPos));
            if (Rtn)
                Rtn=IsCheck("GT_SetVel", mc.GT_SetVel(CardNum, Axis, Vel));
            if (Rtn)
                Rtn = IsCheck("", mc.GT_Update(CardNum, 1 << (Axis - 1)));
            return Rtn;
        }

        public bool S_PMove(short CardNum, short Axis, double mid_pos, double aim_pos, double MinVel, double MaxVel, double Acc, int RunMode = 1)
        {
            return false;
        }
        #endregion

        #region 单轴停止
        public bool AxisStop(short CardNum,short Axis,int option)
        {
          return  Rtn=IsCheck("GT_Stop", mc.GT_Stop(CardNum, 1 << (Axis - 1), option));
        }
        #endregion
        public bool EmgStop(short CardNum)
        {
            return false;
        }


        #region 清除坐标系缓冲区数据
        /// <summary>
        /// 清除坐标系数据
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <param name="Crd"></param>
        /// <param name="FIFO"></param>
        /// <returns></returns>
        public bool ClearFIFO(short CardNum, short Axis,short Crd,short FIFO)
        {
          return  IsCheck("mc.GT_CrdClear",mc.GT_CrdClear(CardNum, Crd, Crd));
        }
        #endregion

        #region 建立坐标系
        /// <summary>
        /// 创建坐标系
        /// </summary>
        /// <param name="CardNum">卡号</param>
        /// <param name="MaxVel">坐标系最大速度</param>
        /// <param name="MaxAcc">坐标系最大加速度</param>
        /// <param name="dimension">坐标系维数</param>
        /// <param name="Crd">坐标系号</param>
        /// <returns></returns>
        public bool CreateDimension(short CardNum,double MaxVel,double MaxAcc,short dimension, short Crd)
        {
            mc.TCrdPrm MyTCrdPrm = new mc.TCrdPrm();
            MyTCrdPrm.dimension = 3;//坐标系维数
            MyTCrdPrm.evenTime = 0;//每个插补段的最小匀速时间.取值范围[0, 32767]单位ms.
            MyTCrdPrm.synVelMax = MaxVel;//坐标系最大速度。
            MyTCrdPrm.synAccMax = MaxAcc;//坐标系最大加速度.
            MyTCrdPrm.profile1 = 1;
            MyTCrdPrm.profile2 = 2;
            MyTCrdPrm.profile3 = 3;
            MyTCrdPrm.profile4 = 0;
            MyTCrdPrm.profile5 = 0;
            MyTCrdPrm.profile6 = 0;
            MyTCrdPrm.profile7 = 0;
            MyTCrdPrm.profile8 = 0;
            MyTCrdPrm.setOriginFlag = 1;//setOriginFlag：表示是否需要指定坐标系的原点坐标的规划位置，该参数可以方便用户建立区别于机床坐标系的加工坐标系。0：不需要指定原点坐标值，则坐标系的原点在当前规划位置上。1：需要指定原点坐标值，坐标系的原点在 originPos 指定的规划位置上。
            MyTCrdPrm.originPos1 = 0;
            MyTCrdPrm.originPos2 = 0;
            MyTCrdPrm.originPos3 = 0;
            MyTCrdPrm.originPos4 = 0;
            return IsCheck("GT_SetCrdPrm", mc.GT_SetCrdPrm(CardNum, Crd, ref MyTCrdPrm));
        }
        #endregion



        public bool CmpMode(short CardNum, short Axis,short group, short Hcmp, int time, short cmp_logic,int Mode)
        {
            return false;
        }

        public bool addHcmpPoint(short CardNum, short Hcmp, int Pos)
        {
            return false;
        }

        public bool ClearHcmpPoint(short CardNum, short Hcmp)
        {
            return false;
        }
        /// <summary>
        /// 查询坐标系缓存区空间
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Crd"></param>
        /// <param name="Fifo"></param>
        /// <returns></returns>
        public int GT_CrdSpace(short CardNum,short Crd,short Fifo)
        {
            IsCheck("GT_CrdSpace", mc.GT_CrdSpace(CardNum, Crd,out int Space, Fifo));
            return Space;
        }
        public  float DebugSpeed(bool DebugMode, float Speed)
        {
           if(!DebugMode)
           {
               if(Speed>20)
               {
                   return 20;
               }
               else
               {
                   return Speed;
               }
           }
           return Speed;
        }

        public int AxisHome(short CardNum, short Axis, double HomeOffset, double Spd, double Capspd, int HomeMode, short Level, short HomeDir,int Timeout)
        {
            return 1;
        }
        
        // #region 单轴回零
        // public  void TrapHome(short CardNum, short Axis, int TrapPos, double spd)
        // {
        //     mc.GT_ZeroPos(CardNum, Axis, 1);
        //     mc.GT_ClrSts(CardNum, Axis, 1);//清除各轴报警和限位
        //     short rtn1 = gts.mc.GT_AxisOn(CardNum, Axis);
        //     mc.GT_PrfTrap(CardNum, Axis);//设置点位模式
        //     mc.TTrapPrm myTTrapPrm = new gts.mc.TTrapPrm();
        //     myTTrapPrm.acc = 0.125;
        //     myTTrapPrm.dec = 0.125;//减速度
        //     myTTrapPrm.velStart = 10;//起始速度
        //     myTTrapPrm.smoothTime = 50;//平滑时间
        //     gts.mc.GT_SetTrapPrm(CardNum, Axis, ref myTTrapPrm);
        //     double nowpos = GetAxisPrfPos(CardNum, Axis);
        //     gts.mc.GT_SetPos(CardNum, Axis,(int)nowpos + TrapPos);
        //     gts.mc.GT_SetVel(CardNum, Axis, spd);
        //     gts.mc.GT_Update(CardNum, 1 << (Axis - 1));
        // }

        // public  void JOGHome(short CardNum, short Axis,double vel)
        // {
        //     gts.mc.GT_ClrSts(CardNum, Axis, 1);//清除各轴报警和限位
        //     gts.mc.GT_PrfJog(CardNum, Axis);//设置为jog模式
        //     short rtn = gts.mc.GT_AxisOn(CardNum, Axis);
        //     mc.TJogPrm MyTJogPrm = new mc.TJogPrm();
        //     MyTJogPrm.acc = 0.125;
        //     MyTJogPrm.dec = 0.125;
        //     gts.mc.GT_SetJogPrm(CardNum, Axis, ref MyTJogPrm);
        //     gts.mc.GT_SetVel(CardNum, Axis, vel);
        //     gts.mc.GT_Update(CardNum, 1 << (Axis - 1));
        // }
        // /// <summary>
        // /// 负限+Home
        // ///  <param name="Axis">轴编号</param>
        // /// </summary>
        // public  bool SingleGoHome(short CardNum, short Axis, int Offset, double HomeSpd, double SearchHomeSpd, int NegLimitDis)
        // {
        //     //GlobalFun.FlagHomeSinge[CardNum * 8 + Axis] = false;
        //     if (GetAxisStatus(CardNum, Axis).FlagNegLimit)
        //     {
        //         TrapHome(CardNum, Axis, NegLimitDis, HomeSpd);
        //         Thread.Sleep(200);
        //         do
        //         {
        //             //if (GlobalFun.HomeStop || GetAxisStatus(CardNum, Axis).FlagMoveEnd)
        //             //{
        //             //    break;
        //             //}
        //         }
        //         while (!GetAxisStatus(CardNum, Axis).FlagMoveEnd);
        //     }
        //     short Re;
        //     gts.mc.THomeStatus tHomeSts;
        //     gts.mc.THomePrm HomePrm;
        //     gts.mc.GT_AlarmOff(CardNum, Axis);
        //     gts.mc.GT_ClrSts(CardNum, Axis, 8);
        //     gts.mc.GT_ZeroPos(CardNum, Axis, 1);
        //     gts.mc.GT_AxisOn(CardNum, Axis);
        //     Re = gts.mc.GT_GetHomePrm(CardNum, Axis, out HomePrm);
        //     HomePrm.mode = 11;
        //     HomePrm.moveDir = -1;
        //     HomePrm.edge = 1;
        //     HomePrm.pad1_1 = 1;//使用高速回零
        //     HomePrm.velHigh = HomeSpd;//GetAxisParm(CardNum, Axis).HomeSpd;
        //     HomePrm.velLow = SearchHomeSpd; //GetAxisParm(CardNum, Axis).SearchHomeSpd;
        //     HomePrm.acc = 0.25;
        //     HomePrm.dec = 0.25;
        //     HomePrm.smoothTime = 25;
        //     HomePrm.homeOffset = Offset;
        //     HomePrm.escapeStep = 1000;
        //     HomePrm.searchHomeDistance = 0;
        //     HomePrm.searchIndexDistance = 0;
        //     gts.mc.GT_GoHome(CardNum, Axis, ref HomePrm);
        //     Thread Home = new Thread(() =>
        //     {
        //         do
        //         {
        //             gts.mc.GT_GetHomeStatus(CardNum, Axis, out tHomeSts);
        //         }
        //         while (tHomeSts.run == 1);
        //         Thread.Sleep(1000);
        //         if (tHomeSts.run == 0)
        //         {
        //             Re = gts.mc.GT_ZeroPos(CardNum, Axis, 1);
        //             Thread.Sleep(200);
        //             //GlobalFun.FlagHomeSinge[CardNum * 8 + Axis] = true;
        //             //SystemOperation.SendDisplayLOG(CardNum * 8 + Axis + "轴复位完成！！！", MainForm.MainHandle.LOG_TXT);
        //         }
        //     });
        //     Home.Start();
        //     return true;
        // }
        // /// <summary>
        ///// 负限位原点短接方式复位
        ///// </summary>
        ///// <param name="CardNum">卡号</param>
        ///// <param name="Axis">轴号</param>
        ///// <param name="Offset">原点偏移距离</param>
        // /// <param name="DeviateSensorDis">偏移感应器距离</param>
        ///// <param name="HomeSpd">回零速度</param>
        ///// <param name="SearchHomeSpd">捕获原点速度</param>
        ///// <param name="NegLimitDis">搜索距离</param>
        ///// <returns></returns>
        // public  bool SingleGoHome_Num1(short CardNum, short Axis, int Offset,int DeviateSensorDis, double HomeSpd, double SearchHomeSpd, int NegLimitDis,short DP)
        // {
        //     int pos = 0;
        //     short capture;
        //     uint clk;
        //     //GlobalFun.FlagHomeSinge[CardNum * 8 + Axis] = false;
        //     //GlobalFun.FlagHomeSingeFail[CardNum * 8 + Axis] = false;
        //     Thread Home2 = new Thread(() =>
        //         {
        //             //GlobalFun.HomeStop = false;
        //             //判断轴位置是否在原点或者负限位
        //             if (GetAxisStatus(CardNum, Axis).FlagNegLimit || GetAxisStatus(CardNum, Axis).FlagHome)
        //             {
        //                 TrapHome(CardNum, Axis, DeviateSensorDis, HomeSpd);
        //                 Thread.Sleep(200);
        //                 //判断轴是否正常停止
        //                 do
        //                 {
        //                     Thread.Sleep(2);
        //                     //                            if (GlobalFun.HomeStop || CMotion.ALM(CardNum, Axis))
        //                     //                            {
        //                     //                                GlobalFun.FlagHomeSingeFail[CardNum * 8 + Axis] = true;
        //                     //;
        //                     //                                GlobalFun.HomeStop = true;
        //                     //                                return;
        //                     //                            }
        //                 }
        //                 while (!GetAxisStatus(CardNum, Axis).FlagMoveEnd);
        //             }
        //             Thread.Sleep(200);
        //             //启动jop运动寻找负限位
        //             JOGHome(CardNum, Axis, -1 * HomeSpd);
        //             Thread.Sleep(200);
        //             //触碰负限位停止
        //             do
        //             {
        //                 Thread.Sleep(2);
        //                 if (GetAxisStatus(CardNum, Axis).FlagNegLimit)
        //                 {
        //                     //AxisStop(CardNum, Axis);
        //                 }
        //                 //if (GlobalFun.HomeStop || CMotion.ALM(CardNum, Axis))
        //                 //{
        //                 //    GlobalFun.FlagHomeSingeFail[CardNum * 8 + Axis] = true;
        //                 //    GlobalFun.HomeStop = true;
        //                 //    return;
        //                 //}
        //             }
        //             while (!GetAxisStatus(CardNum, Axis).FlagMoveEnd);
        //             Thread.Sleep(200);
        //             gts.mc.GT_ClearCaptureStatus(CardNum, Axis);
        //             gts.mc.GT_SetCaptureSense(CardNum, Axis, mc.CAPTURE_HOME, DP);
        //             gts.mc.GT_SetCaptureMode(CardNum, Axis, gts.mc.CAPTURE_HOME);
        //             TrapHome(CardNum, Axis, NegLimitDis, SearchHomeSpd);
        //             do
        //             {
        //                 Thread.Sleep(2);
        //                 gts.mc.GT_GetCaptureStatus(CardNum, Axis, out capture, out pos, 1, out clk);
        //                 //if (GlobalFun.HomeStop || CMotion.ALM(CardNum, Axis))
        //                 //{
        //                 //    GlobalFun.FlagHomeSingeFail[CardNum * 8 + Axis] = true;
        //                 //    GlobalFun.HomeStop = true;
        //                 //    return;
        //                 //}
        //                 //if (GetAxisStatus(CardNum, Axis).FlagMoveEnd && capture==0)
        //                 //{
        //                 //    GlobalFun.FlagHomeSingeFail[CardNum * 8 + Axis] = true;
        //                 //    GlobalFun.HomeStop = true;
        //                 //    return;
        //                 //}
        //             }
        //             while (capture == 0);
        //             //AxisStop(CardNum, Axis);
        //             Thread.Sleep(500);
        //             mc.GT_ClrSts(CardNum, Axis, 1);//清除各轴报警和限位
        //             gts.mc.GT_SetPos(CardNum, Axis, pos);
        //             gts.mc.GT_SetVel(CardNum, Axis, HomeSpd);
        //             gts.mc.GT_Update(CardNum, 1 << (Axis - 1));
        //             Thread.Sleep(200);
        //             do
        //             {
        //                 Thread.Sleep(2);
        //                 //if (GlobalFun.HomeStop || CMotion.ALM(CardNum, Axis))
        //                 //{
        //                 //    GlobalFun.FlagHomeSingeFail[CardNum * 8 + Axis] = true;
        //                 //    GlobalFun.HomeStop = true;
        //                 //    return;
        //                 //}
        //             }
        //             while (!GetAxisStatus(CardNum, Axis).FlagMoveEnd);
        //             mc.GT_ClrSts(CardNum, Axis, 1);//清除各轴报警和限位
        //             gts.mc.GT_SetPos(CardNum, Axis, pos + Offset);
        //             gts.mc.GT_SetVel(CardNum, Axis, HomeSpd);
        //             gts.mc.GT_Update(CardNum, 1 << (Axis - 1));
        //             Thread.Sleep(100);
        //             do
        //             {
        //                 Thread.Sleep(2);
        //                 //if (GlobalFun.HomeStop || CMotion.ALM(CardNum, Axis))
        //                 //{
        //                 //    GlobalFun.FlagHomeSingeFail[CardNum * 8 + Axis] = true;
        //                 //    GlobalFun.HomeStop = true;
        //                 //    return;
        //                 //}
        //             }
        //             while (!GetAxisStatus(CardNum, Axis).FlagMoveEnd);
        //             Thread.Sleep(1000);
        //             mc.GT_ZeroPos(CardNum, Axis, 1);
        //             Thread.Sleep(200);
        //             //GlobalFun.FlagHomeSinge[CardNum * 8 + Axis] = true;
        //             //try
        //             //{
        //             //    SystemOperation.SendResetLOG("Axis:" + (CardNum * 8 + Axis) + "轴复位完成!!!", ResetForm.ResetHandle.ResetData);
        //             //}
        //             //catch
        //             //{

        //             //}
        //             //SystemOperation.SendResetLOG("Axis:" + (CardNum * 8 + Axis) + "轴复位完成!!!",MainForm.MainHandle.LOG_TXT);
        //         });
        //     Home2.Start();
        //     return true;
        // }

        // public  bool SingleGoHome_Num2(short CardNum, short Axis, int Offset, int DeviateSensorDis, double HomeSpd, double SearchHomeSpd, int NegLimitDis, short DP)
        // {
        //     int pos = 0;
        //     short capture;
        //     uint clk;
        //     bool HomeStart = true;
        //     int HomeStep = 0;
        //     //GlobalFun.FlagHomeSinge[CardNum * 8 + Axis] = false;
        //     Thread Home2 = new Thread(() =>
        //     {
        //         //GlobalFun.HomeStop = false;
        //         while(HomeStart)
        //         {
        //             switch (HomeStep)
        //             {
        //                 //判断轴位置是否在原点或者负限位
        //                 case 0:
        //                     if (GetAxisStatus(CardNum, Axis).FlagNegLimit || GetAxisStatus(CardNum, Axis).FlagHome)
        //                     {
        //                         TrapHome(CardNum, Axis, DeviateSensorDis, HomeSpd);
        //                         Thread.Sleep(200);
        //                     }
        //                     break;
        //                 case 1:
        //                     break;
        //             }
        //         }
        //         //判断轴位置是否在原点或者负限位
        //         if (GetAxisStatus(CardNum, Axis).FlagNegLimit || GetAxisStatus(CardNum, Axis).FlagHome)
        //         {
        //             TrapHome(CardNum, Axis, DeviateSensorDis, HomeSpd);
        //             Thread.Sleep(200);
        //         }
        //         //判断轴是否正常停止
        //         do
        //         {
        //             //if (GlobalFun.HomeStop || GetAxisStatus(CardNum, Axis).FlagMoveEnd)
        //             //{
        //             //    break;
        //             //}
        //         }
        //         while (!GetAxisStatus(CardNum, Axis).FlagMoveEnd);
        //         Thread.Sleep(200);
        //         //启动jop运动寻找负限位
        //         JOGHome(CardNum, Axis, -1 * HomeSpd);
        //         Thread.Sleep(200);
        //         //触碰负限位停止
        //         do
        //         {
        //             if (GetAxisStatus(CardNum, Axis).FlagNegLimit)
        //             {
        //                 //AxisStop(CardNum, Axis);
        //             }
        //             //if (GlobalFun.HomeStop || GetAxisStatus(CardNum, Axis).FlagMoveEnd)
        //             //{
        //             //    break;
        //             //}
        //         }
        //         while (!GetAxisStatus(CardNum, Axis).FlagMoveEnd);
        //         Thread.Sleep(200);
        //         gts.mc.GT_ClearCaptureStatus(CardNum, Axis);
        //         gts.mc.GT_SetCaptureSense(CardNum, Axis, mc.CAPTURE_HOME, DP);
        //         gts.mc.GT_SetCaptureMode(CardNum, Axis, gts.mc.CAPTURE_HOME);
        //         TrapHome(CardNum, Axis, NegLimitDis, SearchHomeSpd);
        //         do
        //         {
        //             gts.mc.GT_GetCaptureStatus(CardNum, Axis, out capture, out pos, 1, out clk);
        //             if (GetAxisStatus(CardNum, Axis).FlagMoveEnd)
        //             {
        //                 break;
        //             }
        //         }
        //         while (capture == 0);
        //         //AxisStop(CardNum, Axis);
        //         Thread.Sleep(500);
        //         mc.GT_ClrSts(CardNum, Axis, 1);//清除各轴报警和限位
        //         gts.mc.GT_SetPos(CardNum, Axis, pos + Offset);
        //         gts.mc.GT_SetVel(CardNum, Axis, HomeSpd);
        //         gts.mc.GT_Update(CardNum, 1 << (Axis - 1));
        //         Thread.Sleep(200);
        //         do
        //         {
        //             //if (GlobalFun.HomeStop || GetAxisStatus(CardNum, Axis).FlagMoveEnd)
        //             //{
        //             //    break;
        //             //}

        //         }
        //         while (!GetAxisStatus(CardNum, Axis).FlagMoveEnd);
        //         mc.GT_ClrSts(CardNum, Axis, 1);//清除各轴报警和限位
        //         gts.mc.GT_SetPos(CardNum, Axis, Offset);
        //         gts.mc.GT_SetVel(CardNum, Axis, HomeSpd);
        //         gts.mc.GT_Update(CardNum, 1 << (Axis - 1));
        //         do
        //         {
        //             //if (GlobalFun.HomeStop || GetAxisStatus(CardNum, Axis).FlagMoveEnd)
        //             //{
        //             //    break;
        //             //}
        //         }
        //         while (!GetAxisStatus(CardNum, Axis).FlagMoveEnd);
        //         Thread.Sleep(1000);
        //         mc.GT_ZeroPos(CardNum, Axis, 1);
        //         Thread.Sleep(200);
        //         //GlobalFun.FlagHomeSinge[CardNum * 8 + Axis] = true;
        //         //SystemOperation.SendDisplayLOG((CardNum * 8 + Axis) + "轴复位完成！！！", MainForm.MainHandle.LOG_TXT);
        //         //try
        //         //{
        //         //    SystemOperation.SendDisplayLOG((CardNum * 8 + Axis) + "轴复位完成！！！", ResetForm.ResetHandle.ResetData);
        //         //}
        //         //catch
        //         //{

        //         //}
        //     });
        //     Home2.Start();
        //     return true;
        // }
        // #endregion



        #region 自动回零
        ///<summary>
        ///自动复位
        ///</summary>
        //public static void AutoHome()
        //{
        //    int HomeStep = 0;
        //    bool HomeStart = false;
        //    Thread AutoHome = new Thread(() =>
        //    {
        //        while (!GlobalFun.HomeStop && !HomeStart)
        //        {
        //            Thread.Sleep(10);
        //            Application.DoEvents();
        //            switch (HomeStep)
        //            {
        //                case 0:
        //                    CMotion.SingleGoHome_Num1(CMotion.AxisCCD.Card, CMotion.AxisCCD.AxisNum, (int)(CMotion.GetMotionPix(CMotion.AxisCCD.Card, CMotion.AxisCCD.AxisNum) * CMotion.GetAxisParm(CMotion.AxisCCD.Card, CMotion.AxisCCD.AxisNum).Homeoffset),
        //                        20000, 30, 5, 2000, 0);//Tray盘CCD回零
        //                    CMotion.SingleGoHome_Num1(CMotion.AxisCUKeyZ.Card, CMotion.AxisCUKeyZ.AxisNum, (int)(CMotion.GetMotionPix(CMotion.AxisCUKeyZ.Card, CMotion.AxisCUKeyZ.AxisNum) * CMotion.GetAxisParm(CMotion.AxisCUKeyZ.Card, CMotion.AxisCUKeyZ.AxisNum).Homeoffset),
        //                        5000, 10, 5, 5000, 0);//组装Z1轴回零
        //                    CMotion.SingleGoHome_Num1(CMotion.AxisFTKeyZ2.Card, CMotion.AxisFTKeyZ2.AxisNum, (int)(CMotion.GetMotionPix(CMotion.AxisFTKeyZ2.Card, CMotion.AxisFTKeyZ2.AxisNum) * CMotion.GetAxisParm(CMotion.AxisFTKeyZ2.Card, CMotion.AxisFTKeyZ2.AxisNum).Homeoffset),
        //                        5000, 10, 5, 5000, 0);//组装Z1轴回零
        //                    HomeStep = 1;
        //                    break;
        //                case 1:
        //                    if (GlobalFun.FlagHomeSinge[CMotion.AxisCUKeyZ.Card * 8 + CMotion.AxisCUKeyZ.AxisNum] && GlobalFun.FlagHomeSinge[CMotion.AxisFTKeyZ2.Card * 8 + CMotion.AxisFTKeyZ2.AxisNum])
        //                    {
        //                        HomeStep = 2;
        //                    }
        //                    break;
        //                case 2:
        //                    CMotion.SingleGoHome_Num1(CMotion.AxisGrabKC_Z.Card, CMotion.AxisGrabKC_Z.AxisNum, (int)(CMotion.GetMotionPix(CMotion.AxisGrabKC_Z.Card, CMotion.AxisGrabKC_Z.AxisNum) * CMotion.GetAxisParm(CMotion.AxisGrabKC_Z.Card, CMotion.AxisGrabKC_Z.AxisNum).Homeoffset),
        //                           5000, 10, 5, 5000, 0);//KC取料Z轴回零
        //                    CMotion.SingleGoHome_Num1(CMotion.AxisGrabKB_Z.Card, CMotion.AxisGrabKB_Z.AxisNum, (int)(CMotion.GetMotionPix(CMotion.AxisGrabKB_Z.Card, CMotion.AxisGrabKB_Z.AxisNum) * CMotion.GetAxisParm(CMotion.AxisGrabKB_Z.Card, CMotion.AxisGrabKB_Z.AxisNum).Homeoffset),
        //                           5000, 10, 5, 5000, 0);//KB取料Z轴回零
        //                    HomeStep = 3;
        //                    break;
        //                case 3:
        //                    if (GlobalFun.FlagHomeSinge[CMotion.AxisGrabKC_Z.Card * 8 + CMotion.AxisGrabKC_Z.AxisNum] && GlobalFun.FlagHomeSinge[CMotion.AxisGrabKB_Z.Card * 8 + CMotion.AxisGrabKB_Z.AxisNum])
        //                    {
        //                        HomeStep = 4;
        //                    }
        //                    break;
        //                case 4:
        //                    CMotion.SingleGoHome_Num1(CMotion.AxisCUKeyX.Card, CMotion.AxisCUKeyX.AxisNum, (int)(CMotion.GetMotionPix(CMotion.AxisCUKeyX.Card, CMotion.AxisCUKeyX.AxisNum) * CMotion.GetAxisParm(CMotion.AxisCUKeyX.Card, CMotion.AxisCUKeyX.AxisNum).Homeoffset),
        //                        5000, 20, 5, 2000, 0);//组装X轴回零
        //                    CMotion.SingleGoHome_Num1(CMotion.AxisCUKeyY.Card, CMotion.AxisCUKeyY.AxisNum, (int)(CMotion.GetMotionPix(CMotion.AxisCUKeyY.Card, CMotion.AxisCUKeyY.AxisNum) * CMotion.GetAxisParm(CMotion.AxisCUKeyY.Card, CMotion.AxisCUKeyY.AxisNum).Homeoffset),
        //                        5000, 30, 5, 5000, 0);//组装Y轴回零
        //                    CMotion.SingleGoHome_Num1(CMotion.AxisCUKeyR.Card, CMotion.AxisCUKeyR.AxisNum, (int)(CMotion.GetMotionPix(CMotion.AxisCUKeyR.Card, CMotion.AxisCUKeyR.AxisNum) * CMotion.GetAxisParm(CMotion.AxisCUKeyR.Card, CMotion.AxisCUKeyR.AxisNum).Homeoffset),
        //                        5000, 10, 5, 5000, 0);//组装R轴回零
        //                    CMotion.SingleGoHome_Num1(CMotion.AxisFTKeyX2.Card, CMotion.AxisFTKeyX2.AxisNum, (int)(CMotion.GetMotionPix(CMotion.AxisFTKeyX2.Card, CMotion.AxisFTKeyX2.AxisNum) * CMotion.GetAxisParm(CMotion.AxisFTKeyX2.Card, CMotion.AxisFTKeyX2.AxisNum).Homeoffset),
        //                        5000, 10, 5, 5000, 0);//组装X2轴回零

        //                    CMotion.SingleGoHome_Num1(CMotion.AxisGrabKC_Y.Card, CMotion.AxisGrabKC_Y.AxisNum, (int)(CMotion.GetMotionPix(CMotion.AxisGrabKC_Y.Card, CMotion.AxisGrabKC_Y.AxisNum) * CMotion.GetAxisParm(CMotion.AxisGrabKC_Y.Card, CMotion.AxisGrabKC_Y.AxisNum).Homeoffset),
        //                        5000, 30, 5, 5000, 0);//KC取料Y轴回零
        //                    CMotion.SingleGoHome_Num1(CMotion.AxisGrabKB_Y.Card, CMotion.AxisGrabKB_Y.AxisNum, (int)(CMotion.GetMotionPix(CMotion.AxisGrabKB_Y.Card, CMotion.AxisGrabKB_Y.AxisNum) * CMotion.GetAxisParm(CMotion.AxisGrabKB_Y.Card, CMotion.AxisGrabKB_Y.AxisNum).Homeoffset),
        //                        5000, 30, 5, 5000, 0);//KB取料Y轴回零

        //                    CMotion.SingleGoHome_Num1(CMotion.AxisDZ.Card, CMotion.AxisDZ.AxisNum, (int)(CMotion.GetMotionPix(CMotion.AxisDZ.Card, CMotion.AxisDZ.AxisNum) * CMotion.GetAxisParm(CMotion.AxisDZ.Card, CMotion.AxisDZ.AxisNum).Homeoffset),
        //                        5000, 10, 5, 5000, 0);//二次定位平台回零
        //                    HomeStep = 5;
        //                    break;
        //                case 5:
        //                    HomeStart = true;
        //                    break;
        //            }
        //          }
        //    });
        //    AutoHome.Start();
        //}
        #endregion

        /// <summary>
        /// 延时
        /// </summary>
        /// <param name="millisecondsTimeout"></param>
        public static void Delay(int millisecondsTimeout)
        {
            DateTime dt = DateTime.Now.AddMilliseconds(millisecondsTimeout);
            do
            {
                Thread.Sleep(1);
                Application.DoEvents();
            } while (DateTime.Now <= dt);
        }


      public  bool LinearInterMove(short CardNum, short Crd, short AxisNum, double Vel, double Acc, ushort[] AxisList, int[] DisLlist, ushort Mode)
        {
            return false;
        }
       public bool CrdRunning(short CardNum, short Crd)
        {
            return false;
        }


        /// <summary>
        /// 清除捕获状态
        /// </summary>
        public bool ClearCapSts(short CardNum, short Axis, short ch)
        {
          
           return false;
            
        }

        /// <summary>
        /// 设置捕获参数
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <param name="Pos"></param>
        /// <param name="ch">捕获的通道号</param>
        /// <returns></returns>
        public bool SetCap(short CardNum, short Axis, int Pos, short ch)
        {

            return false;
        }
        public bool GetCapSts(short CardNum, short Axis, short ch)
        {
            return false;
        }
    }
}
