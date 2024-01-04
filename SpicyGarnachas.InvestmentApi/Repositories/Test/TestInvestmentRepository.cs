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

        public async Task<(bool IsSuccess, IEnumerable<InvestmentModel>?, string MessageError)> GetInvestmentData()
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
                return result.AsList().Count > 0 ? (IsSuccess: true, result, string.Empty) : (IsSuccess: false, null, "No data");
            }
            catch (Exception exceptionMessage)
            {
                logger.LogError(exceptionMessage.Message);
                return (false, null, exceptionMessage.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<InvestmentModel>?, string MessageError)> GetInvestmentDataByPortfolioId(int id)
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
