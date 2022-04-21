using Microsoft.EntityFrameworkCore;
using OnlineWalmart.Users.DAL.Entities;

namespace OnlineWalmart.Users.Context;

public class UserContext : DbContext
{
    public DbSet<User> Users => Set<User>();

    public UserContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<User>()
            .Property(p => p.Id)
            .HasDefaultValueSql("NEWID()");

        modelBuilder.Entity<User>()
            .HasIndex(p => p.Email)
            .IsUnique();

        modelBuilder.Entity<User>().HasData(
             new User
             {
                 Id = Guid.NewGuid(),
                 FirstName = "Billy",
                 LastName = "Bob",
                 DateOfBirth = new DateTimeOffset(1985, 4, 20, 0, 0, 0, TimeSpan.Zero),
                 Phone = "0763648234",
                 Email = "billy@nomail.com"
             },
             new User
             {
                 Id = Guid.NewGuid(),
                 FirstName = "John",
                 LastName = "Doe",
                 DateOfBirth = new DateTimeOffset(1982, 6, 12, 0, 0, 0, TimeSpan.Zero),
                 Phone = "0765628331",
                 Email = "john@nomail.com"
             },
             new User
             {
                 Id = Guid.NewGuid(),
                 FirstName = "Jane",
                 LastName = "Doe",
                 DateOfBirth = new DateTimeOffset(1995, 8, 5, 0, 0, 0, TimeSpan.Zero),
                 Phone = "0765628331",
                 Email = "jane@nomail.com"
             });
    }
}
