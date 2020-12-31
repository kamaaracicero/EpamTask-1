using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Client_Server
{
    public static class DataSaver
    {
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
