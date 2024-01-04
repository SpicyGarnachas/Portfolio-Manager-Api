using SpicyGarnachas.InvestmentApi.Repositories.Interfaces;
using SpicyGarnachas.InvestmentApi.Models;
using Dapper;

namespace SpicyGarnachas.InvestmentApi.Repositories.Test
{
    public class TestPortfolioRepository : IPortfolioRepository
    {
        private readonly ILogger<TestPortfolioRepository> logger;

        public TestPortfolioRepository(ILogger<TestPortfolioRepository> logger)
        {
            this.logger = logger;
        }

        public async Task<(bool IsSuccess, IEnumerable<PortfolioModel>?, string MessageError)> GetPortfolioData()
        {
            try
            {
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
        
        public async Task<(bool IsSuccess, IEnumerable<PortfolioModel>?, string MessageError)> GetPortfolioById(int id)
        {
            try
            {
                PortfolioModel? portfolio = new PortfolioModel()
                {
                    id = 1,
                    name = "My fruit store",
                    description = "Retail fruit store",
                    createdOn = DateTime.Now,
                    updatedOn = DateTime.Now,
                    userId = id
                };
                IEnumerable<PortfolioModel>? result = new List<PortfolioModel>() { portfolio };
                await Task.Delay(0);
                return result.AsList().Count > 0 ? (IsSuccess: true, result, string.Empty) : (IsSuccess: false, null, "No data");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, null, ex.Message);
            }
        }
    }
}
