using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Interfaces.Http;
using MarketTools.Application.Interfaces.Http.Wb.Seller.Api;
using MarketTools.Application.Models.Autoresponder;
using MarketTools.Domain.Http.WB.Seller.Api;
using MarketTools.Domain.Http.WB.Seller.Api.Feedbaks;
using StandardAutoresponder.WorkerService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardAutoresponder.WorkerService.Services
{
    internal class WbFeedbacksHandler(IFeedbacksHttpService _feedbacksHttpService, IAutoresponderResponseService _autoresponderResponseService, ILogger<WbFeedbacksHandler> _logger)
        : IWbFeedbacksHandler
    {
        public async Task RunAsync()
        {
            try
            {
                IEnumerable<FeedbackDetails> feedbacks = await GetFeedbacksAsync();

                foreach(FeedbackDetails feedback in feedbacks)
                {
                    AutoresponderResultModel answer = BuildResponse(feedback);
                    bool isSend = await TrySendAnswerAsync(answer, feedback);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private async Task<bool> TrySendAnswerAsync(AutoresponderResultModel answer, FeedbackDetails feedback)
        {
            if (answer.IsSuccess == false || string.IsNullOrEmpty(answer.Text))
            {
                return false;
            }

            SendResponseBody body = new SendResponseBody
            {
                Id = feedback.Id,
                Text = answer.Text
            };

            await Task.Delay(100);
            //await _feedbacksHttpService.SendResponseAsync(body);
            _logger.LogInformation($"Send feedback {feedback.Id}");

            return true;
        }

        private AutoresponderResultModel BuildResponse(FeedbackDetails feedback)
        {
            AutoresponderRequestModel request = new AutoresponderRequestModel
            {
                Article = feedback.ProductDetails.NmId.ToString(),
                Rating = feedback.ProductValuation,
                Text = feedback.Text
            };

            return _autoresponderResponseService.Build(request);
        }

        private async Task<IEnumerable<FeedbackDetails>> GetFeedbacksAsync()
        {
            List<FeedbackDetails> feedbacks = new List<FeedbackDetails>();

            FeedbacksQuery query = new FeedbacksQuery
            {
                Take = 3000,
                Skip = 0,
                IsAnswered = false
            };

            WbApiResult<FeedbackResponseData> resultWithoutAnswer = await _feedbacksHttpService.GetFeedbacksAsync(query);
            feedbacks.AddRange(resultWithoutAnswer.Data.Feedbacks);

            query.IsAnswered = false;

            WbApiResult<FeedbackResponseData> resultWithAnswer = await _feedbacksHttpService.GetFeedbacksAsync(query);
            feedbacks.AddRange(resultWithAnswer.Data.Feedbacks);

            return feedbacks.Where(x=> x.Answer == null);
        }
    }
}
