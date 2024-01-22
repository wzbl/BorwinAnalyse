using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Security.Cryptography;
using System.IO.IsolatedStorage;

namespace LibSDK.Rwfile
{
    public class CDataXml
    {
        /// <summary>
        /// ∑¥–Ú¡–ªØ
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content"></param>
        /// <returns></returns>
        public T Deserialize<T>(string content)
        {

            using (System.IO.StringReader strReader = new System.IO.StringReader(content))
            {
                T result = default(T);
                XmlSerializer xmldes = new XmlSerializer(typeof(T));
                result = (T)xmldes.Deserialize(strReader);
                return result;
            }
        }
        public string Serializer<T>(T t)
        {
            string result = "";
            MemoryStream Stream = new MemoryStream();
            XmlSerializer xml = new XmlSerializer(typeof(T));
            xml.Serialize(Stream, t);
            Stream.Position = 0;

            StreamReader strReader = new StreamReader(Stream);
            result = strReader.ReadToEnd();
            strReader.Dispose();
            Stream.Dispose();
            return result;
        }

        public bool Serializer<T>(string filePath, T objInstance)
        {
            using (System.IO.StreamWriter sWriter = new System.IO.StreamWriter(filePath, false, Encoding.UTF8))
            {
                Type type = objInstance.GetType();
                System.Xml.Serialization.XmlSerializer xmlFormat = new System.Xml.Serialization.XmlSerializer(type);
                
                System.Xml.Serialization.XmlSerializerNamespaces xmlSN = new System.Xml.Serialization.XmlSerializerNamespaces();
                xmlSN.Add("", "");

                xmlFormat.Serialize(sWriter, objInstance, xmlSN);
            }
            return true;
        }
        public T DeserializeFile<T>(string filePath)
        {

            using (FileStream fs = File.Open(filePath, FileMode.Open))
            {
                using (System.IO.StreamReader streamReader = new System.IO.StreamReader(fs, Encoding.UTF8))
                {
                    T result = default(T);
                    XmlSerializer xmldes = new XmlSerializer(typeof(T));
                    result = (T)xmldes.Deserialize(streamReader);
                    return result;
                }
            }
        }

        public  void EncryptAndSerialize<T>(string filePath, T obj, SymmetricAlgorithm key)
        {
            using (FileStream fs = File.Open(filePath, FileMode.Create))
            {
                using (CryptoStream cs = new CryptoStream(fs, key.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    XmlSerializer xmlser = new XmlSerializer(typeof(T));
                    xmlser.Serialize(cs, obj);
                }
            }
        }
        public  T DecryptAndDeserialize<T>(string filePath, SymmetricAlgorithm key)
        {
            using (FileStream fs = File.Open(filePath, FileMode.Open))
            {
                using (CryptoStream cs = new CryptoStream(fs, key.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    XmlSerializer xmlser = new XmlSerializer(typeof(T));
                    return (T)xmlser.Deserialize(cs);
                }
            }
        }
    }
}
