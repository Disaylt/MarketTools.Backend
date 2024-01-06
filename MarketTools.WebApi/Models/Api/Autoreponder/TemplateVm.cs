﻿using AutoMapper;
using MarketTools.Application.Common.Mappings;
using MarketTools.Domain.Entities;

namespace MarketTools.WebApi.Models.Api.Autoreponder
{
    public class TemplateVm : IHasMap
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<StandardAutoresponderTemplateEntity, TemplateVm>();
        }
    }
}
