using Microsoft.EntityFrameworkCore;

namespace InternetShop.Model {
    public class DbEntities : DbContext {
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }
        
        public DbSet<OrderLine> Orderlines { get; set; }

        public DbEntities() => this.Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql();
    }
}
