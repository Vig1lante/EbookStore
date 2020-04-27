using Microsoft.EntityFrameworkCore;

namespace InternetShop.Model {
    class DbEntities : DbContext {

        //public DbEntities() => this.Database.EnsureCreated();
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }

        public DbEntities() {

        this.Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=vps796625.ovh.net; " +
                                        "Database=bookstore; Username=dbuser;" +
                                        " Password=asd123");



        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Order>()
            .HasMany<Order>(o => o.Products)
            .WithMany(p => p.Orders)
            .Map(cs =>
            {
                cs.MapLeftKey("StudentRefId");
                cs.MapRightKey("CourseRefId");
                cs.ToTable("StudentCourse");
            });
        }
    }
}
