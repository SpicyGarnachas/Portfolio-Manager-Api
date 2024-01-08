namespace SpicyGarnachas.InvestmentApi.Models
{
    public class UserModel
    {
        int Id { get; set; }
        string? UserName { get; set; }
        string? Password { get; set; }
        public byte[]? image { get; set; }
        
    }
}