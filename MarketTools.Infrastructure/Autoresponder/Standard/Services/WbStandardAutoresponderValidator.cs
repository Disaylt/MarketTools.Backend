using MarketTools.Application.Interfaces.Database;
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
using MarketTools.Application.Interfaces.Http.Wb;
using MarketTools.Application.Interfaces.Http.Wb.Seller;
using MarketTools.Domain.Interfaces.Http;
using MarketTools.Application.Utilities.HttpParamsBuilder.WB.Seller;

namespace MarketTools.Infrastructure.Autoresponder.Standard.Services
{
    internal class WbStandardAutoresponderValidator(IWbHttpRequestFactory<IWbSellerFeedbacksHttpService> _feedbacksHttpService,
        IProjectServiceFactory<IConnectionDefinitionService> _connectionDefinitionServiceFactory)
        : IServiceValidator
    {
        public async Task TryActivete()
        {
            IWbSellerFeedbacksHttpService wbSellerFeedbacksHttpService = GetWbSellerFeedbacksHttpService();
            IParamsBuilder paramsBuilder = CreateFeedbackParamsBuilder();
            await wbSellerFeedbacksHttpService.GetFeedbacksAsync(paramsBuilder);
        }

        private IWbSellerFeedbacksHttpService GetWbSellerFeedbacksHttpService()
        {
            MarketplaceConnectionType connectionType = _connectionDefinitionServiceFactory
                .Create(EnumProjectServices.StandardAutoresponder, MarketplaceName.WB)
                .Get();
            
            return _feedbacksHttpService
                .Create(connectionType);
        }

        private IParamsBuilder CreateFeedbackParamsBuilder()
        {
            return new WbSellerGetFeedbacksParamBuilder()
                .Take(1)
                .Skip(0)
                .IsAnswered(true);
                
        }
    }
}
