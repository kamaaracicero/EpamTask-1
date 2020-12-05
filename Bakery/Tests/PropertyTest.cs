using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Bakery;

namespace Tests
{
    /// <summary>
    /// Test class for Product properties
    /// </summary>
    [TestClass]
    public class PropertyTest
    {
        /// <summary>
		/// Class: Product
		/// Property check: Cost, FullCost, Calories
		/// Value: Bread, 2, 20, ListOfIngredients
		/// Exodus: True
		/// </summary>
        [TestMethod]
        public void Property_CheckCaloriesAndPrice()
        {
            // Arrange
            List<(string name, double cost, int calories)> ingredients = new List<(string name, double cost, int calories)>();
            ingredients.Add((name: "Flour", cost: 2, calories: 200));
            ingredients.Add((name: "Sugar", cost: 1, calories: 100));

            // Act
            Product product = new Product("Bread", 2, 20, ingredients);

            // Assert
            // Price with amount
            Assert.IsTrue(product.Cost.EqualTo(3.6, 0.001));
            // Full price
            Assert.IsTrue(product.FullCost.EqualTo(7.2, 0.001));
            // Calories
            Assert.AreEqual(300, product.Calories);
        }
    }
}
