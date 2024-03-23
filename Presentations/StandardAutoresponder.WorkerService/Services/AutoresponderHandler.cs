using MarketTools.Application.Models.Autoresponder;
using MarketTools.Application.Models.Feedbacks;
using MarketTools.Application.Requests.Autoresponder.Standard.Reports.Commands;
using MarketTools.Application.Requests.Autoresponder.Standard.Response.Command;
using MarketTools.Application.Requests.Feedbacks.Commands;
using MarketTools.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardAutoresponder.WorkerService.Services
{
    internal class AutoresponderHandler(IMediator _mediator, MarketplaceName _marketplaceName)
    {
        public async Task HandleAsync(FeedbackDto feedback, int connectionId)
        {
            AutoresponderResultModel result = await CreateAnswerAsync(feedback, connectionId);
            if (result.IsSuccess && result.Text != null)
            {
                await SendAsync(feedback, result.Text, connectionId);
            }
            await CreateReportAsync(feedback, result, connectionId);
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
                Service = EnumProjectServices.StandardAutoresponder
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
    }
}
