using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery
{
    public class Product : IComparable
    {
        private List<(string name, double cost, int calories)> ingredients = new List<(string name, double cost, int calories)>();
        private int markup = 0;


        public string Name { get; }
        public int Amount { get; } = 0;
        public double FullCost{
            get
            {
                return 1;
            }
        }
        public double CostPerPiece { 
            get
            {
                return 1;
            } 
        }
        public uint Calories
        {
            get
            {
                return 1;
            }
        }

        public int CompareTo(object o)
        {
            Product product = o as Product;
            if (product != null)
            {
                if (this.Calories > product.Calories) return 1;
                else if (this.Calories < product.Calories) return -1;
                else return 0;
            }
            else
                throw new Exception("Сomparison is impossible");
        }

        public Product(string name, int amount, int markup, List<(string name, double cost, int calories)> ingredients) 
        {
            Name = name;
            Amount += amount;

            if (this.markup > 0) { this.markup = (this.markup + markup) / 2; }
            else this.markup = markup;

            this.ingredients = ingredients;
        }

        public override string ToString()
        {
            StringBuilder @string = new StringBuilder();
            @string.Append("--Private--\n");
            @string.Append("Markup: " + markup + "\n");
            @string.Append("--Ingredients--\n");
            foreach(var ingredient in ingredients)
            {
                @string.Append("\t" + ingredient.name + " Cost: " + ingredient.cost + " Calories: " + ingredient.calories + "\n");
            }
            return @string.ToString();
        }
    }
}
