using System.Collections.Generic;
using System.IO;

namespace Bakery.Interfaces
{
    /// <summary>
    /// Interface for the saver class
    /// </summary>
    public interface IBakerySaver
    {
        /// <summary>
        /// Method to save list of products
        /// </summary>
        /// <param name="products">List of products to save</param>
        /// <param name="file">File where to save all this</param>
        /// <param name="handler">Message event</param>
        void Save(List<Product> products, FileStream file, Bakery.MessageHandler handler);
    }
}
