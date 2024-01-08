using Microsoft.AspNetCore.Mvc;
using SpicyGarnachas.InvestmentApi.Services.Interfaces;
using SpicyGarnachas.InvestmentApi.Models;
using Microsoft.AspNetCore.Cors;

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
        [Route("GetInvestmentData")]
        public async Task<ActionResult<IEnumerable<InvestmentModel>?>> GetInvestmentData()
        {
            var (IsSuccess, Result, Message) = await services.GetInvestmentData();
            return IsSuccess ? Ok(Result) : BadRequest(Message);
        }
        
        [HttpGet]
        [Route("GetInvestmentDataByPortfolioId/id={id}")]
        public async Task<ActionResult<IEnumerable<InvestmentModel>?>> GetInvestmentDataByPortfolioId(int id)
        {
            var (IsSuccess, Result, Message) = await services.GetInvestmentDataByPortfolioId(id);
            return IsSuccess ? Ok(Result) : BadRequest(Message);
        }

        [HttpPost]
        [Route("CreateNewInvestment/portfolioId={portfolioId}&name={name}&description={description}&platform={platform}&type={type}&sector={sector}&risk={risk}&liquidity={liquidity}&image={image}&currency={currency}")]
        public async Task<ActionResult<string>> CreateNewInvestment(int portfolioId, string name, string description, string platform, string type, string sector, int risk, int liquidity, byte[] image, string currency)
        {
            var (IsSuccess, Message) = await services.CreateNewInvestment(portfolioId, name, description, platform, type, sector, risk, liquidity, image, currency);
            return IsSuccess ? Ok(Message) : BadRequest(Message);
        }

        [HttpPut]
        [Route("ModifyInvestment/id={id}&portfolioId={portfolioId}")]
        public async Task<ActionResult<string>> ModifyInvestment(int id, int portfolioId, string name, string description, string platform, string type, string sector, int risk, int liquidity, byte[] image, string currency)
        {
            var (IsSuccess, Message) = await services.ModifyInvestment(id, portfolioId, name, description, platform, type, sector, risk, liquidity, image, currency);
            return IsSuccess ? Ok(Message) : BadRequest(Message);
        }

        [HttpDelete]
        [Route("DeleteInvestment/id={id}&portfolioId={portfolioId}")]
        public async Task<ActionResult<string>> DeleteInvestment(int id, int portfolioId)
        {
            var (IsSuccess, Message) = await services.DeleteInvestment(id, portfolioId);
            return IsSuccess ? Ok(Message) : BadRequest(Message);
        }
    }
}