namespace SpicyGarnachas.InvestmentApi.Models
{
    public class BusinessModel
    {
        public int id { get; set; }
        public int? portfolioId { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public string? sector { get; set; }
        public DateTime? createdOn { get; set; }
        public DateTime? updatedOn { get; set; }
    }
}