﻿using SpicyGarnachas.InvestmentApi.Models;
using SpicyGarnachas.InvestmentApi.Repositories.Interfaces;

namespace SpicyGarnachas.InvestmentApi.Services.Interfaces;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository repository;
    private readonly ILogger<TransactionService> logger;

    public TransactionService(ITransactionRepository repository, ILogger<TransactionService> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<(bool IsSuccess, IEnumerable<TransactionModel>?, string Message)> GetTransactionsData()
    {
        try
        {
            var (IsSuccess, Result, Message) = await repository.GetTransactionsData();
            return IsSuccess ? (true, Result, string.Empty) : (false, null, Message);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return (false, null, ex.Message);
        }
    }

    public async Task<(bool IsSuccess, IEnumerable<TransactionModel>?, string Message)> GetTransactionsDataByPortfolioId(int id)
    {
        try
        {
            var (IsSuccess, Result, Message) = await repository.GetTransactionsDataByPortfolioId(id);
            return IsSuccess ? (true, Result, string.Empty) : (false, null, Message);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return (false, null, ex.Message);
        }
    }
}