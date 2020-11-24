using System.Collections.Generic;

namespace Bakery.Comparers
{
    /// <summary>
    /// Comparer class for sorting array by price
    /// </summary>
    internal class CostComparer : IComparer<Product>
    {
        /// <summary>
        /// Sorting method
        /// </summary>
        /// <param name="first">First product</param>
        /// <param name="second">Second product</param>
        /// <returns>Greater, less or equal</returns>
        public int Compare(Product first, Product second)
        {
            if (first.Cost > second.Cost)
                return -1;
            else if (first.Cost < second.Cost)
                return 1;
            else
                return 0;
        }
    }
}
