using AutoMapper;
using MarketTools.Application.Interfaces.Mapping;
using MarketTools.Application.Requests.Autoresponder.Standard.Tempaltes.Settings.Commands;

namespace MarketTools.WebApi.Models.Api.Autoreponder.Standard.Template
{
    public class SettingsUpdateDto : IHasMap
    {
        public int TemplateId { get; set; }
        public bool IsSkipWithTextFeedbacks { get; set; }
        public bool IsSkipEmptyFeedbacks { get; set; }
        public bool IsMain { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SettingsUpdateDto, SettingsUpdateCommand>();
        }
    }
}
