using BinaryTree;
using BinaryTree.TreeDataType;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Arrange
            Tree<StudentTestRes> tree = new Tree<StudentTestRes>();

            // Act
            tree.Add(new StudentTestRes("Andrey", "Math", DateTime.Now.ToShortDateString(), 56));   // Root
            tree.Add(new StudentTestRes("Denis", "Math", DateTime.Now.ToShortTimeString(), 80));    // Root -> Right
            tree.Add(new StudentTestRes("Arthur", "Math", DateTime.Now.ToShortTimeString(), 100));  // Root -> Right -> Right
        }
    }
}
