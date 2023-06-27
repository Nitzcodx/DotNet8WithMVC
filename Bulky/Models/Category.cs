using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [DisplayName("Category Name")]
        [MaxLength(5)]
        public required string CategoryName { get; set; }

        [Required]
        [DisplayName("Display Order")]
        [Range(0, 20, ErrorMessage = "Wrong Range")]
        public int DisplayOrder { get; set; }
    }
}
