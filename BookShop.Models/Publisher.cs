using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class Publisher
    {
        public Publisher()
        {
            Books = new HashSet<Book>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        [StringLength(250, ErrorMessage = "Name must contain less then or equals to 250 characters")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Enter Address Name")]
        [StringLength(500, ErrorMessage = "Address must contain less then or equals to 500 characters")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; } = null!;

        [Required(ErrorMessage = "Please Enter Contact No")]
        [StringLength(250, ErrorMessage = "Contact No must contain less then or equals to 250 characters")]
        [DataType(DataType.PhoneNumber)]
        public string Contact { get; set; } = null!;
        public virtual ICollection<Book> Books { get; set; }
    }
}
