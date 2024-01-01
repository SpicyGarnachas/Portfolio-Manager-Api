namespace SpicyGarnachas.InvestmentApi.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        Task<(bool IsSuccess, List<Models.TransactionModel>?, string MessageError)> GetTransactionsData();
    }
}
