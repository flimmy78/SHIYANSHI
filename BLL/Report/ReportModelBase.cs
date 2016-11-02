using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace Langben.Report
{
    /// <summary>
    /// XML《-》对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ObjConvert<T>
    {
        /// <summary>
        /// 将XML转化为对象
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static T XmlCovertObj(string input)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StringReader rdr = new StringReader(input.Trim());

            T result = (T)serializer.Deserialize(rdr);
            return result;
        }
        /// <summary>
        ///  将对象转换为XML
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string xml = "";
            try
            {
                XmlSerializer serializer = new XmlSerializer(this.GetType());
                using (MemoryStream mem = new MemoryStream())
                {
                    using (XmlTextWriter writer = new XmlTextWriter(mem, Encoding.UTF8))
                    {
                        writer.Formatting = Formatting.Indented;
                        XmlSerializerNamespaces n = new XmlSerializerNamespaces();
                        n.Add("", "");
                        serializer.Serialize(writer, this, n);
                        mem.Seek(0, SeekOrigin.Begin);
                        using (StreamReader reader = new StreamReader(mem))
                        {
                            xml = reader.ReadToEnd().Trim();
                        }
                    }
                }
            }
            catch { xml = ""; }
            return xml;

        }
    }
}
