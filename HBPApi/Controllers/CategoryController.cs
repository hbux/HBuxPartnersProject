using HBPApi.Library.Data;
using HBPApi.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HBPApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryData _categoryData;

        public CategoryController(ILogger<CategoryController> logger, ICategoryData categoryData)
        {
            _logger = logger;
            _categoryData = categoryData;
        }

        [HttpGet]
        public async Task<List<CategoryModel>> GetAll()
        {
            return await _categoryData.GetAllCategories();
        }
    }
}
