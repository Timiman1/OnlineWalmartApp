using Microsoft.EntityFrameworkCore;

namespace WebApplication2.DAL
{
    public class ProductContext : DbContext
    {

        DbSet<IProduct> Products { get; set; }

        public ProductContext(DbContextOptions options) : base(options)
        {

        }


    }
}
