﻿using BorwinAnalyse.BaseClass;
using BorwinSplicMachine.LCR;
using LibSDK;
using LibSDK.IO;
using LibSDK.Motion;
using Mes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BorwinSplicMachine
{
    /// <summary>
    /// 运动控制类
    /// </summary>
    public class MotControl
    {
        #region 轴
        MotAPI 流道调宽 = null;
        MotAPI 凸轮 = null;
        MotAPI 左进入 = null;
        MotAPI 右进入 = null;
        MotAPI 吸头平移 = null;
        MotAPI 吸头上下 = null;
        MotAPI 热熔上下 = null;
        MotAPI 拨刀 = null;
        MotAPI 卷料 = null;

        MotAPI 探针A = null;
        MotAPI 测值整体上下 = null;
        MotAPI 探针B = null;
        MotAPI 下针 = null;
        #endregion

        #region 输入IO
        Input 探针A原点 = null;
        Input 测值整体上下原点 = null;
        Input 探针B原点 = null;
        Input 下针原点 = null;
        Input 屏蔽按钮 = null;
        Input 安全门开关 = null;
        Input 真空表 = null;
        Input 左收料按钮 = null;
        Input 右收料按钮 = null;
        Input 左料盘感应 = null;
        Input 右料盘感应 = null;
        Input 左轮光栅 = null;
        Input 右轮光栅 = null;
        Input 左物料光栅 = null;
        Input 右物料光栅 = null;
        Input 左入料光栅 = null;
        Input 右入料光栅 = null;
        Input 卷料原点 = null;
        Input 切料光纤感应 = null;
        Input 切料电机接近感应 = null;
        Input 贴膜定位针上位 = null;
        Input 贴膜定位针下位 = null;
        Input 料尾感应光电 = null;
        Input 胶膜1到位 = null;
        #endregion

        #region 输出IO
        Output 真空电磁阀1 = null;
        Output 真空电磁阀2 = null;
        Output 真空泵 = null;
        Output 贴膜定位针上下 = null;
        Output 蜂鸣器 = null;
        Output 卷料压膜电池铁 = null;
        Output 测值支撑电磁铁 = null;
        Output 测值压料带电磁铁 = null;
        Output 测值垫高电磁铁 = null;
        Output 测值下针电磁铁 = null;
        Output 探针旋转 = null;
        Output 左收料 = null;
        Output 右收料 = null;
        #endregion


        /// <summary>
        /// 左流程
        /// </summary>
        public MainFlow FlowLeft = MainFlow.None;
        /// <summary>
        /// 右流程
        /// </summary>
        public MainFlow FlowRight = MainFlow.None;

        /// <summary>
        /// 贴膜流程
        /// </summary>
        public FilmFlow filmFlow = FilmFlow.None;
        public MotControl()
        {
            流道调宽 = MotionControl.GetAxis("流道调宽");
            凸轮 = MotionControl.GetAxis("凸轮");
            左进入 = MotionControl.GetAxis("左进入");
            右进入 = MotionControl.GetAxis("右进入");
            吸头平移 = MotionControl.GetAxis("吸头平移");
            吸头上下 = MotionControl.GetAxis("吸头上下");
            热熔上下 = MotionControl.GetAxis("热熔上下");
            拨刀 = MotionControl.GetAxis("拨刀");
            卷料 = MotionControl.GetAxis("卷料");
            探针A = MotionControl.GetAxis("探针A");
            测值整体上下 = MotionControl.GetAxis("测值整体上下");
            探针B = MotionControl.GetAxis("探针B");
            下针 = MotionControl.GetAxis("下针");


            Input 探针A原点 = MotionControl.GetInPutIO("探针A原点");
            Input 测值整体上下原点 = MotionControl.GetInPutIO("测值整体上下原点");
            Input 探针B原点 = MotionControl.GetInPutIO("探针B原点");
            Input 下针原点 = MotionControl.GetInPutIO("下针原点");
            Input 屏蔽按钮 = MotionControl.GetInPutIO("屏蔽按钮");
            Input 安全门开关 = MotionControl.GetInPutIO("安全门开关");
            Input 真空表 = MotionControl.GetInPutIO("真空表");
            Input 左收料按钮 = MotionControl.GetInPutIO("左收料按钮");
            Input 右收料按钮 = MotionControl.GetInPutIO("右收料按钮");
            Input 左料盘感应 = MotionControl.GetInPutIO("左料盘感应");
            Input 右料盘感应 = MotionControl.GetInPutIO("右料盘感应");
            Input 左轮光栅 = MotionControl.GetInPutIO("左轮光栅");
            Input 右轮光栅 = MotionControl.GetInPutIO("右轮光栅");
            Input 左物料光栅 = MotionControl.GetInPutIO("左物料光栅");
            Input 右物料光栅 = MotionControl.GetInPutIO("右物料光栅");
            Input 左入料光栅 = MotionControl.GetInPutIO("左入料光栅");
            Input 右入料光栅 = MotionControl.GetInPutIO("右入料光栅");
            Input 卷料原点 = MotionControl.GetInPutIO("卷料原点");
            Input 切料光纤感应 = MotionControl.GetInPutIO("切料光纤感应");
            Input 切料电机接近感应 = MotionControl.GetInPutIO("切料电机接近感应");
            Input 贴膜定位针上位 = MotionControl.GetInPutIO("贴膜定位针上位");
            Input 贴膜定位针下位 = MotionControl.GetInPutIO("贴膜定位针下位");
            Input 料尾感应光电 = MotionControl.GetInPutIO("料尾感应光电");
            Input 胶膜1到位 = MotionControl.GetInPutIO("胶膜1到位");


            Output 真空电磁阀1 = MotionControl.GetOutPutIO("真空电磁阀1");
            Output 真空电磁阀2 = MotionControl.GetOutPutIO("真空电磁阀2");
            Output 真空泵 = MotionControl.GetOutPutIO("真空泵");
            Output 贴膜定位针上下 = MotionControl.GetOutPutIO("贴膜定位针上下");
            Output 蜂鸣器 = MotionControl.GetOutPutIO("蜂鸣器");
            Output 卷料压膜电池铁 = MotionControl.GetOutPutIO("卷料压膜电池铁");
            Output 测值支撑电磁铁 = MotionControl.GetOutPutIO("测值支撑电磁铁");
            Output 测值压料带电磁铁 = MotionControl.GetOutPutIO("测值压料带电磁铁");
            Output 测值垫高电磁铁 = MotionControl.GetOutPutIO("测值垫高电磁铁");
            Output 测值下针电磁铁 = MotionControl.GetOutPutIO("测值下针电磁铁");
            Output 探针旋转 = MotionControl.GetOutPutIO("探针旋转");
            Output 左收料 = MotionControl.GetOutPutIO("左收料");
            Output 右收料 = MotionControl.GetOutPutIO("右收料");
        }

        public virtual void Run()
        {
            //左
            Task.Factory.StartNew(() =>
            {
                while (true)
                {

                    switch (FlowLeft)
                    {
                        case MainFlow.None:
                            if (!ParamManager.Instance.System_条码.B&& 左入料光栅.IsOn())
                            {
                                FlowLeft = MainFlow.进料;
                            }
                            break;
                        case MainFlow.进料:
                            //左轮开始转动

                            break;
                        case MainFlow.感应料带到光源位置:
                            //左轮停止转动
                            if (!ParamManager.Instance.System_找空料.B)
                            {
                                FlowLeft = MainFlow.请求测值;
                            }
                            break;
                        case MainFlow.找空料:

                            break;
                        case MainFlow.找空料完成:
                            break;

                        case MainFlow.请求测值:
                            if (Form1.MainControl.UCLCR.LCRHelper.LCRFlow == LCR.LCRFlow.None && Form1.MainControl.UCLCR.LCRHelper.Side == LCR.WhichSide.None)
                            {
                                Form1.MainControl.UCLCR.LCRHelper.Side = LCR.WhichSide.Left;
                                Form1.MainControl.UCLCR.LCRHelper.LCRFlow = LCR.LCRFlow.Start;
                                FlowLeft = MainFlow.测值中;
                            }
                            break;
                        case MainFlow.测值中:

                            break;
                        case MainFlow.测值完成:
                            if (!ParamManager.Instance.System_找空料.B)
                            {
                                FlowLeft = MainFlow.丝印;
                            }
                            if (!ParamManager.Instance.System_丝印.B)
                            {
                                FlowLeft = MainFlow.完成;
                            }
                            break;
                        case MainFlow.切空料:
                            break;
                        case MainFlow.切空料完成:
                            break;
                        case MainFlow.丝印:
                            break;
                        case MainFlow.丝印完成:
                            break;
                        case MainFlow.完成:
                            if (filmFlow==FilmFlow.完成)
                            {
                                FlowLeft = MainFlow.None;
                            }
                            break;
                        default:
                            break;
                    }

                    Thread.Sleep(20);
                }
            });

            //右
            Task.Factory.StartNew(() =>
            {
                while (true)
                {

                    switch (FlowRight)
                    {
                        case MainFlow.None:

                            break;
                        case MainFlow.进料:

                            break;
                        case MainFlow.感应料带到光源位置:

                            break;
                        case MainFlow.找空料:

                            break;
                        case MainFlow.找空料完成:
                            break;

                        case MainFlow.请求测值:
                            if (Form1.MainControl.UCLCR.LCRHelper.LCRFlow == LCR.LCRFlow.None && Form1.MainControl.UCLCR.LCRHelper.Side == LCR.WhichSide.None)
                            {
                                Form1.MainControl.UCLCR.LCRHelper.Side = LCR.WhichSide.Right;
                                Form1.MainControl.UCLCR.LCRHelper.LCRFlow = LCR.LCRFlow.Start;
                                FlowRight = MainFlow.测值中;
                            }
                            break;
                        case MainFlow.测值完成:
                            break;
                        case MainFlow.切空料:
                            break;
                        case MainFlow.切空料完成:
                            break;
                        case MainFlow.丝印:
                            break;
                        case MainFlow.丝印完成:
                            break;
                        case MainFlow.完成:
                            break;
                        default:
                            break;
                    }

                    Thread.Sleep(20);
                }
            });

            //贴膜
            Task.Factory.StartNew(() =>
            {

                while (true)
                {
                    switch (filmFlow)
                    {
                        case FilmFlow.None:
                            if (FlowLeft==MainFlow.完成&& FlowRight == MainFlow.完成)
                            {

                            }
                            break;
                        case FilmFlow.到位:

                            break;
                        case FilmFlow.卷料送一个膜:
                            break;
                        case FilmFlow.吸头上下吸膜:
                            break;
                        case FilmFlow.判断真空表:
                            break;
                        case FilmFlow.吸头上下到待机位:
                            break;
                        case FilmFlow.平移到对应贴膜位:
                            break;
                        case FilmFlow.贴膜动作:
                            break;
                        case FilmFlow.热熔动作:
                            break;
                        case FilmFlow.完成:
                            break;
                        default:
                            break;
                    }
                    Thread.Sleep(20);
                }
            });

        }
    }

    /// <summary>
    /// 主流程
    /// </summary>
    public enum MainFlow
    {
        None, //判断复位OK
        进料,//齿轮转动
        感应料带到光源位置,//齿轮走一格
        找空料,//拍照
        找空料完成,//去切空料位
        请求测值,//测值失败走一格
        测值中,
        测值完成,
        切空料,
        切空料完成,//去测值位，到位信号
        丝印,
        丝印完成,
        完成
    }

    /// <summary>
    /// 贴膜流程
    /// </summary>
    public enum FilmFlow
    {
        None,
        /// <summary>
        /// 吸头上下，热熔上下到待机位
        /// 吸头平移到吸膜位，拨刀去伸出位
        /// </summary>
        到位,
        卷料送一个膜,
        /// <summary>
        /// 打开真空电磁阀
        /// </summary>
        吸头上下吸膜,
        判断真空表,
        吸头上下到待机位,
        平移到对应贴膜位,
        贴膜动作,
        热熔动作,
        完成
    }

    //屏蔽扫码，屏蔽相机
}