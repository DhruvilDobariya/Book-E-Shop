using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Role")]
        [StringLength(20, ErrorMessage = "Role must contain less then or equals to 20 characters")]
        public string Name { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
