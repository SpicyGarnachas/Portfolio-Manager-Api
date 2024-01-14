using Dapper;
using MySql.Data.MySqlClient;
using SpicyGarnachas.InvestmentApi.Models;

namespace SpicyGarnachas.InvestmentApi;

public class UserRepository
{
    private readonly ILogger<UserRepository> logger;
    private readonly IConfiguration _configuration;

    public UserRepository(ILogger<UserRepository> logger, IConfiguration configuration)
    {
        this.logger = logger;
        _configuration = configuration;
    }

    public async Task<(bool IsSuccess, IEnumerable<UserModel>?, string Message)> LoginByUserAndPassword(string username, string password)
    {
        try
        {
            string? connectionString = _configuration["stringConnection"];

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Users WHERE id = ";
                var users = await connection.QueryAsync<UserModel>(sqlQuery);
                return users.AsList().Count > 0 ? (IsSuccess: true, users, string.Empty) : (IsSuccess: false, null, "Database without Users");
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return (false, null, ex.Message);
        }
    }


    public async Task<(bool IsSuccess, IEnumerable<UserModel>?, string Message)> Register(UserModel user)
    {
        try
        {
            string? connectionString = _configuration["stringConnection"];

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Users WHERE id = ";
                var users = await connection.QueryAsync<UserModel>(sqlQuery);
                return users.AsList().Count > 0 ? (IsSuccess: true, users, string.Empty) : (IsSuccess: false, null, "Database without Users");
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return (false, null, ex.Message);
        }
    }



}
