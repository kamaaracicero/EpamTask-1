using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery
{
    public static class DoubleExtensions
    {
        public static bool EqualTo(this double value1, double value2, double epsilon)
        {
            return Math.Abs(value1 - value2) < epsilon;
        }
    }
}
