using SpicyGarnachas.InvestmentApi.Repositories.Interfaces;
using System;
using Microsoft.Data.SqlClient;

namespace SpicyGarnachas.InvestmentApi.Repositories
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly ILogger<PortfolioRepository> logger;
        private readonly IConfiguration _configuration;

        public PortfolioRepository(ILogger<PortfolioRepository> logger, IConfiguration configuration)
        {
            this.logger = logger;
            _configuration = configuration;
        }

        public async Task<(bool IsSuccess, Models.PortfolioModel?, string MessageError)> GetPortfolioData()
        {
            string? connectionString = _configuration["stringConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT * FROM Portfolio";
                    using SqlCommand command = new SqlCommand(sql, connection);
                    using SqlDataReader dataReader = await command.ExecuteReaderAsync();
                    Models.PortfolioModel? portfolio = null;
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            portfolio = new Models.PortfolioModel()
                            {
                                id = Convert.ToInt32(dataReader["id"]),
                                name = Convert.ToString(dataReader["name"]),
                                description = Convert.ToString(dataReader["description"]),
                                version = Convert.ToString(dataReader["version"])
                            };
                            
                        }
                        connection.Close();
                        return (portfolio != null ? (true, portfolio, string.Empty) : (false, null, "No data"));
                    }
                    else
                    {
                        connection.Close();
                        return (false, null, "No data");
                    }
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message);
                    return (false, null, ex.Message);
                }
            }
        }
    }
}
