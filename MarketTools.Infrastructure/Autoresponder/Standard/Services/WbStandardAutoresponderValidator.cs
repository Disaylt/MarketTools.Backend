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

namespace MarketTools.Infrastructure.Autoresponder.Standard.Services
{
    internal class WbStandardAutoresponderValidator(IAuthUnitOfWork _authUnitOfWork,
        IHttpConnectionFactory<IFeedbacksHttpService> _httpConnectionFactory,
        IProjectServiceFactory<IConnectionDeterminantService> _connectionServiceFactory)
        : IServiceValidator
    {
        public async Task TryActivete(int connectionId)
        {
            MarketplaceConnectionEntity entity = await GetConnection(connectionId);

            FeedbacksQuery feedbacksQuery = CreateFeedbackQuery();

            await _httpConnectionFactory.Create(entity)
                .GetFeedbacksAsync(feedbacksQuery);
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

        private async Task<MarketplaceConnectionEntity> GetConnection(int connectionId)
        {
            return await _connectionServiceFactory
                .Create(EnumProjectServices.StandardAutoresponder)
                .Create(MarketplaceName.WB)
                .GetAsync(_authUnitOfWork, connectionId); ;
        }
    }
}
