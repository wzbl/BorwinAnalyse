/******************************************************************************
 * LibSDK 控件库、工具类库、扩展类库、多页面开发框架。
 * 作    者：Zhuxingang
 * * EMail：xinguangzhuemail@163.com
 * * 版权信息：版权所有 (c) 2020, , 保留所有权利
 ******************************************************************************
 * 文件名称: InfaceCrd.cs
 * 文件说明: 运控库的接口
 * 当前版本: V2.2
 * 创建日期: 2021-06-06
 *
 * 2020-06-06: V2.2.5 增加文件说明
******************************************************************************/

using GC.Frame.Motion.Privt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GC.Motion.Scpt;

namespace LibSDK.Motion
{
   public interface CardInterface
    {
        //回零停止
        bool HomeStop { get; set; }
        /// <summary>
        /// 回零运行中
        /// </summary>
        bool HomeRuning { get; set; }

        /// <summary>
        /// 初始化控制卡
        /// </summary>
        /// <param name="Path"></param>
        bool CrdIni(short cardNum, string pFile);

        /// <summary>
        /// 关闭板卡
        /// </summary>
        /// <param name="CardNum"></param>
        /// <returns></returns>
        bool CloseCard(short CardNum = 0);
        /// <summary>
        /// 初始化扩展模块
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="FileName"></param>
        /// <returns></returns>
        bool ExMdlIni(short CardNum, int MdlNum=3, params string[] FileName);
        /// <summary>
        /// 使能开
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        bool Servon(short CardNum, short Axis);
        /// <summary>
        /// 设置轴的软限位
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <param name="P_Limit"></param>
        /// <param name="N_Limit"></param>
        /// <returns></returns>
        bool SetSofLimit(short CardNum, short Axis,bool Enable, double P_Limit, double N_Limit);

        /// <summary>
        /// 设置轴正负限位
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <param name="El_Enable"></param>
        /// <param name="EL_Logic"></param>
        /// <param name="EL_Mode"></param>
        /// <returns></returns>
        bool SetELMode(short CardNum, short Axis, short El_Enable, short EL_Logic, short EL_Mode);

        /// <summary>
        /// 使能关
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        bool Servoff(short CardNum, short Axis);
        /// <summary>
        /// 读取电机使能信号，高电平输出
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        bool SevOn(short CardNum, short Axis);

        /// <summary>
        /// 清除轴状态
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        bool ClearAxisState(short CardNum, short Axis);
        /// <summary>
        /// 连续运动
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <param name="Direction"></param>
        /// <param name="Vel"></param>
        /// <returns></returns>
        bool JogMove(short CardNum, short Axis, short Direction, double Vel);
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
        bool PMove(short CardNum, short Axis, double Pos, double Vel, double Acc, int RunMode = 1);
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
        bool S_PMove(short CardNum, short Axis, double hight_pos, double low_pos, double MinVel, double MaxVel, double Acc, int RunMode = 1);
        /// <summary>
        /// 在线变速
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <param name="Vel"></param>
        void ChangeSpeed(short CardNum, short Axis, double Vel);
        /// <summary>
        /// 读取规划位置
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        double GetPrfPluse(short CardNum, short Axis);

        /// <summary>
        /// 读取编码器位置
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        double GetEncPluse(short CardNum, short Axis);

        /// <summary>
        /// 单轴停止
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        bool AxisStop(short CardNum, short Axis, int option);
        /// <summary>
        /// 紧急停止所有轴
        /// </summary>
        /// <param name="CardNum"></param>
        /// <returns></returns>
        bool EmgStop(short CardNum);
        /// <summary>
        /// 单轴回零
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
        int AxisHome(short CardNum, short Axis, double HomeOffset, double Spd, double Capspd, int HomeMode, short Level, short HomeDir,int Timeout );


        /// <summary>
        /// 设置输出IO信号
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="DoNum"></param>
        /// <param name="value"></param>
        bool SetDo(short CardNum, short IoNum, short value);
        /// <summary>
        /// 读取输出IO信号
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="DoNum"></param>
        /// <returns></returns>
        bool GetDo(short CardNum, short IoNum);
        /// <summary>
        /// 读取输入信号
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="DoNum"></param>
        /// <returns></returns>
        bool GetDi(short CardNum, short IoNum);
        /// <summary>
        /// 设置扩展模块输出
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="mdl"></param>
        /// <param name="DoNum"></param>
        /// <param name="value"></param>
        bool SetExtmdlDO(short CardNum, short mdl, short IoNum, ushort value);
        /// <summary>
        /// 读取扩展模块输出
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="mdl"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        bool GetExtmdDO(short CardNum, short mdl, short IoNum);

        /// <summary>
        /// 读取扩展模块输入
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="mdl"></param>
        /// <param name="DoNum"></param>
        /// <returns></returns>
        bool GetExtmdDi(short CardNum, short mdl, short IoNum);
        /// <summary>
        /// 轴报警
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        bool Mot_ALM(short CardNum, short Axis);
        /// <summary>
        /// 正限位
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        bool Mot_PEL(short CardNum, short Axis);

        /// <summary>
        /// 负限位
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        bool Mot_NEL(short CardNum, short Axis);
        /// <summary>
        /// 原点信号
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        bool Mot_ORG(short CardNum, short Axis);
        /// <summary>
        /// 软负限位信号
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        bool Mot_SLN(short CardNum, short Axis);
        /// <summary>
        /// 软正限位信号
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        bool Mot_SLP(short CardNum, short Axis);

        /// <summary>
        /// 电机运行状态
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        bool Mot_Running(short CardNum, short Axis);
        /// <summary>
        ///伺服到位信号
        /// </summary>
        /// <param name="CardNum"></param>
        /// <param name="Axis"></param>
        /// <returns></returns>
        bool GetCheckDone(short CardNum, short Axis);

        #region 高速位置比较
        bool CmpMode(short CardNum, short Axis, short group, short Hcmp, int time, short cmp_logic,int Mode);
        bool addHcmpPoint(short CardNum, short Hcmp, int Pos);
        bool ClearHcmpPoint(short CardNum, short Hcmp);

        bool ClearCapSts(short CardNum, short Axis, short ch);

        bool SetCap(short CardNum, short Axis, int Pos, short ch);

        bool GetCapSts(short CardNum, short Axis, short ch);

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
        bool LinearInterMove(short CardNum, short Crd, short AxisNum, double Vel, double Acc, ushort[] AxisList, int[] DisLlist, ushort Mode);

        bool CrdRunning(short CardNum, short Crd);

        #region 脚本函数接口

        /// <summary>
        ///  Scpt初始化
        /// </summary>
        /// <param name="cardNum"></param>
        /// <param name=""></param>
        /// <returns></returns>
        bool ScptIni(int instIdx, short cardNum);

        /// <summary>
        /// 下载bin文件
        /// </summary>
        /// <returns></returns>
        bool ScpDownLoad(int idx, string filepath, short Autorun);
        /// <summary>
        /// 配置自动运行参数
        /// </summary>
        /// <param name="idx">实例序号【0-7】</param>
        /// <param name="AutorunEn">是否自启动，1：开机自启动，0：开机不自启动 </param>
        /// <param name="AutorunDisGpiindex">
        /// 开机自启动跳过 DI（开机时，此 di 有输入，则跳过自
        ///  启动）, 取值范围[0, 16]，0 表示不设置该选项</param>
        /// <returns></returns>
        bool ScpRunconfig(int idx, short AutorunEn, short AutorunDisGpiindex);
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
        bool ScpRun(int idx, int flag);
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
        bool ScptGetStatus(int idx, ref TScptStsUser pSts);
        /// <summary>
        /// 用户变量读取 
        /// </summary>
        /// <param name="idx">实例序号，取值范围[0,7]</param>
        /// <param name="VarType">变量类型，0:double,1:float,2:Int32,3:Int16</param>
        /// <param name="varidx">变量序号,取值范围[1,max]</param>
        /// <returns>读回的数值 -1读取失败</returns>
        double ScpUserVarRead(int idx, short VarType, short varidx);
        /// <summary>
        /// 用户变量写入
        /// </summary>
        /// <param name="idx">实例序号，取值范围[0,7]</param>
        /// <param name="VarType">变量类型，0:double,1:float,2:Int32,3:Int16</param>
        /// <param name="varidx">变量序号,取值范围[1,max]</param>
        /// <param name="Val">写的数值</param>
        /// <returns></returns>
        bool ScpUserVarWrite(int idx, short VarType, short varidx, double Val);
        /// <summary>
        /// 用户变量读取（多个）
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="VarType"></param>
        /// <param name="varidx"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        double[] ScpUserVarReadEx(int idx, short VarType, short varidx, short count);
        /// <summary>
        /// 用户变量写入（多个） 
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="VarType"></param>
        /// <param name="varidx"></param>
        /// <param name="count"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        bool ScpUserVarWriteEx(int idx, short VarType, short varidx, short count, double[] values);

        /// <summary>
        /// 设置全局变量值 
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="pVarName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool ScpSetGlobalVarValue(int idx, string pVarName, double value);
        /// <summary>
        /// 读全局变量值
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="pVarName"></param>
        /// <returns></returns>
        double ScpGetGlobalVarValue(int idx, string pVarName);
        /// <summary>
        /// 带任务启动掩码的启动运行 
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="taskMask"></param>
        /// <returns></returns>
        bool ScpRunEx(int idx, int taskMask);
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
        bool ScpGetTaskSts(int idx, short taskIdx, ref TScptTaskSts pSts);


        #endregion
    }
}
