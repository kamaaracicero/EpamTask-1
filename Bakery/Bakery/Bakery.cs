using Bakery.Interfaces;
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

        public Bakery(IBakeryReader reader, IBakerySaver saver, IBakeryConverter converter/*, FileStream file*/)
        {
            this.reader = reader;
            this.saver = saver;
            this.converter = converter;
            //mainFile = file;
        }

        public void InputDataFromFile(string path)
        {
            try
            {
                string[] strings = reader.ReadFile(new FileStream(path, FileMode.Open, FileAccess.Read));
                products = converter.ConvertFileStrings(strings);
                products.Sort()
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

        public override string ToString()
        {
            StringBuilder @string = new StringBuilder();
            foreach (Product product in products)
            {
                @string.Append("Name - " + product.Name + "; Amount: " + product.Amount + "\n");
                @string.Append(product);
            }
            return @string.ToString();
        }
    }
}
