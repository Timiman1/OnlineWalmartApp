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
            
    }
}
