using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetShop {
    [Table("Orders")]
    public class Order {

        public enum OrderStatus { Active, Processed }

        [Key]
        public long Id { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public User User { get; set; }

        public OrderStatus Status { get; set; }

        public uint Price { get; set; }  
    }
}
