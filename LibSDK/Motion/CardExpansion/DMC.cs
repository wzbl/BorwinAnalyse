using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using csLTDMC;

namespace LibSDK.Motion
{
    class DMC:MotionBase, CardInterface
    {
        public bool HomeStop { get; set; }

        public bool HomeRuning { get; set; }

        public bool CrdIni(short CardNum, string CardFile)
        {
            short CNum = LTDMC.dmc_board_init();
            if(CNum <= 0 || CNum > 8)
            {
                ShowErrorMessage("dmc_set_debug_mode", CNum, "没有找到控制卡,或者控制卡异常");
                return false;
            }
            else
            {
                Rtn = IsCheck("dmc_set_debug_mode", LTDMC.dmc_set_debug_mode(0, "DMC_ErrorLog.ini"));
                
                if (Rtn)
                Rtn = IsCheck("dmc_download_configfile", LTDMC.dmc_download_configfile((ushort)CardNum, CardFile));
                return Rtn;
            }
        }
        public bool CloseCard(short CardNum=0)
        {
          return IsCheck("dmc_board_close", LTDMC.dmc_board_close());
        }
        public bool ExMdlIni(short CardNum, int MdlNum, params string[] FileName)
        {
            if (MdlNum <= 0) { return true; }
            for (int i = 1; i <= MdlNum; i++)
            {
                Rtn = IsCheck("nmc_set_connect_state", LTDMC.nmc_set_connect_state((ushort)CardNum, (ushort)i, 1, 0));
                if (!Rtn) return false;
                Thread.Sleep(10);
            }
            return true;
        }
        /// <summary>
        /// 清除轴状态
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        public bool ClearAxisState(short CardNum, short Axis)
        {
            return IsCheck("dmc_clear_stop_reason", LTDMC.dmc_clear_stop_reason((ushort)CardNum, (ushort)Axis));
        }
        /// <summary>
        /// 使能开
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        public bool Servon(short CardNum, short Axis)
        {
            return IsCheck("dmc_write_sevon_pin", LTDMC.dmc_write_sevon_pin((ushort)CardNum, (ushort)(Axis-1), 0));
        }
        /// <summary>
        /// 使能关
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        public bool Servoff(short CardNum, short Axis)
        {
          return IsCheck("GT_AxisOff", LTDMC.dmc_write_sevon_pin((ushort)CardNum, (ushort)(Axis-1),1));
        }

        public bool SetSofLimit(short CardNum, short Axis,bool Enable,double P_Limit,double N_Limit)
        {
            ushort enable; 
            if (Enable) { enable = 1; } else { enable = 0; }
            return IsCheck("dmc_set_softlimit", LTDMC.dmc_set_softlimit((ushort)CardNum, (ushort)(Axis - 1), enable, 0,0, (int)N_Limit, (int)P_Limit));
        }

        public bool SetELMode(short CardNum, short Axis,short El_Enable,short EL_Logic,short ELMode)
        {
            return IsCheck("dmc_set_softlimit", LTDMC.dmc_set_el_mode((ushort)CardNum, (ushort)(Axis - 1), (ushort)El_Enable, (ushort)EL_Logic, (ushort)ELMode));

        }
        /// <summary>
        /// 读取轴状态
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        private uint GetSts(short CardNum, short Axis)
        {
          uint Pvalue = LTDMC.dmc_axis_io_status((ushort)CardNum, (ushort)Axis);
          return Pvalue;
        }
        private bool GetBitStatus(short CardNum, short Axis, int bitIndex)
        {
            uint pSts;
            uint bit = 0x01;
            bit <<= bitIndex;
            pSts = GetSts(CardNum,Axis);
            if ((pSts & bit) == bit) return true;
            return false;
        }
        /// <summary>
        /// 读取报警信号
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        public bool Mot_ALM(short CardNum, short Axis)
        {
          return GetBitStatus(CardNum, (short)(Axis - 1), 0);
        }
        /// <summary>
        /// 读取正限位信号
        /// </summary>
        public bool Mot_PEL(short CardNum, short Axis)
        {
            return GetBitStatus(CardNum, (short)(Axis - 1), 1);
        }
        /// <summary>
        /// 读取负限位信号
        /// </summary>
        public bool Mot_NEL(short CardNum, short Axis)
        {
          return GetBitStatus(CardNum, (short)(Axis - 1), 2);
        }
        /// <summary>
        /// 读取原点信号
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        public bool Mot_ORG(short CardNum, short Axis)
        {
            return GetBitStatus(CardNum, (short)(Axis-1), 4);
        }
        /// <summary>
        /// 读取轴正软限位状态
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        public bool Mot_SLP(short CardNum, short Axis)
        {
            return GetBitStatus(CardNum, (short)(Axis - 1), 6);
        }
        /// <summary>
        /// 读取轴正软限位状态
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        public bool Mot_SLN(short CardNum, short Axis)
        {
            return GetBitStatus(CardNum, (short)(Axis - 1), 7);
        }
        /// <summary>
        /// 读取伺服到位信号
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        public bool Mot_INP(short CardNum, short Axis)
        {
            return GetBitStatus(CardNum, (short)(Axis - 1), 8);
        }
        /// <summary>
        /// 读取轴急停信号
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        public bool Mot_EMG(short CardNum, short Axis)
        {
           return GetBitStatus(CardNum, (short)(Axis - 1), 3);
        }
        /// <summary>
        /// 读取使能信号
        /// </summary>
        /// <returns></returns>
        public bool SevOn(short CardNum, short Axis)
        {
            bool BoolRtn = false;
            short rtn = LTDMC.dmc_read_sevon_pin((ushort)CardNum, (ushort)(Axis-1));
            if (rtn == 0) {  BoolRtn = true; }
            if(rtn ==1) {  BoolRtn = false; }
            return BoolRtn;
        }
        /// <summary>
        /// 获取规划位置
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        public double GetPrfPluse(short CardNum, short Axis)
        {
            double pValue;
            pValue = LTDMC.dmc_get_position((ushort)CardNum, (ushort)(Axis-1));
            return pValue;
        }
        /// <summary>
        ///获取编码器位置
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        public double GetEncPluse(short CardNum, short Axis)
        {
            double pValue;
            pValue = LTDMC.dmc_get_encoder((ushort)CardNum, (ushort)(Axis-1));
            return pValue;
        }
       /// <summary>
       /// 单轴停止
       /// </summary>
       /// <param name="CardNum"></param>
       /// <param name="Axis"></param>
       /// <param name="option"></param>
       /// <returns></returns>
        public bool AxisStop(short CardNum, short Axis, int option)
        {
            LTDMC.dmc_set_dec_stop_time((ushort)CardNum, (ushort)(Axis - 1), 0.5); //设置减速停止时间
            return IsCheck("dmc_stop", LTDMC.dmc_stop((ushort)CardNum, (ushort)(Axis - 1), (ushort)option));
        }
        public bool EmgStop(short CardNum)
        {
            return IsCheck("dmc_emg_stop", LTDMC.dmc_emg_stop((ushort)CardNum));
        }
        #region IO操作
        public bool SetDo(short CardNum, short IoNum, short value)
        {
           return IsCheck("dmc_write_outbit", LTDMC.dmc_write_outbit((ushort)CardNum, (ushort)(IoNum - 1), (ushort)value));
        }
        public bool GetDo(short CardNum, short IoNum)
        {
            if (LTDMC.dmc_read_outbit((ushort)CardNum, (ushort)(IoNum - 1)) == 0)
                return true;
            else
                return false;
        }
        public bool GetDi(short CardNum, short IoNum)
        {
            if(LTDMC.dmc_read_inbit((ushort)CardNum, (ushort)(IoNum - 1))==0)
                return true;
            else
                return false;
        }
        public bool SetExtmdlDO(short CardNum, short mdl, short IoNum, ushort value)
        {
          return IsCheck("nmc_write_outbit", LTDMC.nmc_write_outbit((ushort)CardNum, (ushort)mdl, (ushort)(IoNum - 1), value));
        }
        public bool GetExtmdDO(short CardNum, short mdl, short IoNum)
        {
            ushort Pvalue = 0;

            IsCheck("nmc_read_outbit", LTDMC.nmc_read_outbit((ushort)CardNum,(ushort)mdl, (ushort)(IoNum-1),ref  Pvalue));
            if (Pvalue==0) { return true; }
            else
            {
              return false;
            }
        }
        public bool GetExtmdDi(short CardNum, short mdl, short IoNum)
        {
            ushort Pvalue = 0;
            IsCheck("nmc_read_inbit", LTDMC.nmc_read_inbit((ushort)CardNum,(ushort)mdl,(ushort)(IoNum-1),ref Pvalue));
            if (Pvalue == 0) { return true; }
            else
            {
               return false;
            }
        }
        #endregion

        /// <summary>
        /// 伺服到位信号
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        public bool GetCheckDone(short CardNum, short Axis)
        {
          return this.GetBitStatus(CardNum, (short)(Axis - 1), 8);
        }
        /// <summary>
        /// 检测电机运行状态
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        public bool Mot_Running(short CardNum, short Axis)
        {
            bool BoolRtn=false;
            short rtn = LTDMC.dmc_check_done((ushort)CardNum, (ushort)(Axis-1));
            if (rtn == 0)
            {
                BoolRtn = false;
            }
            else if (rtn == 1)
            {
              BoolRtn = true;
            }
            return BoolRtn;
        }

        public void ChangeSpeed(short CardNum, short Axis, double Vel)
        {
            LTDMC.dmc_change_speed((ushort)CardNum, (ushort)(Axis - 1), Vel,0);//设置速度参数
        }
        public bool JogMove(short CardNum, short Axis, short Direction, double Vel)
        {
           LTDMC.dmc_set_profile((ushort)CardNum, (ushort)(Axis - 1), 30, Vel, 0.15, 0.15, 50);//设置速度参数
           LTDMC.dmc_set_s_profile((ushort)CardNum, (ushort)(Axis - 1), 0, 0.05);//设置S段速度参数
           LTDMC.dmc_vmove((ushort)CardNum, (ushort)(Axis - 1), (ushort)Direction);//连续运动
           return Rtn;
        }
        public bool S_PMove(short CardNum, short Axis,double hight_pos,double low_pos,double MinVel,double MaxVel, double Acc, int RunMode = 1)
        {
            double Accpuse = Acc * 1000000;
            double AccTime = Math.Round(MaxVel / Accpuse, 3);//计算加速时间
            LTDMC.dmc_t_pmove_extern((ushort)CardNum, (ushort)(Axis - 1), hight_pos, low_pos, 2500*100, MaxVel, MinVel, AccTime, AccTime, (ushort)RunMode);
            return Rtn;
        }
        public bool PMove(short CardNum, short Axis, double Pos, double Vel, double Acc , int RunMode = 1)
        {
            double Accpuse = Acc * 1000000;
            double AccTime = Math.Round(Vel / Accpuse, 3);//计算加速时间
            LTDMC.dmc_set_profile((ushort)CardNum, (ushort)(Axis - 1), 30, Vel, AccTime, AccTime+ AccTime*0.2, 30);//设置速度参数
            LTDMC.dmc_set_s_profile((ushort)CardNum, (ushort)(Axis - 1), 0, 0.03);//设置S段速度参数
            LTDMC.dmc_pmove((ushort)CardNum, (ushort)(Axis - 1), (int)Pos, (ushort)RunMode);//点位运动
            return Rtn;
        }
        public bool XyzBufMove(short CardNum,short Crd,double Vel,double Acc,double Xpos,double Ypos,double Zpos,double SafeHight)
        {
            ushort[] AxisList = null;
            int[] DisList = null;

            double Accpuse = Acc * 1000000;
            double AccTime = Math.Round(Vel / Accpuse, 3);//计算加速时间
           
            AxisList[0] = 0; AxisList[1] = 1; AxisList[2] = 2;

            DisList[0] = (int)Xpos; DisList[1] = (int)Ypos; DisList[2] = (int)Zpos;

            Rtn = IsCheck("dmc_set_vector_profile_multicoor", LTDMC.dmc_set_vector_profile_multicoor((ushort)CardNum,(ushort)Crd,30, Vel, AccTime,0.15,100));
            if (Rtn)
                Rtn = IsCheck("dmc_line_multicoor", LTDMC.dmc_line_multicoor((ushort)CardNum, (ushort)Crd, 3, AxisList, DisList, 1));
            return Rtn;

        }
        /// <summary>
        /// 设置比较模式
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <param name="Hcmp"></param>
        /// <param name="time"></param>
        public bool CmpMode(short CardNum, short Axis, short group,short Hcmp,int time,short cmp_logic,int Mode)
        {
            Rtn = IsCheck("dmc_hcmp_set_mode", LTDMC.dmc_hcmp_set_mode((ushort)CardNum, (ushort)Hcmp, (ushort)Mode));
            if (Rtn)
                Rtn = IsCheck("dmc_hcmp_set_config", LTDMC.dmc_hcmp_set_config((ushort)CardNum, (ushort)Hcmp, (ushort)(Axis - 1), 0, (ushort)cmp_logic, time));
            return Rtn;
        }
        public bool addHcmpPoint(short CardNum, short Hcmp,int Pos)
        {
           return IsCheck("dmc_hcmp_add_point", LTDMC.dmc_hcmp_add_point((ushort)CardNum,(ushort)Hcmp, Pos));
        }

        public bool  ClearHcmpPoint(short CardNum,short Hcmp)
        {
            return IsCheck("dmc_hcmp_clear_points", LTDMC.dmc_hcmp_clear_points(((ushort)CardNum),(ushort)Hcmp));
        }
        /*****************************************************************回零函数*******************************************************************************
         * 回零模式：
         *0：一 次回零
         *1：一次回零加找
         *2：二次回零
         *3：一次回零后再 记一个同向 EZ 脉冲 进行回零
         *4：记一个 EZ 脉冲进行回零
         *5：原点加反向 EZ
         *6：原点锁存
         *7：原点锁存加同向 EZ 锁存
         *8：单独记一个 EZ 锁存
         *9：原点锁存加反向 EZ 锁存
        *10:一次限位回零
        *11: 一次限位回零加反找
        *12: 二次限位回零
         ***********************************************************************************************************************************************************/
         /// <summary>
         /// 回零函数
         /// </summary>
         /// <param name="CardNum"></param>
         /// <param name="Axis"></param>
         /// <param name="HomeOffset"></param>
         /// <param name="Spd"></param>
         /// <param name="Capspd"></param>
         /// <param name="HomeMode"></param>
         /// <param name="Level"></param>
         /// <param name="HomeDir"></param>
         /// <param name="Timeout"></param>
         /// <returns></returns>
        public int AxisHome(short CardNum, short Axis, double HomeOffset, double Spd, double Capspd, int HomeMode,short Level,short HomeDir,int Timeout)
        {
            Stopwatch sw = new Stopwatch();
            LTDMC.dmc_stop((ushort)CardNum,(ushort)(Axis - 1),0);//回零前先停止当前轴
            Rtn = IsCheck("dmc_set_home_pin_logic", LTDMC.dmc_set_home_pin_logic(0, (ushort)(Axis - 1), (ushort)Level, 0));//设置回原点电平
            LTDMC.dmc_set_profile((ushort)CardNum, (ushort)(Axis - 1), Capspd, Spd, 0.15, 0.15, Spd/2);//设置回零速度
            LTDMC.dmc_set_s_profile((ushort)CardNum, (ushort)(Axis - 1), 0, 0.05);//设置S段速度参数
            if (Rtn)
                Rtn = IsCheck("dmc_set_homemode", LTDMC.dmc_set_homemode((ushort)CardNum, (ushort)(Axis - 1), (ushort)HomeDir, 1, (ushort)HomeMode, 0));//设置回原点模式
            if (Rtn)
                Rtn = IsCheck("dmc_set_home_el_return", LTDMC.dmc_set_home_el_return((ushort)CardNum, (ushort)(Axis - 1), 0));//设置回零是否反找
            if (Rtn)
                Rtn = IsCheck("dmc_set_home_position", LTDMC.dmc_set_home_position((ushort)CardNum, (ushort)(Axis - 1), 2, HomeOffset));//设置回零偏移量及清零模式
            if (Rtn)
                Rtn = IsCheck("dmc_home_move", LTDMC.dmc_home_move((ushort)CardNum, (ushort)(Axis - 1)));////回原点运动启动
            if (!Rtn) { return 1; };
            Thread.Sleep(100);
            sw.Start();
            do
            {
                if(sw.ElapsedTicks / (decimal)Stopwatch.Frequency > Timeout)//回零 超时
                {
                    sw.Stop();
                    return 3;
                }
                if (Mot_ALM(CardNum, Axis))
                {
                    LTDMC.dmc_emg_stop((ushort)CardNum);//驱动器报警紧急停止轴
                    return 2;
                }
                if (HomeStop)//手动停止轴
                {
                    LTDMC.dmc_stop((ushort)CardNum, (ushort)(Axis - 1), 0);
                    return 4;
                }
                Thread.Sleep(5);//扫瞄周期
            }
            while (!Mot_Running(CardNum, Axis));
            ushort ReFlag = 0;
            IsCheck("dmc_get_home_result", LTDMC.dmc_get_home_result(0, (ushort)(Axis - 1), ref ReFlag));//检查回零是否成功
            if (ReFlag == 0) return 2;
            Thread.Sleep(100);
            LTDMC.dmc_set_encoder((ushort)CardNum, (ushort)(Axis-1),0);
            return 0;
        }

        /// <summary>
        /// 直线插补
        /// </summary>
        /// <returns></returns>
        public bool LinearInterMove(short CardNum,short Crd, short AxisNum, double Vel,double Acc,ushort [] AxisList, int[] DisLlist,ushort Mode)
        {
            double Accpuse = Acc * 1000000;
            double AccTime = Math.Round(Vel / Accpuse, 3);//计算加速时间
            LTDMC.dmc_set_vector_profile_multicoor((ushort)CardNum,(ushort)Crd,100,Vel, AccTime, AccTime, 100);
            LTDMC.dmc_line_multicoor((ushort)CardNum, (ushort)Crd,(ushort)AxisNum ,AxisList,DisLlist,Mode);
            return Rtn;
        }
        /// <summary>
        /// 判断坐标系停止
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Crd"></param>
        /// <returns></returns>
        public bool CrdRunning(short CardNum, short Crd)
        {
            bool BoolRtn = false;
            short rtn = LTDMC.dmc_check_done_multicoor((ushort)CardNum, (ushort)Crd);
            if (rtn == 0)
            {
                BoolRtn = false;
            }
            else if (rtn == 1)
            {
                BoolRtn = true;
            }
            return BoolRtn;
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
