using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LibSDK
{
    public class KTimer
    {
        private GetTickCountEx tick = new GetTickCountEx();

        private long StartTM;

        public void Restart()
        {
            this.StartTM = this.tick.Value;
        }

        public bool IsOn(long millisecond)
        {
            long num = this.tick.Value - this.StartTM;
            return num >= millisecond;
        }

        public long GetTime()
        {
            return this.tick.Value - this.StartTM;
        }
    }

    public class GetTickCountEx
    {
        private bool isPerfCounterSupported = false;

        public long frequency = 0L;

        private const string lib = "kernel32.dll";

        public long Value
        {
            get
            {

                long num = 0L;
                bool flag = this.isPerfCounterSupported;
                if (flag)
                {
                    GetTickCountEx.QueryPerformanceCounter(ref num);
                }
                else
                {
                    num = (long)Environment.TickCount;
                }
                double num2 = (double)num * 1000.0 / (double)this.frequency;
                return (long)num2;
            }
        }
        [DllImport("kernel32.dll")]
        private static extern int QueryPerformanceCounter(ref long count);

        [DllImport("kernel32.dll")]
        private static extern int QueryPerformanceFrequency(ref long frequency);

        public GetTickCountEx()
        {
            int num = GetTickCountEx.QueryPerformanceFrequency(ref this.frequency);
            bool flag = num != 0 && this.frequency != 1000L;
            if (flag)
            {
                this.isPerfCounterSupported = true;
            }
            else
            {
                this.frequency = 1000L;
            }
        }
    }
}
