using System.Collections.Generic;
using Storehouse.Products;

namespace Storehouse.Interfaces
{
    /// <summary>
    /// Interface for Reader class
    /// </summary>
    public interface IStorageReader
    {
        /// <summary>
        /// Method for serializing product list to .json file
        /// </summary>
        /// <param name="path">The path to a readable file</param>
        /// <returns>List of products</returns>
        public List<Product> ReadJsonFile(string path);
    }
}
