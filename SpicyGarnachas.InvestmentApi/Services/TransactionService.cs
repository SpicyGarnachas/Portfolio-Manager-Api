﻿using SpicyGarnachas.InvestmentApi.Models;
using SpicyGarnachas.InvestmentApi.Repositories.Interfaces;

namespace SpicyGarnachas.InvestmentApi.Services.Interfaces
{
    public class TransactionService: ITransactionService
    {
        private readonly ITransactionRepository repository;
        private readonly ILogger<TransactionService> logger;

        public TransactionService(ITransactionRepository repository, ILogger<TransactionService> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<(bool IsSuccess, IEnumerable<TransactionModel>?, string MessageError)> GetTransactionsData()
        {
            try
            {
                var (IsSuccess, Result, MessageError) = await repository.GetTransactionsData();
                await Task.Delay(0);
                return IsSuccess ? (true, Result, string.Empty) : (false, null, MessageError);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, null, ex.Message);
            }
        }
        
        public async Task<(bool IsSuccess, IEnumerable<TransactionModel>?, string MessageError)> GetTransactionsDataByPortfolioId(int id)
        {
            try
            {
                var (IsSuccess, Result, MessageError) = await repository.GetTransactionsDataByPortfolioId(id);
                await Task.Delay(0);
                return IsSuccess ? (true, Result, string.Empty) : (false, null, MessageError);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, null, ex.Message);
            }
        }
    }
}
