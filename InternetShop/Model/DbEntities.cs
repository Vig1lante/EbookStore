using Microsoft.EntityFrameworkCore;

namespace InternetShop.Model {
    public class DbEntities : DbContext {

        //public DbEntities() => this.Database.EnsureCreated();
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }

        public DbSet<OrderLine> Orderlines { get; set; }

        //public DbEntities() {

        //this.Database.EnsureCreated();
        //}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<OrderLine>()
                .HasKey(order => new { order.OrderId, order.ProductId });
            modelBuilder.Entity<OrderLine>()
                 .HasOne(pc => pc.Order)
                 .WithMany(p => p.OrderLines)
                 .HasForeignKey(pc => pc.OrderId);
            modelBuilder.Entity<OrderLine>()
                .HasOne(pc => pc.Product)
                .WithMany(c => c.OrderLines)
                .HasForeignKey(pc => pc.ProductId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=vps796625.ovh.net; " +
                                        "Database=bookstoreandy; Username=dbuser;" +
                                        " Password=asd123");
    }
}
