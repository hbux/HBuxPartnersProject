using HBPUI.Library.Endpoint;
using HBPUI.Library.Models;
using HBPWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HBPWebUI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly IProductEndpoint _productEndpoint;

        public CategoriesController(ILogger<CategoriesController> logger, IProductEndpoint productEndpoint)
        {
            _logger = logger;
            _productEndpoint = productEndpoint;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string name)
        {
            try
            {
                List<ProductModel> products = await _productEndpoint.GetAllProducts(name);

                return View(new CategoryViewModel()
                {
                    CategoryName = name,
                    Products = products,
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
    }
}
