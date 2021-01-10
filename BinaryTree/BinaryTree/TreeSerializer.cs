using System;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Text;

namespace BinaryTree
{
    internal class TreeSerializer
    {
        private string path;

        public TreeSerializer()
        {
            path = "data.xml";
        }

        public TreeSerializer(string path)
        {
            this.path = path;
        }

        public void SerializeTree(Type serType, object tree)
        {
            var serializer = new DataContractSerializer(serType);
            using (FileStream file = new FileStream(path, FileMode.Create))
            {
                var settings = new XmlWriterSettings()
                {
                    Encoding = Encoding.UTF8,
                    Indent = true,
                    OmitXmlDeclaration = true,
                    NewLineOnAttributes = false
                };
                using (XmlWriter writer = XmlWriter.Create(file, settings))
                {
                    serializer.WriteObject(writer, tree);
                }
            }
        }
    }
}
