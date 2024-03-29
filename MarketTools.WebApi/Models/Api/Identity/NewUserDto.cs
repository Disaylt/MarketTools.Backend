﻿using AutoMapper;
using MarketTools.Application.Cases.User.Command.Register;
using MarketTools.Application.Common.Mappings;
using System.ComponentModel.DataAnnotations;

namespace MarketTools.WebApi.Models.Api.Identity
{
    public class NewUserDto : IHasMap
    {
        [Required(ErrorMessage = "Введите имя пользователя")]
        public required string UserName { get; set; }

        [EmailAddress(ErrorMessage = "Введите почту")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [Length(6, 30, ErrorMessage = "Введите от 6 до 30 символов")]
        public required string Password { get; set; }

        [Required(ErrorMessage = "Повторите пароль")]
        public required string RepeatPassword { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewUserDto, RegisterUserCommand>();
        }
    }
}
