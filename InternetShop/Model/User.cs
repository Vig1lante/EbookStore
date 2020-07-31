using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetShop.Model {
    [Table("Users")]

    public class User {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        //[Ignore field => dont need in db, only in memory]
        [NotMapped]
        public bool Anonymous { get; set; } = false; // Keep this for automatic ignore when registering a real user
        public ICollection<Order> Orders { get; set; } 
    }
}
