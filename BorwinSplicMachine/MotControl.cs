using LibSDK;
using LibSDK.Motion;
using Mes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BorwinSplicMachine
{
    /// <summary>
    /// 运动控制类
    /// </summary>
    public class MotControl
    {
        public MotAPI A;
        public MotAPI B;
        public MotAPI C;
        public MotAPI D;
        public MotAPI E;
        public MotAPI F;
        public MotAPI G;
        public MotAPI H;
        public MotControl()
        {
            Init();
        }

        private void Init()
        {
            InitAxis();
            InitIO();
        }

        private void InitAxis()
        {
            A = MotionControl.AddAxis("A轴");
            B = MotionControl.AddAxis("B轴");
            C = MotionControl.AddAxis("C轴");
            D = MotionControl.AddAxis("D轴");
            E = MotionControl.AddAxis("E轴");
            F = MotionControl.AddAxis("F轴");
            G = MotionControl.AddAxis("G轴");
            H = MotionControl.AddAxis("H轴");
            MotionControl.AxisParm.Write();
        }

        private void InitIO()
        {
            MotionControl.AddOutPutIO("OUT_0");
            MotionControl.AddOutPutIO("OUT_1");
            MotionControl.AddOutPutIO("OUT_2");
            MotionControl.AddOutPutIO("OUT_3");
            MotionControl.AddOutPutIO("OUT_4");
            MotionControl.AddOutPutIO("OUT_5");
            MotionControl.AddOutPutIO("OUT_6");
            MotionControl.AddOutPutIO("OUT_7");
            MotionControl.AddOutPutIO("OUT_8");
            MotionControl.AddOutPutIO("OUT_9");
            MotionControl.AddOutPutIO("OUT_10");
            MotionControl.AddOutPutIO("OUT_11");
            MotionControl.AddOutPutIO("OUT_12");
            MotionControl.AddOutPutIO("OUT_13");
            MotionControl.AddOutPutIO("OUT_14");
            MotionControl.AddOutPutIO("OUT_15");
            MotionControl.AddOutPutIO("OUT_16");
            MotionControl.AddOutPutIO("OUT_17");
            MotionControl.AddOutPutIO("OUT_18");
            MotionControl.AddOutPutIO("OUT_19");
            MotionControl.AddOutPutIO("OUT_20");


            MotionControl.AddInPutIO("IN_0");
            MotionControl.AddInPutIO("IN_1");
            MotionControl.AddInPutIO("IN_2");
            MotionControl.AddInPutIO("IN_3");
            MotionControl.AddInPutIO("IN_4");
            MotionControl.AddInPutIO("IN_5");
            MotionControl.AddInPutIO("IN_6");
            MotionControl.AddInPutIO("IN_7");
            MotionControl.AddInPutIO("IN_8");
            MotionControl.AddInPutIO("IN_9");
            MotionControl.AddInPutIO("IN_10");
            MotionControl.AddInPutIO("IN_11");
            MotionControl.AddInPutIO("IN_12");
            MotionControl.AddInPutIO("IN_13");
            MotionControl.AddInPutIO("IN_14");
            MotionControl.AddInPutIO("IN_15");
            MotionControl.AddInPutIO("IN_16");
            MotionControl.AddInPutIO("IN_17");
            MotionControl.AddInPutIO("IN_18");
            MotionControl.AddInPutIO("IN_19");
            MotionControl.AddInPutIO("IN_20");
            MotionControl.IOParmIn.Write();
            MotionControl.IOParmOut.Write();
        }
    }
}
