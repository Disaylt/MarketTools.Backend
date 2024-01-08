using AutoMapper;
using MarketTools.Application.Cases.Autoresponder.Standard.Tempaltes.Settings.Commands.Update;
using MarketTools.Application.Common.Mappings;

namespace MarketTools.WebApi.Models.Api.Autoreponder.Standard.Template
{
    public class SettingsUpdateDto : IHasMap
    {
        public int TemplateId { get; set; }
        public bool IsSkipWithTextFeedbacks { get; set; }
        public bool IsSkipEmptyFeedbacks { get; set; }
        public bool AsMainTemplate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SettingsUpdateDto, SettingsUpdateCommand>();
        }
    }
}
