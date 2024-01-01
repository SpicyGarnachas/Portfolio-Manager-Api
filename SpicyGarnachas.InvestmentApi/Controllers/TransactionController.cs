using Microsoft.AspNetCore.Mvc;
using SpicyGarnachas.InvestmentApi.Services.Interfaces;

namespace SpicyGarnachas.InvestmentApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService services;

        public TransactionController(ITransactionService services)
        {
            this.services = services;
        }

        [HttpGet]
        [Route("[action]/")]
        public async Task<ActionResult<List<Models.TransactionModel>?>> GetTransactionsData()
        {
            var (IsSuccess, Result, MessageError) = await services.GetTransactionsData();
            return IsSuccess ? Ok(Result) : BadRequest(Result);
        }
    }
}

