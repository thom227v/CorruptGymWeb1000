using CorruptGymLibrary.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CorruptGymLibrary.SqlDataAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<SqlDataAccess> _logger;

        public SqlDataAccess(IConfiguration configuration, ILogger<SqlDataAccess> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "DefaultConnection")
        {
            string connectionString = _configuration.GetConnectionString(connectionId);
            
            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    _logger.LogInformation("Executing stored procedure: {StoredProcedure}", storedProcedure);
                    var data = await connection.QueryAsync<T>(
                        storedProcedure,
                        parameters,
                        commandType: CommandType.StoredProcedure);
                    return data;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing stored procedure: {StoredProcedure}", storedProcedure);
                throw;
            }
        }

        public async Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "DefaultConnection")
        {
            string connectionString = _configuration.GetConnectionString(connectionId);
            
            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    _logger.LogInformation("Executing stored procedure: {StoredProcedure} with parameters: {@Parameters}", storedProcedure, parameters);
                    await connection.ExecuteAsync(
                        storedProcedure,
                        parameters,
                        commandType: CommandType.StoredProcedure);
                    _logger.LogInformation("Successfully executed stored procedure: {StoredProcedure}", storedProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing stored procedure: {StoredProcedure} with parameters: {@Parameters}", storedProcedure, parameters);
                throw;
            }
        }
    }
}
