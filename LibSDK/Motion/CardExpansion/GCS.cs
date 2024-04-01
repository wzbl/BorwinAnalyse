using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using csLTDMC;
using GC.Frame.Motion.Privt;
using GC.Motion;
using static GC.Motion.Scpt;


//高川板卡
namespace LibSDK.Motion
{
    class GCS : MotionBase,CardInterface
    {
        private static ushort[] devhandle = new ushort[4];
        private static ushort[,] axishandle = new ushort[4, 10];
        private static ushort[,] crdhandle = new ushort[4, 2];
        private static string[] crdname = new string[4] {"CARD1","CARD2", "CARD3","CARD4" };
        
        public  bool HomeStop { get; set; }//回零停止
       
        /// <summary>
        /// 回零运行中
        /// </summary>
        public bool HomeRuning { get; set; }

        /// <summary>
        /// 初始化控制卡
        /// </summary>
        /// <param name="Path"></param>
        public bool CrdIni(short cardNum, string pFile)
        {
            //需要GCS给多卡命名，按名称打开不会导致卡号错乱
            rtn = CNMCLib20.NMC_DevOpenByID(crdname[cardNum], ref devhandle[cardNum]);
            if (rtn != 0) { return false; }
            //板卡复位
            rtn = CNMCLib20.NMC_DevReset(devhandle[cardNum]);
            //加载配置文件
            if (pFile != "")
            {
                rtn = CNMCLib20.NMC_LoadConfigFromFile(devhandle[cardNum], System.Text.ASCIIEncoding.Default.GetBytes(pFile));
                if (rtn != 0)
                {
                    return false;
                }
            }
            for (int i = 0; i < 8; i++)
            {
              rtn = CNMCLib20.NMC_MtOpen(devhandle[cardNum], (short)i, ref axishandle[cardNum, i]);
              rtn = CNMCLib20.NMC_MtSetAxisArrivalPara(axishandle[cardNum, i], 10, 5);
            }
            
            rtn = CNMCLib20.NMC_CrdOpenEx(devhandle[cardNum], 0, ref crdhandle[cardNum, 0]);
            rtn = CNMCLib20.NMC_CrdOpenEx(devhandle[cardNum], 1, ref crdhandle[cardNum, 1]);
            return true;
        }

        /// <summary>
        /// 关闭板卡
        /// </summary>
        /// <param name="CardNum"></param>
        /// <returns></returns>
        public bool CloseCard(short CardNum = 0)
        {
            rtn = CNMCLib20.NMC_DevClose(ref devhandle[CardNum]);
            return true;
        }

        /// <summary>
        /// 初始化扩展模块
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public bool ExMdlIni(short CardNum, int MdlNum = 3, params string[] FileName)
        {
            if (MdlNum <= 0) { return true; }
            for (int i = 1; i <= MdlNum; i++)
            {
                //使能拓展模块，以及获取坐标系句柄
                rtn = CNMCLib20.NMC_SetIOModuleEn(devhandle[CardNum], (byte)(i+1));
                if (rtn!=0) return false;
                Thread.Sleep(10);
            }
            return true;
        }

        /// <summary>
        /// 使能开
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        public bool Servon(short CardNum, short Axis)
        {
            rtn = CNMCLib20.NMC_MtClrError(axishandle[CardNum, Axis - 1]);
            Thread.Sleep(1);
            rtn = CNMCLib20.NMC_MtSetSvOn(axishandle[CardNum, Axis-1]);
            if (rtn != 0) return false;
            return true;
        }

        /// <summary>
        /// 设置轴的软限位
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <param name="P_Limit"></param>
        /// <param name="N_Limit"></param>
        /// <returns></returns>
        public bool SetSofLimit(short CardNum, short Axis, bool Enable, double P_Limit, double N_Limit)
        {
            rtn += CNMCLib20.NMC_MtSwLmtValue(axishandle[CardNum, Axis-1], (int)P_Limit, (int)N_Limit);
            if (Enable)
            {
                rtn += CNMCLib20.NMC_MtSwLmtOnOff(axishandle[CardNum, Axis - 1], 1);
            }
            else
            {
                rtn += CNMCLib20.NMC_MtSwLmtOnOff(axishandle[CardNum, Axis - 1], 0);
            }
            if (rtn != 0) return false;
            return true;
        }

        /// <summary>
        /// 设置轴正负限位
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <param name="El_Enable"></param>
        /// <param name="EL_Logic"></param>
        /// <param name="EL_Mode"></param>
        /// <returns></returns>
        public bool SetELMode(short CardNum, short Axis, short El_Enable, short EL_Logic, short EL_Mode)
        {
            rtn = CNMCLib20.NMC_MtSetLmtCfg(axishandle[CardNum, Axis - 1], El_Enable, El_Enable, EL_Logic, EL_Logic);
            if (rtn != 0) return false;
            return true;
        }

        /// <summary>
        /// 使能关
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        public bool Servoff(short CardNum, short Axis)
        {
            rtn = CNMCLib20.NMC_MtSetSvOff(axishandle[CardNum, Axis - 1]);
            return true;
        }

        /// <summary>
        ///  读取使能信号
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        public bool SevOn(short CardNum, short Axis)
        {
            short pStsWord = 0;
            rtn = CNMCLib20.NMC_MtGetSts(axishandle[CardNum, Axis - 1], ref pStsWord);
            if ((pStsWord & CNMCLib20.BIT_AXIS_SVON) != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 清除轴状态
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        public bool ClearAxisState(short CardNum, short Axis)
        {
            rtn = CNMCLib20.NMC_MtClrError(axishandle[CardNum, Axis - 1]);
            if (rtn != 0) return false;
            return true;
        }

        /// <summary>
        /// 连续运动
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <param name="Direction"></param>
        /// <param name="Vel"></param>
        /// <returns></returns>
        public bool JogMove(short CardNum, short Axis, short Direction, double Vel)
        {

            short dir=0;
            if (Direction == 0) { dir = -1; }
            else { dir = 1; }
            rtn = CNMCLib20.NMC_MtClrError(axishandle[CardNum, Axis - 1]);
            rtn = CNMCLib20.NMC_MtMoveJog(axishandle[CardNum, Axis - 1], 1, 1, dir * Vel, 0, 1);
            if (rtn != 0) return false;
            return true;
        }

        /// <summary>
        /// 点位运动
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <param name="Pos"></param>
        /// <param name="Vel"></param>
        /// <param name="Acc"></param>
        /// <param name="RunMode"></param>
        /// <returns></returns>
        public bool PMove(short CardNum, short Axis, double Pos, double Vel, double Acc, int RunMode = 1)
        {
            rtn = CNMCLib20.NMC_MtClrError(axishandle[CardNum, Axis - 1]);
            if (RunMode == 1)
            {
                //绝对运动
                rtn = CNMCLib20.NMC_MtMovePtpAbs(axishandle[CardNum, Axis - 1], Acc, Acc, 0, 0, Vel, 0, (int)Pos);
            }
            else
            {
                //相对运动,Pos为正则正向相对移动，为负则负向相对移动
                rtn = CNMCLib20.NMC_MtMovePtpRel(axishandle[CardNum, Axis - 1], Acc, Acc, 0, 0, Vel, 0, (int)Pos);
            }
            if (rtn != 0) return false;
            return true;
        }

        /// <summary>
        /// 软着陆运动
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <param name="mid_pos"></param>
        /// <param name="aim_pos"></param>
        /// <param name="MinVel"></param>
        /// <param name="MaxVel"></param>
        /// <param name="Acc"></param>
        /// <param name="RunMode"></param>
        /// <returns></returns>
        public bool S_PMove(short CardNum, short Axis, double high_pos, double low_pos, double MinVel, double MaxVel, double Acc, int RunMode =0)
        {
            short rtn = 0;
            rtn = CNMCLib20.NMC_MtClrError(axishandle[CardNum, Axis - 1]);
            switch (RunMode)
            {
                case 0:
                    CNMCLib20.TPvtMoveHighToLow pvt = new CNMCLib20.TPvtMoveHighToLow();
                    pvt.highAcc = Acc;
                    pvt.highDec = Acc;
                    pvt.highDist = (int)high_pos;
                    pvt.highVel = MaxVel;
                    pvt.lowDec = Acc;
                    pvt.lowDist = (int)low_pos;
                    pvt.lowVel = MinVel;
                    pvt.smooth = 0;
                    pvt.startVel = 0;
                    pvt.reseved = new short[3] { 0, 0, 0 };
                    rtn = CNMCLib20.OEM_MtPvtMoveHighToLow(axishandle[CardNum, Axis - 1], ref pvt);
                    break;
                case 1:
                    CNMCLib20.TPvtMoveLowToHigh Lhpvt = new CNMCLib20.TPvtMoveLowToHigh();
                    Lhpvt.highAcc = Acc;
                    Lhpvt.highDec = Acc;
                    Lhpvt.highDist=(int)high_pos;
                    Lhpvt.lowDist =(int)low_pos;
                    Lhpvt.highVel = MaxVel;
                    Lhpvt.lowVel = MinVel;
                    Lhpvt.lowAcc = Acc;
                    Lhpvt.smooth = 0;
                    Lhpvt.startVel = 0;
                    Lhpvt.reseved = new short[3] { 0, 0, 0 };
                    rtn = CNMCLib20.OEM_MtPvtMoveLowToHigh(axishandle[CardNum, Axis - 1], ref Lhpvt);
                    break;
            }
            if (rtn != 0) return false;
            return true;
        }

        /// <summary>
        /// 在线变速
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <param name="Vel"></param>
        public void ChangeSpeed(short CardNum, short Axis, double Vel)
        {
            rtn += CNMCLib20.NMC_MtSetVel(axishandle[CardNum, Axis - 1], Vel);
            rtn += CNMCLib20.NMC_MtUpdate(axishandle[CardNum, Axis - 1]);
        }

        /// <summary>
        /// 读取规划位置
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        public double GetPrfPluse(short CardNum, short Axis)
        {
            int pos = 0;
            rtn = CNMCLib20.NMC_MtGetPrfPos(axishandle[CardNum, Axis - 1], ref pos);
            return pos;
        }

        /// <summary>
        /// 读取编码器位置
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        public double GetEncPluse(short CardNum, short Axis)
        {
            int pos = 0;
            rtn = CNMCLib20.NMC_MtGetEncPos(axishandle[CardNum, Axis - 1], ref pos);
            return pos;
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
            rtn = CNMCLib20.NMC_MtStop(axishandle[CardNum, Axis - 1]);
            rtn = CNMCLib20.NMC_MtHomeStop(axishandle[CardNum, Axis - 1]);
            return true;
        }

        /// <summary>
        /// 紧急停止所有轴
        /// </summary>
        /// <param name="CardNum"></param>
        /// <returns></returns>
        public bool EmgStop(short CardNum)
        {
            for (int i = 0; i < 10; i++)
            {
                rtn = CNMCLib20.NMC_MtEstp(axishandle[CardNum, i]);
            }
            return true;
        }

        /// <summary>
        /// 单轴回零
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <param name="HomeOffset"></param>
        /// <returns></returns>
        public int AxisHome(short CardNum, short Axis, double HomeOffset, double Spd, double Capspd, int HomeMode, short Level, short HomeDir, int Timeout)
        {
            Stopwatch sw = new Stopwatch();//回零超时计时器、
            rtn = CNMCLib20.NMC_MtClrError(axishandle[CardNum, Axis - 1]);
            rtn = CNMCLib20.NMC_MtZeroPos(axishandle[CardNum, Axis - 1]);
            CNMCLib20.THomeSetting setting = new CNMCLib20.THomeSetting(true);
            rtn = CNMCLib20.NMC_MtGetHomePara(axishandle[CardNum, Axis - 1], ref setting);
            //回零参数配置
            setting.mode = (short)HomeMode;//设置回零模式
            setting.dir = (short)HomeDir;//设置回零方向 0-  1+
            setting.offset = (int)HomeOffset;//设置回零后偏移量
            setting.scan1stVel = (double)Spd;//第一段回零速度
            setting.scan2ndVel = (double)Capspd;//第二段回零速度
            setting.acc = 0.5;//回零加速度
            setting.reScanEn = 1;//设置为2次回零
            setting.homeEdge =(byte)Level;  //原点触发沿，低电平触发为下降沿，反之为上升沿  
            setting.lmtEdge = (byte)Level;  //限位触发沿，低电平触发为下降沿，反之为上升沿  
            setting.zEdge = (byte)Level;    // Z相位,触发沿(默认下降沿)
            setting.iniRetPos = 0;          //起始反向距离
            setting.retSwOffset = 0;       // 反向运动时离开开关距离(可选,不用时设为0)
            setting.safeLen = 0;          //安全距离,回零时最远搜寻距离(可选,不用时设为0,不限制距离)
            setting.usePreSetPtpPara = 0;//当usePreSetPtpPara=0时，回零运动的减加速度默认等于 acc,起跳速度、终点速度、平滑系数默认为0
            //获取原点电平配置
            rtn = CNMCLib20.NMC_MtSetHomePara(axishandle[CardNum, Axis - 1], ref setting);
            rtn = CNMCLib20.NMC_MtHome(axishandle[CardNum, Axis-1]);
            if (rtn != 0) { return  1; }
            //启动回零后延时50毫秒，保证轴的状态已经改变
            Thread.Sleep(50);
            sw.Start();
            short homeSts=0;
            do
            {
                Thread.Sleep(5);
                if (sw.ElapsedTicks / (decimal)Stopwatch.Frequency > Timeout)//回零 超时
                {
                    sw.Stop();
                    return 3;
                }
                if (Mot_ALM(CardNum, Axis))
                {
                    //驱动器报警停止回零
                    AxisStop(CardNum, Axis, 0);
                    return 2;
                }
                if (HomeStop)//手动停止轴
                {
                    AxisStop(CardNum, Axis, 0);
                    return 4;
                }
                rtn = CNMCLib20.NMC_MtGetHomeSts(axishandle[CardNum, Axis - 1], ref homeSts); //读取回零状态
                if ((homeSts & CNMCLib20.BIT_AXHOME_BUSY) == 0)
                {
                    if ((homeSts & CNMCLib20.BIT_AXHOME_OK) != 0)
                    {
                      return 0;//回零成功
                    }
                    else if(((homeSts & CNMCLib20.BIT_AXHOME_FAIL) != 0)
                    || ((homeSts & CNMCLib20.BIT_AXHOME_ERR_MV) != 0)
                    || ((homeSts & CNMCLib20.BIT_AXHOME_ERR_SWT) != 0))
                    {
                        return 2; // 回零过程出现错误
                    }
                    else
                    {
                        return 4; //回零中手动急停
                    }
                }
            } while (true);
        }

        /// <summary>
        /// 设置输出IO信号
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="DoNum"></param>
        /// <param name="value"></param>
        public bool SetDo(short CardNum, short IoNum, short value)
        {
            rtn = CNMCLib20.NMC_SetDOBit(devhandle[CardNum], IoNum, value);
            return rtn == 0;
        }

        /// <summary>
        /// 读取输出IO信号
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="DoNum"></param>
        /// <returns></returns>
        public bool GetDo(short CardNum, short IoNum)
        {
            try
            {
                CNMCLib20.NMC_GetDOGroup(devhandle[CardNum], out Int32 value, 0);

                int val = (int)Math.Pow(2, IoNum);

                int va = val & (Math.Abs(value) - 1);
                if (val == va)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }

        
        }

        /// <summary>
        /// 读取输入信号
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="DoNum"></param>
        /// <returns></returns>
        public bool GetDi(short CardNum, short IoNum)
        {
            try
            {
                short bitValue = 0;
                rtn = CNMCLib20.NMC_GetDIBit(devhandle[CardNum], IoNum, ref bitValue);
                return bitValue == 0;
            }
            catch (Exception )
            {
                return false;
            }
          
        }

        /// <summary>
        /// 设置扩展模块输出
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="mdl"></param>
        /// <param name="DoNum"></param>
        /// <param name="value"></param>
        public bool SetExtmdlDO(short CardNum, short mdl, short IoNum, ushort value)
        {
            rtn = CNMCLib20.NMC_SetDOBit(devhandle[CardNum], (short)((mdl) * 64 + IoNum-1), (short)value);
            return rtn == 0;
        }

        /// <summary>
        /// 读取扩展模块输出
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="mdl"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        public bool GetExtmdDO(short CardNum, short mdl, short IoNum)
        {
            short bitValue = 0;
            rtn = CNMCLib20.NMC_GetDOBit(devhandle[CardNum], (short)((mdl) * 64 + IoNum-1), ref bitValue);
            return bitValue == 0;
        }

        /// <summary>
        /// 读取扩展模块输入
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="mdl"></param>
        /// <param name="DoNum"></param>
        /// <returns></returns>
        public bool GetExtmdDi(short CardNum, short mdl, short IoNum)
        {
            short bitValue = 0;
            rtn = CNMCLib20.NMC_GetDIBit(devhandle[CardNum], (short)((mdl)*64 + IoNum-1), ref bitValue);
            return bitValue == 0;
        }

        /// <summary>
        /// 轴报警
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        public bool Mot_ALM(short CardNum, short Axis)
        {
            short pStsWord = 0;
             rtn = CNMCLib20.NMC_MtGetSts(axishandle[CardNum, Axis - 1], ref pStsWord);
            if ((pStsWord & CNMCLib20.BIT_AXIS_ALM) != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 正限位
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        public bool Mot_PEL(short CardNum, short Axis)
        {
            short pStsWord = 0;
             rtn = CNMCLib20.NMC_MtGetSts(axishandle[CardNum, Axis - 1], ref pStsWord);
            if ((pStsWord & CNMCLib20.BIT_AXIS_LMTP) != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 负限位
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        public bool Mot_NEL(short CardNum, short Axis)
        {
            short pStsWord = 0;
             rtn = CNMCLib20.NMC_MtGetSts(axishandle[CardNum, Axis - 1], ref pStsWord);
            if ((pStsWord & CNMCLib20.BIT_AXIS_LMTN) != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 原点信号
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        public bool Mot_ORG(short CardNum, short Axis)
        {
            int orgvalue = 0;
            rtn = CNMCLib20.NMC_MtGetMotionIOLogical(axishandle[CardNum, Axis - 1], ref orgvalue);
            if ((orgvalue & CNMCLib20.BIT_AXMTIO_HOME) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 软负限位信号
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        public bool Mot_SLN(short CardNum, short Axis)
        {
            short pStsWord = 0;
             rtn = CNMCLib20.NMC_MtGetSts(axishandle[CardNum, Axis - 1], ref pStsWord);
            if ((pStsWord & CNMCLib20.BIT_AXIS_SOFTNEGLMT) != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 软正限位信号
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        public bool Mot_SLP(short CardNum, short Axis)
        {
            short pStsWord = 0;
             rtn = CNMCLib20.NMC_MtGetSts(axishandle[CardNum, Axis-1], ref pStsWord);
            if ((pStsWord & CNMCLib20.BIT_AXIS_SOFTPOSLMT) != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 电机运行状态
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        public bool Mot_Running(short CardNum, short Axis)
        {
            short pStsWord = 0;
            rtn = CNMCLib20.NMC_MtGetSts(axishandle[CardNum, Axis - 1], ref pStsWord);
            if((pStsWord & 1)==0&&(pStsWord & 2)!=0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///伺服到位信号
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        public bool GetCheckDone(short CardNum, short Axis)
        {
            short pStsWord = 0;
            short rtn = CNMCLib20.NMC_MtGetSts(axishandle[CardNum, Axis - 1], ref pStsWord);
            if ((pStsWord & 1) == 0 && (pStsWord & 2) != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region 高速位置比较
        public bool CmpMode(short CardNum, short Axis, short group,short Hcmp, int time, short cmp_logic, int Mode)
        {
            short rtn = 0;
            rtn = CNMCLib20.NMC_Comp2DimensOnoff(devhandle[CardNum], group, 0, Hcmp);
            //清除数据
            rtn = CNMCLib20.NMC_Comp2DimensSetData(devhandle[CardNum], group, new int[2] { 0, 0 }, 0, Hcmp);
            CNMCLib20.TComp2DimensParamEx paramEx = new CNMCLib20.TComp2DimensParamEx(true);
            paramEx.chnType = 1;     //高速口输出
            paramEx.dir1No =(short)(Axis-1);//比较轴号
            paramEx.dir2No = -1;     //只比较Axis
            paramEx.errZone = 50;    //位置误差
            paramEx.gateTime = time; //脉冲时间，us
            paramEx.outputChn = 0;   //为高速口时该参数无效
            paramEx.outputType = 0; //脉冲型输出
            paramEx.posSrc = 1;     //比较源为编码器
            paramEx.stLevel = 0;   //初始为低电平
            rtn = CNMCLib20.NMC_Comp2DimensSetParamEx(devhandle[CardNum], group, ref paramEx, Hcmp);
            return rtn == 0;
        }
        public bool addHcmpPoint(short CardNum, short Hcmp, int Pos)
        {
            rtn += CNMCLib20.NMC_Comp2DimensSetData(devhandle[CardNum], Hcmp, new int[2] { Pos, 0 }, 1, 0);
            CNMCLib20.TComp2DimensSts sts = new CNMCLib20.TComp2DimensSts();
            rtn += CNMCLib20.NMC_Comp2DimensStatusEx(devhandle[CardNum], Hcmp, ref sts, 0);
            if (sts.sts != 1)
            {
                rtn += CNMCLib20.NMC_Comp2DimensOnoff(devhandle[CardNum], Hcmp, 1, 0);
            }
            return rtn == 0;
        }
        public bool ClearHcmpPoint(short CardNum,short Hcmp)
        {
            //清除数据
            rtn = CNMCLib20.NMC_Comp2DimensSetData(devhandle[CardNum], Hcmp, new int[2] { 0, 0 }, 0, 0);//count=0为清除数据
            return rtn == 0;
        }

        /// <summary>
        /// 清除捕获状态
        /// </summary>
        public bool ClearCapSts(short CardNum, short Axis, short ch)
        {
            rtn = CNMCLib20.NMC_MtClrAdvCaptSts(axishandle[CardNum, Axis - 1], ch);
            if (rtn != 0) return false;
            else return true;
        }

        /// <summary>
        /// 设置捕获参数
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <param name="Pos"></param>
        /// <param name="ch">捕获的通道号</param>
        /// <returns></returns>
        public bool SetCap(short CardNum, short Axis,int Pos,short ch)
        {
            //高级捕获,轴编码器位置达到时捕获
            rtn = CNMCLib20.NMC_MtClrAdvCaptSts(devhandle[CardNum], ch);
            CNMCLib20.TAdvCaptureParam adv = new CNMCLib20.TAdvCaptureParam();
            adv.capPosIndex =(short)(Axis - 1);
            adv.filter = 0;
            adv.trigIndex=(short)(Axis - 1); ;  //触发源序号。(默认0)
            adv.trigSrc  =6;    //编码器位置触发
            adv.trigValue = Pos;//1轴编码器为1000时触发
            rtn = CNMCLib20.NMC_MtSetAdvCaptParam(devhandle[CardNum], ref adv, ch);
           if (rtn != 0) return false;
            else return true;
        }
        public bool GetCapSts(short CardNum, short Axis, short ch)
        {
            short captsts = 0;
            int[] pos = new int[4];
            rtn = CNMCLib20.NMC_MtGetAdvCaptPos(devhandle[CardNum], ref captsts, ref pos[0], ch);
            if (rtn != 0) return false;
            if ((captsts & 1) != 0&& rtn==0)
            {
              return true;
            }
            else return false;
        }
    
        #endregion

        /// <summary>
        /// 直线插补
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Crd"></param>
        /// <param name="AxisNum"></param>
        /// <param name="Vel"></param>
        /// <param name="Acc"></param>
        /// <param name="AxisList"></param>
        /// <param name="DisLlist"></param>
        /// <param name="Mode"></param>
        /// <returns></returns>
        public bool LinearInterMove(short CardNum, short Crd, short AxisNum, double Vel, double Acc, ushort[] AxisList, int[] DisLlist, ushort Mode)
        {
            ushort pCrdHandle = (ushort)Crd;
            short rtn = CNMCLib20.NMC_CrdOpenEx(devhandle[CardNum], Crd, ref crdhandle[CardNum, Crd]);
            CNMCLib20.TCrdConfig crdConfig = new CNMCLib20.TCrdConfig(true);
            crdConfig.axCnts = AxisNum;
            short mask = 0;
            for (int i = 0; i < AxisList.Length; i++)
            {
                crdConfig.pAxArray[i] = (short)AxisList[i];
                mask += (short)(1 << AxisList[i]);
            }
            rtn = CNMCLib20.NMC_CrdConfig(crdhandle[CardNum, Crd], ref crdConfig);
            CNMCLib20.TCrdPara crdPara = new CNMCLib20.TCrdPara(true);
            crdPara.orgFlag = 1;
            crdPara.offset = new int[4] { 0, 0, 0, 0 };
            crdPara.synAccMax = 50;
            crdPara.synVelMax = 1000;
            rtn = CNMCLib20.NMC_CrdSetPara(crdhandle[CardNum, Crd], ref crdPara);
            rtn = CNMCLib20.NMC_CrdLineXYZEx(crdhandle[CardNum, Crd], 0, mask, DisLlist, 0, Vel, Acc, 0);
            rtn = CNMCLib20.NMC_CrdEndMtn(crdhandle[CardNum, Crd]);
            rtn = CNMCLib20.NMC_CrdStartMtn(crdhandle[CardNum, Crd]);
            return true;
        }

        public bool CrdRunning(short CardNum, short Crd)
        {
            short sts = 0;
            rtn = CNMCLib20.NMC_CrdGetSts(crdhandle[CardNum, Crd], ref sts);
            if ((sts & CNMCLib20.BIT_CORD_BUSY)==0)
            {
               return true;
            }
            else
            {
              return false;
            }
        }
        #region 高川脚本操作API
        /// <summary>
        ///  Scpt初始化
        /// </summary>
        /// <param name="cardNum"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public override bool ScptIni(int instIdx, short cardNum)
        {
            //RunMode 0:下位机模式  1:上位机模式
            rtn = (short)Scpt.ScptItf_InitByHandle(instIdx, devhandle[cardNum], 0, 1000, 10);
            if (rtn != 0) return false;
            else return true;
        }

        /// <summary>
        /// 下载bin文件
        /// </summary>
        /// <returns></returns>
        public override bool ScpDownLoad(int idx, string filepath, short Autorun)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(filepath);
            rtn = (short)Scpt.ScptItf_Download(idx, bytes, Autorun);
            if (rtn != 0) return false;
            return true;
        }

        /// <summary>
        /// 配置自动运行参数
        /// </summary>
        /// <param name="idx">实例序号【0-7】</param>
        /// <param name="AutorunEn">是否自启动，1：开机自启动，0：开机不自启动 </param>
        /// <param name="AutorunDisGpiindex">
        /// 开机自启动跳过 DI（开机时，此 di 有输入，则跳过自
        ///  启动）, 取值范围[0, 16]，0 表示不设置该选项</param>
        /// <returns></returns>
        public override bool ScpRunconfig(int idx, short AutorunEn, short AutorunDisGpiindex)
        {
            rtn = (short)Scpt.ScptItf_CfgAutoRun(idx, AutorunEn, AutorunDisGpiindex, 0);
            if (rtn != 0) return false;
            else return true;
        }
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
        public override bool ScpRun(int idx, int flag)
        {
            rtn = (short)Scpt.ScptItf_RunControl(idx, flag);
            if (rtn != 0) return false;
            else return true;
        }
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
        public override bool ScptGetStatus(int idx, ref Scpt.TScptStsUser pSts)
        {
            rtn = (short)Scpt.ScptItf_GetStatus(idx, ref pSts);
            if (rtn != 0) return false;
            else return true;
        }
        /// <summary>
        /// 用户变量读取 
        /// </summary>
        /// <param name="idx">实例序号，取值范围[0,7]</param>
        /// <param name="VarType">变量类型，0:double,1:float,2:Int32,3:Int16</param>
        /// <param name="varidx">变量序号,取值范围[1,max]</param>
        /// <returns>读回的数值 -1读取失败</returns>
        public override double ScpUserVarRead(int idx, short VarType, short varidx)
        {
            double value = 0;
            rtn = (short)Scpt.ScptItf_UserVarRead(idx, VarType, varidx, ref value);
            if (rtn != 0) return -1;
            else return value;
        }
        /// <summary>
        /// 用户变量写入
        /// </summary>
        /// <param name="idx">实例序号，取值范围[0,7]</param>
        /// <param name="VarType">变量类型，0:double,1:float,2:Int32,3:Int16</param>
        /// <param name="varidx">变量序号,取值范围[1,max]</param>
        /// <param name="Val">写的数值</param>
        /// <returns></returns>
        public override bool ScpUserVarWrite(int idx, short VarType, short varidx, double Val)
        {
            rtn = (short)Scpt.ScptItf_UserVarWrite(idx, VarType, varidx, Val);
            if (rtn != 0) return false;
            else return true;

        }
        /// <summary>
        /// 用户变量读取（多个）
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="VarType"></param>
        /// <param name="varidx"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public override double[] ScpUserVarReadEx(int idx, short VarType, short varidx, short count)
        {
            double[] value = new double[10];
            rtn = (short)Scpt.ScptItf_UserVarReadEx(idx, VarType, varidx, count, value);
            if (rtn != 0) return null;
            else return value;
        }

        /// <summary>
        /// 用户变量写入（多个） 
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="VarType"></param>
        /// <param name="varidx"></param>
        /// <param name="count"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public override bool ScpUserVarWriteEx(int idx, short VarType, short varidx, short count, double[] values)
        {
            rtn = (short)Scpt.ScptItf_UserVarWriteEx(idx, VarType, varidx, count, values);
            if (rtn != 0) return false;
            else return true;
        }


        /// <summary>
        /// 设置全局变量值 
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="pVarName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool ScpSetGlobalVarValue(int idx, string pVarName, double value)
        {
            rtn = (short)Scpt.ScptItf_SetGlobalNumVarValue(idx, pVarName, value);
            if (rtn != 0) return false;
            else return true;
        }

        /// <summary>
        /// 读全局变量值
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="pVarName"></param>
        /// <returns></returns>
        public override double ScpGetGlobalVarValue(int idx, string pVarName)
        {
            double value = 0;
            rtn = (short)Scpt.ScptItf_GetGlobalNumVarValue(idx, pVarName, ref value);
            if (rtn != 0) return -1;
            else return value;
        }
        /// <summary>
        /// 带任务启动掩码的启动运行 
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="taskMask"></param>
        /// <returns></returns>
        public override bool ScpRunEx(int idx, int taskMask)
        {
            rtn = (short)Scpt.ScptItf_RunEx(idx, taskMask);
            if (rtn != 0) return false; else return true;
        }

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
        public override bool ScpGetTaskSts(int idx, short taskIdx, ref TScptTaskSts pSts)
        {
            rtn = (short)Scpt.ScptItf_GetTaskSts(idx, taskIdx, ref pSts);
            if (rtn != 0) return false; else return true;
        }

        #endregion
    }
}
