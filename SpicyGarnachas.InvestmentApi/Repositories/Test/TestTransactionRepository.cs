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

        public async Task<(bool IsSuccess, IEnumerable<TransactionModel>?, string Message)> GetTransactionsData()
        {
            try
            {
                TransactionModel firstTransaction = new TransactionModel()
                {
                    id = 1,
                    referenceId = 1,
                    type = "Returns TEST",
                    description = "TEST",
                    category = "TEST",
                    value = 565,
                    image = null,
                    createdOn = DateTime.Now,
                    updatedOn = DateTime.Now
                };
                TransactionModel secondTransaction = new TransactionModel()
                {
                    id = 2,
                    referenceId = 1,
                    type = "Returns TEST",
                    description = "TEST",
                    category = "TEST",
                    value = 565,
                    image = null,
                    createdOn = DateTime.Now,
                    updatedOn = DateTime.Now
                };
                TransactionModel thirdTransaction = new TransactionModel()
                {
                    id = 3,
                    referenceId = 1,
                    type = "Returns TEST",
                    description = "TEST",
                    category = "TEST",
                    value = 565,
                    image = null,
                    createdOn = DateTime.Now,
                    updatedOn = DateTime.Now
                };
                IEnumerable<TransactionModel>? result = new List<TransactionModel>() { firstTransaction, secondTransaction, thirdTransaction };
                await Task.Delay(0);
                return result.AsList().Count > 0 ? (IsSuccess: true, result, "TEST SUCCESS") : (IsSuccess: false, null, "Database without Transactions TEST");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, null, ex.Message);
            }
        }
        
        public async Task<(bool IsSuccess, IEnumerable<TransactionModel>?, string Message)> GetTransactionsDataByPortfolioId(int id)
        {
            try
            {
                TransactionModel firstTransaction = new TransactionModel()
                {
                    id = 1,
                    referenceId = 1,
                    type = "Returns TEST",
                    value = 565,
                    createdOn = DateTime.Now,
                    updatedOn = DateTime.Now
                };
                IEnumerable<TransactionModel>? result = new List<TransactionModel>() { firstTransaction };
                await Task.Delay(0);
                return result.AsList().Count > 0 ? (IsSuccess: true, result, "TEST SUCCESS") : (IsSuccess: false, null, "User has no Transactions in this portfolio TEST");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, null, ex.Message);
            }
        }
    }
}