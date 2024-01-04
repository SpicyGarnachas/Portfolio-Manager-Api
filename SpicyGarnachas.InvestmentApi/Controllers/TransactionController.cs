using SpicyGarnachas.InvestmentApi.Models;
using Microsoft.AspNetCore.Mvc;
using SpicyGarnachas.InvestmentApi.Services.Interfaces;
using Microsoft.AspNetCore.Cors;

namespace SpicyGarnachas.InvestmentApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")] 
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService services;

        public TransactionController(ITransactionService services)
        {
            this.services = services;
        }

        [HttpGet]
        [Route("[action]/")]
        public async Task<ActionResult<IEnumerable<TransactionModel>?>> GetTransactionsData()
        {
            var (IsSuccess, Result, MessageError) = await services.GetTransactionsData();
            return IsSuccess ? Ok(Result) : BadRequest(Result);
        }
    }
}

