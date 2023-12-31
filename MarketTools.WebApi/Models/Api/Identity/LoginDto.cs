using AutoMapper;
using MarketTools.Application.Cases.User.Command.Login;
using MarketTools.Application.Common.Mappings;
using System.ComponentModel.DataAnnotations;

namespace MarketTools.WebApi.Models.Api.Identity
{
    public class LoginDto : IHasMap
    {
        [EmailAddress(ErrorMessage = "Введите почту")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [Length(6, 30, ErrorMessage = "Введите от 6 до 30 символов")]
        public required string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LoginDto, LoginUserCommand>();
        }
    }
}
