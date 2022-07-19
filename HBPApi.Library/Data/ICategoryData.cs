using HBPApi.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HBPApi.Library.Data
{
    public interface ICategoryData
    {
        Task<List<CategoryModel>> GetCategories();
        Task<Dictionary<string, List<CategoryModel>>> GetCategory(string superordinateName);
    }
}