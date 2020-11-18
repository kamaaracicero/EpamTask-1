using System.Collections.Generic;

namespace Bakery.Interfaces
{
    public interface IBakerySaver
    {
        void Save(List<Product> saveObject);
    }
}
