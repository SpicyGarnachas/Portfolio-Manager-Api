namespace SpicyGarnachas.InvestmentApi.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<(bool IsSuccess, Models.TransactionModel?, string MessageError)> GetTransactionsData();
    }
}
