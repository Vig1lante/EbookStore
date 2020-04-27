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
                product.Author = "Mike Tyson";
                product.Description = "IT'S THE BETH";
                product.Genre = "Alternative medicine";
                product.Price = 34;
                product.Title = "How to eat one's children";
                product.Discount = 30;
                ctx.Product.Add(product);
                ctx.SaveChanges();
            }
        }
    }
}
