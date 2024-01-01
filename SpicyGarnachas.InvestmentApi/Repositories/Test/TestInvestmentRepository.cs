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

        public async Task<(bool IsSuccess, Models.InvestmentModel?, string MessageError)> GetInvestmentData()
        {
            try
            {
                Models.InvestmentModel? investment = new Models.InvestmentModel()
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
                await Task.Delay(0);
                return (investment != null ? (true, investment, string.Empty) : (false, null, "No data"));
            }
            catch (Exception exceptionMessage)
            {
                logger.LogError(exceptionMessage.Message);
                return (false, null, exceptionMessage.Message);
            }
        }
    }
}
