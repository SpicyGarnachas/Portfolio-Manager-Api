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
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, null, ex.Message);
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
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, string Message)> CreateNewBusiness(int portfolioId, string name, string description, string sector)
        {
            try
            {
                string? connectionString = _configuration["stringConnection"];

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sqlQuery = $"INSERT INTO Business (portfolioId, name, description, sector, createdOn, updatedOn) VALUES ({portfolioId}, '{name}', '{description}', '{sector}', NOW(), NOW())";
                    await connection.ExecuteAsync(sqlQuery);
                    return (true, "Business created successfully");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, ex.Message);
            }
        }
        public async Task<(bool IsSuccess, string Message)> DeleteBusiness(int id, int portfolioId)
        {
            try
            {
                string? connectionString = _configuration["stringConnection"];

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sqlQuery = $"DELETE FROM Business WHERE id = {id} AND portfolioId = {portfolioId}";
                    await connection.ExecuteAsync(sqlQuery);
                    return (true, "Business deleted successfully");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, ex.Message);
            }
        }
    }
}
