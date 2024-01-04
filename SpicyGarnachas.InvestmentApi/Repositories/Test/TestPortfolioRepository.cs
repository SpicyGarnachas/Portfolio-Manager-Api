using SpicyGarnachas.InvestmentApi.Repositories.Interfaces;
using SpicyGarnachas.InvestmentApi.Models;
using MySql.Data.MySqlClient;
using Dapper;

namespace SpicyGarnachas.InvestmentApi.Repositories.Test
{
    public class TestPortfolioRepository : IPortfolioRepository
    {
        private readonly ILogger<TestPortfolioRepository> logger;
        private readonly IConfiguration _configuration;

        public TestPortfolioRepository(ILogger<TestPortfolioRepository> logger, IConfiguration configuration)
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
                    return portfolio.AsList().Count > 0 ? (IsSuccess: true, portfolio, string.Empty) : (IsSuccess: false, null, "No se encontraron resultados");
                }
            }
            catch (Exception exceptionMessage)
            {
                logger.LogError(exceptionMessage.Message);
                return (false, null, exceptionMessage.Message);
            }
        }
    }
}
