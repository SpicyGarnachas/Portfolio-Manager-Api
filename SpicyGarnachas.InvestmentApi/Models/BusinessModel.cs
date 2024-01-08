namespace SpicyGarnachas.InvestmentApi.Models
{
    public class BusinessModel
    {
        public int id { get; set; }
        public int? referenceId { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public string? sector { get; set; } // communication services, consumer discretionary, consumer staples, energy, financials, health care, industrials, information technology, materials, real estate, utilities
        public bool? isActive { get; set; }
        public DateTime? createdOn { get; set; }
        public DateTime? updatedOn { get; set; }
        public DateTime? inactiveDate { get; set; }
        public byte[]? image { get; set; }
    }
}