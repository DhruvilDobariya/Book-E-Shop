using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Models
{
    public class Book
    {
        public Book()
        {
            //OrderDtls = new HashSet<OrderDtl>();
            Carts = new HashSet<Cart>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        [StringLength(250, ErrorMessage = "Name must contain less then or equals to 250 characters")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Please Price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;

        [DataType(DataType.ImageUrl)]
        public string Base64image { get; set; } = null!;

        [Required(ErrorMessage = "Please Category")]
        [ForeignKey("Category")]
        public int Categoryid { get; set; }

        [Required(ErrorMessage = "Please Category")]
        [ForeignKey("Publisher")]
        public int PublisherId { get; set; }

        [Required(ErrorMessage = "Please Quntity")]
        public int Quantity { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Publisher? Publisher { get; set; }
        //public virtual ICollection<OrderDtl> OrderDtls { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
