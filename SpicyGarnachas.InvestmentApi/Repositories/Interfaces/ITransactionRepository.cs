using SpicyGarnachas.InvestmentApi.Models;

namespace SpicyGarnachas.InvestmentApi.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        Task<(bool IsSuccess, IEnumerable<TransactionModel>?, string MessageError)> GetTransactionsData();
    }
}
