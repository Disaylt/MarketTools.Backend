using System.ComponentModel.DataAnnotations;

namespace MarketTools.WebApi.Models.Identity
{
    public class LoginModel
    {
        [EmailAddress(ErrorMessage = "Введите почту")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [Length(6, 30, ErrorMessage = "Введите от 6 до 30 символов")]
        public required string Password { get; set; }
    }
}
