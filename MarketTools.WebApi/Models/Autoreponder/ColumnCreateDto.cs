﻿using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Columns.Commands.Create;
using MarketTools.Application.Common.Mappings;
using System.ComponentModel.DataAnnotations;

namespace MarketTools.WebApi.Models.Autoreponder
{
    public class ColumnCreateDto : IHasMap
    {
        [Required(ErrorMessage = "Введите название.")]
        [MaxLength(100, ErrorMessage = "Длинна название не более 100 символов.")]
        [MinLength(5, ErrorMessage = "Длинна названия не менее 5 символов.")]
        public required string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ColumnCreateDto, ColumnCreateCommand>();
        }
    }
}