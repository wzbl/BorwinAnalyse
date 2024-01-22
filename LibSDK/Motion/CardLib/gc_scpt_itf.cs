////*****************************************************************
// Moudle Name  :   gc_scpt_itf.cs
// Abstract     :   GaoChuan Script control user header
// Modification History :
// Note :			1.�ṹ�嶨�������еġ�reservedxxx���ĳ�Ա���Ǳ����������벻Ҫ�޸�����
//					  2.���ر�˵��������API����RTN_CMD_SUCCESS����0ֵ����ʾִ�гɹ����������ʾ�������
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

        // ��������ʵ����
        public const Int32 MAX_INSTANCE = 8;

        // Scpt��ʼ��
        // idx:ʵ����ţ�ȡֵ��Χ[0,MAX_INSTANCE]
        // devIdx:��������ţ�ȡֵ��Χ[0,n]
        // runtimeMode:����ģʽ��0����λ��ģʽ��1����λ��ģʽ
        // commTimeOuts : ͨѶ��ʱ����λ��ms
        // commReties : ͨѶ���Դ���
        [DllImport(DLL_PATH, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 ScptItf_Init(Int32 idx, Int32 devIdx, Int32 runtimeMode, Int32 commTimeOuts, Int32 commReties);

        // Scpt��ʼ��
        // idx:ʵ����ţ�ȡֵ��Χ[0,MAX_INSTANCE]
        // hDev:������������û�ͨ��NMC_DevOpen�Ȼ�ȡ
        // runtimeMode:����ģʽ��0����λ��ģʽ��1����λ��ģʽ
        // commTimeOuts : ͨѶ��ʱ����λ��ms
        // commReties : ͨѶ���Դ���
        [DllImport(DLL_PATH, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 ScptItf_InitByHandle(Int32 idx, UInt16 hDev, Int32 runtimeMode, Int32 commTimeOuts, Int32 commReties);

        // ���������ļ�
        // idx:ʵ����ţ�ȡֵ��Χ[0,MAX_INSTANCE]
        // autoRun:1���صĹ��̽��Զ�����δ�Զ����У�0�������Զ�����
        // binFileName:�����ļ�·��
        [DllImport(DLL_PATH, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 ScptItf_Download(Int32 idx,
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 128)]byte[] binFileName, Int16 autoRun);
        
        // ���������ļ�
        // idx:ʵ����ţ�ȡֵ��Χ[0,MAX_INSTANCE]
        // autoRun:1���صĹ��̽��Զ�����δ�Զ����У�0�������Զ�����
        // binFileName:�����ļ�·��
        // uploadPassword:�ϴ����룬�ַ�������0~15���ֽ�
        [DllImport(DLL_PATH, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 ScptItf_DownloadEx(Int32 idx,
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 128)]byte[] binFileName, Int16 autoRun,
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 16)]byte[] uploadPassword);
        
        // �����ϵ�������
        // idx:ʵ����ţ�ȡֵ��Χ[0,MAX_INSTANCE]
        // autoRunEn:�Ƿ���������1��������������0��������������
        // autoRunDisGPIIndex: ��������������DI������ʱ����di�����룬��������������, ȡֵ��Χ[0, 16]��0��ʾ�����ø�ѡ�
        // otherFlag:����������Ϊ0
        [DllImport(DLL_PATH, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 ScptItf_CfgAutoRun(Int32 idx, Int16 autoRunEn, Int16 autoRunDisGPIIndex, Int16 otherFlag);


        // ���п�����
        public const Int32 RUN_CTRL_RUN = 1;		// ��������
        public const Int32 RUN_CTRL_STOP = 2;		// ֹͣ����
        public const Int32 RUN_CTRL_PAUSE = 3;		// ��ͣ
        public const Int32 RUN_CTRL_HOME = 4;		// ����
        public const Int32 RUN_CTRL_EMG = 5;		// ��ͣ
        public const Int32 RUN_CTRL_RESET = 6;		// ��λ������
        public const Int32 RUN_CTRL_CLR = 7;		// �������״̬

        // ���п���
        // idx:ʵ����ţ�ȡֵ��Χ[0,MAX_INSTANCE]
        // flag:���п�����
        [DllImport(DLL_PATH, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 ScptItf_RunControl(Int32 idx, Int32 flag);

        // run state
        public const Int16 Run_State_None = 0;
        public const Int16 Run_State_Stop = 1;
        public const Int16 Run_State_Run = 2;
        public const Int16 Run_State_Err = 3;
        public const Int16 Run_State_Pause = 4;

        // ������״̬
        public const Int16 RS_MAX_AXIS_NUM = 16;
        public struct TScptStsUser
        {
            // controller status
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = RS_MAX_AXIS_NUM)]
            public Single[] axisPos;		// ���λ��
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = RS_MAX_AXIS_NUM)]
            public Single[] encPos;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = RS_MAX_AXIS_NUM)]
            public Int16[] axisSts;		// ���״̬
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = RS_MAX_AXIS_NUM)]
            public Int16[] motionIO;		// ר��IO״̬
            public Int32 di1;						// ������������1��״̬
            public Int32 di2;						// ������������2��״̬
            public Int32 do1;						// �����������1��״̬
            public Int32 do2;						// �����������3��״̬

            // run status
            public Int16 runState;         //�ű�runtime������״̬
            public Int16 errCode;          // �������
            public Int16 bitFlag;          //��־λ���Ƿ���㡢�Ƿ����õ�
            public Int16 currentLine;	    //��ǰ���е��к�
            public Int16 errLine;		    // ��ǰ������к�
            public Int16 watchVLen;	    // watch����ֵ�ĳ���
            public Int16 outputLen;	    // output�ĳ���
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

        // ��ȡ״̬
        // idx:ʵ����ţ�ȡֵ��Χ[0,MAX_INSTANCE]
        [DllImport(DLL_PATH, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 ScptItf_GetStatus(Int32 idx, ref TScptStsUser pSts);

        // ���û�����
        // idx:ʵ����ţ�ȡֵ��Χ[0,MAX_INSTANCE]
        // varType	�������ͣ�0 : double, 1 : float, 2 : Int32, 3 : Int16
        // varIdx	�������, ȡֵ��Χ[1, max]
        // val	���ص���ֵ
        [DllImport(DLL_PATH, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 ScptItf_UserVarRead(Int32 idx, Int16 varType, Int16 varIdx, ref double val);

        // д�û�����
        [DllImport(DLL_PATH, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 ScptItf_UserVarWrite(Int32 idx, Int16 varType, Int16 varIdx, double val);

        // ���û�����(���)
        // count:��ȡ�ı�������
        // val:�����ַָ��
        // ע�⣺�����ܳ��Ȳ��ܳ���960���ֽ�
        [DllImport(DLL_PATH, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 ScptItf_UserVarReadEx(Int32 idx, Int16 varType, Int16 varIdx,
            Int16 count, [MarshalAs(UnmanagedType.LPArray, SizeConst = 128)]double[] val);

        // д�û�����(���)
        // count:д��ı���������
        // val:������Դָ��
        // ע�⣺�����ܳ��Ȳ��ܳ���960���ֽ�
        [DllImport(DLL_PATH, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 ScptItf_UserVarWriteEx(Int32 idx, Int16 varType, Int16 varIdx, Int16 count, double[] val);


				// ��������״̬
				public const Int16 TASK_RUN_STS_DIS = -1;	// not active
				public const Int16 TASK_RUN_STS_STOP = 0;	// stopped
				public const Int16 TASK_RUN_STS_RUN = 1;	// running
				public const Int16 TASK_RUN_STS_ERR = 2;	// error
				public struct TScptTaskSts
				{
					public Int16 runState;      // �ű�runtime������״̬�����Ϻ궨��
					public Int16 errCode;       // �������
					public Int32  runLine;			// ��������
					public Int16 reserved1;			// ����
					public Int16 reserved2;			// ����
					public Int16 reserved3;			// ����
					public Int16 reserved4;			// ����
				};
				
				// ��ȡ��������״̬
				// taskIdx:����仯��ȡֵ��Χ[0,8)
				// pSts:ָ�������״̬
				[DllImport(DLL_PATH, CallingConvention = CallingConvention.StdCall)]
				public static extern Int32 ScptItf_GetTaskSts(Int32 idx, Int16 taskIdx, ref TScptTaskSts pSts);

				// ����ȫ�ֱ�������ֵ()
				// pVarName:ȫ�ֱ������������ִ�Сд
				// value:Ҫ���õ���ֵ
				[DllImport(DLL_PATH, CallingConvention = CallingConvention.StdCall)]
				public static extern Int32 ScptItf_SetGlobalNumVarValue(Int32 idx, string pVarName, double value);
				
				// ��ȡȫ�ֱ�������ֵ
				// pVarName:ȫ�ֱ������������ִ�Сд
				// pValue: ��ǰ��������ֵ
				[DllImport(DLL_PATH, CallingConvention = CallingConvention.StdCall)]
				public static extern Int32 ScptItf_GetGlobalNumVarValue(Int32 idx, string pVarName, ref double pValue);
				
				// ��������������нӿ�
				// taskMask:��Ҫ���е���������
				[DllImport(DLL_PATH, CallingConvention = CallingConvention.StdCall)]
				public static extern Int32 ScptItf_RunEx(Int32 idx, Int32 taskMask);
				
				// ���������ͣ���нӿ�
				// taskMask:��Ҫ��ͣ����������
				[DllImport(DLL_PATH, CallingConvention = CallingConvention.StdCall)]
				public static extern Int32 ScptItf_PauseEx(Int32 idx, Int32 taskMask);
    }
}



