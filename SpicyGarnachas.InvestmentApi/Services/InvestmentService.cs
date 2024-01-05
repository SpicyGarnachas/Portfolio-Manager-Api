using SpicyGarnachas.InvestmentApi.Models;
using SpicyGarnachas.InvestmentApi.Repositories.Interfaces;
using SpicyGarnachas.InvestmentApi.Services.Interfaces;

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

        public async Task<(bool IsSuccess, IEnumerable<InvestmentModel>?, string Message)> GetInvestmentData()
        {
            try
            {
                var (IsSuccess, Result, MessageError) = await repository.GetInvestmentData();
                return IsSuccess ? (true, Result, string.Empty) : (false, null, MessageError);
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
                var (IsSuccess, Result, MessageError) = await repository.GetInvestmentDataByPortfolioId(id);
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
