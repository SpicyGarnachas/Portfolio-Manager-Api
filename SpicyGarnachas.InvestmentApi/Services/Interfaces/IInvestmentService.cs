using SpicyGarnachas.InvestmentApi.Models;

namespace SpicyGarnachas.InvestmentApi.Services.Interfaces
{
    public interface IInvestmentService
    {
        Task<(bool IsSuccess, IEnumerable<InvestmentModel>?, string Message)> GetInvestmentData();
        Task<(bool IsSuccess, IEnumerable<InvestmentModel>?, string Message)> GetInvestmentDataByPortfolioId(int id);
        Task<(bool IsSuccess, string Message)>CreateNewInvestment(int portfolioId, string name, string description, string platform, string type, string sector, int risk, int liquidity);
        Task<(bool IsSuccess, string Message)> ModifyInvestment(int id, int portfolioId, string name, string description, string platform, string type, string sector, int risk, int liquidity);
    }
}
