using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csIOC0640;

namespace LibSDK.Motion
{
    public class Dmc6040:MotionBase,IOInterface
    {
        public Dmc6040() { }
        public bool IoCardIni()
        {
            int IoCNum = IOC0640.ioc_board_init();

            if (IoCNum <= 0 || IoCNum > 8)
            {
                ShowErrorMessage("dmc_set_debug_mode", IoCNum, "没有找到控制卡,或者控制卡异常");
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IoCardClose()
        {
            IOC0640.ioc_board_close();
            return true;
        }
        public bool C_ReadIn(short Cardnuo,short IoNum)
        {
            if (IOC0640.ioc_read_inbit((ushort)Cardnuo, (ushort)IoNum) == 0)
                return true;
            else
                return false;

        }
        public bool C_ReadOut(short Cardnuo,short IoNum)
        {
            if (IOC0640.ioc_read_outbit((ushort)Cardnuo, (ushort)IoNum) == 0)
                return true;
            else
                return false;

        }
        public bool C_WiteOut(short Cardnuo, short IoNum,int Value)
        {
            return IsCheck("ioc_write_outbit", (int)IOC0640.ioc_write_outbit((ushort)Cardnuo,(ushort)IoNum,Value),"IOcard");
        }

    }
}
