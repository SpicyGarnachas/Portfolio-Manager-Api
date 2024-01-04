using Microsoft.AspNetCore.Mvc;
using SpicyGarnachas.InvestmentApi.Services.Interfaces;
using SpicyGarnachas.InvestmentApi.Models;
using Microsoft.AspNetCore.Cors;

namespace SpicyGarnachas.InvestmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")] 
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioService services;

        public PortfolioController(IPortfolioService services)
        {
            this.services = services;
        }

        [HttpGet]
        [Route("[action]/")]
        public async Task<ActionResult<IEnumerable<PortfolioModel>?>> GetPortfolioData()
        {
            var (IsSuccess, Result, MessageError) = await services.GetPortfolioData();
            return IsSuccess ? Ok(Result) : BadRequest(Result);
        }
    }
}
