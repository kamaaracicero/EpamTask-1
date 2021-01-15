using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BinaryTree
{
    public class Tree<T> where T : IComparable
    {
        private TreeSerializer serializer = new TreeSerializer();

        private readonly int[,] turn_right = 
        {
            { -1, -1, +1, +1 },
            { -1, +0, +1, +0},
            { -1, +1, +2, +0},
            { -2, -1, +0, +0},
            { -2, -2, +0, +1},
            { -2, +0, +1, -1}
        };

        private readonly int[,] turn_left =
        {
            { +1, -1, -2, +0},
            { +1, +0, -1, +0},
            { +1, +1, -1, -1},
            { +2, +0, -1, +1},
            { +2, +1, +0, +0},
            { +2, +2, +0, -1}
        };

        Func<int> MathHandler;

        /// <summary>
        /// Root node
        /// </summary>
        public TreeNode<T> RootNode { get; set; }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public Tree()
        { }

        /// <summary>
        /// Adding a new node to a binary tree
        /// </summary>
        /// <param name="node">New node</param>
        /// <param name="currentNode">Current node</param>
        public void Add(TreeNode<T> node, TreeNode<T> currentNode = null)
        {
            if (RootNode == null)
            {
                node.Parent = null;
                RootNode = node;
                return;
            }
            else
            {
                currentNode ??= RootNode;
                node.Parent = currentNode;
                int result;
                if ((result = node.Data.CompareTo(currentNode.Data)) == 0)
                    return;
                else if (result < 0)
                {
                    if (currentNode.LeftNode == null)
                        currentNode.LeftNode = node;
                    else
                        Add(node, currentNode.LeftNode);
                }
                else
                {
                    if (currentNode.RightNode == null)
                        currentNode.RightNode = node;
                    else
                        Add(node, currentNode.RightNode);
                }
            }
        }

        /// <summary>
        /// Add data to tree
        /// </summary>
        /// <param name="data">Data</param>
        public void Add(T data)
        {
            Add(new TreeNode<T>(data));
        }

        /// <summary>
        /// Find node in binary tree
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="startNode">Start node</param>
        /// <returns>Node</returns>
        public TreeNode<T> FindNode(T data, TreeNode<T> startNode = null)
        {
            if (RootNode != null)
            {
                startNode ??= RootNode;
                int result;
                if ((result = data.CompareTo(startNode.Data)) == 0)
                    return startNode;
                else
                    if (result < 0)
                        if (startNode.LeftNode == null)
                            return null;
                        else
                            return FindNode(data, startNode.LeftNode);
                    else
                        if (startNode.RightNode == null)
                            return null;
                        else
                            return FindNode(data, startNode.RightNode);
            }
            else
                throw new Exception("Binary tree is empty");
        }

        /// <summary>
        /// Delete node from tree
        /// </summary>
        /// <param name="node">Node</param>
        public void DeleteNode(TreeNode<T> node)
        {
            if (node == null)
                return;

            var curSide = node.NodeSide;
            if (node.LeftNode == null && node.RightNode == null)
            {
                if (curSide == Side.Left)
                    node.Parent.LeftNode = null;
                else
                    node.Parent.RightNode = null;
            }
            else if (node.LeftNode == null)
            {
                if (curSide == Side.Left)
                    node.Parent.LeftNode = node.RightNode;
                else
                    node.Parent.RightNode = node.RightNode;

                node.RightNode.Parent = node.Parent;
            }
            else if (node.RightNode == null)
            {
                if (curSide == Side.Left)
                    node.Parent.LeftNode = node.LeftNode;
                else
                    node.Parent.RightNode = node.LeftNode;

                node.LeftNode.Parent = node.Parent;
            }
            else
                switch (curSide)
                {
                    case Side.Left:
                        node.Parent.LeftNode = node.RightNode;
                        node.RightNode.Parent = node.Parent;
                        Add(node.LeftNode, node.RightNode);
                        break;
                    case Side.Right:
                        node.Parent.RightNode = node.RightNode;
                        node.RightNode.Parent = node.Parent;
                        Add(node.LeftNode, node.RightNode);
                        break;
                    default:
                        var _Left = node.LeftNode;
                        var _RightLeft = node.RightNode.LeftNode;
                        var _RightRight = node.RightNode.RightNode;
                        node.Data = node.RightNode.Data;
                        node.RightNode = _RightRight;
                        node.LeftNode = _RightLeft;
                        Add(_Left, node);
                        break;
                }
        }

        /// <summary>
        /// Delete node from tree
        /// </summary>
        /// <param name="data">Data</param>
        public void DeleteNode(T data) => DeleteNode(FindNode(data));

        /// <summary>
        /// Serialize tree in xml file
        /// </summary>
        public void SerializeTreeInXml()
        {
            serializer.SerializeTree(typeof(TreeNode<T>), RootNode);
        }

        /// <summary>
        /// Convert binary tree in list
        /// </summary>
        /// <param name="list">Ref list</param>
        /// <param name="startNode">StartNode</param>
        public void ToList(ref List<T> list, TreeNode<T> startNode)
        {
            list.Add(startNode.Data);
            if (startNode.LeftNode != null)
                ToList(ref list, startNode.LeftNode);
            if (startNode.RightNode != null)
                ToList(ref list, startNode.RightNode);
        }

        /// <summary>
        /// Convert binary tree in list
        /// </summary>
        /// <param name="list">Ref list</param>
        public void ToList(ref List<T> list) => ToList(ref list, RootNode);


        public void BalanceTree()
        {
            

        }


        private TreeNode<T> TurnBranchRight(TreeNode<T> node)
        {
            TreeNode<T> nodeLeft = node.LeftNode;
            TreeNode<T> nodeLeftRight = nodeLeft.RightNode;

            nodeLeft.RightNode = node;
            node.LeftNode = nodeLeftRight;

            for (int n = 0; n < 6; n++)
                if (turn_right[n,0] == node.Balance && turn_right[n,1] == nodeLeft.Balance)
                {
                    nodeLeft.Balance = turn_right[n, 2];
                    node.Balance = turn_right[n, 3];
                    break;
                }
            return nodeLeft;
        }

        private TreeNode<T> TurnBranchLeft(TreeNode<T> node)
        {
            TreeNode<T> nodeRight = node.RightNode;
            TreeNode<T> nodeRightLeft = nodeRight.LeftNode;

            nodeRight.LeftNode = node;
            node.RightNode = nodeRightLeft;

            for (int n = 0; n < 6; n++)
                if (turn_left[n,0]==node.Balance && turn_left[n,1]==nodeRight.Balance)
                {
                    nodeRight.Balance = turn_left[n, 2];
                    node.Balance = turn_left[n, 3];
                    break;
                }
            return nodeRight;
        }

        private bool BalanceInsert(TreeNode<T> startNode)
        {
            TreeNode<T> node = startNode;

            if (node.Balance > 1)
            {
                if (node.RightNode.Balance < 0)
                    node.RightNode = TurnBranchRight(node.RightNode);
                startNode = TurnBranchLeft(node);
                return true;
            }
            if (node.Balance < -1)
            {
                if (node.LeftNode.Balance > 0) 
                    node.LeftNode = TurnBranchLeft(node.LeftNode);
                startNode = TurnBranchRight(node);
                return true;
            }
            return false;
        }


        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
