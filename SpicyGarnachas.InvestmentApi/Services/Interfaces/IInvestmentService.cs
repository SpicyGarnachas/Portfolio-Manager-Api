using SpicyGarnachas.InvestmentApi.Models;

namespace SpicyGarnachas.InvestmentApi.Services.Interfaces
{
    public interface IInvestmentService
    {
        Task<(bool IsSuccess, IEnumerable<InvestmentModel>?, string MessageError)> GetInvestmentData();
        Task<(bool IsSuccess, IEnumerable<InvestmentModel>?, string MessageError)> GetInvestmentDataByPortfolioId(int id);
    }
}
