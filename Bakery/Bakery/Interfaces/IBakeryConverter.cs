using System.Collections.Generic;

namespace Bakery.Interfaces
{
    public interface IBakeryConverter
    {
        List<Product> ConvertFileStrings(string[] strings);
    }
}
