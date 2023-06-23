using System.ComponentModel.DataAnnotations;

namespace Bulky.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public required string CategoryName { get; set; }

        public int DisplayOrder { get; set; }
    }
}
