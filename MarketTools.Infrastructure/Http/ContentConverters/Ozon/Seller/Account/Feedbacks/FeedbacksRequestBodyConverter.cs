using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Http;
using MarketTools.Application.Models.Http.Ozon.Seller.Account;
using MarketTools.Application.Models.Http.Ozon.Seller.Account.Feedbacks;
using MarketTools.Infrastructure.Http.Models.Ozon.Seller.Account.Feedbacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http.ContentConverters.Ozon.Seller.Account.Feedbacks
{
    internal class OzonSellerAccountFeedbacksRequestBodyConverter : BaseOzonSellerAccountConverter, IHttpContentConverter<FeedbacksRequestBody>
    {
        public HttpContent Convert(FeedbacksRequestBody body)
        {
            FeedbacksRequestJsonBody jsonBody = new FeedbacksRequestJsonBody
            {
                CompanyId = body.CompanyId,
                CompanyType = Convert(OzonCompanyType.Seller),
                PaginationLastTimestamp = body.PaginationLastTimestamp,
                PaginationLastUuid = body.PaginationLastUuid
            };

            foreach(InteractionStatus status in body.InteractionStatus)
            {
                string strStatus = Convert(status);
                jsonBody.Filter.InteractionStatus.Add(strStatus);
            }

            foreach(int rating in body.Rating)
            {
                jsonBody.Filter.Rating.Add(rating);
            }

            jsonBody.Sort.SortBy = Convert(body.SortBy);
            jsonBody.Sort.SortDirection = Convert(body.OrderType);

            return JsonContent.Create(jsonBody);
        }

        protected string Convert(InteractionStatus status)
        {
            return status switch
            {
                InteractionStatus.All => "ALL",
                InteractionStatus.Viewed => "VIEWED",
                InteractionStatus.NotViewed => "NOT_VIEWED",
                _ => throw new AppNotFoundException("Невозможна конвертация типа фильтрации.")
            };
        }
    }
}
