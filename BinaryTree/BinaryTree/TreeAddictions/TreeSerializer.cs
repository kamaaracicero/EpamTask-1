using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Text;
using BinaryTree.Interfaces;

namespace BinaryTree.TreeAddictins
{
    internal class TreeSerializer : ITreeSerializer
    {
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
