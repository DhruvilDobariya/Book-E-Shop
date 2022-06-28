using Microsoft.EntityFrameworkCore;

namespace BookShop.Models.Data
{
    public class BookShopDbContext : DbContext
    {
        public BookShopDbContext(DbContextOptions<BookShopDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
