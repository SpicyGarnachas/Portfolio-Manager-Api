﻿using SpicyGarnachas.InvestmentApi.Models;

namespace SpicyGarnachas.InvestmentApi.Services.Interfaces
{
    public interface IBusinessService
    {
        Task<(bool IsSuccess, IEnumerable<BusinessModel>?, string MessageError)> GetBusinessData();
        Task<(bool IsSuccess, IEnumerable<BusinessModel>?, string MessageError)> GetBusinessDataByPortfolioId(int id);
    }
}
