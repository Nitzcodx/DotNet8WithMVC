﻿using DI_Service_Lifetime.Models;
using DI_Service_Lifetime.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;

namespace DI_Service_Lifetime.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ITransientService _transientService1;
        private readonly ITransientService _transientService2;

        private readonly IScopedService _scopedService1;
        private readonly IScopedService _scopedService2;

        private readonly ISingletonService _singletonService1;
        private readonly ISingletonService _singletonService2;

        public HomeController(
            ILogger<HomeController> logger,
            ITransientService transientService1,
            ITransientService transientService2,
            IScopedService scopedService1, IScopedService scopedService2,
            ISingletonService singletonService1, ISingletonService singletonService2)
        {
            _logger = logger;
            _transientService1 = transientService1;
            _transientService2 = transientService2;
            _scopedService1 = scopedService1;
            _scopedService2 = scopedService2;
            _singletonService1 = singletonService1;
            _singletonService2 = singletonService2;
        }

        public IActionResult Index()
        {
            StringBuilder messages = new StringBuilder();
            messages.AppendLine($"Transient1: {_transientService1.GetGuid()}");
            messages.AppendLine($"Transient2: {_transientService2.GetGuid()}");
            messages.AppendLine($"Scoped1: {_scopedService1.GetGuid()}");
            messages.AppendLine($"Scoped2: {_scopedService2.GetGuid()}");
            messages.AppendLine($"Singleton1: {_singletonService1.GetGuid()}");
            messages.AppendLine($"Singleton2: {_singletonService2.GetGuid()}");
            
            return Ok(messages.ToString());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}