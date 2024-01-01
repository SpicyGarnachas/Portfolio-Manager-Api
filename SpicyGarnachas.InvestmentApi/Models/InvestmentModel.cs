namespace SpicyGarnachas.InvestmentApi.Models
{
    public class InvestmentModel
    {
        public int id { get; set; }
        public int? portfolioId { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public string? platform { get; set; }
        public string? type { get; set; }
        public string? sector { get; set; }
        public string? risk { get; set; }
        public string? liquidity  { get; set; }
    }
}
