using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Category
    {
        public Category()
        {
            Books = new HashSet<Book>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Category Name")]
        [StringLength(250, ErrorMessage = "Category Name must contain less then or equals to 250 characters")]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
