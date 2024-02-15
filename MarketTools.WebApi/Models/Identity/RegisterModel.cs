namespace MarketTools.WebApi.Models.Identity
{
    public class RegisterModel
    {
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string RepeatPassword { get; set; }
    }
}
