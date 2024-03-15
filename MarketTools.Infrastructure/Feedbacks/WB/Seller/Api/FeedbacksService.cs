﻿using AutoMapper;
using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Feedbacks;
using MarketTools.Application.Interfaces.Http.Wb.Seller.Api;
using MarketTools.Application.Models.Feedbacks;
using MarketTools.Application.Models.Http.WB.Seller.Api;
using MarketTools.Application.Models.Http.WB.Seller.Api.Feedbacks;
using ProductDetails = MarketTools.Application.Models.Feedbacks.ProductDetails;

namespace MarketTools.Infrastructure.Feedbacks.WB.Seller.Api
{
    internal class WbSellerApiFeedbacksService(IWbSellerApiFeedbacksService _wbSellerApiFeedbacksService) : IFeedbacksService
    {
        public async Task<IEnumerable<FeedbackDto>> GetFeedbacksAsync(FeedbacksQueryDto data)
        {
            FeedbacksQuery feedbacksQuery = MapQuery(data);
            WbApiResult<FeedbackResponseData> result = await _wbSellerApiFeedbacksService.GetFeedbacksAsync(feedbacksQuery);

            return MapFeedbacks(result);
        }

        public async Task SendAnswerAsync(AnswerDto data)
        {
            ResponseBody answer = MapAnswer(data);
            await _wbSellerApiFeedbacksService.SendResponseAsync(answer);
        }

        private ResponseBody MapAnswer(AnswerDto data)
        {
            return new ResponseBody
            {
                Id = data.FeedbackId,
                Text = data.Text
            };
        }

        private IEnumerable<FeedbackDto> MapFeedbacks(WbApiResult<FeedbackResponseData> data)
        {
            return data
                .Data
                .Feedbacks
                .Select(x => new FeedbackDto
                {
                    Id = x.Id,
                    Answer = x.Answer?.Text,
                    CreatedDate = x.CreatedDate,
                    Grade = x.ProductValuation,
                    Text = x.Text,
                    ProductDetails = new ProductDetails
                    {
                        Article = x.ProductDetails.NmId.ToString(),
                        SellerArticle = x.ProductDetails.SupplierArticle,
                        ProductName = x.ProductDetails.ProductName
                    }
                });
        }

        private FeedbacksQuery MapQuery(FeedbacksQueryDto data)
        {
            if(data.Grade != null)
            {
                throw new AppBadRequestException("WB API не поддерживает поиск отзывов по оценке.");
            }

            FeedbacksQuery query = new FeedbacksQuery
            {
                IsAnswered = data.IsAnswered,
                Skip = data.Skip,
                Take = data.Take,
                Order = data.Order
            };

            if (data.DateFrom.HasValue)
            {
                query.DateFrom = ((DateTimeOffset)data.DateFrom.Value).ToUnixTimeSeconds();
            }

            if (data.DateTo.HasValue)
            {
                query.DateTo = ((DateTimeOffset)data.DateTo.Value).ToUnixTimeSeconds();
            }

            if(data.Article != null && int.TryParse(data.Article, out int articleResult))
            {
                query.NmId = articleResult;
            }

            return query;
        }
    }
}