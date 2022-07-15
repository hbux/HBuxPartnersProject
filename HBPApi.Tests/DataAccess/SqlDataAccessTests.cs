using HBPApi.Library.DataAccess;
using HBPApi.Library.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HBPApi.Tests.DataAccess
{
    public class SqlDataAccessTests
    {
        private IConfiguration BuildConfiguration()
        {
            // Creates the configuration class using in-memory settings for SqlDataAccess constructor
            var inMemorySettings = new Dictionary<string, string> {
                {"ConnectionStrings:DefaultConnection", @"Server=(localdb)\\mssqllocaldb;Database=HBPAuthData;Trusted_Connection=True;MultipleActiveResultSets=true"},
                {"ConnectionStrings:HBPData", @"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HBPData;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"}
            };

            IConfiguration config = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            return config;
        }

        private ISqlDataAccess BuildDataAccess()
        {
            // Mocks the logger class for SqlDataAccess contructor
            var mockLogger = new Mock<ILogger<SqlDataAccess>>();
            ILogger<SqlDataAccess> logger = mockLogger.Object;

            // Initialising the data access class to test
            ISqlDataAccess dataAccess = new SqlDataAccess(logger, BuildConfiguration());

            return dataAccess;
        }

        [Theory]
        [InlineData("DefaultConnection", @"Server=(localdb)\\mssqllocaldb;Database=HBPAuthData;Trusted_Connection=True;MultipleActiveResultSets=true")]
        [InlineData("HBPData", @"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HBPData;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")]
        public void GetConnectionString_ShouldRetrieveSuccessfully(string connectionStringName ,string expectedConnectionString)
        {
            ISqlDataAccess dataAccess = BuildDataAccess();

            // Running the method to retrieve the connection string
            string actualConnectionString = dataAccess.GetConnectionString(connectionStringName);

            Assert.Equal(expectedConnectionString, actualConnectionString);
            Assert.False(string.IsNullOrEmpty(actualConnectionString));
        }

        [Theory]
        [InlineData("InvalidConnectionStringName")]
        [InlineData("")]
        public void GetConnectionString_ShouldThrowException(string connectionStringName)
        {
            ISqlDataAccess dataAccess = BuildDataAccess();

            Assert.Throws<InvalidOperationException>(() => dataAccess.GetConnectionString(connectionStringName));
        }
    }
}
