using ChildrensTable.Figures;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ChildrensTable
{
    /// <summary>
    /// Save list of figures in xml file using StreamWriter
    /// </summary>
    /// <param name="path">File path</param>
    /// <param name="list">List of figures</param>
    public static class XmlHelper
    {
        public static void SaveInXml_StreamWriter(string path, List<Figure> list)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Figure>));

            using (FileStream file = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(file))
                    serializer.Serialize(writer, list);
            }
        }

        /// <summary>
        /// Save list of figures in xml file using XmlWriter
        /// </summary>
        /// <param name="path">File path</param>
        /// <param name="list">List of figures</param>
        public static void SaveInXml_XmlWriter(string path, List<Figure> list)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Figure>));

            using (FileStream file = new FileStream(path, FileMode.Create))
            {
                var settings = new XmlWriterSettings();
                settings.Encoding = Encoding.UTF8;
                settings.Indent = true;
                settings.OmitXmlDeclaration = true;
                settings.NewLineOnAttributes = false;
                using (XmlWriter writer = XmlWriter.Create(file, settings))
                    serializer.Serialize(writer, list);
            }
        }

        /// <summary>
        /// Read list from xml using StreamReader
        /// </summary>
        /// <param name="path">File path</param>
        /// <returns>List of figures</returns>
        public static List<Figure> ReadFromXml_StreamReader(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Figure>));
            List<Figure> list;
            using (FileStream file = new FileStream(path, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    list = serializer.Deserialize(reader) as List<Figure>;
                }
            }
            return list;
        }

        /// <summary>
        /// Read list from xml using XmlReader
        /// </summary>
        /// <param name="path">File path</param>
        /// <returns>List of figures</returns>
        public static List<Figure> ReadFromXml_XmlReader(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Figure>));
            List<Figure> list;

            using (FileStream file = new FileStream(path, FileMode.Open))
            {
                using (XmlReader reader = XmlReader.Create(file))
                {
                    list = serializer.Deserialize(reader) as List<Figure>;
                }
            }
            return list;
        }

    }
}
