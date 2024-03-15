using MarketTools.Application.Interfaces.Feedbacks;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Interfaces.ProjectServices;
using MarketTools.Application.Models.Feedbacks;
using MarketTools.Domain.Entities;

namespace MarketTools.Infrastructure.Autoresponder.Standard.Services
{
    internal class StandardAutoresponderValidator(IConnectionServiceFactory<IFeedbacksService> _feedbacksServiceFactory) : IProjectServiceValidator
    {
        public async Task ActivateAsync(MarketplaceConnectionEntity connection)
        {
            FeedbacksQueryDto query = CreateQuery();
            await _feedbacksServiceFactory
                .Create(connection.ConnectionType, connection.MarketplaceName)
                .GetFeedbacksAsync(query);
        }

        public async Task<bool> TryActivateAsync(MarketplaceConnectionEntity connection)
        {
            try
            {
                await ActivateAsync(connection);
            }
            catch
            {
                return false;
            }

            return true;
        }

        private FeedbacksQueryDto CreateQuery()
        {
            return new FeedbacksQueryDto
            {
                IsAnswered = false,
                Skip = 0,
                Take = 0
            };
        }
    }
}
