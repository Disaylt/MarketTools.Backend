using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Http;
using MarketTools.Application.Models.Autoresponder;
using MarketTools.Application.Models.Autoresponder.Standard;
using MarketTools.Domain.Http.WB.Seller.Api;
using MarketTools.Domain.Http.WB.Seller.Api.Feedbaks;
using StandardAutoresponder.WorkerService.Interfaces;

namespace StandardAutoresponder.WorkerService.Services
{
    internal class WbFeedbacksHandler(IAutoresponderResponseService _autoresponderResponseService,
        IAutoresponderReportsService _autoresponderReportsService,
        IContextService<AutoresponderContext> _autoresponderContext,
        IUnitOfWork _unitOfWork,
        ILogger<WbFeedbacksHandler> _logger,
        IExceptionHandleService<AppConnectionBadRequestException> _exceptionHandleService)
        : IWbFeedbacksHandler
    {
        public async Task RunAsync()
        {
            //try
            //{
            //    IEnumerable<FeedbackDetails> feedbacks = await GetFeedbacksAsync();

            //    foreach(FeedbackDetails feedback in feedbacks)
            //    {
            //        AutoresponderResultModel answer = BuildResponse(feedback);
            //        bool isSend = await TrySendAnswerAsync(answer, feedback);
            //        await _autoresponderReportsService.AddAsync(feedback, answer, _autoresponderContext.Context.Connection.SellerConnectionId);
            //    }
            //}
            //catch(AppConnectionBadRequestException ex)
            //{
            //    await _exceptionHandleService.Hadnle(ex);
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex.Message);
            //}
            //finally
            //{
            //    await _unitOfWork.CommitAsync();
            //}
        }

        //private async Task<bool> TrySendAnswerAsync(AutoresponderResultModel answer, FeedbackDetails feedback)
        //{
        //    if (answer.IsSuccess == false || string.IsNullOrEmpty(answer.Text))
        //    {
        //        return false;
        //    }

        //    SendResponseBody body = new SendResponseBody
        //    {
        //        Id = feedback.Id,
        //        Text = answer.Text
        //    };

        //    await _feedbacksHttpService.SendResponseAsync(body);

        //    return true;
        //}

        //private AutoresponderResultModel BuildResponse(FeedbackDetails feedback)
        //{
        //    AutoresponderRequestModel request = new AutoresponderRequestModel
        //    {
        //        Article = feedback.ProductDetails.NmId.ToString(),
        //        Rating = feedback.ProductValuation,
        //        Text = feedback.Text
        //    };

        //    return _autoresponderResponseService.Build(request);
        //}

        //private async Task<IEnumerable<FeedbackDetails>> GetFeedbacksAsync()
        //{
        //    List<FeedbackDetails> feedbacks = new List<FeedbackDetails>();

        //    FeedbacksQuery query = new FeedbacksQuery
        //    {
        //        Take = 3000,
        //        Skip = 0,
        //        IsAnswered = false
        //    };

        //    WbApiResult<FeedbackResponseData> resultWithoutAnswer = await _feedbacksHttpService.GetFeedbacksAsync(query);
        //    feedbacks.AddRange(resultWithoutAnswer.Data.Feedbacks);

        //    query.IsAnswered = true;

        //    WbApiResult<FeedbackResponseData> resultWithAnswer = await _feedbacksHttpService.GetFeedbacksAsync(query);
        //    feedbacks.AddRange(resultWithAnswer.Data.Feedbacks);

        //    return feedbacks.Where(x=> x.Answer == null);
        //}
    }
}
