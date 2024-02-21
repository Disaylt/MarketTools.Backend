using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Http.Wb.Seller.Api;
using MarketTools.Application.Interfaces.Http;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Interfaces.ProjectServices;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using MarketTools.Domain.Http.WB.Seller.Api.Feedbaks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketTools.Application.Interfaces.Common;

namespace MarketTools.Infrastructure.Autoresponder.Standard.Services
{
    internal class WbStandardAutoresponderValidator(IMarketplaceConnectionService _marketplaceConnectionService,
        IFeedbacksHttpService _feedbacksHttpService,
        IContextService<MarketplaceConnectionEntity> _contextService)
        : IServiceValidator
    {
        public async Task TryActivete(int connectionId)
        {
            _contextService.Context = await _marketplaceConnectionService.GetWithDetailsAsync(connectionId);

            FeedbacksQuery feedbacksQuery = CreateFeedbackQuery();
            await _feedbacksHttpService.GetFeedbacksAsync(feedbacksQuery);
        }

        private FeedbacksQuery CreateFeedbackQuery()
        {
            return new FeedbacksQuery
            {
                IsAnswered = false,
                Skip = 0,
                Take = 1
            };
        }
    }
}
