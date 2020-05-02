using System;
using System.Collections.Generic;
using System.Text;
using InternetShop.Model;

namespace InternetShop.Controller {
    class ComparerForRegistration : IEqualityComparer<User> {
        public bool Equals(User x, User y) {
            if (x.Name == y.Name && x.Surname == y.Surname) {
                return true;
            }
            return false;
        }
        public int GetHashCode(User obj) {
            throw new NotImplementedException();
        }
    }
}
