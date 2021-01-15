using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Text;
using BinaryTree.Interfaces;

namespace BinaryTree.TreeAddictins
{
    internal class TreeXmlSerializer : ITreeSerializer
    {
        public object DeserializeTree(Type serType, string path)
        {
            object tree;
            var serializer = new DataContractSerializer(serType);
            using (FileStream file = new FileStream(path, FileMode.Open))
            {
                var settings = new XmlReaderSettings()
                {
                    
                };
                using (XmlReader reader = XmlReader.Create(file, settings))
                {
                    tree = serializer.ReadObject(reader);
                }
            }
            return tree;
        }

        public void SerializeTree(Type serType, object tree, string path)
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
