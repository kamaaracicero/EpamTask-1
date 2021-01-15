using System;
using System.Text;

namespace BinaryTree.Interfaces
{
    public interface ITreeBalancer<T> where T : IComparable
    {
        /// <summary>
        /// Branch height
        /// </summary>
        /// <param name="startNode">Start node</param>
        /// <returns>Height</returns>
        int BranchHeight(TreeNode<T> startNode);

        /// <summary>
        /// Branch balance coefficient
        /// </summary>
        /// <param name="startNode">Branch start note</param>
        /// <returns>Coefficient</returns>
        int BranchBalance(TreeNode<T> startNode);

        /// <summary>
        /// Turn branch from right to left
        /// </summary>
        /// <param name="node">Branch start node</param>
        /// <returns>New rotated branch</returns>
        TreeNode<T> LeftRotation(TreeNode<T> node);

        /// <summary>
        /// Turn branch from left to right
        /// </summary>
        /// <param name="node">Branch start node</param>
        /// <returns>New rotated branch</returns>
        TreeNode<T> RightRotation(TreeNode<T> node);

        /// <summary>
        /// Balance tree
        /// </summary>
        /// <param name="rootNode">Root tree node</param>
        /// <returns>New balanced tree</returns>
        TreeNode<T> BalanceTree(TreeNode<T> rootNode);
    }
}
