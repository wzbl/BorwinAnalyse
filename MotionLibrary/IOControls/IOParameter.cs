using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MotionLibrary.IOControls
{
    [TypeConverter(typeof(NullConverter))]
    public class IOParameter
    {
        /// <summary>
        /// IO端口
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// IO名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// IO文本
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public int NormalValue { get; set; }

        /// <summary>
        /// 当前值
        /// </summary>
        [XmlIgnore]
        public int Value { get; set; }

    }
}
