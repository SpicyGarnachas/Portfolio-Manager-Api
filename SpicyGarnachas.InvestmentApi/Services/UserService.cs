using SpicyGarnachas.InvestmentApi.Repositories.Interfaces;
using SpicyGarnachas.InvestmentApi.Services.Interfaces;

namespace SpicyGarnachas.InvestmentApi;

public class UserService
{
    private readonly IUserRepository userRepository;
    private readonly ILogger<UserService> logger;

    public UserService(IUserRepository repository, ILogger<UserService> logger)
    {
        this.userRepository = repository;
        this.logger = logger;
    }
}
