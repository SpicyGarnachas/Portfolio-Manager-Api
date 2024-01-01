namespace SpicyGarnachas.InvestmentApi.Services.Interfaces
{
    public interface IInvestmentService
    {
        Task<(bool IsSuccess, Models.InvestmentModel?, string MessageError)> GetInvestmentData();
    }
}
