using MotionLibrary.IOControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionLibrary.Managers
{
    public class MotionManager
    {
        private static MotionManager instance;
        public static MotionManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MotionManager();
                }
                return instance;
            }
        }

        public IOControl InBitControl { get;  set; } = new IOControl(IOType.InBit);
        public IOControl OutBitControl { get;  set; } = new IOControl(IOType.OutBit);
        public Motion_GC Motion_GC =new Motion_GC();
        

    }
}
