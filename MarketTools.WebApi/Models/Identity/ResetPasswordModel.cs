using System.ComponentModel.DataAnnotations;

namespace MarketTools.WebApi.Models.Identity
{
    public class ResetPasswordModel
    {
        [Required(ErrorMessage = "Обязательно введите Email.")]
        [EmailAddress(ErrorMessage = "Значение в поле Email не соответствует данным.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Обязательно введите пароль.")]
        public required string Password { get; set; }
        [Required(ErrorMessage = "Обязательно повторите пароль.")]
        public required string RepeatPassword { get; set; }

        [Required(ErrorMessage = "Обязательно введите код.")]
        public required string Code { get; set; }
    }
}
