using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InternetShop {
    class Order {

        internal enum OrderStatus {
            Active,
            Processed,
        }
        [Key]
        public int Id { get; set; }
        public ICollection<Product> Products { get; set; }

        public UserType User { get; set; }

        public OrderStatus Status { get; set; }

        public uint Price { get; set; }  
    }
}
