using System;
using Storehouse.Interfaces;
using Storehouse.Products;
using Storehouse.StandardClasses;
using System.Collections.Generic;
using System.Text;

namespace Storehouse
{
    /// <summary>
    /// Storage class
    /// </summary>
    public class Storage
    {
        /// <summary>
        /// File reader
        /// </summary>
        private readonly IStorageReader reader;

        /// <summary>
        /// File saver
        /// </summary>
        private readonly IStorageSaver saver;

        /// <summary>
        /// List of products
        /// </summary>
        public List<Product> products = new List<Product>();

        public Storage(IStorageReader reader, IStorageSaver saver)
        {
            this.reader = reader;
            this.saver = saver;
        }

        /// <summary>
        /// Standart empty constructor
        /// </summary>
        public Storage() : this (new StandartReader(), new StandartSaver())
        { }

        /// <summary>
        /// Method for saving a list of products in a .json file
        /// </summary>
        /// <param name="path">File path</param>
        public void SaveProducts(string path)
        {
            saver.SaveInJson(products, path);
        }

        /// <summary>
        /// Method for reading a list of products from .json file
        /// </summary>
        /// <param name="path">File path</param>
        public void LoadProducts(string path)
        {
            products = reader.ReadJsonFile(path);
        }

        /// <summary>
        /// The method of folding all the same products in a list
        /// </summary>
        public void FoldProducts()
        {
            for (int indexF = 0; indexF < products.Count; indexF++)
            {
                for (int indexS = indexF + 1; indexS < products.Count; indexS++)
                {
                    if(Product.IsIdenticalProduct(products[indexF], products[indexS]))
                    {
                        products[indexF] += products[indexS];
                        products.RemoveAt(indexS);
                        indexS--;
                    }
                }
            }
        }

        /// <summary>
        /// The method of adding two products with specific indexes
        /// </summary>
        /// <param name="firstIndex">First product index</param>
        /// <param name="secondIndex">Second product index</param>
        /// <returns>Was this operation successful or not</returns>
        public bool TryFoldProducts(int firstIndex, int secondIndex)
        {
            if (Product.IsIdenticalProduct(products[firstIndex], products[secondIndex]))
            {
                products[firstIndex] += products[secondIndex];
                products.RemoveAt(secondIndex);
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Method for adding registered product to the list
        /// </summary>
        /// <param name="name">Product name</param>
        /// <param name="price">Purchase price</param>
        /// <param name="amount">Number of product</param>
        public void AddRegisteredProduct(RegisteredProducts product, double price, int amount)
        {
            switch(product)
            {
                case RegisteredProducts.LAPTOP:
                    products.Add(new Laptop(price, amount));
                    break;
                case RegisteredProducts.RUBBER:
                    products.Add(new Rubber(price, amount));
                    break;
            }
        }

        /// <summary>
        /// Method for adding registered product to the list with not standart markup
        /// </summary>
        /// <param name="name">Product name</param>
        /// <param name="price">Purchase price</param>
        /// <param name="markup">Product markup</param>
        /// <param name="amount">Number of product</param>
        public void AddRegisteredProduct(RegisteredProducts product, double price, int markup, int amount)
        {
            switch (product)
            {
                case RegisteredProducts.LAPTOP:
                    products.Add(new Laptop(price, markup, amount));
                    break;
                case RegisteredProducts.RUBBER:
                    products.Add(new Rubber(price, markup, amount));
                    break;
            }
        }

        /// <summary>
        /// Method for adding unregistered product
        /// </summary>
        /// <param name="name">Product name</param>
        /// <param name="price">Purchase price</param>
        /// <param name="markup">Product markup</param>
        /// <param name="amount">Number of product</param>
        public void AddProduct(string name, double price, int markup, int amount)
        {
            products.Add(new Product(name, price, markup, amount));
        }

        /// <summary>
        /// Remove a specific quantity from a product with a given index
        /// </summary>
        /// <param name="index">Product index</param>
        /// <param name="amount">Removable quantity</param>
        public void RemoveQuantityOfProduct(int index, int amount)
        {
            products[index] -= amount;
        }

        /// <summary>
        /// Remove a specific quantity from a product with a given name
        /// </summary>
        /// <param name="name">Product name</param>
        /// <param name="amount">Removable quantity</param>
        /// <param name="flag">If true - fold all products. False - without folding</param>
        public void RemoveQuantityOfProduct(string name, int amount, bool flag = false)
        {
            if (flag)
            {
                FoldProducts();
                for (int index = 0; index < products.Count; index++)
                {
                    if (products[index].Name.ToLower() == name.ToLower())
                        products[index] -= amount;
                }
            }
            else
            {
                bool _flag = true;
                int index = 0;
                while(_flag)
                {
                    if (products[index].Name.ToLower() == name.ToLower())
                    {
                        products[index] -= amount;
                        _flag = false;
                    }
                    index++;
                }
            }
        }

        /// <summary>
        /// Return product cost in coins
        /// </summary>
        /// <param name="index">Product index</param>
        /// <returns>Cost</returns>
        public int GetCostOfProductInCoins(int index)
        {
            return (int)products[index];
        }

        /// <summary>
        /// Return product cost in rubles
        /// </summary>
        /// <param name="index">Product index</param>
        /// <returns>Cost</returns>
        public double GetCostOfProductInRub(int index)
        {
            return (double)products[index];
        }

        /// <summary>
        /// Override method ToString()
        /// </summary>
        /// <returns>Products in string</returns>
        public override string ToString()
        {
            StringBuilder @string = new StringBuilder();
            foreach(Product product in products)
            {
                @string.Append(product.Name + "\n\tPrice: " + product.PurchasePrice + "\n\tAmount: " + product.Amount + "\n\tMarkup: " + product.Markup + "\n");
            }
            return @string.ToString();
        }

        /// <summary>
        /// Override method Equals()
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>Bool value</returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// Override method GetHashCode()
        /// </summary>
        /// <returns>Int value</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
