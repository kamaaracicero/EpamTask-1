using System.Collections.Generic;
using Storehouse.Interfaces;
using Storehouse.Products;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Storehouse.StandardClasses
{
    /// <summary>
    /// Standart saver class
    /// </summary>
    internal class StandartSaver : IStorageSaver
    {
        public void SaveInJson(List<Product> products, string path)
        {
            var serial = new DataContractJsonSerializer(typeof(List<Product>));

            using (FileStream file = new FileStream(path, FileMode.Create))
            {
                serial.WriteObject(file, products);
            }
        }
    }
}