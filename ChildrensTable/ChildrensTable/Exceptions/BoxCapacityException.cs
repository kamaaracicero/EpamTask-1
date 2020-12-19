using System;

namespace ChildrensTable
{
    /// <summary>
    /// Exception for box congestion
    /// </summary>
    internal class BoxCapacityException : Exception
    {
        /// <summary>
        /// Standart constructor
        /// </summary>
        /// <param name="message"></param>
        public BoxCapacityException()
            : base ("Box is full!")
        { }
    }
}
