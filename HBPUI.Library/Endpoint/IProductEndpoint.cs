using HBPUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HBPUI.Library.Endpoint
{
    public interface IProductEndpoint
    {
        Task<List<ProductModel>> GetAll();
    }
}