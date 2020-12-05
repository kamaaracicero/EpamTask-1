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

            Assert.Equal("Unknown", rubber.Name);
        }

        [Fact]
        public void Test_Constructor_2()
        {
            string name = "rubber";
            double price = 0.2;
            int markup = 20;
            int amount = 4;

            Rubber rubber = new Rubber(name, price, markup, amount);

            Assert.Equal("rubber", rubber.Name);
            Assert.Equal(0.2, rubber.PurchasePrice);
            Assert.Equal(20, rubber.Markup);
            Assert.Equal(4, rubber.Amount);
        }

        [Fact]
        public void Test_Fold()
        {
            string name = "rubber";
            double price = 0.2;
            int markup = 20;
            int amount = 4;

            string _name = "rubber";
            double _price = 0.2;
            int _markup = 20;
            int _amount = 2;

            Rubber rubber1 = new Rubber(name, price, markup, amount);
            Rubber rubber2 = new Rubber(_name, _price, _markup, _amount);

            rubber1.Fold(rubber1, rubber2);
        }
    }
}
