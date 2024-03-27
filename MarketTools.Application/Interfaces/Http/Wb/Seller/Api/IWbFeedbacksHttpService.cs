using MarketTools.Application.Models.Http.WB.Seller.Api;
using MarketTools.Application.Models.Http.WB.Seller.Api.Feedbacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Http.Wb.Seller.Api
{
    public interface IWbSellerApiFeedbacksHttpService
    {
        public Task<WbApiResult<FeedbackResponseData>> GetFeedbacksAsync(WbSellerApiFeedbacksQuery query);
        public Task SendResponseAsync(ResponseBody body);
    }
}
