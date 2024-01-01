namespace SpicyGarnachas.InvestmentApi.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<(bool IsSuccess, List<Models.TransactionModel>?, string MessageError)> GetTransactionsData();
    }
}
