using System;
using Xunit;
using BinaryTree;

namespace Tests
{
    public class SerializationTest
    {
        [Fact]
        public void Test1()
        {
            Tree<int> tree = new Tree<int>();

            tree.Add(8);
            tree.Add(4);
            tree.Add(3);
            tree.Add(10);
            tree.SerializeTreeInXml();
        }
    }
}
