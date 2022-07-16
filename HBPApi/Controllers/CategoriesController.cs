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
    public class CategoriesController : Controller
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly IProductData _productData;
        private readonly ICategoryHelper _categoryHelper;

        public CategoriesController(ILogger<CategoriesController> logger, IProductData productData,
            ICategoryHelper categoryHelper)
        {
            _logger = logger;
            _productData = productData;
            _categoryHelper = categoryHelper;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<List<NestedCategoryModel>> GetAllCategories()
        {
            List<CategoryModel> allCategories = await _productData.GetCategories();

            return _categoryHelper.CreateNestedCategories(allCategories);
        }
    }
}
