using MarketTools.Application.Models.Http.WB.Seller;
using MarketTools.Domain.Http.WB.Seller.Api.Feedbaks;
using MarketTools.Domain.Interfaces.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Http.Wb.Seller
{
    public interface IWbSellerFeedbacksHttpService
    {
        public Task<IEnumerable<FeedbackDto>> GetFeedbacksAsync(GetFeedbacksHttpDto data);
        public Task SendResponseAsync(SendResponseDto body);
    }
}
