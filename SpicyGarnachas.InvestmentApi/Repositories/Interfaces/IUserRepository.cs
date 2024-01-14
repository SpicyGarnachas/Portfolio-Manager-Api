using SpicyGarnachas.InvestmentApi.Models;
namespace SpicyGarnachas.InvestmentApi.Repositories.Interfaces;


public interface IUserRepository
{
    Task<(bool IsSuccess, UserModel, string Message)> GetUserData(string username);
    Task<(bool IsSuccess, string Message)> RegisterUser(UserModel user);
    Task<(bool isSuccess, string salt)> GenerateRandomSalt();
    Task<(bool isSuccess, string hash)> EncriptPassword(string salt, string pass);
}
