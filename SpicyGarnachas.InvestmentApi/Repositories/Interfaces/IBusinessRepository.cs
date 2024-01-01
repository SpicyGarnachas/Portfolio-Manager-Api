namespace SpicyGarnachas.InvestmentApi.Repositories.Interfaces
{
    public interface IBusinessRepository
    {
        Task<(bool IsSuccess, Models.BusinessModel?, string MessageError)> GetBusinessData();
    }
}
