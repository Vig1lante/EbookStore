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
                product.Isbn = "12";
                product.Author = "vvvvvvvvvvvvvvvvvvvv";
                product.Description = "ccccccccccccccc";
                product.Genre = "ssssssssssssssssssss medicine";
                product.Price = 324;
                product.Title = "How to eat one's children";
                product.Discount = 30;
                ctx.Product.Add(product);
                ctx.SaveChanges();
            }
        }
    }
}
