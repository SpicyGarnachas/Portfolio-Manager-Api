﻿namespace SpicyGarnachas.InvestmentApi.Models;

public class InvestmentValueModel
{
    public int id { get; set; }
    public int? investmentId { get; set; }
    public int? value { get; set; }
    public string? currencyCode { get; set; }
    public DateTime? createdOn { get; set; }
    public DateTime? updatedOn { get; set; }
}