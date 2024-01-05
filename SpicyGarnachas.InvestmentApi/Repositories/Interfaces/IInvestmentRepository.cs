using SpicyGarnachas.InvestmentApi.Models;

namespace SpicyGarnachas.InvestmentApi.Repositories.Interfaces
{
    public interface IInvestmentRepository
    {
        Task<(bool IsSuccess, IEnumerable<InvestmentModel>?, string Message)> GetInvestmentData();
        Task<(bool IsSuccess, IEnumerable<InvestmentModel>?, string Message)> GetInvestmentDataByPortfolioId(int id);
        Task<(bool IsSuccess, string Message)> CreateNewInvestment(int portfolioId, string name, string description, string platform, string type, string sector, int risk, int liquidity);
        Task<(bool IsSuccess, string Message)> ModifyInvestment(int id, string sqlQuery);
        Task<(bool IsSuccess, string Message)> DeleteInvestment(int id, int portfolioId);
    }
}