using System;

namespace ChildrensTable.Figures
{
    /// <summary>
    /// Exception for impossibility of painting
    /// </summary>
    public class PaintException : Exception
    {
        /// <summary>
        /// Standart constructor
        /// </summary>
        public PaintException(string msg) 
            : base (msg)
        { }
    }
}
