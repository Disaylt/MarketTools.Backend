using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Http;
using MarketTools.Application.Interfaces.MarketplaceConnections.Ozon.Seller.Account;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http.Clients
{
    internal class OzonSellerAccountHttpConnectionClient : HttpConnectionClientHandler
    {
        private readonly IOzonSellerAccountConnectionService _ozonSellerAccountConnectionService;
        private readonly IRepository<MarketplaceConnectionEntity> _repository;

        public OzonSellerAccountHttpConnectionClient(IHttpConnectionContextService connectionContextReader, 
            IOzonSellerAccountConnectionService ozonSellerAccountConnectionService,
            IUnitOfWork unitOfWork) 
            : base(connectionContextReader, MarketplaceName.OZON, MarketplaceConnectionType.Account)
        {
            _repository = unitOfWork.GetRepository<MarketplaceConnectionEntity>();
            ozonSellerAccountConnectionService.Connection = Connection;
            _ozonSellerAccountConnectionService = ozonSellerAccountConnectionService;
        }

        public override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage)
        {
            HttpResponseMessage response = await base.SendAsync(httpRequestMessage);

            _ozonSellerAccountConnectionService.ChangeAllCookies(ClientHandler.CookieContainer);
            UpdateCookies();

            return response;
        }

        private void UpdateCookies()
        {
            _ozonSellerAccountConnectionService.ChangeAllCookies(ClientHandler.CookieContainer);

            if(_ozonSellerAccountConnectionService.IsChanged)
            {
                _repository.Update(Connection);
            }
        }
    }
}
