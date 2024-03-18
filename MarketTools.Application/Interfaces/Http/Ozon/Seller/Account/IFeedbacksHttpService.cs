using MarketTools.Application.Models.Http.Ozon.Seller.Account.Feedbacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Http.Ozon.Seller.Account
{
    public interface IOzonSellerAccountFeedbacksHttpService
    {
        public Task<FeedbacksResponseBody> GetFeedbacksAsync(FeedbacksRequestBody body);
        public Task SendResponseAsync();
    }
}
