using AutoMapper;
using MarketTools.Application.Interfaces.Mapping;
using MarketTools.Application.Requests.Autoresponder.Standard.Reports.Queries;
using MarketTools.Domain.Common;
using MarketTools.Domain.Enums;

namespace MarketTools.WebApi.Models.Api.Autoreponder.Standard
{
    public class ReportQueryDto: PaginationModel, IHasMap
    {
        public int? ConnectionId { get; set; }
        public int? Rating { get; set; }
        public bool? IsSuccess { get; set; }
        public string? Article { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ReportQueryDto, GetRangeReportsQuery>()
                .ForMember(x => x.PageRequest, x => x.MapFrom(opt => new PageRequest
                {
                    OrderType = OrderType.Desk,
                    Skip = opt.Skip,
                    Take = opt.Take
                }));
            profile.CreateMap<ReportQueryDto, CountReportsQuery>();
        }
    }
}
