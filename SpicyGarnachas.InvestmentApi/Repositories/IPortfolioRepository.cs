namespace SpicyGarnachas.InvestmentApi.Repositories
{
    public interface IPortfolioRepository
    {
        Task<(bool IsSuccess, Models.PortfolioModel?, string MessageError)> GetPortfolioData();
    }
}
