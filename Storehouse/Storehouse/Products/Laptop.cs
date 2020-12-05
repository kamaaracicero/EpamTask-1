using System.Runtime.Serialization;

namespace Storehouse.Products
{
    /// <summary>
    /// Product laptop class
    /// </summary>
    [DataContract]
    public class Laptop : Product
    {
        /// <summary>
        /// Standart constructor. Create product with not standart markup
        /// </summary>
        /// <param name="price">Purchase price</param>
        /// <param name="markup">Product not standart markup</param>
        /// <param name="amount">Amount</param>
        public Laptop(double price, int markup, int amount)
            : base("Laptop", price, markup, amount)
        { }

        /// <summary>
        /// Standart constructor. Create product with standart markup
        /// </summary>
        /// <param name="price">Purchase price</param>
        /// <param name="amount">Amount</param>
        public Laptop(double price, int amount) : this(price, 50, amount)
        { }

        /// <summary>
        /// Standart empty constructor
        /// </summary>
        public Laptop() : base("Laptop")
        { }

        /// <summary>
        /// Converting from Rubber to Laptop
        /// </summary>
        /// <param name="rubber">Reference to the Rubber class</param>
        public static explicit operator Laptop(Rubber rubber)
        {
            return new Laptop(rubber.PurchasePrice, rubber.Markup, rubber.Amount);
        }
    }
}
