using System;

namespace ChildrensTable.Figures
{
    /// <summary>
    /// Figure class exception
    /// </summary>
    internal class FigureException : Exception
    {
        /// <summary>
        /// Standart constructor
        /// </summary>
        /// <param name="msg">Message</param>
        public FigureException(string msg) : base (msg)
        { }
    }
}
