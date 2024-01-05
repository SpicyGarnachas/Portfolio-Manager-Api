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

        public async Task<(bool IsSuccess, IEnumerable<BusinessModel>?, string Message)> GetBusinessData()
        {
            try
            {
                var (IsSuccess, Result, MessageError) = await repository.GetBusinessData();
                return IsSuccess ? (true, Result, string.Empty) : (false, null, MessageError);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, null, ex.Message);
            }
        }
        public async Task<(bool IsSuccess, IEnumerable<BusinessModel>?, string Message)> GetBusinessDataByPortfolioId(int id)
        {
            try
            {
                var (IsSuccess, Result, MessageError) = await repository.GetBusinessDataByPortfolioId(id);
                return IsSuccess ? (true, Result, string.Empty) : (false, null, MessageError);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, string Message)> CreateNewBusiness(int portfolioId, string name, string description, string sector)
        {
            try
            {
                var (IsSuccess, Message) = await repository.CreateNewBusiness(portfolioId,  name,  description,  sector);
                return IsSuccess ? (true, string.Empty) : (false, Message);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, string Message)> ModifyBusiness(int id, int userId, string name, string description)
        {
            try
            {
                var (IsSuccess, Message) = await repository.ModifyBusiness(id, userId, name, description);
                return IsSuccess ? (true, string.Empty) : (false, Message);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, string Message)> DeleteBusiness(int id, int portfolioId)
        {
            try
            {
                var (IsSuccess, Message) = await repository.DeleteBusiness(id, portfolioId);
                return IsSuccess ? (true, string.Empty) : (false, Message);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, ex.Message);
            }
        }
    }
}

