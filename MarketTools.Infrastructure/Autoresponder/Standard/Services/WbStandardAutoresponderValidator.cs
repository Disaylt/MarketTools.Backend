using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Http;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Interfaces.ProjectServices;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Http.Wb;
using MarketTools.Application.Interfaces.Http.Wb.Seller;
using MarketTools.Application.Models.Http.WB.Seller;

namespace MarketTools.Infrastructure.Autoresponder.Standard.Services
{
    internal class WbStandardAutoresponderValidator(IWbHttpRequestFactory<IWbSellerFeedbacksHttpService> _feedbacksHttpService,
        IProjectServiceFactory<IConnectionDefinitionService> _connectionDefinitionServiceFactory)
        : IServiceValidator
    {
        public async Task TryActivete()
        {
            IWbSellerFeedbacksHttpService wbSellerFeedbacksHttpService = GetWbSellerFeedbacksHttpService();
            FeedbacksGetDto query = CreateRequestData();
            await wbSellerFeedbacksHttpService.GetFeedbacksAsync(query);
        }

        private IWbSellerFeedbacksHttpService GetWbSellerFeedbacksHttpService()
        {
            MarketplaceConnectionType connectionType = _connectionDefinitionServiceFactory
                .Create(EnumProjectServices.StandardAutoresponder, MarketplaceName.WB)
                .Get();
            
            return _feedbacksHttpService
                .Create(connectionType);
        }

        private FeedbacksGetDto CreateRequestData()
        {
            return new FeedbacksGetDto
            {
                IsAnswered = true,
                Take = 1,
                Skip = 0
            };
                
        }
    }
}
