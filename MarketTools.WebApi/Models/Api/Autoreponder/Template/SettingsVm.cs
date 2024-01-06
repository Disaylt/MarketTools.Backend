using MarketTools.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MarketTools.WebApi.Models.Api.Autoreponder.Template
{
    public class SettingsVm
    {
        public bool IsSkipWithTextFeedbacks { get; set; }
        public bool IsSkipEmptyFeedbacks { get; set; }
        public bool AsMainTemplate { get; set; }
    }
}
