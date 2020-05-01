using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using InternetShop.Model;

namespace InternetShop.Controller {
    public class Controller {
        public DbEntities Context { get; set; }

        public Controller(DbEntities context) => this.Context = context;

        public User UserRegister() {
            return null;
        }
    }   
}
