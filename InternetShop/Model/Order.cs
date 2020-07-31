using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetShop.Model {
    [Table("Orders")]
    public class Order {
        public Order()
        {
            OrderLines = new List<OrderLine>();
        }

        public enum OrderStatus { Active, Processed }

        [Key]
        public long Id { get; set; }
        [Required]
        public User User { get; set; }
        
        public OrderStatus Status { get; set; }

        public uint Price { get; set; }

        public ICollection<OrderLine> OrderLines { get; set; }

    }
}
