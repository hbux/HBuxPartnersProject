using HBPUI.Library.Api;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HBPUI.Tests.Api
{
    public class ApiSetupTests
    {
        private IConfiguration BuildConfiguration()
        {
            // Creates the configuration class using in-memory settings for ApiSetup constructor
            var inMemorySettings = new Dictionary<string, string> {
                {"Secrets:Api.Uri", "https://localhost:7193/"}
            };

            IConfiguration config = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            return config;
        }

        private IApiSetup BuildApiSetup()
        {
            // Mocks the logger class for ApiSetup contructor
            var mockLogger = new Mock<ILogger<ApiSetup>>();
            ILogger<ApiSetup> logger = mockLogger.Object;

            // Initialising the api setup class to test
            IApiSetup api = new ApiSetup(logger, BuildConfiguration());

            return api;
        }

        [Theory]
        [InlineData("Secrets:Api.Uri", "https://localhost:7193/")]
        public void GetApiUri_ShouldRetrieveSuccessfully(string uriName, string expectedApiUri)
        {
            IApiSetup api = BuildApiSetup();

            // Running the method to retrieve the connection string
            string actualApiUri = api.GetApiUri(uriName);

            Assert.Equal(expectedApiUri, actualApiUri);
            Assert.False(string.IsNullOrEmpty(actualApiUri));
        }

        [Theory]
        [InlineData("")]
        [InlineData("InvalidUriName")]
        public void GetApiUri_ShouldThrowException(string uriName)
        {
            IApiSetup api = BuildApiSetup();

            Assert.Throws<InvalidOperationException>(() => api.GetApiUri(uriName));
        }
    }
}
