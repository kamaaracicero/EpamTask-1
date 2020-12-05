using Storehouse.Products;
using System.Collections.Generic;

namespace Storehouse.Interfaces
{
    /// <summary>
    /// Interface for Reader class
    /// </summary>
    public interface IStorageSaver
    {
        /// <summary>
        /// Method for serializing product list to .json file
        /// </summary>
        /// <param name="products">List of products</param>
        /// <param name="path">File path</param>
        public void SaveInJson(List<Product> products, string path);
    }
}
