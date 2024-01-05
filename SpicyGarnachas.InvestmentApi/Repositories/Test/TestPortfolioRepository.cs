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

        public async Task<(bool IsSuccess, IEnumerable<PortfolioModel>?, string Message)> GetPortfolioData()
        {
            try
            {
                PortfolioModel? portfolio = new PortfolioModel()
                {
                    id = 1,
                    name = "My fruit store TEST",
                    description = "Retail fruit store",
                    createdOn = DateTime.Now,
                    updatedOn = DateTime.Now,
                    userId = 1
                };
                IEnumerable<PortfolioModel>? result = new List<PortfolioModel>() { portfolio };
                await Task.Delay(0);
                return result.AsList().Count > 0 ? (IsSuccess: true, result, "TEST SUCCESS") : (IsSuccess: false, null, "No data");
            }
            catch (Exception exceptionMessage)
            {
                logger.LogError(exceptionMessage.Message);
                return (false, null, exceptionMessage.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<PortfolioModel>?, string Message)> GetPortfolioByUserId(int id)
        {
            try
            {
                PortfolioModel? portfolio = new PortfolioModel()
                {
                    id = 1,
                    name = "My fruit store TEST",
                    description = "Retail fruit store",
                    createdOn = DateTime.Now,
                    updatedOn = DateTime.Now,
                    userId = id
                };
                IEnumerable<PortfolioModel>? result = new List<PortfolioModel>() { portfolio };
                await Task.Delay(0);
                return result.AsList().Count > 0 ? (IsSuccess: true, result, "TEST SUCCESS") : (IsSuccess: false, null, "No data");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, string Message)> CreateNewPortfolio(int userId, string name, string description)
        {
            try
            {
                await Task.Delay(0);
                return (IsSuccess: true, Message: "Portfolio created successfully TEST");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, string Message)> ModifyPorfolio(int id, string sqlQuery)
        {
            try
            {
                await Task.Delay(0);
                return (IsSuccess: true, Message: "Portfolio updated successfully TEST");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, string Message)> DeletePortfolio(int id, int userId)
        {
            try
            {
                await Task.Delay(0);
                return (IsSuccess: true, Message: "Portfolio deleted successfully TEST");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, ex.Message);
            }
        }
    }
}