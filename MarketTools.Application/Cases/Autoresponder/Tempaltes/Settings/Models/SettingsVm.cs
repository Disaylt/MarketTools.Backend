using AutoMapper;
using MarketTools.Application.Common.Mappings;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Tempaltes.Settings.Models
{
    public class SettingsVm : IHasMap
    {
        public bool IsSkipWithTextFeedbacks { get; set; }
        public bool IsSkipEmptyFeedbacks { get; set; }
        public bool AsMainTemplate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AutoresponderStandardTemplateSettings, SettingsVm>();
        }
    }
}
