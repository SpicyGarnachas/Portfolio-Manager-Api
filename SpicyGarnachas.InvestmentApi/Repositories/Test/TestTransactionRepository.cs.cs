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

        public async Task<(bool IsSuccess, Models.TransactionModel?, string MessageError)> GetTransactionsData()
        {
            try
            {
                Models.TransactionModel? transaction = new Models.TransactionModel()
                {
                    id = 1,
                    investmentId = 1,
                    type = "Income TEST",
                    date = DateTime.Now,
                    value = 565
                };
                await Task.Delay(0);
                return (transaction != null ? (true, transaction, string.Empty) : (false, null, "No data"));
            }
            catch (Exception exceptionMessage)
            {
                logger.LogError(exceptionMessage.Message);
                return (false, null, exceptionMessage.Message);
            }
        }
    }
}

