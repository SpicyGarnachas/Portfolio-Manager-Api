﻿namespace SpicyGarnachas.InvestmentApi.Models
{
    public class InvestmentValueModel
    {
        public int id { get; set; }
        public int? investmentId { get; set; }
        public DateTime? date { get; set; }
        public int? value { get; set; }
    }
}