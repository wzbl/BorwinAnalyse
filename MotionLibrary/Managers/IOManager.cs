using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotionLibrary.IOControls;

namespace MotionLibrary.Managers
{
    public class IOManager
    {
        private string fileName = "Ini/IOManager.xml";

        public IOControl InBitControl { get; set; } = new IOControl(IOType.InBit);

        public IOControl OutBitControl { get; set; } = new IOControl(IOType.OutBit);

        public IOManager()
        {

        }

        public IOManager(string fileName)
        {
            this.fileName = fileName;
        }

        public bool Load(string fileName)
        {
            this.fileName = fileName;
            return Load();
        }

        public bool Load()
        {
            var iOManager = SerializeHelper.DeserializeXml<IOManager>(fileName);
            if (iOManager == null)
            {
                return false;
            }
            InBitControl = iOManager.InBitControl;
            OutBitControl = iOManager.OutBitControl;
            InBitControl.Initialize();
            OutBitControl.Initialize();
            return true;
        }

        public bool Save(string fileName)
        {
            this.fileName = fileName;
            return Save();
        }

        public bool Save()
        {
            return SerializeHelper.SerializeXml(fileName, this); ;
        }
    }
}
