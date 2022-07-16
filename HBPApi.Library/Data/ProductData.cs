using HBPApi.Library.DataAccess;
using HBPApi.Library.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBPApi.Library.Data
{
    public class ProductData : IProductData
    {
        private readonly ILogger<ProductData> _logger;
        private readonly ISqlDataAccess _dataAccess;

        public ProductData(ILogger<ProductData> logger, ISqlDataAccess dataAccess)
        {
            _logger = logger;
            _dataAccess = dataAccess;
        }

        /// <summary>
        /// Retrieves a product from the database.
        /// </summary>
        /// <param name="productId">The ID of the product to retrieve</param>
        /// <returns>A product</returns>
        /// <exception cref="NullReferenceException"></exception>
        public async Task<ProductModel> GetProduct(int productId)
        {
            string storedProcedure = "dbo.spProduct_GetByProductId";
            string connectionStringName = "HBPData";

            List<ProductModel> products = await
                _dataAccess.LoadData<ProductModel, dynamic>(storedProcedure, new { ProductId = productId }, connectionStringName);

            if (products == null)
            {
                _logger.LogWarning("Unable to load products by product ID: {Id} with SP: {StoredProcedure} with CNN: {ConnectionStringName} at {Time}",
                    productId, storedProcedure, connectionStringName, DateTime.UtcNow);
                throw new NullReferenceException("Unable to load products.");
            }

            ProductModel product = products.FirstOrDefault();

            storedProcedure = "dbo.spPhoto_GetByProductId";
            List<PhotoModel> productPhotos = await
                    _dataAccess.LoadData<PhotoModel, dynamic>(storedProcedure, new { ProductId = product.Id }, connectionStringName);

            if (productPhotos == null)
            {
                _logger.LogWarning("Unable to load product photos by PID: {ProductId} with SP: {StoredProcedure} with CNN: {ConnectionStringName} at {Time}",
                product.Id, storedProcedure, connectionStringName, DateTime.UtcNow);
            }

            product.Photos = productPhotos;

            return product;
        }

        /// <summary>
        /// Retrieves all products from the database.
        /// </summary>
        /// <returns>A list of products</returns>
        /// <exception cref="NullReferenceException"></exception>
        public async Task<List<ProductModel>> GetProducts(string categoryName)
        {
            string storedProcedure = "dbo.spProduct_GetAllByCategoryName";
            string connectionStringName = "HBPData";

            List<ProductModel> products = await
                _dataAccess.LoadData<ProductModel, dynamic>(storedProcedure, new { categoryName }, connectionStringName);

            if (products == null)
            {
                _logger.LogWarning("Unable to load products by category: {Category} with SP: {StoredProcedure} with CNN: {ConnectionStringName} at {Time}",
                    categoryName, storedProcedure, connectionStringName, DateTime.UtcNow);
                throw new NullReferenceException("Unable to load products.");
            }

            storedProcedure = "dbo.spPhoto_GetByProductId";
            foreach (ProductModel product in products)
            {
                List<PhotoModel> productPhotos = await
                    _dataAccess.LoadData<PhotoModel, dynamic>(storedProcedure, new { ProductId = product.Id }, connectionStringName);
            
                if (productPhotos == null)
                {
                    _logger.LogWarning("Unable to load product photos by PID: {ProductId} with SP: {StoredProcedure} with CNN: {ConnectionStringName} at {Time}",
                    product.Id ,storedProcedure, connectionStringName, DateTime.UtcNow);
                    continue;
                }

                product.Photos = productPhotos;
            }

            return products;
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
    }
}
