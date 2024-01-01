namespace SpicyGarnachas.InvestmentApi.Services.Interfaces
{
    public interface IBusinessService
    {
        Task<(bool IsSuccess, Models.BusinessModel?, string MessageError)> GetBusinessData();
    }
}
