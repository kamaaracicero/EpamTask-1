using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace Storehouse.Products
{
    /// <summary>
    /// Class of product
    /// You can use both a generalized class Product, and separately prescribed ones, such as a Laptop.
    /// </summary>
    [DataContract]
    [KnownType(typeof(Rubber))]
    [KnownType(typeof(Laptop))]
    public class Product
    {
        /// <summary>
        /// Name of product
        /// </summary>
        [DataMember]
        public string Name { get; private set; }

        /// <summary>
        /// Product purchase prise
        /// </summary>
        [DataMember]
        public double PurchasePrice { get; private set; }

        /// <summary>
        /// Quantity of this product
        /// </summary>
        [DataMember]
        public int Amount { get; private set; }

        /// <summary>
        /// Markup for product
        /// </summary>
        [DataMember]
        public int Markup { get; private set; }

        /// <summary>
        /// Actual product cost per unit
        /// </summary>
        public double Cost
        {
            get
            {
                return PurchasePrice * ((Markup / 100) + 1);
            }
            private set
            {
                Cost = value;
            }
        }

        /// <summary>
        /// Cost for all production
        /// </summary>
        public double FullCost
        {
            get
            {
                return Cost * Amount;
            }
            private set
            {
                Cost = value;
            }
        }

        /// <summary>
        /// Standart class constructor
        /// </summary>
        /// <param name="name">Product name</param>
        /// <param name="price">Product purchase price</param>
        /// <param name="markup">Markup for this product</param>
        /// <param name="amount">Quantity of this product</param>
        public Product(string name, double price, int markup, int amount)
        {
            Name = name;
            PurchasePrice = price;
            Markup = markup;
            Amount = amount;
        }

        /// <summary>
        /// Constructor for heirs
        /// </summary>
        /// <param name="name"></param>
        protected Product(string name) : this(name, 0.0, 0, 0)
        { }

        /// <summary>
        /// Standart empty class
        /// </summary>
        public Product() : this("Unknown")
        { }

        /// <summary>
        /// Method for comparing products
        /// </summary>
        /// <param name="product1">First product</param>
        /// <param name="product2">Second product</param>
        /// <returns>Bool value</returns>
        public static bool IsIdenticalProduct(Product product1, Product product2)
        {
            if ((String.Compare(product1.Name, product2.Name, true) == 0) && (product1.Markup == product2.Markup))
                return true;
            else
                return false;
        }

        /// <summary>
        /// An overloaded operator for adding two Product classes
        /// </summary>
        /// <param name="product1">First product</param>
        /// <param name="product2">Second product</param>
        /// <returns>New product class</returns>
        public static Product operator +(Product product1, Product product2)
        {
            double NewPurchasePrice = (product1.PurchasePrice * product1.Amount + product2.PurchasePrice * product2.Amount)
                        / (product1.Amount + product2.Amount);
            int NewAmount = product1.Amount + product2.Amount;

            /* 
             * This part of the code helps to determine if one of the products has a registered class, 
             * but is registered as a regular unregistered product
             */
            #region Danger!
            string product;
            if (product1.GetType().Name != typeof(Product).Name)
                product = product1.GetType().Name;
            else if (product2.GetType().Name != typeof(Product).Name)
                product = product2.GetType().Name;
            else
                product = "Product";
            #endregion

            return product switch
            {
                "Laptop" => new Laptop(NewPurchasePrice, product1.Markup, NewAmount),
                "Rubber" => new Rubber(NewPurchasePrice, product1.Markup, NewAmount),
                _ => new Product(product1.Name, NewPurchasePrice, product1.Markup, NewAmount),
            };
        }

        /// <summary>
        /// Overloaded subtraction operator
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="amount">Amount</param>
        /// <returns>New product with quantity deducted</returns>
        public static Product operator -(Product product, int amount)
        {
            return product.GetType().Name switch
            {
                "Laptop" => new Laptop(product.PurchasePrice, product.Markup, product.Amount - amount),
                "Rubber" => new Rubber(product.PurchasePrice, product.Markup, product.Amount - amount),
                _ => new Product(product.Name, product.PurchasePrice, product.Markup, product.Amount - amount),
            };
        }

        /// <summary>
        /// Explicit conversion of the product class to an int value. Return cost in coins
        /// </summary>
        /// <param name="product">Product</param>
        public static explicit operator int(Product product)
        {
            return (int)(product.Cost * 100);
        }

        /// <summary>
        /// Explicit conversion of the product class to an double value. Return cost in rubles
        /// </summary>
        /// <param name="product">Product</param>
        public static explicit operator double(Product product)
        {
            return product.Cost;
        }
    }
}
