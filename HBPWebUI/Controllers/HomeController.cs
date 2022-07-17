using HBPUI.Library.Endpoint;
using HBPUI.Library.Models;
using HBPWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HBPWebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductEndpoint _productEndpoint;

        public HomeController(ILogger<HomeController> logger, IProductEndpoint productEndpoint)
        {
            _logger = logger;
            _productEndpoint = productEndpoint;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Basket()
        {
            return View();
        }

        public IActionResult Checkout()
        {
            return View();
        }
    }
}