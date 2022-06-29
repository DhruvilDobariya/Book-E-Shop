using Microsoft.EntityFrameworkCore;

namespace BookShop.Models.Data
{
    public class BookShopDbContext : DbContext
    {
        public BookShopDbContext(DbContextOptions<BookShopDbContext> options) : base(options)
        {

        }

        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }

        public DbSet<Category> Category { get; set; }
    }
}
