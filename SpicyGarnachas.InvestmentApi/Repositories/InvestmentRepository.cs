using SpicyGarnachas.InvestmentApi.Repositories.Interfaces;

namespace SpicyGarnachas.InvestmentApi.Repositories
{
    public class InvestmentRepository : IInvestmentRepository
    {
        private readonly ILogger<InvestmentRepository> logger;

        public InvestmentRepository(ILogger<InvestmentRepository> logger)
        {
            this.logger = logger;
        }

        public async Task<(bool IsSuccess, Models.InvestmentModel?, string MessageError)> GetInvestmentData()
        {
            try
            {
                Models.InvestmentModel? portfolio = new Models.InvestmentModel()
                {
                    id = 1,
                    portfolioId = 1,
                    name="Bank Account",
                    description="my default account",
                    platform="Bank of the world",
                    type="Bank",
                    sector="Financials",
                    risk=1,
                    liquidity=1

                };
                await Task.Delay(0);
                return (portfolio != null ? (true, portfolio, string.Empty) : (false, null, "No data"));
            }
            catch (Exception exceptionMessage)
            {
                logger.LogError(exceptionMessage.Message);
                return (false, null, exceptionMessage.Message);
            }
        }
    }
}

