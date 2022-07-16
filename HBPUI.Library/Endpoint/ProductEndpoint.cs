using HBPUI.Library.Api;
using HBPUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HBPUI.Library.Endpoint
{
    public class ProductEndpoint : IProductEndpoint
    {
        private readonly IApiSetup _api;

        public ProductEndpoint(IApiSetup api)
        {
            _api = api;
        }

        public async Task<List<ProductModel>> GetAllProducts()
        {
            using (HttpResponseMessage response = await _api.Client.GetAsync("api/product"))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<ProductModel>>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
