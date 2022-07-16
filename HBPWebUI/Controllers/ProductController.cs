using HBPUI.Library.Endpoint;
using HBPUI.Library.Models;
using HBPWebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HBPWebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductEndpoint _productEndpoint;

        public ProductController(ILogger<ProductController> logger, IProductEndpoint productEndpoint)
        {
            _logger = logger;
            _productEndpoint = productEndpoint;
        }

        public async Task<IActionResult> Index(int name)
        {
            ProductModel product = await _productEndpoint.GetProduct(name);

            return View(new ProductViewModel()
            {
                Product = product
            });
        }
    }
}
