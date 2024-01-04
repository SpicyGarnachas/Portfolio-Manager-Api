using SpicyGarnachas.InvestmentApi.Models;

namespace SpicyGarnachas.InvestmentApi.Repositories.Interfaces
{
    public interface IBusinessRepository
    {
        Task<(bool IsSuccess, IEnumerable<BusinessModel>?, string MessageError)> GetBusinessData();
        Task<(bool IsSuccess, IEnumerable<BusinessModel>?, string MessageError)> GetBusinessDataByPortfolioId(int id);
    }
}
