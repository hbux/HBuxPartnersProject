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
        private readonly ICategoryData _categoryData;

        public CategoriesController(ILogger<CategoriesController> logger, ICategoryData categoryData)
        {
            _logger = logger;
            _categoryData = categoryData;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<List<CategoryModel>> GetAllCategories()
        {
            return await _categoryData.GetCategories();
        }

        [HttpGet]
        [Route("ByName/{superordinateName}")]
        public async Task<Dictionary<string, List<CategoryModel>>> GetCategoriesBySuperordinate(string superordinateName)
        {
            return await _categoryData.GetCategory(superordinateName);
        }
    }
}
