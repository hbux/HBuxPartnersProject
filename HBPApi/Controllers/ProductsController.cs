using HBPApi.Library.Data;
using HBPApi.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HBPApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductData _productData;

        public ProductsController(ILogger<ProductsController> logger, IProductData productData)
        {
            _logger = logger;
            _productData = productData;
        }

        [HttpGet]
        [Route("Product/ById/{productId}")]
        public async Task<ProductModel> GetProductById(int productId)
        {
            return await _productData.GetProduct(productId);
        }

        [HttpGet]
        [Route("ByCategory/{categoryName}")]
        public async Task<List<ProductModel>> GetAllCategoryProducts(string categoryName)
        {
            return await _productData.GetProducts(categoryName);
        }
    }
}
