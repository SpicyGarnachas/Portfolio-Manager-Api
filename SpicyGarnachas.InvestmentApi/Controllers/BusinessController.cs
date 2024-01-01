using Microsoft.AspNetCore.Mvc;
using SpicyGarnachas.InvestmentApi.Services.Interfaces;

namespace SpicyGarnachas.InvestmentApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        private readonly IBusinessService services;

        public BusinessController(IBusinessService services)
        {
            this.services = services;
        }

        [HttpGet]
        [Route("[action]/")]
        public async Task<ActionResult<Models.BusinessModel?>> GetBusinessData()
        {
            var (IsSuccess, Result, MessageError) = await services.GetBusinessData();
            return IsSuccess ? Ok(Result) : BadRequest(Result);
        }
    }

}
