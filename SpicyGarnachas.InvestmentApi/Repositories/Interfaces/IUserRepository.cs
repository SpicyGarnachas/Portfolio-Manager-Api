using SpicyGarnachas.InvestmentApi.Models;
namespace SpicyGarnachas.InvestmentApi.Repositories.Interfaces

{
    public interface IUserRepository
    {
        Task<(bool IsSuccess, IEnumerable<UserModel>?, string Message)> GetUserData(string username);
        Task<(bool IsSuccess, IEnumerable<UserModel>?, string Message)> RegisterUser(UserModel user);
    }
}
