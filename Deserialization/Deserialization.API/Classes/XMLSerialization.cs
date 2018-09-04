using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Deserialization.Classes
{
    public class XMLSerialization
    {

       public void SerializeToXml(string fname)
        {
            SystemCommand command = new SystemCommand();
            XmlSerializer ser_xml = new XmlSerializer(typeof(SystemCommand));
            FileStream fileStream = new FileStream(fname, FileMode.Create);
            ser_xml.Serialize(fileStream, command);
            fileStream.Close();
        }

       public void DeSerializeFromXml(string fname)
        {
            SystemCommand command;
            XmlSerializer ser_xml = new XmlSerializer(typeof(SystemCommand));
            using (FileStream fs = File.Open(fname, FileMode.Open))
            {
                XmlReader xread = XmlReader.Create(fs);
                command = (SystemCommand)ser_xml.Deserialize(xread);
                fs.Close();
            }
            Console.WriteLine("Run: " + command._cmd);
            command.Run();
        }
    }
}
