using SpicyGarnachas.InvestmentApi.Repositories.Interfaces;
using System;
using MySql.Data.MySqlClient;
using Microsoft.Data.SqlClient;
using SpicyGarnachas.InvestmentApi.Models;
using Dapper;

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

        public async Task<(bool IsSuccess, IEnumerable<PortfolioModel>?, string MessageError)> GetPortfolioData()
        {

            try
            {
                string? connectionString = _configuration["stringConnection"];

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM Portfolio";
                    var portfolio = await connection.QueryAsync<PortfolioModel>(sqlQuery);
                    return portfolio.AsList().Count > 0 ? (IsSuccess: true, portfolio, string.Empty) : (IsSuccess: false, null, "No data");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, null, ex.Message);
            }
        }

        Task<(bool IsSuccess, IEnumerable<PortfolioModel>?, string MessageError)> IPortfolioRepository.GetPortfolioData()
        {
            throw new NotImplementedException();
        }
    }
}
