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

        public async Task<List<ProductModel>> GetAllProducts(string categoryName)
        {
            using (HttpResponseMessage response = await _api.Client.GetAsync($"api/products/bycategory/{ categoryName }"))
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

        public async Task<ProductModel> GetProduct(int id)
        {
            using (HttpResponseMessage response = await _api.Client.GetAsync($"api/products/product/byid/{ id }"))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<ProductModel>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
