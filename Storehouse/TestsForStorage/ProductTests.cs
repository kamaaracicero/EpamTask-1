using System;
using Xunit;
using Storehouse;
using Storehouse.Products;

namespace TestsForStorage
{
    /// <summary>
    /// Test class
    /// </summary>
    public class ProductsTest
    {
        /// <summary>
		/// Class: Product
		/// Method check: Constructor
		/// Exodus: Equal
		/// </summary>
        [Fact]
        public void Test_Constructor_1()
        {
            // Arrange
            // Act
            Rubber rubber = new Rubber();

            // Assert
            Assert.Equal("Rubber", rubber.Name);
        }

        /// <summary>
		/// Class: Product
		/// Method check: Constructor
		/// Exodus: Equal
		/// </summary>
        [Fact]
        public void Test_Constructor_2()
        {
            // Arrange
            double price = 0.2;
            int markup = 20;
            int amount = 4;

            // Act
            Rubber rubber = new Rubber(price, markup, amount);

            // Assert
            Assert.Equal(0.2, rubber.PurchasePrice);
            Assert.Equal(20, rubber.Markup);
            Assert.Equal(4, rubber.Amount);
        }

        /// <summary>
		/// Class: Product
		/// Method check: + operator
		/// Exodus: Equal
		/// </summary>
        [Fact]
        public void Test_Fold_1()
        {
            // Arrange
            double price = 0.2;
            int markup = 20;
            int amount = 4;

            double _price = 0.2;
            int _markup = 20;
            int _amount = 2;

            Rubber rubber1 = new Rubber(price, markup, amount);
            Rubber rubber2 = new Rubber(_price, _markup, _amount);

            // Act
            Product rubber = rubber1 + rubber2;

            // Assert
            Assert.Equal("Rubber", rubber.GetType().Name);
        }

        /// <summary>
		/// Class: Storage
		/// Method check: TryFoldProducts
		/// Exodus: False
		/// </summary>
        [Fact]
        public void Test_Fold_2()
        {
            // Arrange
            Storage storage = new Storage();
            double price = 0.1;
            int markup = 15;
            int amount = 3;

            double _price = 0.2;
            int _markup = 20;
            int _amount = 2;

            // Different markup
            storage.AddRegisteredProduct(RegisteredProducts.LAPTOP, price, markup, amount);
            storage.AddRegisteredProduct(RegisteredProducts.RUBBER, _price, _markup, _amount);

            // Act
            bool flag = storage.TryFoldProducts(0, 1);

            // Assert
            Assert.False(flag);
        }

        /// <summary>
		/// Class: Storage
		/// Method check: AddRegisteredProduct, FoldProducts, SaveProducts
		/// Exodus: Equal, 2 products
		/// </summary>
        [Fact]
        public void Test_Folding_1()
        {
            //Arrange
            Storage storage = new Storage();

            storage.AddRegisteredProduct(RegisteredProducts.LAPTOP, 20, 1, 3);
            storage.AddRegisteredProduct(RegisteredProducts.RUBBER, 14, 1, 2);
            storage.AddRegisteredProduct(RegisteredProducts.LAPTOP, 48, 1, 4);
            storage.AddRegisteredProduct(RegisteredProducts.LAPTOP, 20, 1, 3);
            storage.AddRegisteredProduct(RegisteredProducts.RUBBER, 14, 1, 2);
            storage.AddRegisteredProduct(RegisteredProducts.RUBBER, 14, 1, 2);
            storage.AddRegisteredProduct(RegisteredProducts.LAPTOP, 48, 1, 4);

            // Act
            storage.SaveProducts("data.json");
            storage.FoldProducts();

            // Assert
            Assert.Equal(36, storage.products[0].PurchasePrice);
            Assert.Equal(14, storage.products[0].Amount);
            Assert.Equal(1, storage.products[0].Markup);
            Assert.Equal("Laptop", storage.products[0].Name);

            Assert.Equal(14, storage.products[1].PurchasePrice);
            Assert.Equal(6, storage.products[1].Amount);
            Assert.Equal(1, storage.products[1].Markup);
            Assert.Equal("Rubber", storage.products[1].Name);

            Assert.Equal(2, storage.products.Count);
        }

        /// <summary>
		/// Class: Storage
		/// Method check: FoldProducts, AddProduct
		/// Exodus: 1 product
		/// </summary>
        [Fact]
        public void Test_Folding_2()
        {
            // Arrange
            Storage storage = new Storage();
            storage.AddRegisteredProduct(RegisteredProducts.LAPTOP, 20, 1, 4);
            storage.AddProduct("Laptop", 20, 1, 2);

            // Act
            storage.FoldProducts();

            // Assert
            Assert.Single(storage.products);
        }

        /// <summary>
		/// Class: Storage
		/// Method check: LoadProducts
		/// Exodus: Equal
		/// </summary>
        [Fact]
        public void Test_Reading()
        {
            Storage storage = new Storage();

            /*
             * .json File content
             * 
             * [{"__type":"Laptop:#Storehouse.Products","Amount":3,"Markup":1,"Name":"Laptop","PurchasePrice":20},
             * {"__type":"Rubber:#Storehouse.Products","Amount":2,"Markup":1,"Name":"Rubber","PurchasePrice":14},
             * {"__type":"Laptop:#Storehouse.Products","Amount":4,"Markup":1,"Name":"Laptop","PurchasePrice":48},
             * {"__type":"Laptop:#Storehouse.Products","Amount":3,"Markup":1,"Name":"Laptop","PurchasePrice":20},
             * {"__type":"Rubber:#Storehouse.Products","Amount":2,"Markup":1,"Name":"Rubber","PurchasePrice":14},
             * {"__type":"Rubber:#Storehouse.Products","Amount":2,"Markup":1,"Name":"Rubber","PurchasePrice":14},
             * {"__type":"Laptop:#Storehouse.Products","Amount":4,"Markup":1,"Name":"Laptop","PurchasePrice":48}]
             */

            storage.LoadProducts("data.json");

            Assert.Equal(7, storage.products.Count);
        }

        /// <summary>
		/// Class: Storage
		/// Method check: RemoveQuantityOfProduct
		/// Exodus: Equal
		/// </summary>
        [Fact]
        public void Test_RemoveQuantity_1()
        {
            // Arrange
            Storage storage = new Storage();
            storage.AddProduct("Bread", 4, 15, 2);

            // Act
            storage.RemoveQuantityOfProduct(0, 2);

            // Assert
            Assert.Equal(0, storage.products[0].Amount);
        }

        /// <summary>
		/// Class: Storage
		/// Method check: RemoveQuantityOfProduct
		/// Exodus: Equal
		/// </summary>
        [Fact]
        public void Test_RemoveQuantity_2()
        {
            // Arrange
            Storage storage = new Storage();
            storage.AddProduct("Bread", 1, 1, 2);
            storage.AddProduct("Bread", 1, 1, 3);
            storage.AddProduct("Bread", 1, 1, 2);

            // Act
            storage.RemoveQuantityOfProduct("bread", 4, true);

            // Assert
            Assert.Equal(3, storage.products[0].Amount);
        }

        /// <summary>
		/// Class: Storage
		/// Method check: RemoveQuantityOfProduct
		/// Exodus: Equal
		/// </summary>
        [Fact]
        public void Test_RemoveQuantity_3()
        {
            // Arrange
            Storage storage = new Storage();
            storage.AddProduct("Bread", 1, 1, 2);
            storage.AddProduct("Bread", 1, 1, 3);
            storage.AddProduct("Bread", 1, 1, 2);

            // Act
            storage.RemoveQuantityOfProduct("bread", 4);

            // Assert
            Assert.Equal(-2, storage.products[0].Amount);
        }

        /// <summary>
		/// Class: Product
		/// Method check: Cast
		/// Exodus: Equal
		/// </summary>
        [Fact]
        public void Test_ConvertProductToInt()
        {
            // Arrange
            Storage storage = new Storage();
            storage.AddProduct("Cheese", 21.6, 4, 2);

            // Act
            int cost = (int)storage.products[0];

            // Assert
            Assert.Equal(2160, cost);
        }

        /// <summary>
		/// Class: Product
		/// Method check: Cast
		/// Exodus:Equal
		/// </summary>
        [Fact]
        public void Test_ConvertProductToDouble()
        {
            // Arrange
            Storage storage = new Storage();
            storage.AddProduct("Cheese", 21.6, 4, 2);

            // Act
            double cost = (double)storage.products[0];

            // Assert
            Assert.Equal(21.6, cost);
        }

        /// <summary>
		/// Class: Product
		/// Method check: Cast
		/// Exodus: True
		/// </summary>
        [Fact]
        public void Test_Cast()
        {
            // Arrange
            // Act
            Laptop laptop = (Laptop)new Rubber(20, 20, 2);

            // Assert
            Assert.Equal("Laptop", laptop.Name);
            Assert.Equal(20, laptop.Cost);
            Assert.Equal("Laptop", laptop.GetType().Name);
        }
    }
}
