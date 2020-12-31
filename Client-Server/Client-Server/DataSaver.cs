using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Client_Server
{
    public static class DataSaver
    {
        /// <summary>
        /// Save list in json file
        /// </summary>
        /// <typeparam name="T">List type</typeparam>
        /// <param name="list">List</param>
        public static void SaveListInJson<T>(List<T> list)
        {
            var serial = new DataContractJsonSerializer(typeof(List<T>));
            using (FileStream file = new FileStream("data.json", FileMode.Create))
            {
                serial.WriteObject(file, list);
            }
        }
    }
}
