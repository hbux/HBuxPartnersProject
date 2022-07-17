using HBPUI.Library.Endpoint;
using HBPUI.Library.Models;
using HBPWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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

        [HttpGet]
        public async Task<IActionResult> Index(int name)
        {
            try
            {
                ProductModel product = await _productEndpoint.GetProduct(name);

                return View(new ProductViewModel()
                {
                    Product = product
                });
            }
            catch (Exception ex)
            {
                return View(new ErrorViewModel
                {
                    Message = ex.Message,
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToBasket(ProductViewModel productPairing)
        {
            try
            {
                ProductModel prod = await _productEndpoint.GetProduct(productPairing.Product.Id);

                if (ModelState.IsValid == false)
                {
                    return RedirectToAction("Index", "Product", new { name = prod.Id });
                }

                TempData["StatusMessage"] = "Added to basket!";

                return RedirectToAction("Index", "Product", new { name = prod.Id });
            }
            catch (Exception ex)
            {
                return View(new ErrorViewModel
                {
                    Message = ex.Message,
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                });
            }
        }
    }
}
