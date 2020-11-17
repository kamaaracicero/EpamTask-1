using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bakery;

namespace Tests
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestMethod()
        {
            Bakery.Bakery bakery = new Bakery.Bakery(new Reader());
        }
    }
}
