using Bakery.Interfaces;
using System.IO;

namespace Bakery.StandartMethods
{
    internal class StandartReader : IBakeryReader
    {
        public string[] ReadFile(FileStream file)
        {
            string[] strings;
            using (StreamReader reader = new StreamReader(file))
            {
                strings = reader.ReadToEnd().Split('\n');
            }
            file.Close();
            return strings;
        }
    }
}
