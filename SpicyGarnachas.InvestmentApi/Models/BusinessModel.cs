﻿namespace SpicyGarnachas.InvestmentApi.Models
{
    public class BusinessModel
    {
        public int id { get; set; }
        public int? portfolioId { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public string? Sector { get; set; }
    }
}