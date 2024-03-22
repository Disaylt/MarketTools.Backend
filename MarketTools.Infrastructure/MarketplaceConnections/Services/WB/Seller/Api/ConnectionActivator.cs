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

        public override async Task ActivateAsync(MarketplaceConnectionEntity connection)
        {
            if (IsSkipActivate(connection))
            {
                connection.IsActive = false;
                return;
            }

            await base.ActivateAsync(connection);
        }

        private bool IsSkipActivate(MarketplaceConnectionEntity connection)
        {
            IWbSellerApiConnectionConverter wbSellerApiConnectionConverter = _wbSellerApiConnectionBuilderFactory.Create(connection);
            string? value = wbSellerApiConnectionConverter.GetToken();

            return string.IsNullOrEmpty(value);
        }
    }
}
