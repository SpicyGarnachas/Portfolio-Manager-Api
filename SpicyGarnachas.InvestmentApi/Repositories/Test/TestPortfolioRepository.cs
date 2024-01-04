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
                PortfolioModel? portfolio = new PortfolioModel()
                {
                    id = 1,
                    name = "My fruit store",
                    description = "Retail fruit store",
                    createdOn = DateTime.Now,
                    updatedOn = DateTime.Now,
                    userId = 1
                };
                IEnumerable<PortfolioModel>? result = new List<PortfolioModel>() { portfolio };
                await Task.Delay(0);
                return result.AsList().Count > 0 ? (IsSuccess: true, result, string.Empty) : (IsSuccess: false, null, "No data");
            }
            catch (Exception exceptionMessage)
            {
                logger.LogError(exceptionMessage.Message);
                return (false, null, exceptionMessage.Message);
            }
        }
    }
}
