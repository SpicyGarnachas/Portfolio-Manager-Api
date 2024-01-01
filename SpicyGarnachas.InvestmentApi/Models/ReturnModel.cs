namespace SpicyGarnachas.InvestmentApi.Models
{
    public class ReturnModel
    {
        public int id { get; set; }
        public int? investmentId { get; set; }
        public DateTime? date { get; set; }
        public int? value { get; set; }
    }
}
