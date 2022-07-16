using HBPApi.Library.Data;
using HBPApi.Library.Helpers;
using HBPApi.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HBPApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductData _productData;
        private readonly ICategoryHelper _categoryHelper;

        public ProductController(ILogger<ProductController> logger, IProductData productData, 
            ICategoryHelper categoryHelper)
        {
            _logger = logger;
            _productData = productData;
            _categoryHelper = categoryHelper;
        }

        [HttpGet]
        public async Task<List<ProductModel>> GetAllProducts()
        {
            return await _productData.GetAllProducts();
        }

        [HttpGet]
        [Route("Category")]
        public async Task<List<NestedCategoryModel>> GetAllCategories()
        {
            List<CategoryModel> allCategories = await _productData.GetAllCategories();

            return _categoryHelper.CreateNestedCategories(allCategories);
        }
    }
}
