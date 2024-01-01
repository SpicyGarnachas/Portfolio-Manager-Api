using Microsoft.AspNetCore.Mvc;
using SpicyGarnachas.InvestmentApi.Services;
using System.Reflection;

namespace SpicyGarnachas.InvestmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioService services;

        public PortfolioController(IPortfolioService services)
        {
            this.services = services;
        }

        [HttpGet]
        [Route("[action]/")]
        public async Task<ActionResult<Models.PortfolioModel?>> GetPortfolioData()
        {
            var (IsSuccess, Result, MessageError) = await services.GetPortfolioData();
            return IsSuccess ? Ok(Result) : BadRequest(Result);
        }
    }
}
