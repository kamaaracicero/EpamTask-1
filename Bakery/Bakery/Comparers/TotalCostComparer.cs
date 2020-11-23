using System.Collections.Generic;

namespace Bakery.Comparers
{
    internal class TotalCostComparer : IComparer<Product>
    {
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
