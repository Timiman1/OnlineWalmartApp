using Microsoft.EntityFrameworkCore;

namespace OnlineWalmart.DAL
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();

        public ProductContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().OwnsOne(p => p.Price);
        }
    }
}
