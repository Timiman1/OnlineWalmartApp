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
                    Name = "Old Brown Java",
                    Description = "An aged coffee with a story to tell",
                    Price = 14.35,
                    DeliveryInfo = "Delivery with Instabox within 0-2 working days"
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Wooden Spatula",
                    Description = "Cedar wood of highest quality",
                    Price = 14.35,
                    DeliveryInfo = "Delivery with Instabox within 0-2 working days"
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Jumprope",
                    Description = "Very ecological and efficient",
                    Price = 12.15,
                    DeliveryInfo = "Come and pick up in our store within 14 days."
                }, 
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Furry Love Cuffs",
                    Description = "Handcuffs in metal with fluffy fur cover. Adjustable in size and comes with two keys.",
                    Price = 16.35,
                    DeliveryInfo = "Delivery with Instabox within 0-2 working days. Descrete packaging."
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Greedy Girl",
                    Description = "24 cm long, Ø 3.8 cm - Rabbit vibrator with double motors and as many as 36 different vibration combinations!",
                    Price = 69,
                    DeliveryInfo = "Come and pick up in our store within 14 days."
                });

        }
    }
}
