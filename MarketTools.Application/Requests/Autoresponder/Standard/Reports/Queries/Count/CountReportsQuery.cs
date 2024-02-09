using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Autoresponder.Standard.Reports.Queries.Count
{
    public class CountReportsQuery : IRequest<int>
    {
        public int? ConnectionId { get; set; }
        public int? Rating { get; set; }
        public bool? IsSuccess { get; set; }
        public string? Article { get; set; }
    }
}
