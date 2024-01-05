using Dapper;
using SpicyGarnachas.InvestmentApi.Models;
using SpicyGarnachas.InvestmentApi.Repositories.Interfaces;

namespace SpicyGarnachas.InvestmentApi.Repositories.Test
{
    public class TestBusinessRepository : IBusinessRepository
    {
        private readonly ILogger<TestBusinessRepository> logger;

        public TestBusinessRepository(ILogger<TestBusinessRepository> logger)
        {
            this.logger = logger;
        }

        public async Task<(bool IsSuccess, IEnumerable<BusinessModel>?, string Message)> GetBusinessData()
        {
            try
            {
                BusinessModel? business = new BusinessModel()
                {
                    id = 1,
                    portfolioId = 2,
                    name = "My fruit store TEST",
                    description = "Retail fruit store",
                    sector = "Retail"
                };
                await Task.Delay(0);
                IEnumerable<BusinessModel>? result = new List<BusinessModel>() { business };
                await Task.Delay(0);
                return result.AsList().Count > 0 ? (IsSuccess: true, result, "TEST SUCCESS") : (IsSuccess: false, null, "No data");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<BusinessModel>?, string Message)> GetBusinessDataByPortfolioId(int id)
        {
            try
            {
                BusinessModel? business = new BusinessModel()
                {
                    id = 1,
                    portfolioId = id,
                    name = "My fruit store TEST",
                    description = "Retail fruit store",
                    sector = "Retail"
                };
                await Task.Delay(0);
                IEnumerable<BusinessModel>? result = new List<BusinessModel>() { business };
                await Task.Delay(0);
                return result.AsList().Count > 0 ? (IsSuccess: true, result, "TEST SUCCESS") : (IsSuccess: false, null, "No data");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, string Message)> CreateNewBusiness(int portfolioId, string name, string description, string sector)
        {
            try
            {
                await Task.Delay(0);
                return (IsSuccess: true, Message: "Business created successfully TEST");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, string Message)> ModifyBusiness(int id, string sqlQuery)
        {
            try
            {
                await Task.Delay(0);
                return (IsSuccess: true, Message: "Business modified successfully TEST");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, string Message)> DeleteBusiness(int id, int portfolioId)
        {
            try
            {
                await Task.Delay(0);
                return (IsSuccess: true, Message: "Business deleted successfully TEST");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, ex.Message);
            }
        }
        
    }
}