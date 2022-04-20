using OnlineWalmart.DAL;

namespace WebApplication2.DAL
{
    public interface IProduct
    {
        string Name { get; }
        string Description { get; }
        Price Price { get; }
    }
}
