using System;
using Storehouse.Interfaces;
using Storehouse.Products;
using Storehouse.StandardClasses;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Storehouse
{
    public class Storage
    {
        private IStorageReader reader;

        private IStorageSaver saver;

        public List<Product> products = new List<Product>();

        public Storage()
        {
            reader = new StandartReader();
            saver = new StandartSaver();
        }

        public void SaveProducts(string path)
        {
            saver.SaveInJson(products, path);
        }

        public void LoadProducts(string path)
        {
            products = reader.ReadJsonFile(path);
        }

        public void FoldProducts()
        {
            for (int indexF = 0; indexF < products.Count; indexF++)
            {
                string name = products[indexF].Name.ToLower();
                //List<Product> _products = products.FindAll(p => p.Name == name);
                for (int indexS = indexF + 1; indexS < products.Count; indexS++)
                {
                    if (products[indexS].Name.ToLower() == name)
                    {
                        products[indexF] += products[indexS];
                        products.RemoveAt(indexS);
                        indexS--;
                    }
                }
            }
        }

        public void FoldProducts(int firstIndex, int secondIndex)
        {
            if (Product.IsIdenticalProduct(products[firstIndex], products[secondIndex]))
            {
               products[firstIndex] += products[secondIndex];
               products.RemoveAt(secondIndex);
            }
            else throw new ProductException("Folding different products");
        }

        public void AddProduct(string name, double price, int markup, int amount)
        {
            switch(name.ToLower())
            {
                case "laptop":
                    products.Add(new Laptop(price, amount));
                    break;
                case "rubber":
                    products.Add(new Rubber(price, amount));
                    break;
                default:
                    products.Add(new Product(name, price, markup, amount));
                    break;
            }
        }

        public void AddAmountForProduct(string name, int amount)
        {

        }

        public override string ToString()
        {
            StringBuilder @string = new StringBuilder();
            foreach(Product product in products)
            {
                @string.Append(product.Name + "\n\tPrice: " + product.PurchasePrice + "\n\tAmount: " + product.Amount + "\n");
            }
            return @string.ToString();
        }
    }
}
