using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.MarketplaceConnections.Ozon.Seller.Account;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Interfaces.ProjectServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketTools.Domain.Entities;

namespace MarketTools.Infrastructure.MarketplaceConnections.Services.OZON.Seller.Account
{
    internal class OzonSellerAccountConnectionActivator : ConnectionActivator
    {
        private readonly IConnectionConverterFactory<IOzonSellerAccountConnectionConverter> _ozonSellerAccountConnectionConverterFactory;
        public OzonSellerAccountConnectionActivator(IProjectServiceFactory<IProjectServiceValidator> _projectServiceFactory,
            IConnectionConverterFactory<IOzonSellerAccountConnectionConverter> ozonSellerAccountConnectionConverterFactory,
            IAuthUnitOfWork _unitOfWork) 
            : base(_projectServiceFactory, _unitOfWork)
        {
            _ozonSellerAccountConnectionConverterFactory = ozonSellerAccountConnectionConverterFactory;
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
            IOzonSellerAccountConnectionConverter ozonSellerAccountConnectionConverter = _ozonSellerAccountConnectionConverterFactory.Create(connection);
            string? token = ozonSellerAccountConnectionConverter.GetRefreshToken();

            return string.IsNullOrEmpty(token);
        }
    }
}
