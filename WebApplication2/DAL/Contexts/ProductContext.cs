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
                    Id = new Guid("e4e42faf-254c-4715-86a4-f37b8a41fb3b"),
                    Name = "Old Brown Java",
                    Description = "An aged coffee with a story to tell",
                    Price = 14.35,
                    DeliveryInfo = "Delivery with Instabox within 0-2 working days"
                },
                new Product
                {
                    Id = new Guid("37752535-c224-4634-9d81-d762730d1b29"),
                    Name = "Wooden Spatula",
                    Description = "Cedar wood of highest quality",
                    Price = 14.35,
                    DeliveryInfo = "Delivery with Instabox within 0-2 working days"
                },
                new Product
                {
                    Id = new Guid("91ba1ffa-f6fc-4ec6-88e2-043e724c783a"),
                    Name = "Jumprope",
                    Description = "Very ecological and efficient",
                    Price = 12.15,
                    DeliveryInfo = "Come and pick up in our store within 14 days."
                }, 
                new Product
                {
                    Id = new Guid("5a2a52ac-7078-4142-a87f-d6a043e30ca7"),
                    Name = "Furry Love Cuffs",
                    Description = "Handcuffs in metal with fluffy fur cover. Adjustable in size and comes with two keys.",
                    Price = 16.35,
                    DeliveryInfo = "Delivery with Instabox within 0-2 working days. Descrete packaging."
                },
                new Product
                {
                    Id = new Guid("4a985902-e94b-4046-adc3-a167933158b4"),
                    Name = "Greedy Girl",
                    Description = "24 cm long, Ø 3.8 cm - Rabbit vibrator with double motors and as many as 36 different vibration combinations!",
                    Price = 69,
                    DeliveryInfo = "Come and pick up in our store within 14 days."
                });

        }
    }
}
