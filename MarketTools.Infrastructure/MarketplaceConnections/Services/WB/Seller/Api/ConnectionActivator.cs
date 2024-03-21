using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.MarketplaceConnections.WB.Seller.Api;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Interfaces.ProjectServices;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.MarketplaceConnections.Services.WB.Seller.Api
{
    internal class WbSelleApiConnectionActivator : ConnectionActivator
    {
        private readonly IConnectionConverterFactory<IWbSellerApiConnectionConverter> _wbSellerApiConnectionBuilderFactory;
        public WbSelleApiConnectionActivator(IProjectServiceFactory<IProjectServiceValidator> _projectServiceFactory, 
            IAuthUnitOfWork _unitOfWork,
            IConnectionConverterFactory<IWbSellerApiConnectionConverter> wbSellerApiConnectionBuilderFactory) 
            : base(_projectServiceFactory, _unitOfWork)
        {
            _wbSellerApiConnectionBuilderFactory = wbSellerApiConnectionBuilderFactory;
        }

        public override Task ActivateAsync(MarketplaceConnectionEntity connection)
        {
            IWbSellerApiConnectionConverter wbSellerApiConnectionConverter = _wbSellerApiConnectionBuilderFactory.Create(connection);

            return base.ActivateAsync(connection);
        }
    }
}
