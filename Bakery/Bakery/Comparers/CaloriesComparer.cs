using System.Collections.Generic;

namespace Bakery.Comparers
{
    /// <summary>
    /// Comparer class for sorting array by calories
    /// </summary>
    internal class CaloriesComparer : IComparer<Product>
    {
        /// <summary>
        /// Sorting method
        /// </summary>
        /// <param name="first">First product</param>
        /// <param name="second">Second product</param>
        /// <returns>Greater, less or equal</returns>
        public int Compare(Product first, Product second)
        {
            if (first.Calories > second.Calories)
                return -1;
            else if (first.Calories < second.Calories)
                return 1;
            else
                return 0;
        }
    }
}
