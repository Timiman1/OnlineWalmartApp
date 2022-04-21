using Microsoft.EntityFrameworkCore;

namespace OnlineWalmart.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }
        public async Task<bool> AddNewProductAsync(Product Product)
        {
            try
            {
                await _context.Products.AddAsync(Product);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteProduct(Product Product)
        {
            try
            {
                _context.Products.Remove(Product);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ICollection<Product>> GetAllProductsAsync()
        {
            return await _context.Products
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            return await _context.Products
                .FirstOrDefaultAsync(Product => Product.Id == id) ?? null!;
        }

        public bool UpdateProduct(Product Product)
        {
            try
            {
                _context.Products.Update(Product);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
