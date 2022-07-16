using HBPUI.Library.Endpoint;
using Microsoft.AspNetCore.Mvc;

namespace HBPWebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly IProductEndpoint _productEndpoint;

        public CategoryController(ILogger<CategoryController> logger, IProductEndpoint productEndpoint)
        {
            _logger = logger;
            _productEndpoint = productEndpoint;
        }

        public IActionResult Index(string name)
        {
            return View();
        }
    }
}
