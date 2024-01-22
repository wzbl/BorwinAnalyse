using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibSDK.Motion;

namespace LibSDK.IO
{
    public class Output
    {
        private IOParm.CIOType IOParm;

        private readonly IOAPI IO = new IOAPI();

        public Output(IOParm.CIOType iOParm)
        {
          this.IOParm = iOParm;
        }
        public void On()
        {
         IO.IoWrite(IOParm.IoName,0);
        }
        public void Off()
        {
         IO.IoWrite(IOParm.IoName, 1);
        }
        public bool State()
        {
          return IO.IoRadOut(IOParm);
        }
        public void Refresh() { }
        
    }
}
