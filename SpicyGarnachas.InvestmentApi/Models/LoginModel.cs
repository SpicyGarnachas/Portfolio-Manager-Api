namespace SpicyGarnachas.InvestmentApi.Models
{
    public class LoginModel
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public int? UserId { get; set; }
        public string? Token { get; set; }
    }
}