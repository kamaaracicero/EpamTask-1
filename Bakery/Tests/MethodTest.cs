using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Bakery;

namespace Tests
{
	#region File bakery.txt content
	/*
    Bread Amount:7 Markup:20%
		Water 0,5kg 0cal 0,5$
		Yeast 0,005kg 4000cal 0,07$
		Flour 0,32kg 1164cal 0,8$
		Oil 0,03kg 265cal 0,4$
		Sugar 0,005kg 20cal 0,05$
		Salt 0,003kg 0cal 0,02$
	Gingerbread Amount:5 Markup:32%
		Sugar 0,37kg 1431cal 0,3$ 
		Water 0,1kg 0cal 0,1$
		Flour 0,48kg 1748cal 1$
		Soda 0,002kg 0cal 0,1$
		Butter 0,05kg 360cal 0,2$
		Egg 0,06kg 93cal 0,08$
	Terra Amount:2 Markup:12%
		Sugar 0,37kg 2000cal 1$ 
		Water 0,1kg 3000cal 2$
		Flour 0,48kg 4000cal 3$
	Ricca Amount:6 Markup:70%
		Sugar 0,37kg 1000cal 4$ 
		Water 0,1kg 0cal 5$
		Flour 0,48kg 500cal 6$
	Cookies Amount:2 Markup:10%
		Sugar 0,37kg 0cal 0,1$ 
		Water 0,1kg 0cal 0,1$
		Flour 0,48kg 0cal 0,1$
	*/
	#endregion

	/// <summary>
	/// Test class for Bakery methods
	/// </summary>
	[TestClass]
    public class MethodTest
    {
		/// <summary>
		/// Class: Bakery
		/// Method check: GetClonedListOfProducts
		/// Type of sort: By calories
		/// Value: bakery.txt
		/// Exodus: True
		/// </summary>
		[TestMethod]
        public void  Method_TestSortByCalories()
		{
			// Arrange
			Bakery.Bakery bakery = new Bakery.Bakery();
			bakery.InputDataFromFile("bakery.txt");

			// Act
			List<Product> products = bakery.GetClonedListOfProduct(Bakery.Comparers.TypeOfSort.ByCalories);

			// The product "Terra" has the highest calorie count
			// and the lowest indicator has the product "Cookies"

			// Assert
			Assert.AreEqual("Terra", products[0].Name);
			Assert.AreEqual("Cookies", products[products.Count - 1].Name);
		}

		/// <summary>
		/// Class: Bakery
		/// Method check: GetClonedListOfProducts
		/// Type of sort: By price
		/// Value: bakery.txt
		/// Exodus: True
		/// </summary>
		[TestMethod]
		public void Method_TestSortByCost()
		{
			// Arrange
			Bakery.Bakery bakery = new Bakery.Bakery();
			bakery.InputDataFromFile("bakery.txt");

			// Act
			List<Product> products = bakery.GetClonedListOfProduct(Bakery.Comparers.TypeOfSort.ByCost);

			// The product "Ricca" has the highest price
			// and the lowest indicator has the product "Cookies"

			// Assert
			Assert.AreEqual("Ricca", products[0].Name);
			Assert.AreEqual("Cookies", products[products.Count - 1].Name);
		}

		/// <summary>
		/// Class: Bakery
		/// Method check: FindProducts
		/// Value: bakery.txt
		/// Exodus: True
		/// </summary>
		[TestMethod]
		public void Method_FindProductsByCostAndCalories()
		{
			// Arrange
			Bakery.Bakery bakery = new Bakery.Bakery();
			bakery.InputDataFromFile("bakery.txt");

			//Act
			// Bread price and calories
			string[] matches = bakery.FindProducts(2.208, 5449);

			// Assert
			Assert.AreEqual("Bread", matches[0]);
        }

		/// <summary>
		/// Class: Bakery
		/// Method check: FindProducts
		/// Value: bakery.txt
		/// Exodus: True
		/// </summary>
		[TestMethod]
		public void Method_FindProductsByIngrVolume()
		{
			// Arrange
			Bakery.Bakery bakery = new Bakery.Bakery();
			bakery.InputDataFromFile("bakery.txt");

			// Act
			// I find all products in which the amount of flour used is more than 1500 calories
			string[] matches = bakery.FindProducts("Flour", 1500);
			
			// Assert
			// First product must be Gingerbread
			Assert.AreEqual("Gingerbread", matches[0]);
			// Second product must be Terra
			Assert.AreEqual("Terra", matches[1]);
		}

		/// <summary>
		/// Class: Bakery
		/// Method check: FindNumberOfProducts
		/// Value: bakery.txt
		/// Exodus: True
		/// </summary>
		[TestMethod]
		public void Method_FindCountOfProductsByIngrNumber()
		{
			// Arrange
			Bakery.Bakery bakery = new Bakery.Bakery();
			bakery.InputDataFromFile("bakery.txt");

			// Act
			int number = bakery.FindNumberOfProducts(3);

			// Assert
			Assert.AreEqual(2, number);
        }

	}
}
