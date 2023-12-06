using MarketTools.Application.Cases.User.Command.Register;
using MarketTools.Application.Common.Mappings;
using System.ComponentModel.DataAnnotations;

namespace MarketTools.WebApi.Models.Identity
{
    public class NewUserDto : IMapWith<RegisterUserCommand>
    {
        [Required(ErrorMessage = "Введите почту")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [Length(6, 30, ErrorMessage = "Введите от 6 до 30 символов")]
        public required string Password { get; set; }

        [Required(ErrorMessage = "Повторите пароль")]
        [Length(6, 30, ErrorMessage = "Введите от 6 до 30 символов")]
        public required string RepeatPassword { get; set; }
    }
}
