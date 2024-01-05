using SpicyGarnachas.InvestmentApi.Models;

namespace SpicyGarnachas.InvestmentApi.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<(bool IsSuccess, IEnumerable<TransactionModel>?, string Message)> GetTransactionsData();
        Task<(bool IsSuccess, IEnumerable<TransactionModel>?, string Message)> GetTransactionsDataByPortfolioId(int id);
    }
}