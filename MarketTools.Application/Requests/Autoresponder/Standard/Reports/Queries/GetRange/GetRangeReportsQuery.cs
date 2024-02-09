using MarketTools.Application.Models.Requests;
using MarketTools.Domain.Common;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.Reports.Queries.GetRange
{
    public class GetRangeReportsQuery : GetRangeQuery<StandardAutoresponderNotificationEntity>
    {
        public int? ConnectionId { get; set; }
    }
}
