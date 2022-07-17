using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace HBPUI.Library.Api
{
    public class ApiSetup : IApiSetup
    {
        private readonly ILogger<ApiSetup> _logger;
        private readonly IConfiguration _config;
        private HttpClient _client;

        public HttpClient Client
        {
            get
            {
                return _client;
            }
        }

        public ApiSetup(ILogger<ApiSetup> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;

            InitializeClient();
        }

        /// <summary>
        /// Initializes the connection with the api using configuration settings.
        /// </summary>
        private void InitializeClient()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(GetApiUri("Secrets:Api.Uri"));

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Retrieves the API URI from configuration settings.
        /// </summary>
        /// <param name="apiUriName">The key name of the API URI in configuration settings</param>
        /// <returns>The value retrieved from the key</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public string GetApiUri(string apiUriName)
        {
            string apiUri = _config.GetValue<string>(apiUriName);

            if (string.IsNullOrEmpty(apiUri) == true)
            {
                _logger.LogWarning("Failed to retrieve API URI {Name} from configuration settings at {Time}", apiUriName, DateTime.UtcNow);
                throw new InvalidOperationException($"The configuration setting for the API could not be found.");
            }

            return apiUri;
        }
    }
}
