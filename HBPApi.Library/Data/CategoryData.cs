using HBPApi.Library.DataAccess;
using HBPApi.Library.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HBPApi.Library.Data
{
    public class CategoryData : ICategoryData
    {
        private ILogger<CategoryData> _logger;
        private ISqlDataAccess _dataAccess;

        public CategoryData(ILogger<CategoryData> logger, ISqlDataAccess dataAccess)
        {
            _logger = logger;
            _dataAccess = dataAccess;
        }

        public async Task<List<CategoryModel>> GetAllCategories()
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
    }
}
