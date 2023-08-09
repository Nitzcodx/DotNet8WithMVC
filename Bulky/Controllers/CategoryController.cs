using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bulky.Controllers
{
	public class CategoryController : Controller
	{
        private readonly ICategoryRepository _categoryRepository;

		public CategoryController(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		public IActionResult Category()
		{
			var categories = _categoryRepository.GetAll();
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
                _categoryRepository.Add(category);
                _categoryRepository.Save();
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
			var category = _categoryRepository.Get(cat => cat.CategoryId == id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Update(category);
                _categoryRepository.Save();
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
            var category = _categoryRepository.Get(cat => cat.CategoryId == id);
			_categoryRepository.Remove(category);
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
			if(id == null || id == 0)
			{
				return BadRequest();
			}

			var category = _categoryRepository.Get(cat => cat.CategoryId == id);

			if(category == null)
			{
				return NotFound();
			}
            _categoryRepository.Remove(category);
            _categoryRepository.Save();
            TempData["success"] = "Category deleted successfully!";
            return RedirectToAction("Category");
		}
    }
}
