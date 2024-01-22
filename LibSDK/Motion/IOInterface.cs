using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSDK.Motion
{
   public interface IOInterface
    {

        /// <summary>
        /// IO卡初始化
        /// </summary>
        /// <returns></returns>
        bool IoCardIni();
        bool IoCardClose();
        bool C_ReadIn(short Cardnuo ,short IoNum);
        bool C_ReadOut(short Cardnuo,short IoNum);

        bool C_WiteOut(short Cardnuo,short IoNum,int Value);
    }
}
