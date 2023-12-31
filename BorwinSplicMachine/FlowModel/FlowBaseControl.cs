﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml;
using System.Security.Cryptography.X509Certificates;

namespace BorwinSplicMachine.FlowModel
{
    [Serializable]
    [XmlInclude(typeof(FlowBarCode))]
    [XmlInclude(typeof(FlowLCR))]
    [XmlInclude(typeof(FlowMatchControl))]
    [XmlInclude(typeof(FlowFindEmptyStripsControl))]
    public  class FlowBaseControl
    {
        public FlowModeControl FlowModeControl=new FlowModeControl();

        public List<OutOrInFlow> InFlow = new List<OutOrInFlow>();

        public List<OutOrInFlow> outFlows = new List<OutOrInFlow>();

        public bool RunResult = false;

      
        public  FlowBaseControl()
        {
            
        }


        /// <summary>
        /// 运行
        /// </summary>
        public virtual void Run() { }

    }

    [Serializable]
    public class OutOrInFlow
    {
        public OutOrInFlow()
        {

        }

        public OutOrInFlow(FlowModeControl FlowModeControl, BaseModelPos baseModelPos)
        {
            this.baseModelPos = baseModelPos;
            this.FlowModeControl = FlowModeControl;
        }
        public FlowModeControl FlowModeControl;
        public BaseModelPos baseModelPos;
    }

    [Serializable]
    public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable
    {
        public SerializableDictionary() { }
        public void WriteXml(XmlWriter write)       // Serializer
        {
            XmlSerializer KeySerializer = new XmlSerializer(typeof(TKey));
            XmlSerializer ValueSerializer = new XmlSerializer(typeof(TValue));

            foreach (KeyValuePair<TKey, TValue> kv in this)
            {
                write.WriteStartElement("SerializableDictionary");
                write.WriteStartElement("key");
                KeySerializer.Serialize(write, kv.Key);
                write.WriteEndElement();
                write.WriteStartElement("value");
                ValueSerializer.Serialize(write, kv.Value);
                write.WriteEndElement();
                write.WriteEndElement();
            }
        }
        public void ReadXml(XmlReader reader)       // Deserializer
        {
            reader.Read();
            XmlSerializer KeySerializer = new XmlSerializer(typeof(TKey));
            XmlSerializer ValueSerializer = new XmlSerializer(typeof(TValue));
          
            while (reader.NodeType != XmlNodeType.EndElement&& reader.HasValue)
            {
                reader.ReadStartElement("SerializableDictionary");
                reader.ReadStartElement("key");
                TKey tk = (TKey)KeySerializer.Deserialize(reader);
                reader.ReadEndElement();
                reader.ReadStartElement("value");
                TValue vl = (TValue)ValueSerializer.Deserialize(reader);
                reader.ReadEndElement();
                reader.ReadEndElement();
                this.Add(tk, vl);
                reader.MoveToContent();
            }
            reader.ReadEndElement();

        }
        public XmlSchema GetSchema()
        {
            return null;
        }
    }
}
