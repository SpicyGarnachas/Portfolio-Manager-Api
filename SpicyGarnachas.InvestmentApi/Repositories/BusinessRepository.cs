using SpicyGarnachas.InvestmentApi.Models;
using SpicyGarnachas.InvestmentApi.Repositories.Interfaces;
using Dapper;
using MySql.Data.MySqlClient;

namespace SpicyGarnachas.InvestmentApi.Repositories
{
    public class BusinessRepository : IBusinessRepository
    {
        private readonly ILogger<BusinessRepository> logger;
        private readonly IConfiguration _configuration;

        public BusinessRepository(ILogger<BusinessRepository> logger, IConfiguration configuration)
        {
            this.logger = logger;
            _configuration = configuration;
        }

        public async Task<(bool IsSuccess, IEnumerable<BusinessModel>?, string MessageError)> GetBusinessData()
        {
            try
            {
                string? connectionString = _configuration["stringConnection"];

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM Business";
                    var business = await connection.QueryAsync<BusinessModel>(sqlQuery);
                    return business.AsList().Count > 0 ? (IsSuccess: true, business, string.Empty) : (IsSuccess: false, null, "No data");
                }
            }
            catch (Exception exceptionMessage)
            {
                logger.LogError(exceptionMessage.Message);
                return (false, null, exceptionMessage.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<BusinessModel>?, string MessageError)> GetBusinessDataByPortfolioId(int id)
        {
            try
            {
                string? connectionString = _configuration["stringConnection"];

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sqlQuery = $"SELECT * FROM Business WHERE portfolioId = {id}";
                    var business = await connection.QueryAsync<BusinessModel>(sqlQuery);
                    return business.AsList().Count > 0 ? (IsSuccess: true, business, string.Empty) : (IsSuccess: false, null, "No data");
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
