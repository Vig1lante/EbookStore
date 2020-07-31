using System;
using InternetShop.Model;
using InternetShop.Controller;
using InternetShop.View;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System.Linq;
using System.Collections.Generic;

namespace InternetShop
{
    class Program
    {

        static void Main(string[] args) {

            using (var ctx = new DbEntities())
            {
                var ctrl = new AppController(ctx);
                var main = new MainMenu(ctrl);
                main.ViewMenu();
            }
        }
    }
}
