using Storehouse.Products;
using System.Collections.Generic;
using System;
using System.Text;

namespace Storehouse.Interfaces
{
    /// <summary>
    /// Interface for Reader class
    /// </summary>
    public interface IStorageSaver
    {
        public void SaveInJson(List<Product> products, string path);
    }
}
