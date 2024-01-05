using SpicyGarnachas.InvestmentApi.Repositories.Interfaces;
using SpicyGarnachas.InvestmentApi.Services.Interfaces;
using SpicyGarnachas.InvestmentApi.Models;

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
        public async Task<(bool IsSuccess, IEnumerable<PortfolioModel>?, string MessageError)> GetPortfolioData()
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
        public async Task<(bool IsSuccess, IEnumerable<PortfolioModel>?, string MessageError)> GetPortfolioById(int id)
        {
            try
            {
                var (IsSuccess, Result, MessageError) = await repository.GetPortfolioById(id);
                await Task.Delay(0);
                return IsSuccess ? (true, Result, string.Empty) : (false, null, MessageError);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, string Message)> CreateNewPortfolio(int userId, string name, string description, DateTime createdOn, DateTime updatedOn)
        {
            try
            {
                var (IsSuccess, Message) = await repository.CreateNewPortfolio(userId, name, description, createdOn, updatedOn);
                await Task.Delay(0);
                return IsSuccess.Equals(true) ? (true, string.Empty) : (false, Message);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, ex.Message);
            }
        }
    }
}