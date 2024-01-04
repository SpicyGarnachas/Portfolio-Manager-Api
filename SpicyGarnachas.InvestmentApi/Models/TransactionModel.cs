﻿namespace SpicyGarnachas.InvestmentApi.Models
{
    public class TransactionModel
    {
        public int id { get; set; }
        public int? investmentId { get; set; }
        public string? type { get; set; }
        public DateTime? date { get; set; }
        public int? value { get; set; }
    }
}