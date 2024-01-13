using SpicyGarnachas.InvestmentApi.Models;

namespace SpicyGarnachas.InvestmentApi.Services.Interfaces
{
    public interface IInvestmentService
    {
        Task<(bool IsSuccess, IEnumerable<InvestmentModel>?, string Message)> GetInvestmentData();
        Task<(bool IsSuccess, IEnumerable<InvestmentModel>?, string Message)> GetInvestmentDataByPortfolioId(int id);
        Task<(bool IsSuccess, string Message)> CreateNewInvestment(InvestmentModel invest);
        Task<(bool IsSuccess, string Message)> ModifyInvestment(InvestmentModel investment);
        Task<(bool IsSuccess, string Message)> DeleteInvestment(int id, int portfolioId);
    }
}