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
        public async Task<(bool IsSuccess, IEnumerable<TransactionModel>?, string Message)> GetTransactionsData()
        {
            try
            {
                string? connectionString = _configuration["stringConnection"];

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM Transaction";
                    var transactions = await connection.QueryAsync<TransactionModel>(sqlQuery);
                    return transactions.AsList().Count > 0 ? (IsSuccess: true, transactions, string.Empty) : (IsSuccess: false, null, "Database without Transactions");
                }
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
                string? connectionString = _configuration["stringConnection"];

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sqlQuery = $"SELECT * FROM Transaction WHERE portfolioId = {id}";
                    var transactions = await connection.QueryAsync<TransactionModel>(sqlQuery);
                    return transactions.AsList().Count > 0 ? (IsSuccess: true, transactions, string.Empty) : (IsSuccess: false, null, "User has no Transactions in this portfolio");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, null, ex.Message);
            }
        }
    }
}