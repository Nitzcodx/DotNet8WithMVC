using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required, MaxLength(20), DisplayName("Category Name")]
        public required string CategoryName { get; set; }

        [Required, Range(0, 20, ErrorMessage = "Wrong Range"), DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
