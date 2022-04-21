using Microsoft.EntityFrameworkCore;

namespace OnlineWalmart.DAL
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();

        public ProductContext(DbContextOptions options) : base(options)
        {

        }
    }
}
