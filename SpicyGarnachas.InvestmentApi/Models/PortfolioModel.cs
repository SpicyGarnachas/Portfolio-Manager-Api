﻿namespace SpicyGarnachas.InvestmentApi.Models
{
    public class PortfolioModel
    {
        public int id { get; set; }
        public int? userId { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public string? currency { get; set; }
        public byte[]? image { get; set; }
        public DateTime? createdOn { get; set; }
        public DateTime? updatedOn { get; set; }
    }
}