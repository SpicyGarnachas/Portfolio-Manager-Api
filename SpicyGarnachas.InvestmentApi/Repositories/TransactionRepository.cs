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

        public async Task<(bool IsSuccess, List<Models.TransactionModel>?, string MessageError)> GetTransactionsData()
        {
            try
            {
                List<Models.TransactionModel> transactions = new List<Models.TransactionModel>();
                transactions.Add(new Models.TransactionModel()
                {
                    id = 1,
                    investmentId = 1,
                    type = "Income",
                    date = DateTime.Now,
                    value = 565
                });
                transactions.Add(new Models.TransactionModel()
                {
                    id = 2,
                    investmentId = 1,
                    type = "Expense",
                    date = DateTime.Now,
                    value = 565
                });
                transactions.Add(new Models.TransactionModel()
                {
                    id = 3,
                    investmentId = 1,
                    type = "Returns",
                    date = DateTime.Now,
                    value = 565
                });
                await Task.Delay(0);
                return (transactions != null ? (true, transactions, string.Empty) : (false, null, "No data"));
            }
            catch (Exception exceptionMessage)
            {
                logger.LogError(exceptionMessage.Message);
                return (false, null, exceptionMessage.Message);
            }
        }
    }
}
