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

    public async Task<(bool IsSuccess, IEnumerable<UserModel>?, string Message)> GetUserData(string username)
    {
        try
        {
            string? connectionString = _configuration["stringConnection"];

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string sqlQuery = $"SELECT * FROM Users WHERE username = {username}";
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

    public async Task<(bool IsSuccess, IEnumerable<UserModel>?, string Message)> RegisterUser(UserModel user)
    {
        try
        {
            string? connectionString = _configuration["stringConnection"];

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string sqlQuery = $"INSERT INTO users (userName, password, salt, createdOn, updatedOn) VALUES ({user.userName}, {user.password}, {user.salt}, @lastname, @email)";
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
