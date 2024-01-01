namespace SpicyGarnachas.InvestmentApi.Services
{
    public interface IPortfolioService
    {
        Task<(bool IsSuccess, Models.PortfolioModel?, string MessageError)> GetPortfolioData();
    }
}
