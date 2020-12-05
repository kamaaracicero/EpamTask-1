using System.Collections.Generic;
using Storehouse.Interfaces;
using Storehouse.Products;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Storehouse.StandardClasses
{
    internal class StandartReader : IStorageReader
    {
        public List<Product> ReadJsonFile(string path)
        {
            var serial = new DataContractJsonSerializer(typeof(List<Product>));
            List<Product> products = new List<Product>();

            using (FileStream file = new FileStream(path, FileMode.Open))
            {
                products = (List<Product>)serial.ReadObject(file);
            }

            if (products.Count == 0) throw new ProductException("Empty file");
            else return products;
        }
    }
}
