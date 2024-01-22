using LibSDK.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibSDK.Motion
{
    public class MotAPI : MotionBase
    {
        private readonly BoardSwitchCs Card = new BoardSwitchCs();

        public int HomeRtn;

        public int HError;
        private bool homeStop;
        /// <summary>
        /// 回零停止
        /// </summary>
        public bool HomeStop {
            get
            { return homeStop;
            }
            set
            {
                homeStop = value;
                Card.API.HomeStop = value;
            }
        }
       

        private CAxisParm AxisParm;

        /// <summary>
        /// 回零结果
        /// </summary>
        public bool HomeState { get; set; }
        /// <summary>
        /// 回零线程
        /// </summary>
        private Task HomeTask;

        /// <summary>
        /// 停止回零线程
        /// </summary>
        public CancellationTokenSource StopManualTask = new CancellationTokenSource();

        public void ExecuteHome(Action ation)
        {
            if (HomeTask != null)
                if (HomeTask.Status == TaskStatus.Running) { 
                    //new Alarm.Alarm().MesShow(0, "Warning", "Return to zero task execution, can not be repeated!", "OK"); 
                    return; }
            StopManualTask.Dispose();
            StopManualTask = new CancellationTokenSource();
            HomeTask = Task.Factory.StartNew(ation, StopManualTask.Token);
        }
        public bool IsHomeRun()
        {
            if (HomeTask != null)
                if (HomeTask.Status == TaskStatus.Running)
                    return true;
            return false;
        }
        public MotAPI() { }
        public MotAPI(CAxisParm axisParm, MotorType motorType = MotorType.Servo)
        {
            this.CardNum = axisParm.CardID;
            this.Axis = axisParm.AxisID;
            this.MotorType = motorType;
            this.AxisParm = axisParm;
        }
        /// <summary>
        /// 连续运动
        /// </summary>
        /// <param name="directon"></param>
        /// <param name="Spd"></param>
        /// <returns></returns>
        public bool JOP(short directon, double Spd)
        {
            double Vel = this.PosToVel(Spd, CardNum, Axis);//速度换算
            return Card.API.JogMove(CardNum, Axis, directon, Vel);
        }
        /// <summary>
        /// 点位运动
        /// </summary>
        /// <param name="Spd"></param>
        /// <param name="Acc"></param>
        /// <param name="Pos"></param>
        /// <param name="Mode">0.相对运动模式，1.绝对运动模式</param>
        /// <returns></returns>
        public bool PMove(double Spd, double Acc, double Pos, int Mode,bool IsLimt=false)
        {
            double _Pos = PosToPulse(Pos, CardNum, Axis);//位置换算
            double _Spd = PosToVel(Spd, CardNum, Axis);//速度换算
            double _Acc = PosToVcc(Acc, CardNum, Axis);//加速度换算
            if(IsLimt)
            {
                if(Pos < AxisParm.PosLimit&& Pos > 0)
                {
                    return Card.API.PMove(CardNum, Axis, _Pos, _Spd, _Acc, Mode);
                }
                else
                {
                  //SDK.Log.AddLog(AxisParm.AxisName + "目标位置超过软极限", 2);
                  //SDK.Alarm.Show("System Error", "S0002", AxisParm.AxisName + "目标位置超过软极限", "I");
                  return false;
                }
            }
            else
            {
              return Card.API.PMove(CardNum, Axis, _Pos, _Spd, _Acc, Mode);
            }
        }

        public bool S_PMove(double hightPos,double LowPos,double MinVel, double MaxVel, double Acc, int Mode)
        {
            double _hightPos = PosToPulse(hightPos, CardNum, Axis);//位置换算
            double _LowPos = PosToPulse(LowPos, CardNum, Axis);//位置换算
            double _MaxVel = PosToVel(MaxVel, CardNum, Axis);//速度换算
            double _MinVel = PosToVel(MinVel, CardNum, Axis);//速度换算
            double _Acc = PosToVcc(Acc, CardNum, Axis);//加速度换算
            return Card.API.S_PMove(CardNum, Axis, _hightPos, _LowPos, _MinVel, _MaxVel, _Acc, Mode);
        }
        /// <summary>
        /// 设置轴的软限位
        /// </summary>
        /// <param name="P_Limit"></param>
        /// <param name="N_Limit"></param>
        /// <returns></returns>
        public bool SetLimit(double P_Limit,double N_Limit,bool Enable)
        {
            double _P_Limit= PosToPulse(P_Limit, CardNum, Axis);//位置换算
            double _N_Limit = PosToPulse(N_Limit, CardNum, Axis);//位置换算
            return Card.API.SetSofLimit(CardNum, Axis, Enable, _P_Limit, _N_Limit);
        }
        /// <summary>
        /// 设置轴的软限位
        /// </summary>
        /// <param name="P_Limit"></param>
        /// <param name="N_Limit"></param>
        /// <returns></returns>
        public bool SetLimit(bool Enable)
        {
            double _P_Limit = PosToPulse(AxisParm.PosLimit, CardNum, Axis);//位置换算
            double _N_Limit = PosToPulse(AxisParm.NegLimit, CardNum, Axis);//位置换算
            return Card.API.SetSofLimit(CardNum, Axis, Enable, _P_Limit, _N_Limit);
        }

        public void ChangSpeed(double Spd)
        {
            double _Spd = PosToVel(Spd, CardNum, Axis);//速度换算
            Card.API.ChangeSpeed(CardNum, Axis, _Spd);
        }
       /// <summary>
       /// 设置轴硬限位
       /// </summary>
       /// <param name="Enable"></param>
       /// <returns></returns>
        public bool SetELMode(short Enable)
        {
            return Card.API.SetELMode(CardNum, Axis, Enable,0,1);
        }
        /// <summary>
        /// 轴使能
        /// </summary>
        /// <returns></returns>
        public bool SetServon()
        {
            return Card.API.Servon(CardNum, Axis);
        }
        /// <summary>
        /// 轴下使能
        /// </summary>
        /// <returns></returns>
        public bool SetServoff()
        {
            return Card.API.Servoff(CardNum, Axis);
        }
        /// <summary>
        /// 获取轴使能状态
        /// </summary>
        /// <returns></returns>
        public bool GetSevOn()
        {
            return Card.API.SevOn(CardNum, Axis);
        }
        /// <summary>
        /// 轴报警
        /// </summary>
        /// <returns></returns>
        public bool ALM()
        {
            return Card.API.Mot_ALM(CardNum, Axis);
        }
        /// <summary>
        /// 正限位
        /// </summary>
        /// <returns></returns>
        public bool PL()
        {
            return Card.API.Mot_PEL(CardNum, Axis);
        }
        /// <summary>
        /// 负限位
        /// </summary>
        /// <returns></returns>
        public bool EL()
        {
            return Card.API.Mot_NEL(CardNum, Axis);
        }
        /// <summary>
        /// 原点
        /// </summary>
        /// <returns></returns>
        public bool ORG()
        {
          return Card.API.Mot_ORG(CardNum, Axis);
        }
        /// <summary>
        /// 软负限位
        /// </summary>
        /// <returns></returns>
        public bool SLN()
        {
          return Card.API.Mot_SLN(CardNum, Axis);
        }
        /// <summary>
        /// 软正限位
        /// </summary>
        /// <returns></returns>
        public bool SLP()
        {
            return Card.API.Mot_SLP(CardNum, Axis);
        }
        /// <summary>
        /// 电机运行状态
        /// </summary>
        /// <returns></returns>
        public bool Runing()
        {
          return Card.API.Mot_Running(CardNum, Axis);
        }
        /// <summary>
        /// 电机到位状态
        /// </summary>
        /// <returns></returns>
        public bool CheckMotor()
        {
          return Card.API.GetCheckDone(CardNum, Axis);
        }
        public bool CheckAxisDone(double Acc,double vel , double Pos,double offset)
        {
            bool bDone = false;
            double dis = Math.Abs(GetPrfPluse() - Pos);//位置差
            if (dis < offset )//比较位置
            {
              if (Runing()) { bDone = true; }
              else { bDone = false; }
            }
            else
            {
                if(Runing()&&!ALM())
                {
                    PMove(vel, Acc, Pos, 1);
                }
            }
            return bDone;

        }
        /// <summary>
        /// 读取规划位置
        /// </summary>
        /// <returns></returns>
        public double GetPrfPluse()
        {
          return Card.API.GetPrfPluse(CardNum, Axis);
        }
        public double GetPrfPos()
        {
         return GetPrfPluse() / MotionControl.AxisParm.GetMotionPix(CardNum, Axis);
        }
        public double GetEncPos()
        {
         return GetEncPluse() / MotionControl.AxisParm.GetMotionPix(CardNum, Axis);
        }
        /// <summary>
        /// 读取编码器位置
        /// </summary>
        /// <returns></returns>
        public double GetEncPluse()
        {
          return Card.API.GetEncPluse(CardNum, Axis);
        }
        /// <summary>
        /// 单轴停止
        /// </summary>
        /// <returns></returns>
        public bool AxisStop()
        {
          return Card.API.AxisStop(CardNum, Axis, 0);

        }
        public bool EmgAxisStop()
        {
          return Card.API.AxisStop(CardNum, Axis, 1);
        }
        /// <summary>
        /// 回零错误处理
        /// </summary>
        /// <param name="Code"></param>
        private bool HomeError(int Code)
        {
            string Error = null;
            switch (Code)
            {
                case 1:
                    Error = AxisParm.AxisName+":Instruction call error!/指令调用错误!!!";
                    break;
                case 2:
                    Error = AxisParm.AxisName+":Drive alarm failed to return to zero!/轴驱器报警!";//驱动器报警
                    break;
                case 3:
                    Error = AxisParm.AxisName+":Return to zero timeout!/轴回零超时！";//回零超时！！！
                    break;
                case 4:
                    Error = AxisParm.AxisName + ":Emergency abort back to zero!/紧急停止回零！";//回零超时！！！
                    break;
            }
            if (Error != null)
            {
                MotionControl.HomeFlag = true;
                new CardAPI().StopAxis();//回零失败紧急停止所有轴
                //new Alarm.Alarm().MesShow(0, "Home Error", Error, "Yes/确定");
                return false;
            }
            else
            {
             return true;
            }
        }

        public void Home(double HomeOffset, double Spd, double Capspd, int HomeMode, short Level, short HomeDir,int Timeout)
        {
            HomeState = false;
            HError = 0;
            if (IsHomeRun()) return;
            ExecuteHome(() =>
            {
                HomeStop = false;
                double Offset = PosToPulse(HomeOffset, CardNum, Axis);//位置换算
                double HSpd = PosToVel(Spd, CardNum, Axis);
                double Lspd = PosToVel(Capspd, CardNum, Axis);
                this.HomeRtn = Card.API.AxisHome(CardNum, Axis, Offset, HSpd, Lspd, HomeMode, Level, HomeDir, Timeout);
                HomeError(HomeRtn);
                if (HomeRtn == 0) { HomeState = true; };
            });
        }
        /// <summary>
        /// 单轴回零（提示）
        /// </summary>
        /// <returns></returns>
        public void Home(Action action,int Timeout)
        {
            if (IsHomeRun()) return;
            ExecuteHome(() =>
            {
                HomeStop = false;
                double Offset = PosToPulse(this.AxisParm.Homeoffset, CardNum, Axis);//位置换算
                double HSpd = PosToVel(this.AxisParm.HomeSpd, CardNum, Axis);
                double Lspd = PosToVel(this.AxisParm.SearchHomeSpd, CardNum, Axis);
                this.HomeRtn = Card.API.AxisHome(CardNum, Axis, Offset, HSpd, Lspd, MotionControl.HomeMode, 0, this.AxisParm.HomeDirection, Timeout);
                action();
                HomeError(HomeRtn);

            });
        }

        public void Home(int Timeout)
        {
            HomeState = false;
            HError=0 ;
            if (IsHomeRun()) return;
            ExecuteHome(() =>
            {
                HomeStop = false;
                double Offset = PosToPulse(this.AxisParm.Homeoffset, CardNum, Axis);//位置换算
                double HSpd = PosToVel(this.AxisParm.HomeSpd, CardNum, Axis);
                double Lspd = PosToVel(this.AxisParm.SearchHomeSpd, CardNum, Axis);
                this.HomeRtn = Card.API.AxisHome(CardNum, Axis, Offset, HSpd, Lspd, MotionControl.HomeMode, 0, this.AxisParm.HomeDirection,Timeout);
                HomeError(HomeRtn);
                if(HomeRtn == 0) { HomeState = true;};
            });
        }

        /// <summary>
        /// 清除捕获状态
        /// </summary>
        /// <param name="cn"></param>
        /// <returns></returns>
        public bool ClearCapSts(short cn)
        {
            return Card.API.ClearCapSts(CardNum, Axis, cn);
        }
        /// <summary>
        /// 设置锁存状态位置
        /// </summary>
        /// <param name="Pos"></param>
        /// <param name="cn"></param>
        /// <returns></returns>
        public bool SetCap(double Pos, short cn)
        {
            double _Pos = PosToPulse(Pos, CardNum, Axis);//位置换算
            return Card.API.SetCap(CardNum, Axis, (int)_Pos, cn);
        }
        /// <summary>
        /// 获取锁存状态
        /// </summary>
        /// <param name="cn"></param>
        /// <returns></returns>
        public bool GetCapSts(short cn)
        {
            return Card.API.GetCapSts(CardNum, Axis,cn);
        }

        #region 高速位置比较
        public bool CmpMode(short group, short Hcmp, int time, short cmp_logic, int Mode)
        {
            return Card.API.CmpMode(CardNum, Axis, group, Hcmp, time, cmp_logic, Mode);
        }
        public bool AddCmpPoint(short Hcmp, double Pos)
        {
            int _Pos = PosToPulse(Pos, CardNum, Axis);//位置换算

            return Card.API.addHcmpPoint(CardNum, Hcmp, _Pos);
        }
        public bool ClearHcmpPoint(short Hcmp)
        {
            return Card.API.ClearHcmpPoint(CardNum, Hcmp);
        }
        #endregion
    }
}
