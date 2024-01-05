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
                var (IsSuccess, Result, Message) = await repository.GetBusinessData();
                return IsSuccess ? (true, Result, Message) : (false, null, Message);
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
                var (IsSuccess, Result, Message) = await repository.GetBusinessDataByPortfolioId(id);
                return IsSuccess ? (true, Result, Message) : (false, null, Message);
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
                var (IsSuccess, Message) = await repository.CreateNewBusiness(portfolioId, name, description, sector);
                return IsSuccess ? (true, Message) : (false, Message);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, string Message)> ModifyBusiness(int id, int portfolioId, string name, string description, string sector)
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
                if (sector != null || sector != string.Empty)
                {
                    updateFields.Add($"sector = '{sector}'");
                }

                updateFields.Add($"updatedOn = NOW()");

                foreach (string field in updateFields)
                {
                    if (isFirst)
                    {
                        sqlQuery += $"UPDATE Business SET {field}";
                        isFirst = false;
                    }
                    else
                    {
                        sqlQuery += $", {field}";
                    }
                }

                sqlQuery += $" WHERE id = {id} AND portfolioId = {portfolioId}";

                var (IsSuccess, Message) = await repository.ModifyBusiness(id, sqlQuery);
                return IsSuccess ? (true, Message) : (false, Message);
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
                return IsSuccess ? (true, Message) : (false, Message);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, ex.Message);
            }
        }
    }
}