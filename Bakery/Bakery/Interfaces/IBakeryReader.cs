using System.IO;

namespace Bakery.Interfaces
{
    public interface IBakeryReader
    {
        string[] ReadFile(FileStream file);
    }
}
