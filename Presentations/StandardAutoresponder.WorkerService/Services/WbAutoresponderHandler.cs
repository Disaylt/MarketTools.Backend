using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Http;
using MarketTools.Application.Models.Autoresponder;
using MarketTools.Application.Models.Autoresponder.Standard;
using MarketTools.Application.Models.Feedbacks;
using MarketTools.Application.Requests.Autoresponder.Standard.Reports.Commands;
using MarketTools.Application.Requests.Autoresponder.Standard.Response.Command;
using MarketTools.Application.Requests.Feedbacks.Commands;
using MarketTools.Application.Requests.Feedbacks.Queries;
using MarketTools.Domain.Enums;
using MediatR;
using StandardAutoresponder.WorkerService.Interfaces;

namespace StandardAutoresponder.WorkerService.Services
{

    internal class WbAutoresponderHandler
        : AutoresponderHandler, IAutoresponderHandler
    {
        private readonly IMediator _mediator;

        public WbAutoresponderHandler(IMediator mediator) : base(mediator, MarketplaceName.WB)
        {
            _mediator = mediator;
        }

        public async Task RunAsync(int connectionId)
        {
            IEnumerable<FeedbackDto> feedbacks = await GetFeedbackAsync(connectionId);

            foreach(FeedbackDto feedback in feedbacks)
            {
                await HandleAsync(feedback, connectionId);
            }
        }

        private async Task<IEnumerable<FeedbackDto>> GetFeedbackAsync(int connectionId)
        {
            FeedbacksQueryDto feedbacksQueryDto = new FeedbacksQueryDto
            {
                Take = 5,
                Skip = 0,
                Order = OrderType.Desc
            };
            feedbacksQueryDto.Types.Add(FeedbacksType.New);
            feedbacksQueryDto.Types.Add(FeedbacksType.Viewed);

            GetRangeFeedbacksByServiceQuery request = new GetRangeFeedbacksByServiceQuery
            {
                Data = feedbacksQueryDto,
                ConnectionId = connectionId,
                MarketplaceName = MarketplaceName.WB,
                Service = EnumProjectServices.StandardAutoresponder
            };

            return await _mediator.Send(request);
        }
    }
}
