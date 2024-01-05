using SpicyGarnachas.InvestmentApi.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using SpicyGarnachas.InvestmentApi.Models;
using Dapper;

namespace SpicyGarnachas.InvestmentApi.Repositories
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly ILogger<PortfolioRepository> logger;
        private readonly IConfiguration _configuration;

        public PortfolioRepository(ILogger<PortfolioRepository> logger, IConfiguration configuration)
        {
            this.logger = logger;
            _configuration = configuration;
        }

        public async Task<(bool IsSuccess, IEnumerable<PortfolioModel>?, string MessageError)> GetPortfolioData()
        {
            try
            {
                string? connectionString = _configuration["stringConnection"];

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM Portfolio";
                    var portfolio = await connection.QueryAsync<PortfolioModel>(sqlQuery);
                    return portfolio.AsList().Count > 0 ? (IsSuccess: true, portfolio, string.Empty) : (IsSuccess: false, null, "No data");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<PortfolioModel>?, string MessageError)> GetPortfolioById(int id)
        {
            try
            {
                string? connectionString = _configuration["stringConnection"];

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sqlQuery = $"SELECT * FROM Portfolio WHERE Id = {id}";
                    var portfolio = await connection.QueryAsync<PortfolioModel>(sqlQuery);
                    return portfolio.AsList().Count > 0 ? (IsSuccess: true, portfolio, string.Empty) : (IsSuccess: false, null, "No data");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, string Message)> CreateNewPortfolio(int userId, string name, string description)
        {
            try
            {
                string? connectionString = _configuration["stringConnection"];

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sqlQuery = $"INSERT INTO Portfolio (username, password, createdOn, updatedOn) VALUES ({userId}, '{name}', '{description}', '{DateTime.Now}', '{DateTime.Now}');";
                    await connection.ExecuteAsync(sqlQuery);

                    return (IsSuccess: true, Message: "Portfolio created successfully");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, string Message)> ModifyPorfolio(int id, string sqlQuery)
        {
            try
            {
                string? connectionString = _configuration["stringConnection"];

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    await connection.ExecuteAsync(sqlQuery);
                    return (IsSuccess: true, Message: "Portfolio updated successfully");
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