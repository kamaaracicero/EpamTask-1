using System;

namespace BinaryTree.Interfaces
{
    public interface ITreeSerializer
    {
        /// <summary>
        /// Serialize tree in file
        /// </summary>
        /// <param name="serType">Serializable type</param>
        /// <param name="tree">Binary tree</param>
        /// <param name="path">File path</param>
        void SerializeTree(Type serType, object tree, string path);

        /// <summary>
        /// Deserialize tree
        /// </summary>
        /// <param name="serType">Serializable type</param>
        /// <param name="path">File path</param>
        /// <returns>Binary tree</returns>
        object DeserializeTree(Type serType, string path);
    }
}
