using System;
using System.Runtime.Serialization;

namespace BinaryTree
{
    /// <summary>
    /// Binary tree node
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract(IsReference = true)]
    public class TreeNode<T> where T : IComparable
    {
        /// <summary>
        /// Standart constructor
        /// </summary>
        /// <param name="data">Data</param>
        public TreeNode(T data)
        {
            Data = data;
        }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public TreeNode()
        { }

        /// <summary>
        /// Node data
        /// </summary>
        [DataMember]
        public T Data { get; set; }

        /// <summary>
        /// Parent node
        /// </summary>
        [DataMember]
        public TreeNode<T> Parent { get; set; }

        /// <summary>
        /// Left node
        /// </summary>
        [DataMember]
        public TreeNode<T> LeftNode { get; set; }

        /// <summary>
        /// Right node
        /// </summary>
        [DataMember]
        public TreeNode<T> RightNode { get; set; }

        /// <summary>
        /// Location of a node relative to its parent
        /// </summary>
        public Side? NodeSide => Parent == null ? (Side?)null : Parent.LeftNode == this ? Side.Left : Side.Right;

        public override string ToString() => Data.ToString();
    }
}
