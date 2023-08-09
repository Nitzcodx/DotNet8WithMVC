using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bulky.Controllers
{
	public class CategoryController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public CategoryController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IActionResult Category()
		{
			var categories = _unitOfWork.Category.GetAll();
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
                _unitOfWork.Category.Add(category);
                _unitOfWork.Save();
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
			var category = _unitOfWork.Category.Get(cat => cat.CategoryId == id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(category);
                _unitOfWork.Save();
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
            var category = _unitOfWork.Category.Get(cat => cat.CategoryId == id);
            _unitOfWork.Category.Remove(category);
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
			if(id == null || id == 0)
			{
				return BadRequest();
			}

			var category = _unitOfWork.Category.Get(cat => cat.CategoryId == id);

			if(category == null)
			{
				return NotFound();
			}
            _unitOfWork.Category.Remove(category);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully!";
            return RedirectToAction("Category");
		}
    }
}
