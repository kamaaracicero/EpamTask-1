using BinaryTree;
using BinaryTree.TreeDataType;
using System;
using Xunit;

namespace Tests
{
    public class BinaryTreeTest
    {
        [Fact]
        public void AddMethod_Test_1()
        {
            // Arrange
            Tree<StudentTestRes> tree = new Tree<StudentTestRes>();

            // Act
            tree.Add(new StudentTestRes("Andrey", "Math", DateTime.Now.ToShortDateString(), 56));
            tree.Add(new StudentTestRes("Denis", "Math", DateTime.Now.ToShortTimeString(), 100));

            // Assert
            Assert.Equal("Andrey", tree.RootNode.Data.studentName);
            Assert.Equal("Denis", tree.RootNode.RightNode.Data.studentName);
        }

        [Fact]
        public void TreeBalance_Test_1()
        {
            // Arrange
            Tree<StudentTestRes> tree = new Tree<StudentTestRes>();

            // Act
            tree.Add(new StudentTestRes("Andrey", "Math", DateTime.Now.ToShortDateString(), 56));   // Root
            tree.Add(new StudentTestRes("Denis", "Math", DateTime.Now.ToShortTimeString(), 80));    // Root -> Right
            tree.Add(new StudentTestRes("Arthur", "Math", DateTime.Now.ToShortTimeString(), 100));  // Root -> Right -> Right
            // Tree balance. Root node now is Denis

            // Assert
            Assert.Equal("Denis", tree.RootNode.Data.studentName);
        }
    }
}
