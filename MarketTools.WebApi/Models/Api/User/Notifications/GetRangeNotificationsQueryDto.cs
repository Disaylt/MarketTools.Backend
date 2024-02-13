using MarketTools.Domain.Common;

namespace MarketTools.WebApi.Models.Api.User.Notifications
{
    public class GetRangeNotificationsQueryDto : PaginationModel
    {
        public bool? IsRead { get; set; }
    }
}
