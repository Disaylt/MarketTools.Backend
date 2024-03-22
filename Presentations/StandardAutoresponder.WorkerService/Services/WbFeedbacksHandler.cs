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

    internal class WbFeedbacksHandler(IMediator _mediator)
        : IWbFeedbacksHandler
    {
        private static readonly EnumProjectServices _service = EnumProjectServices.StandardAutoresponder;
        private static readonly MarketplaceName _marketplaceName = MarketplaceName.WB;


        public async Task RunAsync(int connectionId)
        {
            IEnumerable<FeedbackDto> feedbacks = await GetFeedbackAsync(connectionId);

            foreach(FeedbackDto feedback in feedbacks)
            {
                AutoresponderResultModel result = await CreateAnswerAsync(feedback, connectionId);
                if (result.IsSuccess && result.Text != null)
                {
                    await SendAsync(feedback, result.Text, connectionId);
                }
                await CreateReportAsync(feedback, result, connectionId);
            }
        }

        private async Task CreateReportAsync(FeedbackDto feedback, AutoresponderResultModel result, int connectionId)
        {
            CreateReportCommand request = new CreateReportCommand
            {
                ConnectionId = connectionId,
                Feedback = feedback,
                Result = result
            };

            await _mediator.Send(request);
        }

        private async Task SendAsync(FeedbackDto feedback, string answer, int connectionId)
        {
            SendAnswerCommand requst = new SendAnswerCommand
            {
                Data = new AnswerDto
                {
                    FeedbackId = feedback.Id,
                    Text = answer
                },
                ConnectionId = connectionId,
                MarketplaceName = _marketplaceName,
                Service = _service
            };

            await _mediator.Send(requst);
        }

        private async Task<AutoresponderResultModel> CreateAnswerAsync(FeedbackDto feedback, int connectionId)
        {
            CreateResponseCommand request = new CreateResponseCommand
            {
                Article = feedback.ProductDetails.Article,
                ConnectionId = connectionId,
                Rating = feedback.Grade,
                Text = feedback.Text
            };

            return await _mediator.Send(request);
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
                MarketplaceName = _marketplaceName,
                Service = _service
            };

            return await _mediator.Send(request);
        }
    }
}
