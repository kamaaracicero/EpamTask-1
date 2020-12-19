using ChildrensTable.Figures;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ChildrensTable
{
    public static class XmlHelper
    {
        public static void SaveInXml_Writer(string path, List<Figure> list)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Figure>));

            using (FileStream file = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(file))
                    serializer.Serialize(writer, list);
            }
        }

    }
}
