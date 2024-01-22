using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MotionLibrary
{
    public class OptionMotion
    {
        private OptionAxis[] m_oAxis = new OptionAxis[(int)Axis.Length];
        private string fileName = "Ini/OptionMotion.xml";

        [Browsable(false)]
        public OptionAxis[] AXIS { get { return this.m_oAxis; } }

        [Category("运动轴")]
        public OptionAxis A { get { return this.AXIS[(int)Axis.A]; } }

        [Category("运动轴")]
        public OptionAxis B { get { return this.AXIS[(int)Axis.B]; } }

        [Category("运动轴")]
        public OptionAxis C { get { return this.AXIS[(int)Axis.C]; } }

        [Category("运动轴")]
        public OptionAxis D { get { return this.AXIS[(int)Axis.D]; } }
        [Category("运动轴")]
        public OptionAxis E { get { return this.AXIS[(int)Axis.E]; } }
        [Category("运动轴")]
        public OptionAxis F { get { return this.AXIS[(int)Axis.F]; } }
        [Category("运动轴")]
        public OptionAxis G { get { return this.AXIS[(int)Axis.G]; } }
        [Category("运动轴")]
        public OptionAxis H { get { return this.AXIS[(int)Axis.H]; } }
        [Category("运动轴")]
        public OptionAxis I { get { return this.AXIS[(int)Axis.I]; } }
        [Category("运动轴")]
        public OptionAxis J { get { return this.AXIS[(int)Axis.J]; } }
        [Category("运动轴")]
        public OptionAxis K { get { return this.AXIS[(int)Axis.K]; } }
        [Category("运动轴")]
        public OptionAxis L { get { return this.AXIS[(int)Axis.L]; } }
        [Category("运动轴")]
        public OptionAxis M { get { return this.AXIS[(int)Axis.M]; } }
        [Category("运动轴")]
        public OptionAxis N { get { return this.AXIS[(int)Axis.N]; } }

        public OptionMotion()
        {
            for (int i = 0; i < m_oAxis.Length; i++)
            {
                MotionAxis motionAxis = new MotionAxis()
                {
                    Name = Enum.GetName(typeof(Axis), i).ToString(),
                    Number = i + 1,
                };
                this.m_oAxis[i] = new OptionAxis()
                {
                    MotionParam = motionAxis,
                    HomeParam = new HomeAxis()

                };

            }
        }

        public bool Load()
        {
            var axes = SerializeHelper.DeserializeXml<OptionAxis[]>(fileName);
            if (axes == null)
            {
                return false;
            }
            m_oAxis = new OptionAxis[(int)Axis.Length];
            m_oAxis = axes;
            return true;
        }

        public bool Save()
        {
            return SerializeHelper.SerializeXml(fileName, m_oAxis);
        }
    }

    public enum Axis
    {
        /// <summary>
        /// X轴
        /// </summary>
        A,
        /// <summary>
        /// Y轴
        /// </summary>
        B,
        /// <summary>
        /// Z轴
        /// </summary>
        C,
        /// <summary>
        /// A轴
        /// </summary>
        D,
        E,
        F,
        G,
        H,
        I,
        J,
        K,
        L,
        M,
        N,
        /// <summary>
        /// 枚举长度，无实意
        /// </summary>
        Length,
    }

    public enum Level
    {
        X1,
        X10,
        X100,
        X1000,
    }

    public class SerializeHelper
    {
        public static bool SerializeXml(string path, object obj)
        {
            try
            {
              
                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    XmlSerializer serializer = new XmlSerializer(obj.GetType());
                    serializer.Serialize(fs, obj);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static T DeserializeXml<T>(string path) where T : class
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    object obj = serializer.Deserialize(fs);
                    return obj as T;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
