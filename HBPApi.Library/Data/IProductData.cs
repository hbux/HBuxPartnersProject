﻿using HBPApi.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HBPApi.Library.Data
{
    public interface IProductData
    {
        Task<List<ProductModel>> GetProducts(string categoryName);
        Task<ProductModel> GetProduct(int productId);
    }
}