using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Http;
using MarketTools.Application.Interfaces.Http.Wb.Seller.Api;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Interfaces.ProjectServices;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using MarketTools.Domain.Http.WB.Seller.Api.Feedbaks;

namespace MarketTools.Application.Services.Autroesponder.Standard
{
    internal class WbAutoresponderValidator(IAuthUnitOfWork _authUnitOfWork,
        IHttpConnectionFactory<IFeedbacksHttpService> _httpConnectionFactory,
        IConnectionServiceFactory<IConnectionSerivceDeterminant> _connectionServiceFactory) 
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
                .Create(MarketplaceName.WB)
                .Create(EnumProjectServices.StandardAutoresponder)
                .GetAsync(_authUnitOfWork, connectionId); ;
        }
    }
}
