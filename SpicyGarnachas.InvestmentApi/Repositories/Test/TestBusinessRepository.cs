﻿using Dapper;
using SpicyGarnachas.InvestmentApi.Models;
using SpicyGarnachas.InvestmentApi.Repositories.Interfaces;

namespace SpicyGarnachas.InvestmentApi.Repositories.Test
{
    public class TestBusinessRepository : IBusinessRepository
    {
        private readonly ILogger<TestBusinessRepository> logger;

        public TestBusinessRepository(ILogger<TestBusinessRepository> logger)
        {
            this.logger = logger;
        }

        public async Task<(bool IsSuccess, IEnumerable<BusinessModel>?, string MessageError)> GetBusinessData()
        {
            try
            {
                BusinessModel? business = new BusinessModel()
                {
                    id = 1,
                    portfolioId = 1,
                    name = "My fruit store TEST",
                    description = "Retail fruit store",
                    sector = "Retail"
                };
                await Task.Delay(0);
                IEnumerable<BusinessModel>? result = new List<BusinessModel>() { business };
                await Task.Delay(0);
                return result.AsList().Count > 0 ? (IsSuccess: true, result, string.Empty) : (IsSuccess: false, null, "No data");
            }
            catch (Exception exceptionMessage)
            {
                logger.LogError(exceptionMessage.Message);
                return (false, null, exceptionMessage.Message);
            }
        }
    }
}

