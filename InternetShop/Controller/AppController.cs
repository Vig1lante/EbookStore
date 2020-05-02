using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using InternetShop.Model;
using System.Diagnostics.CodeAnalysis;

namespace InternetShop.Controller {
    public class AppController {
        public DbEntities Context { get; set; }
        public User User { get; set; }

        public AppController(DbEntities context) => this.Context = context;

        public void UserRegister(User user) {
            // Error handling 
            // 
            if (ValidateRegistration(user)) { 
                this.Context.Add(user); 
            }
        }
        public bool ValidateRegistration(User user) {

            IEnumerable<User> users = Context.User.AsEnumerable();
            var names = users.Select(n => n.Name).ToList();
            // a field is empty
            // username already exists
            // password too short
            // incorrect email format
            return true;
        }


    }

}
