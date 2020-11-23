using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery
{
    public class Product : ICloneable
    {
        private List<(string name, double cost, int calories)> ingredients = new List<(string name, double cost, int calories)>();
        private int markup = 0;


        public string Name { get; }
        public int Amount { get; } = 0;
        public double FullCost{
            get
            {
                double result = 0;
                double markupTemp = (markup / 100) + 1;
                foreach(var ingredient in ingredients)
                {
                    result += ingredient.cost;
                }
                return result * Amount * markupTemp;
            }
        }
        public double Cost { 
            get
            {
                return FullCost / Amount;
            } 
        }
        public int Calories
        {
            get
            {
                int result = 0;
                double markupTemp = (markup / 100) + 1;
                foreach (var ingredient in ingredients)
                {
                    result += ingredient.calories;
                }
                return result;
            }
        }

        public Product(string name, int amount, int markup, List<(string name, double cost, int calories)> ingredients) 
        {
            Name = name;
            Amount += amount;

            if (this.markup > 0) { this.markup = (this.markup + markup) / 2; }
            else this.markup = markup;

            this.ingredients = ingredients;
        }

        public object Clone()
        {
            return new Product(this.Name, this.Amount, this.markup, this.ingredients);
        }

        public override string ToString()
        {
            StringBuilder @string = new StringBuilder();
            @string.Append("--Private--\n");
            @string.Append("\tMarkup: " + markup + "%\n\n");
            @string.Append("--Ingredients--\n");
            foreach(var ingredient in ingredients)
            {
                @string.Append("\t" + ingredient.name + " Cost: " + ingredient.cost + " Calories: " + ingredient.calories + "\n");
            }
            @string.Append("\n\n");
            return @string.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
