using SpicyGarnachas.InvestmentApi.Models;

namespace SpicyGarnachas.InvestmentApi.Services.Interfaces
{
    public interface IInvestmentService
    {
        Task<(bool IsSuccess, IEnumerable<InvestmentModel>?, string Message)> GetInvestmentData();
        Task<(bool IsSuccess, IEnumerable<InvestmentModel>?, string Message)> GetInvestmentDataByPortfolioId(int id);
    }
}
