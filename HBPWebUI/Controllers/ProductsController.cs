using HBPUI.Library.Endpoint;
using HBPUI.Library.Models;
using HBPWebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HBPWebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductEndpoint _productEndpoint;

        public ProductsController(ILogger<ProductsController> logger, IProductEndpoint productEndpoint)
        {
            _logger = logger;
            _productEndpoint = productEndpoint;
        }

        public async Task<IActionResult> ViewAll()
        {
            try
            {
                List<ProductModel> products = await _productEndpoint.GetAll();

                return View(new ProductsViewModel { Products = products });
            }
            catch
            {
                // TODO: Replace this with displaying error on View
                throw;
            }
        }

        public async Task<IActionResult> Item(int id)
        {
            try
            {
                List<ProductModel> products = await _productEndpoint.GetAll();

                ProductModel product = products.Where(x => x.Id == id).FirstOrDefault();

                return View(new ItemViewModel { Product = product });
            }
            catch
            {
                // TODO: Replace this with displaying error on View
                throw;
            }
        }
    }
}
