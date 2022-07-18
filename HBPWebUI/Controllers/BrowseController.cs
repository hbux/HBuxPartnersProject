using HBPUI.Library.Endpoint;
using HBPUI.Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace HBPWebUI.Controllers
{
    public class BrowseController : Controller
    {
        private readonly ILogger<BrowseController> _logger;
        private readonly ICategoryEndpoint _categoryEndpoint;
        private readonly IProductEndpoint _productEndpoint;

        public BrowseController(ILogger<BrowseController> logger, 
            ICategoryEndpoint categoryEndpoint, IProductEndpoint productEndpoint)
        {
            _logger = logger;
            _categoryEndpoint = categoryEndpoint;
            _productEndpoint = productEndpoint;
        }

        public async Task<IActionResult> Index()
        {
            List<NestedCategoryModel> allCategories = await _categoryEndpoint.GetAllCategories();

            return View(allCategories);
        }

        public async Task<IActionResult> Categories(string category, string subCategory, string type)
        {
            if (string.IsNullOrEmpty(category) || string.IsNullOrEmpty(subCategory) || 
                string.IsNullOrEmpty(type))
            {
                return View("Index");
            }

            List<ProductModel> categoryProducts = await _productEndpoint.GetAllProducts(type);

            return View(categoryProducts);
        }

        public async Task<IActionResult> Product(int name)
        {
            ProductModel product = await _productEndpoint.GetProduct(name);

            return View(product);
        }
    }
}
