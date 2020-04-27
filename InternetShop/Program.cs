using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace InternetShop {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
        }
        public void ConfigureServices(IServiceCollection services) {
            var connectionString = Configuration["PostgreSql:ConnectionString"];

        }
    }
}
