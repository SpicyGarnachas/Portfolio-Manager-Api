using SpicyGarnachas.InvestmentApi.Models;
using SpicyGarnachas.InvestmentApi.Repositories.Interfaces;
using SpicyGarnachas.InvestmentApi.Services.Interfaces;

namespace SpicyGarnachas.InvestmentApi.Services
{
    public class BusinessService : IBusinessService
    {
        private readonly IBusinessRepository repository;
        private readonly ILogger<BusinessService> logger;

        public BusinessService(IBusinessRepository repository, ILogger<BusinessService> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<(bool IsSuccess, IEnumerable<BusinessModel>?, string MessageError)> GetBusinessData()
        {
            try
            {
                var (IsSuccess, Result, MessageError) = await repository.GetBusinessData();
                await Task.Delay(0);
                return IsSuccess ? (true, Result, string.Empty) : (false, null, MessageError);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, null, ex.Message);
            }
        }
        public async Task<(bool IsSuccess, IEnumerable<BusinessModel>?, string MessageError)> GetBusinessDataByPortfolioId(int id)
        {
            try
            {
                var (IsSuccess, Result, MessageError) = await repository.GetBusinessDataByPortfolioId(id);
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

