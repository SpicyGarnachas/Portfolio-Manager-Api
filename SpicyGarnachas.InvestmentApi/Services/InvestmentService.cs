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
                var (IsSuccess, Result, Message) = await repository.GetInvestmentData();
                return IsSuccess ? (true, Result, string.Empty) : (false, null, Message);
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
                var (IsSuccess, Result, Message) = await repository.GetInvestmentDataByPortfolioId(id);
                return IsSuccess ? (true, Result, string.Empty) : (false, null, Message);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, string Message)> CreateNewInvestment(int portfolioId, string name, string description, string platform, string type, string sector, int risk, int liquidity)
        {
            try
            {
                var (IsSuccess, Message) = await repository.CreateNewInvestment(portfolioId, name, description, platform, type, sector, risk, liquidity);
                return IsSuccess ? (true, Message) : (false, Message);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, string Message)> ModifyInvestment(int id, int portfolioId, string name, string description, string platform, string type, string sector, int risk, int liquidity)
        {
            try
            {
                bool isFirst = true;
                string sqlQuery = string.Empty;
                List<string> updateFields = new List<string>();

                if(name == null || name == string.Empty && description == null || description == string.Empty && platform == null || platform == string.Empty && type == null || type == string.Empty && sector == null || sector != string.Empty)
                {
                    return (false, "You must provide at least one field to update");
                }

                if(name != null || name != string.Empty)
                {
                    updateFields.Add($"name = '{name}'");
                }

                if(description != null || description != string.Empty)
                {
                    updateFields.Add($"description = '{description}'");
                }

                if(platform != null || platform != string.Empty)
                {
                    updateFields.Add($"platform = '{platform}'");
                }

                if(type != null || type != string.Empty)
                {
                    updateFields.Add($"type = '{type}'");
                }

                if(sector != null || sector != string.Empty)
                {
                    updateFields.Add($"sector = '{sector}'");
                }
                
                updateFields.Add($"risk = {risk}");
                updateFields.Add($"liquidity = {liquidity}");
                updateFields.Add($"updatedOn = NOW()");

                foreach (string field in updateFields)
                {
                    if (isFirst)
                    {
                        sqlQuery += $"UPDATE investment SET {field}";
                        isFirst = false;
                    }
                    else
                    {
                        sqlQuery += $", {field}";
                    }
                }

                sqlQuery += $" WHERE id = {id} AND portfolioId = {portfolioId}";

                var (IsSuccess, Message) = await repository.ModifyInvestment(id, sqlQuery);
                return IsSuccess.Equals(true) ? (true, Message) : (false, Message);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, ex.Message);
            }
        }
        
        public async Task<(bool IsSuccess, string Message)> DeleteInvestment(int id, int portfolioId)
        {
            try
            {
                var (IsSuccess, Message) = await repository.DeleteInvestment(id, portfolioId);
                return IsSuccess.Equals(true) ? (true, Message) : (false, Message);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, ex.Message);
            }
        }
    }
}