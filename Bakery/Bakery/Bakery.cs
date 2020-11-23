using Bakery.Interfaces;
using Bakery.StandartMethods;
using Bakery.Comparers;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bakery
{
    public class Bakery
    {
        /// <summary>
        /// Handler for message
        /// </summary>
        /// <param name="mes">Message</param>
        public delegate void MessageHandler(string mes);

        /// <summary>
        /// Bakery main event
        /// </summary>
        public static event MessageHandler MessageEvent;

        /// <summary>
        /// Reader class
        /// </summary>
        readonly IBakeryReader reader;

        /// <summary>
        /// Saver class
        /// </summary>
        readonly IBakerySaver saver;

        /// <summary>
        /// Converter class
        /// </summary>
        readonly IBakeryConverter converter;

        /// <summary>
        /// Main file
        /// </summary>
        readonly FileStream mainFile;

        /// <summary>
        /// List of products
        /// </summary>
        List<Product> products;

        /// <summary>
        /// Standart constructor with the specified file
        /// </summary>
        /// <param name="reader">Class for reading file</param>
        /// <param name="saver">Class for saving data</param>
        /// <param name="converter">Class for converting file</param>
        /// <param name="file">Main file</param>
        public Bakery(IBakeryReader reader, IBakerySaver saver, IBakeryConverter converter, FileStream file)
        {
            this.reader = reader;
            this.saver = saver;
            this.converter = converter;
            mainFile = file;
        }

        /// <summary>
        /// Standart constructor
        /// </summary>
        /// <param name="reader">Class for reading file</param>
        /// <param name="saver">Class for saving data</param>
        /// <param name="converter">Class for converting file</param>
        public Bakery(IBakeryReader reader, IBakerySaver saver, IBakeryConverter converter) : this (reader, saver, converter, new FileStream("data.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
        { }
        
        /// <summary>
        /// Empty constructor
        /// </summary>
        public Bakery() : this (new StandartReader(), new StandartSaver(), new StandartConverter())
        { }

        /// <summary>
        /// Read the file and convert it to data
        /// </summary>
        /// <param name="path">path to file</param>
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

        /// <summary>
        /// Method for adding a new product to the array
        /// </summary>
        /// <param name="name">Product name</param>
        /// <param name="amount">Number of products</param>
        /// <param name="markup">Extra charge for this product</param>
        /// <param name="ingredients">Array of ingredients</param>
        public void AddNewProduct(string name, int amount, int markup, List<(string name, double cost, int calories)> ingredients)
        {
            products.Add(new Product(name, amount, markup, ingredients));
        }

        /// <summary>
        /// Returns a list of items with a typed sort
        /// </summary>
        /// <param name="type">Sort type</param>
        /// <returns>New list with products</returns>
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

        /// <summary>
        /// Sorting an array of products
        /// </summary>
        /// <param name="type">Sort type</param>
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

        /// <summary>
        /// Find all foods with a specified price and calorie count
        /// </summary>
        /// <param name="cost">Product price</param>
        /// <param name="calories">Calorie count</param>
        /// <returns>String with all products</returns>
        public string FindProducts(int cost, int calories)
        {
            StringBuilder @string = new StringBuilder();
            @string.Append("Matches:\n");
            foreach(Product product in products)
            {
                if(product.Cost == cost && product.Calories == calories)
                {
                    @string.Append(product.Name + "\n");
                }
            }
            return @string.ToString();
        }

        /// <summary>
        /// Find in the array all products for which the volume of use the specified ingredient is greater than the specified value
        /// </summary>
        /// <param name="ingredientName">Name of the specified ingredient</param>
        /// <param name="calories">Volume(here the calorie value is used)</param>
        /// <returns>String with all products</returns>
        public string FindProducts(string ingredientName, int calories)
        {
            StringBuilder @string = new StringBuilder();
            @string.Append("Products:\n");
            foreach(Product product in products)
            {
                if(product.IsContain(ingredientName, calories))
                {
                    @string.Append(product.Name + "\n");
                }
            }
            return @string.ToString();
        }

        /// <summary>
        /// Find the number of products with more ingredients than a given value
        /// </summary>
        /// <param name="number">Value</param>
        /// <returns>Returns the number of products</returns>
        public int FindNumberOfProducts(int number)
        {
            int count = 0;
            foreach(Product product in products)
            {
                if (product.NumberOfIngredients > number)
                    count++;
            }
            return count;
        }

        public void Save()
        {
            saver.Save(products, mainFile, MessageEvent);
        }

        /// <summary>
        /// Converting the entire class to a string
        /// </summary>
        /// <returns>Class string</returns>
        public override string ToString()
        {
            StringBuilder @string = new StringBuilder();
            foreach (Product product in products)
            {
                string fullcost = string.Format("{0:f3}", product.FullCost);
                string cost = string.Format("{0:f3}", product.Cost);
                @string.Append("--Public--\n");
                @string.Append("Name - " + product.Name + "; \n\tAmount: " + product.Amount + "; \n\tCost: " + cost + "; \n\tCalories: " + product.Calories + "; \n\tFullCost: " + fullcost + "\n");
                @string.Append(product);
            }
            return @string.ToString();
        }

        /// <summary>
        /// Override base method
        /// </summary>
        /// <param name="obj">Odject</param>
        /// <returns>Bool value</returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// Override base method
        /// </summary>
        /// <returns>Int value</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
