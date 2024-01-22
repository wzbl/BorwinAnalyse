using GC.Frame.Motion.Privt;
using LibSDK.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSDK.Motion
{
    class ErrorClass
    {
        public static string Error(short errNum, CardType cardType)
        {
          string errMessage = "";
           if(cardType== CardType.GTS)
            {
                switch (errNum)
                {
                    case 1:
                        errMessage = "<<指令执行错误>>,请检查当前指令的执行条件是否满足.";
                        break;
                    case 2:
                        errMessage = "<<license不支持>>,如果需要此功能,请与生产厂商联系.";
                        break;
                    case 7:
                        errMessage = "<<指令参数错误>>,请检查当前指令输入参数的取值.";
                        break;
                    case -1:
                        errMessage = "<<主机和运动控制器通讯失败>>,请检查:1. 是否正确安装运动控制器驱动程序,2. 检查运动控制器是否接插牢靠,3. 更换主机,4. 更换控制器";
                        break;
                    case -6:
                        errMessage = "<<打开控制器失败>>,请检查:1. 是否正确安装运动控制器驱动程序,2. 是否调用了2次GT_Open指令,3. 其他程序是否已经打开运动控制器.";
                        break;
                    case -7:
                        errMessage = "<<运动控制器没有响应>>,请更换运动控制器.";
                        break;
                    default:
                        errMessage = "未知错误 ";
                        break;

                }
            }
           else if(cardType == CardType.LTDMC)
            {
                switch (errNum)
                {
                    case 1:
                        errMessage = "未知错误.";
                        break;
                    case 2:
                        errMessage = "参数错误.";
                        break;
                    case 3:
                        errMessage = "操作超时.";
                        break;
                    case 4:
                        errMessage = "控制卡状态忙.";
                        break;
                    case 6:
                        errMessage = "连续插补错误.";
                        break;
                    case 8:
                        errMessage = "无法连接错误.";
                        break;
                    case 9:
                        errMessage = "卡号错误，可能由于函数参数中的卡号或轴号超出范围产生，比如有两张卡分别为 0 号和1 号卡，当轴号为 8 时根据计算应该为 2 号卡，此时就会产生错误.";
                        break;
                    case 10:
                        errMessage = "数据传输错误，请检查 PCI 槽位是否松动.";
                        break;
                    case 12:
                        errMessage = "固件文件错误.";
                        break;
                    case 14:
                        errMessage = "固件不匹配.";
                        break;
                    case 20:
                        errMessage = "固件参数错误.";
                        break;
                    case 22:
                        errMessage = "固件当前状态不允许操作.";
                        break;
                    case 24:
                        errMessage = " 不支持的功能.";
                        break;
                    case 1967:
                        errMessage = "旧密码输入错误.";
                        break;
                    case 1968:
                        errMessage = "旧密码验证次数超限，不能继续验证.";
                        break;
                    case 1969:
                        errMessage = "拒绝写入新密码.";
                        break;
                    default:
                        errMessage = "未知错误 ";
                        break;
                }
            }
           else if(cardType == CardType.GCS)
            {
                errMessage = "未知错误";
            }
          return string.Format("返回值为:{0},系统检测到:{1}", errNum, errMessage); ;
       }
        public static string IoError(short errNum, IOType iOType)
        {
            string errMessage = "";
            switch(iOType)
            {
                case IOType.DMC640:
                    switch (errNum)
                    {
                        default:
                            errMessage = "未知错误 ";
                            break;
                    }
                    break;
              }
             errMessage = string.Format("返回值为:{0},系统检测到:{1}", errNum, errMessage);
            return errMessage;
        }
    }
}
