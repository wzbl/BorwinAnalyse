using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionLibrary.IOControls
{
    [TypeConverter(typeof(NullConverter))]
    public class IOControl
    {
        private Dictionary<string, IOParameter> m_dicData = new Dictionary<string, IOParameter>();
        public IOType IOType;

        public IOParameter[] IOParameters { get; set; } = new IOParameter[16];
        //public Dictionary<string, IOParameter> Data { get => m_dicData; }

        public IOControl()
        {

        }

        public IOControl(IOType iOType)
        {
            this.IOType = iOType;
            string nameStr = "";
            string textStr = "";
            if (IOType == IOType.InBit)
            {
                nameStr += "INB_";
                textStr += "EXI";
            }
            else
            {
                nameStr += "OUTB_";
                textStr += "EXO";
            }
            for (int i = 0; i < IOParameters.Length; i++)
            {
                IOParameters[i] = new IOParameter()
                {
                    Name = nameStr + i,
                    Port = i,
                    Text = textStr + i.ToString("#00"),
                };
            }
        }

        public void Initialize()
        {
            foreach (var each in IOParameters)
            {
                if (!string.IsNullOrWhiteSpace(each.Name))
                {
                    m_dicData.Add(each.Name, each);
                }
            }
        }

        public IOParameter this[string name]
        {
            get
            {
                if (m_dicData.ContainsKey(name))
                    return m_dicData[name];
                return null;
            }
        }
    }

    public enum IOType
    {
        InBit,
        OutBit,
    }
}
