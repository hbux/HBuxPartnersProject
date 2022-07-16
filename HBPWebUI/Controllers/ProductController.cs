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

        public async Task<IActionResult> Index(int id)
        {
            try
            {
                // This is slow. Imagine if there were 1,000,000 entires. Looping over that each refresh?
                List<ProductModel> products = await _productEndpoint.GetAllProducts();

                ProductModel product = products.FirstOrDefault(x => x.Id == id);

                return View(new IndexViewModel()
                {
                    Product = product
                });
            }
            catch
            {
                // TODO: Replace this with displaying error on View
                throw;
            }
        }

        public async Task<IActionResult> ViewAll()
        {
            try
            {
                List<ProductModel> products = await _productEndpoint.GetAllProducts();

                return View(new ProductViewModel
                {
                    Products = products
                });
            }
            catch
            {
                // TODO: Replace this with displaying error on View
                throw;
            }
        }
    }
}
