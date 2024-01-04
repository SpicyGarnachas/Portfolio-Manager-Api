using Dapper;
using SpicyGarnachas.InvestmentApi.Models;
using SpicyGarnachas.InvestmentApi.Repositories.Interfaces;

namespace SpicyGarnachas.InvestmentApi.Repositories.Test
{
    public class TestTransactionRepository : ITransactionRepository
    {
        private readonly ILogger<TestTransactionRepository> logger;

        public TestTransactionRepository(ILogger<TestTransactionRepository> logger)
        {
            this.logger = logger;
        }

        public async Task<(bool IsSuccess, IEnumerable<TransactionModel>?, string MessageError)> GetTransactionsData()
        {
            try
            {
                TransactionModel firstTransaction = new TransactionModel()
                {
                    id = 1,
                    investmentId = 1,
                    type = "Returns TEST",
                    date = DateTime.Now,
                    value = 565
                };
                TransactionModel secondTransaction = new TransactionModel()
                {
                    id = 2,
                    investmentId = 2,
                    type = "Returns TEST",
                    date = DateTime.Now,
                    value = 565
                };
                TransactionModel thirdTransaction = new TransactionModel()
                {
                    id = 3,
                    investmentId = 3,
                    type = "Returns TEST",
                    date = DateTime.Now,
                    value = 565
                };
                IEnumerable<TransactionModel>? result = new List<TransactionModel>() { firstTransaction, secondTransaction, thirdTransaction };
                await Task.Delay(0);
                return result.AsList().Count > 0 ? (IsSuccess: true, result, string.Empty) : (IsSuccess: false, null, "No data");
            }
            catch (Exception exceptionMessage)
            {
                logger.LogError(exceptionMessage.Message);
                return (false, null, exceptionMessage.Message);
            }
        }
        public async Task<(bool IsSuccess, IEnumerable<TransactionModel>?, string MessageError)> GetTransactionsDataByPortfolioId(int id)
        {
            try
            {
                TransactionModel firstTransaction = new TransactionModel()
                {
                    id = 1,
                    investmentId = 1,
                    type = "Returns TEST",
                    date = DateTime.Now,
                    value = 565
                };
                IEnumerable<TransactionModel>? result = new List<TransactionModel>() { firstTransaction };
                await Task.Delay(0);
                return result.AsList().Count > 0 ? (IsSuccess: true, result, string.Empty) : (IsSuccess: false, null, "No data");
            }
            catch (Exception exceptionMessage)
            {
                logger.LogError(exceptionMessage.Message);
                return (false, null, exceptionMessage.Message);
            }
        }
    }
}