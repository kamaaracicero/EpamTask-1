using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery
{
    public class Product : ICloneable
    {
        /// <summary>
        /// List of ingredients
        /// </summary>
        private readonly List<(string name, double cost, int calories)> ingredients = new List<(string name, double cost, int calories)>();

        /// <summary>
        /// Markup
        /// </summary>
        private readonly int markup = 0;

        /// <summary>
        /// Name of product
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Amount produced
        /// </summary>
        public int Amount { get; } = 0;

        /// <summary>
        /// The cost of all products in this category
        /// </summary>
        public double FullCost {
            get
            {
                double result = 0;
                double markupTemp = ((double)markup / 100) + 1;
                foreach(var (name, cost, calories) in ingredients)
                {
                    result += cost;
                }
                result *= markupTemp;
                return (result * Amount);
            }
        }

        /// <summary>
        /// The cost of one unit of this product
        /// </summary>
        public double Cost { 
            get
            {
                return FullCost / Amount;
            } 
        }

        /// <summary>
        /// The number of calories contained in one unit of this product
        /// </summary>
        public int Calories {
            get
            {
                int result = 0;
                foreach (var (name, cost, calories) in ingredients)
                {
                    result += calories;
                }
                return result;
            }
        }

        /// <summary>
        /// Number of ingredients
        /// </summary>
        public int NumberOfIngredients { 
            get
            {
                return ingredients.Count;
            }
        }

        /// <summary>
        /// Standart constructor
        /// </summary>
        /// <param name="name">Name of product</param>
        /// <param name="amount">Number of products</param>
        /// <param name="markup">Extra charge for this product</param>
        /// <param name="ingredients">Ingredients required for the manufacture of this product</param>
        public Product(string name, int amount, int markup, List<(string name, double cost, int calories)> ingredients) 
        {
            Name = name;
            Amount += amount;

            if (this.markup > 0) { this.markup = (this.markup + markup) / 2; }
            else this.markup = markup;

            this.ingredients = ingredients;
        }

        /// <summary>
        /// Method for adding ingredients
        /// </summary>
        /// <param name="ingredient">Ingredient written as a tuple</param>
        public void AddIngredient((string name, double cost, int calories) ingredient)
        {
            ingredients.Add(ingredient);
        }

        /// <summary>
        /// Method for adding ingredients
        /// </summary>
        /// <param name="name">Name of ingredient</param>
        /// <param name="cost">Price of ingredient</param>
        /// <param name="calories">Calories</param>
        public void AddIngredient(string name, double cost, int calories)
        {
            ingredients.Add((name, cost, calories));
        }

        /// <summary>
        /// Method for returning a clone of the given class
        /// </summary>
        /// <returns>New Product class</returns>
        public object Clone()
        {
            return new Product(this.Name, this.Amount, this.markup, this.ingredients);
        }

        /// <summary>
        /// The method of finding an ingredient with a volume exceeding the specified value
        /// </summary>
        /// <param name="ingredientName">Ingredient name</param>
        /// <param name="calories">Сalorie content of an ingredient</param>
        /// <returns>Contain or not</returns>
        public bool IsContain(string ingredientName, int calories)
        {
            foreach(var ingredien in ingredients)
            {
                if (ingredien.name.ToLower() == ingredientName.ToLower() && ingredien.calories > calories)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Converting the entire class to a string
        /// </summary>
        /// <returns>Class string</returns>
        public override string ToString()
        {
            StringBuilder @string = new StringBuilder();
            @string.Append("--Private--\n");
            @string.Append("\tMarkup: " + markup + "%\n\n");
            @string.Append("--Ingredients--\n");
            foreach(var ingredient in ingredients)
            {
                string cost = String.Format("{0:f3}", ingredient.cost);
                @string.Append("\t" + ingredient.name + " Cost: " + cost + " Calories: " + ingredient.calories + "\n");
            }
            @string.Append("\n\n");
            return @string.ToString();
        }

        /// <summary>
        /// Override base method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Bool value</returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// Override base method
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
