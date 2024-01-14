namespace SpicyGarnachas.InvestmentApi.Models
{
    public class LoginModel
    {
        public bool isSuccess { get; set; }
        public string? message { get; set; }
        public int? userId { get; set; }
        public byte[]? image { get; set; }
        public string? token { get; set; }
    }
}