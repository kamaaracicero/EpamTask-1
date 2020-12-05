using System;
using Xunit;
using Storehouse;
using Storehouse.Products;

namespace TestsForStorage
{
    public class ProductsTest
    {
        [Fact]
        public void Test_Constructor_1()
        {
            Rubber rubber = new Rubber();

            Assert.Equal("Rubber", rubber.Name);
        }

        [Fact]
        public void Test_Constructor_2()
        {
            double price = 0.2;
            int markup = 20;
            int amount = 4;

            Rubber rubber = new Rubber(price, markup, amount);

            Assert.Equal(0.2, rubber.PurchasePrice);
            Assert.Equal(20, rubber.Markup);
            Assert.Equal(4, rubber.Amount);
        }

        [Fact]
        public void Test_Fold_1()
        {
            double price = 0.2;
            int markup = 20;
            int amount = 4;

            double _price = 0.2;
            int _markup = 20;
            int _amount = 2;

            Rubber rubber1 = new Rubber(price, markup, amount);
            Rubber rubber2 = new Rubber(_price, _markup, _amount);

            Product rubber = rubber1 + rubber2;

            Assert.Equal("Rubber", rubber.GetType().Name);
        }

        [Fact]
        public void Test_Fold_2()
        {
            Storage storage = new Storage();
            double price = 0.1;
            int markup = 15;
            int amount = 3;

            double _price = 0.2;
            int _markup = 20;
            int _amount = 2;

            storage.AddRegisteredProduct(RegisteredProducts.LAPTOP, price, markup, amount);
            storage.AddRegisteredProduct(RegisteredProducts.RUBBER, _price, _markup, _amount);

            bool flag = storage.TryFoldProducts(0, 1);

            Assert.False(flag);
        }

        [Fact]
        public void Test_Folding_1()
        {
            Storage storage = new Storage();

            storage.AddRegisteredProduct(RegisteredProducts.LAPTOP, 20, 1, 3);
            storage.AddRegisteredProduct(RegisteredProducts.RUBBER, 14, 1, 2);
            storage.AddRegisteredProduct(RegisteredProducts.LAPTOP, 48, 1, 4);
            storage.AddRegisteredProduct(RegisteredProducts.LAPTOP, 20, 1, 3);
            storage.AddRegisteredProduct(RegisteredProducts.RUBBER, 14, 1, 2);
            storage.AddRegisteredProduct(RegisteredProducts.RUBBER, 14, 1, 2);
            storage.AddRegisteredProduct(RegisteredProducts.LAPTOP, 48, 1, 4);

            storage.FoldProducts();

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

        [Fact]
        public void Test_Folding_2()
        {
            Storage storage = new Storage();
            storage.AddRegisteredProduct(RegisteredProducts.LAPTOP, 20, 1, 4);
            storage.AddProduct("Laptop", 20, 1, 2);

            storage.FoldProducts();

            Assert.Single(storage.products);
        }

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

        [Fact]
        public void Test_RemoveQuantity()
        {
            Storage storage = new Storage();

            storage.AddProduct("Bread", 4, 15, 2);

            storage.products[0] -= 2;

            Assert.Equal(0, storage.products[0].Amount);
        }
    }
}
