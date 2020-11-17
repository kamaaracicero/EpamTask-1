using Bakery.Interfaces;
using System.IO;

namespace Bakery
{
    internal class Reader : IBakeryReader
    {
        public string[] ReadFile(FileStream file)
        {
            string[] strings;
            using (StreamReader reader = new StreamReader(file))
            {
                strings = reader.ReadToEnd().Split('\n');
            }
            return strings;
        }
    }
}
