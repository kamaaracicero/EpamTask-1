using System.IO;

namespace Bakery.Interfaces
{
    /// <summary>
    /// Interface for the reader class
    /// </summary>
    public interface IBakeryReader
    {
        /// <summary>
        /// Method to convert file to strings
        /// </summary>
        /// <param name="file">File</param>
        /// <returns>Array of file strings</returns>
        string[] ReadFile(FileStream file);
    }
}
