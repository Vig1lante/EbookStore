using System;
using InternetShop.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace InternetShop {
    class Program {

        static void Main(string[] args) {

            using (var ctx = new DbEntities()) {
                var product = new Product();
                product.Isbn = "asdf143";
                product.Author = "Tom Jones";
                product.Description = "Boring book, not worth it";
                product.Genre = "Mystery";
                product.Price = 34;
                product.Title = "The adventures of Mr.Poblocki";
                product.Discount = 30;
                ctx.Product.Add(product);
                ctx.SaveChanges();
            }
            Console.WriteLine("Work you bitch");
        }

    }
}
