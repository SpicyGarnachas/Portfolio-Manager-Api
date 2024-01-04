using SpicyGarnachas.InvestmentApi.Models;

namespace SpicyGarnachas.InvestmentApi.Repositories.Interfaces
{
    public interface IInvestmentRepository
    {
        Task<(bool IsSuccess, IEnumerable<InvestmentModel>?, string MessageError)> GetInvestmentData();
        Task<(bool IsSuccess, IEnumerable<InvestmentModel>?, string MessageError)> GetInvestmentDataByPortfolioId(int id);
    }
}
