using SpicyGarnachas.InvestmentApi.Models;
using Microsoft.AspNetCore.Mvc;
using SpicyGarnachas.InvestmentApi.Services.Interfaces;

namespace SpicyGarnachas.InvestmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ITransactionService services;

        public UserController(ITransactionService services)
        {
            this.services = services;
        }

        [HttpGet]
        [Route("LoginByUserAndPassword")]
        public async Task<ActionResult<LoginModel>?> LoginByUserAndPassword(string username, string password)
        {
            //var (IsSuccess, Result, Message) = await services.LoginByUserAndPassword(string username, string password);
            //return IsSuccess ? Ok(Result) : BadRequest(Message);
            await Task.Delay(1000);
            return new LoginModel() {
                isSuccess = true,
                message = "Login successful",
                userId = 1,
                token = "a1b2c3d4e5f6g7h8i9j0k1l2m3n4o5p6"};
        }
    }
}