using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bakery;
using System.Collections.Generic;

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
	Kiticat Amount:2 Markup:10%
		Sugar 0,37kg 0cal 0,1$ 
		Water 0,1kg 0cal 0,1$
		Flour 0,48kg 0cal 0,1$
	*/
	#endregion

	/// <summary>
	/// Test class for input methods
	/// </summary>
	[TestClass]
	public class InputTest
	{
		/// <summary>
		/// Class: Bakery
		/// Method check: InputDataFromFile
		/// Value: bakery.txt
		/// Exodus: True
		/// </summary>
		[TestMethod]
		public void Input_CheckFirstProduct_Name()
		{
			/// Arrange
			Bakery.Bakery bakery = new Bakery.Bakery();

			// Act
			bakery.InputDataFromFile("bakery.txt");
			Product product = bakery.GetProductByIndex(0);

			// Assert
			Assert.AreEqual("Bread", product.Name);
			Assert.AreNotEqual("Gingerbread", product.Name);
		}

		/// <summary>
		/// Class: Bakery
		/// Method check: InputDataFromFile
		/// Value: bakery.txt
		/// Exodus: True
		/// </summary>
		[TestMethod]
		public void Input_CheckFirstProduct_IngredientCount()
		{
			// Arrange
			Bakery.Bakery bakery = new Bakery.Bakery();

			// Act
			bakery.InputDataFromFile("bakery.txt");
			Product product = bakery.GetProductByIndex(0);

			// Assert
			Assert.AreEqual(6, product.NumberOfIngredients);
        }

		/// <summary>
		/// Class: Bakery
		/// Method check: InputDataFromFile
		/// Value: bakery.txt
		/// Exodus: True
		/// </summary>
		[TestMethod]
		public void Input_CheckProducts_Count()
		{
			// Arrange
			Bakery.Bakery bakery = new Bakery.Bakery();

			// Act
			bakery.InputDataFromFile("bakery.txt");
			List<Product> products = bakery.GetClonedListOfProduct(Bakery.Comparers.TypeOfSort.ByCalories);

			// Assert
			Assert.AreEqual(5, products.Count);
        }
    }
}
