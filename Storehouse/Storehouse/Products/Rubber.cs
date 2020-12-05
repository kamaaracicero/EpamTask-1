using System.Runtime.Serialization;

namespace Storehouse.Products
{
    /// <summary>
    /// Product rubber class
    /// </summary>
    [DataContract]
    public class Rubber : Product
    {
        /// <summary>
        /// Standart constructor
        /// </summary>
        /// <param name="price">Purchase price</param>
        /// <param name="amount">Amount</param>
        public Rubber(double price, int amount)
            : base ("Rubber", price, 30, amount)
        { }

        /// <summary>
        /// Standart empty constructor
        /// </summary>
        public Rubber() : base("Rubber")
        { }

        /// <summary>
        /// Converting from Laptop to Rubber
        /// </summary>
        /// <param name="laptop">Reference to the Laptop class</param>
        public static explicit operator Rubber(Laptop laptop)
        {
            return new Rubber(laptop.PurchasePrice, laptop.Amount);
        }
    }
}
