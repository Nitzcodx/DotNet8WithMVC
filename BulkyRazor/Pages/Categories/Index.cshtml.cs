using BulkyRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyRazor.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly BulkyRazorDbContext _db;

        [BindProperty]
        public List<Category> CategoryList { get; set; }

        public IndexModel(BulkyRazorDbContext dbContext)
        {
            _db = dbContext;    
        }

        public void OnGet()
        {
            CategoryList = _db.Categories.ToList();
        }
    }
}
