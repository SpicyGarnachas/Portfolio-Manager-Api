using SpicyGarnachas.InvestmentApi.Repositories;

namespace SpicyGarnachas.InvestmentApi.Services
{
    public class InvestmentService : IInvestmentService
    {
        private readonly IInvestmentRepository repository;
        private readonly ILogger<InvestmentService> logger;

        public InvestmentService(IInvestmentRepository repository, ILogger<InvestmentService> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<(bool IsSuccess, Models.InvestmentModel?, string MessageError)> GetInvestmentData()
        {
            try
            {
                var (IsSuccess, Result, MessageError) = await repository.GetInvestmentData();
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
