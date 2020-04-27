using System;
using System.Collections.Generic;
using System.Text;

namespace InternetShop {
    class UserType {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public ICollection<Order> Orders { get; set; } 

    }
}
