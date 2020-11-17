using System.Text.RegularExpressions;
using System.Collections.Generic;
using System;
using Bakery.Interfaces;

namespace Bakery.StandartMethods
{
    internal class Converter : IBakeryConverter
    {
        // Probably need some changes
        public List<Product> ConvertFileStrings(string[] strings)
        {
            int index = 0;
            List<Product> products = new List<Product>();
            while (index < strings.Length)
            {
                products.Add(ConvertProductString(strings, ref index));
            }
            return products;
        }

        public Product ConvertProductString(string[] strings, ref int stopPlace)
        {
            Regex productRegex = new Regex(@"^(\w+\s*\w*)\s+Amount:(\d+)\s+Markup:(\d+)\%");
            Regex ingredientRegex = new Regex(@"\t+(\w+\s?\w*)\s+(\d+[,]*\d*)kg\s(\d+)cal\s+(\d+[,]*\d*)\$");

            string productName = null;
            int productAmount = 0;
            int productMarkup = 0;
            int index;
            Match productString = productRegex.Match(strings[stopPlace]);
            if (productString.Success)
            {
                productName = productString.Groups[1].Value;
                productAmount = Convert.ToInt32(productString.Groups[2].Value);
                productMarkup = Convert.ToInt32(productString.Groups[3].Value);
                stopPlace++;
            }
            else
            {
                throw new Exception("Inappropriate string");
            }

            List<(string name, double cost, int calories)> ingredients = new List<(string name, double cost, int calories)>();
            for (index = stopPlace; index < strings.Length; index++)
            {
                if (ingredientRegex.IsMatch(strings[index]))
                {
                    ingredients.Add(ConvertStringToIngredient(strings[index], ingredientRegex));
                }
                else
                {
                    break;
                }
            }
            stopPlace = index;

            return new Product(productName, productAmount, productMarkup, ingredients);
        }

        private (string name, double cost, int calories) ConvertStringToIngredient(string @string, Regex ingredientRegex)
        {
            string name = null;
            double cost = 0;
            int calories = 0;

            Match ingredientString = ingredientRegex.Match(@string);
            name = ingredientString.Groups[1].Value;
            cost = Convert.ToDouble(ingredientString.Groups[4].Value);
            calories = Convert.ToInt32(ingredientString.Groups[3].Value);

            return (name, cost, calories);
        }
    }
}

