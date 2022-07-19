using HBPApi.Library.Data;
using HBPApi.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HBPApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class CategoriesController : Controller
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly IProductData _productData;

        public CategoriesController(ILogger<CategoriesController> logger, IProductData productData)
        {
            _logger = logger;
            _productData = productData;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<List<CategoryModel>> GetAllCategories()
        {
            return await _productData.GetCategories();
        }
    }
}
