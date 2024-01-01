namespace SpicyGarnachas.InvestmentApi.Repositories
{
    public interface IInvestmentRepository
    {
        Task<(bool IsSuccess, Models.InvestmentModel?, string MessageError)> GetInvestmentData();
    }
}
