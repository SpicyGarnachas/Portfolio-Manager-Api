namespace SpicyGarnachas.InvestmentApi.Repositories.Interfaces
{
    public interface IPortfolioRepository
    {
        Task<(bool IsSuccess, Models.PortfolioModel?, string MessageError)> GetPortfolioData();
    }
}
