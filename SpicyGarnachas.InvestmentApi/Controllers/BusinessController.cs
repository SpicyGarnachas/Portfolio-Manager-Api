using Microsoft.AspNetCore.Mvc;
using SpicyGarnachas.InvestmentApi.Services.Interfaces;
using SpicyGarnachas.InvestmentApi.Models;
using Microsoft.AspNetCore.Cors;

namespace SpicyGarnachas.InvestmentApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class BusinessController : ControllerBase
    {
        private readonly IBusinessService services;

        public BusinessController(IBusinessService services)
        {
            this.services = services;
        }

        [HttpGet]
        [Route("GetBusinessData")]
        public async Task<ActionResult<IEnumerable<BusinessModel>?>> GetBusinessData()
        {
            var (IsSuccess, Result, Message) = await services.GetBusinessData();
            return IsSuccess ? Ok(Result) : BadRequest(Message);
        }

        [HttpGet]
        [Route("GetBusinessDataByPortfolioId/{id}")]
        public async Task<ActionResult<IEnumerable<BusinessModel>?>> GetBusinessDataByPortfolioId(int id)
        {
            var (IsSuccess, Result, Message) = await services.GetBusinessDataByPortfolioId(id);
            return IsSuccess ? Ok(Result) : BadRequest(Message);
        }

        [HttpPost]
        [Route("CreateNewBusiness/{portfolioId}/{name}/{description}/{sector}")]
        public async Task<ActionResult<string>> CreateNewBusiness(int portfolioId, string name, string description, string sector)
        {
            var (IsSuccess, Message) = await services.CreateNewBusiness(portfolioId, name, description, sector);
            return IsSuccess ? Ok(Message) : BadRequest(Message);
        }

        [HttpDelete]
        [Route("DeleteBusiness/{id}/{portfolioId}")]
        public async Task<ActionResult<string>> DeleteBusiness(int id, int portfolioId)
        {
            var (IsSuccess, Message) = await services.DeleteBusiness(id, portfolioId);
            return IsSuccess ? Ok(Message) : BadRequest(Message);
        }
    }
}