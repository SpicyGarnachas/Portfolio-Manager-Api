namespace SpicyGarnachas.InvestmentApi.Repositories
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly ILogger<PortfolioRepository> logger;

        public PortfolioRepository(ILogger<PortfolioRepository> logger)
        {
            this.logger = logger;
        }

        public async Task<(bool IsSuccess, Models.PortfolioModel?, string MessageError)> GetPortfolioData()
        {
            try
            {
                Models.PortfolioModel? portfolio = new Models.PortfolioModel()
                {
                    id = 1,
                    name = "My capital REAL",
                    description = "All my investments and business.",
                    version = "1"
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
