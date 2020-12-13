using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace Task02
{
    public class XmlSerializer
    {
        public object Deserialize(String fileName, Type type)
        {
            object obj;
            FileStream fileStream = new FileStream(fileName, FileMode.Open);
            XmlDictionaryReader xmlDictionaryReader = XmlDictionaryReader.CreateTextReader(fileStream, new XmlDictionaryReaderQuotas());
            DataContractSerializer dataContractSerializer = new DataContractSerializer(type);
            obj = dataContractSerializer.ReadObject(xmlDictionaryReader, true);
            xmlDictionaryReader.Close();
            fileStream.Close();
            return obj;
        }

        public void Serialize(String fileName, object graph)
        {
            List<Type> types = new List<Type> { typeof(ClassA), typeof(ClassB), typeof(ClassC) };
            DataContractSerializer ser =
                new DataContractSerializer(graph.GetType(), types);
            XmlWriter writer = XmlWriter.Create(fileName, new XmlWriterSettings() { Indent = true });
            ser.WriteObject(writer, graph);
            writer.Close();
        }
    }
}
