using AutoMapper;
using MarketTools.Application.Common.Mappings;
using MarketTools.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MarketTools.WebApi.Models.Api.Autoreponder.Standard.Template
{
    public class SettingsVm : IHasMap
    {
        public bool IsSkipWithTextFeedbacks { get; set; }
        public bool IsSkipEmptyFeedbacks { get; set; }

        public void Mapping(Profile profile)
        {
           profile.CreateMap<StandardAutoresponderTemplateSettingsEntity, SettingsVm>();
        }
    }
}
