using Microsoft.EntityFrameworkCore;

namespace OnlineWalmart.DAL.Contexts
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();

        public ProductContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Wooden Spatula",
                    Description = "Cedar wood",
                    Price = 14.35,
                    Discount = 0,
                    DeliveryInfo = "Delivery with Instabox within 0-2 working days"
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Jumprope",
                    Description = "Very ecological and efficient",
                    Price = 12.15,
                    Discount = 0,
                    DeliveryInfo = "Come and pick up in our store within 14 days."
                });
        }
    }
}
