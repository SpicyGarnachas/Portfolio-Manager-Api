using SpicyGarnachas.InvestmentApi.Models;
namespace SpicyGarnachas.InvestmentApi.Services.Interfaces
{
    public interface IPortfolioService
    {
        Task<(bool IsSuccess, IEnumerable<PortfolioModel>?, string MessageError)> GetPortfolioData();
        Task<(bool IsSuccess, IEnumerable<PortfolioModel>?, string MessageError)> GetPortfolioById(int id);
        Task<(bool IsSuccess, string Message)> CreateNewPortfolio(int userId, string name, string description);
        Task<(bool IsSuccess, string Message)> ModifyPorfolio(int id, int userId, string name, string description);
        Task<(bool IsSuccess, string Message)> DeletePortfolio(int id, int userId);
    }
}
