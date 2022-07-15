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
    public class ProductData : IProductData
    {
        private readonly ILogger<ProductData> _logger;
        private readonly ISqlDataAccess _dataAccess;

        public ProductData(ILogger<ProductData> logger, ISqlDataAccess dataAccess)
        {
            _logger = logger;
            _dataAccess = dataAccess;
        }

        public async Task<List<ProductModel>> GetAllProducts()
        {
            string storedProcedure = "dbo.spProduct_GetAll";
            string connectionStringName = "HBPData";

            List<ProductModel> products =
                await _dataAccess.LoadData<ProductModel, dynamic>(storedProcedure, new { }, connectionStringName);

            if (products == null)
            {
                _logger.LogWarning("Unable to load products with SP: {StoredProcedure} with CNN: {ConnectionStringName} at {Time}", 
                    storedProcedure, connectionStringName, DateTime.UtcNow);
                throw new NullReferenceException("Unable to load products.");
            }

            storedProcedure = "dbo.spPhoto_GetByProductId";
            foreach (ProductModel product in products)
            {
                List<PhotoModel> productPhotos =
                    await _dataAccess.LoadData<PhotoModel, dynamic>(storedProcedure, new { ProductId = product.Id }, connectionStringName);

                if (productPhotos == null)
                {
                    _logger.LogWarning("Unable to load photos for product ID: {Id} with SP: {StoredProcedure} with CNN: {ConnectionStringName} at {Time}", 
                        storedProcedure, connectionStringName, DateTime.UtcNow);
                    continue;
                }

                product.Photos = productPhotos;
            }

            return products;
        }
    }
}
