namespace SpicyGarnachas.InvestmentApi.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        Task<(bool IsSuccess, Models.TransactionModel?, string MessageError)> GetTransactionsData();
    }
}
