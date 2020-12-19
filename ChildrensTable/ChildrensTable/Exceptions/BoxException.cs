using System;
using System.Collections.Generic;
using System.Text;

namespace ChildrensTable
{
    /// <summary>
    /// Box class exception
    /// </summary>
    public class BoxException : Exception
    {
        /// <summary>
        /// Standart constructor
        /// </summary>
        /// <param name="mes"></param>
        public BoxException(string mes)
            : base (mes)
        { }
    }
}
