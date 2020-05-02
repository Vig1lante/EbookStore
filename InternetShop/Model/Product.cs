using InternetShop.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetShop.Model {
    [Table("Products")]
    public class Product {
        [Key]
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int Discount { get; set; }
        public long Price { get; set; }
        public ICollection<OrderLine> OrderLines { get; set; }

    }
}
