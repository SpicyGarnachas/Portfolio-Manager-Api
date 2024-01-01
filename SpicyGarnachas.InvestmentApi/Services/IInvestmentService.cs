namespace SpicyGarnachas.InvestmentApi.Services
{
    public interface IInvestmentService
    {
        Task<(bool IsSuccess, Models.InvestmentModel?, string MessageError)> GetInvestmentData();
    }
}
