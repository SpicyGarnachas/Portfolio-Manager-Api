using SpicyGarnachas.InvestmentApi.Repositories;

namespace SpicyGarnachas.InvestmentApi.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IPortfolioRepository repository;
        private readonly ILogger<PortfolioService> logger;

        public PortfolioService(IPortfolioRepository repository, ILogger<PortfolioService> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<(bool IsSuccess, Models.PortfolioModel?, string MessageError)> GetPortfolioData()
        {
            try
            {
                var (IsSuccess, Result, MessageError) = await repository.GetPortfolioData();
                await Task.Delay(0);
                return IsSuccess ? (true, Result, string.Empty) : (false, null, MessageError);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, null, ex.Message);
            }
        }
    }
}

