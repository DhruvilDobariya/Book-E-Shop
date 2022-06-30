using Microsoft.EntityFrameworkCore;

namespace BookShop.Models.Data
{
    public class BookShopDbContext : DbContext
    {
        public BookShopDbContext(DbContextOptions<BookShopDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Role> Role { get; set; } = null!;
        public virtual DbSet<User> User { get; set; } = null!;
        public  virtual DbSet<Category> Category { get; set; } = null!;
        public virtual DbSet<Publisher> Publisher { get; set; } = null!;
        public virtual DbSet<Book> Book { get; set; } = null!;
    }
}
