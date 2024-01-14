using SpicyGarnachas.InvestmentApi.Models;

namespace SpicyGarnachas.InvestmentApi.Services.Interfaces;

public interface IUserService
{
    Task<(bool IsSuccess, string Message)> Register(UserModel user);
    Task<(bool IsSuccess, string Message)> Login(string username, string password);

}
