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

        public async Task<(bool IsSuccess, Models.BusinessModel?, string MessageError)> GetBusinessData()
        {
            try
            {
                Models.BusinessModel? business = new Models.BusinessModel()
                {
                    id = 1,
                    portfolioId = 1,
                    name = "My fruit store TEST",
                    description = "Retail fruit store",
                    sector = "Retail"
                };
                await Task.Delay(0);
                return (business != null ? (true, business, string.Empty) : (false, null, "No data"));
            }
            catch (Exception exceptionMessage)
            {
                logger.LogError(exceptionMessage.Message);
                return (false, null, exceptionMessage.Message);
            }
        }
    }
}

