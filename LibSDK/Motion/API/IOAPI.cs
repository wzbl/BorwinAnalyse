using LibSDK.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSDK.Motion
{
    public class IOAPI
    {
        private readonly BoardSwitchCs Card = new BoardSwitchCs();
       
        /// <summary>
        /// 读取输入IO(IOParm.CIOType 参数类型)
        /// </summary>
        /// <param name="cIOType"></param>
        /// <returns></returns>
        public bool IoReadIn(IO.CIOType cIOType)
        {
            bool BoolRtn = false;
            if (cIOType.Extmdl == 0)
            {
                BoolRtn = Card.API.GetDi(cIOType.CardNo, cIOType.IONum);
            }
            else if (cIOType.Extmdl > 0)
            {
                BoolRtn = Card.API.GetExtmdDi(cIOType.CardNo, cIOType.Extmdl, cIOType.IONum);
            }
            else if (cIOType.Extmdl < 0)
            {
                BoolRtn = Card.IoAPI.C_ReadIn(cIOType.CardNo, cIOType.IONum);
            }
            if (cIOType.Invert) { return !BoolRtn; }
            else { return BoolRtn; }
        }

        /// <summary>
        /// 读输入IO(strig  IO名称)
        /// </summary>
        /// <param name="IoName">IO名称</param>
        /// <returns></returns>
        public bool IoReadIn(string IoName)
        {
           bool BoolRtn=false;
           IO.CIOType cIO= MotionControl.IOParmIn.GetIOprame(IoName);

           if(cIO.Extmdl==0)
            {
                BoolRtn= Card.API.GetDi(cIO.CardNo, cIO.IONum);
            }
            else if(cIO.Extmdl > 0)
            {
               BoolRtn= Card.API.GetExtmdDi(cIO.CardNo, cIO.Extmdl,cIO.IONum);
            }
            else if (cIO.Extmdl<0)
            {
                BoolRtn = Card.IoAPI.C_ReadIn(cIO.CardNo, cIO.IONum);
            }
            if (cIO.Invert) { return !BoolRtn; }
            else { return BoolRtn;}
        }

        /// <summary>
        /// 读取输入IO(参数（int IO序号)
        /// </summary>
        /// <param name="Index">IO序号</param>
        /// <returns></returns>
        public bool IoReadIn(int Index)
        {
            bool BoolRtn=false;
            IO.CIOType cIO = MotionControl.IOParmIn.GetIOprame(Index);
            
            if (cIO.Extmdl == 0)
            {
                BoolRtn= Card.API.GetDi(cIO.CardNo, cIO.IONum);
            }
            else if(cIO.Extmdl>0)
            {
                BoolRtn= Card.API.GetExtmdDi(cIO.CardNo, cIO.Extmdl, cIO.IONum);
            }
            else if(cIO.Extmdl<0)
            {
                BoolRtn = Card.IoAPI.C_ReadIn(cIO.CardNo,cIO.IONum);
            }
            if (cIO.Invert) { return !BoolRtn; }
            else { return BoolRtn; }
        }

        /// <summary>
        /// 读取输出IO(参数（IOParm.CIOType 参数类型)
        /// </summary>
        /// <param name="cIOType"></param>
        /// <returns></returns>
        public bool IoRadOut(IO.CIOType cIOType)
        {
            bool BoolRtn = false;
            if (cIOType.Extmdl == 0)
            {
                BoolRtn= Card.API.GetDo(cIOType.CardNo, cIOType.IONum);
            }
            else if(cIOType.Extmdl>0)
            {
                BoolRtn= Card.API.GetExtmdDO(cIOType.CardNo, cIOType.Extmdl, cIOType.IONum);
            }
            else if(cIOType.Extmdl<0)
            {
                BoolRtn= Card.IoAPI.C_ReadOut(cIOType.CardNo, cIOType.IONum);
            }
            if (cIOType.Invert)
            {
                BoolRtn = !BoolRtn;
            }
            return BoolRtn;
        }

        /// <summary>
        /// 读取输出IO(参数（strig IO名称)
        /// </summary>
        /// <param name="Index">IO序号</param>
        /// <returns></returns>
        public bool IoRadOut(string IoName)
        {
            bool BoolRtn = false;
            IO.CIOType cIO = MotionControl.IOParmOut.GetIOprame(IoName);
            if (cIO.Extmdl == 0)
            {
                BoolRtn= Card.API.GetDo(cIO.CardNo, cIO.IONum);
            }
            else if(cIO.Extmdl>0)
            {
                BoolRtn= Card.API.GetExtmdDO(cIO.CardNo, cIO.Extmdl, cIO.IONum);
            }
            else if(cIO.Extmdl<0)
            {
              BoolRtn= Card.IoAPI.C_ReadOut(cIO.CardNo,cIO.IONum);
            }
            return BoolRtn;
        }

        /// <summary>
        /// 读取输出IO(参数（int IO序号)
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public bool IoRadOut(int Index)
        {
            bool BoolRtn = false;
            IO.CIOType cIO = MotionControl.IOParmOut.GetIOprame(Index);
            if (cIO.Extmdl == 0)
            {
                BoolRtn= Card.API.GetDo(cIO.CardNo, cIO.IONum);
            }
            else if(cIO.Extmdl>0)
            {
                BoolRtn= Card.API.GetExtmdDO(cIO.CardNo, cIO.Extmdl, cIO.IONum);
            }
            else if(cIO.Extmdl<0)
            {
                BoolRtn = Card.IoAPI.C_ReadOut(cIO.CardNo,cIO.IONum);
            }
            return BoolRtn;
        }

        /// <summary>
        /// 写输出IO(参数（IOParm.CIOType 参数类型)
        /// </summary>
        /// <param name="cIOType"></param>
        /// <param name="oUTtype"></param>
        /// <returns></returns>
        public bool IoWrite(IO.CIOType cIOType, short Pvalue)
        {
            bool BoolRtn = false;
            if (cIOType.Extmdl == 0)
            {
                BoolRtn= Card.API.SetDo(cIOType.CardNo, cIOType.IONum, Pvalue);
            }
            else if(cIOType.Extmdl>0)
            {
                BoolRtn= Card.API.SetExtmdlDO(cIOType.CardNo, cIOType.Extmdl, cIOType.IONum, (ushort)Pvalue);
            }
            else if (cIOType.Extmdl<0)
            {
                BoolRtn= Card.IoAPI.C_WiteOut(cIOType.CardNo, cIOType.IONum, (ushort)Pvalue);
            }
            return BoolRtn;
        }

        /// <summary>
        /// 写输出IO(参数（strig IO名称)
        /// </summary>
        /// <param name="IoName"></param>
        /// <param name="oUTtype"></param>
        /// <returns></returns>
        public bool IoWrite(string IoName, short Pvalue)
        {
            bool BoolRtn = false;
            IO.CIOType cIO = MotionControl.IOParmOut.GetIOprame(IoName);

            if (cIO.Extmdl == 0)
            {
                BoolRtn= Card.API.SetDo(cIO.CardNo, cIO.IONum, Pvalue);
            }
            else if(cIO.Extmdl>0)
            {
                BoolRtn= Card.API.SetExtmdlDO(cIO.CardNo, cIO.Extmdl, cIO.IONum, (ushort)Pvalue);
            }
            else if(cIO.Extmdl<0)
            {
                BoolRtn = Card.IoAPI.C_WiteOut(cIO.CardNo,cIO.IONum, (ushort)Pvalue);
            }
            return BoolRtn;
        }

        /// <summary>
        /// 写输出IO(参数（int IO序号)
        /// </summary>
        /// <param name="IoName"></param>
        /// <param name="oUTtype"></param>
        /// <returns></returns>
        public bool IoWrite(int Index, OUTtype oUTtype)
        {
            bool BoolRtn = false;
            IO.CIOType cIO = MotionControl.IOParmOut.GetIOprame(Index);

            if (cIO.Extmdl == 0)
            {
                BoolRtn= Card.API.SetDo(cIO.CardNo, cIO.IONum, Convert.ToInt16(oUTtype));
            }
            else if(cIO.Extmdl>0)
            {
                BoolRtn= Card.API.SetExtmdlDO(cIO.CardNo, cIO.Extmdl, cIO.IONum,(ushort)Convert.ToInt16(oUTtype));
            }
            else if(cIO.Extmdl<0)
            {
                BoolRtn = Card.IoAPI.C_WiteOut(cIO.CardNo,cIO.IONum, Convert.ToInt16(oUTtype));
            }
            return BoolRtn;
        }
    }
}
