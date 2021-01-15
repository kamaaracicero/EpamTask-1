using System;
using BinaryTree.Interfaces;

namespace BinaryTree.TreeAddictins
{
    internal class TreeBalancer<T> : ITreeBalancer<T> where T : IComparable
    {
        
        public int BranchHeight(TreeNode<T> startNode)
        {
            int sum = 0;
            if (startNode != null)
            {
                sum = 1 + Math.Max(BranchHeight(startNode.LeftNode), BranchHeight(startNode.RightNode));
            }
            return sum;
        }

        public int BranchBalance(TreeNode<T> startNode)
        {
            return BranchHeight(startNode.LeftNode) - BranchHeight(startNode.RightNode);
        }

        public TreeNode<T> LeftRotation(TreeNode<T> node)
        {
            TreeNode<T> newNode = node.RightNode;
            node.RightNode = newNode.LeftNode;
            newNode.LeftNode = node;
            return newNode;
        }

        public TreeNode<T> RightRotation(TreeNode<T> node)
        {
            TreeNode<T> newNode = node.LeftNode;
            node.LeftNode = newNode.RightNode;
            newNode.RightNode = node;
            return newNode;
        }

        public TreeNode<T> BalanceTree(TreeNode<T> rootNode)
        {
            TreeNode<T> newRoot = rootNode;

            if (BranchBalance(rootNode) == -2)
            {
                if (BranchBalance(rootNode.RightNode) > 0)
                    rootNode.RightNode = RightRotation(rootNode.RightNode);

                newRoot = LeftRotation(rootNode);
            }
            else if (BranchBalance(rootNode) == 0)
            {
                if (BranchBalance(rootNode.LeftNode) < 0)
                    rootNode.LeftNode = LeftRotation(rootNode.LeftNode);

                newRoot = RightRotation(rootNode);
            }

            return newRoot;
        }
    }
}
