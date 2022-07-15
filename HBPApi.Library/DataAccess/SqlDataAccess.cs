using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBPApi.Library.DataAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly ILogger<SqlDataAccess> _logger;
        private readonly IConfiguration _config;

        public SqlDataAccess(ILogger<SqlDataAccess> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        /// <summary>
        /// Retrieves a connection found in the configuration file.
        /// </summary>
        /// <param name="name">The key of the connection string</param>
        /// <returns>The full connection string</returns>
        public string GetConnectionString(string name)
        {
            string connectionString = _config.GetConnectionString(name);

            if (string.IsNullOrEmpty(connectionString) == true)
            {
                _logger.LogWarning("Failed to retrieve connection string {Name} from configuration settings at {Time}", 
                    name, DateTime.UtcNow);
                throw new InvalidOperationException($"The configuration setting for the database could not be found.");
            }

            return connectionString;
        }

        /// <summary>
        /// Retrieves data from a database.
        /// </summary>
        /// <typeparam name="T">The type of data to retrieve</typeparam>
        /// <typeparam name="U">The type of parameters used</typeparam>
        /// <param name="storedProcedure">The stored procedure to execute</param>
        /// <param name="parameters">Any additional parameters to execute</param>
        /// <param name="connectionStringName">The database to query</param>
        /// <returns>A sequence of data.</returns>
        public async Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName)
        {
            using (IDbConnection connection = new SqlConnection(GetConnectionString(connectionStringName)))
            {
                try
                {
                    var data = await connection.QueryAsync<T>(storedProcedure, parameters,
                    commandType: CommandType.StoredProcedure);

                    return data.ToList();
                }
                catch (DataException ex)
                {
                    _logger.LogError(ex, "Could not establish connection with database {ConnectionString} at {Time}", 
                        connectionStringName, DateTime.UtcNow);
                    throw;
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "An error occured while querying {Storedprocedure} with database: {ConnectionString} at {Time}", 
                        connectionStringName, storedProcedure, DateTime.UtcNow);
                    throw;
                }
            }
        }

        /// <summary>
        /// Saves data to a database.
        /// </summary>
        /// <typeparam name="T">The type of data to retrieve</typeparam>
        /// <param name="storedProcedure">The stored procedure to execute</param>
        /// <param name="parameters">Any additional parameters to execute</param>
        /// <param name="connectionStringName">The database to query</param>
        /// <returns></returns>
        public async Task SaveData<T>(string storedProcedure, T parameters, string connectionStringName)
        {
            using (IDbConnection connection = new SqlConnection(GetConnectionString(connectionStringName)))
            {
                try
                {
                    await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                }
                catch (DataException ex)
                {
                    _logger.LogError(ex, "Could not establish connection with database {ConnectionString} at {Time}", 
                        connectionStringName, DateTime.UtcNow);
                    throw;
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "An error occured while querying {Storedprocedure} with database: {ConnectionString} at {Time}", 
                        connectionStringName, storedProcedure, DateTime.UtcNow);
                    throw;
                }
            }
        }
    }
}
