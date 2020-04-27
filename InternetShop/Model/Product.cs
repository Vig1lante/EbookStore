using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InternetShop {
    class Product {
        [Key]
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int Discount { get; set; }
        public long Price { get; set; }

    }
}
