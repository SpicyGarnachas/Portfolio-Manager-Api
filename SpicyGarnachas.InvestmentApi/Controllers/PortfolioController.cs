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
        [Route("GetPortfolioData")]
        public async Task<ActionResult<IEnumerable<PortfolioModel>?>> GetPortfolioData()
        {
            var (IsSuccess, Result, MessageError) = await services.GetPortfolioData();
            return IsSuccess ? Ok(Result) : BadRequest(Result);
        }

        [HttpGet]
        [Route("GetPortfolioByUserId/{id}")]
        public async Task<ActionResult<IEnumerable<PortfolioModel>?>> GetPortfolioByUserId(int id)
        {
            var (IsSuccess, Result, MessageError) = await services.GetPortfolioById(id);
            return IsSuccess ? Ok(Result) : BadRequest(Result);
        }
    }
}
