﻿using Dapper;
using MySql.Data.MySqlClient;
using SpicyGarnachas.InvestmentApi.Models;
using SpicyGarnachas.InvestmentApi.Repositories.Interfaces;

namespace SpicyGarnachas.InvestmentApi.Repositories
{
    public class InvestmentRepository : IInvestmentRepository
    {
        private readonly ILogger<InvestmentRepository> logger;
        private readonly IConfiguration _configuration;

        public InvestmentRepository(ILogger<InvestmentRepository> logger, IConfiguration configuration)
        {
            this.logger = logger;
            _configuration = configuration;
        }
        
        public async Task<(bool IsSuccess, IEnumerable<InvestmentModel>?, string Message)> GetInvestmentData()
        {
            try
            {
                string? connectionString = _configuration["stringConnection"];

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM Investment";
                    var investment = await connection.QueryAsync<InvestmentModel>(sqlQuery);
                    return investment.AsList().Count > 0 ? (IsSuccess: true, investment, string.Empty) : (IsSuccess: false, null, "No data");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, null, ex.Message);
            }
        }
        public async Task<(bool IsSuccess, IEnumerable<InvestmentModel>?, string Message)> GetInvestmentDataByPortfolioId(int id)
        {
            try
            {
                string? connectionString = _configuration["stringConnection"];

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sqlQuery = $"SELECT * FROM Investment where portfolioId = {id}";
                    var investment = await connection.QueryAsync<InvestmentModel>(sqlQuery);
                    return investment.AsList().Count > 0 ? (IsSuccess: true, investment, string.Empty) : (IsSuccess: false, null, "No data");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, null, ex.Message);
            }
        }

        public async Task <(bool IsSuccess, string Message)> CreateNewInvestment(int portfolioId, string name, string description, string platform, string type, string sector, int risk, int liquidity)
        {
            try
            {
                string? connectionString = _configuration["stringConnection"];

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sqlQuery = $"INSERT INTO Investment (portfolioId, name, description, platform, type, sector, risk, liquidity, createdOn, updatedOn) VALUES ({portfolioId}, '{name}', '{description}', '{platform}', '{type}', '{sector}', {risk}, {liquidity}, NOW(), NOW())";
                    await connection.ExecuteAsync(sqlQuery);
                    return (true, string.Empty);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, ex.Message);
            }
        }
    }
}

