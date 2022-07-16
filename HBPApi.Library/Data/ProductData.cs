using HBPApi.Library.DataAccess;
using HBPApi.Library.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HBPApi.Library.Data
{
    public class ProductData : IProductData
    {
        private ILogger<ProductData> _logger;
        private ISqlDataAccess _dataAccess;

        public ProductData(ILogger<ProductData> logger, ISqlDataAccess dataAccess)
        {
            _logger = logger;
            _dataAccess = dataAccess;
        }

        /// <summary>
        /// Retrieves all products from the database.
        /// </summary>
        /// <returns>A list of products</returns>
        /// <exception cref="NullReferenceException"></exception>
        public async Task<List<ProductModel>> GetAllProducts()
        {
            string storedProcedure = "dbo.spProduct_GetAll";
            string connectionStringName = "HBPData";

            List<ProductModel> products = await
                _dataAccess.LoadData<ProductModel, dynamic>(storedProcedure, new { }, connectionStringName);

            if (products == null)
            {
                _logger.LogWarning("Unable to load products with SP: {StoredProcedure} with CNN: {ConnectionStringName} at {Time}",
                    storedProcedure, connectionStringName, DateTime.UtcNow);
                throw new NullReferenceException("Unable to load products.");
            }

            return products;
        }

        /// <summary>
        /// Retrives all categories from the database.
        /// </summary>
        /// <returns>A list of categories</returns>
        /// <exception cref="NullReferenceException"></exception>
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
