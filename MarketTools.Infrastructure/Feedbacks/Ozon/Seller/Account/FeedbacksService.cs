using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Feedbacks;
using MarketTools.Application.Interfaces.Http;
using MarketTools.Application.Interfaces.Http.Ozon.Seller.Account;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Interfaces.MarketplaceConnections.Ozon.Seller.Account;
using MarketTools.Application.Models.Feedbacks;
using MarketTools.Application.Models.Http.Ozon.Seller.Account;
using MarketTools.Application.Models.Http.Ozon.Seller.Account.Feedbacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Feedbacks.Ozon.Seller.Account
{
    internal class OzonSellerAccountFeedbacksService(IOzonSellerAccountFeedbacksHttpService _ozonSellerAccountFeedbacksHttpService,
        IConnectionConverterFactory<IOzonSellerAccountConnectionConverter> _ozonSellerAccountConnectionServiceFactory)
        : IFeedbacksService
    {
        private readonly IOzonSellerAccountConnectionConverter _ozonSellerAccountConnectionConverter = _ozonSellerAccountConnectionServiceFactory.CreateFromHttpContext();
        private const int _maxIteration = 10;

        public async Task<IEnumerable<FeedbackDto>> GetFeedbacksAsync(FeedbacksQueryDto data)
        {
            IEnumerable<FeedbackDto> allFeedbacks = new List<FeedbackDto>();

            ValidateRequest(data);
            IEnumerable<InteractionStatus> interactStatuses = ConvertStatuses(data.Types);
            string? paginationLastTimestamp = null;
            string? paginationLastUuid = null;
            int currentIteration = 0;

            while (data.Skip < data.Take || currentIteration > _maxIteration)
            {
                currentIteration += 1;

                FeedbacksRequestBody body = MapFeedbackRequestBody(data, interactStatuses, paginationLastTimestamp, paginationLastUuid);
                FeedbacksResponseBody responseBody = await _ozonSellerAccountFeedbacksHttpService.GetFeedbacksAsync(body);
                IEnumerable<FeedbackDto> feedbacks = MapFeedbacks(responseBody);
                allFeedbacks = allFeedbacks.Concat(feedbacks);

                if(responseBody.HasNext)
                {
                    data.Skip += responseBody.Result.Count;
                    paginationLastTimestamp = responseBody.PaginationLastTimestamp;
                    paginationLastUuid = responseBody.PaginationLastUuid;
                    await Task.Delay(500);
                }
                else
                {
                    break;
                }
            }

            return allFeedbacks;
        }

        public async Task SendAnswerAsync(AnswerDto data)
        {
            AnswerRequestBody body = new AnswerRequestBody
            {
                CompanyId = _ozonSellerAccountConnectionConverter.GetRequiredSellerId(),
                ReviewUuid = data.FeedbackId,
                Text = data.Text
            };
            await _ozonSellerAccountFeedbacksHttpService.SendResponseAsync(body);
        }

        private IEnumerable<FeedbackDto> MapFeedbacks(FeedbacksResponseBody responseBody)
        {
            return responseBody
                .Result
                .Select(x => new FeedbackDto
                {
                    Answer = x.CommentsAmount > 0 || x.CommentsCount > 0 ? "More than 0" : null,
                    CreatedDate = x.PublishedAt,
                    Grade = x.Rating,
                    Id = x.Uuid,
                    ProductDetails = new ProductDetails
                    {
                        Article = x.Id,
                        SellerArticle = x.Sku,
                        ProductName = x.Product.Title
                    },
                    Text = $"{x.Text.Comment}{x.Text.Negative}{x.Text.Positive}"
                });
        }

        private IEnumerable<InteractionStatus> ConvertStatuses(IEnumerable<FeedbacksType> feedbacksTypes)
        {
            List<InteractionStatus> statuses = new List<InteractionStatus>();

            foreach(FeedbacksType type in feedbacksTypes)
            {
                switch(type)
                {
                    case FeedbacksType.New:
                        statuses.Add(InteractionStatus.NotViewed);
                        break;
                    case FeedbacksType.Viewed:
                        statuses.Add(InteractionStatus.Viewed);
                        break;
                    default: throw new AppNotFoundException("Такой тип отзывов не поддерживается.");
                }
            }

            return statuses;
        }

        private FeedbacksRequestBody MapFeedbackRequestBody(FeedbacksQueryDto data, IEnumerable<InteractionStatus> statuses, string? paginationLastTimestamp, string? paginationLastUuid)
        {
            FeedbacksRequestBody body = new FeedbacksRequestBody
            {
                CompanyId = _ozonSellerAccountConnectionConverter.GetRequiredSellerId(),
                OrderType = data.Order,
                PaginationLastTimestamp = paginationLastTimestamp,
                PaginationLastUuid = paginationLastUuid,
                Rating = data.Grades,
                SortBy = SortBy.PublishedAt
            };
            body.InteractionStatus.Concat(statuses);

            return body;
        }

        private void ValidateRequest(FeedbacksQueryDto data)
        {
            if(data.Take > 100)
            {
                throw new AppBadRequestException("Невозможно получить более 100 отзывов.");
            }

            if(data.Skip > 0)
            {
                throw new AppBadRequestException("Невозможно изначально пропустить отзывы на озон.");
            }
        }
    }
}
