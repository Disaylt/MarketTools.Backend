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
using MarketTools.Application.Interfaces.Feedbacks;

namespace MarketTools.Infrastructure.Autoresponder.Standard.Services
{
    internal class WbStandardAutoresponderValidator(IConnectionServiceFactory<IFeedbacksService> _feedbacksService,
        IProjectServiceFactory<IConnectionDefinitionFactory> _connectionDefinitionServiceFactory)
        : IServiceValidator
    {
        public async Task TryActivete()
        {
            //IWbSellerFeedbacksHttpService wbSellerFeedbacksHttpService = GetWbSellerFeedbacksHttpService();
            //FeedbacksGetDto query = CreateRequestData();
            //await wbSellerFeedbacksHttpService.GetFeedbacksAsync(query);
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
