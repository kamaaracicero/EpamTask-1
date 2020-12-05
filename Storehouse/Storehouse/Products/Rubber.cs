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
        /// <param name="markup">Product not standart markup</param>
        /// <param name="amount">Amount</param>
        public Rubber(double price, int markup, int amount)
            : base("Rubber", price, markup, amount)
        { }

        /// <summary>
        /// Standart constructor
        /// </summary>
        /// <param name="price">Purchase price</param>
        /// <param name="amount">Amount</param>
        public Rubber(double price, int amount) : this(price, 30, amount)
        { }

        /// <summary>
        /// Standart empty constructor
        /// </summary>
        public Rubber() : base("Rubber")
        { }
        
        /// <summary>
        /// Converting from Laptop to Rubberzz
        /// </summary>
        /// <param name="rubber">Reference to the Laptop class</param>
        public static explicit operator Laptop(Rubber rubber)
        {
            return new Laptop(rubber.PurchasePrice, rubber.Markup, rubber.Amount);
        }
    }
}
