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
            var (IsSuccess, Result, Message) = await services.GetPortfolioData();
            return IsSuccess ? Ok(Result) : BadRequest(Message);
        }

        [HttpGet]
        [Route("GetPortfolioByUserId/{id}")]
        public async Task<ActionResult<IEnumerable<PortfolioModel>?>> GetPortfolioByUserId(int id)
        {
            var (IsSuccess, Result, Message) = await services.GetPortfolioById(id);
            return IsSuccess ? Ok(Result) : BadRequest(Message);
        }

        [HttpPost]
        [Route("CreateNewPortfolio/{userId}/{name}/{description}")]
        public async Task<ActionResult<string>> CreateNewPortfolio(int userId, string name, string description)
        {
            var (IsSuccess, Message) = await services.CreateNewPortfolio(userId, name, description);
            return IsSuccess ? Ok(Message) : BadRequest(Message);
        }

        [HttpPut]
        [Route("ModifyPorfolio/{id}/{userId}")]
        public async Task<ActionResult<string>> ModifyPorfolio(int id, int userId, string name, string description)
        {
            var (IsSuccess, Message) = await services.ModifyPorfolio(id,userId, name, description);
            return IsSuccess ? Ok(Message) : BadRequest(Message);
        }

        [HttpDelete]
        [Route("DeletePortfolio/{id}/{userId}")]
        public async Task<ActionResult<string>> DeletePortfolio(int id, int userId)
        {
            var (IsSuccess, Message) = await services.DeletePortfolio(id, userId);
            return IsSuccess ? Ok(Message) : BadRequest(Message);
        }
    }
}
