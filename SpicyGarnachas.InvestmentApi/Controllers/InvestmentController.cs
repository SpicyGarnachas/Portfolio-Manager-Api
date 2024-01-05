using Microsoft.AspNetCore.Mvc;
using SpicyGarnachas.InvestmentApi.Services.Interfaces;
using SpicyGarnachas.InvestmentApi.Models;
using Microsoft.AspNetCore.Cors;

namespace SpicyGarnachas.InvestmentApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")] 
    public class InvestmentController : ControllerBase
    {
        private readonly IInvestmentService services;

        public InvestmentController(IInvestmentService services)
        {
            this.services = services;
        }

        [HttpGet]
        [Route("GetInvestmentData")]
        public async Task<ActionResult<IEnumerable<InvestmentModel>?>> GetInvestmentData()
        {
            var (IsSuccess, Result, Message) = await services.GetInvestmentData();
            return IsSuccess ? Ok(Result) : BadRequest(Message);
        }
        
        [HttpGet]
        [Route("GetInvestmentDataByPortfolioId/{id}")]
        public async Task<ActionResult<IEnumerable<InvestmentModel>?>> GetInvestmentDataByPortfolioId(int id)
        {
            var (IsSuccess, Result, Message) = await services.GetInvestmentDataByPortfolioId(id);
            return IsSuccess ? Ok(Result) : BadRequest(Message);
        }

        [HttpPost]
        [Route("CreateNewInvestment/{userId}/{name}/{description}")]
        public async Task<ActionResult<string>> CreateNewInvestment(int portfolioId, string name, string description, string platform, string type, string sector, int risk, int liquidity)
        {
            var (IsSuccess, Message) = await services.CreateNewInvestment(portfolioId, name, description, platform, type, sector, risk, liquidity);
            return IsSuccess ? Ok(Message) : BadRequest(Message);
        }
    }
}
