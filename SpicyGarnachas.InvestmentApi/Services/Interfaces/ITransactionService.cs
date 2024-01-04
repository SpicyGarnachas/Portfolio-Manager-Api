using SpicyGarnachas.InvestmentApi.Models;

namespace SpicyGarnachas.InvestmentApi.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<(bool IsSuccess, IEnumerable<TransactionModel>?, string MessageError)> GetTransactionsData();
    }
}
