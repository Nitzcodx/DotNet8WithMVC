using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bulky.Controllers
{
	public class CategoryController : Controller
	{
		private readonly BulkyDbContext _bulkyDbContext;

		public CategoryController(BulkyDbContext bulkyDbContext)
		{
			_bulkyDbContext = bulkyDbContext;
		}

		public IActionResult Category()
		{
			var categories = _bulkyDbContext.Categories.ToList();
			return View(categories);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Category category)
		{
			if (ModelState.IsValid)
			{
				_bulkyDbContext.Categories.Add(category);
				_bulkyDbContext.SaveChanges();
				TempData["success"] = "Category created successfully!";
				return RedirectToAction("Category");
			}
			return View();

		}

		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var category = _bulkyDbContext.Categories.FirstOrDefault(cat => cat.CategoryId == id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _bulkyDbContext.Categories.Update(category);
                _bulkyDbContext.SaveChanges();
                TempData["success"] = "Category updated successfully!";
                return RedirectToAction("Category");
            }
            return View();

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _bulkyDbContext.Categories.FirstOrDefault(cat => cat.CategoryId == id);
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
			if(id == null || id == 0)
			{
				return BadRequest();
			}

			var category = _bulkyDbContext.Categories.Find(id);

			if(category == null)
			{
				return NotFound();
			}
			_bulkyDbContext.Categories.Remove(category);
			_bulkyDbContext.SaveChanges();
            TempData["success"] = "Category deleted successfully!";
            return RedirectToAction("Category");
		}
    }
}
