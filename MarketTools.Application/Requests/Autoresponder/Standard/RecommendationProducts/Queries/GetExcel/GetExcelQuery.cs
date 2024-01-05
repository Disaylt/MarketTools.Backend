using MarketTools.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.RecommendationProducts.Queries.GetExcel
{
    public class GetExcelQuery : IRequest<Stream>
    {
        public MarketplaceName MarketplaceName { get; set; }
    }
}
