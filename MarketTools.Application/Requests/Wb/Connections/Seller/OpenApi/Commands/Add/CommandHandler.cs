using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Wb.Connections.Seller.OpenApi.Commands.Add
{
    public class CommandHandler(IUnitOfWork _unitOfWork, 
        IAuthReadHelper _authReadHelper,
        IConnectionActivator<MarketplaceConnectionOpenApiEntity> _connectionActivator)
        : IRequestHandler<SellerOpenApiAddCommand, MarketplaceConnectionEntity>
    {
        private readonly IRepository<MarketplaceConnectionOpenApiEntity> _connectionRepository = _unitOfWork.GetRepository<MarketplaceConnectionOpenApiEntity>();

        public async Task<MarketplaceConnectionEntity> Handle(SellerOpenApiAddCommand request, CancellationToken cancellationToken)
        {
            MarketplaceConnectionOpenApiEntity newEntity = Create(request);

            await _connectionActivator.ActivateAsync(newEntity);
            await _connectionRepository.AddAsync(newEntity, cancellationToken);
            await _unitOfWork.CommintAsync(cancellationToken);

            return newEntity;
        }

        private MarketplaceConnectionOpenApiEntity Create(SellerOpenApiAddCommand request)
        {
            return new MarketplaceConnectionOpenApiEntity
            {
                Description = request.Description,
                Name = request.Name,
                Token = request.Token,
                UserId = _authReadHelper.UserId,
                MarketplaceName = MarketplaceName.WB
            };
        }
    }
}
