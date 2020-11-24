using System.Collections.Generic;

namespace Bakery.Interfaces
{
    /// <summary>
    /// Interface for the converter class
    /// </summary>
    public interface IBakeryConverter
    {
        /// <summary>
        /// Method to convert file string into list of products
        /// </summary>
        /// <param name="strings">File strings</param>
        /// <returns>List of products</returns>
        List<Product> ConvertFileStrings(string[] strings);
    }
}
