using System.Collections.Generic;

namespace Bakery.Comparers
{
    /// <summary>
    /// Comparer class for sorting array by total price
    /// </summary>
    internal class TotalCostComparer : IComparer<Product>
    {
        /// <summary>
        /// Sorting method
        /// </summary>
        /// <param name="first">First product</param>
        /// <param name="second">Second product</param>
        /// <returns>Greater, less or equal</returns>
        public int Compare(Product first, Product second)
        {
            if (first.FullCost > second.FullCost)
                return -1;
            else if (first.FullCost < second.FullCost)
                return 1;
            else
                return 0;
        }
    }
}
