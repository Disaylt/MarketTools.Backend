using AutoMapper;
using MarketTools.Application.Common.Mappings;
using MarketTools.Domain.Entities;

namespace MarketTools.WebApi.Models.Api.Autoreponder.Standard
{
    public class ReportVm : IHasMap
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public int Rating { get; set; }
        public DateTime ReviewCreateDate { get; set; }
        public int Article { get; set; }
        public string SupplierArticle { get; set; } = "-";
        public string Response { get; set; } = string.Empty;
        public string Report { get; set; } = string.Empty;
        public bool IsSuccess { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<StandardAutoresponderNotificationEntity, ReportVm>();
        }
    }
}
