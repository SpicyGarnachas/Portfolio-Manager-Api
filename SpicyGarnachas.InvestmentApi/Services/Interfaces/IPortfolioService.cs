namespace SpicyGarnachas.InvestmentApi.Services.Interfaces
{
    public interface IPortfolioService
    {
        Task<(bool IsSuccess, Models.PortfolioModel?, string MessageError)> GetPortfolioData();
    }
}
