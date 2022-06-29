using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        //public User()
        //{
        //    Carts = new HashSet<Cart>();
        //    Ordermsts = new HashSet<Ordermst>();
        //}

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter First Name")]
        [StringLength(250, ErrorMessage = "First Name must contain less then or equals to 250 characters")]
        public string Firstname { get; set; } = null!;

        [Required(ErrorMessage = "Please Enter Last Name")]
        [StringLength(250, ErrorMessage = "Last Name must contain less then or equals to 250 characters")]
        public string Lastname { get; set; } = null!;

        [Required(ErrorMessage = "Please Enter Email")]
        [EmailAddress(ErrorMessage = "Enter valid email")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must contain at least 8 character")]
        public string Password { get; set; } = null!;

        [ForeignKey("Role")]
        [Required(ErrorMessage = "Please Enter Role")]
        public int Roleid { get; set; }

        public virtual Role? Role { get; set; }
        //public virtual ICollection<Cart> Carts { get; set; }
        //public virtual ICollection<Ordermst> Ordermsts { get; set; }
    }
}
