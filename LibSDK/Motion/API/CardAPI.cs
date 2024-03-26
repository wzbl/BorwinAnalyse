using LibSDK.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibSDK.Motion
{
    public class CardAPI
    {
        private readonly BoardSwitchCs Card = new BoardSwitchCs();
        /// <summary>
        /// 是否初始化卡完成
        /// </summary>
        public bool IsInitCardOK { get; private set; }

        public CardAPI() { }

        /// <summary>
        /// 板卡数量
        /// </summary>
        private int CardNumber { get; set; }

        /// <summary>
        ///卡对应轴数
        /// </summary>
        private int[,] AxisNumList { get; set; }
        /// <summary>
        /// 扩展模块数量
        /// </summary>
        private int MdlNumbr { get; set; }

        /// <summary> 
        /// 初始化控制器【CardNum-板卡数量,AxisNum-对应卡轴的数量 ,MdlNum-模块数量,Pfile-配置文件名称】
        /// </summary>
        /// <param name="CardNum">卡的数量</param>
        /// <param name="AxisNum">对应卡的轴数</param>
        /// <param name="MdlNum">扩展模块的数量</param>
        /// <param name="Pfile">配置文件名称 和路径</param>
        /// <returns></returns>
        public bool InitCard(int CardNum,int[]AxisNum,int MdlNum ,params string[] Pfile)
        {
            bool Rtn = false;
            this.CardNumber =CardNum;
            this.AxisNumList = new int[CardNum, CardNum];
            for (int i = 0;i< CardNum;i++)
            {
              AxisNumList[i, 0] = AxisNum[i];
            }
            
            this.MdlNumbr = MdlNum;
            //初始化前先关闭板卡
            if (this.IsInitCardOK) this.CloseCard();

            switch (MotionControl.EnumControl.CardType)
            {
                case CardType.GTS://固高板卡
                    for (int i = 0; i < CardNum; i++)
                    {
                      Rtn=Card.API.CrdIni((short)i, Pfile[i]);
                     if (!Rtn) { return Rtn; }
                    }
                    Rtn=Card.API.ExMdlIni(0,0,Pfile[CardNum]);
                    Rtn=Servon();//所有轴使能
                    break;
                case CardType.LTDMC://雷赛板卡
                    for (int i = 0; i < CardNum; i++)
                    {
                        Rtn= Card.API.CrdIni((short)i, Pfile[i]);
                        if (!Rtn) { return Rtn; }
                    }
                    if(MdlNum>0)
                    {
                        Rtn = Card.API.ExMdlIni(0, MdlNum, Pfile[CardNum]);
                    }
                    Rtn=Servon();//所有轴使能
                    break;
                case CardType.GCS://高川板卡
                    {
                        for (int i = 0; i < CardNum; i++)
                        {
                            Rtn = Card.API.CrdIni((short)i, Pfile[i]);
                            if (!Rtn) {
                                Alarm.AlarmControl.alarmList = Alarm.AlarmList.控制卡打开异常;
                                MotionControl.Log(string.Format("初始化卡{0}失败",i));
                                return Rtn;
                            }
                            MotionControl.Log(string.Format("初始化卡{0}成功", i));
                        }
                        if (MdlNum > 0)
                        {
                            Rtn = Card.API.ExMdlIni(0, MdlNum,"");
                        }
                        MotionControl.Log(string.Format("打开所有轴使能"));
                        Rtn = Servon();//所有轴使能
                    }
                    break;
            }
            this.IsInitCardOK = Rtn;
            return Rtn;
        }
        /// <summary>
        /// 初始化IO卡
        /// </summary>
        /// <returns></returns>
        public bool IniIoCard()
        {
          return Card.IoAPI.IoCardIni();
        }
        /// <summary>
        /// 关闭IO卡
        /// </summary>
        /// <returns></returns>
       public bool CloseIoCard()
        {
         return Card.IoAPI.IoCardClose();
        }
        /// <summary>
        /// 清除驱动器报警标志
        /// </summary>
        /// <returns></returns>
        public bool ClearSts()
        {
            bool Rtn = false;
            for (int i = 0; i < this.CardNumber; i++)
            {
                for (int j = 0; j < AxisNumList[i,0]; j++)
                {
                    Rtn = Card.API.ClearAxisState((short)i, (short)(j + 1));
                    if (!Rtn) { return Rtn; }
                }
            }
            return Rtn;
        }
        /// <summary>
        /// 关闭板卡
        /// </summary>
        /// <returns></returns>
        public bool CloseCard()
        {
         return Card.API.CloseCard();
        }
        /// <summary>
        /// 使能开
        /// </summary>
        /// <returns></returns>
        public bool Servon()
        {
            bool Rtn = false;
            for (int i = 0; i < this.CardNumber; i++)
            {
                for (int j = 0; j < AxisNumList[i, 0]; j++)
                {
                    
                    Rtn = Card.API.Servon((short)i, (short)(j + 1));
                    if (!Rtn) { return Rtn; }
                }
            }
            return Rtn;
        }
        /// <summary>
        /// 使能关
        /// </summary>
        /// <param name="axisList"></param>
        /// <returns></returns>
        public bool Servoff()
        {
            bool Rtn = false;
            for (int i = 0; i < this.CardNumber; i++)
            {
                for (int j = 0; j < AxisNumList[i,0]; j++)
                {
                    Rtn = Card.API.Servoff((short)i, (short)(j+1));
                    if (!Rtn) { return Rtn; }
                }
            }
            return Rtn;
        }
        /// <summary>
        /// 紧急停止所有轴
        /// </summary>
        /// <returns></returns>
        public bool StopEmgAxis()
        {
            bool re = false ;
            for(int i= 0;i < this.CardNumber;i++)
            {
                re = Card.API.EmgStop((short)i);
            }
            return re;
        }
        public bool StopAxis()
        {
            bool re = false;
            for (int i = 0; i < this.CardNumber; i++)
            {
                for (int j = 0; j < AxisNumList[i,0]; j++)
                {
                  re = Card.API.AxisStop((short)i, (short)(j + 1),0);
                }
            }
            return re;
        }
    }
}
