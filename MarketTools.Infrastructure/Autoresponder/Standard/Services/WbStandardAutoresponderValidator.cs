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
    internal class WbStandardAutoresponderValidator(IAuthUnitOfWork _authUnitOfWork,
        IFeedbacksHttpService _feedbacksHttpService,
        IContextService<MarketplaceConnectionEntity> _contextService,
        IProjectServiceFactory<IConnectionDeterminantService> _connectionServiceFactory)
        : IServiceValidator
    {
        private readonly IRepository<MarketplaceConnectionEntity> _connectionEntityRepository = _authUnitOfWork.GetRepository<MarketplaceConnectionEntity>();

        public async Task TryActivete(int connectionId)
        {
            await SetHttpConnectionContextAsync(connectionId);

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

        private async Task SetHttpConnectionContextAsync(int connectionId)
        {
            MarketplaceConnectionEntity entity = await _connectionEntityRepository
                .FirstAsync(x=> x.i)

            _httpConnectionContextService.Write(entity);
        }
    }
}
