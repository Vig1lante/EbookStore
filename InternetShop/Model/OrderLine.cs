using System.ComponentModel.DataAnnotations;

namespace InternetShop.Model {
    public class OrderLine {

        [Key]
        public int Id { get; set; }

        [Required]
        public Product Product { get; set; }
        //public string ProductId { get; set; }

        [Required]
        public Order Order { get; set; }
        //public long OrderId { get; set; }

    }
}
