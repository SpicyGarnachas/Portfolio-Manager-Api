using SpicyGarnachas.InvestmentApi.Models;

namespace SpicyGarnachas.InvestmentApi.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        Task<(bool IsSuccess, IEnumerable<TransactionModel>?, string Message)> GetTransactionsData();
        Task<(bool IsSuccess, IEnumerable<TransactionModel>?, string Message)> GetTransactionsDataByPortfolioId(int id);
    }
}