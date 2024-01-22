////*****************************************************************
// Moudle Name  :   gc_scpt_itf.cs
// Abstract     :   GaoChuan Script control user header
// Modification History :
// Note :			1.结构体定义中所有的‘reservedxxx’的成员都是保留参数，请不要修改他们
//					  2.无特别说明，所有API返回RTN_CMD_SUCCESS（即0值）表示执行成功，其他则表示错误代码
////*****************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace GC.Motion
{
    public class Scpt
    {
        public const string DLL_PATH = @"gc_scpt_itf.dll";

        // 最大允许的实例数
        public const Int32 MAX_INSTANCE = 8;

        // Scpt初始化
        // idx:实例序号，取值范围[0,MAX_INSTANCE]
        // devIdx:控制器编号，取值范围[0,n]
        // runtimeMode:运行模式，0：下位机模式，1：上位机模式
        // commTimeOuts : 通讯超时，单位：ms
        // commReties : 通讯重试次数
        [DllImport(DLL_PATH, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 ScptItf_Init(Int32 idx, Int32 devIdx, Int32 runtimeMode, Int32 commTimeOuts, Int32 commReties);

        // Scpt初始化
        // idx:实例序号，取值范围[0,MAX_INSTANCE]
        // hDev:控制器句柄，用户通过NMC_DevOpen等获取
        // runtimeMode:运行模式，0：下位机模式，1：上位机模式
        // commTimeOuts : 通讯超时，单位：ms
        // commReties : 通讯重试次数
        [DllImport(DLL_PATH, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 ScptItf_InitByHandle(Int32 idx, UInt16 hDev, Int32 runtimeMode, Int32 commTimeOuts, Int32 commReties);

        // 下载运行文件
        // idx:实例序号，取值范围[0,MAX_INSTANCE]
        // autoRun:1下载的工程将自动配置未自动运行，0：不会自动运行
        // binFileName:运行文件路径
        [DllImport(DLL_PATH, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 ScptItf_Download(Int32 idx,
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 128)]byte[] binFileName, Int16 autoRun);
        
        // 下载运行文件
        // idx:实例序号，取值范围[0,MAX_INSTANCE]
        // autoRun:1下载的工程将自动配置未自动运行，0：不会自动运行
        // binFileName:运行文件路径
        // uploadPassword:上传密码，字符串长度0~15个字节
        [DllImport(DLL_PATH, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 ScptItf_DownloadEx(Int32 idx,
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 128)]byte[] binFileName, Int16 autoRun,
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 16)]byte[] uploadPassword);
        
        // 配置上电自启动
        // idx:实例序号，取值范围[0,MAX_INSTANCE]
        // autoRunEn:是否自启动，1：开机自启动，0：开机不自启动
        // autoRunDisGPIIndex: 开机自启动跳过DI（开机时，此di有输入，则跳过自启动）, 取值范围[0, 16]，0表示不设置该选项，
        // otherFlag:保留，请设为0
        [DllImport(DLL_PATH, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 ScptItf_CfgAutoRun(Int32 idx, Int16 autoRunEn, Int16 autoRunDisGPIIndex, Int16 otherFlag);


        // 运行控制字
        public const Int32 RUN_CTRL_RUN = 1;		// 启动运行
        public const Int32 RUN_CTRL_STOP = 2;		// 停止运行
        public const Int32 RUN_CTRL_PAUSE = 3;		// 暂停
        public const Int32 RUN_CTRL_HOME = 4;		// 回零
        public const Int32 RUN_CTRL_EMG = 5;		// 急停
        public const Int32 RUN_CTRL_RESET = 6;		// 复位控制器
        public const Int32 RUN_CTRL_CLR = 7;		// 清除错误状态

        // 运行控制
        // idx:实例序号，取值范围[0,MAX_INSTANCE]
        // flag:运行控制字
        [DllImport(DLL_PATH, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 ScptItf_RunControl(Int32 idx, Int32 flag);

        // run state
        public const Int16 Run_State_None = 0;
        public const Int16 Run_State_Stop = 1;
        public const Int16 Run_State_Run = 2;
        public const Int16 Run_State_Err = 3;
        public const Int16 Run_State_Pause = 4;

        // 控制器状态
        public const Int16 RS_MAX_AXIS_NUM = 16;
        public struct TScptStsUser
        {
            // controller status
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = RS_MAX_AXIS_NUM)]
            public Single[] axisPos;		// 电机位置
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = RS_MAX_AXIS_NUM)]
            public Single[] encPos;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = RS_MAX_AXIS_NUM)]
            public Int16[] axisSts;		// 电机状态
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = RS_MAX_AXIS_NUM)]
            public Int16[] motionIO;		// 专用IO状态
            public Int32 di1;						// 数字量输入组1的状态
            public Int32 di2;						// 数字量输入组2的状态
            public Int32 do1;						// 数字量输出组1的状态
            public Int32 do2;						// 数字量输出组3的状态

            // run status
            public Int16 runState;         //脚本runtime的运行状态
            public Int16 errCode;          // 错误代码
            public Int16 bitFlag;          //标志位，是否回零、是否配置等
            public Int16 currentLine;	    //当前运行的行号
            public Int16 errLine;		    // 当前出错的行号
            public Int16 watchVLen;	    // watch变量值的长度
            public Int16 outputLen;	    // output的长度
            public Int16 reserve;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
            public byte[] data;

            public TScptStsUser(bool bInit)
            {
                di1 = di2 = do1 = do2 = 0;
                runState = errCode = bitFlag = currentLine = errLine = watchVLen = outputLen = reserve = 0;
                axisPos = new float[RS_MAX_AXIS_NUM];
                encPos = new float[RS_MAX_AXIS_NUM];
                axisSts = new Int16[RS_MAX_AXIS_NUM];
                motionIO = new Int16[RS_MAX_AXIS_NUM];
                data = new byte[512];
            }
        };

        // 读取状态
        // idx:实例序号，取值范围[0,MAX_INSTANCE]
        [DllImport(DLL_PATH, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 ScptItf_GetStatus(Int32 idx, ref TScptStsUser pSts);

        // 读用户变量
        // idx:实例序号，取值范围[0,MAX_INSTANCE]
        // varType	变量类型，0 : double, 1 : float, 2 : Int32, 3 : Int16
        // varIdx	变量序号, 取值范围[1, max]
        // val	读回的数值
        [DllImport(DLL_PATH, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 ScptItf_UserVarRead(Int32 idx, Int16 varType, Int16 varIdx, ref double val);

        // 写用户变量
        [DllImport(DLL_PATH, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 ScptItf_UserVarWrite(Int32 idx, Int16 varType, Int16 varIdx, double val);

        // 读用户变量(多个)
        // count:读取的变量数量
        // val:存入地址指针
        // 注意：数据总长度不能超过960个字节
        [DllImport(DLL_PATH, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 ScptItf_UserVarReadEx(Int32 idx, Int16 varType, Int16 varIdx,
            Int16 count, [MarshalAs(UnmanagedType.LPArray, SizeConst = 128)]double[] val);

        // 写用户变量(多个)
        // count:写入的变量数量，
        // val:数据来源指针
        // 注意：数据总长度不能超过960个字节
        [DllImport(DLL_PATH, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 ScptItf_UserVarWriteEx(Int32 idx, Int16 varType, Int16 varIdx, Int16 count, double[] val);


				// 任务运行状态
				public const Int16 TASK_RUN_STS_DIS = -1;	// not active
				public const Int16 TASK_RUN_STS_STOP = 0;	// stopped
				public const Int16 TASK_RUN_STS_RUN = 1;	// running
				public const Int16 TASK_RUN_STS_ERR = 2;	// error
				public struct TScptTaskSts
				{
					public Int16 runState;      // 脚本runtime的运行状态，如上宏定义
					public Int16 errCode;       // 错误代码
					public Int32  runLine;			// 运行行数
					public Int16 reserved1;			// 保留
					public Int16 reserved2;			// 保留
					public Int16 reserved3;			// 保留
					public Int16 reserved4;			// 保留
				};
				
				// 获取任务运行状态
				// taskIdx:任务变化，取值范围[0,8)
				// pSts:指定任务的状态
				[DllImport(DLL_PATH, CallingConvention = CallingConvention.StdCall)]
				public static extern Int32 ScptItf_GetTaskSts(Int32 idx, Int16 taskIdx, ref TScptTaskSts pSts);

				// 设置全局变量的数值()
				// pVarName:全局变量名，不区分大小写
				// value:要设置的数值
				[DllImport(DLL_PATH, CallingConvention = CallingConvention.StdCall)]
				public static extern Int32 ScptItf_SetGlobalNumVarValue(Int32 idx, string pVarName, double value);
				
				// 获取全局变量的数值
				// pVarName:全局变量名，不区分大小写
				// pValue: 当前变量的数值
				[DllImport(DLL_PATH, CallingConvention = CallingConvention.StdCall)]
				public static extern Int32 ScptItf_GetGlobalNumVarValue(Int32 idx, string pVarName, ref double pValue);
				
				// 带掩码的启动运行接口
				// taskMask:需要运行的任务掩码
				[DllImport(DLL_PATH, CallingConvention = CallingConvention.StdCall)]
				public static extern Int32 ScptItf_RunEx(Int32 idx, Int32 taskMask);
				
				// 带掩码的暂停运行接口
				// taskMask:需要暂停的任务掩码
				[DllImport(DLL_PATH, CallingConvention = CallingConvention.StdCall)]
				public static extern Int32 ScptItf_PauseEx(Int32 idx, Int32 taskMask);
    }
}



