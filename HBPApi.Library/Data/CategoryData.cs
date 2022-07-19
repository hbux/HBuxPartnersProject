using HBPApi.Library.DataAccess;
using HBPApi.Library.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBPApi.Library.Data
{
    public class CategoryData : ICategoryData
    {
        private readonly ILogger<CategoryData> _logger;
        private readonly ISqlDataAccess _dataAccess;

        public CategoryData(ILogger<CategoryData> logger, ISqlDataAccess dataAccess)
        {
            _logger = logger;
            _dataAccess = dataAccess;
        }

        /// <summary>
        /// Retrives all categories from the database.
        /// </summary>
        /// <returns>A list of categories</returns>
        /// <exception cref="NullReferenceException"></exception>
        public async Task<List<CategoryModel>> GetCategories()
        {
            string storedProcedure = "dbo.spCategory_GetAll";
            string connectionStringName = "HBPData";

            List<CategoryModel> categories = await
                _dataAccess.LoadData<CategoryModel, dynamic>(storedProcedure, new { }, connectionStringName);

            if (categories == null)
            {
                _logger.LogWarning("Unable to load categories with SP: {StoredProcedure} with CNN: {ConnectionStringName} at {Time}",
                    storedProcedure, connectionStringName, DateTime.UtcNow);
                throw new NullReferenceException("Unable to load categories.");
            }

            return categories;
        }

        public async Task<Dictionary<string, List<CategoryModel>>> GetCategory(string superordinateName)
        {
            Dictionary<string, List<CategoryModel>> category = new Dictionary<string, List<CategoryModel>>();

            List<CategoryModel> allCategories = await GetCategories();

            CategoryModel superordinate = allCategories.FirstOrDefault(x => x.Title == superordinateName);

            List<CategoryModel> subordinates = allCategories.Where(x => x.ParentId == superordinate.Id).ToList();

            foreach (CategoryModel sub in subordinates)
            {
                List<CategoryModel> types = new List<CategoryModel>();

                foreach (CategoryModel cat in allCategories.Where(x => x.ParentId == sub.Id))
                {
                    types.Add(cat);
                }

                category.Add(sub.Title, types);
            }

            return category;
        }
    }
}
