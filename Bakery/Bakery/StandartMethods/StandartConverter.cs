using System.Text.RegularExpressions;
using System.Collections.Generic;
using System;
using Bakery.Interfaces;

namespace Bakery.StandartMethods
{
    internal class StandartConverter : IBakeryConverter
    {
        Regex productRegex;
        Regex ingredientRegex;

        public StandartConverter()
        {
            productRegex = new Regex(@"^(\w+\s*\w*)\s+Amount:(\d+)\s+Markup:(\d+)\%");
            ingredientRegex = new Regex(@"\t+(\w+\s?\w*)\s+(\d+[,]*\d*)kg\s(\d+)cal\s+(\d+[,]*\d*)\$");
        }

        public List<Product> ConvertFileStrings(string[] strings)
        {
            int index = 0;
            List<Product> products = new List<Product>();
            while (index < strings.Length)
            {
                if (!String.IsNullOrEmpty(strings[index]) && strings[index] != "\r")
                    products.Add(GetProductClass(strings, ref index));
                else
                    index++;
            }
            return products;
        }

        public Product GetProductClass(string[] strings, ref int currentString)
        {
            List<(string name, double cost, int calories)> ingredients = new List<(string name, double cost, int calories)>();
            string productName;
            int productAmount;
            int productMarkup;
            int index;

            ConvertStringToProduct(out productName, out productAmount, out productMarkup, strings[currentString]);

            for (index = currentString + 1; index < strings.Length; index++)
            {
                if (ingredientRegex.IsMatch(strings[index]))
                {
                    ingredients.Add(ConvertStringToIngredient(strings[index]));
                }
                else if (string.IsNullOrEmpty(strings[index]) || strings[index] == "\r") continue;
                else break;
            }
            currentString = index;

            return new Product(productName, productAmount, productMarkup, ingredients);
        }

        private void ConvertStringToProduct(out string name, out int amount, out int markup, string @string)
        {
            Match productString = productRegex.Match(@string);
            if (productString.Success)
            {
                name = productString.Groups[1].Value;
                amount = Convert.ToInt32(productString.Groups[2].Value);
                markup = Convert.ToInt32(productString.Groups[3].Value);
            }
            else throw new Exception("Inappropriate string");
        }

        private (string name, double cost, int calories) ConvertStringToIngredient(string @string)
        {
            string name;
            double cost;
            int calories;

            Match ingredientString = ingredientRegex.Match(@string);
            name = ingredientString.Groups[1].Value;
            cost = Convert.ToDouble(ingredientString.Groups[4].Value);
            calories = Convert.ToInt32(ingredientString.Groups[3].Value);

            return (name, cost, calories);
        }
    }
}

