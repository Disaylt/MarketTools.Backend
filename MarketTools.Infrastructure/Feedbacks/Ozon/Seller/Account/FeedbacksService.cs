using MarketTools.Application.Interfaces.Feedbacks;
using MarketTools.Application.Interfaces.Http.Ozon.Seller.Account;
using MarketTools.Application.Models.Feedbacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Feedbacks.Ozon.Seller.Account
{
    internal class OzonSellerAccountFeedbacksService(IOzonSellerAccountFeedbacksHttpService _ozonSellerAccountFeedbacksHttpService)
        : IFeedbacksService
    {
        public Task<IEnumerable<FeedbackDto>> GetFeedbacksAsync(FeedbacksQueryDto data)
        {
            throw new NotImplementedException();
        }

        public Task SendAnswerAsync(AnswerDto data)
        {
            throw new NotImplementedException();
        }


    }
}
