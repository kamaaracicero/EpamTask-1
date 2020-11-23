using Bakery.Interfaces;
using Bakery.StandartMethods;
using Bakery.Comparers;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System;
using System.Text;

namespace Bakery
{
    public class Bakery
    {
        public delegate void MessageHandler(string mes);
        public event MessageHandler MessageEvent; 

        IBakeryReader reader;
        IBakerySaver saver;
        IBakeryConverter converter;
        FileStream mainFile;

        List<Product> products;

        public Bakery(IBakeryReader reader, IBakerySaver saver, IBakeryConverter converter, FileStream file)
        {
            this.reader = reader;
            this.saver = saver;
            this.converter = converter;
            mainFile = file;
        }

        public Bakery(IBakeryReader reader, IBakerySaver saver, IBakeryConverter converter) : this (reader, saver, converter, new FileStream("data.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
        { }

        public Bakery() : this (new StandartReader(), new StandartSaver(), new StandartConverter())
        { }

        public void InputDataFromFile(string path)
        {
            try
            {
                string[] strings = reader.ReadFile(new FileStream(path, FileMode.Open, FileAccess.Read));
                products = converter.ConvertFileStrings(strings);
            }
            catch (DirectoryNotFoundException dictEx)
            {
                MessageEvent(dictEx.Message);
            }
            catch (FileNotFoundException fileEx)
            {
                MessageEvent(fileEx.Message);
            }
        }

        public List<Product> GetClonedListOfProduct(TypeOfSort type)
        {
            List<Product> productsClone = new List<Product>();
            foreach (Product product in products)
            {
                productsClone.Add(product.Clone() as Product);
            }
            switch (type)
            {
                case TypeOfSort.ByCalories:
                    productsClone.Sort(new CaloriesComparer());
                    break;
                case TypeOfSort.ByCost:
                    productsClone.Sort(new CostComparer());
                    break;
                case TypeOfSort.ByFullCost:
                    productsClone.Sort(new TotalCostComparer());
                    break;
            }
            return productsClone;
        }

        public void SortProduction(TypeOfSort type)
        {
            switch (type)
            {
                case TypeOfSort.ByCalories:
                    products.Sort(new CaloriesComparer());
                    break;
                case TypeOfSort.ByCost:
                    products.Sort(new CostComparer());
                    break;
                case TypeOfSort.ByFullCost:
                    products.Sort(new TotalCostComparer());
                    break;
            }
        }

        public override string ToString()
        {
            StringBuilder @string = new StringBuilder();
            foreach (Product product in products)
            {
                @string.Append("--Public--\n");
                @string.Append("Name - " + product.Name + "; \n\tAmount: " + product.Amount + "; \n\tCost: " + product.Cost + "; \n\tCalories: " + product.Calories + "; \n\tFullCost: " + product.FullCost + "\n");
                //@string.Append(product);
            }
            return @string.ToString();
        }
    }
}
