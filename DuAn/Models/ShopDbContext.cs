using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DuAn.Models
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext() { }
        public ShopDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillDetails> BillDetailss { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetails> CartDetailss { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
    
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-2V5BKJA\\SQLEXPRESS;Initial Catalog=DUAN_C#4;Persist Security Info=True;User ID=hieupvph27565;Password=hieupvph27565");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
