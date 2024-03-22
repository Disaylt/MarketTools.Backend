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
    internal class OzonSellerAccountAnswerRequesstBodyConverter : BaseOzonSellerAccountConverter, IHttpContentConverter<AnswerRequestBody>
    {
        public HttpContent Convert(AnswerRequestBody body)
        {
            AnswerRequestJsonBody jsonBody = new AnswerRequestJsonBody
            {
                CompanyId = body.CompanyId,
                CompanyType = Convert(OzonCompanyType.Seller),
                ReviewUuid = body.ReviewUuid,
                Text = body.Text
            };

            return JsonContent.Create(jsonBody);
        }
    }
}
