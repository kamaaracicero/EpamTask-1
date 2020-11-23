using System;
using System.Collections.Generic;

namespace Bakery.Comparers
{
    internal class CaloriesComparer : IComparer<Product>
    {
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
