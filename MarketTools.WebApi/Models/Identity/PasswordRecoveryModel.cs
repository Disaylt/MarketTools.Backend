using System.ComponentModel.DataAnnotations;

namespace MarketTools.WebApi.Models.Identity
{
    public class PasswordRecoveryModel
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }
        [Required]
        public required string RepeatPassword { get; set; }

        [Required]
        public required string Code { get; set; }
    }
}
