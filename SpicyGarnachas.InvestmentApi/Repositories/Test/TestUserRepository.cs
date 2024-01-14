using MySql.Data.MySqlClient;
using SpicyGarnachas.InvestmentApi.Models;
using SpicyGarnachas.InvestmentApi.Repositories.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace SpicyGarnachas.InvestmentApi.Repositories.Test
{
    public class TestUserRepository : IUserRepository
    {
        private readonly ILogger<TestUserRepository> logger;

        public TestUserRepository(ILogger<TestUserRepository> logger)
        {
            this.logger = logger;
        }

        public async Task<(bool IsSuccess, UserModel, string Message)> GetUserData(string username)
        {
            try
            {
                UserModel user = new UserModel()
                { 
                    id = 1,
                    userName = "juan",
                    password = "qCz4mP1Bso87s4TAYovVUg==",
                    salt = "319NADX1xC0fVjoPR+wig2ObcarWsZSbW2lNiMnLCX4=",
                    createdOn = DateTime.Now,
                    updatedOn = DateTime.Now
                };
                return (true, user, string.Empty);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, string Message)> RegisterUser(UserModel user)
        {
            try
            {
                return (IsSuccess: true, string.Empty);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, ex.Message);
            }
        }

        public async Task<(bool isSuccess, string salt)> GenerateRandomSalt()
        {
            try
            {
                byte[] salt = new byte[32];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salt);
                }
                return (true, Convert.ToBase64String(salt));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, ex.Message);
            }
        }

        public async Task<(bool isSuccess, string hash)> EncriptPassword(string salt, string password)
        {
            try
            {
                using (var pbkdf2 = new Rfc2898DeriveBytes(Encoding.UTF8.GetBytes(password), Encoding.UTF8.GetBytes(salt), 2, HashAlgorithmName.SHA256))
                {
                    byte[] hash = pbkdf2.GetBytes(16);
                    return (true, Convert.ToBase64String(hash));
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
