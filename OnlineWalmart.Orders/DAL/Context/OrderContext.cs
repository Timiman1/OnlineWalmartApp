using Microsoft.EntityFrameworkCore;
using OnlineWalmart.Orders.DAL.Entities;

namespace OnlineWalmart.Orders.DAL.Context;

public class OrderContext : DbContext
{
    public DbSet<Order> Orders => Set<Order>();

    public OrderContext(DbContextOptions options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
           .HasKey(p => p.Id);

        modelBuilder.Entity<Order>()
            .Property(p => p.ProductId)
            .HasDefaultValueSql("NEWID()");

        modelBuilder.Entity<Order>()
            .Property(p => p.UserId)
            .HasDefaultValueSql("NEWID()");

        modelBuilder.Entity<Order>().HasData(
             new Order
             {
                 Id = 1,
                 ProductId = new Guid("5a2a52ac-7078-4142-a87f-d6a043e30ca7"),
                 UserId = new Guid("8e5301ee-5a93-4df1-bb95-1f4c2caef259"),
                 DateOfPurchase = new DateTimeOffset(2022, 4, 22, 0, 0, 0, TimeSpan.Zero),
                 DiscountInPercent = 10f
             },
             new Order
             {
                 Id = 2,
                 ProductId = new Guid("37752535-c224-4634-9d81-d762730d1b29"),
                 UserId = new Guid("e75b825d-be51-46dc-b208-92c4c45899bc"),
                 DateOfPurchase = new DateTimeOffset(2022, 2, 22, 0, 0, 0, TimeSpan.Zero),
                 DiscountInPercent = 25f
             },
             new Order
             {
                 Id = 3,
                 ProductId = new Guid("e4e42faf-254c-4715-86a4-f37b8a41fb3b"),
                 UserId = new Guid("5ad66822-eaa0-4784-8c6c-baa00f36132c"),
                 DateOfPurchase = new DateTimeOffset(2022, 3, 22, 0, 0, 0, TimeSpan.Zero),
                 DiscountInPercent = 5f
             });
    }
}
