using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NetCloneFuzzer
{
    public static class XmlHelper<T> where T : class
    {
        public static T ReadFromFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return null;
            }

            try
            {
                XmlSerializer xmlSerial = new XmlSerializer(typeof(T));
                using (Stream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    T result = (T)xmlSerial.Deserialize(fs);
                    fs.Close();
                    return result;
                }
            }
            catch (Exception /*ex*/)
            {
                return null;
            }
        }

        public static void WriteToFile(T data, string fileName)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            XmlSerializer xmlSerial = new XmlSerializer(typeof(T));
            using (Stream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                xmlSerial.Serialize(fs, data, ns);
                fs.Flush();
                fs.Close();
            }
        }
    }
}
