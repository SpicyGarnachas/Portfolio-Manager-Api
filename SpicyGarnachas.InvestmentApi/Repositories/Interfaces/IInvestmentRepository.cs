using SpicyGarnachas.InvestmentApi.Models;

namespace SpicyGarnachas.InvestmentApi.Repositories.Interfaces
{
    public interface IInvestmentRepository
    {
        Task<(bool IsSuccess, IEnumerable<InvestmentModel>?, string Message)> GetInvestmentData();
        Task<(bool IsSuccess, IEnumerable<InvestmentModel>?, string Message)> GetInvestmentDataByPortfolioId(int id);
    }
}
