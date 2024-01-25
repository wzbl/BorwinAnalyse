using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibSDK.Motion;

namespace LibSDK.IO
{
    public class Input: InBase
    {
        public CIOType IOParm;

        private readonly IOAPI IO = new IOAPI();

        private bool bNewStatus = false;

        private bool bOldStatus = false;

        private bool bIsInitial = false;

        private bool _ReverseStatus;

        public Input(CIOType iOParm)
        {
          this.IOParm = iOParm;
        }
        public bool RStatus
        {
            get
            {
              return this._ReverseStatus;
            }
            set
            {
              base.ReverseStatus = value;
              this._ReverseStatus = value;
            }
        }
        public bool IsOn()
        {
            Refresh();
            return base.ReadOn();
        }
        public bool IsOn(int DelayTime)
        {
            Refresh();
            return base.ReadOn(DelayTime);
        }
        public  bool IsOff()
        {
            Refresh();
            return base.ReadOff();
        }
        public bool IsOff(int DelayTime)
        {
            Refresh();
            return base.ReadOff(DelayTime);
        }
        public void Refresh()
        {
          base.Status=IO.IoReadIn(IOParm);
        }

        public bool State()
        {
            return IO.IoReadIn(IOParm);
        }
    }
}
