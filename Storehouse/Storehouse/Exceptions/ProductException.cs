using System;

namespace Storehouse.Products
{
    /// <summary>
    /// Product exception
    /// </summary>
    public class ProductException : Exception
    {
        /// <summary>
        /// Standart constructor
        /// </summary>
        /// <param name="message">Message</param>
        public ProductException(string message)
            : base(message)
        { }
    }
}
