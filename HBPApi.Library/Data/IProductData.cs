using HBPApi.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HBPApi.Library.Data
{
    public interface IProductData
    {
        Task<List<ProductModel>> GetAllProducts();
    }
}