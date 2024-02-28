using AutoMapper;
using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Http;
using MarketTools.Application.Models.Http.WB.Seller;
using MarketTools.Domain.Http.WB.Seller.Api;
using MarketTools.Domain.Http.WB.Seller.Api.Feedbaks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http.Wb.Seller.Api
{
    internal class SellerOpenApiGetFeedbacksResponseConverter(IMapper _mapper)
        : IHttpResponseConverter<IEnumerable<FeedbackDto>>
    {
        public async Task<IEnumerable<FeedbackDto>> ConvertAsync(HttpResponseMessage message)
        {
            WbApiResult<FeedbackResponseData> httpResponse = await message
                .Content
                .ReadFromJsonAsync<WbApiResult<FeedbackResponseData>>()
                ?? throw new AppNotFoundException("Не удалось преобразовать json wb api отзыовов.");

            return _mapper.Map<IEnumerable<FeedbackDto>>(httpResponse.Data.Feedbacks);
        }
    }
}
