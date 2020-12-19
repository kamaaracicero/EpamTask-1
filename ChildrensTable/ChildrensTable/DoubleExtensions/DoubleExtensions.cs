using System;
using System.Collections.Generic;
using System.Text;

namespace ChildrensTable.DoubleExtensions
{
    /// <summary>
    /// Double extension class
    /// </summary>
    public static class DoubleExtension
    {
        /// <summary>
        /// Compares 2 double arrays
        /// </summary>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <returns>true if they are equal; otherwise, false</returns>
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

        /// <summary>
        /// compares 2 double values with the specified precision
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="epsilon">Precision</param>
        /// <returns></returns>
        public static bool EqualToAnother(this double value1, double value2, double epsilon)
        {
            return Math.Abs(value1 - value2) < epsilon;
        }
    }
}
