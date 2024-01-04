using Microsoft.AspNetCore.Mvc;
using SpicyGarnachas.InvestmentApi.Services.Interfaces;
using SpicyGarnachas.InvestmentApi.Models;

namespace SpicyGarnachas.InvestmentApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentController : ControllerBase
    {
        private readonly IInvestmentService services;

        public InvestmentController(IInvestmentService services)
        {
            this.services = services;
        }

        [HttpGet]
        [Route("[action]/")]
        public async Task<ActionResult<IEnumerable<InvestmentModel>?>> GetInvestmentData()
        {
            var (IsSuccess, Result, MessageError) = await services.GetInvestmentData();
            return IsSuccess ? Ok(Result) : BadRequest(Result);
        }
    }
}
