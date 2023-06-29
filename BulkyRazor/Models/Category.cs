using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyRazor.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(20), DisplayName("Category Name")]
        public required string Name { get; set; }

        [Required, Range(0, 20), DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
