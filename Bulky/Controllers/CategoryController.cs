﻿using Bulky.Models;
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
    }
}
