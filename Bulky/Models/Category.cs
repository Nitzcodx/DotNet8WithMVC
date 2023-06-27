using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [DisplayName("Category Name")]
        public required string CategoryName { get; set; }

        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
