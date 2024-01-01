using SpicyGarnachas.InvestmentApi.Repositories.Interfaces;

namespace SpicyGarnachas.InvestmentApi.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ILogger<TransactionRepository> logger;

        public TransactionRepository(ILogger<TransactionRepository> logger)
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
                    type = "Income",
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
