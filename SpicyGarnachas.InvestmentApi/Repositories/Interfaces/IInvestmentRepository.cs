namespace SpicyGarnachas.InvestmentApi.Repositories.Interfaces
{
    public interface IInvestmentRepository
    {
        Task<(bool IsSuccess, Models.InvestmentModel?, string MessageError)> GetInvestmentData();
    }
}
