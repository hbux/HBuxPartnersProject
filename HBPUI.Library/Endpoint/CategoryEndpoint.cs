using HBPUI.Library.Api;
using HBPUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HBPUI.Library.Endpoint
{
    public class CategoryEndpoint : ICategoryEndpoint
    {
        private readonly IApiSetup _api;

        public CategoryEndpoint(IApiSetup api)
        {
            _api = api;
        }

        /// <summary>
        /// Reads all categories received from the request to the API.
        /// </summary>
        /// <returns>A list of ordered categories</returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<CategoryModel>> GetAllCategories()
        {
            using (HttpResponseMessage response = await _api.Client.GetAsync("api/categories/getall"))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<CategoryModel>>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
