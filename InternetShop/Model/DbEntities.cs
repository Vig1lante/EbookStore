using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace InternetShop.Model {
    class DbEntities: DbContext {

        public DbEntities() {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DbEntities>);
        }
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<UserType> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=dumbo.db.elephantsql.com; " +
                                        "Database=bntmllfq; Username=bntmllfq;" +
                                        " Password=uI9CxYhBKT6XwvqV03iQLd6bY7tD7wH7");
        }
    }
}
