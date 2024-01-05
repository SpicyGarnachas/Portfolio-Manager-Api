using Dapper;
using SpicyGarnachas.InvestmentApi.Models;
using SpicyGarnachas.InvestmentApi.Repositories.Interfaces;

namespace SpicyGarnachas.InvestmentApi.Repositories.Test
{
    public class TestInvestmentRepository : IInvestmentRepository
    {
        private readonly ILogger<TestInvestmentRepository> logger;

        public TestInvestmentRepository(ILogger<TestInvestmentRepository> logger)
        {
            this.logger = logger;
        }

        public async Task<(bool IsSuccess, IEnumerable<InvestmentModel>?, string Message)> GetInvestmentData()
        {
            try
            {
                InvestmentModel? investment = new InvestmentModel()
                {
                    id = 1,
                    portfolioId = 1,
                    name = "Bank Account TEST",
                    description = "my default account",
                    platform = "Bank of the world",
                    type = "Bank",
                    sector = "Financials",
                    risk = 1,
                    liquidity = 1
                };
                IEnumerable<InvestmentModel>? result = new List<InvestmentModel>() { investment };
                await Task.Delay(0);
                return result.AsList().Count > 0 ? (IsSuccess: true, result, "TEST SUCCESS") : (IsSuccess: false, null, "No data");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<InvestmentModel>?, string Message)> GetInvestmentDataByPortfolioId(int id)
        {
            try
            {
                InvestmentModel? investment = new InvestmentModel()
                {
                    id = 1,
                    portfolioId = id,
                    name = "Bank Account TEST",
                    description = "my default account",
                    platform = "Bank of the world",
                    type = "Bank",
                    sector = "Financials",
                    risk = 1,
                    liquidity = 1
                };
                IEnumerable<InvestmentModel>? result = new List<InvestmentModel>() { investment };
                await Task.Delay(0);
                return result.AsList().Count > 0 ? (IsSuccess: true, result, "TEST SUCCESS") : (IsSuccess: false, null, "No data");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, string Message)> CreateNewInvestment(int portfolioId, string name, string description, string platform, string type, string sector, int risk, int liquidity)
        {
            try
            {
                await Task.Delay(0);
                return (true, "Investment created successfully TEST");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, string Message)> ModifyInvestment(int id, string sqlQuery)
        {
            try
            {
                await Task.Delay(0);
                return (true, "Investment updated successfully TEST");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, string Message)> DeleteInvestment(int id, int portfolioId)
        {
            try
            {
                await Task.Delay(0);
                return (true, "Investment deleted successfully TEST");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, ex.Message);
            }
        }
    }
}