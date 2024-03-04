using MarketTools.Application.Models.Http.WB.Seller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Http.Wb.Seller
{
    public interface IWbSellerFeedbacksHttpService
    {
        public Task<IEnumerable<FeedbackDto>> GetFeedbacksAsync(FeedbacksHttpRequestDto data);
        public Task SendResponseAsync(ResponseHttpRequestDto body);
    }
}
