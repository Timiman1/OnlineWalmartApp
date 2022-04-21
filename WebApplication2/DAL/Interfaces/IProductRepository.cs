namespace OnlineWalmart.DAL.Interfaces
{
    public interface IProductRepository
    {
        Task<ICollection<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(Guid id);
        Task<bool> AddNewProductAsync(Product Product);
        bool UpdateProduct(Product Product);
        bool DeleteProduct(Product Product);
    }
}
