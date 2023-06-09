﻿using HBPUI.Library.Endpoint;
using HBPUI.Library.Models;
using HBPWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HBPWebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Checkout()
        {
            return View();
        }
    }
}