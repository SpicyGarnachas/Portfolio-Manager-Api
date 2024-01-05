using SpicyGarnachas.InvestmentApi.Models;

namespace SpicyGarnachas.InvestmentApi.Repositories.Interfaces
{
    public interface IBusinessRepository
    {
        Task<(bool IsSuccess, IEnumerable<BusinessModel>?, string MessageError)> GetBusinessData();
        Task<(bool IsSuccess, IEnumerable<BusinessModel>?, string MessageError)> GetBusinessDataByPortfolioId(int id);
        Task<(bool IsSuccess, string Message)> CreateNewBusiness(int portfolioId, string name, string description, string sector);
        Task<(bool IsSuccess, string Message)> DeleteBusiness(int id, int portfolioId);
    }
}
