using SpicyGarnachas.InvestmentApi.Models;

namespace SpicyGarnachas.InvestmentApi.Services.Interfaces
{
    public interface IBusinessService
    {
        Task<(bool IsSuccess, IEnumerable<BusinessModel>?, string Message)> GetBusinessData();
        Task<(bool IsSuccess, IEnumerable<BusinessModel>?, string Message)> GetBusinessDataByPortfolioId(int id);
        Task<(bool IsSuccess, string Message)> CreateNewBusiness(int portfolioId, string name, string description, string sector);
        Task<(bool IsSuccess, string Message)> ModifyBusiness(int id, int userId, string name, string description);
        Task<(bool IsSuccess, string Message)> DeleteBusiness(int id, int portfolioId);
    }
}
