namespace SpicyGarnachas.InvestmentApi.Models
{
    public class InvestmentValueModel
    {
        public int id { get; set; }
        public int? investmentId { get; set; }
        public string? date { get; set; }
        public string? value { get; set; }
    }
}
