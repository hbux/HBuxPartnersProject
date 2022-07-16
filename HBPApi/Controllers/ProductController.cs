using HBPApi.Library.Data;
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

        public ProductController(ILogger<ProductController> logger, IProductData productData)
        {
            _logger = logger;
            _productData = productData;
        }

        [HttpGet]
        public async Task<List<ProductModel>> GetAllProducts()
        {
            return await _productData.GetAllProducts();
        }

        [HttpGet]
        [Route("Category")]
        public async Task<List<CategoryModel>> GetAllCategories()
        {
            return await _productData.GetAllCategories();
        }
    }
}
