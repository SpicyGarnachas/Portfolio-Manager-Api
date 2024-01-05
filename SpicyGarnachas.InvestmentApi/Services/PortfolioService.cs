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
        public async Task<(bool IsSuccess, IEnumerable<PortfolioModel>?, string Message)> GetPortfolioData()
        {
            try
            {
                var (IsSuccess, Result, MessageError) = await repository.GetPortfolioData();
                return IsSuccess ? (true, Result, string.Empty) : (false, null, MessageError);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, null, ex.Message);
            }
        }
        public async Task<(bool IsSuccess, IEnumerable<PortfolioModel>?, string Message)> GetPortfolioByUserId(int id)
        {
            try
            {
                var (IsSuccess, Result, MessageError) = await repository.GetPortfolioByUserId(id);
                return IsSuccess ? (true, Result, string.Empty) : (false, null, MessageError);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, string Message)> CreateNewPortfolio(int userId, string name, string description)
        {
            try
            {
                var (IsSuccess, Message) = await repository.CreateNewPortfolio(userId, name, description);
                return IsSuccess.Equals(true) ? (true, string.Empty) : (false, Message);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, string Message)> ModifyPorfolio(int id, int userId, string name, string description)
        {
            try
            {
                bool isFirst = true;
                string sqlQuery = string.Empty;
                List<string> updateFields = new List<string>();

                if (name != null || name != string.Empty)
                {
                    updateFields.Add($"name = '{name}'");
                }

                if (description != null || description != string.Empty)
                {
                    updateFields.Add($"description = '{description}'");
                }

                updateFields.Add($"updatedOn = NOW()");

                foreach (string field in updateFields)
                {
                    if (isFirst)
                    {
                        sqlQuery += $"UPDATE Portfolio SET {field}";
                        isFirst = false;
                    }
                    else
                    {
                        sqlQuery += $", {field}";
                    }
                }

                sqlQuery += $" WHERE id = {id} AND userId = {userId}";

                var (IsSuccess, Message) = await repository.ModifyPorfolio(id, sqlQuery);
                return IsSuccess.Equals(true) ? (true, string.Empty) : (false, Message);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, string Message)> DeletePortfolio(int id, int userId)
        {
            try
            {
                var (IsSuccess, Message) = await repository.DeletePortfolio(id, userId);
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