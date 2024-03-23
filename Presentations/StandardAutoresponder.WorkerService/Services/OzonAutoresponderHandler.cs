using MarketTools.Application.Models.Feedbacks;
using MarketTools.Application.Requests.Autoresponder.Standard.ConnectionRating.Queries;
using MarketTools.Application.Requests.Feedbacks.Queries;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using MediatR;
using StandardAutoresponder.WorkerService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardAutoresponder.WorkerService.Services
{
    internal class OzonAutoresponderHandler : AutoresponderHandler, IAutoresponderHandler
    {
        private readonly IMediator _mediator;

        public OzonAutoresponderHandler(IMediator mediator) : base(mediator, MarketplaceName.OZON)
        {
            _mediator = mediator;
        }

        public async Task RunAsync(int connectionId)
        {
            IEnumerable<int> ratings = await GetRatingsAsync(connectionId);

            if(ratings.Count() == 0)
            {
                return;
            }

            IEnumerable<FeedbackDto> feedbacks = await GetFeedbackAsync(connectionId, ratings);

            foreach (FeedbackDto feedback in feedbacks)
            {
                await HandleAsync(feedback, connectionId);
            }
        }

        private async Task<IEnumerable<FeedbackDto>> GetFeedbackAsync(int connectionId, IEnumerable<int> ratings)
        {
            FeedbacksQueryDto feedbacksQueryDto = new FeedbacksQueryDto
            {
                Take = 5,
                Skip = 0,
                Order = OrderType.Desc
            };
            feedbacksQueryDto.Types.Add(FeedbacksType.New);
            feedbacksQueryDto.Types.Add(FeedbacksType.Viewed);
            feedbacksQueryDto.Grades.AddRange(ratings);

            GetRangeFeedbacksByServiceQuery request = new GetRangeFeedbacksByServiceQuery
            {
                Data = feedbacksQueryDto,
                ConnectionId = connectionId,
                MarketplaceName = MarketplaceName.OZON,
                Service = EnumProjectServices.StandardAutoresponder
            };

            return await _mediator.Send(request);
        }

        private async Task<IEnumerable<int>> GetRatingsAsync(int connectionId)
        {
            GetRangeRatingsQuery request = new GetRangeRatingsQuery
            {
                ConnectionId = connectionId
            };

            IEnumerable<StandardAutoresponderConnectionRatingEntity> ratings = await _mediator.Send(request);

            return ratings.Select(x => x.Rating);
        }
    }
}
