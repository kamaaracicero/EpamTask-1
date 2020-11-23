using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Comparers
{
    class CostComparer : IComparer<Product>
    {
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
