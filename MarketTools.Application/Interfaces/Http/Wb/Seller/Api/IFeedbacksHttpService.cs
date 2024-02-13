using MarketTools.Domain.Entities;
using MarketTools.Domain.Http.WB.Seller.Api;
using MarketTools.Domain.Http.WB.Seller.Api.Feedbaks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Http.Wb.Seller.Api
{
    public interface IFeedbacksHttpService
    {
        public Task<WbApiResult<FeedbackResponseData>> GetFeedbacksAsync(FeedbacksQuery query);
        public Task SendResponseAsync(SendResponseBody body);
    }
}
