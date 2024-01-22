using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MotionLibrary.Managers
{
    public abstract class BaseTimer
    {
        protected Timer timer;
        protected int delayTime;
        protected bool isRunning;
        protected string name;
        protected ManualResetEvent stopResetEvent = new ManualResetEvent(false);

        public bool IsRunning => isRunning;

        protected BaseTimer()
        {

        }

        public void Run(object state)
        {
            Run();
            if (stopResetEvent.WaitOne(delayTime))
            {
                return;
            }
            timer.Change(0, Timeout.Infinite);
        }

        public abstract void Run();

        /// <summary>
        /// 开始运行Run方法，建议使用Initialize方法
        /// </summary>
        public void Start()
        {
            if (isRunning)
            {
                AddLog($"[{name}]线程重复启动！");
                return;
            }
            if (timer == null)
            {
                timer = new Timer(Run, null, Timeout.Infinite, Timeout.Infinite);
            }
            stopResetEvent.Reset();
            isRunning = true;
            timer.Change(0, Timeout.Infinite);
        }

        /// <summary>
        /// 停止运行Run方法，建议使用Deinitialize方法
        /// </summary>
        public void Stop()
        {
            stopResetEvent.Set();
            isRunning = false;
        }

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="message"></param>
        public abstract void AddLog(string message);

        /// <summary>
        /// 初始化方法，默认只运行Start方法
        /// </summary>
        public virtual bool Initialize()
        {
            Start();
            return true;
        }

        /// <summary>
        /// 反初始化方法，默认只运行Stop方法
        /// </summary>
        public virtual bool Deinitialize()
        {
            Stop();
            return true;
        }

    }
}
