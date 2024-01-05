using SpicyGarnachas.InvestmentApi.Models;
using Microsoft.AspNetCore.Mvc;
using SpicyGarnachas.InvestmentApi.Services.Interfaces;

namespace SpicyGarnachas.InvestmentApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ITransactionService services;

        public LoginController(ITransactionService services)
        {
            this.services = services;
        }

        [HttpGet]
        [Route("LoginByUserAndPassword/username={username}&password={password}")]
        public async Task<ActionResult<LoginModel>?> LoginByUserAndPassword(string username, string password)
        {
            //var (IsSuccess, Result, Message) = await services.LoginByUserAndPassword(string username, string password);
            //return IsSuccess ? Ok(Result) : BadRequest(Message);
            await Task.Delay(1000);
            return new LoginModel() {
                IsSuccess = true,
                Message = "Login successful",
                UserId = 1,
                Token = "a1b2c3d4e5f6g7h8i9j0k1l2m3n4o5p6"};
        }
    }
}