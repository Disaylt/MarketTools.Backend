using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Models.Feedbacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Feedbacks
{
    public interface IFeedbacksService : IConnectionService
    {
        public Task<IEnumerable<FeedbackDto>> GetFeedbacksAsync(FeedbacksQueryDto data);
        public Task SendAnswerAsync(AnswerDto data);
    }
}
