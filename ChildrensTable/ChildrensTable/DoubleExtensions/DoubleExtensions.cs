using System;
using System.Collections.Generic;
using System.Text;

namespace ChildrensTable.DoubleExtensions
{
    public static class DoubleExtension
    {
        public static bool EqualTo(this double[] array1, double[] array2)
        {
            if (array1.Length == array2.Length)
            {
                for (int index = 0; index < array1.Length; index++)
                {
                    if (!array1[index].EqualToAnother(array2[index], 0.0001))
                        return false;
                }
                return true;
            }
            else
                return false;
        }

        public static bool EqualToAnother(this double value1, double value2, double epsilon)
        {
            return Math.Abs(value1 - value2) < epsilon;
        }
    }
}
