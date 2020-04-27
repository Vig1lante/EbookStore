using Microsoft.EntityFrameworkCore;

namespace InternetShop.Model {
    class DbEntities : DbContext {

        //public DbEntities() => this.Database.EnsureCreated();
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }

        public DbSet<Orderlines> Orderlines { get; set; }

        public DbEntities() {

        this.Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=vps796625.ovh.net; " +
                                        "Database=bookstore; Username=dbuser;" +
                                        " Password=asd123");
    }
}
