using Dapper;
using MySql.Data.MySqlClient;
using SpicyGarnachas.InvestmentApi.Models;
using SpicyGarnachas.InvestmentApi.Repositories.Interfaces;

namespace SpicyGarnachas.InvestmentApi.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ILogger<TransactionRepository> logger;
        private readonly IConfiguration _configuration;

        public TransactionRepository(ILogger<TransactionRepository> logger, IConfiguration configuration)
        {
            this.logger = logger;
            _configuration = configuration;
        }
        public async Task<(bool IsSuccess, IEnumerable<TransactionModel>?, string MessageError)> GetTransactionsData()
        {
            try
            {
                string? connectionString = _configuration["stringConnection"];

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM Transactions";
                    var transactions = await connection.QueryAsync<TransactionModel>(sqlQuery);
                    return transactions.AsList().Count > 0 ? (IsSuccess: true, transactions, string.Empty) : (IsSuccess: false, null, "No data");
                }
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
                string? connectionString = _configuration["stringConnection"];

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sqlQuery = $"SELECT * FROM Transactions WHERE investmentId = {id}";
                    var transactions = await connection.QueryAsync<TransactionModel>(sqlQuery);
                    return transactions.AsList().Count > 0 ? (IsSuccess: true, transactions, string.Empty) : (IsSuccess: false, null, "No data");
                }
            }
            catch (Exception exceptionMessage)
            {
                logger.LogError(exceptionMessage.Message);
                return (false, null, exceptionMessage.Message);
            }
        }
    }
}
