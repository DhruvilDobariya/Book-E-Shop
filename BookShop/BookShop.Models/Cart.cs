using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter User")]
        [ForeignKey("User")]
        public int Userid { get; set; }

        [Required(ErrorMessage = "Please Enter Book")]
        [ForeignKey("Book")]
        public int Bookid { get; set; }

        [Required(ErrorMessage = "Please Enter Quantity")]
        public int Quantity { get; set; }

        public virtual Book? Book { get; set; }
        public virtual User? User { get; set; }
    }
}
