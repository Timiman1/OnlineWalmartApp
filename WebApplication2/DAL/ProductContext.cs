using Microsoft.EntityFrameworkCore;

namespace OnlineWalmart.DAL
{
    public class ProductContext : DbContext
    {

        DbSet<Product> Products { get; set; }

        public ProductContext(DbContextOptions options) : base(options)
        {

        }


    }
}
